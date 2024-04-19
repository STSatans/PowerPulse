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
    public partial class AddUsina : Form
    {
        public AddUsina()
        {
            InitializeComponent();
        }

        private void AddUsina_Load(object sender, EventArgs e)
        {

        }
        private readonly static string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        //private readonly static string con = ConfigurationManager.ConnectionStrings["BDEst"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                BD.Open();
                SqlCommand cmd = new SqlCommand("Insert into Usina(Nome,Tipo,capacidade,localizacao,data_construcao,status,prod) values(@Nome,@Tipo,@Capacidade,@localizacao,@dataConst,@status)", BD);
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Tipo", cmbTipo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Capacidade", txtCapacidade.Text);
                cmd.Parameters.AddWithValue("@localizacao", txtLoc.Text);
                cmd.Parameters.AddWithValue("@dataConst", dtpData.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@status", "Online");


                int row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Inseridos", "Inserido", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Nao Inseridos", "Inserido", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { BD.Close(); }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem.ToString() == "Eolica" || cmbTipo.SelectedItem.ToString() == "Solar")
            {
                panel1.Hide();
            }
        }
    }
}
