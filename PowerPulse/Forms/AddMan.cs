using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class AddMan : Form
    {
        private Form currentChildForm;

        public AddMan()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
        //private readonly static string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        private readonly static string con = ConfigurationManager.ConnectionStrings["BDEst"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);
        private void AddMan_Load(object sender, EventArgs e)
        {
            
            txtCosts.Enabled = false;
            comboBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;

            BD.Open();

            SqlCommand cmd = new SqlCommand("Select ID_Usina,Nome from Usina", BD);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows)
                {
                    cmbUsina.Items.Add(dr["ID_Usina"].ToString() + "-" + dr["Nome"].ToString());
                }
            }
            BD.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCosts.BackColor = Color.White;
            txtCosts.ForeColor = Color.Black;
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                string[] id = cmbUsina.SelectedItem.ToString().Split('-');
                DateTime date_ini = dateTimePicker1.Value;
                DateTime date_end = dateTimePicker2.Value;
                SqlCommand cmd = new SqlCommand("Select data_ini from manutencao_usina where ID_Usina=" + id[0] + "and estado !='Concluido'", BD);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        DateTime date = Convert.ToDateTime(dr["data_ini"].ToString());
                        if(date.Date==date_ini.Date)
                        {
                            MessageBox.Show("sad");
                        }
                    }
                }
                dr.Close();
                SqlCommand cmd2 = new SqlCommand("Insert into manutencao_usina(ID_Usina,data_ini,data_fim,tipo_manutencao,custo_manutencao,descricao,estado) values(@ID_Usina,@data_ini,@data_fim,@tipo_manutencao,@custo_manutencao,@descricao,@estado)", BD);
                cmd2.Parameters.AddWithValue("@ID_Usina", id[0]);
                cmd2.Parameters.AddWithValue("@data_ini", date_ini);
                cmd2.Parameters.AddWithValue("@data_fim", date_end);
                cmd2.Parameters.AddWithValue("@tipo_manutencao", comboBox2.SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("@custo_manutencao", txtCosts.Text);
                cmd2.Parameters.AddWithValue("@descricao", txtDesc.Text);
                if(date_ini.Date>=DateTime.Today)
                {
                    cmd2.Parameters.AddWithValue("@estado","Agendada");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@estado","Inicializada");
                }

                if (date_ini <= date_end)
                {
                    if (date_ini >= DateTime.Today && date_end >= DateTime.Today)
                    {
                        int row = cmd2.ExecuteNonQuery();

                        if (row > 0)
                        {
                            MessageBox.Show("Inserido com sucesso");
                        }
                        else
                        {
                            MessageBox.Show("Deu Erro");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma data pode ser inferior a hoje");
                    }
                }
                else
                {
                    MessageBox.Show("A data Inicial não pode ser maior que a data Fim");
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
        private void btnBack_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Manutencao());
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void cmbUsina_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCosts.Enabled = true;
            comboBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }
    }
}
