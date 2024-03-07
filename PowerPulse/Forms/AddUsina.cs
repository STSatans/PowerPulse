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
    public partial class AddUsina : Form
    {
        public AddUsina()
        {
            InitializeComponent();
        }

        private void AddUsina_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Solar"||comboBox1.SelectedItem.ToString() == "Eolica"|| comboBox1.SelectedItem.ToString() == "Hidroeletrica")
            {
                panel1.Hide();
            }
           
        }
    }
}
