﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPulse.Forms
{
    public partial class AddUsina : Form
    {
        public AddUsina()
        {
            InitializeComponent();
        }

        private void AddUsina_Load(object sender, EventArgs e)
        {

        }
        private readonly static string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        private readonly static string con2 = ConfigurationManager.ConnectionStrings["BDEst"].ConnectionString;
        //SqlConnection BD = new SqlConnection(con);
        SqlConnection BD = new SqlConnection(con2);
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem.ToString() == "Solar"||cmbTipo.SelectedItem.ToString() == "Eolica"|| cmbTipo.SelectedItem.ToString() == "Hidroeletrica")
            {
                panel1.Hide();
            }
           
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand("Insert into Usina(Nome,Tipo,capacidade,localizacao,data_construcao) values(@Nome,@Tipo,@Capacidade,@localizacao,@dataConst)",BD);
            cmd.Parameters.AddWithValue("@Nome",txtNome.Text);
            cmd.Parameters.AddWithValue("@Tipo", cmbTipo.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Capacidade",txtCapacidade.Text);
            cmd.Parameters.AddWithValue("@localizacao", txtLoc.Text);
            cmd.Parameters.AddWithValue("@dataConst", dtpData.Value.ToString("yyyy-MM-dd"));


            int row=cmd.ExecuteNonQuery();

            if(row >0)
            {
                MessageBox.Show("Inseridos", "Inserido",MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Nao Inseridos", "Inserido", MessageBoxButtons.OK);
            }
        }
    }
}
