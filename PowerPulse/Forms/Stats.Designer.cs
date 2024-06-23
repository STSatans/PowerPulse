namespace PowerPulse.Forms
{
    partial class Stats
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
            this.lblClientes = new System.Windows.Forms.Label();
            this.lblContratos = new System.Windows.Forms.Label();
            this.lblligadas = new System.Windows.Forms.Label();
            this.lblUsinas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.Controls.Add(this.lblClientes);
            this.panelDesktop.Controls.Add(this.lblContratos);
            this.panelDesktop.Controls.Add(this.lblligadas);
            this.panelDesktop.Controls.Add(this.lblUsinas);
            this.panelDesktop.Controls.Add(this.label4);
            this.panelDesktop.Controls.Add(this.label3);
            this.panelDesktop.Controls.Add(this.label2);
            this.panelDesktop.Controls.Add(this.label1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(891, 557);
            this.panelDesktop.TabIndex = 0;
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // lblClientes
            // 
            this.lblClientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblClientes.AutoSize = true;
            this.lblClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblClientes.Location = new System.Drawing.Point(653, 142);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(64, 25);
            this.lblClientes.TabIndex = 7;
            this.lblClientes.Text = "label8";
            // 
            // lblContratos
            // 
            this.lblContratos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContratos.AutoSize = true;
            this.lblContratos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblContratos.Location = new System.Drawing.Point(483, 142);
            this.lblContratos.Name = "lblContratos";
            this.lblContratos.Size = new System.Drawing.Size(64, 25);
            this.lblContratos.TabIndex = 6;
            this.lblContratos.Text = "label7";
            // 
            // lblligadas
            // 
            this.lblligadas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblligadas.AutoSize = true;
            this.lblligadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblligadas.Location = new System.Drawing.Point(318, 142);
            this.lblligadas.Name = "lblligadas";
            this.lblligadas.Size = new System.Drawing.Size(64, 25);
            this.lblligadas.TabIndex = 5;
            this.lblligadas.Text = "label6";
            // 
            // lblUsinas
            // 
            this.lblUsinas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsinas.AutoSize = true;
            this.lblUsinas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblUsinas.Location = new System.Drawing.Point(131, 142);
            this.lblUsinas.Name = "lblUsinas";
            this.lblUsinas.Size = new System.Drawing.Size(64, 25);
            this.lblUsinas.TabIndex = 4;
            this.lblUsinas.Text = "label5";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(628, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nr. clientes";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(454, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nr. Contratos";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(280, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usinas Ligadas";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(80, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Usinas";
            // 
            // Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(891, 557);
            this.Controls.Add(this.panelDesktop);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stats";
            this.Text = "Stats";
            this.Load += new System.EventHandler(this.Stats_Load);
            this.panelDesktop.ResumeLayout(false);
            this.panelDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblContratos;
        private System.Windows.Forms.Label lblligadas;
        private System.Windows.Forms.Label lblUsinas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}