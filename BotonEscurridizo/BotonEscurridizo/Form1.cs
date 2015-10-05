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

        private void BotonEscurridizo_MouseMove(object sender, MouseEventArgs e)//Controla las acciones de las personas en juego cada vez que se mueve el raton
        {
            foreach (Persona p in lista)
            {
                p.mirar(e);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)//Temporizador 1, para añadir personas al juego
        {
            añadirPersona();
            lista.Add(persona);
        }

        private void timer2_Tick(object sender, EventArgs e) //Temporizador 2, para crecimiento y borrado de personas muertas
        {
            //Creo una lista auxiliar en la que se van agregando las personas muertas
            ArrayList listaBorrados = new ArrayList();
            foreach (Persona p in lista)
            {
                if(p.vivo == false)
                {
                    listaBorrados.Add(p);
                }
                else //Si no esta muerto, la persona aumenta de tamaño (hasta un tope de 4)
                {
                    if (p.tamaño < 4)
                        p.crece();
                }
            }
            //Borro de la lista principal aquellas personas muertas contenidas en la lista de borrados.
            lista.Remove(listaBorrados);
        }
    }
}
