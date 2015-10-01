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
        int cont = 0;

        public BotonEscurridizo()
        {
            InitializeComponent();
            añadirPersona();
            lista.Add(persona);
        }

        private Persona añadirPersona()
        {
            //poner añadirBoton() que devuelva un boton en persona. aqui ejecutar ese metodo y darle a this.controls
            //usar las propiedades de la persona en vez de las del boton.
            Random rnd = new Random();

            Button boton = new Button();
            int tamaño = rnd.Next(3) + 1;
            boton.Size = (Size)new Point(16 * tamaño, 30 * tamaño); //16,30
            boton.Location = new Point(rnd.Next(760), rnd.Next(560));
            boton.BackColor = Color.Transparent;
            boton.BackgroundImage = Image.FromFile("C:\\Users\\Corpex\\Documents\\GitHub\\interface-design\\BotonEscurridizo\\persona.png");
            boton.BackgroundImageLayout = ImageLayout.Zoom;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Visible = false;
            this.Controls.Add(boton);

            //elboton.click += new EventHandler(this.tePille)

            persona = new Persona(20, 30, 150, boton, MaximumSize.Width, MaximumSize.Height);

            return persona;
        }

        private void BotonEscurridizo_MouseMove(object sender, MouseEventArgs e)
        {
            //hacer un for each para que cada elemento de la lista de personas mire
            persona.mirar(e);
            if (cont % 2000 == 0)
            {
                añadirPersona();
                lista.Add(persona);
            }
            cont++;
        }
    }
}
