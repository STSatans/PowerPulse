using System;
using System.Configuration;
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
        bool Edit;
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);

        private void Admin_Load(object sender, EventArgs e)
        {
            BD.Open();
            btnCanc.Hide();
            btnDel.Enabled = false;
            btnConf.Hide();
            btnEdit.Hide();
            btnIns.Enabled = false;
            SqlCommand cmd = new SqlCommand("Select ID,nome,cargo from login ", BD);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listBox1.Items.Add(rd[0].ToString() + " - " + rd[1].ToString() + " - " + rd[2].ToString());
            }
            rd.Close();
            BD.Close();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems == null)
            {
                btnCanc.Hide();
                btnDel.Enabled = false;
                btnConf.Hide();
                btnEdit.Hide();
                btnIns.Enabled = false;

                txtNome.Clear();
                txtPass.Clear();
                cmbCargo.SelectedItem = null;
                cmbCargo.Items.Clear();
            }
            else
            {
                BD.Open();
                string[] item = listBox1.SelectedItem.ToString().Split('-');
                SqlCommand cmd = new SqlCommand("Select nome,cargo,password from Login where ID=" + item[0], BD);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
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
                BD.Close();
            }
        }
        private void verify()
        {
            if (cmbCargo.SelectedItem != null && txtNome.Text != "" && txtPass.Text != "")
            {
                btnIns.Enabled = true;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Hide();
            btnConf.Show();
            btnDel.Enabled = false;
            btnCanc.Show();
            Edit = true;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                string[] item = listBox1.SelectedItem.ToString().Split('-');
                SqlCommand cmd = new SqlCommand("Delete from Login where ID=" + item[0], BD);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Registos Eliminados com Sucesso", "Eliminados");
                    cmbCargo.SelectedItem = null;
                    txtNome.Text = "";
                    txtPass.Text = "";
                    listBox1.SelectedItems.Clear();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro", "Eliminados");
                    cmbCargo.SelectedItem = null;
                    txtNome.Text = "";
                    txtPass.Text = "";
                }
                BD.Close() ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }
        private void btnConf_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select Nome,Cargo,Password from Login ", BD);
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
                SqlCommand cm2 = new SqlCommand("Update Login Set Nome=@nome, Password=@pass, Cargo=@cargo",BD);
                cm2.Parameters.AddWithValue("@nome", txtNome.Text);
                cm2.Parameters.AddWithValue("@pass", txtPass.Text);
                cm2.Parameters.AddWithValue("@cargo",cmbCargo.SelectedItem.ToString());
                int row=cm2.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Registo Alterado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCargo.SelectedItem = null;
                    listBox1.SelectedItems.Clear();
                    txtNome.Text = "";
                    txtPass.Text = "";
                    BD.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar registos", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbCargo.SelectedItem = null;
                    listBox1.SelectedItems.Clear();
                    txtNome.Text = "";
                    txtPass.Text = "";
                    BD.Close();
                    return;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Não existem alterações. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    cmbCargo.SelectedItem = null;
                    listBox1.SelectedItems.Clear();
                    txtNome.Text = "";
                    txtPass.Text = "";
                    BD.Close();
                    return;
                }
            }
            BD.Close();
        }
        private void btnCanc_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select Nome,Cargo,Password from Login ", BD);
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
                DialogResult result = MessageBox.Show("Existe alterações. Deseja continuar mesmo assim?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {

                }
                else
                {

                }
            }
        }
        private void btnIns_Click(object sender, EventArgs e)
        {
            BD.Open();

            SqlCommand cmd = new SqlCommand("Insert into Login (Cargo,Password,Nome) values(@cargo,@Password,@nome)", BD);
            cmd.Parameters.AddWithValue("@cargo", cmbCargo.SelectedItem);
            cmd.Parameters.AddWithValue("@password", txtPass.Text);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Inserido com sucesso");
                cmbCargo.SelectedItem = null;
                txtNome.Text ="";
                txtPass.Text= "";
            }
            else
            {
                MessageBox.Show("Erro ao inserir registos");
            }
            BD.Close();
        }
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            verify();
        }
        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            verify();
        }
        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            verify();
        }
    }
}
