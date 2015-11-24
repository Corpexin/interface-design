using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaJuegos
{
    public static class Prompt
    {
        private static TextBox textBox;
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 200;
            prompt.Height = 150;
            prompt.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            
            Label textLabel = new Label() { Left = 40, Top = 20, Text = text };
            textBox = new TextBox() { Left = 18, Top = 50, Width = 150 };
            textBox.UseSystemPasswordChar = true;
            Button confirmation = new Button() { Text = "Registro", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "!q·r$t%ey&/(www24)=";
        }

    }
}
