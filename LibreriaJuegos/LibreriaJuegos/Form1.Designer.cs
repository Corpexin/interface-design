namespace LibreriaJuegos
{
    partial class FLogin
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
            this.imagLogo = new System.Windows.Forms.PictureBox();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.registrarUser = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imagLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // imagLogo
            // 
            this.imagLogo.Image = global::LibreriaJuegos.Properties.Resources.logo;
            this.imagLogo.Location = new System.Drawing.Point(46, 56);
            this.imagLogo.Name = "imagLogo";
            this.imagLogo.Size = new System.Drawing.Size(201, 58);
            this.imagLogo.TabIndex = 0;
            this.imagLogo.TabStop = false;
            // 
            // tbUsuario
            // 
            this.tbUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.tbUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsuario.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbUsuario.Location = new System.Drawing.Point(12, 156);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(276, 26);
            this.tbUsuario.TabIndex = 2;
            this.tbUsuario.TabStop = false;
            this.tbUsuario.Text = "   Usuario";
            this.tbUsuario.WordWrap = false;
            this.tbUsuario.Enter += new System.EventHandler(this.campoEnter);
            this.tbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.confirmar);
            this.tbUsuario.Leave += new System.EventHandler(this.campoLeave);
            // 
            // tbContraseña
            // 
            this.tbContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.tbContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbContraseña.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContraseña.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbContraseña.Location = new System.Drawing.Point(12, 205);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.Size = new System.Drawing.Size(276, 26);
            this.tbContraseña.TabIndex = 3;
            this.tbContraseña.TabStop = false;
            this.tbContraseña.Text = "   Contraseña";
            this.tbContraseña.WordWrap = false;
            this.tbContraseña.Enter += new System.EventHandler(this.campoEnter);
            this.tbContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.confirmar);
            this.tbContraseña.Leave += new System.EventHandler(this.campoLeave);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblError.Location = new System.Drawing.Point(54, 248);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(183, 16);
            this.lblError.TabIndex = 4;
            this.lblError.Text = "Usuario/Contraseña incorrecto";
            this.lblError.Visible = false;
            // 
            // registrarUser
            // 
            this.registrarUser.ActiveLinkColor = System.Drawing.Color.Silver;
            this.registrarUser.AutoSize = true;
            this.registrarUser.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarUser.LinkColor = System.Drawing.Color.DimGray;
            this.registrarUser.Location = new System.Drawing.Point(85, 264);
            this.registrarUser.Name = "registrarUser";
            this.registrarUser.Size = new System.Drawing.Size(115, 14);
            this.registrarUser.TabIndex = 5;
            this.registrarUser.TabStop = true;
            this.registrarUser.Text = "Registrar este Usuario";
            this.registrarUser.Visible = false;
            this.registrarUser.VisitedLinkColor = System.Drawing.Color.DimGray;
            this.registrarUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registrarUser_LinkClicked);
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(300, 295);
            this.ControlBox = false;
            this.Controls.Add(this.registrarUser);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.imagLogo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FLogin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.imagLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagLogo;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.TextBox tbContraseña;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.LinkLabel registrarUser;
    }
}

