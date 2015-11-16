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

        public void guardarPj(String[] lines)
        {
            listPj.Add(lines);
        }

        public void eliminarPj(String[] lines)
        {

        }

        public void modificarPj(String[] lines)
        {

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
