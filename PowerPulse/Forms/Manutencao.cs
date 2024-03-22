using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Manutencao()
        {
            InitializeComponent();
        }

        private void Manutencao_Load(object sender, EventArgs e)
        {
            btnCanc.Visible = false;
            btnConf.Visible = false;

            txtCost.Enabled = false;

            cmbTipoM.Enabled = false;
            
            dtpDataIni.Enabled = false;
            dtpDataFim.Enabled = false;
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
