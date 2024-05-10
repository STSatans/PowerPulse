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
        }

        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);//con casa

        private void Faturas_Load(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select Fatura.*, Contrato.Id_cliente,Contrato.ID_Contrato from Fatura right join Contrato on Contrato.ID_Contrato = Fatura.ID_Contrato", BD);
            SqlDataReader rdr = cmd.ExecuteReader();
            
            btnEdit.Visible = false;
            btnDel.Enabled = false;
            btnInserir.Enabled = false;
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                        ListViewItem item = new ListViewItem(rdr["ID_Fatura"].ToString());
                        item.SubItems.Add(rdr["Id_Cliente"].ToString());
                        item.SubItems.Add(rdr["ID_Contrato"].ToString());
                        item.SubItems.Add(rdr["Data_Emissao"].ToString());
                        item.SubItems.Add(rdr["Leitura"].ToString());
                        item.SubItems.Add(rdr["Preco"].ToString());
                    listView1.Items.Add(item);
                    cmbNif.Items.Add(rdr[7].ToString());
                }
            }
            BD.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCanc.Visible = true;
            btnConf.Visible = true;
            btnEdit.Visible = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se algum item está selecionado
            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    // Obtenha o primeiro item selecionado
                    ListViewItem selectedItem = listView1.SelectedItems[0];

                    // Obtenha o NIF do cliente do subitem na posição 1
                    string nif = selectedItem.SubItems[1].Text;

                    // Defina o NIF selecionado no ComboBox cmbNIF
                    cmbNif.SelectedItem = nif;

                    // Preencha os outros campos com base no item selecionado
                    cmbCont.SelectedValue = selectedItem.SubItems[2].Text;
                    dateTimePicker1.Value =Convert.ToDateTime(selectedItem.SubItems[3].Text);
                    txtLeit.Text = selectedItem.SubItems[4].Text;
                    lblPrice.Text = selectedItem.SubItems[5].Text;
                    // Desative os controles conforme necessário
                    btnInserir.Enabled = false;
                    btnEdit.Show();
                    btnDel.Enabled = true;
                }
                catch (Exception ex)
                {
                    // Lidar com qualquer exceção ocorrida
                    MessageBox.Show("Ocorreu um erro ao selecionar o item: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Insert into Faturas(ID_Cliente,Data_Emissao,Leitura,Preco,ID_Contrato) values(@ID_Cliente,@Data_Emissao,@Leitura,@Preco,@ID_Contrato)", BD);
            cmd.Parameters.AddWithValue("@ID_Cliente",cmbNif.SelectedItem);
            cmd.Parameters.AddWithValue("@Data_Emissao", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Leitura", txtLeit.Text);
            cmd.Parameters.AddWithValue("@Preco", lblPrice.Text);
            cmd.Parameters.AddWithValue("@ID_Contrato", cmbCont.SelectedItem);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Inseridos com Sucesso", "Sucesso");
                SqlCommand cmd2 = new SqlCommand("Select * from Fatura");
                SqlDataReader rdr = cmd2.ExecuteReader();
                if (rdr.HasRows)
                {
                    while(rdr.Read())
                    {
                       
                    }
                }

            }
            else
            {
                MessageBox.Show("Erro ao inserir registos","Warning");
            }
            BD.Close();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select ID_Contrato from Contrato where Id_cliente="+cmbNif.SelectedItem,BD);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    cmbCont.Items.Add(rd[0].ToString());
                }
            }
            BD.Close();
        }

        private void Verifytxt()
        {
            try
            {
                if (cmbNif.SelectedItem != null && cmbNif.SelectedItem != null && txtLeit.Text!="")
                {
                    btnInserir.Enabled = true;
                }
                else
                {
                    btnInserir.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
