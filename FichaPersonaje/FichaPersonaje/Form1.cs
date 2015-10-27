using FichaPersonaje.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FichaPersonaje
{
    public partial class FichaPersonaje : Form
    {
        Boolean[] clickeado = new Boolean[4]; //Indices: 0 = bk | 1 = dw | 2 = elf | 3 = dl
        Boolean[] btnclickeado = new Boolean[3]; //Indices: 0 = basic | 1 = caract | 2 = equip
        private readonly int MAX_PUNTOS_CONT = 5000;//Constante con el maximo de puntos disponibles para las caracteristicas
        int[] listaValoresCaract = new int[4]; //aqui se guardan los puntos de las 4 caracteristicas

        public FichaPersonaje()
        {
            InitializeComponent();
            //Inicializamos los booleans de clickeados. Controlan si una clase esta clickeada o no
            for(int i=0; i<clickeado.Length; i++)
            {
                clickeado[i] = false;
            }

            for(int i =0; i<btnclickeado.Length; i++)
            {
                if (i == 0)
                {
                    btnclickeado[i] = true;
                }
                else
                {
                    btnclickeado[i] = false;
                }
            }
            //Inicializamos el uptodown
            inicioUptoDown();
            
            //Inicializamos array de valores de estadisticas a 0
            for(int i =0; i<listaValoresCaract.Length; i++)
            {
                listaValoresCaract[i] = 0;
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
        private void btn1_MouseHover(object sender, EventArgs e)
        {
            btn1.Image = Resources.btnAct1;
        }

        private void btn2_MouseHover(object sender, EventArgs e)
        {
            btn2.Image = Resources.btnAct1;
        }

        private void btn3_MouseHover(object sender, EventArgs e)
        {
            btn3.Image = Resources.btnAct1;
        }

        private void btn1_MouseLeave(object sender, EventArgs e)
        {
            if (btnclickeado[0] == false)
                btn1.Image = Resources.btnDesact1;
                
            
        }

        private void btn2_MouseLeave(object sender, EventArgs e)
        {
            if (btnclickeado[1] == false)
                btn2.Image = Resources.btnDesact1;
        }

        private void btn3_MouseLeave(object sender, EventArgs e)
        {
            if (btnclickeado[2] == false)
                btn3.Image = Resources.btnDesact1;
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
                    imgElf.Image = Resources.clelfproh1;
                    imgDL.Image = Resources.cldlproh1;
                    break;
                case 1:
                    imgBk.Enabled = false;
                    imgDW.Enabled = false;
                    imgElf.Enabled = true;
                    imgDL.Enabled = false;
                    imgElf.Image = Resources.clelfdesact1;
                    imgBk.Image = Resources.clbkproh1;
                    imgDW.Image = Resources.cldwproh1;
                    imgDL.Image = Resources.cldlproh1;
                    break;
                case 2:
                    imgBk.Enabled = false;
                    imgDW.Enabled = false;
                    imgElf.Enabled = false;
                    imgDL.Enabled = true;
                    imgDL.Image = Resources.cldldesact1;
                    imgBk.Image = Resources.clbkproh1;
                    imgDW.Image = Resources.cldwproh1;
                    imgElf.Image = Resources.clelfproh1;
                    break;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1.Image = Resources.btnAct1;
            btn2.Image = Resources.btnDesact1;
            btn3.Image = Resources.btnDesact1;
            panelDos.Visible = false;
            btnclickeado[0] = true;
            btnclickeado[1] = false;
            btnclickeado[2] = false;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btn2.Image = Resources.btnAct1;
            btn1.Image = Resources.btnDesact1;
            btn3.Image = Resources.btnDesact1;
            panelDos.Visible = true;
            btnclickeado[0] = false;
            btnclickeado[1] = true;
            btnclickeado[2] = false;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btn3.Image = Resources.btnAct1;
            btn1.Image = Resources.btnDesact1;
            btn2.Image = Resources.btnDesact1;
            //panelTres.Visible = true;
            btnclickeado[0] = false;
            btnclickeado[2] = true;
            btnclickeado[1] = false;
        }

        private void inicioUptoDown()
        {
            //Creo un arrayList de 9999 numeros y se los asigno a los uptodown
            ArrayList listNum = new ArrayList();
            for (int i = MAX_PUNTOS_CONT; i >=0; i--)
            {
                listNum.Add(i);
            }
            UDFuerza.Items.AddRange(listNum);
            UDFuerza.SelectedIndex = MAX_PUNTOS_CONT; //mueve el indice al 0 (ultimo numero añadido)
            UDAgilidad.Items.AddRange(listNum);
            UDAgilidad.SelectedIndex = MAX_PUNTOS_CONT;
            UDVitalidad.Items.AddRange(listNum);
            UDVitalidad.SelectedIndex = MAX_PUNTOS_CONT;
            UDEnergia.Items.AddRange(listNum);
            UDEnergia.SelectedIndex = MAX_PUNTOS_CONT;
            
        }

        private void UDFuerza_SelectedItemChanged(object sender, EventArgs e)
        {
            calcularValor(UDFuerza, 0, PBFuerza);
        }

        private void UDAgilidad_SelectedItemChanged(object sender, EventArgs e)
        {
            calcularValor(UDAgilidad, 1, PBAgilidad);
        }

        private void UDVitalidad_SelectedItemChanged(object sender, EventArgs e)
        {
            calcularValor(UDVitalidad, 2, PBVitalidad);
        }

        private void UDEnergia_SelectedItemChanged(object sender, EventArgs e)
        {
            calcularValor(UDEnergia, 3, PBEnergia);
        }

        private void calcularValor(DomainUpDown udCaract, int indice, ProgressBar pbCaract)
        {
            Regex r = new Regex("^\\d+$"); //Patron que solo coge numeros (hora y media de debug y busquedas para encontrarlo .... )
            String ft = udCaract.Text;
            Match m2 = r.Match(ft);
            int valor=0;
            if (udCaract.Text != null && m2.Success && udCaract.Text.Length<=6 && Int32.Parse(udCaract.Text) <= MAX_PUNTOS_CONT)
            {
                listaValoresCaract[indice] = Int32.Parse(udCaract.Text);
                for (int i = 0; i < listaValoresCaract.Length; i++)
                {
                    valor = valor + listaValoresCaract[i];
                }
                tvContadorPuntos.Text = "" + (MAX_PUNTOS_CONT - valor);
                pbCaract.Value = listaValoresCaract[indice];
                if(Int32.Parse(tvContadorPuntos.Text)  < 0)
                {
                    tvError.Visible = true;
                }
                else
                {
                    tvError.Visible = false;
                }
            }
            else
            {
                tvContadorPuntos.Text = "Valor no Soportado";
                listaValoresCaract[indice] = 0;
                pbCaract.Value = 0;
            }

        }
    }

}
