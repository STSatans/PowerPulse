using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class Usina : Form
    {
        private Form currentChildForm;
        public Usina()
        {
            InitializeComponent();
        }

        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);
        bool isEditing = false;
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();

                ListViewItem selectedItem = listView1.SelectedItems[0];
                string itemText = selectedItem.Text;
                string[] Item = itemText.Split('-');
                string usinaId = Item[0];
                // Check for associated maintenances
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Manutencao_usina WHERE ID_Usina = @ID_Usina", BD);
                checkCmd.Parameters.AddWithValue("@ID_Usina", usinaId);
                int maintenanceCount = (int)checkCmd.ExecuteScalar();

                bool deleteAll = true;

                if (maintenanceCount > 0)
                {
                    DialogResult result = MessageBox.Show("Existem manutenções associadas a esta usina. Deseja eliminar todas as manutenções associadas?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        deleteAll = false;
                    }
                }
                if (deleteAll)
                {
                    // Delete associated maintenances if any
                    if (maintenanceCount > 0)
                    {
                        SqlCommand deleteMaintenanceCmd = new SqlCommand("DELETE FROM Manutencao_usina WHERE ID_Usina = @ID_Usina", BD);
                        deleteMaintenanceCmd.Parameters.AddWithValue("@ID_Usina", usinaId);
                        deleteMaintenanceCmd.ExecuteNonQuery();
                    }

                    // Delete the usina
                    SqlCommand cmd = new SqlCommand("DELETE FROM Usina WHERE ID_Usina = @ID_Usina", BD);
                    cmd.Parameters.AddWithValue("@ID_Usina", usinaId);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Eliminado");
                        selectedItem.Remove();
                        ResetTxt();
                    }
                    else
                    {
                        MessageBox.Show("No record found to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("A usina não foi eliminada porque existem manutenções associadas.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                BD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (BD.State == ConnectionState.Open)
                {
                    BD.Close();
                }
            }

        }
        private void Usina_Load(object sender, EventArgs e)
        {
            try
            {
                dtpData.Value = DateTime.Today;
                dtpData.Enabled = false;
                //labels 
                lblTipo.Text = "";
                lblEstado.Text = "";
                lblGasto.Text = "";
                lblManutencao.Text = "";
                lblMatUs.Text = "";
                lblProdM.Text = "";
                lblManutencao.Text = "";
                //listview configs
                listView1.View = View.SmallIcon;
                listView1.SmallImageList = ImgSm;
                //txt
                txtCapMat.Enabled = false;
                txtLoc.Enabled = false;
                txtNome.Enabled = false;
                //Btns
                btnCancel.Hide();
                btnUpdate.Hide();
                btnEditar.Hide();
                btnDel.Hide();
                //Reload
                Reload();
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
        private void Reload()
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Select ID_Usina,Nome,Tipo from Usina", BD);
                SqlDataReader rdr = cmd.ExecuteReader();
                listView1.Items.Clear();
                while (rdr.Read())
                {
                    if (rdr.HasRows)
                    {

                        ListViewItem lvi = new ListViewItem(rdr["ID_Usina"].ToString() + "-" + rdr["Nome"].ToString());
                        listView1.Items.Add(lvi);
                        if (rdr["Tipo"].ToString() == "Solar")
                        {
                            lvi.ImageIndex = 0;
                        }
                        else if (rdr["Tipo"].ToString() == "Eólica")
                        {
                            lvi.ImageIndex = 1;
                        }
                        else if (rdr["Tipo"].ToString() == "Fóssil")
                        {
                            lvi.ImageIndex = 2;
                        }
                        else if (rdr["Tipo"].ToString() == "Geotérmica")
                        {
                            lvi.ImageIndex = 3;
                        }
                        else if (rdr["Tipo"].ToString() == "Nuclear")
                        {
                            lvi.ImageIndex = 4;
                        }
                        else if (rdr["Tipo"].ToString() == "Biomassa")
                        {
                            lvi.ImageIndex = 5;
                        }
                        else if (rdr["Tipo"].ToString() == "Hidroeletrica")
                        {
                            lvi.ImageIndex = 6;
                        }
                        else if (rdr["Tipo"].ToString() == "Hidrogénio")
                        {
                            lvi.ImageIndex = 7;
                        }
                        else
                        {
                            lvi.ImageIndex = 8;
                        }
                    }
                }
                BD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            isEditing = true;
            btnCancel.Show();
            btnUpdate.Show();
            btnEditar.Hide();
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            
            txtLoc.Enabled = true;
            txtNome.Enabled = true;
            if (lblTipo.Text=="Geotérmica" || lblTipo.Text == "Eólica"|| lblTipo.Text == "Hidroelétricas")
            {
                txtCapMat.Enabled = false;
            }
            else
            {
                txtCapMat.Enabled = true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddUsina());
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string itemText = selectedItem.Text;
                string[] Item = itemText.Split('-');
                string usinaId = Item[0];

                string query = "SELECT Nome, localizacao, capacidade, tipo, data_construcao FROM Usina WHERE ID_Usina = @ID_Usina";
                SqlCommand cmd = new SqlCommand(query, BD);
                cmd.Parameters.AddWithValue("@ID_Usina", usinaId);

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string nome = rdr["Nome"].ToString();
                        string capacidade = rdr["capacidade"].ToString();
                        string localizacao = rdr["localizacao"].ToString();
                        DateTime dataConstrucao = Convert.ToDateTime(rdr["data_construcao"]);

                        // Convert empty txtCapMat to null for comparison
                        string txtCapMatValue = string.IsNullOrWhiteSpace(txtCapMat.Text) ? null : txtCapMat.Text;

                        bool hasChanges = txtNome.Text != nome ||
                                          txtCapMatValue != capacidade ||
                                          txtLoc.Text != localizacao ||
                                          dtpData.Value != dataConstrucao;

                        if (!hasChanges)
                        {
                            DialogResult result = MessageBox.Show("Não existem alterações nos registros. Deseja continuar a editar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.No)
                            {
                                isEditing = false;
                                txtCapMat.Enabled = false;
                                txtLoc.Enabled = false;
                                txtNome.Enabled = false;
                                btnCancel.Hide();
                                btnUpdate.Hide();
                                rdr.Close();
                                BD.Close();
                                Reset();
                                return;
                            }
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Existem alterações nos registros. Deseja continuar a editar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.No)
                            {
                                isEditing = false;
                                txtCapMat.Enabled = false;
                                txtLoc.Enabled = false;
                                txtNome.Enabled = false;
                                btnCancel.Hide();
                                btnUpdate.Hide();
                                rdr.Close();
                                BD.Close();
                                Reset();
                                return;
                            }
                        }
                    }
                }
                rdr.Close();
                BD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (BD.State == ConnectionState.Open)
                {
                    BD.Close();
                }
            }
        }
        private void Reset()
        {
            try
            {
                    BD.Open();
                    ListViewItem selectedItem = listView1.SelectedItems[0];
                    string itemText = selectedItem.Text;
                    string[] Item = itemText.Split('-');

                    string selectQuery = "SELECT Nome, localizacao, capacidade, tipo, data_construcao FROM Usina WHERE ID_Usina = @UsinaID";
                    using (SqlCommand cmd = new SqlCommand(selectQuery, BD))
                    {
                        cmd.Parameters.AddWithValue("@UsinaID", Item[0]);

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows && rd.Read())
                            {
                                txtNome.Text = rd["Nome"].ToString();
                                txtLoc.Text = rd["localizacao"].ToString();
                                txtCapMat.Text = rd["capacidade"].ToString();
                                lblTipo.Text = rd["tipo"].ToString();
                                dtpData.Value = Convert.ToDateTime(rd["data_construcao"]);
                            }
                        }
                    }

                    txtCapMat.Enabled = false;
                    txtLoc.Enabled = false;
                    txtNome.Enabled = false;
                    btnCancel.Hide();
                    btnUpdate.Hide();
                BD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    ResetTxt();
                    listView1.SelectedItems.Clear();
                    txtCapMat.Enabled = false;
                    txtLoc.Enabled = false;
                    txtNome.Enabled = false;
                    dtpData.Enabled = false;
                    btnCancel.Hide();
                    btnEditar.Hide();
                    btnUpdate.Hide();
                }
                else
                {
                    btnDel.Show();
                    btnEditar.Show();
                    ResetTxt();
                    ListViewItem selectedItem = listView1.SelectedItems[0];

                    // Extract the index part from the ListViewItem's Text property
                    string itemText = selectedItem.Text;

                    // Split the text to extract just the index part
                    string[] Item = itemText.Split('-');
                    BD.Open();
                    SqlCommand cmd = new SqlCommand("Select Usina.*, Manutencao_Usina.data_ini,Manutencao_usina.estado from Usina left join Manutencao_Usina on Usina.ID_Usina=Manutencao_Usina.id_usina where Usina.ID_Usina=" + Item[0], BD);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        DateTime? retrievedDate = rdr.IsDBNull(10) ? (DateTime?)null : rdr.GetDateTime(10);


                        if (retrievedDate == null)
                        {
                            //inserir labels
                            txtNome.Text = rdr["Nome"].ToString();
                            txtLoc.Text = rdr["localizacao"].ToString();
                            txtCapMat.Text = rdr["Capacidade"].ToString();
                            lblEstado.Text = rdr["status"].ToString();
                            lblTipo.Text = rdr["Tipo"].ToString();
                            lblProdM.Text = rdr["ProdMax"].ToString()+" KW/H";
                            lblMatUs.Text = rdr["Material"].ToString();
                            lblGasto.Text = rdr["Gasto"].ToString() + " KW/H";
                            dtpData.Value = Convert.ToDateTime(rdr["data_construcao"].ToString());
                        }
                        else
                        {
                            lblManutencao.Text = retrievedDate.ToString();
                            txtNome.Text = rdr["Nome"].ToString();
                            txtLoc.Text = rdr["localizacao"].ToString();
                            lblEstado.Text = rdr["status"].ToString();
                            lblTipo.Text = rdr["Tipo"].ToString();
                            lblProdM.Text = rdr["ProdMax"].ToString() + " KW/H";
                            lblMatUs.Text = rdr["Material"].ToString();
                            lblGasto.Text = rdr["Gasto"].ToString() + " KW/H";
                            dtpData.Value = Convert.ToDateTime(rdr["data_construcao"].ToString());
                        }
                    }
                    BD.Close();
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
        private void ResetTxt()
        {
            lblEstado.Text = "";
            lblGasto.Text = "";
            lblManutencao.Text = "";
            lblMatUs.Text = "";
            lblProdM.Text = "";
            lblTipo.Text = "";
            txtCapMat.Text = "";
            txtLoc.Text = "";
            txtNome.Text = "";
            dtpData.Value = DateTime.Now;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                ListViewItem selectedItem = listView1.SelectedItems[0];
                // Extract the index part from the ListViewItem's Text property
                string itemText = selectedItem.Text;
                // Split the text to extract just the index part
                string[] Item = itemText.Split('-');
                string query = "SELECT Nome, localizacao, capacidade, data_construcao FROM Usina WHERE ID_Usina = @ID_Usina";
                SqlCommand cmd = new SqlCommand(query, BD);
                cmd.Parameters.AddWithValue("@ID_Usina", Item[0]);

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        bool hasChanges = (txtNome.Text != rdr["Nome"].ToString() ||
                                            txtLoc.Text != rdr["localizacao"].ToString() ||
                                            txtCapMat.Text != rdr["capacidade"].ToString() ||
                                            dtpData.Value != Convert.ToDateTime(rdr["data_construcao"].ToString()));

                        if (!hasChanges)
                        {
                            DialogResult result = MessageBox.Show("Não existe alterações nos registos. Deseja continuar a editar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.No)
                            {
                                isEditing = false;
                                BD.Close();
                                Reset();
                                ResetText();
                                return; // Exit the method to avoid further execution
                            }
                        }
                        else
                        {
                            rdr.Close(); // Close the reader before executing another command
                            string updateQuery = "UPDATE Usina SET Nome = @Nome, localizacao = @loc, capacidade = @cap, data_construcao = @data WHERE ID_Usina = @ID_Usina";
                            SqlCommand updateCmd = new SqlCommand(updateQuery, BD);
                            updateCmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                            updateCmd.Parameters.AddWithValue("@loc", txtLoc.Text);
                            updateCmd.Parameters.AddWithValue("@cap", txtCapMat.Text);
                            updateCmd.Parameters.AddWithValue("@data", dtpData.Value);
                            updateCmd.Parameters.AddWithValue("@ID_Usina", Item[0]);

                            int row = updateCmd.ExecuteNonQuery();
                            if (row > 0)
                            {
                                MessageBox.Show("Atualizados com Sucesso", "Atualizacao", MessageBoxButtons.OK);
                                BD.Close();
                                Reset();
                                Reload();
                                isEditing = false;
                            }
                            else
                            {
                                MessageBox.Show("Erro ao atualizar registos", "Atualizacao", MessageBoxButtons.OK);
                            }
                            return; // Exit the method after the update
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (BD.State == ConnectionState.Open)
                {
                    BD.Close();
                }
            }
        }
        private void txtCapMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void txtLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
