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
    public partial class StatsAdm : Form
    {
        public StatsAdm()
        {
            InitializeComponent();
        }
        //conexoes
        private static readonly string con = ConfigurationManager.ConnectionStrings["BDest"].ConnectionString;//con estagio
        //private static readonly string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;//con casa
        //SqlConnection BD=new SqlConnection(con);//con casa
        SqlConnection BD = new SqlConnection(con);//con estagio
        private void StatsAdm_Load(object sender, EventArgs e)
        {
           BD.Open();
            SqlCommand cmd = new SqlCommand("Select Count(ID_Usina) from Usina");
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd != null)
            {
                while (rd.Read()) 
                {
                    lblUsinas.Text = rd[0].ToString();
                    //lblTUsinas.Text =;
                }
            }
        }
    }
}