﻿using System;
using System.Configuration;
using System.Data.SqlClient;
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
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        private void StatsAdm_Load(object sender, EventArgs e)
        {
            using (SqlConnection BD = new SqlConnection(con))
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

        private void AtualizarContagemUsinas(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(ID_Usina) from Usina", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    lblUsinas.Text = rd[0].ToString();
                }
            }
        }

        private void AtualizarContagemUsinasPorTipo(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(ID_Usina), tipo from Usina group by tipo", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                string labelText = "";
                while (rd.Read())
                {
                    labelText += rd["tipo"].ToString() + ": " + rd[0].ToString() + "\r\n";
                }
                lblTUsinas.Text = labelText;
            }
        }

        private void AtualizarContagemFuncionarios(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(ID) from Login", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    lblFun.Text = rd[0].ToString();
                }
            }
        }

        private void AtualizarContagemFuncionariosPorCargo(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(ID), cargo from Login group by cargo", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                string labelText2 = "";
                while (rd.Read())
                {
                    labelText2 += rd["cargo"].ToString() + ": " + rd[0].ToString() + "\r\n";
                }
                lblCargos.Text = labelText2;
            }
        }

        private void AtualizarContagemManutencoesInicializadas(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(id_manutencao) from manutencao_usina where estado = 'Inicializada'", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    label11.Text = rd[0].ToString();
                }
            }
        }

        private void AtualizarContagemClientes(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(Id_cliente) from Cliente", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    lblClientes.Text = rd[0].ToString();
                }
            }
        }

        private void AtualizarContagemContratos(SqlConnection BD)
        {
            using (SqlCommand cmd = new SqlCommand("Select Count(ID_Contrato) from Contrato", BD))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                if (rd.Read())
                {
                    lblContratos.Text = rd[0].ToString();
                }
            }
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
    }
}
