using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaPersonaje
{
    class Album
    {
        public ArrayList listPj;

        public Album()
        {
            listPj = new ArrayList();
        }

        public void guardarPj(Personaje pj)
        {
            listPj.Add(pj);
        }

        public int eliminarPj(int cont, Personaje pj)
        {
            listPj.Remove(pj);
            if (cont <= 0)

                cont = listPj.Count - 1;
            else
                cont--;

            return cont;
        }

        public void modificarPj(Personaje pj, String[] lines)
        {
            pj.nombrePJ = lines[0];
            pj.nombreJug = lines[1];
            pj.faccion = lines[2];
            pj.mapaInicio = lines[3];
            pj.clase = lines[4];
            pj.puntos = lines[5];
            pj.tipoArma = lines[6];
            pj.arma = lines[7];
            pj.inventario = lines[8];
            pj.skillTree = lines[9];
            listPj[listPj.IndexOf(pj)] = pj;

        }

        public int siguientePJ(int cont)
        {
            if (cont >= listPj.Count-1)

                cont = 0;
            else
                cont++;

            return cont;
            
        }

        public int anteriorPJ(int cont)
        {
            if (cont <= 0)

                cont = listPj.Count-1;
            else
                cont--;

            return cont;
        }
    }
}
