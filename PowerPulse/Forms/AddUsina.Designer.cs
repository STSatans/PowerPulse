namespace PowerPulse.Forms
{
    partial class AddUsina
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCapacidade = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpData);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbTipo);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(137, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(112, 211);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(172, 20);
            this.txtLoc.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(3, 205);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5);
            this.label5.Size = new System.Drawing.Size(107, 30);
            this.label5.TabIndex = 18;
            this.label5.Text = "Localizacao:";
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(174, 151);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(91, 20);
            this.dtpData.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(336, 183);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5);
            this.label8.Size = new System.Drawing.Size(60, 30);
            this.label8.TabIndex = 14;
            this.label8.Text = "KW/H";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(158, 185);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(172, 20);
            this.textBox5.TabIndex = 13;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(69, 21);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(148, 20);
            this.txtNome.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(3, 175);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(5);
            this.label7.Size = new System.Drawing.Size(149, 30);
            this.label7.TabIndex = 8;
            this.label7.Text = "Producao Máxima:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(3, 145);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5);
            this.label6.Size = new System.Drawing.Size(166, 30);
            this.label6.TabIndex = 7;
            this.label6.Text = "Data de Construcao:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Solar",
            "Eolica",
            "Geotermica",
            "Nuclear"});
            this.cmbTipo.Location = new System.Drawing.Point(53, 51);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(183, 21);
            this.cmbTipo.TabIndex = 5;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCapacidade);
            this.panel1.Controls.Add(this.txtMaterial);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 69);
            this.panel1.TabIndex = 4;
            // 
            // txtCapacidade
            // 
            this.txtCapacidade.Location = new System.Drawing.Point(114, 35);
            this.txtCapacidade.Name = "txtCapacidade";
            this.txtCapacidade.Size = new System.Drawing.Size(100, 20);
            this.txtCapacidade.TabIndex = 11;
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(133, 6);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(100, 20);
            this.txtMaterial.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(0, 30);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(108, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Capacidade:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(130, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Material Usado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(53, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(65, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // iconButton2
            // 
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.Location = new System.Drawing.Point(56, 18);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(75, 23);
            this.iconButton2.TabIndex = 17;
            this.iconButton2.Text = "Voltar";
            this.iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(357, 326);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(75, 23);
            this.iconButton1.TabIndex = 16;
            this.iconButton1.Text = "Inserir";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panelDesktop
            // 
            this.panelDesktop.Controls.Add(this.groupBox1);
            this.panelDesktop.Controls.Add(this.iconButton1);
            this.panelDesktop.Controls.Add(this.iconButton2);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(816, 489);
            this.panelDesktop.TabIndex = 12;
            // 
            // AddUsina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(816, 489);
            this.Controls.Add(this.panelDesktop);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddUsina";
            this.Text = "AddUsina";
            this.Load += new System.EventHandler(this.AddUsina_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDesktop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtCapacidade;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelDesktop;
    }
}