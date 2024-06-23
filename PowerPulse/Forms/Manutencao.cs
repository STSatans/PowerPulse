using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

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
                    // Criar um array de strings para armazenar os valores das colunas
                    string[] row = new string[]
                    {
                        rdr["id_usina"].ToString(),
                        Convert.ToDateTime(rdr["data_ini"]).ToString("dd/MM/yyyy"), // Formatar data_ini
                        Convert.ToDateTime(rdr["data_fim"]).ToString("dd/MM/yyyy"), // Formatar data_fim
                        rdr["tipo_manutencao"].ToString(),
                        rdr["custo_manutencao"].ToString(),
                        rdr["descricao"].ToString(),
                        rdr["estado"].ToString()
                    };

                    // Criar um novo ListViewItem com os valores das colunas
                    ListViewItem listViewItem = new ListViewItem(row);

                    // Adicionar o ListViewItem à ListView
                    lstMan.Items.Add(listViewItem);
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
            btnCanc.Show();
            btnConf.Show();
            cmbTipoM.Enabled = true;
            dtpDataFim.Enabled = true;
            dtpDataIni.Enabled = true;
            txtCost.Enabled = true;
            btnEdit.Hide();
            //colours
            cmbTipoM.BackColor = Color.FromArgb(30, 30, 30);
            txtCost.BackColor = Color.FromArgb(30, 30, 30);

        }
        private void btnCanc_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();

                DateTime inicio = dtpDataIni.Value;
                DateTime fim = dtpDataFim.Value;
                string tipo = cmbTipoM.Text;
                string custo = txtCost.Text;
                string selectedItem = lstMan.SelectedItems[0].Text;

                string query = "SELECT data_ini, data_fim, tipo_manutencao, custo_manutencao FROM Manutencao_usina WHERE id_manutencao=@id_usina";
                SqlCommand cmd = new SqlCommand(query, BD);
                cmd.Parameters.AddWithValue("@id_usina", selectedItem);

                SqlDataReader rd = cmd.ExecuteReader();

                bool hasChanges = false;

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        DateTime dbInicio = Convert.ToDateTime(rd["data_ini"]);
                        DateTime dbFim = Convert.ToDateTime(rd["data_fim"]);
                        string dbTipo = rd["tipo_manutencao"].ToString();
                        string dbCusto = rd["custo_manutencao"].ToString();
                        hasChanges = inicio != dbInicio || fim != dbFim || tipo != dbTipo || custo != dbCusto;
                    }
                }

                rd.Close();

                if (hasChanges)
                {
                    DialogResult result = MessageBox.Show("Existem alterações nos registros. Deseja Cancelar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Reset();
                    }
                }
                else
                {
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (BD.State == ConnectionState.Open)
                {
                    BD.Close();
                }
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Delete top(1) from Manutencao_Usina where id_usina=@ID", BD);
                foreach (ListViewItem selectedItem in lstMan.SelectedItems)
                {
                    cmd.Parameters.AddWithValue("@ID", selectedItem.SubItems[0].Text);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Eliminados");
                        lstMan.Items.Remove(selectedItem);
                        Reset();
                        btnEdit.Enabled = false;
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
            if (lstMan.SelectedItems.Count == 0)
            {
                Reset();
                btnDel.Hide();
                btnEdit.Hide();
            }
            else
            {
                // Get the selected item
                ListViewItem selectedItem = lstMan.SelectedItems[0];

                // Display subitems in separate labels
                for (int i = 0; i < selectedItem.SubItems.Count; i++)
                {
                    dtpDataIni.Value = Convert.ToDateTime(selectedItem.SubItems[1].Text);
                    dtpDataFim.Value = Convert.ToDateTime(selectedItem.SubItems[2].Text);
                    decimal custo;
                    if (decimal.TryParse(selectedItem.SubItems[4].Text, out custo))
                    {
                        txtCost.Text = string.Format("{0:F2}", custo);
                    }
                    else
                    {
                        // Se a conversão falhar, exibir uma mensagem de erro ou definir um valor padrão
                        txtCost.Text = "0.00";
                    }
                    cmbTipoM.SelectedItem = selectedItem.SubItems[3].Text;
                    txtCost.ForeColor = Color.White;
                    txtCost.BackColor = Color.FromArgb(30, 30, 30);
                }
                btnEdit.Visible = true;
            }
        }
        private void Reset()
        {
            lstMan.SelectedItems.Clear();

            dtpDataFim.Value = DateTime.Now;
            dtpDataIni.Value = DateTime.Today;
            cmbTipoM.SelectedItem = null;
            txtCost.Text = "";

            btnCanc.Visible = false;
            btnConf.Visible = false;
            cmbTipoM.Enabled = false;
            dtpDataFim.Enabled = false;
            dtpDataIni.Enabled = false;
            txtCost.Enabled = false;
        }
        private void btnConf_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                DateTime inicio = dtpDataIni.Value;
                DateTime fim = dtpDataFim.Value;
                string tipo = cmbTipoM.SelectedItem.ToString();
                string custo = txtCost.Text;
                string selectedItem = lstMan.SelectedItems[0].Text;
                string query = "SELECT data_ini, data_fim, tipo_manutencao,custo_manutencao FROM Manutencao_usina WHERE id_usina = @id_usina";
                SqlCommand cmd = new SqlCommand(query, BD);
                cmd.Parameters.AddWithValue("@id_usina", selectedItem);
                SqlDataReader rd = cmd.ExecuteReader();
                bool hasChanges = false;
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        DateTime dbInicio =
                       Convert.ToDateTime(rd["data_ini"]);
                        DateTime dbFim = Convert.ToDateTime(rd["data_fim"]);
                        string dbTipo = rd["tipo_manutencao"].ToString();
                        string dbCusto = rd["custo_manutencao"].ToString();
                        hasChanges = inicio != dbInicio || fim != dbFim ||
                        tipo != dbTipo || custo != dbCusto;
                    }
                }
                rd.Close();

                if (hasChanges)
                {
                    string update = "UPDATE Manutencao_usina SET data_ini = @data_ini, data_fim= @data_fim, tipo_manutencao = @tipo_manutencao, custo_manutencao =@custo_manutencao WHERE id_usina = @id_usina";
                    SqlCommand updateCMD = new SqlCommand(update, BD);
                    updateCMD.Parameters.AddWithValue("@id_usina", selectedItem);
                    updateCMD.Parameters.AddWithValue("@data_ini", inicio);
                    updateCMD.Parameters.AddWithValue("@data_fim", fim);
                    updateCMD.Parameters.AddWithValue("@tipo_manutencao", tipo);
                    updateCMD.Parameters.AddWithValue("@custo_manutencao", custo);
                    int rowsAffected = updateCMD.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dados atualizados com sucesso.", "Informação",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                        SqlCommand refresh = new SqlCommand("Select id_usina, data_ini, data_fim, tipo_manutencao, custo_manutencao, descricao, estado from Manutencao_Usina", BD);

                        SqlDataReader rdr = refresh.ExecuteReader();
                        lstMan.Items.Clear();
                        while (rdr.Read())
                        {
                            if (rdr.HasRows)
                            {
                                // Criar um array de strings para armazenar os valores das colunas
                                string[] row = new string[]
                                  {
                                 rdr["id_usina"].ToString(),
                                 Convert.ToDateTime(rdr["data_ini"]).ToString("dd/MM/yyyy"),
                                 // Formatar data_ini
                                 Convert.ToDateTime(rdr["data_fim"]).ToString("dd/MM/yyyy"),
                                 // Formatar data_fim
                                 rdr["tipo_manutencao"].ToString(),
                                 rdr["custo_manutencao"].ToString(),
                                 rdr["descricao"].ToString(),
                                 rdr["estado"].ToString()
                                   };

                                // Criar um novo ListViewItem com os valores das colunas
                                ListViewItem listViewItem = new ListViewItem(row);
                                // Adicionar o ListViewItem à ListView
                                lstMan.Items.Add(listViewItem);
                            }
                        }
                        BD.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (BD.State == ConnectionState.Open)
                {
                    BD.Close();
                }
            }

        }
    }
}
