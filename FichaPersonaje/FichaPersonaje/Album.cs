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
        ArrayList listPj;

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
    }
}
