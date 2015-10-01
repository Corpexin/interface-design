﻿using System;
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
        public int tamaño;
        int vision; //poner como constante
        public Button boton;
        int maxSizeWidth;
        int maxSizeHeight;

        public Persona(int vision, int maxSizeWidth, int maxSizeHeight)
        {
            tamaño = 1;
            this.vision = vision;
            this.maxSizeWidth = maxSizeWidth;
            this.maxSizeHeight = maxSizeHeight;
            boton = añadirBoton();
            nacer();
        }

        public void nacer()
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
            boton.BackgroundImage = Image.FromFile("C:\\Users\\Corpex\\Documents\\GitHub\\interface-design\\BotonEscurridizo\\persona.png");
            boton.BackgroundImageLayout = ImageLayout.Zoom;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Visible = false;


            boton.Click += new EventHandler(morir);
            return boton;
        }

        internal void crece()
        {
            tamaño++;
            boton.Size = (Size)new Point(16 * tamaño, 30 * tamaño);
        }

        public void mirar(MouseEventArgs e) //le pasamos por parametro la "e" de formulario(posicion del raton)
        {

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
            boton.Dispose();
            
        }
    }
}
