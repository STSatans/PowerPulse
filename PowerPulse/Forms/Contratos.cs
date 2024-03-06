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
            BD2.Open();
            SqlCommand cmd = new SqlCommand("Select * from Contrato",BD2);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Show();
            btnCancel.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BD2.Open();
            SqlCommand cmd = new SqlCommand("Update Fatura Set", BD2);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 1)
            {
                MessageBox.Show("Valores Inseridos Com sucesso", "Aviso", MessageBoxButtons.OK);
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
        private void L()
        {
            txtContato.Enabled = false;
            txtMoradaCliente.Enabled = false;
            txtMoradaCont.Enabled = false;
            txtNome.Enabled = false;
            txtNrCont.Enabled = false;
            txtPagamento.Enabled = false;
            txtTel.Enabled = false;
            txtTipoCliente.Enabled = false;
            txtTipoContrato.Enabled = false;
        }
        private void Enable()
        {
            txtContato.Enabled = true;
            txtMoradaCliente.Enabled = true;
            txtMoradaCont.Enabled = true;
            txtNome.Enabled = true;
            txtNrCont.Enabled = true;
            txtPagamento.Enabled = true;
            txtTel.Enabled = true;
            txtTipoCliente.Enabled = true;
            txtTipoContrato.Enabled = true;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            BD2.Open();
            SqlCommand cmd = new SqlCommand("Delete from ", BD2);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("");
            }
            else
            {
                MessageBox.Show("");
            }
        }
    }
}
