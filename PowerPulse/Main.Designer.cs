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
            this.btnStats = new FontAwesome.Sharp.IconButton();
            this.btnFaturas = new FontAwesome.Sharp.IconButton();
            this.btnCliente = new FontAwesome.Sharp.IconButton();
            this.btnMant = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnAdm = new FontAwesome.Sharp.IconButton();
            this.btnContratos = new FontAwesome.Sharp.IconButton();
            this.btnCentrais = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(61)))));
            this.panelMenu.Controls.Add(this.btnStats);
            this.panelMenu.Controls.Add(this.btnFaturas);
            this.panelMenu.Controls.Add(this.btnCliente);
            this.panelMenu.Controls.Add(this.btnMant);
            this.panelMenu.Controls.Add(this.btnExit);
            this.panelMenu.Controls.Add(this.btnAdm);
            this.panelMenu.Controls.Add(this.btnContratos);
            this.panelMenu.Controls.Add(this.btnCentrais);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(165, 627);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // btnStats
            // 
            this.btnStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStats.FlatAppearance.BorderSize = 0;
            this.btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStats.ForeColor = System.Drawing.Color.White;
            this.btnStats.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.btnStats.IconColor = System.Drawing.Color.White;
            this.btnStats.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStats.IconSize = 32;
            this.btnStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStats.Location = new System.Drawing.Point(0, 461);
            this.btnStats.Margin = new System.Windows.Forms.Padding(0);
            this.btnStats.Name = "btnStats";
            this.btnStats.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnStats.Size = new System.Drawing.Size(165, 60);
            this.btnStats.TabIndex = 10;
            this.btnStats.Text = "Estatísticas";
            this.btnStats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnFaturas
            // 
            this.btnFaturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFaturas.FlatAppearance.BorderSize = 0;
            this.btnFaturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFaturas.ForeColor = System.Drawing.Color.White;
            this.btnFaturas.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.btnFaturas.IconColor = System.Drawing.Color.White;
            this.btnFaturas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFaturas.IconSize = 32;
            this.btnFaturas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFaturas.Location = new System.Drawing.Point(0, 401);
            this.btnFaturas.Margin = new System.Windows.Forms.Padding(0);
            this.btnFaturas.Name = "btnFaturas";
            this.btnFaturas.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnFaturas.Size = new System.Drawing.Size(165, 60);
            this.btnFaturas.TabIndex = 9;
            this.btnFaturas.Text = "Faturação";
            this.btnFaturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFaturas.UseVisualStyleBackColor = true;
            this.btnFaturas.Click += new System.EventHandler(this.btnFaturas_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.ForeColor = System.Drawing.Color.White;
            this.btnCliente.IconChar = FontAwesome.Sharp.IconChar.Portrait;
            this.btnCliente.IconColor = System.Drawing.Color.White;
            this.btnCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCliente.IconSize = 32;
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCliente.Location = new System.Drawing.Point(0, 341);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(0);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnCliente.Size = new System.Drawing.Size(165, 60);
            this.btnCliente.TabIndex = 8;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnMant
            // 
            this.btnMant.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMant.FlatAppearance.BorderSize = 0;
            this.btnMant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMant.ForeColor = System.Drawing.Color.White;
            this.btnMant.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.btnMant.IconColor = System.Drawing.Color.White;
            this.btnMant.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMant.IconSize = 32;
            this.btnMant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMant.Location = new System.Drawing.Point(0, 281);
            this.btnMant.Margin = new System.Windows.Forms.Padding(0);
            this.btnMant.Name = "btnMant";
            this.btnMant.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnMant.Size = new System.Drawing.Size(165, 60);
            this.btnMant.TabIndex = 7;
            this.btnMant.Text = "Manutenção";
            this.btnMant.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMant.UseVisualStyleBackColor = true;
            this.btnMant.Click += new System.EventHandler(this.btnMant_Click);
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
            this.btnExit.Location = new System.Drawing.Point(0, 578);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(8, 0, 15, 0);
            this.btnExit.Size = new System.Drawing.Size(165, 49);
            this.btnExit.TabIndex = 6;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdm
            // 
            this.btnAdm.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdm.FlatAppearance.BorderSize = 0;
            this.btnAdm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdm.ForeColor = System.Drawing.Color.Snow;
            this.btnAdm.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.btnAdm.IconColor = System.Drawing.Color.White;
            this.btnAdm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdm.IconSize = 32;
            this.btnAdm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdm.Location = new System.Drawing.Point(0, 221);
            this.btnAdm.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdm.Name = "btnAdm";
            this.btnAdm.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnAdm.Size = new System.Drawing.Size(165, 60);
            this.btnAdm.TabIndex = 3;
            this.btnAdm.Text = "Administrador";
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
            this.btnContratos.Location = new System.Drawing.Point(0, 161);
            this.btnContratos.Margin = new System.Windows.Forms.Padding(2);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnContratos.Size = new System.Drawing.Size(165, 60);
            this.btnContratos.TabIndex = 2;
            this.btnContratos.Text = "Contratos";
            this.btnContratos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnContratos.UseVisualStyleBackColor = true;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // btnCentrais
            // 
            this.btnCentrais.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCentrais.FlatAppearance.BorderSize = 0;
            this.btnCentrais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCentrais.ForeColor = System.Drawing.Color.White;
            this.btnCentrais.IconChar = FontAwesome.Sharp.IconChar.Bolt;
            this.btnCentrais.IconColor = System.Drawing.Color.White;
            this.btnCentrais.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCentrais.IconSize = 32;
            this.btnCentrais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCentrais.Location = new System.Drawing.Point(0, 101);
            this.btnCentrais.Margin = new System.Windows.Forms.Padding(0);
            this.btnCentrais.Name = "btnCentrais";
            this.btnCentrais.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnCentrais.Size = new System.Drawing.Size(165, 60);
            this.btnCentrais.TabIndex = 1;
            this.btnCentrais.Text = "Usinas";
            this.btnCentrais.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCentrais.UseVisualStyleBackColor = true;
            this.btnCentrais.Click += new System.EventHandler(this.btnCentrais_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(235)))), ((int)(((byte)(87)))));
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
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCargo.ForeColor = System.Drawing.Color.Black;
            this.lblCargo.Location = new System.Drawing.Point(73, 53);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(46, 17);
            this.lblCargo.TabIndex = 2;
            this.lblCargo.Text = "Cargo";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(73, 28);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(38, 17);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "User";
            // 
            // picUser
            // 
            this.picUser.Location = new System.Drawing.Point(12, 21);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(55, 55);
            this.picUser.TabIndex = 0;
            this.picUser.TabStop = false;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(235)))), ((int)(((byte)(87)))));
            this.panelTitleBar.Controls.Add(this.lblForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(165, 0);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(891, 61);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(61)))));
            this.lblForm.Location = new System.Drawing.Point(48, 28);
            this.lblForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(45, 17);
            this.lblForm.TabIndex = 3;
            this.lblForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.Transparent;
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(200)))));
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(200)))));
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(12, 21);
            this.iconCurrentChildForm.Margin = new System.Windows.Forms.Padding(2);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(32, 32);
            this.iconCurrentChildForm.TabIndex = 2;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(165, 61);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(891, 9);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelDesktop.Controls.Add(this.pictureBox2);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(165, 70);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(891, 557);
            this.panelDesktop.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(247, 99);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(408, 340);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(255)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1056, 627);
            this.ControlBox = false;
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnCentrais;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnAdm;
        private FontAwesome.Sharp.IconButton btnContratos;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.PictureBox pictureBox2;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox picUser;
        private FontAwesome.Sharp.IconButton btnMant;
        private FontAwesome.Sharp.IconButton btnCliente;
        private FontAwesome.Sharp.IconButton btnStats;
        private FontAwesome.Sharp.IconButton btnFaturas;
    }
}