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
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public Main()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            btnAdm.Visible = false;
            btnAdm.Enabled = false;
        }

        private static readonly string con = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        SqlConnection BD=new SqlConnection(con);

        private void Main_Load(object sender, EventArgs e)
        {
            BD.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BD;
            cmd.CommandText = "Select from ";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.HasRows)
            {
                if(reader.Read())
                {
                    lblUser.Text = reader.GetString(0);
                    lblCargo.Text = reader.GetString(1);
                    if(lblCargo.Text=="Admin")
                    {
                        btnAdm.Visible=true;
                        btnAdm.Enabled=true;
                    }
                }
            }
        }

        private void btnUsinas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Usina());
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Contratos());
        }

        private void btnAdm_Click(object sender, EventArgs e)
        {
            //apenas visivel para adm
            OpenChildForm(new Admin());
        }

        private void BtnStats_Click(object sender, EventArgs e)
        {

            //stats para Users
            if (lblCargo.Text == "Admin")
            {
                //OpenChildForm(new ADMStats());
            }
            else
            { OpenChildForm(new Stats()); }
            //criar novo form pra Stats de ADM
        }
        
        private void btnFatura_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Faturas());
        }

        //drag form
        [DllImport("user32.dll",EntryPoint ="ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll",EntryPoint ="SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd,int wMsg,int wParam, int IParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.White;
            lblForm.Text = "Home";
        }
    }
}
