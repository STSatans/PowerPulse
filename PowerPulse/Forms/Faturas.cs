using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace PowerPulse
{
    public partial class Faturas : Form
    {
        public Faturas()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
        bool isEditing = false;
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);
        private void Faturas_Load(object sender, EventArgs e)
        {
            BD.Open();
            lblPrice.Text = "";
            btnEdit.Visible = false;
            btnCanc.Hide();
            btnConf.Hide();
            btnDel.Enabled = false;
            btnInserir.Enabled = false;
            cmbCont.Enabled = false;
            RefreshListView();
            SqlCommand cmd2 = new SqlCommand("Select Id_cliente from Cliente", BD);
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            if (rdr2.HasRows)
            {
                while (rdr2.Read())
                {
                    cmbNif.Items.Add(rdr2["Id_Cliente"].ToString());
                }
            }
            rdr2.Close();
            BD.Close();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCanc.Visible = true;
            btnConf.Visible = true;
            btnEdit.Visible = false;
            isEditing = true;
            txtLeit.Enabled = true;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se algum item está selecionado
            if (listView1.SelectedItems.Count == 0)
            {
                Reset();
            }
            else
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
                    dateTimePicker1.Value = Convert.ToDateTime(selectedItem.SubItems[3].Text);
                    txtLeit.Text = selectedItem.SubItems[4].Text;
                    lblPrice.Text = selectedItem.SubItems[5].Text;
                    // Desative os controles conforme necessário
                    btnInserir.Enabled = false;
                    btnEdit.Show();
                    btnDel.Enabled = true;

                    cmbNif.Enabled = false;
                    cmbCont.Enabled = false;
                    txtLeit.Enabled = false;
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
            try
            {

                BD.Open();
                string[] preco = lblPrice.Text.Split(' ');
                SqlCommand cmd = new SqlCommand("Insert into Fatura(ID_Cliente,Data_Emissao,Leitura,Preco,ID_Contrato) values(@ID_Cliente,@Data_Emissao,@Leitura,@Preco,@ID_Contrato)", BD);
                cmd.Parameters.AddWithValue("@ID_Cliente", cmbNif.SelectedItem);
                cmd.Parameters.AddWithValue("@Data_Emissao", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Leitura", txtLeit.Text);
                cmd.Parameters.AddWithValue("@Preco", preco[0].Trim());
                cmd.Parameters.AddWithValue("@ID_Contrato", cmbCont.SelectedItem);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Inseridos com Sucesso", "Sucesso");
                    Reset();
                    RefreshListView();
                }
                else
                {
                    MessageBox.Show("Erro ao inserir registos", "Warning");
                }
                BD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnConf_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    using (SqlConnection BD = new SqlConnection(con))
                    {
                        BD.Open();
                        SqlCommand cmd = new SqlCommand("SELECT Data_Emissao, Leitura, Preco FROM Fatura WHERE ID_Fatura = @Fatura", BD);
                        cmd.Parameters.AddWithValue("@Fatura", item.SubItems[0].Text);
                        SqlDataReader rd = cmd.ExecuteReader();
                        string[] price = lblPrice.Text.Split(' ');

                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                if (dateTimePicker1.Value != Convert.ToDateTime(rd["Data_Emissao"]) || txtLeit.Text != rd["Leitura"].ToString() || price[0] != rd["Preco"].ToString())
                                {

                                    using (SqlConnection BD2 = new SqlConnection(con))
                                    {
                                        BD2.Open();
                                        SqlCommand cmd2 = new SqlCommand("UPDATE Fatura SET Data_Emissao = @Data, Leitura = @Leitura, Preco = @Preco WHERE ID_Fatura = @Fatura", BD2);
                                        cmd2.Parameters.AddWithValue("@Data", dateTimePicker1.Value);
                                        cmd2.Parameters.AddWithValue("@Leitura", txtLeit.Text);
                                        cmd2.Parameters.AddWithValue("@Preco", price[0]);
                                        cmd2.Parameters.AddWithValue("@Fatura", item.SubItems[0].Text);
                                        int row = cmd2.ExecuteNonQuery();

                                        if (row > 0)
                                        {
                                            MessageBox.Show("Registo Alterado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            isEditing = false;
                                            Reset();
                                            btnCanc.Hide();
                                            btnConf.Hide();
                                            RefreshListView();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Erro ao Atualizar o registo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    DialogResult result = MessageBox.Show("Não existem alterações. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.No)
                                    {
                                        isEditing = false;
                                        btnCanc.Hide();
                                        btnConf.Hide();
                                        Reset();
                                        rd.Close();
                                        BD.Close();
                                        return;
                                    }
                                }
                            }
                        }
                        rd.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RefreshListView()
        {
            listView1.Items.Clear();
            using (SqlConnection BD = new SqlConnection(con))
            {
                try
                {
                    BD.Open();
                    SqlCommand refreshCmd = new SqlCommand("SELECT * FROM Fatura", BD);
                    SqlDataReader rdr = refreshCmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            ListViewItem lst = new ListViewItem(rdr["ID_Fatura"].ToString());
                            lst.SubItems.Add(rdr["Id_Cliente"].ToString());
                            lst.SubItems.Add(rdr["ID_Contrato"].ToString());
                            lst.SubItems.Add(Convert.ToDateTime(rdr["Data_Emissao"]).ToString("dd/MM/yyyy"));
                            lst.SubItems.Add(rdr["Leitura"].ToString());
                            lst.SubItems.Add(rdr["Preco"].ToString());
                            listView1.Items.Add(lst);
                        }
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCanc_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    BD.Open();
                    SqlCommand cmd = new SqlCommand("Select Data_Emissao,Leitura,Preco from Fatura where ID_Fatura=@Fatura", BD);
                    cmd.Parameters.AddWithValue("@Fatura", selectedItem.SubItems[0].Text);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            if (dateTimePicker1.Value != Convert.ToDateTime(rd[0]) || txtLeit.Text != rd[1].ToString() || lblPrice.Text != rd[2].ToString())
                            {
                                DialogResult result = MessageBox.Show("Existem Alterações por guardar. Deseja Sair do Modo de Edicao?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.Yes)
                                {
                                    isEditing = false;
                                    btnCanc.Hide();
                                    btnConf.Hide();
                                    Reset();
                                    return;
                                }
                            }
                        }
                    }
                    rd.Close();
                    BD.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Fatura WHERE ID_Fatura = @Fatura", BD);

                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Fatura", selectedItem.SubItems[0].Text);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registo eliminado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isEditing = false;
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao eliminar o registo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BD.Close();
            }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Reset()
        {
            listView1.SelectedItems.Clear();
            txtLeit.Text = "";
            cmbCont.SelectedItem = null;
            cmbNif.SelectedItem = null;
            dateTimePicker1.Value = DateTime.Today;
        }
        private void txtLeit_TextChanged(object sender, EventArgs e)
        {
            Verifytxt();
            if (txtLeit.Text != "")
            {
                int preco = Convert.ToInt32(txtLeit.Text) * 50;
                lblPrice.Text = preco.ToString() + " €";
            }
        }
        private void txtLeit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void cmbNif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNif.SelectedItem != null)
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("Select ID_Contrato from Contrato where Id_cliente=" + cmbNif.SelectedItem, BD);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        cmbCont.Items.Clear();
                        cmbCont.Items.Add(rd[0].ToString());
                        cmbCont.Enabled = true;
                    }
                }
                BD.Close();
            }
        }
    }
}
