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
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
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
            BD.Open();
            SqlCommand cmd2 = new SqlCommand("Select id_cliente from cliente",BD);
            SqlDataReader rd= cmd2.ExecuteReader();
            if(rd.HasRows)
            {
                while(rd.Read())
                {
                    cmbNIF.Items.Add(rd[0].ToString());
                }
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
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
           
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
            txtCodP1.Enabled = false;
            txtCodP2.Enabled = false;
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
            SqlCommand cmd = new SqlCommand("Insert into Contrato(Morada,telefone,tarifa,Metodo_Pagamento,Id_Cliente) values(@Morada,@telefone,@tarifa,@metodo_pagamento,@Id_cliente)",BD);
            cmd.Parameters.AddWithValue("@Morada",txtMoradaCont.Text);
            cmd.Parameters.AddWithValue("@telefone",txtTel.Text);
            cmd.Parameters.AddWithValue("@tarifa",comboBox2.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@metodo_pagamento",cmbMet.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Id_cliente", cmbNIF.Text);
            int row=cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Inseridos com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SqlCommand cmd2 = new SqlCommand("select * from Contrato", BD);
                SqlDataReader rdr = cmd2.ExecuteReader();
                while (rdr.Read())
                {
                    // Criar um array de strings para armazenar os dados de uma linha
                    string[] fields = new string[rdr.FieldCount];

                    // Preencher o array com os valores das colunas
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        fields[i] = rdr[i].ToString();
                    }

                    // Adicionar os valores ao ListView
                    listView1.Items.Add(new ListViewItem(fields));
                }
                BD.Close();
            }
            else
            {
                MessageBox.Show("Erro na insercao de registos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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
            SqlCommand cmd = new SqlCommand("Select nome,endereco,Contato,codPostal from Cliente",BD);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtNome.Text = reader[0].ToString();
                    txtMoradaCliente.Text= reader[1].ToString();
                    txtContato.Text= reader[2].ToString();
                    string[] cod= reader[3].ToString().Split('-');
                    txtCodP1.Text = cod[0];
                    txtCodP2.Text = cod[1];
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
