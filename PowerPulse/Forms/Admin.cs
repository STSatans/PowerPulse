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
        bool Edit=false;
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
            if (listBox1.SelectedIndex == 0)
            {
                btnCanc.Hide();
                btnDel.Enabled = false;
                btnConf.Hide();
                btnEdit.Hide();
                btnIns.Enabled = false;

                txtID.Clear();
                txtNome.Clear();
                txtPass.Clear();
                cmbCargo.SelectedItem=null;
                cmbCargo.Items.Clear();
            }
            else
            {
                BD.Open();
                string[] item=listBox1.SelectedItem.ToString().Split('-');
                SqlCommand cmd = new SqlCommand("Select * from Login where ID=" + item[0],BD);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    txtID.Text = rd[0].ToString();
                    txtNome.Text = rd[3].ToString();
                    txtPass.Text = rd[1].ToString();
                    cmbCargo.SelectedText = rd[2].ToString();

                    btnDel.Enabled = true;
                    btnEdit.Show();
                }
                rd.Close();
                BD.Close();
            }
        }
        private void verify()
        {
            if(cmbCargo.SelectedItem!=null&&txtID.Text!=""&&txtNome.Text!=""&&txtPass.Text!="")
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
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro", "Eliminados");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void btnConf_Click(object sender, EventArgs e)
        {

        }

        private void btnCanc_Click(object sender, EventArgs e)
        {

        }

        private void btnIns_Click(object sender, EventArgs e)
        {

        }
    }
}
