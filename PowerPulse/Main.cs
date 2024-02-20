using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPulse
{
    public partial class Main : Form
    {
        private IconButton currentBtn;
        private Panel leftborderBtn;
        public Main()
        {
            InitializeComponent();
            leftborderBtn=new Panel();
            leftborderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftborderBtn);
        }

        private stur

        private void ActivateButton(object senderBtn, Color color) 
        {
            if(senderBtn !=null)
            {
                DisableButton();
                currentBtn=(IconButton)senderBtn;
                currentBtn.BackColor=Color.FromArgb(37,36,81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign=ContentAlignment.MiddleCenter;
                currentBtn.IconColor=color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //leftborder button
                leftborderBtn.BackColor=color;
                leftborderBtn.Location=new Point(0,currentBtn.Location.Y);
                leftborderBtn.Visible=true;
                leftborderBtn.BringToFront();

                //Icon
                iconCurrentChildForm.IconChar=currentBtn.IconChar;
                iconCurrentChildForm.IconColor=color;

            }
        }

        private void DisableButton()
        {
            if(currentBtn!=null)
            {
                currentBtn.BackColor = Color.FromArgb(31,30,68);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Reset()
        {
            leftborderBtn.Visible= false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor= Color.White;
            lblForm.Text = "Home";
        }
    }
}
