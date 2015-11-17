using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaPersonaje
{
    class Personaje
    {
        public String nombrePJ;
        public String nombreJug;
        public String faccion;
        public String mapaInicio;
        public String clase;
        public String puntos;
        public String tipoArma;
        public String arma;
        public String inventario;
        public String skillTree;

        public Personaje(String nombrePJ, String nombreJug, String faccion, String mapaInicio, String clase, String puntos, String tipoArma, String arma, String inventario, String skillTree)
        {
            this.nombrePJ = nombrePJ;
            this.nombreJug = nombreJug;
            this.faccion = faccion;
            this.mapaInicio = mapaInicio;
            this.clase = clase;
            this.puntos = puntos;
            this.tipoArma = tipoArma;
            this.inventario = inventario;
            this.arma = arma;
            this.skillTree = skillTree;
        }


    }
}
