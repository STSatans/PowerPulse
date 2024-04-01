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

namespace PowerPulse.Forms
{
    public partial class AddMan : Form
    {
        public AddMan()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
        private readonly static string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        private readonly static string con2 = ConfigurationManager.ConnectionStrings["BDEst"].ConnectionString;
        //SqlConnection BD = new SqlConnection(con);
        SqlConnection BD = new SqlConnection(con2);
        private void AddMan_Load(object sender, EventArgs e)
        {
            BD.Open();
            
            SqlCommand cmd = new SqlCommand("Select Nome from Usina",BD);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if(dr.HasRows)
                {
                    cmbUsina.Items.Add(dr["Nome"].ToString());
                }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCosts.BackColor= Color.White;
            txtCosts.ForeColor= Color.Black;
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select ID_Usina from Usina where Nome='"+cmbUsina.Text+"'");
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (r.HasRows)
                {
                    string ID = r["ID"].ToString();
                }
            }
            BD.Close();
            SqlConnection conn = new SqlConnection(con2);
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Inser into manutencao_usina values(@ID_Usina,@)");
        }
    }
}
