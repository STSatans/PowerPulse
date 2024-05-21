using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class Manutencao : Form
    {
        private Form currentChildForm;

        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);

        public Manutencao()
        {
            InitializeComponent();
        }

        private void Manutencao_Load(object sender, EventArgs e)
        {
            //BTN
            btnEdit.Visible = false;
            btnCanc.Visible = false;
            btnConf.Visible = false;
            //Txt
            txtCost.Enabled = false;
            //cmb
            cmbTipoM.Enabled = false;
            //dtp
            dtpDataIni.Enabled = false;
            dtpDataFim.Enabled = false;

            BD.Open();
            SqlCommand cmd = new SqlCommand("Select id_usina,data_ini,data_fim,tipo_manutencao,custo_manutencao,descricao,estado from Manutencao_Usina", BD);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    // Criar um array de strings para armazenar os dados de uma linha
                    string[] row = new string[rdr.FieldCount];

                    // Preencher o array com os valores das colunas
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        row[i] = rdr[i].ToString();
                    }

                    // Adicionar os valores ao ListView
                    lstMan.Items.Add(new ListViewItem(row));
                }
            }
            BD.Close();
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

        private void btnIns_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddMan());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCanc.Visible = true;
            btnConf.Visible = true;
            cmbTipoM.Enabled = true;
            dtpDataFim.Enabled = true;
            dtpDataIni.Enabled = true;
            txtCost.Enabled = true;
            //colours
            cmbTipoM.BackColor = Color.FromArgb(30, 30, 30);
            txtCost.BackColor = Color.FromArgb(30, 30, 30);

        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            btnCanc.Visible = false;
            btnConf.Visible = false;
            cmbTipoM.Enabled = false;
            dtpDataFim.Enabled = false;
            dtpDataIni.Enabled = false;
            txtCost.Enabled = false;

            //Reset infos
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Delete from Manutencao_Usina where id_usina=@ID", BD);
                foreach (ListViewItem selectedItem in lstMan.SelectedItems)
                {
                    cmd.Parameters.AddWithValue("@ID", selectedItem.SubItems[0].Text);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Eliminados");
                        lstMan.Items.Remove(selectedItem);
                    }
                    else
                    {
                        MessageBox.Show("Erro");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { BD.Close(); }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMan.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = lstMan.SelectedItems[0];

                // Display subitems in separate labels
                for (int i = 0; i < selectedItem.SubItems.Count; i++)
                {
                    dtpDataIni.Value = Convert.ToDateTime(selectedItem.SubItems[1].Text);
                    dtpDataFim.Value = Convert.ToDateTime(selectedItem.SubItems[2].Text);
                    txtCost.Text = selectedItem.SubItems[4].Text;
                    cmbTipoM.Text = selectedItem.SubItems[3].Text;
                    txtCost.ForeColor = Color.White;
                    txtCost.BackColor = Color.FromArgb(30, 30, 30);
                }
                btnEdit.Visible = true;
            }
            else
            {

            }
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select top(1) data_ini,data_fim,tipo_manutencao,custo_manutencao from Manutencao_usina where ", BD);
            DateTime inicio = dtpDataIni.Value;
            DateTime fim = dtpDataFim.Value;
            string tipo = cmbTipoM.SelectedItem.ToString();
            string custo = txtCost.Text;
        }
    }
}
