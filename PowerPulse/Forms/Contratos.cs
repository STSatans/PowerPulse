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
    public partial class Contratos : Form
    {
        public Contratos()
        {
            InitializeComponent();
        }
        private static readonly string con2 = ConfigurationManager.ConnectionStrings["BDest"].ConnectionString;//con estagio
        //private static readonly string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;//con casa
        //SqlConnection BD=new SqlConnection(con);//con casa
        SqlConnection BD2 = new SqlConnection(con2);//con estagio

        private void Contratos_Load(object sender, EventArgs e)
        {
           //Btns
           btnCancel.Hide();
           btnUpdate.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Show();
            btnCancel.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BD2.Open();
            SqlCommand cmd= new SqlCommand("Update Fatura Set",BD2);
            int rows=cmd.ExecuteNonQuery();
            if(rows>1)
            {
                MessageBox.Show("Valores Inseridos Com sucesso","Aviso",MessageBoxButtons.OK);
                btnCancel.Hide();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro,por favor verifique os dados", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void verificarTXT()
        {

        }
    }
}
