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

namespace mpRadioButton
{
    public partial class Form1 : Form
    {
        RadioButton[] list1;
        RadioButton[] list2;

        public Form1()
        {
            InitializeComponent();
            añadirLista();
        }

        private void añadirLista()
        {
            list1 = new RadioButton[5];
            list1[0] = radioButton11;
            list1[1] = radioButton12;
            list1[2] = radioButton13;
            list1[3] = radioButton14;
            list1[4] = radioButton15;

            list2 = new RadioButton[5];
            list2[0] = radioButton21;
            list2[1] = radioButton22;
            list2[2] = radioButton23;
            list2[3] = radioButton24;
            list2[4] = radioButton25;

        }


        private void activar(int v)
        {
            for(int i=0; i<v; i++)
            {
                list1[i].Checked = true;
            }
        }

        private void desactivar(int v)
        {
            for (int i = list1.Length-1; i > v; i--)
            {
                list1[i].Checked = false;
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked == true)
            {
                activar(0);
            }
            else
            {
                desactivar(0);
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton12.Checked == true)
            {
                activar(1);
            }
            else
            {
                desactivar(1);
            }
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton13.Checked == true)
            {
                activar(2);
            }
            else
            {
                desactivar(2);
            }
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton14.Checked == true)
            {
                activar(3);
            }
            else
            {
                desactivar(3);
            }
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton15.Checked == true)
            {
                activar(4);
            }
            else
            {
                desactivar(4);
            }
        }

       
    }
}
