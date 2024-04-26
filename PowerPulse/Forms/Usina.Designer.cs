namespace PowerPulse.Forms
{
    partial class Usina
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usina));
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ImgSm = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblManutencao = new System.Windows.Forms.Label();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.txtCapMat = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGasto = new System.Windows.Forms.Label();
            this.lblMatUs = new System.Windows.Forms.Label();
            this.lblProdM = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.imgUsina = new System.Windows.Forms.PictureBox();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.btnDel = new FontAwesome.Sharp.IconButton();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.panelDesktop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgUsina)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDesktop.Controls.Add(this.listView1);
            this.panelDesktop.Controls.Add(this.panel2);
            this.panelDesktop.Controls.Add(this.panel1);
            this.panelDesktop.Controls.Add(this.btnUpdate);
            this.panelDesktop.Controls.Add(this.btnCancel);
            this.panelDesktop.Controls.Add(this.btnEditar);
            this.panelDesktop.Controls.Add(this.imgUsina);
            this.panelDesktop.Controls.Add(this.btnAdd);
            this.panelDesktop.Controls.Add(this.btnDel);
            this.panelDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(800, 450);
            this.panelDesktop.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.ImgSm;
            this.listView1.Location = new System.Drawing.Point(12, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(355, 406);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ImgSm
            // 
            this.ImgSm.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgSm.ImageStream")));
            this.ImgSm.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgSm.Images.SetKeyName(0, "solar-cell.png");
            this.ImgSm.Images.SetKeyName(1, "eolic-energy.png");
            this.ImgSm.Images.SetKeyName(2, "fossil-fuel.png");
            this.ImgSm.Images.SetKeyName(3, "geothermal.png");
            this.ImgSm.Images.SetKeyName(4, "nuclear-plant.png");
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.lblManutencao);
            this.panel2.Controls.Add(this.dtpData);
            this.panel2.Controls.Add(this.txtLoc);
            this.panel2.Controls.Add(this.txtCapMat);
            this.panel2.Controls.Add(this.txtNome);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(373, 183);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 226);
            this.panel2.TabIndex = 8;
            // 
            // lblManutencao
            // 
            this.lblManutencao.AutoSize = true;
            this.lblManutencao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblManutencao.ForeColor = System.Drawing.Color.White;
            this.lblManutencao.Location = new System.Drawing.Point(150, 193);
            this.lblManutencao.Name = "lblManutencao";
            this.lblManutencao.Size = new System.Drawing.Size(137, 20);
            this.lblManutencao.TabIndex = 14;
            this.lblManutencao.Text = "Data Manutencao";
            // 
            // txtLoc
            // 
            this.txtLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtLoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtLoc.ForeColor = System.Drawing.Color.White;
            this.txtLoc.Location = new System.Drawing.Point(106, 101);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(309, 19);
            this.txtLoc.TabIndex = 10;
            // 
            // txtCapMat
            // 
            this.txtCapMat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCapMat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCapMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCapMat.ForeColor = System.Drawing.Color.White;
            this.txtCapMat.Location = new System.Drawing.Point(163, 58);
            this.txtCapMat.Name = "txtCapMat";
            this.txtCapMat.Size = new System.Drawing.Size(195, 19);
            this.txtCapMat.TabIndex = 9;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNome.ForeColor = System.Drawing.Color.White;
            this.txtNome.Location = new System.Drawing.Point(58, 13);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(357, 19);
            this.txtNome.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Prox. Manutencao:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Data De Construção";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Localizacao:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Capacidade Material";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Nome:";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.lblGasto);
            this.panel1.Controls.Add(this.lblMatUs);
            this.panel1.Controls.Add(this.lblProdM);
            this.panel1.Controls.Add(this.lblTipo);
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(476, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 174);
            this.panel1.TabIndex = 7;
            // 
            // lblGasto
            // 
            this.lblGasto.AutoSize = true;
            this.lblGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGasto.ForeColor = System.Drawing.Color.White;
            this.lblGasto.Location = new System.Drawing.Point(66, 140);
            this.lblGasto.Name = "lblGasto";
            this.lblGasto.Size = new System.Drawing.Size(53, 20);
            this.lblGasto.TabIndex = 9;
            this.lblGasto.Text = "Gasto";
            // 
            // lblMatUs
            // 
            this.lblMatUs.AutoSize = true;
            this.lblMatUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMatUs.ForeColor = System.Drawing.Color.White;
            this.lblMatUs.Location = new System.Drawing.Point(127, 108);
            this.lblMatUs.Name = "lblMatUs";
            this.lblMatUs.Size = new System.Drawing.Size(112, 20);
            this.lblMatUs.TabIndex = 8;
            this.lblMatUs.Text = "MaterialUsado";
            // 
            // lblProdM
            // 
            this.lblProdM.AutoSize = true;
            this.lblProdM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProdM.ForeColor = System.Drawing.Color.White;
            this.lblProdM.Location = new System.Drawing.Point(127, 76);
            this.lblProdM.Name = "lblProdM";
            this.lblProdM.Size = new System.Drawing.Size(110, 20);
            this.lblProdM.TabIndex = 7;
            this.lblProdM.Text = "Producao Max";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTipo.ForeColor = System.Drawing.Color.White;
            this.lblTipo.Location = new System.Drawing.Point(52, 46);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(39, 20);
            this.lblTipo.TabIndex = 6;
            this.lblTipo.Text = "Tipo";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(73, 16);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(60, 20);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Estado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Material Usado:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gasto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Produção Max.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estado:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnUpdate.IconColor = System.Drawing.Color.Black;
            this.btnUpdate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUpdate.Location = new System.Drawing.Point(373, 154);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCancel.IconColor = System.Drawing.Color.Black;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.Location = new System.Drawing.Point(373, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEditar.IconColor = System.Drawing.Color.Black;
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.Location = new System.Drawing.Point(373, 96);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(97, 23);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // imgUsina
            // 
            this.imgUsina.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgUsina.Location = new System.Drawing.Point(373, 3);
            this.imgUsina.Name = "imgUsina";
            this.imgUsina.Size = new System.Drawing.Size(97, 87);
            this.imgUsina.TabIndex = 3;
            this.imgUsina.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAdd.IconColor = System.Drawing.Color.Black;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.Location = new System.Drawing.Point(292, 415);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDel.IconColor = System.Drawing.Color.Black;
            this.btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDel.Location = new System.Drawing.Point(12, 415);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dtpData
            // 
            this.dtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(163, 144);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(120, 26);
            this.dtpData.TabIndex = 13;
            // 
            // Usina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDesktop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Usina";
            this.Text = "Usina";
            this.Load += new System.EventHandler(this.Usina_Load);
            this.panelDesktop.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgUsina)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnDel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnUpdate;
        private FontAwesome.Sharp.IconButton btnCancel;
        private FontAwesome.Sharp.IconButton btnEditar;
        private System.Windows.Forms.PictureBox imgUsina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.TextBox txtCapMat;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblGasto;
        private System.Windows.Forms.Label lblMatUs;
        private System.Windows.Forms.Label lblProdM;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblManutencao;
        private System.Windows.Forms.ImageList ImgSm;
        private System.Windows.Forms.DateTimePicker dtpData;
    }
}