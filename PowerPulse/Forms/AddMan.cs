using System;
using System.Configuration;
using System.Data.SqlClient;
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
                SqlCommand cmd2 = new SqlCommand("Insert into manutencao_usina(id_usina,data_ini,data_fim,tipo_manutencao,custo_manutencao,descricao,estado) values(@id_usina,@data_ini,@data_fim,@tipo_manutencao,@custo_manutencao,@descricao,@estado)", BD);
                cmd2.Parameters.AddWithValue("@ID_Usina", id[0]);
                cmd2.Parameters.AddWithValue("@data_ini", date_ini);
                cmd2.Parameters.AddWithValue("@data_fim", date_end);
                cmd2.Parameters.AddWithValue("@tipo_manutencao", cmbMan.SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("@custo_manutencao", txtCosts.Text);
                cmd2.Parameters.AddWithValue("@descricao", txtDesc.Text);
                if (date_ini.Date > DateTime.Today)
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
                            cmbMan.SelectedItem = null;
                            cmbUsina.SelectedItem = null;
                            txtCosts.Clear();
                            dtpIni.Value = DateTime.Now;
                            dtpFim.Value = DateTime.Now;

                            txtCosts.Enabled = false;
                            cmbMan.Enabled = false;
                            dtpIni.Enabled = false;
                            dtpFim.Enabled = false;
                            btnIns.Enabled = false;
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
            verify();
            txtDesc.Enabled = true;
            txtCosts.Enabled = true;
            cmbMan.Enabled = true;
            dtpIni.Enabled = true;
            dtpFim.Enabled = true;
            txtCosts.Text = "";
            txtDesc.Text = "";
        }
        private void verify()
        {
            if (cmbUsina.SelectedItem != null && cmbMan.SelectedItem != null && dtpIni.Value != null && dtpFim.Value != null && txtCosts.Text != "" && txtDesc.Text != "")
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
            TextBox textBox = sender as TextBox;

            // Temporarily unsubscribe from TextChanged event to avoid recursive calls
            textBox.TextChanged -= txtCosts_TextChanged;

            try
            {
                // Replace dots with commas for consistency
                string text = textBox.Text.Replace('.', ',');

                if (IsValidFormat(text))
                {
                    verify(); // Call your verify method if the format is valid
                }
                else
                {
                    // Only remove the last character if the text box is not empty
                    if (textBox.Text.Length > 0)
                    {
                        textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                        textBox.SelectionStart = textBox.Text.Length; // Set cursor position to the end
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-subscribe to TextChanged event
                textBox.TextChanged += txtCosts_TextChanged;
            }
        }

        private bool IsValidFormat(string text)
        {
            // Split the text into parts based on the comma
            string[] parts = text.Split(',');

            // Check if there are more than one comma
            if (parts.Length > 2)
            {
                return false;
            }

            // Check the length of the integer part
            if (parts[0].Length > 10)
            {
                return false;
            }

            // Check the length of the fractional part, if it exists
            if (parts.Length == 2 && parts[1].Length > 2)
            {
                return false;
            }

            return true;
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

        private void txtCosts_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            char ch = e.KeyChar;

            // Allow control characters (e.g., backspace)
            if (char.IsControl(ch))
            {
                return;
            }

            // Allow only one comma or dot
            if (ch == ',' || ch == '.')
            {
                if (textBox.Text.IndexOfAny(new char[] { ',', '.' }) != -1)
                {
                    e.Handled = true;
                }
                return;
            }

            // Allow digits
            if (!char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }
    }
}
