namespace PowerPulse.Forms
{
    partial class Manutencao
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
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.btnDel = new FontAwesome.Sharp.IconButton();
            this.btnCanc = new FontAwesome.Sharp.IconButton();
            this.btnConf = new FontAwesome.Sharp.IconButton();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colUsina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataIni = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataFim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTipoM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipoM = new System.Windows.Forms.ComboBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.dtpDataFim = new System.Windows.Forms.DateTimePicker();
            this.dtpDataIni = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIns = new FontAwesome.Sharp.IconButton();
            this.panelDesktop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelDesktop.Controls.Add(this.btnDel);
            this.panelDesktop.Controls.Add(this.btnCanc);
            this.panelDesktop.Controls.Add(this.btnConf);
            this.panelDesktop.Controls.Add(this.btnEdit);
            this.panelDesktop.Controls.Add(this.listView1);
            this.panelDesktop.Controls.Add(this.groupBox1);
            this.panelDesktop.Controls.Add(this.btnIns);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(891, 542);
            this.panelDesktop.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDel.IconColor = System.Drawing.Color.Black;
            this.btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDel.Location = new System.Drawing.Point(416, 492);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "Eliminar";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnCanc
            // 
            this.btnCanc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCanc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCanc.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCanc.IconColor = System.Drawing.Color.Black;
            this.btnCanc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCanc.Location = new System.Drawing.Point(695, 164);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(75, 23);
            this.btnCanc.TabIndex = 5;
            this.btnCanc.Text = "Cancelar";
            this.btnCanc.UseVisualStyleBackColor = true;
            this.btnCanc.Click += new System.EventHandler(this.btnCanc_Click);
            // 
            // btnConf
            // 
            this.btnConf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConf.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnConf.IconColor = System.Drawing.Color.Black;
            this.btnConf.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConf.Location = new System.Drawing.Point(695, 98);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(75, 23);
            this.btnConf.TabIndex = 4;
            this.btnConf.Text = "Confirmar";
            this.btnConf.UseVisualStyleBackColor = true;
            this.btnConf.Click += new System.EventHandler(this.btnConf_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEdit.IconColor = System.Drawing.Color.Black;
            this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEdit.Location = new System.Drawing.Point(695, 33);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUsina,
            this.colDataIni,
            this.colDataFim,
            this.colTipoM,
            this.colCost,
            this.colDesc});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(29, 218);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(834, 268);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // colUsina
            // 
            this.colUsina.Text = "Usina";
            // 
            // colDataIni
            // 
            this.colDataIni.Text = "Data Inicio";
            this.colDataIni.Width = 71;
            // 
            // colDataFim
            // 
            this.colDataFim.Text = "Data Fim";
            this.colDataFim.Width = 63;
            // 
            // colTipoM
            // 
            this.colTipoM.Text = "Tipo de Manutenção";
            this.colTipoM.Width = 118;
            // 
            // colCost
            // 
            this.colCost.Text = "Custo de Manutenção";
            this.colCost.Width = 117;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Descrição";
            this.colDesc.Width = 340;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbTipoM);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.dtpDataFim);
            this.groupBox1.Controls.Add(this.dtpDataIni);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(196, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 189);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(418, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "€";
            // 
            // cmbTipoM
            // 
            this.cmbTipoM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbTipoM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbTipoM.ForeColor = System.Drawing.Color.White;
            this.cmbTipoM.FormattingEnabled = true;
            this.cmbTipoM.Items.AddRange(new object[] {
            "Simples",
            "Completa",
            "Limpeza"});
            this.cmbTipoM.Location = new System.Drawing.Point(170, 102);
            this.cmbTipoM.Name = "cmbTipoM";
            this.cmbTipoM.Size = new System.Drawing.Size(266, 24);
            this.cmbTipoM.TabIndex = 7;
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCost.ForeColor = System.Drawing.Color.White;
            this.txtCost.Location = new System.Drawing.Point(182, 153);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(230, 19);
            this.txtCost.TabIndex = 6;
            this.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpDataFim
            // 
            this.dtpDataFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFim.Location = new System.Drawing.Point(90, 59);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(116, 23);
            this.dtpDataFim.TabIndex = 5;
            // 
            // dtpDataIni
            // 
            this.dtpDataIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpDataIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataIni.Location = new System.Drawing.Point(101, 19);
            this.dtpDataIni.Name = "dtpDataIni";
            this.dtpDataIni.Size = new System.Drawing.Size(105, 23);
            this.dtpDataIni.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(6, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Custo de Manutenção:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Manutenção:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Fim:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Inicio:";
            // 
            // btnIns
            // 
            this.btnIns.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIns.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnIns.IconColor = System.Drawing.Color.Black;
            this.btnIns.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIns.Location = new System.Drawing.Point(29, 30);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(75, 23);
            this.btnIns.TabIndex = 0;
            this.btnIns.Text = "Inserir";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // Manutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(891, 542);
            this.Controls.Add(this.panelDesktop);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Manutencao";
            this.Text = "Manutencao";
            this.Load += new System.EventHandler(this.Manutencao_Load);
            this.panelDesktop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnCanc;
        private FontAwesome.Sharp.IconButton btnConf;
        private FontAwesome.Sharp.IconButton btnEdit;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnIns;
        private System.Windows.Forms.ColumnHeader colUsina;
        private System.Windows.Forms.ColumnHeader colDataIni;
        private System.Windows.Forms.ColumnHeader colDataFim;
        private System.Windows.Forms.ColumnHeader colTipoM;
        private System.Windows.Forms.ColumnHeader colCost;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.DateTimePicker dtpDataFim;
        private System.Windows.Forms.DateTimePicker dtpDataIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoM;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label5;
    }
}