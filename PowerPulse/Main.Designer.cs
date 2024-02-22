namespace PowerPulse
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnFatura = new FontAwesome.Sharp.IconButton();
            this.BtnStats = new FontAwesome.Sharp.IconButton();
            this.btnAdm = new FontAwesome.Sharp.IconButton();
            this.btnContratos = new FontAwesome.Sharp.IconButton();
            this.btnUsinas = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(61)))));
            this.panelMenu.Controls.Add(this.btnExit);
            this.panelMenu.Controls.Add(this.btnFatura);
            this.panelMenu.Controls.Add(this.BtnStats);
            this.panelMenu.Controls.Add(this.btnAdm);
            this.panelMenu.Controls.Add(this.btnContratos);
            this.panelMenu.Controls.Add(this.btnUsinas);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(165, 544);
            this.panelMenu.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 32;
            this.btnExit.Location = new System.Drawing.Point(0, 495);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(8, 0, 15, 0);
            this.btnExit.Size = new System.Drawing.Size(165, 49);
            this.btnExit.TabIndex = 6;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFatura
            // 
            this.btnFatura.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFatura.FlatAppearance.BorderSize = 0;
            this.btnFatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFatura.ForeColor = System.Drawing.Color.White;
            this.btnFatura.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnFatura.IconColor = System.Drawing.Color.White;
            this.btnFatura.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFatura.IconSize = 32;
            this.btnFatura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFatura.Location = new System.Drawing.Point(0, 297);
            this.btnFatura.Margin = new System.Windows.Forms.Padding(0);
            this.btnFatura.Name = "btnFatura";
            this.btnFatura.Padding = new System.Windows.Forms.Padding(8, 0, 15, 0);
            this.btnFatura.Size = new System.Drawing.Size(165, 49);
            this.btnFatura.TabIndex = 5;
            this.btnFatura.Text = "Faturas";
            this.btnFatura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFatura.UseVisualStyleBackColor = true;
            this.btnFatura.Click += new System.EventHandler(this.btnFatura_Click);
            // 
            // BtnStats
            // 
            this.BtnStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnStats.FlatAppearance.BorderSize = 0;
            this.BtnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStats.ForeColor = System.Drawing.Color.White;
            this.BtnStats.IconChar = FontAwesome.Sharp.IconChar.Bucket;
            this.BtnStats.IconColor = System.Drawing.Color.White;
            this.BtnStats.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnStats.IconSize = 32;
            this.BtnStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnStats.Location = new System.Drawing.Point(0, 248);
            this.BtnStats.Margin = new System.Windows.Forms.Padding(0);
            this.BtnStats.Name = "BtnStats";
            this.BtnStats.Padding = new System.Windows.Forms.Padding(8, 0, 15, 0);
            this.BtnStats.Size = new System.Drawing.Size(165, 49);
            this.BtnStats.TabIndex = 4;
            this.BtnStats.Text = "Estatisticas";
            this.BtnStats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnStats.UseVisualStyleBackColor = true;
            this.BtnStats.Click += new System.EventHandler(this.BtnStats_Click);
            // 
            // btnAdm
            // 
            this.btnAdm.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdm.FlatAppearance.BorderSize = 0;
            this.btnAdm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdm.ForeColor = System.Drawing.Color.Snow;
            this.btnAdm.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAdm.IconColor = System.Drawing.Color.Black;
            this.btnAdm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdm.Location = new System.Drawing.Point(0, 199);
            this.btnAdm.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdm.Name = "btnAdm";
            this.btnAdm.Padding = new System.Windows.Forms.Padding(8, 0, 15, 0);
            this.btnAdm.Size = new System.Drawing.Size(165, 49);
            this.btnAdm.TabIndex = 3;
            this.btnAdm.Text = "Admin";
            this.btnAdm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdm.UseVisualStyleBackColor = true;
            this.btnAdm.Click += new System.EventHandler(this.btnAdm_Click);
            // 
            // btnContratos
            // 
            this.btnContratos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContratos.FlatAppearance.BorderSize = 0;
            this.btnContratos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContratos.ForeColor = System.Drawing.Color.White;
            this.btnContratos.IconChar = FontAwesome.Sharp.IconChar.ClipboardCheck;
            this.btnContratos.IconColor = System.Drawing.Color.White;
            this.btnContratos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnContratos.IconSize = 32;
            this.btnContratos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContratos.Location = new System.Drawing.Point(0, 150);
            this.btnContratos.Margin = new System.Windows.Forms.Padding(2);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Padding = new System.Windows.Forms.Padding(8, 0, 15, 0);
            this.btnContratos.Size = new System.Drawing.Size(165, 49);
            this.btnContratos.TabIndex = 2;
            this.btnContratos.Text = "Contratos";
            this.btnContratos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnContratos.UseVisualStyleBackColor = true;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // btnUsinas
            // 
            this.btnUsinas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsinas.FlatAppearance.BorderSize = 0;
            this.btnUsinas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsinas.ForeColor = System.Drawing.Color.White;
            this.btnUsinas.IconChar = FontAwesome.Sharp.IconChar.Bolt;
            this.btnUsinas.IconColor = System.Drawing.Color.White;
            this.btnUsinas.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnUsinas.IconSize = 32;
            this.btnUsinas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsinas.Location = new System.Drawing.Point(0, 101);
            this.btnUsinas.Margin = new System.Windows.Forms.Padding(0);
            this.btnUsinas.Name = "btnUsinas";
            this.btnUsinas.Padding = new System.Windows.Forms.Padding(8, 0, 15, 0);
            this.btnUsinas.Size = new System.Drawing.Size(165, 49);
            this.btnUsinas.TabIndex = 1;
            this.btnUsinas.Text = "Usinas";
            this.btnUsinas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsinas.UseVisualStyleBackColor = true;
            this.btnUsinas.Click += new System.EventHandler(this.btnUsinas_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.lblCargo);
            this.panelLogo.Controls.Add(this.lblUser);
            this.panelLogo.Controls.Add(this.picUser);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(165, 101);
            this.panelLogo.TabIndex = 1;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(61)))));
            this.panelTitleBar.Controls.Add(this.lblForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(165, 0);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(735, 61);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.ForeColor = System.Drawing.Color.White;
            this.lblForm.Location = new System.Drawing.Point(40, 28);
            this.lblForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(35, 13);
            this.lblForm.TabIndex = 3;
            this.lblForm.Text = "label1";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(61)))));
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.White;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 24;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(12, 21);
            this.iconCurrentChildForm.Margin = new System.Windows.Forms.Padding(2);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(24, 26);
            this.iconCurrentChildForm.TabIndex = 2;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(55)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(165, 61);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(735, 9);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(61)))));
            this.panelDesktop.Controls.Add(this.pictureBox2);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(165, 70);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(735, 474);
            this.panelDesktop.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 46);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(702, 384);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // picUser
            // 
            this.picUser.Location = new System.Drawing.Point(3, 21);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(55, 55);
            this.picUser.TabIndex = 0;
            this.picUser.TabStop = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(64, 30);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(38, 17);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "User";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCargo.ForeColor = System.Drawing.Color.White;
            this.lblCargo.Location = new System.Drawing.Point(64, 53);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(46, 17);
            this.lblCargo.TabIndex = 2;
            this.lblCargo.Text = "Cargo";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 544);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnUsinas;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnAdm;
        private FontAwesome.Sharp.IconButton btnContratos;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblForm;
        private FontAwesome.Sharp.IconButton btnFatura;
        private FontAwesome.Sharp.IconButton BtnStats;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.PictureBox pictureBox2;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox picUser;
    }
}