using FontAwesome.Sharp;
using PowerPulse.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPulse
{
    public partial class Main : Form
    {
        //controlos
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        //Classe publica 
        public int User {  get; set; }
        
        //conexoes
        private static readonly string con2 = ConfigurationManager.ConnectionStrings["BDest"].ConnectionString;//con estagio
        //private static readonly string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;//con casa
        //SqlConnection BD=new SqlConnection(con);//con casa
        SqlConnection BD2 = new SqlConnection(con2);//con estagio

        public Main()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            btnAdm.Hide();

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                BD2.Open();
                SqlCommand cmd = new SqlCommand("Select Nome,Cargo from Login where ID='"+User+"'", BD2);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    if (reader.HasRows)
                    {
                        lblUser.Text = reader.GetString(0);
                        lblCargo.Text = reader.GetString(1);
                        if(lblCargo.Text=="Admin")
                        {
                            //picUser.Image = Properties.Resources; importar imagens em casa
                            btnAdm.Show();
                        }
                    }
                }
                BD2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUsinas_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Usina());
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Contratos());
        }

        private void btnAdm_Click(object sender, EventArgs e)
        {
            //apenas visivel para adm
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Admin());
        }

        private void BtnStats_Click(object sender, EventArgs e)
        {

            //stats para Users
            if (lblCargo.Text == "Admin")
            {
                ActivateButton(sender, Color.FromArgb(75, 255, 87));
                OpenChildForm(new AdmStats());
            }
            else
            {
                ActivateButton(sender, Color.FromArgb(75, 255, 87));
                OpenChildForm(new Stats());
            }
            //criar novo form pra Stats de ADM
        }

        private void btnFatura_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Faturas());
        }

        //drag form
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quer mesmo sair?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { Application.Exit(); }
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblForm.Text = childForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblForm.Text = "Home";
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void btnMant_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Manutencao());
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Cliente());
        }
    }
}
