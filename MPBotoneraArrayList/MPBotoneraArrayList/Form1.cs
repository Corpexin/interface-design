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

namespace MPBotoneraArrayList
{
    public partial class Form1 : Form
    {
        ArrayList listaNombre;
        Boolean bmodificar;
        int cont = -1;
        public Form1()
        {
            InitializeComponent();
            listaNombre = new ArrayList();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (tvNombre.Text != null)
            {
                if (bmodificar)
                {
                    if(cont>=0)
                    listaNombre[cont] = tvNombre.Text;
                }
                else
                {
                    listaNombre.Add(tvNombre.Text);
                    cont++;
                }
            }
            //Entra en modo edicion
            modoVision();
        }

       
        private void cancelar_Click(object sender, EventArgs e)
        {
            tvNombre.Text = "";
        }

       

        private void nuevo_Click(object sender, EventArgs e)
        {
            bmodificar = false;
            modoEdicion();
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            if(cont>=0)
             bmodificar = true;
            modoEdicion();
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            cont--;
            if(cont>= 0)
            {
                Resultado.Text = (String)listaNombre[cont];
            }
            else
            {
                cont = listaNombre.Count - 1;
                if (cont >= 0)
                Resultado.Text = (String)listaNombre[cont];
            }
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            
            if (cont+1 < listaNombre.Count)
            {
                cont++;
                Resultado.Text = (String) listaNombre[cont];
            }
            else
            {
                
                if (cont >= 0)
                {
                    cont = 0;
                    Resultado.Text = (String)listaNombre[cont];
                }
            }
        }

        private void modoVision()
        {
            if (listaNombre.Count != 0)
                Resultado.Text = (String)listaNombre[listaNombre.Count - 1];
            else
                Resultado.Text = "Ningun Nombre Seleccionado";
            guardar.Visible = false;
            cancelar.Visible = false;
            Resultado.Visible = true;
            tvNombre.Visible = false;
        }

        private void modoEdicion()
        {
            tvNombre.Visible = true;
            if (!bmodificar)
                tvNombre.Text = "";
            else
            {
                if(cont>=0)
                tvNombre.Text = (String)listaNombre[cont];
            }
            Resultado.Visible = false;
            guardar.Visible = true;
            cancelar.Visible = true;
        }

        private void borrar_Click(object sender, EventArgs e)
        {
            if (cont >= 0)
            {
                listaNombre.RemoveAt(cont);
                cont--;
            }
                
            modoVision();
        }
    }
}
