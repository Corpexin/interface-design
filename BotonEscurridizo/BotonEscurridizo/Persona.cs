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
        int aceleracion;
        int tamañoX;
        int tamañoY;
        int vision;
        Button boton;
        int maxSizeWidth;
        int maxSizeHeight;

        public Persona(int tamañoX, int tamañoY, int vision, Button boton, int maxSizeWidth, int maxSizeHeight)
        {
            this.tamañoX = tamañoX;
            this.tamañoY = tamañoY;
            this.vision = vision;
            this.boton = boton;
            this.maxSizeWidth = maxSizeWidth;
            this.maxSizeHeight = maxSizeHeight;
            nacer();
        }

        public void nacer()
        {
            boton.Visible = true;
        }

        public void mirar(MouseEventArgs e) //le pasamos por parametro la "e" de formulario(posicion del raton?)
        {

            if (fDistancia(new Point(e.X, e.Y), new Point(boton.Location.X, boton.Location.Y)) < 80)
            {
                aceleracion = 5;
                huir(e);
            }
            else if (fDistancia(new Point(e.X, e.Y), new Point(boton.Location.X, boton.Location.Y)) < 110)
            {
                aceleracion = 1;
                huir(e);
            }
        }

        public void huir(MouseEventArgs e)
        {
            int cont = 0;
            if (cont % 2 == 0) // contador que relentiza el trackeo del boton a la mitad
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
                cont++;
            }
        }

        private int fDistancia(Point p1, Point p2)
        {
            return (int)Math.Pow(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2), 0.5);
        }

        public void morir()
        {

        }
    }
}
