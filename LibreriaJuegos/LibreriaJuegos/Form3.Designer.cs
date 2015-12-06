using System;

namespace LibreriaJuegos
{
    partial class Form3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.TextBox();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.lblDescrip = new System.Windows.Forms.RichTextBox();
            this.lblGenero = new System.Windows.Forms.TextBox();
            this.lblGen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbAdquirir = new System.Windows.Forms.PictureBox();
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdquirir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.pbFoto);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 221);
            this.panel1.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(35)))));
            this.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Black", 13.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 33);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(245, 26);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "123456789123456789";
            this.lblTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbFoto
            // 
            this.pbFoto.Location = new System.Drawing.Point(0, 89);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(270, 126);
            this.pbFoto.TabIndex = 0;
            this.pbFoto.TabStop = false;
            // 
            // lblDescrip
            // 
            this.lblDescrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.lblDescrip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblDescrip.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrip.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDescrip.Location = new System.Drawing.Point(296, 94);
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Size = new System.Drawing.Size(280, 106);
            this.lblDescrip.TabIndex = 6;
            this.lblDescrip.Text = "12312321312312313231231231231231231231231231231231231";
            // 
            // lblGenero
            // 
            this.lblGenero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.lblGenero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblGenero.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.ForeColor = System.Drawing.Color.DarkGray;
            this.lblGenero.Location = new System.Drawing.Point(296, 36);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(146, 19);
            this.lblGenero.TabIndex = 4;
            this.lblGenero.Text = "12312312312312312312321321312";
            // 
            // lblGen
            // 
            this.lblGen.AutoSize = true;
            this.lblGen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGen.ForeColor = System.Drawing.Color.Gray;
            this.lblGen.Location = new System.Drawing.Point(293, 19);
            this.lblGen.Name = "lblGen";
            this.lblGen.Size = new System.Drawing.Size(46, 14);
            this.lblGen.TabIndex = 5;
            this.lblGen.Text = "Género:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(293, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Descripción:";
            // 
            // pbAdquirir
            // 
            this.pbAdquirir.Location = new System.Drawing.Point(585, 172);
            this.pbAdquirir.Name = "pbAdquirir";
            this.pbAdquirir.Size = new System.Drawing.Size(26, 28);
            this.pbAdquirir.TabIndex = 5;
            this.pbAdquirir.TabStop = false;
            this.pbAdquirir.Click += new System.EventHandler(this.pbAdquirir_Click);
            // 
            // pbCerrar
            // 
            this.pbCerrar.Image = global::LibreriaJuegos.Properties.Resources.cerrar1;
            this.pbCerrar.Location = new System.Drawing.Point(592, 8);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(19, 19);
            this.pbCerrar.TabIndex = 4;
            this.pbCerrar.TabStop = false;
            this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(620, 212);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGen);
            this.Controls.Add(this.lblDescrip);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.pbAdquirir);
            this.Controls.Add(this.pbCerrar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdquirir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbCerrar;
        private System.Windows.Forms.PictureBox pbAdquirir;
        private Juego juego;
        private System.Windows.Forms.TextBox lblTitulo;
        private System.Windows.Forms.RichTextBox lblDescrip;
        public System.Windows.Forms.Label lblGen;
        private System.Windows.Forms.TextBox lblGenero;
        public System.Windows.Forms.Label label1;
    }
}