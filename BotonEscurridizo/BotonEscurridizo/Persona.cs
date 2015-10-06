using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotonEscurridizo
{
    class Persona
    {
        int aceleracion; //aumento de la velocidad con respecto a la cercania del monstruo
        public int tamaño; //tamaño de la persona. 
        int vision; //campo de vision de la persona
        public Button boton; //boton relacionado con la persona
        int maxSizeWidth; //altura minima del formulario
        int maxSizeHeight; //altura maxima del formulario
        public Boolean vivo; //boolean que dice si la persona esta viva o muerta. Muere cuando se clickea sobre la persona

        public Persona(int vision, int maxSizeWidth, int maxSizeHeight) 
        {
            tamaño = 1;
            this.vision = vision;
            this.maxSizeWidth = maxSizeWidth;
            this.maxSizeHeight = maxSizeHeight;
            boton = añadirBoton(); 
            nacer();
            vivo = true;
        }

        public void nacer() //tecnicamente se podria crear el boton directamente visible, pero por aumentar el realismo....
        {
            boton.Visible = true;
        }

        public Button añadirBoton()
        {
            Random rnd = new Random();
            boton = new Button();
            boton.Size = (Size)new Point(16 * tamaño, 30 * tamaño); //16,30
            boton.Location = new Point(rnd.Next(760), rnd.Next(560));
            boton.BackColor = Color.Transparent;
            boton.BackgroundImage = Properties.Resources.persona;
            boton.BackgroundImageLayout = ImageLayout.Zoom;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Visible = false;

            //Evento que se activa cuando se hace click sobre el boton (muere)
            boton.Click += new EventHandler(morir);
            return boton;
        }

        internal void crece()
        {
            tamaño++;
            boton.Size = (Size)new Point(16 * tamaño, 30 * tamaño); //Para crecer se aumenta el tamaño fijo de la imagen (16 x 30) * tamaño
        }

        public void mirar(MouseEventArgs e) //le pasamos por parametro la posicion del raton
        {
            //Si la distancia es de 0-100 va corriendo, si la distancia es de 100-140 va andando.
            if (fDistancia(new Point(e.X, e.Y), new Point(boton.Location.X, boton.Location.Y)) < 100)
            {
                aceleracion = 5;
                huir(e);
            }
            else if (fDistancia(new Point(e.X, e.Y), new Point(boton.Location.X, boton.Location.Y)) < 140)
            {
                aceleracion = 1;
                huir(e);
            }
        }

        public void huir(MouseEventArgs e)
        {
            //arriba
            if (e.Y - boton.Location.Y > 0 && boton.Location.Y > 35)
            {
                boton.Location = new Point(boton.Location.X, boton.Location.Y - aceleracion);
            }
            //izquierda
            if (e.X - boton.Location.X > 0 && boton.Location.X > 35)
            {
                boton.Location = new Point(boton.Location.X - aceleracion, boton.Location.Y);
            }
            //abajo
            if (e.Y - boton.Location.Y < 0 && boton.Location.Y < maxSizeHeight - boton.Height - 35)
            {
                boton.Location = new Point(boton.Location.X, boton.Location.Y + aceleracion);
            }
            //derecha
            if (e.X - boton.Location.X < 0 && boton.Location.X < maxSizeWidth - boton.Width - 35)
            {
                boton.Location = new Point(boton.Location.X + aceleracion, boton.Location.Y);
            }

        }

        private int fDistancia(Point p1, Point p2)
        {
            return (int)Math.Pow(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2), 0.5);
        }

        public void morir(object sender, EventArgs e)
        {
            //El boton muere y la persona cambia su estado vivo a false, para ser usado por la clase Form1 y eliminarlo de su ArrayList de personas
            boton.Dispose();
            vivo = false;
        }
    }
}
