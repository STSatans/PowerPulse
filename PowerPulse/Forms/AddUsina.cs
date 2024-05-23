using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class AddUsina : Form
    {
        private Form currentChildForm;
        public AddUsina()
        {
            InitializeComponent();
        }

        private void AddUsina_Load(object sender, EventArgs e)
        {
            btnIns.Enabled = false;
            txtCapacidade.Enabled = false;
            txtGasto.Enabled = false;
            txtMaterial.Enabled = false;
        }
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);

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
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem != null)
            {
                if (cmbTipo.SelectedItem.ToString() == "Eólica" || cmbTipo.SelectedItem.ToString() == "Solar" || cmbTipo.SelectedItem.ToString() == "Hidroeletrica" || cmbTipo.SelectedItem.ToString() == "Geotérmica" || cmbTipo.SelectedItem.ToString() == "Hidrogénio" || cmbTipo.SelectedItem.ToString() == "Biomassa" || cmbTipo.SelectedItem.ToString() == "Hidráulica")
                {
                    panel1.Hide();
                    txtCapacidade.Clear();
                    txtGasto.Clear();
                    txtMaterial.Clear();
                }
                else
                {
                    panel1.Show();
                    txtCapacidade.Enabled = true;
                    txtGasto.Enabled = true;
                    txtMaterial.Enabled = true;
                    VerifyTxt();
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Usina());
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtCapacidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void VerifyTxt()
        {
            if (cmbTipo.SelectedIndex > -1)
            {
                if (cmbTipo.SelectedItem.ToString() == "Eólica" || cmbTipo.SelectedItem.ToString() == "Solar" || cmbTipo.SelectedItem.ToString() == "Hidroeletrica" || cmbTipo.SelectedItem.ToString() == "Geotérmica" || cmbTipo.SelectedItem.ToString() == "Hidrogénio" || cmbTipo.SelectedItem.ToString() == "Biomassa" || cmbTipo.SelectedItem.ToString() == "Hidraulica")
                {
                    if (txtNome.TextLength > 0 && txtProd.TextLength > 0 && txtLoc.TextLength > 0)
                    {
                        btnIns.Enabled = true;
                    }
                    else
                    {
                        btnIns.Enabled = false;
                    }
                }
                else
                {

                    if (txtNome.TextLength > 0 && txtProd.TextLength > 0 && txtLoc.TextLength > 0 && txtCapacidade.TextLength > 0 && txtGasto.TextLength > 0 && txtMaterial.TextLength > 0)
                    {
                        btnIns.Enabled = true;
                    }
                    else
                    {
                        btnIns.Enabled = false;
                    }

                }
            }

        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            VerifyTxt();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            VerifyTxt();
        }

        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {

            VerifyTxt();
        }

        private void txtCapacidade_TextChanged(object sender, EventArgs e)
        {

            VerifyTxt();
        }

        private void txtGasto_TextChanged(object sender, EventArgs e)
        {

            VerifyTxt();
        }

        private void txtProd_TextChanged_1(object sender, EventArgs e)
        {

            VerifyTxt();
        }

        private void btnIns_Click(object sender, EventArgs e)
        {

            try
            {

                BD.Open();
                SqlCommand cmd = new SqlCommand("Insert into Usina(Nome,Tipo,capacidade,localizacao,data_construcao,status,prodMax,Material,Gasto) values(@Nome,@Tipo,@Capacidade,@localizacao,@dataConst,@status,@prodMax,@Material,@Gasto)", BD);
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Tipo", cmbTipo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Capacidade", txtCapacidade.Text);
                cmd.Parameters.AddWithValue("@localizacao", txtLoc.Text);
                cmd.Parameters.AddWithValue("@dataConst", dtpData.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@status", "Online");
                cmd.Parameters.AddWithValue("@prodMax", txtProd.Text);
                cmd.Parameters.AddWithValue("@Material", txtMaterial.Text);
                cmd.Parameters.AddWithValue("@Gasto", txtGasto.Text);
                int row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Inseridos", "Inserido", MessageBoxButtons.OK);
                    cmbTipo.SelectedItem = null;
                    txtCapacidade.Clear();
                    txtProd.Clear();
                    txtGasto.Clear();
                    txtLoc.Clear();
                    txtMaterial.Clear();
                    txtNome.Clear();
                    dtpData.Value = DateTime.Today;
                    btnIns.Enabled = false;
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
            finally
            {
                BD.Close();
            }
        }

        private void txtGasto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
