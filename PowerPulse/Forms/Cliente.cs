using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        //conexoes
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);//con estagio
        bool isEditing = false;
        private void Cliente_Load(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnCanc.Visible = false;
            btnUpdate.Visible = false;
            btnDel.Enabled = false;
            btnIns.Enabled = false;
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("select Id_cliente,nome,endereco,contato,codPostal from Cliente", BD);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    // Criar um array de strings para armazenar os dados de uma linha
                    string[] row = new string[rdr.FieldCount];

                    // Preencher o array com os valores das colunas
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        row[i] = rdr[i].ToString();
                    }

                    // Adicionar os valores ao ListView
                    lst.Items.Add(new ListViewItem(row));
                }
                BD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { BD.Close(); }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lst.SelectedItems.Count == 0)
                {
                    txtNIF.Enabled = true;
                    txtNome.Enabled = true;
                    txtTelefone.Enabled = true;
                    txtMorada.Enabled = true;
                    txtCodP1.Enabled = true;
                    txtCodP2.Enabled = true;
                    btnIns.Enabled = false;
                    btnDel.Enabled = false;
                    btnCanc.Hide();
                    btnUpdate.Hide();
                    Reset();
                }
                else
                {
                    // Get the selected item
                    ListViewItem selectedItem = lst.SelectedItems[0];

                    // Display subitems in separate labels
                    for (int i = 0; i < selectedItem.SubItems.Count; i++)
                    {
                        txtNIF.Text = selectedItem.SubItems[0].Text;
                        txtNome.Text = selectedItem.SubItems[1].Text;
                        txtTelefone.Text = selectedItem.SubItems[3].Text;
                        txtMorada.Text = selectedItem.SubItems[2].Text;
                        string[] item = selectedItem.SubItems[4].Text.Split('-');
                        txtCodP1.Text = item[0];
                        txtCodP2.Text = item[1];

                        txtNIF.Enabled = false;
                        txtNome.Enabled = false;
                        txtTelefone.Enabled = false;
                        txtMorada.Enabled = false;
                        txtCodP1.Enabled = false;
                        txtCodP2.Enabled = false;
                        btnIns.Enabled = false;   
                        btnEdit.Show();
                        btnDel.Show();
                        btnDel.Enabled = true;
                        btnClear.Enabled = true;

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
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                foreach (ListViewItem selectedItem in lst.SelectedItems)
                {
                    string clienteId = selectedItem.SubItems[0].Text;

                    // Perguntar ao usuário se deseja eliminar o cliente e todos os dados associados
                    DialogResult result = MessageBox.Show("Existem contratos criados e Faturas com este cliente. Deseja eliminar?", "Confirmação de Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Verificar se existem contratos associados ao cliente
                        SqlCommand checkContractsCmd = new SqlCommand("SELECT Id_contrato FROM Contrato WHERE Id_cliente = @ClienteId", BD);
                        checkContractsCmd.Parameters.AddWithValue("@ClienteId", clienteId);
                        SqlDataReader contractsReader = checkContractsCmd.ExecuteReader();

                        // Lista para armazenar os IDs dos contratos a serem excluídos
                        List<int> contractIds = new List<int>();

                        while (contractsReader.Read())
                        {
                            contractIds.Add(contractsReader.GetInt32(0));
                        }
                        contractsReader.Close();

                        foreach (int contractId in contractIds)
                        {
                            // Verificar se existem faturas associadas ao contrato
                            SqlCommand checkInvoicesCmd = new SqlCommand("SELECT ID_Fatura FROM Fatura WHERE ID_Contrato = @ContractId", BD);
                            checkInvoicesCmd.Parameters.AddWithValue("@ContractId", contractId);
                            SqlDataReader invoicesReader = checkInvoicesCmd.ExecuteReader();

                            // Lista para armazenar os IDs das faturas a serem excluídas
                            List<int> invoiceIds = new List<int>();

                            while (invoicesReader.Read())
                            {
                                invoiceIds.Add(invoicesReader.GetInt32(0));
                            }
                            invoicesReader.Close();

                            // Excluir as faturas associadas ao contrato
                            foreach (int invoiceId in invoiceIds)
                            {
                                SqlCommand deleteInvoiceCmd = new SqlCommand("DELETE FROM Fatura WHERE ID_Fatura = @InvoiceId", BD);
                                deleteInvoiceCmd.Parameters.AddWithValue("@InvoiceId", invoiceId);
                                deleteInvoiceCmd.ExecuteNonQuery();
                            }

                            // Excluir o contrato
                            SqlCommand deleteContractCmd = new SqlCommand("DELETE FROM Contrato WHERE ID_Contrato = @ContractId", BD);
                            deleteContractCmd.Parameters.AddWithValue("@ContractId", contractId);
                            deleteContractCmd.ExecuteNonQuery();
                        }

                        // Excluir o cliente
                        SqlCommand deleteClientCmd = new SqlCommand("DELETE FROM Cliente WHERE Id_cliente = @ClienteId", BD);
                        deleteClientCmd.Parameters.AddWithValue("@ClienteId", clienteId);
                        int rows = deleteClientCmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Todos os registos foram eliminados");
                            lst.Items.Remove(selectedItem);
                            txtNIF.Text = " ";
                            txtNome.Text = "";
                            txtMorada.Text = "";
                            txtTelefone.Text = "";
                            txtCodP1.Text = "";
                            txtCodP2.Text = "";
                            btnDel.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Erro ao eliminar cliente");
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
        private void btnIns_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Insert into Cliente(Id_cliente,nome,endereco,Contato,codPostal) values(@Id_cliente,@nome,@endereco,@Contato,@codPostal)", BD);
                cmd.Parameters.AddWithValue("@Id_cliente", txtNIF.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@contato", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@endereco", txtMorada.Text);
                cmd.Parameters.AddWithValue("@codPostal", txtCodP1.Text + " - " + txtCodP2.Text);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Inseridos com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SqlCommand cmd2 = new SqlCommand("select Id_cliente,nome,endereco,contato,codPostal from Cliente", BD);
                    SqlDataReader rdr = cmd2.ExecuteReader();
                    lst.Items.Clear();
                    while (rdr.Read())
                    {
                        // Criar um array de strings para armazenar os dados de uma linha
                        string[] fields = new string[rdr.FieldCount];

                        // Preencher o array com os valores das colunas
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            fields[i] = rdr[i].ToString();
                        }

                        // Adicionar os valores ao ListView
                        lst.Items.Add(new ListViewItem(fields));
                    }
                    BD.Close();
                }
                else
                {
                    MessageBox.Show("Erro na insercao de registos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                BD.Open();
            }

        }
        private void Reset()
        {
            txtNIF.Text = "";
            txtNome.Text = "";
            txtMorada.Text = "";
            txtTelefone.Text = "";
            txtCodP1.Text = "";
            txtCodP2.Text = "";
            lst.SelectedItems.Clear();
            btnEdit.Hide();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the main database connection
                BD.Open();

                // Initialize a flag to track if any alterations are found
                bool alterationsFound = false;

                // Iterate through each selected item in the ListView
                foreach (ListViewItem selectedItem in lst.SelectedItems)
                {
                    // Prepare a SQL query to retrieve the record for the selected item
                    SqlCommand cmd = new SqlCommand("SELECT Id_cliente, nome, endereco, Contato, codPostal FROM Cliente WHERE Id_cliente=@selectedId", BD);
                    cmd.Parameters.AddWithValue("@selectedId", selectedItem.SubItems[0].Text);

                    // Execute the query to retrieve the record
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Check if any alterations are found for the current item
                    while (rdr.Read())
                    {
                        string CodPostal = txtCodP1.Text + "-" + txtCodP2.Text;
                        if (txtNIF.Text != rdr["Id_cliente"].ToString() ||
                            txtNome.Text != rdr["nome"].ToString() ||
                            txtMorada.Text != rdr["endereco"].ToString() ||
                            txtTelefone.Text != rdr["Contato"].ToString() ||
                            CodPostal != rdr["codPostal"].ToString())
                        {
                            alterationsFound = true;
                            break; // Exit the loop since alterations are found
                        }
                    }

                    // Close the SqlDataReader after use
                    rdr.Close();
                    BD.Close();
                }

                // If alterations are found, proceed with the update operation
                if (alterationsFound)
                {
                    BD.Open();
                    SqlCommand cmd2 = new SqlCommand("UPDATE Cliente SET Id_cliente=@Id_cliente , nome=@nome , endereco=@endereco , contato=@contato , codPostal=@codPostal WHERE Id_cliente=@selectedId", BD);
                    cmd2.Parameters.AddWithValue("@Id_cliente", txtNIF.Text);
                    cmd2.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd2.Parameters.AddWithValue("@endereco", txtMorada.Text);
                    cmd2.Parameters.AddWithValue("@contato", txtTelefone.Text);
                    cmd2.Parameters.AddWithValue("@codPostal", txtCodP1.Text + "-" + txtCodP2.Text);
                    cmd2.Parameters.AddWithValue("@selectedId", lst.SelectedItems[0].SubItems[0].Text); // Assuming only one item is selected

                    int row = cmd2.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Atualizados com Sucesso", "Atualizacao", MessageBoxButtons.OK);
                        isEditing = false;
                        SqlCommand refresh = new SqlCommand("select Id_cliente,nome,endereco,contato,codPostal from Cliente", BD);
                        SqlDataReader rdr = refresh.ExecuteReader();
                        lst.Items.Clear();
                        while (rdr.Read())
                        {
                            // Criar um array de strings para armazenar os dados de uma linha
                            string[] field = new string[rdr.FieldCount];

                            // Preencher o array com os valores das colunas
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                field[i] = rdr[i].ToString();
                            }

                            // Adicionar os valores ao ListView
                            lst.Items.Add(new ListViewItem(field));
                        }
                        BD.Close();
                        Reset();
                        btnUpdate.Hide();
                        btnCanc.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar registos", "Atualizacao", MessageBoxButtons.OK);
                        isEditing = false;
                    }
                }
                else
                {
                    // No alterations found, prompt the user
                    if (MessageBox.Show("Não foram encontradas alterações nos registos.\r\nDeseja continuar em modo de edição?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        BD.Close();
                        Reset();
                        btnUpdate.Hide();
                        btnCanc.Hide();
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
                // Close the main database connection after use
                BD.Close();
            }
        }
        private void btnCanc_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the main database connection
                BD.Open();

                // Initialize a flag to track if any alterations are found
                bool alterationsFound = false;

                // Iterate through each selected item in the ListView
                foreach (ListViewItem selectedItem in lst.SelectedItems)
                {
                    // Prepare a SQL query to retrieve the record for the selected item
                    SqlCommand cmd = new SqlCommand("SELECT Id_cliente, nome, endereco, Contato, codPostal FROM Cliente WHERE Id_cliente=@selectedId", BD);
                    cmd.Parameters.AddWithValue("@selectedId", selectedItem.SubItems[0].Text);

                    // Execute the query to retrieve the record
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Check if any alterations are found for the current item
                    while (rdr.Read())
                    {
                        string CodPostal = txtCodP1.Text + "-" + txtCodP2.Text;
                        if (txtNIF.Text != rdr["Id_cliente"].ToString() ||
                            txtNome.Text != rdr["nome"].ToString() ||
                            txtMorada.Text != rdr["endereco"].ToString() ||
                            txtTelefone.Text != rdr["Contato"].ToString() ||
                            CodPostal != rdr["codPostal"].ToString())
                        {
                            alterationsFound = true;
                            break; // Exit the loop since alterations are found
                        }
                    }

                    // Close the SqlDataReader after use
                    rdr.Close();
                    BD.Close();
                }

                // If alterations are found, proceed with the update operation
                if (alterationsFound)
                {
                    DialogResult result = MessageBox.Show("Existem alterações não salvas. Deseja cancelar mesmo assim?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        isEditing = false;
                        Reset();
                        btnIns.Enabled = false;
                        lst.SelectedItems.Clear();
                        btnCanc.Hide();
                        btnClear.Enabled = false;
                        btnEdit.Hide();
                        btnUpdate.Hide();
                        txtCodP1.Enabled = true;
                        txtCodP2.Enabled = true;
                        txtTelefone.Enabled = true;
                        txtMorada.Enabled = true;
                        txtNIF.Enabled = true;
                        txtNome.Enabled =true;
                    }
                }
                else
                {
                    isEditing = false;
                    Reset();
                    btnIns.Enabled = false;
                    lst.SelectedItems.Clear();
                    btnCanc.Hide();
                    btnClear.Enabled = false;
                    btnEdit.Hide();
                    btnUpdate.Hide();
                    txtCodP1.Enabled = true;
                    txtCodP2.Enabled = true;
                    txtTelefone.Enabled = true;
                    txtMorada.Enabled = true;
                    txtNIF.Enabled = true;
                    txtNome.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the main database connection after use
                BD.Close();
            }

        }
        private void txtCodP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void VerifyTxt()
        {
            if (!isEditing)
            {
                if (txtNIF.Text != "" && txtMorada.Text != "" && txtCodP2.Text != "" && txtCodP1.Text != "" && txtTelefone.Text != "")
                {
                    btnIns.Enabled = true;
                }
                else
                {
                    btnIns.Enabled = false;
                }
            }
        }
        private void txtCodP1_TextChanged(object sender, EventArgs e)
        {
            VerifyTxt();
        }
        private void txtCodP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void txtNIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void txtNIF_TextChanged(object sender, EventArgs e)
        {
            VerifyTxt();
        }
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            VerifyTxt();
        }
        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            VerifyTxt();
        }
        private void txtMorada_TextChanged(object sender, EventArgs e)
        {
            VerifyTxt();
        }
        private void txtCodP2_TextChanged(object sender, EventArgs e)
        {
            VerifyTxt();
        }
        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNIF.Text = "";
            txtNome.Text = "";
            txtMorada.Text = "";
            txtTelefone.Text = "";
            txtCodP1.Text = "";
            txtCodP2.Text = "";
            lst.SelectedItems.Clear();
            btnEdit.Hide();
            btnIns.Enabled=false;
            btnDel.Enabled=false;
            isEditing = false;
            
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditing = true;
            btnDel.Hide();
            btnCanc.Show();
            btnUpdate.Show();
            btnEdit.Hide();
            txtCodP1.Enabled = true;
            txtCodP2.Enabled = true;
            txtTelefone.Enabled = true;
            txtMorada.Enabled = true;
            txtNIF.Enabled = true;
            txtNome.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
