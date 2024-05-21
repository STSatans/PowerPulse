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
        bool isEditing=false;
        private void Faturas_Load(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select Fatura.*, Contrato.Id_cliente,Contrato.ID_Contrato from Fatura right join Contrato on Contrato.ID_Contrato = Fatura.ID_Contrato", BD);
            SqlDataReader rdr = cmd.ExecuteReader();
            lblPrice.Text = "";
            btnEdit.Visible = false;
            btnCanc.Hide();
            btnConf.Hide();
            btnDel.Enabled = false;
            btnInserir.Enabled = false;
            cmbCont.Enabled = false;
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
                    cmbNif.Items.Add(rdr["Id_Cliente"].ToString());
                }
            }
            BD.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCanc.Visible = true;
            btnConf.Visible = true;
            btnEdit.Visible = false;
            isEditing = true;
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
                    cmbCont.SelectedItem = selectedItem.SubItems[2].Text;
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
            string[] preco=lblPrice.Text.Split(' ');
            SqlCommand cmd = new SqlCommand("Insert into Fatura(ID_Cliente,Data_Emissao,Leitura,Preco,ID_Contrato) values(@ID_Cliente,@Data_Emissao,@Leitura,@Preco,@ID_Contrato)", BD);
            cmd.Parameters.AddWithValue("@ID_Cliente",cmbNif.SelectedItem);
            cmd.Parameters.AddWithValue("@Data_Emissao", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Leitura", txtLeit.Text);
            cmd.Parameters.AddWithValue("@Preco", preco[0].Trim());
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
                        ListViewItem item = new ListViewItem(rdr["ID_Fatura"].ToString());
                        item.SubItems.Add(rdr["Id_Cliente"].ToString());
                        item.SubItems.Add(rdr["ID_Contrato"].ToString());
                        item.SubItems.Add(rdr["Data_Emissao"].ToString());
                        item.SubItems.Add(rdr["Leitura"].ToString());
                        item.SubItems.Add(rdr["Preco"].ToString());
                        listView1.Items.Add(item);
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
            foreach (ListViewItem item in listView1.Items)
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Select Data_Emissao,Leitura,Preco from Fatura where ID_Fatura=@Fatura", BD);
                cmd.Parameters.AddWithValue("@Fatura", item.SubItems[0].Text);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (dateTimePicker1.Value != Convert.ToDateTime(rd[0]) || txtLeit.Text != rd[1].ToString()|| lblPrice.Text != rd[2].ToString())
                        {
                            SqlCommand cmd2 = new SqlCommand("Insert into Fatura(Data_Emissao,Leitura,Preco) SET Data_Emissao=@Data, leitura=@leitura,Preco=@Preco where ID_Fatura=@Fatura", BD);
                            cmd2.Parameters.AddWithValue("Data",dateTimePicker1.Value);
                            cmd2.Parameters.AddWithValue("leitura",txtLeit.Text);
                            cmd2.Parameters.AddWithValue("Preco",lblPrice.Text);
                            cmd2.Parameters.AddWithValue("Fatura", item.SubItems[0].Text);
                            int row=cmd2.ExecuteNonQuery();
                            if(row >0)
                            {
                                MessageBox.Show("Registo Alterado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isEditing = false;
                                ResetText();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao Atualizar o registo","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Nao existem alteracoes. Deseja Continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if(result==DialogResult.No)
                            {
                                isEditing=false;
                                ResetText();
                            }
                        }
                    }
                }
            }
        
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Select Data_Emissao,Leitura,Preco from Fatura where ID_Fatura=@Fatura", BD);
                cmd.Parameters.AddWithValue("@Fatura", item.SubItems[0].Text);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (dateTimePicker1.Value != Convert.ToDateTime(rd[0]) || txtLeit.Text != rd[1].ToString() || lblPrice.Text != rd[2].ToString())
                        {
                            DialogResult result = MessageBox.Show("Existem Alterações por guardar. Deseja Sair do Modo de Edicao?","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                            if(result==DialogResult.Yes)
                            {
                                isEditing = false;
                                ResetText();
                            }
                        }
                    }
                }
            }
        }
                        

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Delete from Fatura where ID_Fatura=@Fatura");
                cmd.Parameters.AddWithValue("@Fatura", item.SubItems[0].Text);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Registo Eliminado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isEditing = false;
                    ResetText();
                }
                else
                {
                    MessageBox.Show("Erro ao Eliminar o Registo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    cmbCont.Enabled = true;
                }
            }
            BD.Close();
        }

        private void Verifytxt()
        {
            try
            {
                if (!isEditing)
                {
                    if (cmbNif.SelectedItem != null && cmbNif.SelectedItem != null && txtLeit.Text != "")
                    {
                        btnInserir.Enabled = true;
                    }
                    else
                    {
                        btnInserir.Enabled = false;
                    }
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

        private void cmbCont_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verifytxt();
        }

        private void txtLeit_TextChanged(object sender, EventArgs e)
        {
            Verifytxt();
            int preco = Convert.ToInt32(txtLeit.Text) * 50;
            lblPrice.Text = preco.ToString()+" €";
        }

        private void txtLeit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
