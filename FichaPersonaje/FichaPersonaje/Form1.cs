using FichaPersonaje.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FichaPersonaje
{
    public partial class FichaPersonaje : Form
    {
        public FichaPersonaje()
        {
            InitializeComponent();
        }

        private void imgBk_MouseHover(object sender, EventArgs e)
        {
            
            imgBk.Image = Resources.clbk3;
            tvDescrip.Text = "Clase enfocada al cuerpo a cuerpo a corta distancia.";
            tvDescrip.Visible = true;
        }

        private void imgBk_MouseLeave(object sender, EventArgs e)
        {
            imgBk.Image = Resources.clbkdesact1;
            tvDescrip.Visible = false;
        }

        private void imgDW_MouseHover(object sender, EventArgs e)
        {
            imgDW.Image = Resources.cldw1;
            tvDescrip.Text = "Clase enfocada al ataque a largas distancias con hechizos.";
            tvDescrip.Visible = true;
        }

        private void imgDW_MouseLeave(object sender, EventArgs e)
        {
            imgDW.Image = Resources.cldwdesact1;
            tvDescrip.Visible = false;
        }
    }

}
