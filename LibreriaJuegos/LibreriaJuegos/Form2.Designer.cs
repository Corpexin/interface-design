namespace LibreriaJuegos
{
    partial class Form2
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
            this.lvLibreria = new System.Windows.Forms.ListView();
            this.lvMiLista = new System.Windows.Forms.ListView();
            this.cbGenero = new System.Windows.Forms.ComboBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbFlechaDer = new System.Windows.Forms.PictureBox();
            this.pbFlechaIzq = new System.Windows.Forms.PictureBox();
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbBorrar = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlechaDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlechaIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorrar)).BeginInit();
            this.SuspendLayout();
            // 
            // lvLibreria
            // 
            this.lvLibreria.AllowDrop = true;
            this.lvLibreria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(23)))));
            this.lvLibreria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvLibreria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLibreria.ForeColor = System.Drawing.Color.DimGray;
            this.lvLibreria.Location = new System.Drawing.Point(-1, 77);
            this.lvLibreria.Margin = new System.Windows.Forms.Padding(1);
            this.lvLibreria.Name = "lvLibreria";
            this.lvLibreria.Size = new System.Drawing.Size(804, 396);
            this.lvLibreria.TabIndex = 0;
            this.lvLibreria.UseCompatibleStateImageBehavior = false;
            this.lvLibreria.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvLibreria_ItemDrag);
            this.lvLibreria.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvLibreria_DragEnter);
            this.lvLibreria.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entrarEnCarta);
            // 
            // lvMiLista
            // 
            this.lvMiLista.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvMiLista.AllowDrop = true;
            this.lvMiLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.lvMiLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMiLista.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMiLista.ForeColor = System.Drawing.Color.DarkGray;
            this.lvMiLista.Location = new System.Drawing.Point(64, 493);
            this.lvMiLista.Name = "lvMiLista";
            this.lvMiLista.Size = new System.Drawing.Size(594, 88);
            this.lvMiLista.TabIndex = 1;
            this.lvMiLista.UseCompatibleStateImageBehavior = false;
            this.lvMiLista.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvMiLista_DragDrop);
            this.lvMiLista.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvMiLista_DragEnter);
            // 
            // cbGenero
            // 
            this.cbGenero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.cbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGenero.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.cbGenero.FormattingEnabled = true;
            this.cbGenero.Location = new System.Drawing.Point(14, 36);
            this.cbGenero.Name = "cbGenero";
            this.cbGenero.Size = new System.Drawing.Size(121, 21);
            this.cbGenero.TabIndex = 2;
            this.cbGenero.SelectedValueChanged += new System.EventHandler(this.cbGenero_SelectedValueChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.menuStrip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem,
            this.contactoToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 8;
            this.menuStrip.Text = "Menu";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programaToolStripMenuItem,
            this.sQLServerToolStripMenuItem,
            this.nETToolStripMenuItem});
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.versionToolStripMenuItem.Text = "Version";
            // 
            // programaToolStripMenuItem
            // 
            this.programaToolStripMenuItem.Name = "programaToolStripMenuItem";
            this.programaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.programaToolStripMenuItem.Text = "Programa";
            this.programaToolStripMenuItem.Click += new System.EventHandler(this.programaToolStripMenuItem_Click);
            // 
            // sQLServerToolStripMenuItem
            // 
            this.sQLServerToolStripMenuItem.Name = "sQLServerToolStripMenuItem";
            this.sQLServerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sQLServerToolStripMenuItem.Text = "SQL Server";
            // 
            // nETToolStripMenuItem
            // 
            this.nETToolStripMenuItem.Name = "nETToolStripMenuItem";
            this.nETToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.nETToolStripMenuItem.Text = ".NET";
            // 
            // contactoToolStripMenuItem
            // 
            this.contactoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailToolStripMenuItem,
            this.githubToolStripMenuItem});
            this.contactoToolStripMenuItem.Name = "contactoToolStripMenuItem";
            this.contactoToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.contactoToolStripMenuItem.Text = "Contacto";
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.emailToolStripMenuItem.Text = "email";
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.githubToolStripMenuItem.Text = "github";
            // 
            // pbFlechaDer
            // 
            this.pbFlechaDer.Image = global::LibreriaJuegos.Properties.Resources.flechaDerAct;
            this.pbFlechaDer.Location = new System.Drawing.Point(663, 500);
            this.pbFlechaDer.Name = "pbFlechaDer";
            this.pbFlechaDer.Size = new System.Drawing.Size(30, 35);
            this.pbFlechaDer.TabIndex = 9;
            this.pbFlechaDer.TabStop = false;
            this.pbFlechaDer.Click += new System.EventHandler(this.pbFlechaDer_Click);
            // 
            // pbFlechaIzq
            // 
            this.pbFlechaIzq.Image = global::LibreriaJuegos.Properties.Resources.flechaIzqAct;
            this.pbFlechaIzq.Location = new System.Drawing.Point(28, 500);
            this.pbFlechaIzq.Name = "pbFlechaIzq";
            this.pbFlechaIzq.Size = new System.Drawing.Size(30, 35);
            this.pbFlechaIzq.TabIndex = 6;
            this.pbFlechaIzq.TabStop = false;
            this.pbFlechaIzq.Click += new System.EventHandler(this.pbFlechaIzq_Click);
            // 
            // pbCerrar
            // 
            this.pbCerrar.Image = global::LibreriaJuegos.Properties.Resources.cerrar;
            this.pbCerrar.Location = new System.Drawing.Point(750, 10);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(18, 20);
            this.pbCerrar.TabIndex = 5;
            this.pbCerrar.TabStop = false;
            this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::LibreriaJuegos.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(292, 10);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(203, 61);
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // pbBorrar
            // 
            this.pbBorrar.Image = global::LibreriaJuegos.Properties.Resources.basura;
            this.pbBorrar.Location = new System.Drawing.Point(724, 485);
            this.pbBorrar.Name = "pbBorrar";
            this.pbBorrar.Size = new System.Drawing.Size(44, 64);
            this.pbBorrar.TabIndex = 3;
            this.pbBorrar.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pbFlechaDer);
            this.Controls.Add(this.pbFlechaIzq);
            this.Controls.Add(this.pbCerrar);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.pbBorrar);
            this.Controls.Add(this.cbGenero);
            this.Controls.Add(this.lvMiLista);
            this.Controls.Add(this.lvLibreria);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlechaDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlechaIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvLibreria;
        private System.Windows.Forms.ListView lvMiLista;
        private System.Windows.Forms.ComboBox cbGenero;
        private System.Windows.Forms.PictureBox pbBorrar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.PictureBox pbCerrar;
        private string text1;
        private string text2;
        private System.Windows.Forms.PictureBox pbFlechaIzq;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbFlechaDer;
    }
}