namespace MPBotoneraArrayList
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tvNombre = new System.Windows.Forms.TextBox();
            this.anterior = new System.Windows.Forms.Button();
            this.siguiente = new System.Windows.Forms.Button();
            this.nuevo = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.Resultado = new System.Windows.Forms.Label();
            this.borrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre: ";
            // 
            // tvNombre
            // 
            this.tvNombre.Location = new System.Drawing.Point(70, 12);
            this.tvNombre.Name = "tvNombre";
            this.tvNombre.Size = new System.Drawing.Size(193, 20);
            this.tvNombre.TabIndex = 1;
            // 
            // anterior
            // 
            this.anterior.Location = new System.Drawing.Point(12, 82);
            this.anterior.Name = "anterior";
            this.anterior.Size = new System.Drawing.Size(18, 23);
            this.anterior.TabIndex = 2;
            this.anterior.Text = "<";
            this.anterior.UseVisualStyleBackColor = true;
            this.anterior.Click += new System.EventHandler(this.anterior_Click);
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(36, 82);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(17, 23);
            this.siguiente.TabIndex = 3;
            this.siguiente.Text = ">";
            this.siguiente.UseVisualStyleBackColor = true;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // nuevo
            // 
            this.nuevo.Location = new System.Drawing.Point(70, 82);
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(47, 23);
            this.nuevo.TabIndex = 4;
            this.nuevo.Text = "Nuevo";
            this.nuevo.UseVisualStyleBackColor = true;
            this.nuevo.Click += new System.EventHandler(this.nuevo_Click);
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(136, 82);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(59, 23);
            this.modificar.TabIndex = 5;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(70, 38);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(64, 23);
            this.guardar.TabIndex = 7;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(188, 38);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 8;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // Resultado
            // 
            this.Resultado.AutoSize = true;
            this.Resultado.Location = new System.Drawing.Point(112, 18);
            this.Resultado.Name = "Resultado";
            this.Resultado.Size = new System.Drawing.Size(35, 13);
            this.Resultado.TabIndex = 11;
            this.Resultado.Text = "label2";
            this.Resultado.Visible = false;
            // 
            // borrar
            // 
            this.borrar.Location = new System.Drawing.Point(213, 82);
            this.borrar.Name = "borrar";
            this.borrar.Size = new System.Drawing.Size(50, 23);
            this.borrar.TabIndex = 12;
            this.borrar.Text = "borrar";
            this.borrar.UseVisualStyleBackColor = true;
            this.borrar.Click += new System.EventHandler(this.borrar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 118);
            this.Controls.Add(this.borrar);
            this.Controls.Add(this.Resultado);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.nuevo);
            this.Controls.Add(this.siguiente);
            this.Controls.Add(this.anterior);
            this.Controls.Add(this.tvNombre);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tvNombre;
        private System.Windows.Forms.Button anterior;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Button nuevo;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label Resultado;
        private System.Windows.Forms.Button borrar;
    }
}

