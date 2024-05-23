using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
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
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);
        private void AddMan_Load(object sender, EventArgs e)
        {
            txtCosts.Enabled = false;
            cmbMan.Enabled = false;
            dtpIni.Enabled = false;
            dtpFim.Enabled = false;
            btnIns.Enabled = false;
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
        private void btnIns_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                string[] id = cmbUsina.SelectedItem.ToString().Split('-');
                DateTime date_ini = dtpIni.Value;
                DateTime date_end = dtpFim.Value;
                SqlCommand cmd2 = new SqlCommand("Insert into manutencao_usina(ID_Usina,data_ini,data_fim,tipo_manutencao,custo_manutencao,descricao,estado) values(@ID_Usina,@data_ini,@data_fim,@tipo_manutencao,@custo_manutencao,@descricao,@estado)", BD);
                cmd2.Parameters.AddWithValue("@ID_Usina", id[0]);
                cmd2.Parameters.AddWithValue("@data_ini", date_ini);
                cmd2.Parameters.AddWithValue("@data_fim", date_end);
                cmd2.Parameters.AddWithValue("@tipo_manutencao", cmbMan.SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("@custo_manutencao", txtCosts.Text);
                cmd2.Parameters.AddWithValue("@descricao", txtDesc.Text);
                if (date_ini.Date >= DateTime.Today)
                {
                    cmd2.Parameters.AddWithValue("@estado", "Agendada");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@estado", "Inicializada");
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
            txtDesc.Enabled = true;
            txtCosts.Enabled = true;
            cmbMan.Enabled = true;
            dtpIni.Enabled = true;
            dtpFim.Enabled = true;
        }
        private void verify()
        {
            if(cmbUsina.SelectedItem!=null && cmbMan.SelectedItem!=null && dtpIni.Value!=null && dtpFim.Value!=null && txtCosts.Text!=null && txtDesc.Text!=null)
            {
                btnIns.Enabled = true;
            }
        }
        private void cmbMan_SelectedIndexChanged(object sender, EventArgs e)
        {
            verify();
        }
        private void txtCosts_TextChanged(object sender, EventArgs e)
        {
            verify();
        }
        private void dtpFim_ValueChanged(object sender, EventArgs e)
        {
            verify();
        }
        private void dtpIni_ValueChanged(object sender, EventArgs e)
        {
            verify();
        }
        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            verify();
        }
    }
}
