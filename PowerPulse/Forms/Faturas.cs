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

namespace PowerPulse
{
    public partial class Faturas : Form
    {
        public Faturas()
        {
            InitializeComponent();
            btnDel.Visible = false;
            btnConf.Visible = false;
            btnCanc.Visible = false;
        }

        //private static readonly string con = ConfigurationManager.ConnectionStrings["BDest"].ConnectionString;//con estagio
        private static readonly string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;//con casa
        SqlConnection BD = new SqlConnection(con);//con casa

        private void Faturas_Load(object sender, EventArgs e)
        {
            BD.Open();
            //SqlCommand cmd = new SqlCommand("Select * from Fatura",BD);
            //SqlDataReader rdr=cmd.ExecuteReader();

            //if (rdr.HasRows) 
            //{
            //    while (rdr.Read())
            //    {
            //        string[] row = new string[rdr.FieldCount];

            //        // Preencher o array com os valores das colunas
            //        for (int i = 0; i < rdr.FieldCount; i++)
            //        {
            //            row[i] = rdr[i].ToString();
            //        }

            //        // Adicionar os valores ao ListView
            //        listView1.Items.Add(new ListViewItem(row));
            //    }
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCanc.Visible = true;
            btnConf.Visible = true;
            btnEdit.Visible = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDel.Visible = true;
        }
    }
}
