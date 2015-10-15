namespace FichaPersonaje
{
    partial class FichaPersonaje
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
            this.imagPerfil = new System.Windows.Forms.PictureBox();
            this.tvNombrePJ = new System.Windows.Forms.Label();
            this.etNombrePJ = new System.Windows.Forms.TextBox();
            this.panelUno = new System.Windows.Forms.Panel();
            this.tvDescrip = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.imgDL = new System.Windows.Forms.PictureBox();
            this.imgElf = new System.Windows.Forms.PictureBox();
            this.imgDW = new System.Windows.Forms.PictureBox();
            this.imgBk = new System.Windows.Forms.PictureBox();
            this.tvClase = new System.Windows.Forms.Label();
            this.tvMapaInicio = new System.Windows.Forms.Label();
            this.tvFaccion = new System.Windows.Forms.Label();
            this.etNombreJug = new System.Windows.Forms.TextBox();
            this.tvNombreJug = new System.Windows.Forms.Label();
            this.rbVanert = new System.Windows.Forms.RadioButton();
            this.rbDuprian = new System.Windows.Forms.RadioButton();
            this.pnRBFaccion = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagPerfil)).BeginInit();
            this.panelUno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgElf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imagPerfil
            // 
            this.imagPerfil.BackColor = System.Drawing.Color.Transparent;
            this.imagPerfil.Image = global::FichaPersonaje.Properties.Resources.df;
            this.imagPerfil.Location = new System.Drawing.Point(298, 72);
            this.imagPerfil.Name = "imagPerfil";
            this.imagPerfil.Size = new System.Drawing.Size(105, 105);
            this.imagPerfil.TabIndex = 0;
            this.imagPerfil.TabStop = false;
            this.imagPerfil.WaitOnLoad = true;
            // 
            // tvNombrePJ
            // 
            this.tvNombrePJ.AutoSize = true;
            this.tvNombrePJ.Font = new System.Drawing.Font("Pristina", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvNombrePJ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvNombrePJ.Location = new System.Drawing.Point(42, 47);
            this.tvNombrePJ.Name = "tvNombrePJ";
            this.tvNombrePJ.Size = new System.Drawing.Size(89, 27);
            this.tvNombrePJ.TabIndex = 1;
            this.tvNombrePJ.Text = "Nombre PJ:";
            // 
            // etNombrePJ
            // 
            this.etNombrePJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.etNombrePJ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.etNombrePJ.Font = new System.Drawing.Font("Roboto Light", 8F);
            this.etNombrePJ.ForeColor = System.Drawing.Color.Salmon;
            this.etNombrePJ.Location = new System.Drawing.Point(47, 77);
            this.etNombrePJ.Name = "etNombrePJ";
            this.etNombrePJ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.etNombrePJ.Size = new System.Drawing.Size(201, 22);
            this.etNombrePJ.TabIndex = 11;
            this.etNombrePJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelUno
            // 
            this.panelUno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(4)))));
            this.panelUno.BackgroundImage = global::FichaPersonaje.Properties.Resources.pn;
            this.panelUno.Controls.Add(this.tvDescrip);
            this.panelUno.Controls.Add(this.comboBox1);
            this.panelUno.Controls.Add(this.imgDL);
            this.panelUno.Controls.Add(this.imgElf);
            this.panelUno.Controls.Add(this.imgDW);
            this.panelUno.Controls.Add(this.imgBk);
            this.panelUno.Controls.Add(this.tvClase);
            this.panelUno.Controls.Add(this.tvMapaInicio);
            this.panelUno.Controls.Add(this.tvFaccion);
            this.panelUno.Controls.Add(this.etNombreJug);
            this.panelUno.Controls.Add(this.tvNombreJug);
            this.panelUno.Controls.Add(this.etNombrePJ);
            this.panelUno.Controls.Add(this.rbVanert);
            this.panelUno.Controls.Add(this.rbDuprian);
            this.panelUno.Controls.Add(this.tvNombrePJ);
            this.panelUno.Controls.Add(this.pnRBFaccion);
            this.panelUno.Location = new System.Drawing.Point(29, 113);
            this.panelUno.Name = "panelUno";
            this.panelUno.Size = new System.Drawing.Size(643, 468);
            this.panelUno.TabIndex = 24;
            // 
            // tvDescrip
            // 
            this.tvDescrip.AutoSize = true;
            this.tvDescrip.Font = new System.Drawing.Font("Roboto Light", 10.25F);
            this.tvDescrip.ForeColor = System.Drawing.Color.Salmon;
            this.tvDescrip.Location = new System.Drawing.Point(144, 239);
            this.tvDescrip.Name = "tvDescrip";
            this.tvDescrip.Size = new System.Drawing.Size(46, 19);
            this.tvDescrip.TabIndex = 28;
            this.tvDescrip.Text = "label1";
            this.tvDescrip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tvDescrip.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.Font = new System.Drawing.Font("Roboto Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.Salmon;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "     Lorencia",
            "     Noria",
            "     Devias"});
            this.comboBox1.Location = new System.Drawing.Point(435, 160);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 27;
            // 
            // imgDL
            // 
            this.imgDL.Image = global::FichaPersonaje.Properties.Resources.cldldesact1;
            this.imgDL.Location = new System.Drawing.Point(477, 296);
            this.imgDL.Name = "imgDL";
            this.imgDL.Size = new System.Drawing.Size(94, 94);
            this.imgDL.TabIndex = 26;
            this.imgDL.TabStop = false;
            // 
            // imgElf
            // 
            this.imgElf.Image = global::FichaPersonaje.Properties.Resources.clelfdesact1;
            this.imgElf.Location = new System.Drawing.Point(343, 296);
            this.imgElf.Name = "imgElf";
            this.imgElf.Size = new System.Drawing.Size(94, 94);
            this.imgElf.TabIndex = 25;
            this.imgElf.TabStop = false;
            // 
            // imgDW
            // 
            this.imgDW.Image = global::FichaPersonaje.Properties.Resources.cldwdesact1;
            this.imgDW.Location = new System.Drawing.Point(211, 296);
            this.imgDW.Name = "imgDW";
            this.imgDW.Size = new System.Drawing.Size(94, 94);
            this.imgDW.TabIndex = 24;
            this.imgDW.TabStop = false;
            this.imgDW.MouseLeave += new System.EventHandler(this.imgDW_MouseLeave);
            this.imgDW.MouseHover += new System.EventHandler(this.imgDW_MouseHover);
            // 
            // imgBk
            // 
            this.imgBk.Image = global::FichaPersonaje.Properties.Resources.clbkdesact1;
            this.imgBk.Location = new System.Drawing.Point(77, 296);
            this.imgBk.Name = "imgBk";
            this.imgBk.Size = new System.Drawing.Size(94, 94);
            this.imgBk.TabIndex = 23;
            this.imgBk.TabStop = false;
            this.imgBk.MouseLeave += new System.EventHandler(this.imgBk_MouseLeave);
            this.imgBk.MouseHover += new System.EventHandler(this.imgBk_MouseHover);
            // 
            // tvClase
            // 
            this.tvClase.AutoSize = true;
            this.tvClase.Font = new System.Drawing.Font("Pristina", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvClase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvClase.Location = new System.Drawing.Point(285, 205);
            this.tvClase.Name = "tvClase";
            this.tvClase.Size = new System.Drawing.Size(66, 35);
            this.tvClase.TabIndex = 22;
            this.tvClase.Text = "Clase:";
            // 
            // tvMapaInicio
            // 
            this.tvMapaInicio.AutoSize = true;
            this.tvMapaInicio.Font = new System.Drawing.Font("Pristina", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMapaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvMapaInicio.Location = new System.Drawing.Point(429, 122);
            this.tvMapaInicio.Name = "tvMapaInicio";
            this.tvMapaInicio.Size = new System.Drawing.Size(120, 32);
            this.tvMapaInicio.TabIndex = 21;
            this.tvMapaInicio.Text = "Mapa Inicio:";
            // 
            // tvFaccion
            // 
            this.tvFaccion.AutoSize = true;
            this.tvFaccion.Font = new System.Drawing.Font("Pristina", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvFaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvFaccion.Location = new System.Drawing.Point(50, 122);
            this.tvFaccion.Name = "tvFaccion";
            this.tvFaccion.Size = new System.Drawing.Size(81, 32);
            this.tvFaccion.TabIndex = 20;
            this.tvFaccion.Text = "Facción:";
            // 
            // etNombreJug
            // 
            this.etNombreJug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.etNombreJug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.etNombreJug.Font = new System.Drawing.Font("Roboto Light", 8F);
            this.etNombreJug.ForeColor = System.Drawing.Color.Salmon;
            this.etNombreJug.Location = new System.Drawing.Point(397, 77);
            this.etNombreJug.Name = "etNombreJug";
            this.etNombreJug.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.etNombreJug.Size = new System.Drawing.Size(198, 22);
            this.etNombreJug.TabIndex = 19;
            this.etNombreJug.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tvNombreJug
            // 
            this.tvNombreJug.AutoSize = true;
            this.tvNombreJug.Font = new System.Drawing.Font("Pristina", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvNombreJug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvNombreJug.Location = new System.Drawing.Point(392, 47);
            this.tvNombreJug.Name = "tvNombreJug";
            this.tvNombreJug.Size = new System.Drawing.Size(120, 27);
            this.tvNombreJug.TabIndex = 18;
            this.tvNombreJug.Text = "Nombre Jugador:";
            // 
            // rbVanert
            // 
            this.rbVanert.AutoSize = true;
            this.rbVanert.Font = new System.Drawing.Font("Roboto Light", 10.25F);
            this.rbVanert.ForeColor = System.Drawing.Color.Salmon;
            this.rbVanert.Location = new System.Drawing.Point(148, 157);
            this.rbVanert.Name = "rbVanert";
            this.rbVanert.Size = new System.Drawing.Size(69, 23);
            this.rbVanert.TabIndex = 15;
            this.rbVanert.TabStop = true;
            this.rbVanert.Text = "Vanert";
            this.rbVanert.UseVisualStyleBackColor = true;
            // 
            // rbDuprian
            // 
            this.rbDuprian.AutoSize = true;
            this.rbDuprian.Font = new System.Drawing.Font("Roboto Light", 10.25F);
            this.rbDuprian.ForeColor = System.Drawing.Color.Salmon;
            this.rbDuprian.Location = new System.Drawing.Point(50, 157);
            this.rbDuprian.Name = "rbDuprian";
            this.rbDuprian.Size = new System.Drawing.Size(76, 23);
            this.rbDuprian.TabIndex = 14;
            this.rbDuprian.TabStop = true;
            this.rbDuprian.Text = "Duprian";
            this.rbDuprian.UseVisualStyleBackColor = true;
            // 
            // pnRBFaccion
            // 
            this.pnRBFaccion.Location = new System.Drawing.Point(50, 157);
            this.pnRBFaccion.Name = "pnRBFaccion";
            this.pnRBFaccion.Size = new System.Drawing.Size(175, 30);
            this.pnRBFaccion.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FichaPersonaje.Properties.Resources.ficha_gif;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(701, 66);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // FichaPersonaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FichaPersonaje.Properties.Resources.ficha_gif;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imagPerfil);
            this.Controls.Add(this.panelUno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(700, 600);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "FichaPersonaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FichaPersonaje";
            ((System.ComponentModel.ISupportInitialize)(this.imagPerfil)).EndInit();
            this.panelUno.ResumeLayout(false);
            this.panelUno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgElf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagPerfil;
        private System.Windows.Forms.Label tvNombrePJ;
        private System.Windows.Forms.TextBox etNombrePJ;
        private System.Windows.Forms.Panel panelUno;
        private System.Windows.Forms.RadioButton rbVanert;
        private System.Windows.Forms.RadioButton rbDuprian;
        private System.Windows.Forms.Panel pnRBFaccion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label tvMapaInicio;
        private System.Windows.Forms.Label tvFaccion;
        private System.Windows.Forms.TextBox etNombreJug;
        private System.Windows.Forms.Label tvNombreJug;
        private System.Windows.Forms.PictureBox imgDL;
        private System.Windows.Forms.PictureBox imgElf;
        private System.Windows.Forms.PictureBox imgDW;
        private System.Windows.Forms.PictureBox imgBk;
        private System.Windows.Forms.Label tvClase;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label tvDescrip;
    }
}

