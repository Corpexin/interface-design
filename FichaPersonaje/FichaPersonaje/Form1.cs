using FichaPersonaje.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FichaPersonaje
{
    public partial class FichaPersonaje : Form
    {

        Boolean[] clickeado = new Boolean[4]; //Indices: 0 = bk | 1 = dw | 2 = elf | 3 = dl

        public FichaPersonaje()
        {
            InitializeComponent();
            //Inicializamos los booleans de clickeados. Controlan si una clase esta clickeada o no
            for(int i=0; i<clickeado.Length; i++)
            {
                clickeado[i] = false;
            }
            
        }

        private void imgBk_MouseHover(object sender, EventArgs e)
        {
            
            imgBk.Image = Resources.clbk3;
            tvDescrip.Text = "Clase enfocada al cuerpo a cuerpo a corta distancia.";
            tvDescrip.Visible = true;
        }

       
        private void imgBk_MouseLeave(object sender, EventArgs e)
        {
            if (clickeado[0] == false)
            {
                imgBk.Image = Resources.clbkdesact1;
                tvDescrip.Visible = false;
            }
           
        }

        private void imgDW_MouseHover(object sender, EventArgs e)
        {
            imgDW.Image = Resources.cldw1;
            tvDescrip.Text = "Clase enfocada al ataque a largas distancias con hechizos.";
            tvDescrip.Visible = true;
        }

        private void imgDW_MouseLeave(object sender, EventArgs e)
        {
            if (clickeado[1] == false)
            {
                imgDW.Image = Resources.cldwdesact1;
                tvDescrip.Visible = false;
            }
        }

        private void imgElf_MouseHover(object sender, EventArgs e)
        {
            imgElf.Image = Resources.clelf1;
            tvDescrip.Text = "Clase enfocada a largas distancias con arco y flechas";
            tvDescrip.Visible = true;
        }

        private void imgElf_MouseLeave(object sender, EventArgs e)
        {
            if (clickeado[2] == false)
            { 
                imgElf.Image = Resources.clelfdesact1;
                tvDescrip.Visible = false;
            }
        }

        private void imgDL_MouseHover(object sender, EventArgs e)
        {
            imgDL.Image = Resources.cldl1;
            tvDescrip.Text = "Clase enfocada a largas distancias a personajes individuales";
            tvDescrip.Visible = true;
        }

        private void imgDL_MouseLeave(object sender, EventArgs e)
        {
            if (clickeado[3] == false)
            {
                imgDL.Image = Resources.cldldesact1;
                tvDescrip.Visible = false;
            }
        }

        private void imgBk_Click(object sender, EventArgs e)
        {
            imgBk.Image = Resources.clbk3;
            //recorro el array de booleans y si encuentra uno a true, lo desactiva
            desactivarImagen();
            clickeado[0] = true;
            imagPerfil.Image = Resources.bk1;
        }

        private void imgDW_Click(object sender, EventArgs e)
        {
            imgDW.Image = Resources.cldw1;
            //recorro el array de booleans y si encuentra uno a true, lo desactiva
            desactivarImagen();
            clickeado[1] = true;
            imagPerfil.Image = Resources.dw;
        }

        private void imgElf_Click(object sender, EventArgs e)
        {
            imgElf.Image = Resources.clelf1;
            //recorro el array de booleans y si encuentra uno a true, lo desactiva
            desactivarImagen();
            clickeado[2] = true;
            imagPerfil.Image = Resources.elf;
        }

        private void imgDL_Click(object sender, EventArgs e)
        {
            imgDL.Image = Resources.cldl1;
            //recorro el array de booleans y si encuentra uno a true, lo desactiva
            desactivarImagen();
            clickeado[3] = true;
            imagPerfil.Image = Resources.dl;
        }

        //Metodo para desactivar resto de imagenes segun el que se haga click
        private void desactivarImagen()
        {
            for (int i = 0; i < clickeado.Length; i++)
            {
                if (clickeado[i] == true)
                {
                    switch (i)
                    {
                        case 0:
                            imgBk.Image = Resources.clbkdesact1;
                            break;
                        case 1:
                            imgDW.Image = Resources.cldwdesact1;
                            break;
                        case 2:
                            imgElf.Image = Resources.clelfdesact1;
                            break;
                        case 3:
                            imgDL.Image = Resources.cldldesact1;
                            break;
                            
                    }
                    clickeado[i] = false;
                   
                }
            }
        }

        private void btn2_MouseHover(object sender, EventArgs e)
        {
            btn2.Image = Resources.btnAct;
        }

        private void btn3_MouseHover(object sender, EventArgs e)
        {
            btn3.Image = Resources.btnAct;
        }

        private void btn2_MouseLeave(object sender, EventArgs e)
        {
            btn2.Image = Resources.btnDesact;
        }

        private void btn3_MouseLeave(object sender, EventArgs e)
        {
            btn3.Image = Resources.btnDesact;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            for(int i = 0; i<clickeado.Length; i++)
            {
                clickeado[i] = false;
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    imgBk.Enabled = true;
                    imgDW.Enabled = true;
                    imgElf.Enabled = false;
                    imgDL.Enabled = false;
                    imgBk.Image = Resources.clbkdesact1;
                    imgDW.Image = Resources.cldwdesact1;
                    imgElf.Image = Resources.clelfproh;
                    imgDL.Image = Resources.cldlproh;
                    break;
                case 1:
                    imgBk.Enabled = false;
                    imgDW.Enabled = false;
                    imgElf.Enabled = true;
                    imgDL.Enabled = false;
                    imgElf.Image = Resources.clelfdesact1;
                    imgBk.Image = Resources.clbkproh;
                    imgDW.Image = Resources.cldwproh;
                    imgDL.Image = Resources.cldlproh;
                    break;
                case 2:
                    imgBk.Enabled = false;
                    imgDW.Enabled = false;
                    imgElf.Enabled = false;
                    imgDL.Enabled = true;
                    imgDL.Image = Resources.cldldesact1;
                    imgBk.Image = Resources.clbkproh;
                    imgDW.Image = Resources.cldwproh;
                    imgElf.Image = Resources.clelfproh;
                    break;
            }
        }
    }

}
