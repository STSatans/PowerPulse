using System;
using System.Configuration;
using System.Data.SqlClient;
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
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);//con estagio

        private void Cliente_Load(object sender, EventArgs e)
        {
            //btnEdit.Visible = false;

            BD.Open();
            SqlCommand cmd = new SqlCommand("Select * from Cliente", BD);
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
                lst.Items.Add(new ListViewItem(row));
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Delete from Cliente where id_cliente=@ID", BD);
                foreach (ListViewItem selectedItem in lst.SelectedItems)
                {
                    cmd.Parameters.AddWithValue("@ID", selectedItem.SubItems[0].Text);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Eliminados");
                        lst.Items.Remove(selectedItem);
                    }
                    else
                    {
                        MessageBox.Show("Erro");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { BD.Close(); }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
