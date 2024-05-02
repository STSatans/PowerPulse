using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
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
                SqlCommand cmd = new SqlCommand("Select * from Cliente", BD);
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
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lst.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = lst.SelectedItems[0];

                // Display subitems in separate labels
                for (int i = 0; i < selectedItem.SubItems.Count; i++)
                {
                    txtNIF.Text = selectedItem.SubItems[1].Text;
                    txtNome.Text = selectedItem.SubItems[2].Text;
                    txtTelefone.Text = selectedItem.SubItems[4].Text;
                    txtMorada.Text = selectedItem.SubItems[3].Text;
                    string[] item = selectedItem.SubItems[5].Text.Split('-');
                    txtCodP1.Text = item[0];
                    txtCodP2.Text = item[1];

                    txtNIF.Enabled = false;
                    txtNome.Enabled = false;
                    txtTelefone.Enabled = false;
                    txtMorada.Enabled = false;
                    txtCodP1.Enabled = false;
                    txtCodP2.Enabled = false;

                }
                btnEdit.Visible = true;
            }
            else
            {

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Delete from Cliente where id_cliente=@ID", BD);
                foreach (ListViewItem selectedItem in lst.SelectedItems)
                {
                    cmd.Parameters.AddWithValue("@ID", selectedItem.SubItems[0].Text);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Eliminados");
                        lst.Items.Remove(selectedItem);
                    }
                    else
                    {
                        MessageBox.Show("Erro");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { BD.Close(); }
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
                    SqlCommand cmd2 = new SqlCommand("Select * from Cliente", BD);
                    SqlDataReader rdr = cmd.ExecuteReader();
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
                }
                else
                {
                    MessageBox.Show("Erro na insercao de registos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }
        private void Reset()
        {
            try
            {
                BD.Open();

                if (lst.SelectedItems.Count > 0)
                {
                    // Get the selected item
                    ListViewItem selectedItem = lst.SelectedItems[0];
                    string Item = selectedItem.SubItems[0].Text;

                    SqlCommand cmd = new SqlCommand("select Id_cliente,nome,endereco,contato,codPostal from Cliente where id_cliente="+Item, BD);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            txtNIF.Text = rdr["Id_cliente"].ToString();
                            txtNome.Text = rdr["nome"].ToString();
                            txtTelefone.Text = rdr["telefone"].ToString();
                            txtMorada.Text = rdr["endereco"].ToString();

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnCanc.Visible = true;
            btnUpdate.Visible = true;

            txtNIF.Enabled = true;
            txtNome.Enabled = true;
            txtTelefone.Enabled = true;
            txtMorada.Enabled = true;
            txtCodP1.Enabled = true;
            txtCodP2.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                SqlConnection BD2 = new SqlConnection(con);
                ListViewItem selectedItem = lst.SelectedItems[0];

                // Extract the index part from the ListViewItem's Text property
                string itemText = selectedItem.Text;

                // Split the text to extract just the index part
                string[] Item = itemText.Split('-');
                SqlCommand cmd = new SqlCommand("select Id_cliente,nome,endereco,contato,codPostal from Cliente", BD);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string CodPostal = txtCodP1.Text + " - " + txtCodP2.Text;
                        if (txtNIF.Text == rdr["Id_cliente"].ToString() && txtNome.Text == rdr["nome"].ToString() && txtMorada.Text == rdr["endereco"].ToString() && txtTelefone.Text == rdr["Contato"].ToString() && CodPostal == rdr["codPostal"].ToString())
                        {
                            MessageBox.Show("Não existe alterações nos registos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            BD2.Open();
                            SqlCommand cmd2 = new SqlCommand("Update Cliente set Id_cliente=@Id_cliente,nome=@nome,endereco=@endereco,contato=@contato,codPostal=@codP where id_cliente=" + Item[0], BD2);
                            cmd.Parameters.AddWithValue("@Id_cliente", txtNIF.Text);
                            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                            cmd.Parameters.AddWithValue("@contato", txtTelefone.Text);
                            cmd.Parameters.AddWithValue("@endereco", txtMorada.Text);
                            cmd.Parameters.AddWithValue("@codPostal", txtCodP1.Text + "-" + txtCodP2.Text);
                            int row = cmd2.ExecuteNonQuery();
                            if (row > 0)
                            {
                                MessageBox.Show("Atualizados com Sucesso", "Atualizacao", MessageBoxButtons.OK);
                                Reset();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao atualizar registos", "Atualizacao", MessageBoxButtons.OK);

                            }
                            BD2.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtCodP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void VerifyTxt()
        {
            if (txtNIF.Text != "" && txtMorada.Text != "" && txtCodP2.Text != "" && txtCodP1.Text != "" && txtTelefone.Text != "")
            {
                btnIns.Enabled = true;
            }
            else
            { btnIns.Enabled = false; }
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
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
