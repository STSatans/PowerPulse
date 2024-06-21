using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Windows.Controls.Primitives;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class StatsAdm : Form
    {
        public StatsAdm()
        {
            InitializeComponent();
        }
        //conexoes
        //private static readonly string con = ConfigurationManager.ConnectionStrings["BDest"].ConnectionString;//con estagio
        //private static readonly string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;//con casa
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);//con casa
        private void StatsAdm_Load(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Select Count(ID_Usina) from Usina", BD);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd != null)
            {
                BD.Open();
                AtualizarContagens(BD);
                AtualizarLucros(BD);
            }
        }
        private void AtualizarContagens(SqlConnection BD)
        {
            AtualizarContagemUsinas(BD);
            AtualizarContagemUsinasPorTipo(BD);
            AtualizarContagemFuncionarios(BD);
            AtualizarContagemFuncionariosPorCargo(BD);
            AtualizarContagemManutencoesInicializadas(BD);
            AtualizarContagemClientes(BD);
            AtualizarContagemContratos(BD);
        }
        private void AtualizarLucros(SqlConnection BD)
        {
            decimal totalGanhos = 0;
            decimal totalDespesas = 0;
            using (SqlCommand cmd = new SqlCommand("SELECT (SELECT SUM(Preco) FROM Fatura) AS TotalGanhos, (SELECT SUM(custo_manutencao) FROM Manutencao_Usina) AS TotalDespesas", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    totalGanhos = rd["TotalGanhos"] != DBNull.Value ? Convert.ToDecimal(rd["TotalGanhos"]) : 0;
                    totalDespesas = rd["TotalDespesas"] != DBNull.Value ? Convert.ToDecimal(rd["TotalDespesas"]) : 0;
                }
            }
            decimal lucro = totalGanhos - totalDespesas;
            lblLucro.Text = lucro.ToString("C"); // Formatar como moeda
        }
        private void AtualizarContagemUsinas(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(ID_Usina) from Usina", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                while (rd.Read())
                {
                    lblTUsinas.Text = rd[0].ToString();
                }
            }
        }
        private void AtualizarContagemUsinasPorTipo(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(ID_Usina),Tipo from Usina Group by Tipo", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    lblTUsinas.Text = rd[1].ToString() +"-"+rd[0].ToString();
                }
            }
        }
        private void AtualizarContagemFuncionarios(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(ID) from Login", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            rd.Close();
            SqlCommand cmd2 = new SqlCommand("Select Count(ID_Usina),tipo from Usina group by tipo", BD);
            SqlDataReader rd2 = cmd2.ExecuteReader();
            string labelText = ""; // Initialize an empty string to store label text
            while (rd2.Read())
            {
                labelText += rd2[1].ToString() + ": " + rd2[0].ToString() + "\r\n"; // Concatenate text for each row
            }
            rd2.Close();

            // Assign the concatenated text to the label after the loop
            if (lblTUsinas != null)
            {
                lblTUsinas.Text = labelText;
            }
            SqlCommand cmd3 = new SqlCommand("Select Count(ID) from Login", BD);
            SqlDataReader rd3 = cmd3.ExecuteReader();
            if (rd3 != null)
            {
                while (rd3.Read())
                {
                    lblContratos.Text = rd[0].ToString();
                }
            }
        }
        private void AtualizarContagemFuncionariosPorCargo(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(ID),Cargo from Login group by Cargo", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    lblContratos.Text = rd[1].ToString()+"-"+rd[0].ToString();
                }
            }
        }
        private void AtualizarContagemManutencoesInicializadas(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(id_manutencao) from Manutencao_Usina", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    lblContratos.Text = rd[0].ToString();
                }
                    lblFun.Text = rd3[0].ToString();
                }
            }
            rd3.Close();

            SqlCommand cmd4 = new SqlCommand("Select Count(ID),cargo from Login group by cargo", BD);
            SqlDataReader rd4 = cmd4.ExecuteReader();
            string labelText2 = ""; // Initialize an empty string to store label text
            while (rd4.Read())
            {
                labelText2 += rd4[1].ToString() + "-" + rd4[0].ToString() + "\r\n"; // Concatenate text for each row
            }
            rd4.Close();

            // Assign the concatenated text to the label after the loop
            if (lblTUsinas != null)
            {
                lblCargos.Text = labelText2;
            }

            SqlCommand cmd5 = new SqlCommand("Select Count(id_manutencao)from manutencao_usina where estado= 'Inicializada'", BD);
            SqlDataReader rd5 = cmd5.ExecuteReader();
            while (rd5.Read())
            {
                label11.Text = rd5[0].ToString();
            }
            rd5.Close();
        }
        private void AtualizarContagemClientes(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(Id_cliente) from Cliente", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    lblContratos.Text = rd[0].ToString();
                }
            }
        }
        private void AtualizarContagemContratos(SqlConnection BD)

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblUsinas_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblTUsinas_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
