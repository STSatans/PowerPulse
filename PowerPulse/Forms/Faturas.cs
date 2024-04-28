using System;
using System.Configuration;
using System.Data.SqlClient;
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

        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);//con casa

        private void Faturas_Load(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select * from Fatura", BD);
            SqlDataReader rdr = cmd.ExecuteReader();
            
            btnEdit.Visible = false;
            btnDel.Visible = false;
            btnInserir.Visible = false;

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCanc.Visible = true;
            btnConf.Visible = true;
            btnEdit.Visible = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDel.Visible = true;
            btnEdit.Visible = true;
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select * from Faturas where ID_Cliente="+comboBox1.Text,BD);
            SqlDataReader rdr1 = cmd.ExecuteReader();
            if(rdr1.HasRows)
            {
                while (rdr1.Read())
                {

                }
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Insert into Faturas values(@ID_Cliente,@Leitura,@Preco)", BD);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                
            }
            else
            {
                MessageBox.Show("Erro ao inserir registos","Warning");
            }


        }

        private void btnConf_Click(object sender, EventArgs e)
        {

        }

        private void btnCanc_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }
    }
}
