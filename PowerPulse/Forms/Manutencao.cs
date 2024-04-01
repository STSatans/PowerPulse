using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class Manutencao : Form
    {
        private Form currentChildForm;

        private readonly static string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        private readonly static string con2 = ConfigurationManager.ConnectionStrings["BDEst"].ConnectionString;
        //SqlConnection BD = new SqlConnection(con);
        SqlConnection BD = new SqlConnection(con2);
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
            SqlCommand cmd = new SqlCommand("Select * from Manutencao_Usina",BD);
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                if(rdr.HasRows)
                {

                }
            }

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
            btnConf.Visible=true;
            cmbTipoM.Enabled=true;
            dtpDataFim.Enabled=true;
            dtpDataIni.Enabled=true;
            txtCost.Enabled=true;
            
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            btnCanc.Visible = false;
            btnConf.Visible = false;
            cmbTipoM.Enabled = false;
            dtpDataFim.Enabled = false;
            dtpDataIni.Enabled = false;
            txtCost.Enabled =false ;

            //Reset infos
        }
    }
}
