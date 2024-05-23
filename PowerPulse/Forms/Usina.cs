using System;
using System.Configuration;
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

                // Extract the index part from the ListViewItem's Text property
                string itemText = selectedItem.Text;

                // Split the text to extract just the index part
                string[] Item = itemText.Split('-');
                SqlCommand cmd = new SqlCommand("Delete from Usina where ID_Usina=" + Item[0], BD);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Eliminado");
                    selectedItem.Remove();
                    ResetLst();
                }
                BD.Close();
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
        private void Usina_Load(object sender, EventArgs e)
        {
            try
            {
                dtpData.Value = DateTime.Today;
                dtpData.Enabled = false;
                //labels 
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
                //con

                BD.Open();

                SqlCommand cmd = new SqlCommand("Select * from Usina", BD);
                SqlDataReader rdr = cmd.ExecuteReader();

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
                        else if (rdr["Tipo"].ToString() == "Fossil")
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
                    }
                }
                BD.Close();
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
        private void btnEditar_Click(object sender, EventArgs e)
        {
            isEditing = true;
            btnCancel.Show();
            btnUpdate.Show();
            btnEditar.Hide();
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            txtCapMat.Enabled = true;
            txtLoc.Enabled = true;
            txtNome.Enabled = true;
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
            isEditing = false;
            try
            {
                using (SqlConnection BD = new SqlConnection(con))
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
                    Reset();
                    txtCapMat.Enabled = false;
                    txtLoc.Enabled = false;
                    txtNome.Enabled = false;
                    btnCancel.Hide();
                    btnUpdate.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void Reset()
        {
            try
            {
                using (SqlConnection BD = new SqlConnection(con))
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
                }
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
                    ResetLst();
                    btnEditar.Hide();
                }
                else
                {
                    btnDel.Show();
                    btnEditar.Show();
                    ResetLst();
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
                            lblProdM.Text = rdr["ProdMax"].ToString();
                            lblMatUs.Text = rdr["Material"].ToString();
                            lblGasto.Text = rdr["Gasto"].ToString();
                            dtpData.Value = Convert.ToDateTime(rdr["data_construcao"].ToString());
                        }
                        else
                        {
                            lblManutencao.Text = retrievedDate.ToString();
                            txtNome.Text = rdr["Nome"].ToString();
                            txtLoc.Text = rdr["localizacao"].ToString();
                            lblEstado.Text = rdr["status"].ToString();
                            lblTipo.Text = rdr["Tipo"].ToString();
                            lblProdM.Text = rdr["ProdMax"].ToString();
                            lblMatUs.Text = rdr["Material"].ToString();
                            lblGasto.Text = rdr["Gasto"].ToString();
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
        private void ResetLst()
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
                SqlConnection BD2 = new SqlConnection(con);
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Extract the index part from the ListViewItem's Text property
                string itemText = selectedItem.Text;

                // Split the text to extract just the index part
                string[] Item = itemText.Split('-');
                SqlCommand cmd = new SqlCommand("Select Nome,localizacao,capacidade,data_construcao from Usina where ID_Usina='" + Item[0] + "'", BD);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (txtNome.Text == rdr["Nome"].ToString() && txtCapMat.Text == rdr["Capacidade"].ToString() && txtLoc.Text == rdr["localizacao"].ToString() && dtpData.Value == Convert.ToDateTime(rdr["data_construcao"].ToString()))
                        {
                            DialogResult result = MessageBox.Show("Não existe alterações nos registos. Deseja continuar a editar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.No)
                            {
                                isEditing = false;
                                Reset();
                            }
                        }
                        else
                        {
                            BD2.Open();
                            SqlCommand cmd2 = new SqlCommand("Update Usina set Nome=@Nome,localizacao=@loc,capacidade=@cap,data_construcao=@data where ID_Usina=" + Item[0], BD2);
                            cmd2.Parameters.AddWithValue("@Nome", txtNome.Text);
                            cmd2.Parameters.AddWithValue("@loc", txtLoc.Text);
                            cmd2.Parameters.AddWithValue("@cap", txtCapMat.Text);
                            cmd2.Parameters.AddWithValue("@data", dtpData.Value);
                            int row = cmd2.ExecuteNonQuery();
                            if (row > 0)
                            {
                                MessageBox.Show("Atualizados com Sucesso", "Atualizacao", MessageBoxButtons.OK);
                                BD2.Close();
                                Reset();
                                isEditing = false;
                            }
                            else
                            {
                                MessageBox.Show("Erro ao atualizar registos", "Atualizacao", MessageBoxButtons.OK);
                                BD2.Close();
                            }
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
    }
}
