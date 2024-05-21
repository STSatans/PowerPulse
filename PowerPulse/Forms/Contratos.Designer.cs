namespace PowerPulse.Forms
{
    partial class Contratos
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodP2 = new System.Windows.Forms.TextBox();
            this.txtCodP1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNIF = new System.Windows.Forms.ComboBox();
            this.txtMoradaCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbPot = new System.Windows.Forms.ComboBox();
            this.cmbMet = new System.Windows.Forms.ComboBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtMoradaCont = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(33, 245);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 191);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nr.Contrato";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "NIF";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nome";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Telefone";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Morada";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Potencia";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Metodo Pagamento";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtCodP2);
            this.panel1.Controls.Add(this.txtCodP1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbNIF);
            this.panel1.Controls.Add(this.txtMoradaCliente);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtContato);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(36, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 204);
            this.panel1.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(165, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "-";
            // 
            // txtCodP2
            // 
            this.txtCodP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCodP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCodP2.ForeColor = System.Drawing.Color.White;
            this.txtCodP2.Location = new System.Drawing.Point(185, 165);
            this.txtCodP2.Name = "txtCodP2";
            this.txtCodP2.Size = new System.Drawing.Size(45, 23);
            this.txtCodP2.TabIndex = 20;
            this.txtCodP2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodP2_KeyPress);
            // 
            // txtCodP1
            // 
            this.txtCodP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCodP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCodP1.ForeColor = System.Drawing.Color.White;
            this.txtCodP1.Location = new System.Drawing.Point(114, 165);
            this.txtCodP1.Name = "txtCodP1";
            this.txtCodP1.Size = new System.Drawing.Size(45, 23);
            this.txtCodP1.TabIndex = 19;
            this.txtCodP1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodP1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(3, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Codigo Postal:";
            // 
            // cmbNIF
            // 
            this.cmbNIF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbNIF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNIF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNIF.ForeColor = System.Drawing.Color.White;
            this.cmbNIF.FormattingEnabled = true;
            this.cmbNIF.Location = new System.Drawing.Point(48, 26);
            this.cmbNIF.Name = "cmbNIF";
            this.cmbNIF.Size = new System.Drawing.Size(141, 21);
            this.cmbNIF.TabIndex = 17;
            this.cmbNIF.SelectedIndexChanged += new System.EventHandler(this.cmbNIF_SelectedIndexChanged);
            // 
            // txtMoradaCliente
            // 
            this.txtMoradaCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtMoradaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMoradaCliente.ForeColor = System.Drawing.Color.White;
            this.txtMoradaCliente.Location = new System.Drawing.Point(93, 134);
            this.txtMoradaCliente.Name = "txtMoradaCliente";
            this.txtMoradaCliente.Size = new System.Drawing.Size(235, 23);
            this.txtMoradaCliente.TabIndex = 8;
            this.txtMoradaCliente.TextChanged += new System.EventHandler(this.txtMoradaCliente_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(3, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "NIF:";
            // 
            // txtContato
            // 
            this.txtContato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtContato.ForeColor = System.Drawing.Color.White;
            this.txtContato.Location = new System.Drawing.Point(87, 93);
            this.txtContato.MaxLength = 9;
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(123, 23);
            this.txtContato.TabIndex = 7;
            this.txtContato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContato_KeyPress);
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtNome.ForeColor = System.Drawing.Color.White;
            this.txtNome.Location = new System.Drawing.Point(61, 60);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(267, 23);
            this.txtNome.TabIndex = 6;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(127, -4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(3, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enderenço:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(3, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contacto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.cmbPot);
            this.panel2.Controls.Add(this.cmbMet);
            this.panel2.Controls.Add(this.txtTel);
            this.panel2.Controls.Add(this.txtMoradaCont);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(484, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 204);
            this.panel2.TabIndex = 2;
            // 
            // cmbPot
            // 
            this.cmbPot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbPot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPot.ForeColor = System.Drawing.Color.White;
            this.cmbPot.FormattingEnabled = true;
            this.cmbPot.Items.AddRange(new object[] {
            "1.15",
            "2.3",
            "3.45",
            "4.6",
            "5.75",
            "6.9",
            "10.35",
            "13.8",
            "17.25",
            "20.7"});
            this.cmbPot.Location = new System.Drawing.Point(164, 153);
            this.cmbPot.Name = "cmbPot";
            this.cmbPot.Size = new System.Drawing.Size(121, 21);
            this.cmbPot.TabIndex = 19;
            this.cmbPot.SelectedIndexChanged += new System.EventHandler(this.cmbPot_SelectedIndexChanged);
            // 
            // cmbMet
            // 
            this.cmbMet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbMet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMet.ForeColor = System.Drawing.Color.White;
            this.cmbMet.FormattingEnabled = true;
            this.cmbMet.Items.AddRange(new object[] {
            "Debito Direto",
            "Bi-Mestral",
            "Tri-Mestral"});
            this.cmbMet.Location = new System.Drawing.Point(184, 111);
            this.cmbMet.Name = "cmbMet";
            this.cmbMet.Size = new System.Drawing.Size(101, 21);
            this.cmbMet.TabIndex = 18;
            this.cmbMet.SelectedIndexChanged += new System.EventHandler(this.cmbMet_SelectedIndexChanged);
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTel.ForeColor = System.Drawing.Color.White;
            this.txtTel.Location = new System.Drawing.Point(84, 68);
            this.txtTel.MaxLength = 9;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(125, 23);
            this.txtTel.TabIndex = 13;
            this.txtTel.TextChanged += new System.EventHandler(this.txtTel_TextChanged);
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // txtMoradaCont
            // 
            this.txtMoradaCont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtMoradaCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMoradaCont.ForeColor = System.Drawing.Color.White;
            this.txtMoradaCont.Location = new System.Drawing.Point(76, 31);
            this.txtMoradaCont.Name = "txtMoradaCont";
            this.txtMoradaCont.Size = new System.Drawing.Size(209, 23);
            this.txtMoradaCont.TabIndex = 12;
            this.txtMoradaCont.TextChanged += new System.EventHandler(this.txtMoradaCont_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(3, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Potencia Contratada:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(122, -4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Contrato";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(3, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Método de Pagamento:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(3, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "Telefone:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(3, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Morada:";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Location = new System.Drawing.Point(367, 442);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(133, 23);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "Eliminar";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(393, 95);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(393, 122);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Atualizar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(393, 149);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnIns
            // 
            this.btnIns.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIns.Location = new System.Drawing.Point(393, 45);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(75, 23);
            this.btnIns.TabIndex = 7;
            this.btnIns.Text = "Inserir";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(393, 214);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Contratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(846, 477);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnIns);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Contratos";
            this.Text = "Contratos";
            this.Load += new System.EventHandler(this.Contratos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.TextBox txtMoradaCliente;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtMoradaCont;
        private System.Windows.Forms.ComboBox cmbNIF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMet;
        private System.Windows.Forms.TextBox txtCodP1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCodP2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbPot;
    }
}