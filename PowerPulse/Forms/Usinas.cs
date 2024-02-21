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
    public partial class Usinas : Form
    {
        public Usinas()
        {
            InitializeComponent();
        }

        private void Usinas_Load(object sender, EventArgs e)
        {
            txtLoc.Enabled = false;
            txtMaterial.Enabled = false;
            txtNome.Enabled = false;
            txtTipo.Enabled = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtTipo.Enabled=true;
            txtNome.Enabled=true;
            txtLoc.Enabled=true;
            txtMaterial.Enabled=true;
            lblDataConst.Enabled=false;
            lblNome.Enabled=false;
            lblMaterial.Enabled = false;
            lblTipo.Enabled=false;
        }
    }
}
