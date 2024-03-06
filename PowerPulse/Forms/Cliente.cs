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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        //conexoes
        private static readonly string con2 = ConfigurationManager.ConnectionStrings["BDest"].ConnectionString;//con estagio
        //private static readonly string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;//con casa
        //SqlConnection BD=new SqlConnection(con);//con casa
        SqlConnection BD2 = new SqlConnection(con2);//con estagio

        private void Cliente_Load(object sender, EventArgs e)
        {
            BD2.Open();
            SqlCommand cmd = new SqlCommand("Select * from Cliente", BD2);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                // Criar um array de strings para armazenar os dados de uma linha
                string[] row = new string[rdr.FieldCount];

                // Preencher o array com os valores das colunas
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    row[i] = rdr[i].ToString();
                }

                // Adicionar os valores ao ListView
                listView1.Items.Add(new ListViewItem(row));
            }
        }
    }
}
