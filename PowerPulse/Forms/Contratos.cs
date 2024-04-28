using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class Contratos : Form
    {
        public Contratos()
        {
            InitializeComponent();
        }
        //private static readonly string con = ConfigurationManager.ConnectionStrings["BDest"].ConnectionString;//con estagio
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        //private static readonly string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;//con casa
        SqlConnection BD = new SqlConnection(con);//con casa

        private void Contratos_Load(object sender, EventArgs e)
        {
            //Btns
            btnCancel.Hide();
            btnUpdate.Hide();
            btnEdit.Hide();
            EditOFF();
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select * from Contrato", BD);
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
            BD.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Show();
            btnCancel.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Update Fatura Set", BD);
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Delete from Contratos where ID=" + listView1.SelectedItems[0].Text);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("Eliminados", "", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Erro");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Show();
        }
        //Métodos

        private void EditOFF()
        {
            txtNome.Enabled = false;
            txtMoradaCliente.Enabled = false;
            txtContato.Enabled = false;
            //cmbTipoCl.Enabled = false;
        }
        private void EditOn()
        {
            txtNome.Enabled = false;
            txtMoradaCliente.Enabled = false;
            txtContato.Enabled = false;
            //cmbTipoCl.Enabled = false;
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Inser into Contrato values()");
        }

        private void cmbTipoCl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMoradaCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select Cliente.nome,Cliente.endereco,Contrato.* from Cliente left join Cliente.Contrato=Contrato.id_contrato where id_cliente=" + cmbNIF.SelectedItem.ToString(), BD);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

            }
        }
    }
}
