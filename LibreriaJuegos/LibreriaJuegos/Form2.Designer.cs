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
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbBorrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorrar)).BeginInit();
            this.SuspendLayout();
            // 
            // lvLibreria
            // 
            this.lvLibreria.AllowDrop = true;
            this.lvLibreria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.lvLibreria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvLibreria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLibreria.ForeColor = System.Drawing.Color.DimGray;
            this.lvLibreria.Location = new System.Drawing.Point(12, 90);
            this.lvLibreria.Margin = new System.Windows.Forms.Padding(1);
            this.lvLibreria.Name = "lvLibreria";
            this.lvLibreria.Size = new System.Drawing.Size(791, 351);
            this.lvLibreria.TabIndex = 0;
            this.lvLibreria.UseCompatibleStateImageBehavior = false;
            this.lvLibreria.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvLibreria_ItemDrag);
            this.lvLibreria.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvLibreria_DragEnter);
            this.lvLibreria.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entrarEnCarta);
            // 
            // lvMiLista
            // 
            this.lvMiLista.AllowDrop = true;
            this.lvMiLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.lvMiLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvMiLista.Location = new System.Drawing.Point(12, 461);
            this.lvMiLista.Name = "lvMiLista";
            this.lvMiLista.Size = new System.Drawing.Size(595, 80);
            this.lvMiLista.TabIndex = 1;
            this.lvMiLista.UseCompatibleStateImageBehavior = false;
            this.lvMiLista.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvMiLista_DragDrop);
            this.lvMiLista.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvMiLista_DragEnter);
            // 
            // cbGenero
            // 
            this.cbGenero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.cbGenero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGenero.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.cbGenero.FormattingEnabled = true;
            this.cbGenero.Location = new System.Drawing.Point(12, 63);
            this.cbGenero.Name = "cbGenero";
            this.cbGenero.Size = new System.Drawing.Size(121, 21);
            this.cbGenero.TabIndex = 2;
            // 
            // pbCerrar
            // 
            this.pbCerrar.Location = new System.Drawing.Point(744, 13);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(27, 27);
            this.pbCerrar.TabIndex = 5;
            this.pbCerrar.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::LibreriaJuegos.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(292, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(203, 61);
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // pbBorrar
            // 
            this.pbBorrar.Location = new System.Drawing.Point(712, 461);
            this.pbBorrar.Name = "pbBorrar";
            this.pbBorrar.Size = new System.Drawing.Size(60, 80);
            this.pbBorrar.TabIndex = 3;
            this.pbBorrar.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pbCerrar);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.pbBorrar);
            this.Controls.Add(this.cbGenero);
            this.Controls.Add(this.lvMiLista);
            this.Controls.Add(this.lvLibreria);
            this.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorrar)).EndInit();
            this.ResumeLayout(false);

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


    }
}