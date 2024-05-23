using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class Contratos : Form
    {
        public Contratos()
        {
            InitializeComponent();
        }
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);//con casa
        bool isEditing = false;
        private void Contratos_Load(object sender, EventArgs e)
        {
            // Ocultar botões e desativar o botão de inserção
            btnCancel.Hide();
            btnUpdate.Hide();
            btnIns.Enabled = false;
            btnDel.Enabled = false;
            btnEdit.Hide();
            EditOn();
            btnClear.Hide();
            BD.Open();

            // Selecionar os dados dos contratos e dos clientes
            string query = "SELECT Contrato.ID_Contrato, Contrato.Id_cliente, Cliente.Nome, Contrato.Telefone, Contrato.Morada, Contrato.Potencia, Contrato.Metodo_Pagamento FROM Contrato INNER JOIN Cliente ON Contrato.Id_cliente = Cliente.Id_cliente";

            SqlCommand cmd = new SqlCommand(query, BD);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem item = new ListViewItem(rdr["ID_Contrato"].ToString());
                item.SubItems.Add(rdr["Id_cliente"].ToString());
                item.SubItems.Add(rdr["Nome"].ToString());
                item.SubItems.Add(rdr["Telefone"].ToString());
                item.SubItems.Add(rdr["Morada"].ToString());
                item.SubItems.Add(rdr["Potencia"].ToString());
                item.SubItems.Add(rdr["Metodo_Pagamento"].ToString());
                listView1.Items.Add(item);
            }
            rdr.Close();
            // Preencher o ComboBox com os IDs dos clientes
            SqlCommand cmd2 = new SqlCommand("SELECT id_cliente FROM cliente", BD);
            SqlDataReader rd = cmd2.ExecuteReader();
            {
                while (rd.Read())
                {
                    cmbNIF.Items.Add(rd["id_cliente"].ToString());
                }
            }
            rd.Close();
            BD.Close();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Show();
            btnCancel.Show();
            btnEdit.Hide();
            EditOn();
            ClientEdit();
            isEditing = true;
        }
        private bool CheckContratoChanges(string contratoId)
        {
            bool updateContrato = false;

            // Prepare o comando SQL para recuperar os registros para o item selecionado
            using (SqlCommand selectContratoCmd = new SqlCommand("SELECT Morada, Telefone, Potencia, Metodo_Pagamento FROM Contrato WHERE ID_Contrato=@selectedId", BD))
            {
                selectContratoCmd.Parameters.AddWithValue("@selectedId", contratoId);

                using (SqlDataReader rdr = selectContratoCmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        if (txtMoradaCont.Text != rdr["Morada"].ToString() ||
                            txtTel.Text != rdr["Telefone"].ToString() ||
                            cmbMet.Text != rdr["Metodo_Pagamento"].ToString() ||
                            cmbPot.Text != rdr["Potencia"].ToString())
                        {
                            updateContrato = true;
                        }
                    }
                }
            }

            return updateContrato;
        }
        private bool CheckClienteChanges(string clienteId)
        {
            bool updateCliente = false;

            // Prepare o comando SQL para recuperar as informações do cliente
            using (SqlCommand selectClienteCmd = new SqlCommand("SELECT endereco, contato, codPostal, nome FROM Cliente WHERE Id_cliente=@Id_cliente", BD))
            {
                selectClienteCmd.Parameters.AddWithValue("@Id_cliente", clienteId);

                using (SqlDataReader rdr = selectClienteCmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        string[] cod = rdr["codPostal"].ToString().Split('-');
                        if (txtNome.Text != rdr["nome"].ToString() ||
                            txtContato.Text != rdr["contato"].ToString() ||
                            txtMoradaCliente.Text != rdr["endereco"].ToString() ||
                            txtCodP1.Text != cod[0] || txtCodP2.Text != cod[1])
                        {
                            updateCliente = true;
                        }
                    }
                }
            }

            return updateCliente;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Abra a conexão com o banco de dados
                BD.Open();

                // Prepare o comando SQL para atualizar os registros do contrato
                SqlCommand updateContratoCmd = new SqlCommand("UPDATE Contrato SET Morada=@Morada, Telefone=@Telefone, Potencia=@Potencia, Metodo_Pagamento=@Metodo WHERE ID_Contrato=@selectedId", BD);

                // Prepare o comando SQL para atualizar os registros do cliente
                SqlCommand updateClienteCmd = new SqlCommand("UPDATE Cliente SET nome=@nome,endereco=@endereco, Contato=@Cont,codPostal=@codPostal WHERE Id_cliente=@Id_cliente", BD);

                // Iterar por cada item selecionado na ListView
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    string contratoId = selectedItem.SubItems[0].Text;
                    string clienteId = selectedItem.SubItems[1].Text;

                    bool updateContrato = CheckContratoChanges(contratoId);
                    bool updateCliente = CheckClienteChanges(clienteId);

                    if (updateContrato && updateCliente)
                    {
                        updateContratoCmd.Parameters.Clear();
                        updateClienteCmd.Parameters.Clear();

                        updateContratoCmd.Parameters.AddWithValue("@selectedId", contratoId);
                        updateContratoCmd.Parameters.AddWithValue("@Morada", txtMoradaCont.Text);
                        updateContratoCmd.Parameters.AddWithValue("@Telefone", txtTel.Text);
                        updateContratoCmd.Parameters.AddWithValue("@Metodo", cmbMet.SelectedItem.ToString());
                        updateContratoCmd.Parameters.AddWithValue("@Potencia", cmbPot.SelectedItem.ToString());
                        int row = updateContratoCmd.ExecuteNonQuery();

                        string Postal = txtCodP1.Text + "-" + txtCodP2.Text;
                        updateClienteCmd.Parameters.AddWithValue("@Id_cliente", clienteId);
                        updateClienteCmd.Parameters.AddWithValue("@endereco", txtMoradaCliente.Text);
                        updateClienteCmd.Parameters.AddWithValue("@Cont", txtContato.Text);
                        updateClienteCmd.Parameters.AddWithValue("@codPostal", Postal);
                        updateClienteCmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        int row2 = updateClienteCmd.ExecuteNonQuery();

                        if (row + row2 > 1)
                        {
                            MessageBox.Show("Cliente e Contrato Atualizados");
                            isEditing = false;
                            Reset();
                            btnIns.Enabled = false;
                            listView1.SelectedItems.Clear();
                            btnCancel.Hide();
                            btnClear.Enabled = false;
                            btnEdit.Hide();
                            btnUpdate.Hide();
                        }
                    }
                    else if (updateContrato && !updateCliente)
                    {
                        updateContratoCmd.Parameters.Clear();

                        updateContratoCmd.Parameters.AddWithValue("@selectedId", contratoId);
                        updateContratoCmd.Parameters.AddWithValue("@Morada", txtMoradaCont.Text);
                        updateContratoCmd.Parameters.AddWithValue("@Telefone", txtTel.Text);
                        updateContratoCmd.Parameters.AddWithValue("@Metodo", cmbMet.SelectedItem.ToString());
                        updateContratoCmd.Parameters.AddWithValue("@Potencia", cmbPot.SelectedItem.ToString());
                        int row = updateContratoCmd.ExecuteNonQuery();
                        if (row > 0)
                        {
                            MessageBox.Show("Contrato Atualizado");
                            Reset();
                            isEditing = false;
                            btnIns.Enabled = false;
                            listView1.SelectedItems.Clear();
                            btnCancel.Hide();
                            btnClear.Enabled = false;
                            btnEdit.Hide();
                            btnUpdate.Hide();
                        }

                    }
                    else if (!updateContrato && updateCliente)
                    {
                        DialogResult result = MessageBox.Show("Não é possível atualizar apenas o cliente.\r\nPara concluir a atualização necessita de alterar o contrato.\r\nDeseja continuar?", "Confirmação", MessageBoxButtons.YesNo);

                        if (result == DialogResult.No)
                        {
                            isEditing = false;
                            Reset();
                            btnIns.Enabled = false;
                            listView1.SelectedItems.Clear();
                            btnCancel.Hide();
                            btnClear.Enabled = false;
                            btnEdit.Hide();
                            btnUpdate.Hide();
                        }
                        else
                        {
                            isEditing = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Feche a conexão com o banco de dados após o uso
                BD.Close();
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Delete from Copntrato where ID_Contrato=@ID", BD);
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    cmd.Parameters.AddWithValue("@ID", selectedItem.SubItems[0].Text);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Eliminados");
                        listView1.Items.Remove(selectedItem);
                        Reset();
                        listView1.SelectedItems.Clear();
                        btnDel.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Erro");
                    }
                }
                BD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { BD.Close(); }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();

                bool UpdateContrato = false;
                bool UpdateCliente = false;

                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    string contratoId = selectedItem.SubItems[0].Text;
                    string clienteId = selectedItem.SubItems[1].Text;

                    UpdateContrato = CheckContratoChanges(contratoId);
                    UpdateCliente = CheckClienteChanges(clienteId);

                    if (UpdateContrato && UpdateCliente)
                    {
                        using (SqlCommand updateContratoCmd = new SqlCommand("UPDATE Contrato SET Morada=@Morada, Telefone=@Telefone, Potencia=@Potencia, Metodo_Pagamento=@Metodo WHERE ID_Contrato=@selectedId", BD))
                        {
                            updateContratoCmd.Parameters.AddWithValue("@selectedId", contratoId);
                            updateContratoCmd.Parameters.AddWithValue("@Morada", txtMoradaCont.Text);
                            updateContratoCmd.Parameters.AddWithValue("@Telefone", txtTel.Text);
                            updateContratoCmd.Parameters.AddWithValue("@Metodo", cmbMet.SelectedItem);
                            updateContratoCmd.Parameters.AddWithValue("@Potencia", cmbPot.SelectedItem);
                            updateContratoCmd.ExecuteNonQuery();
                        }

                        using (SqlCommand updateClienteCmd = new SqlCommand("UPDATE Cliente SET nome=@nome,endereco=@endereco, Contato=@Cont,codPostal=@codPostal WHERE Id_cliente=@Id_cliente", BD))
                        {
                            string Postal = txtCodP1.Text + "-" + txtCodP2.Text;
                            updateClienteCmd.Parameters.AddWithValue("@Id_cliente", clienteId);
                            updateClienteCmd.Parameters.AddWithValue("@nome", txtNome.Text);
                            updateClienteCmd.Parameters.AddWithValue("@endereco", txtMoradaCliente.Text);
                            updateClienteCmd.Parameters.AddWithValue("@Cont", txtContato.Text);
                            updateClienteCmd.Parameters.AddWithValue("@codPostal", Postal);
                            updateClienteCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Cliente e Contrato Atualizados");
                        Reset();
                        btnIns.Enabled = false;
                        listView1.SelectedItems.Clear();
                        btnCancel.Hide();
                        btnClear.Enabled = false;
                        btnEdit.Hide();
                        btnUpdate.Hide();
                    }
                    else if (UpdateContrato && !UpdateCliente)
                    {
                        using (SqlCommand updateContratoCmd = new SqlCommand("UPDATE Contrato SET Morada=@Morada, Telefone=@Telefone, Potencia=@Potencia, Metodo_Pagamento=@Metodo WHERE ID_Contrato=@selectedId", BD))
                        {
                            updateContratoCmd.Parameters.AddWithValue("@selectedId", contratoId);
                            updateContratoCmd.Parameters.AddWithValue("@Morada", txtMoradaCont.Text);
                            updateContratoCmd.Parameters.AddWithValue("@Telefone", txtTel.Text);
                            updateContratoCmd.Parameters.AddWithValue("@Metodo", cmbMet.SelectedItem);
                            updateContratoCmd.Parameters.AddWithValue("@Potencia", cmbPot.SelectedItem);
                            updateContratoCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Contrato Atualizado");
                        Reset();
                        btnIns.Enabled = false;
                        listView1.SelectedItems.Clear();
                        btnCancel.Hide();
                        btnClear.Enabled = false;
                        btnEdit.Hide();
                        btnUpdate.Hide();
                    }
                    else if (UpdateCliente)
                    {
                        DialogResult result = MessageBox.Show("Não é possível atualizar apenas o cliente.\r\nPara concluir a atualização necessita de alterar o contrato.\r\nDeseja continuar?", "Confirmação", MessageBoxButtons.YesNo);

                        if (result == DialogResult.No)
                        {
                            Reset();
                            btnIns.Enabled = false;
                            listView1.SelectedItems.Clear();
                            btnCancel.Hide();
                            btnClear.Enabled = false;
                            btnEdit.Hide();
                            btnUpdate.Hide();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Não existe alterações. Deseja continuar mesmo assim?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            Reset();
                            isEditing = false;
                            btnIns.Enabled = false;
                            listView1.SelectedItems.Clear();
                            btnCancel.Hide();
                            btnClear.Enabled = false;
                            btnEdit.Hide();
                            btnUpdate.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                BD.Close();
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se algum item está selecionado
            if (listView1.SelectedItems.Count == 0)
            {
                Reset();
                btnIns.Enabled = false;
                listView1.SelectedItems.Clear();
                btnCancel.Hide();
                btnClear.Enabled = false;
                btnEdit.Hide();
                btnUpdate.Hide();
                EditOn();
            }
            else
            {
                try
                {
                    // Obtenha o primeiro item selecionado
                    ListViewItem selectedItem = listView1.SelectedItems[0];

                    // Obtenha o NIF do cliente do subitem na posição 1
                    string nif = selectedItem.SubItems[1].Text;

                    // Defina o NIF selecionado no ComboBox cmbNIF
                    cmbNIF.SelectedItem = nif;

                    // Preencha os outros campos com base no item selecionado
                    cmbPot.SelectedItem = selectedItem.SubItems[5].Text;
                    cmbMet.SelectedItem = selectedItem.SubItems[6].Text;
                    txtMoradaCont.Text = selectedItem.SubItems[4].Text;
                    txtTel.Text = selectedItem.SubItems[3].Text;

                    // Desative os controles conforme necessário
                    btnIns.Enabled = false;
                    btnEdit.Show();
                    btnDel.Enabled = true;
                    btnClear.Show();
                    btnClear.Enabled = true;
                    EditOFF();
                }
                catch (Exception ex)
                {
                    // Lidar com qualquer exceção ocorrida
                    MessageBox.Show("Ocorreu um erro ao selecionar o item: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void EditOFF()
        {
            txtNome.Enabled = false;
            txtMoradaCliente.Enabled = false;
            txtContato.Enabled = false;
            txtCodP1.Enabled = false;
            txtCodP2.Enabled = false;
            txtMoradaCont.Enabled = false;
            cmbPot.Enabled = false;
            cmbMet.Enabled = false;
            txtTel.Enabled = false;
        }
        private void ClientEdit()
        {
            txtNome.Enabled = true;
            txtMoradaCliente.Enabled = true;
            txtContato.Enabled = true;
            txtCodP1.Enabled = true;
            txtCodP2.Enabled = true;
        }
        private void EditOn()
        {
            txtMoradaCont.Enabled = true;
            cmbPot.Enabled = true;
            cmbMet.Enabled = true;
            txtTel.Enabled = true;
        }
        private void Reset()
        {
            cmbMet.SelectedItem = null;
            cmbNIF.SelectedItem = null;
            cmbPot.SelectedItem = null;

            txtCodP1.Text = "";
            txtCodP2.Text = "";
            txtContato.Text = "";
            txtMoradaCliente.Text = "";
            txtMoradaCont.Text = "";
            txtTel.Text = "";
            txtNome.Text = "";

        }
        private void btnIns_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Insert into Contrato(Morada,Telefone,Potencia,Metodo_Pagamento,Id_Cliente) values(@Morada,@telefone,@Potencia,@metodo_pagamento,@Id_cliente)", BD);
            cmd.Parameters.AddWithValue("@Morada", txtMoradaCont.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTel.Text);
            cmd.Parameters.AddWithValue("@Potencia", cmbPot.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@metodo_pagamento", cmbMet.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Id_cliente", cmbNIF.Text);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Inseridos com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                SqlCommand cmd2 = new SqlCommand("SELECT Contrato.*, Cliente.Nome FROM Contrato INNER JOIN Cliente ON Contrato.Id_cliente = Cliente.Id_cliente", BD);
                SqlDataReader rdr = cmd2.ExecuteReader();
                listView1.Items.Clear();
                while (rdr.Read())
                {

                    ListViewItem item = new ListViewItem(rdr["ID_Contrato"].ToString());
                    item.SubItems.Add(rdr["Id_cliente"].ToString());
                    item.SubItems.Add(rdr["Nome"].ToString());
                    item.SubItems.Add(rdr["Telefone"].ToString());
                    item.SubItems.Add(rdr["Morada"].ToString());
                    item.SubItems.Add(rdr["Potencia"].ToString());
                    item.SubItems.Add(rdr["Metodo_Pagamento"].ToString());
                    listView1.Items.Add(item);
                }
                BD.Close();
            }
            else
            {
                MessageBox.Show("Erro na insercao de registos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            VerifyTxT();
        }
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void txtCodP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void txtCodP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void txtContato_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void VerifyTxT()
        {
            if (!isEditing)
            {
                if (cmbNIF.SelectedItem != null && txtMoradaCont.Text != "" && txtTel.Text != "" && cmbMet.SelectedItem != null && cmbPot.SelectedItem != null)
                {
                    btnIns.Enabled = true;
                }
                else
                {
                    btnIns.Enabled = false;
                }
            }
        }
        private void cmbMet_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerifyTxT();
        }
        private void cmbPot_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerifyTxT();
        }
        private void cmbNIF_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerifyTxT();
            if (cmbNIF.SelectedItem != null)
            {
                BD.Open();

                // Prepare o comando SQL para selecionar os dados do cliente com base no NIF selecionado
                SqlCommand cmd = new SqlCommand("SELECT nome, endereco, Contato, codPostal FROM Cliente WHERE id_cliente=@NIF", BD);
                cmd.Parameters.AddWithValue("@NIF", cmbNIF.SelectedItem.ToString());

                // Execute o comando SQL e leia os resultados
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Preencha os campos de texto com os dados do cliente
                        txtNome.Text = reader["nome"].ToString();
                        txtMoradaCliente.Text = reader["endereco"].ToString();
                        txtContato.Text = reader["Contato"].ToString();

                        // Divida o código postal, se necessário
                        string codPostal = reader["codPostal"].ToString();
                        if (codPostal.Contains('-'))
                        {
                            string[] cod = codPostal.Split('-');
                            txtCodP1.Text = cod[0];
                            txtCodP2.Text = cod[1];
                        }
                        else
                        {
                            // Se não houver separador '-', atribua diretamente o valor ao txtCodP1.Text
                            txtCodP1.Text = codPostal;
                        }
                    }
                }
                BD.Close();

            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Reset();
            btnEdit.Hide();
            listView1.SelectedItems.Clear();
            EditOn();
        }
        private void txtMoradaCont_TextChanged_1(object sender, EventArgs e)
        {
            VerifyTxT();
        }
    }
}
