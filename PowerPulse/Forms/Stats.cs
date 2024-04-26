using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();
        }
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        //private readonly static string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        //private readonly static string con = ConfigurationManager.ConnectionStrings["BDEst"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);
        private void Stats_Load(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("SELECT (SELECT COUNT(*) FROM Usina) ,(SELECT COUNT(*) FROM Contrato),(SELECT COUNT(*) FROM Cliente),(SELECT COUNT(*) FROM Usina where status='Online')", BD);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lblUsinas.Text = reader[0].ToString();
                lblContratos.Text = reader[1].ToString();
                lblClientes.Text = reader[2].ToString();
                lblligadas.Text = reader[3].ToString();
            }
        }
    }
}
