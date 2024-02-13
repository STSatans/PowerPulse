using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PowerPulse
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPass.Enabled = false;
        }
        //connection string
        private string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            txtPass.Enabled= true;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled= true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection BD = new SqlConnection(con);
                BD.Open();

                SqlCommand cmd = new SqlCommand("Select * from Login", BD);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (txtUser.Text == reader["ID"].ToString() && txtPass.Text == reader["Password"].ToString())
                    {
                        MessageBox.Show("Login efetuado com sucesso", "Login", MessageBoxButtons.OK);
                        Main main = new Main();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username e password nao estao corretos ou nao existem", "Login", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
