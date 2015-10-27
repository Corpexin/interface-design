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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FichaPersonaje));
            this.imagPerfil = new System.Windows.Forms.PictureBox();
            this.tvNombrePJ = new System.Windows.Forms.Label();
            this.etNombrePJ = new System.Windows.Forms.TextBox();
            this.panelUno = new System.Windows.Forms.Panel();
            this.panelDos = new System.Windows.Forms.Panel();
            this.tvError = new System.Windows.Forms.Label();
            this.PBEnergia = new System.Windows.Forms.ProgressBar();
            this.PBVitalidad = new System.Windows.Forms.ProgressBar();
            this.PBAgilidad = new System.Windows.Forms.ProgressBar();
            this.PBFuerza = new System.Windows.Forms.ProgressBar();
            this.UDEnergia = new System.Windows.Forms.DomainUpDown();
            this.tvEnergia = new System.Windows.Forms.Label();
            this.UDVitalidad = new System.Windows.Forms.DomainUpDown();
            this.etVitalidad = new System.Windows.Forms.Label();
            this.UDAgilidad = new System.Windows.Forms.DomainUpDown();
            this.tvAgilidad = new System.Windows.Forms.Label();
            this.UDFuerza = new System.Windows.Forms.DomainUpDown();
            this.tvFuerza = new System.Windows.Forms.Label();
            this.tvContadorPuntos = new System.Windows.Forms.Label();
            this.tvPuntos = new System.Windows.Forms.Label();
            this.tvDarkLord = new System.Windows.Forms.Label();
            this.tvElf = new System.Windows.Forms.Label();
            this.tvSoulWizard = new System.Windows.Forms.Label();
            this.tvBladeKnight = new System.Windows.Forms.Label();
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
            this.separadorIzq = new System.Windows.Forms.PictureBox();
            this.separadorDer = new System.Windows.Forms.PictureBox();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagPerfil)).BeginInit();
            this.panelUno.SuspendLayout();
            this.panelDos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgElf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separadorIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separadorDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imagPerfil
            // 
            resources.ApplyResources(this.imagPerfil, "imagPerfil");
            this.imagPerfil.BackColor = System.Drawing.Color.Transparent;
            this.imagPerfil.Image = global::FichaPersonaje.Properties.Resources.df;
            this.imagPerfil.Name = "imagPerfil";
            this.imagPerfil.TabStop = false;
            // 
            // tvNombrePJ
            // 
            resources.ApplyResources(this.tvNombrePJ, "tvNombrePJ");
            this.tvNombrePJ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvNombrePJ.Name = "tvNombrePJ";
            // 
            // etNombrePJ
            // 
            resources.ApplyResources(this.etNombrePJ, "etNombrePJ");
            this.etNombrePJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.etNombrePJ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.etNombrePJ.ForeColor = System.Drawing.Color.Salmon;
            this.etNombrePJ.Name = "etNombrePJ";
            // 
            // panelUno
            // 
            resources.ApplyResources(this.panelUno, "panelUno");
            this.panelUno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(4)))));
            this.panelUno.BackgroundImage = global::FichaPersonaje.Properties.Resources.pn;
            this.panelUno.Controls.Add(this.panelDos);
            this.panelUno.Controls.Add(this.tvDarkLord);
            this.panelUno.Controls.Add(this.tvElf);
            this.panelUno.Controls.Add(this.tvSoulWizard);
            this.panelUno.Controls.Add(this.tvBladeKnight);
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
            this.panelUno.Controls.Add(this.separadorIzq);
            this.panelUno.Controls.Add(this.separadorDer);
            this.panelUno.Name = "panelUno";
            // 
            // panelDos
            // 
            resources.ApplyResources(this.panelDos, "panelDos");
            this.panelDos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(4)))));
            this.panelDos.BackgroundImage = global::FichaPersonaje.Properties.Resources.pn;
            this.panelDos.Controls.Add(this.tvError);
            this.panelDos.Controls.Add(this.PBEnergia);
            this.panelDos.Controls.Add(this.PBVitalidad);
            this.panelDos.Controls.Add(this.PBAgilidad);
            this.panelDos.Controls.Add(this.PBFuerza);
            this.panelDos.Controls.Add(this.UDEnergia);
            this.panelDos.Controls.Add(this.tvEnergia);
            this.panelDos.Controls.Add(this.UDVitalidad);
            this.panelDos.Controls.Add(this.etVitalidad);
            this.panelDos.Controls.Add(this.UDAgilidad);
            this.panelDos.Controls.Add(this.tvAgilidad);
            this.panelDos.Controls.Add(this.UDFuerza);
            this.panelDos.Controls.Add(this.tvFuerza);
            this.panelDos.Controls.Add(this.tvContadorPuntos);
            this.panelDos.Controls.Add(this.tvPuntos);
            this.panelDos.Name = "panelDos";
            // 
            // tvError
            // 
            resources.ApplyResources(this.tvError, "tvError");
            this.tvError.ForeColor = System.Drawing.Color.Red;
            this.tvError.Name = "tvError";
            // 
            // PBEnergia
            // 
            resources.ApplyResources(this.PBEnergia, "PBEnergia");
            this.PBEnergia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.PBEnergia.Maximum = 5000;
            this.PBEnergia.Name = "PBEnergia";
            // 
            // PBVitalidad
            // 
            resources.ApplyResources(this.PBVitalidad, "PBVitalidad");
            this.PBVitalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.PBVitalidad.Maximum = 5000;
            this.PBVitalidad.Name = "PBVitalidad";
            // 
            // PBAgilidad
            // 
            resources.ApplyResources(this.PBAgilidad, "PBAgilidad");
            this.PBAgilidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.PBAgilidad.Maximum = 5000;
            this.PBAgilidad.Name = "PBAgilidad";
            // 
            // PBFuerza
            // 
            resources.ApplyResources(this.PBFuerza, "PBFuerza");
            this.PBFuerza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.PBFuerza.Maximum = 5000;
            this.PBFuerza.Name = "PBFuerza";
            // 
            // UDEnergia
            // 
            resources.ApplyResources(this.UDEnergia, "UDEnergia");
            this.UDEnergia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.UDEnergia.ForeColor = System.Drawing.Color.Salmon;
            this.UDEnergia.Name = "UDEnergia";
            this.UDEnergia.SelectedItemChanged += new System.EventHandler(this.UDEnergia_SelectedItemChanged);
            // 
            // tvEnergia
            // 
            resources.ApplyResources(this.tvEnergia, "tvEnergia");
            this.tvEnergia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvEnergia.Name = "tvEnergia";
            // 
            // UDVitalidad
            // 
            resources.ApplyResources(this.UDVitalidad, "UDVitalidad");
            this.UDVitalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.UDVitalidad.ForeColor = System.Drawing.Color.Salmon;
            this.UDVitalidad.Name = "UDVitalidad";
            this.UDVitalidad.SelectedItemChanged += new System.EventHandler(this.UDVitalidad_SelectedItemChanged);
            // 
            // etVitalidad
            // 
            resources.ApplyResources(this.etVitalidad, "etVitalidad");
            this.etVitalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.etVitalidad.Name = "etVitalidad";
            // 
            // UDAgilidad
            // 
            resources.ApplyResources(this.UDAgilidad, "UDAgilidad");
            this.UDAgilidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.UDAgilidad.ForeColor = System.Drawing.Color.Salmon;
            this.UDAgilidad.Name = "UDAgilidad";
            this.UDAgilidad.SelectedItemChanged += new System.EventHandler(this.UDAgilidad_SelectedItemChanged);
            // 
            // tvAgilidad
            // 
            resources.ApplyResources(this.tvAgilidad, "tvAgilidad");
            this.tvAgilidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvAgilidad.Name = "tvAgilidad";
            // 
            // UDFuerza
            // 
            resources.ApplyResources(this.UDFuerza, "UDFuerza");
            this.UDFuerza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.UDFuerza.ForeColor = System.Drawing.Color.Salmon;
            this.UDFuerza.Name = "UDFuerza";
            this.UDFuerza.SelectedItemChanged += new System.EventHandler(this.UDFuerza_SelectedItemChanged);
            // 
            // tvFuerza
            // 
            resources.ApplyResources(this.tvFuerza, "tvFuerza");
            this.tvFuerza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvFuerza.Name = "tvFuerza";
            // 
            // tvContadorPuntos
            // 
            resources.ApplyResources(this.tvContadorPuntos, "tvContadorPuntos");
            this.tvContadorPuntos.ForeColor = System.Drawing.Color.Salmon;
            this.tvContadorPuntos.Name = "tvContadorPuntos";
            // 
            // tvPuntos
            // 
            resources.ApplyResources(this.tvPuntos, "tvPuntos");
            this.tvPuntos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvPuntos.Name = "tvPuntos";
            // 
            // tvDarkLord
            // 
            resources.ApplyResources(this.tvDarkLord, "tvDarkLord");
            this.tvDarkLord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvDarkLord.Name = "tvDarkLord";
            // 
            // tvElf
            // 
            resources.ApplyResources(this.tvElf, "tvElf");
            this.tvElf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvElf.Name = "tvElf";
            // 
            // tvSoulWizard
            // 
            resources.ApplyResources(this.tvSoulWizard, "tvSoulWizard");
            this.tvSoulWizard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvSoulWizard.Name = "tvSoulWizard";
            // 
            // tvBladeKnight
            // 
            resources.ApplyResources(this.tvBladeKnight, "tvBladeKnight");
            this.tvBladeKnight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvBladeKnight.Name = "tvBladeKnight";
            // 
            // tvDescrip
            // 
            resources.ApplyResources(this.tvDescrip, "tvDescrip");
            this.tvDescrip.ForeColor = System.Drawing.Color.Salmon;
            this.tvDescrip.Name = "tvDescrip";
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.comboBox1.ForeColor = System.Drawing.Color.Salmon;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2")});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // imgDL
            // 
            resources.ApplyResources(this.imgDL, "imgDL");
            this.imgDL.Image = global::FichaPersonaje.Properties.Resources.cldldesact1;
            this.imgDL.Name = "imgDL";
            this.imgDL.TabStop = false;
            this.imgDL.Click += new System.EventHandler(this.imgDL_Click);
            this.imgDL.MouseLeave += new System.EventHandler(this.imgDL_MouseLeave);
            this.imgDL.MouseHover += new System.EventHandler(this.imgDL_MouseHover);
            // 
            // imgElf
            // 
            resources.ApplyResources(this.imgElf, "imgElf");
            this.imgElf.Image = global::FichaPersonaje.Properties.Resources.clelfdesact1;
            this.imgElf.Name = "imgElf";
            this.imgElf.TabStop = false;
            this.imgElf.Click += new System.EventHandler(this.imgElf_Click);
            this.imgElf.MouseLeave += new System.EventHandler(this.imgElf_MouseLeave);
            this.imgElf.MouseHover += new System.EventHandler(this.imgElf_MouseHover);
            // 
            // imgDW
            // 
            resources.ApplyResources(this.imgDW, "imgDW");
            this.imgDW.Image = global::FichaPersonaje.Properties.Resources.cldwdesact1;
            this.imgDW.Name = "imgDW";
            this.imgDW.TabStop = false;
            this.imgDW.Click += new System.EventHandler(this.imgDW_Click);
            this.imgDW.MouseLeave += new System.EventHandler(this.imgDW_MouseLeave);
            this.imgDW.MouseHover += new System.EventHandler(this.imgDW_MouseHover);
            // 
            // imgBk
            // 
            resources.ApplyResources(this.imgBk, "imgBk");
            this.imgBk.Image = global::FichaPersonaje.Properties.Resources.clbkdesact1;
            this.imgBk.Name = "imgBk";
            this.imgBk.TabStop = false;
            this.imgBk.Click += new System.EventHandler(this.imgBk_Click);
            this.imgBk.MouseLeave += new System.EventHandler(this.imgBk_MouseLeave);
            this.imgBk.MouseHover += new System.EventHandler(this.imgBk_MouseHover);
            // 
            // tvClase
            // 
            resources.ApplyResources(this.tvClase, "tvClase");
            this.tvClase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvClase.Name = "tvClase";
            // 
            // tvMapaInicio
            // 
            resources.ApplyResources(this.tvMapaInicio, "tvMapaInicio");
            this.tvMapaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvMapaInicio.Name = "tvMapaInicio";
            // 
            // tvFaccion
            // 
            resources.ApplyResources(this.tvFaccion, "tvFaccion");
            this.tvFaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvFaccion.Name = "tvFaccion";
            // 
            // etNombreJug
            // 
            resources.ApplyResources(this.etNombreJug, "etNombreJug");
            this.etNombreJug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(12)))), ((int)(((byte)(13)))));
            this.etNombreJug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.etNombreJug.ForeColor = System.Drawing.Color.Salmon;
            this.etNombreJug.Name = "etNombreJug";
            // 
            // tvNombreJug
            // 
            resources.ApplyResources(this.tvNombreJug, "tvNombreJug");
            this.tvNombreJug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.tvNombreJug.Name = "tvNombreJug";
            // 
            // rbVanert
            // 
            resources.ApplyResources(this.rbVanert, "rbVanert");
            this.rbVanert.ForeColor = System.Drawing.Color.Salmon;
            this.rbVanert.Name = "rbVanert";
            this.rbVanert.TabStop = true;
            this.rbVanert.UseVisualStyleBackColor = true;
            // 
            // rbDuprian
            // 
            resources.ApplyResources(this.rbDuprian, "rbDuprian");
            this.rbDuprian.ForeColor = System.Drawing.Color.Salmon;
            this.rbDuprian.Name = "rbDuprian";
            this.rbDuprian.TabStop = true;
            this.rbDuprian.UseVisualStyleBackColor = true;
            // 
            // pnRBFaccion
            // 
            resources.ApplyResources(this.pnRBFaccion, "pnRBFaccion");
            this.pnRBFaccion.Name = "pnRBFaccion";
            // 
            // separadorIzq
            // 
            resources.ApplyResources(this.separadorIzq, "separadorIzq");
            this.separadorIzq.Image = global::FichaPersonaje.Properties.Resources.separadorIzq;
            this.separadorIzq.Name = "separadorIzq";
            this.separadorIzq.TabStop = false;
            // 
            // separadorDer
            // 
            resources.ApplyResources(this.separadorDer, "separadorDer");
            this.separadorDer.Image = global::FichaPersonaje.Properties.Resources.separadorDer;
            this.separadorDer.Name = "separadorDer";
            this.separadorDer.TabStop = false;
            // 
            // btn3
            // 
            resources.ApplyResources(this.btn3, "btn3");
            this.btn3.BackColor = System.Drawing.Color.Transparent;
            this.btn3.FlatAppearance.BorderSize = 0;
            this.btn3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn3.Image = global::FichaPersonaje.Properties.Resources.btnDesact1;
            this.btn3.Name = "btn3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            this.btn3.MouseLeave += new System.EventHandler(this.btn3_MouseLeave);
            this.btn3.MouseHover += new System.EventHandler(this.btn3_MouseHover);
            // 
            // btn2
            // 
            resources.ApplyResources(this.btn2, "btn2");
            this.btn2.BackColor = System.Drawing.Color.Transparent;
            this.btn2.FlatAppearance.BorderSize = 0;
            this.btn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn2.Image = global::FichaPersonaje.Properties.Resources.btnDesact1;
            this.btn2.Name = "btn2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            this.btn2.MouseLeave += new System.EventHandler(this.btn2_MouseLeave);
            this.btn2.MouseHover += new System.EventHandler(this.btn2_MouseHover);
            // 
            // btn1
            // 
            resources.ApplyResources(this.btn1, "btn1");
            this.btn1.BackColor = System.Drawing.Color.Transparent;
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn1.Image = global::FichaPersonaje.Properties.Resources.btnAct1;
            this.btn1.Name = "btn1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            this.btn1.MouseLeave += new System.EventHandler(this.btn1_MouseLeave);
            this.btn1.MouseHover += new System.EventHandler(this.btn1_MouseHover);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::FichaPersonaje.Properties.Resources.fichagif;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // FichaPersonaje
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FichaPersonaje.Properties.Resources.fichagif;
            this.CausesValidation = false;
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.imagPerfil);
            this.Controls.Add(this.panelUno);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FichaPersonaje";
            ((System.ComponentModel.ISupportInitialize)(this.imagPerfil)).EndInit();
            this.panelUno.ResumeLayout(false);
            this.panelUno.PerformLayout();
            this.panelDos.ResumeLayout(false);
            this.panelDos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgElf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separadorIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separadorDer)).EndInit();
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
        private System.Windows.Forms.Label tvDarkLord;
        private System.Windows.Forms.Label tvElf;
        private System.Windows.Forms.Label tvSoulWizard;
        private System.Windows.Forms.Label tvBladeKnight;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Panel panelDos;
        private System.Windows.Forms.PictureBox separadorIzq;
        private System.Windows.Forms.PictureBox separadorDer;
        private System.Windows.Forms.Label tvContadorPuntos;
        private System.Windows.Forms.Label tvPuntos;
        private System.Windows.Forms.DomainUpDown UDFuerza;
        private System.Windows.Forms.Label tvFuerza;
        private System.Windows.Forms.DomainUpDown UDAgilidad;
        private System.Windows.Forms.Label tvAgilidad;
        private System.Windows.Forms.DomainUpDown UDEnergia;
        private System.Windows.Forms.Label tvEnergia;
        private System.Windows.Forms.DomainUpDown UDVitalidad;
        private System.Windows.Forms.Label etVitalidad;
        private System.Windows.Forms.ProgressBar PBEnergia;
        private System.Windows.Forms.ProgressBar PBVitalidad;
        private System.Windows.Forms.ProgressBar PBAgilidad;
        private System.Windows.Forms.ProgressBar PBFuerza;
        private System.Windows.Forms.Label tvError;
    }
}

