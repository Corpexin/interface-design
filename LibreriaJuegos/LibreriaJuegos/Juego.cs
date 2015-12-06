using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaJuegos
{
    public class Juego
    {
        public String nombre;
        public String descripcion;
        public String foto;
        public String genero;

        //Constructor completo
        public Juego(String nombre, String descripcion, String foto, String genero)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
            this.genero = genero;
        }

        //Constructor para solo sacar el nombre y la foto
        public Juego(String nombre, String foto)
        {
            this.nombre = nombre;
            this.foto = foto;
        }
    }
}
