using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        bool Edit = false;
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);
        private void Admin_Load(object sender, EventArgs e)
        {
            btnCanc.Hide();
            btnDel.Enabled = false;
            btnConf.Hide();
            btnEdit.Hide();
            btnIns.Enabled = false;
            LoadListBox();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                ClearForm();

            }
            else
            {
                try
                {
                    if (BD.State == ConnectionState.Closed)
                        BD.Open();

                    string[] item = listBox1.SelectedItem.ToString().Split('-');
                    SqlCommand cmd = new SqlCommand("Select nome,cargo,password from Login where ID=" + item[0], BD);
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        txtNome.Text = rd["nome"].ToString();
                        txtPass.Text = rd["password"].ToString();
                        string cargo = rd["cargo"].ToString();
                        cmbCargo.SelectedItem = cargo;
                        txtNome.Enabled = false;
                        txtPass.Enabled = false;
                        cmbCargo.Enabled = false;
                        btnDel.Enabled = true;
                        btnEdit.Show();
                    }

                    rd.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro");
                }
                finally
                {
                    if (BD.State == ConnectionState.Open)
                        BD.Close();
                }
            }
            verify();
        }
        private void verify()
        {
            // Verifica se nenhum item está selecionado na list box
            if (listBox1.SelectedItem == null)
            {
                // Verifica se os outros campos não estão vazios ou nulos
                if (cmbCargo.SelectedItem != null && !string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtPass.Text))
                {
                    btnIns.Enabled = true;
                }
                else
                {
                    btnIns.Enabled = false;
                }
            }
            else
            {
                btnIns.Enabled = false;
            }
        }
        private void ClearForm()
        {
            btnCanc.Hide();
            btnDel.Enabled = false;
            txtNome.Enabled= true;
            txtPass.Enabled= true;
            btnConf.Hide();
            btnEdit.Hide();
            btnIns.Enabled = false;
            txtNome.Clear();
            txtPass.Clear();
            cmbCargo.Enabled = true;
            cmbCargo.SelectedItem = null; 
            cmbCargo.SelectedIndex = -1;                          
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Hide();
            btnConf.Show();
            btnDel.Enabled = false;
            btnIns.Enabled = false;
            btnCanc.Show();
            Edit = true;
            cmbCargo.Enabled = true;
            txtNome.Enabled = true;
            txtPass.Enabled = true;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string[] item = listBox1.SelectedItem.ToString().Split('-');

                using (SqlConnection connection = new SqlConnection(BD.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("Delete from Login where ID=@ID", connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", item[0]);

                        int row = cmd.ExecuteNonQuery();

                        if (row > 0)
                        {
                            MessageBox.Show("Registro deletado com sucesso.", "Deletado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadListBox();
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro ao deletar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearForm();
                            LoadListBox();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (BD.State == ConnectionState.Closed)
                    BD.Open();

                string[] item = listBox1.SelectedItem.ToString().Split('-');
                SqlCommand cmd = new SqlCommand("Select Nome,Cargo,Password from Login where ID=" + item[0], BD);
                SqlDataReader rdr = cmd.ExecuteReader();

                bool hasChanges = false;

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (cmbCargo.Text != rdr["Cargo"].ToString() || txtNome.Text != rdr["Nome"].ToString() || txtPass.Text != rdr["Password"].ToString())
                        {
                            hasChanges = true;
                        }
                    }
                }

                rdr.Close();

                if (hasChanges)
                {
                    SqlCommand cm2 = new SqlCommand("Update Login Set Nome=@nome, Password=@pass, Cargo=@cargo where ID=" + item[0], BD);
                    cm2.Parameters.AddWithValue("@nome", txtNome.Text);
                    cm2.Parameters.AddWithValue("@pass", txtPass.Text);
                    cm2.Parameters.AddWithValue("@cargo", cmbCargo.SelectedItem.ToString());

                    int row = cm2.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Registro atualizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadListBox();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar registro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearForm();
                        LoadListBox();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Nenhuma alteração detectada. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
            finally
            {
                if (BD.State == ConnectionState.Open)
                    BD.Close();
            }
        }
        private void btnCanc_Click(object sender, EventArgs e)
        {
            try
            {
                if (BD.State == ConnectionState.Closed)
                    BD.Open();

                string[] item = listBox1.SelectedItem.ToString().Split('-');
                SqlCommand cmd = new SqlCommand("Select Nome,Cargo,Password from Login where ID=" + item[0], BD);
                SqlDataReader rdr = cmd.ExecuteReader();

                bool hasChanges = false;

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (cmbCargo.Text != rdr["Cargo"].ToString() || txtNome.Text != rdr["Nome"].ToString() || txtPass.Text != rdr["Password"].ToString())
                        {
                            hasChanges = true;
                        }
                    }
                }

                if (hasChanges)
                {
                    DialogResult result = MessageBox.Show("Existem alterações. Deseja continuar mesmo assim?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        ClearForm();
                    }
                }
                else
                {
                    ClearForm();
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
            finally
            {
                if (BD.State == ConnectionState.Open)
                    BD.Close();
            }
        }
        private void btnIns_Click(object sender, EventArgs e)
        {
            try
            {
                if (BD.State == ConnectionState.Closed)
                    BD.Open();
                SqlCommand cmd = new SqlCommand("Insert into Login (Cargo,Password,Nome) values(@cargo,@Password,@nome)", BD);
                cmd.Parameters.AddWithValue("@cargo", cmbCargo.SelectedItem);
                cmd.Parameters.AddWithValue("@password", txtPass.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);

                int row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Inserido com sucesso");
                    ClearForm();
                    LoadListBox();
                }
                else
                {
                    MessageBox.Show("Erro ao inserir registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
            finally
            {
                if (BD.State == ConnectionState.Open)
                    BD.Close();
            }
        }
        private void LoadListBox()
        {
            try
            {
                BD.Open();

                SqlCommand cmd = new SqlCommand("SELECT ID, Nome, Cargo FROM Login", BD);
                SqlDataReader rdr = cmd.ExecuteReader();

                listBox1.Items.Clear();

                while (rdr.Read())
                {
                    listBox1.Items.Add($"{rdr["ID"]} - {rdr["Nome"]} - {rdr["Cargo"]}");
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BD.Close();
            }
        }
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            verify();
        }
        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            verify();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
