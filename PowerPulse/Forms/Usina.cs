using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            BD.Open();
            SqlCommand cmd = new SqlCommand("Delete from Usina where ID=" + listView1.SelectedItems.ToString() + "");
            cmd.ExecuteNonQuery();
        }

        private void Usina_Load(object sender, EventArgs e)
        {
            //Btns
            btnCancel.Enabled = false;
            btnCancel.Hide();
            btnUpdate.Enabled = false;
            btnUpdate.Hide();
            //con
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select * from Usina", BD);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    ListView item = new ListView();
                }
            }
            BD.Close();
            load();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnCancel.Show();
            btnUpdate.Show();
            btnEditar.Hide();
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            txtOpen();
        }
        private void txtOpen()
        {
            txtLoc.Enabled = true;
            txtNome.Enabled = true;
            txtCapMat.Enabled = true;
            dtpData.Enabled = true;
            txtCapMat.BackColor = Color.White;
            txtLoc.BackColor = Color.White;
            txtNome.BackColor = Color.White;
        }
        private void txtClose()
        {
            txtLoc.Enabled = false;
            txtNome.Enabled =false;
            txtCapMat.Enabled = false;
            dtpData.Enabled = false;
            txtCapMat.BackColor = Color.FromArgb(16, 17, 61);
            txtLoc.BackColor = Color.FromArgb(16, 17, 61);
            txtNome.BackColor = Color.FromArgb(16, 17, 61);
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
            txtClose();
        }

        private void Reset()
        {
            BD.Open();
            SqlCommand cmd= new SqlCommand("Select * from Usina where ID_Usina="+listView1.SelectedItems.ToString()+"",BD);
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.HasRows)
            {
                if(rdr.Read())
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
        private void load()
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select * from Usina where ID_Usina='1'", BD);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    txtNome.Text = rdr["Nome"].ToString();
                    txtLoc.Text = rdr["localizacao"].ToString();
                    txtCapMat.Text = rdr["Capacidade"].ToString();
                    lblEstado.Text = rdr["status"].ToString();
                    lblTipo.Text = rdr["tipo"].ToString();
                    dtpData.Text = rdr["data_construcao"].ToString();
                }
            }

            txtCapMat.Enabled = false;
            txtLoc.Enabled = false;
            txtNome.Enabled = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
