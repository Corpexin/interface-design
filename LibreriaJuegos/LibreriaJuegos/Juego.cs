using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaJuegos
{
    class Juego
    {
        public String nombre;
        public String descripcion;
        public String foto;
        public String genero;

        public Juego(String nombre, String descripcion, String foto, String genero)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
            this.genero = genero;
        }

        public Juego(String nombre, String foto)
        {
            this.nombre = nombre;
            this.foto = foto;
        }
    }
}
