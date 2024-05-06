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
            try
            {
                // Open the main database connection
                BD.Open();

                // Initialize a flag to track if any alterations are found
                bool alterationsFound = false;

                // Iterate through each selected item in the ListView
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    // Prepare a SQL query to retrieve the record for the selected item
                    SqlCommand cmd = new SqlCommand("SELECT Id_cliente, Morada, Telefone, Tarifa, Metodo_Pagamento,Id_cliente FROM Cliente WHERE ID_Contrato=@selectedId", BD);
                    cmd.Parameters.AddWithValue("@selectedId", selectedItem.SubItems[0].Text);

                    // Execute the query to retrieve the record
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Check if any alterations are found for the current item
                    while (rdr.Read())
                    {
                        if (cmbNIF.SelectedItem.ToString() != rdr["Id_cliente"].ToString() ||
                            txtMoradaCont.Text != rdr["Morada"].ToString() ||
                            txtTel.Text != rdr["Telefone"].ToString() ||
                            cmbPot.SelectedItem.ToString() != rdr["Tarifa"].ToString() ||
                            cmbMet.SelectedItem.ToString() != rdr["Metodo_Pagamento"].ToString())
                        {
                            alterationsFound = true;
                            break; // Exit the loop since alterations are found
                        }
                    }

                    // Close the SqlDataReader after use
                    rdr.Close();
                    BD.Close();
                }

                // If alterations are found, proceed with the update operation
                if (alterationsFound)
                {
                    BD.Open();
                    SqlCommand cmd2 = new SqlCommand("UPDATE Contratos SET Morada=@Morada , Telefone=@Telefone , Tarifa=@Tarifa , Metodo_Pagamento=@Metodo , Id_cliente=@Id_cliente WHERE ID_Contrato=@selectedId", BD);
                    cmd2.Parameters.AddWithValue("@Id_cliente", cmbNIF.SelectedItem);
                    cmd2.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd2.Parameters.AddWithValue("@endereco", txtMoradaCont.Text);
                    cmd2.Parameters.AddWithValue("@contato", txtContato.Text);
                    cmd2.Parameters.AddWithValue("@Metodo",cmbMet.SelectedItem);
                    cmd2.Parameters.AddWithValue("@Traifa", cmbPot.SelectedItem);
                    cmd2.Parameters.AddWithValue("@selectedId", listView1.SelectedItems[0].SubItems[0].Text); // Assuming only one item is selected

                    int row = cmd2.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Atualizados com Sucesso", "Atualizacao", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar registos", "Atualizacao", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    // No alterations found, prompt the user
                    if (MessageBox.Show("Não foram encontradas alterações nos registos.\r\nDeseja continuar em modo de edição?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        BD.Close();
                        // User chooses not to continue editing, reset fields, and exit the event handler
                        Reset();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the main database connection after use
                BD.Close();
            }


        }

        private void btnDel_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    // Get the selected item
                    ListViewItem selectedItem = listView1.SelectedItems[0];

                    // Display subitems in separate labels
                    for (int i = 0; i < selectedItem.SubItems.Count; i++)
                    {

                    }
                    btnEdit.Visible = true;
                    btnDel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                BD.Close();
            }
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
            txtNome.Enabled = true;
            txtMoradaCliente.Enabled = true;
            txtContato.Enabled = true;
            txtCodP1.Enabled = true;
            txtCodP2.Enabled = true;
        }
        private void Reset()
        {
            cmbMet.SelectedItem = null;
            cmbNIF.SelectedItem = null;
            cmbPot.SelectedItem = null;

            txtCodP1.Text = null;
            txtCodP2.Text = null;
            txtContato.Text = null;
            txtMoradaCliente.Text = null;
            txtMoradaCont.Text = null;
            txtTel.Text = null;
            
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Insert into Contrato(Morada,Telefone,Tarifa,Metodo_Pagamento,Id_Cliente) values(@Morada,@telefone,@tarifa,@metodo_pagamento,@Id_cliente)",BD);
            cmd.Parameters.AddWithValue("@Morada",txtMoradaCont.Text);
            cmd.Parameters.AddWithValue("@telefone",txtTel.Text);
            cmd.Parameters.AddWithValue("@tarifa",cmbPot.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@metodo_pagamento",cmbMet.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Id_cliente", cmbNIF.Text);
            int row=cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Inseridos com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
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
            BD.Close ();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
