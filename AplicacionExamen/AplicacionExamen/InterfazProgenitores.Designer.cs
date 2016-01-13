namespace AplicacionExamen
{
    partial class InterfazProgenitores
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
            this.cbNombreNiño = new System.Windows.Forms.ComboBox();
            this.lvDientesEnBoca = new System.Windows.Forms.ListView();
            this.lvDientesCaidos = new System.Windows.Forms.ListView();
            this.lvTickets = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbNombreNiño
            // 
            this.cbNombreNiño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNombreNiño.FormattingEnabled = true;
            this.cbNombreNiño.Location = new System.Drawing.Point(618, 12);
            this.cbNombreNiño.Name = "cbNombreNiño";
            this.cbNombreNiño.Size = new System.Drawing.Size(121, 21);
            this.cbNombreNiño.TabIndex = 0;
            this.cbNombreNiño.SelectedValueChanged += new System.EventHandler(this.cbNombreNiño_SelectedValueChanged);
            // 
            // lvDientesEnBoca
            // 
            this.lvDientesEnBoca.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lvDientesEnBoca.Location = new System.Drawing.Point(226, 48);
            this.lvDientesEnBoca.Name = "lvDientesEnBoca";
            this.lvDientesEnBoca.Size = new System.Drawing.Size(513, 97);
            this.lvDientesEnBoca.TabIndex = 1;
            this.lvDientesEnBoca.UseCompatibleStateImageBehavior = false;
            this.lvDientesEnBoca.View = System.Windows.Forms.View.List;
            this.lvDientesEnBoca.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvDientesEnBoca_ItemDrag);
            this.lvDientesEnBoca.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvDientesEnBoca_DragEnter);
            // 
            // lvDientesCaidos
            // 
            this.lvDientesCaidos.AllowDrop = true;
            this.lvDientesCaidos.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lvDientesCaidos.Location = new System.Drawing.Point(226, 163);
            this.lvDientesCaidos.Name = "lvDientesCaidos";
            this.lvDientesCaidos.Size = new System.Drawing.Size(513, 97);
            this.lvDientesCaidos.TabIndex = 2;
            this.lvDientesCaidos.UseCompatibleStateImageBehavior = false;
            this.lvDientesCaidos.View = System.Windows.Forms.View.Tile;
            this.lvDientesCaidos.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvDientesCaidos_DragDrop);
            this.lvDientesCaidos.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvDientesCaidos_DragEnter);
            // 
            // lvTickets
            // 
            this.lvTickets.Location = new System.Drawing.Point(37, 295);
            this.lvTickets.Name = "lvTickets";
            this.lvTickets.Size = new System.Drawing.Size(702, 69);
            this.lvTickets.TabIndex = 3;
            this.lvTickets.UseCompatibleStateImageBehavior = false;
            this.lvTickets.View = System.Windows.Forms.View.Tile;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AplicacionExamen.Properties.Resources.diente;
            this.pictureBox1.Location = new System.Drawing.Point(37, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 212);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(33, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tickets";
            // 
            // InterfazProgenitores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(763, 376);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lvTickets);
            this.Controls.Add(this.lvDientesCaidos);
            this.Controls.Add(this.lvDientesEnBoca);
            this.Controls.Add(this.cbNombreNiño);
            this.Name = "InterfazProgenitores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InterfazProgenitores";
            this.Load += new System.EventHandler(this.InterfazProgenitores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNombreNiño;
        private System.Windows.Forms.ListView lvDientesEnBoca;
        private System.Windows.Forms.ListView lvDientesCaidos;
        private System.Windows.Forms.ListView lvTickets;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}