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
        public Usina()
        {
            InitializeComponent();
            txtNome.Enabled = false;
            txtData.Enabled = false;
            txtLocal.Enabled = false;
            txtTipo.Enabled = false;
            btnCancel.Enabled = false;
            btnCancel.Hide();
            btnUpdate.Enabled = false;
            btnUpdate.Hide();
        }
        private readonly static string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);
        private void btnDel_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BD;
            cmd.CommandText = "Delete * from where";
            //delete selected and confirm
        }
        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            if(lblStatus.Text=="Offline")
            {
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                lblStatus.ForeColor = Color.Green;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //go to other form
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //enable txtbox
            txtTipo.Enabled=true;
            txtData.Enabled=true;
            txtLocal.Enabled=true;
            txtNome.Enabled=true;
            btnUpdate.Show();
            btnCancel.Show();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Reset
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Update

        }
    }
}
