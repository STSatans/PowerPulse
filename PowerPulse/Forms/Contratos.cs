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

        private void Contratos_Load(object sender, EventArgs e)
        {
            // Ocultar botões e desativar o botão de inserção
            btnCancel.Hide();
            btnUpdate.Hide();
            btnIns.Enabled = false;
            btnDel.Enabled = false;
            btnEdit.Hide();
            EditOFF();
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
            EditOn();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Abra a conexão com o banco de dados
                BD.Open();

                // Prepare o comando SQL para recuperar os registros para o item selecionado
                SqlCommand selectCmd = new SqlCommand("SELECT Id_cliente, Morada, Telefone, Tarifa, Metodo_Pagamento FROM Cliente WHERE ID_Contrato=@selectedId", BD);
                selectCmd.Parameters.Add("@selectedId", SqlDbType.VarChar);

                // Prepare o comando SQL para atualizar os registros
                SqlCommand updateCmd = new SqlCommand("UPDATE Contratos SET Morada=@Morada , Telefone=@Telefone , Tarifa=@Tarifa , Metodo_Pagamento=@Metodo , Id_cliente=@Id_cliente WHERE ID_Contrato=@selectedId", BD);
                updateCmd.Parameters.Add("@Id_cliente", SqlDbType.VarChar);
                updateCmd.Parameters.Add("@Morada", SqlDbType.VarChar);
                updateCmd.Parameters.Add("@Telefone", SqlDbType.VarChar);
                updateCmd.Parameters.Add("@Tarifa", SqlDbType.VarChar);
                updateCmd.Parameters.Add("@Metodo", SqlDbType.VarChar);
                updateCmd.Parameters.Add("@selectedId", SqlDbType.VarChar);

                // Inicialize uma flag para rastrear se foram encontradas alterações
                bool alterationsFound = false;

                // Iterar por cada item selecionado na ListView
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    // Definir o ID do item selecionado
                    selectCmd.Parameters["@selectedId"].Value = selectedItem.SubItems[0].Text;

                    // Executar a consulta para recuperar o registro
                    using (SqlDataReader rdr = selectCmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            // Verificar se existem alterações nos registros
                            if (cmbNIF.SelectedItem.ToString() != rdr["Id_cliente"].ToString() ||
                                txtMoradaCont.Text != rdr["Morada"].ToString() ||
                                txtTel.Text != rdr["Telefone"].ToString() ||
                                cmbPot.SelectedItem.ToString() != rdr["Tarifa"].ToString() ||
                                cmbMet.SelectedItem.ToString() != rdr["Metodo_Pagamento"].ToString())
                            {
                                alterationsFound = true;
                                break; // Exit the loop since alterations are found
                            }
                        }
                    }
                }

                // Se foram encontradas alterações, proceda com a operação de atualização
                if (alterationsFound)
                {
                    updateCmd.Parameters["@Id_cliente"].Value = cmbNIF.SelectedItem;
                    updateCmd.Parameters["@Morada"].Value = txtMoradaCont.Text;
                    updateCmd.Parameters["@Telefone"].Value = txtTel.Text;
                    updateCmd.Parameters["@Tarifa"].Value = cmbPot.SelectedItem;
                    updateCmd.Parameters["@Metodo"].Value = cmbMet.SelectedItem;
                    updateCmd.Parameters["@selectedId"].Value = listView1.SelectedItems[0].SubItems[0].Text; // Assuming only one item is selected

                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Atualizados com Sucesso", "Atualizacao", MessageBoxButtons.OK);
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar registos", "Atualizacao", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    // Nenhuma alteração encontrada, pergunte ao usuário
                    if (MessageBox.Show("Não foram encontradas alterações nos registros.\r\nDeseja continuar em modo de edição?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        // O usuário opta por não continuar editando, redefina os campos e saia do manipulador de eventos
                        Reset();
                        return;
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

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se algum item está selecionado
            if (listView1.SelectedItems.Count > 0)
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
                    cmbPot.SelectedItem = selectedItem.SubItems[5].Text.ToString();
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
        }
        private void EditOn()
        {
            txtNome.Enabled = true;
            txtMoradaCliente.Enabled = true;
            txtContato.Enabled = true;
            txtCodP1.Enabled = true;
            txtCodP2.Enabled = true;
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

        private void cmbTipoCl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMoradaCliente_TextChanged(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            if (cmbNIF.SelectedItem != null && txtMoradaCont.Text != "" && txtTel.Text != "" && cmbMet.SelectedItem != null && cmbPot.SelectedItem != null)
            {
                btnIns.Enabled = true;
            }
            else
            {
                btnIns.Enabled = false;
            }
        }

        private void txtMoradaCont_TextChanged(object sender, EventArgs e)
        {
            VerifyTxT();
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

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Reset();
            listView1.SelectedItems.Clear();
        }
    }
}
