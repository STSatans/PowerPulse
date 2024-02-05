using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPulse
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        private void Main_Load(object sender, EventArgs e)
        {
            SqlConnection BD=new SqlConnection(con);
            BD.Open();

            SqlCommand cmd = new SqlCommand("Select designacao from login",BD);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["designacao"].ToString() == "Admin")
                {
                    //adicionar controlos de admin
                    pictureBox1.Show();
                }
                else
                {
                    //esconder controlos de admin
                    pictureBox1.Hide();
                }
            }
        }
    }
}
