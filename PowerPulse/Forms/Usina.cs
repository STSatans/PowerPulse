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

        private readonly static string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        private readonly static string con2 = ConfigurationManager.ConnectionStrings["BDEst"].ConnectionString;
        //SqlConnection BD = new SqlConnection(con);
        SqlConnection BD = new SqlConnection(con2);

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Delete from Usina where ID=" + listView1.SelectedItems.ToString() + "");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { BD.Close(); }
        }

        private void Usina_Load(object sender, EventArgs e)
        {
            try
            {
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
                //Btns
                btnCancel.Enabled = false;
                btnCancel.Hide();
                btnUpdate.Enabled = false;
                btnUpdate.Hide();
                //con

                BD.Open();

                SqlCommand cmd = new SqlCommand("Select * from Usina", BD);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        ListViewItem lvi = new ListViewItem(rdr["Nome"].ToString());
                        listView1.Items.Add(lvi);
                        if (rdr["Tipo"].ToString() == "Solar")
                        {
                            lvi.ImageIndex = 0;
                        }
                        else if (rdr["Tipo"].ToString() == "Eolica")
                        {
                            lvi.ImageIndex = 1;
                        }
                        else if (rdr["Tipo"].ToString() == "Fossil")
                        {
                            lvi.ImageIndex = 2;
                        }
                        else if (rdr["Tipo"].ToString() == "Geotermica")
                        {
                            lvi.ImageIndex = 3;
                        }
                        else if (rdr["Tipo"].ToString() == "Nuclear")
                        {
                            lvi.ImageIndex = 4;
                        }
                    }
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnCancel.Show();
            btnUpdate.Show();
            btnEditar.Hide();
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Select * from Usina where ID_Usina=" + listView1.SelectedItems.ToString() + "", BD);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.HasRows)
                {
                    if (rdr.Read())
                    {
                        txtNome.Text = rdr["Nome"].ToString();
                        txtLoc.Text = rdr["localizacao"].ToString();
                        txtCapMat.Text = rdr["Capacidade"].ToString();
                        lblTipo.Text = rdr["Tipo"].ToString();
                        dtpData.Text = rdr["data_construcao"].ToString();
                    }
                }
                btnCancel.Enabled = false;
                btnUpdate.Enabled = false;
                btnEditar.Enabled = true;
                btnCancel.Hide();
                btnUpdate.Hide();
                btnEditar.Show();
                //Reset txt com dados BD
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { BD.Close(); }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Item = listView1.SelectedItems[0].Text;
                BD.Open();
                SqlCommand cmd = new SqlCommand("Select *,(select data_ini from Manutencao_Usina) as Manutencao from Usina where Nome = '" + Item + "'", BD);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        //inserir labels
                        lblEstado.Text = rdr["status"].ToString();
                        lblTipo.Text = rdr["Tipo"].ToString();
                        lblProdM.Text = rdr["ProdMax"].ToString();
                        lblMatUs.Text = rdr["Material"].ToString();
                        lblGasto.Text = rdr["Gasto"].ToString();
                        lblManutencao.Text = rdr["data_ini"].ToString();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { BD.Close(); }
        }
    }
}
