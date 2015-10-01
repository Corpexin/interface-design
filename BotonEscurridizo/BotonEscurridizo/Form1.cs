using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotonEscurridizo
{
    public partial class BotonEscurridizo : Form
    {
        Persona persona;
        ArrayList lista = new ArrayList();

        public BotonEscurridizo()
        {
            InitializeComponent();
            añadirPersona();
            lista.Add(persona);
        }

        private Persona añadirPersona()
        {
            //usar las propiedades de la persona en vez de las del boton.
            persona = new Persona(150, MaximumSize.Width, MaximumSize.Height);
            this.Controls.Add(persona.boton);
            return persona;
        }

        private void BotonEscurridizo_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Persona p in lista)
            {
                p.mirar(e);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            añadirPersona();
            lista.Add(persona);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (Persona p in lista)
            {
                if(p.tamaño<4)
                 p.crece();
            }
        }
    }
}
