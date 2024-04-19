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
using System.Windows;
using FontAwesome.Sharp;
using Application = System.Windows.Forms.Application;
using System.Linq.Expressions;

namespace PowerPulse
{
    public partial class Login : Form
    {
        //connection string
        private readonly string con = ConfigurationManager.ConnectionStrings["BDEst"].ConnectionString;// con estagio
        //private readonly string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;//con Casa

        public Login()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //enumerador para definir os estados de Login
        enum LoginResult
        {
            Success,
            InvalidUserID,
            InvalidPassword
        }
        //funcao para verificar os dados de Login
        private LoginResult CheckLogin(int userID, string password)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                string query = "SELECT Password FROM Login WHERE ID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                    if (result != null)
                    {
                        string dbPassword = result.ToString();
                        if (dbPassword == password)
                        {
                            return LoginResult.Success;
                        }
                        else
                        {
                            return LoginResult.InvalidPassword;
                        }
                    }
                    else
                    {
                        return LoginResult.InvalidUserID;
                    }
                }
            }
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int userID = Convert.ToInt32(txtUser.Text);

                string password = txtPass.Text;

                LoginResult loginResult = CheckLogin(userID, password);

                //switch case para verificar o resultado do login
                switch (loginResult)
                {
                    case LoginResult.Success:
                        Main main = new Main
                        {
                            User = userID
                        };
                        main.Show();
                        this.Hide();
                        
                        break;

                    case LoginResult.InvalidUserID:

                        panel7.Visible = true;
                        break;

                    case LoginResult.InvalidPassword:

                        panel9.Visible = true;
                        break;
                }
            }
            catch(Exception ex)
            {
                //Mensagen de Excessao
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Lime;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
            else
                WindowState = FormWindowState.Normal;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtpass_Click(object sender, EventArgs e)
        {
            txtPass.SelectAll();
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtPass.ForeColor = Color.White;
                if (txtPass.Text == "")
                {
                    txtPass.Text = "Password";
                    return;
                }
            }
            catch
            { }
        }
        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.SelectAll();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtUser.ForeColor = Color.White;
                if (txtUser.Text == "")
                {
                    txtUser.Text = "Enter Username";
                    return;
                }

            }
            catch
            { }
        }

    }
}
