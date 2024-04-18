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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        //private static readonly string con = ConfigurationManager.ConnectionStrings["BDest"].ConnectionString;//con estagio
        private static readonly string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;//con casa
        SqlConnection BD = new SqlConnection(con);

        private void Admin_Load(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd= new SqlCommand("Select ID,nome,cargo from login ",BD);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                listBox1.Items.Add(rd[0].ToString()+" - " + rd[1].ToString()+" - " + rd[2].ToString());
            }
        }
    }
}
