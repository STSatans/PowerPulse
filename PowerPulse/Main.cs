using FontAwesome.Sharp;
using PowerPulse.Forms;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
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
        public int User { get; set; }

        //conexoes
        private readonly static string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;
        SqlConnection BD = new SqlConnection(con);//con estagio

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
                lblversion.Text="v"+Application.ProductVersion;
                BD.Open();
                SqlCommand cmd = new SqlCommand("Select Nome,Cargo from Login where ID='" + User + "'", BD);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        lblUser.Text = reader.GetString(0);
                        lblCargo.Text = reader.GetString(1);
                        if (lblCargo.Text == "Admin")
                        {
                            picUser.Image = Properties.Resources.icons8_admin_55;
                            btnAdm.Show();
                        }
                        else
                        {
                            btnAdm.Hide();
                            picUser.Image = Properties.Resources.icons8_user_55;
                        }
                    }
                }
                BD.Close();
                // Create a Timer instance
                timer = new Timer();
                // timer.Interval = 28800000; // 8 hour
                timer.Interval = 30000;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCentrais_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Usina(), sender);
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Contratos(), sender);
        }

        private void btnAdm_Click(object sender, EventArgs e)
        {
            //apenas visivel para adm
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Admin(), sender);
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
                iconCurrentChildForm.IconColor = Color.FromArgb(0, 0, 200);
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
        private void OpenChildForm(Form childForm, object senderbtn)
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
            currentBtn = (IconButton)senderbtn;
            lblForm.Text = currentBtn.Text;
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
            OpenChildForm(new Manutencao(), sender);
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Cliente(), sender);
        }
        private void btnStats_Click(object sender, EventArgs e)
        {
            if (lblCargo.Text == "Admin")
            {
                ActivateButton(sender, Color.FromArgb(75, 255, 87));
                OpenChildForm(new StatsAdm(), sender);
            }
            else
            {
                ActivateButton(sender, Color.FromArgb(75, 255, 87));
                OpenChildForm(new Stats(), sender);
            }
        }
        private void btnFaturas_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(75, 255, 87));
            OpenChildForm(new Faturas(), sender);
        }
        private Timer timer;
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                BD.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Manutencao_Usina SET estado = 'Concluida' WHERE data_fim < GETDATE()", BD);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {

                    BD.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                BD.Close();
            }
        }
        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
