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
                while (rd.Read())
                {
                    lblUsinas.Text = rd[0].ToString();
                    //lblTUsinas.Text =;
                }
            }
            BD.Close();
            BD.Open();
            SqlCommand cmd2 = new SqlCommand("Select Count(ID_Usina),tipo from Usina group by tipo", BD);
            SqlDataReader rd2 = cmd2.ExecuteReader();
            int row = 0;
            while (rd2.Read())
            {
                for (int i = 0; i < rd2.FieldCount; i++)
                {
                    if (lblTUsinas != null)
                    {
                        // lblTUsinas.Text = rd2[i].ToString() + ": " + rd2[i+1].ToString();
                    }
                }
                row++; // Increment row counter for next row
            }
            rd2.Close();
            BD.Close();
            BD.Open();
            SqlCommand cmd3 = new SqlCommand("Select Count(ID) from Login", BD);
            SqlDataReader rd3 = cmd3.ExecuteReader();
            if(rd3 !=null)
            {
                while (rd3.Read())
                {
                    lblFun.Text = rd3[0].ToString();
                }
            }
            rd3.Close();
            BD.Close();
        }
    }
}
