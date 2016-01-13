using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionExamen
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //Comprobacion inicial que comprueba si alguna tabla esta vacia, de ser asi la rellena importando de ficheros
            comprobarBaseDatos();
            //Introduzco en el combobox
            rellenarCb();
        }

        private void rellenarCb()
        {
            ArrayList nombres = Datos.sacarProgenitores();
            //Añadimos los progenitores
            cbLogin.Items.Add("RATON PEREZ");
            foreach(String s in nombres)
            {
                cbLogin.Items.Add(s);
            }
        }

        private void comprobarBaseDatos()
        {
            //Si el numero de progenitores en la base de datos es 0, los importo
            if(Datos.comprobarDatos(1) == 0)
            {
                importarDatos(1);
            }
            //Si el numero de niños en la base de datos es 0, los importo
            if(Datos.comprobarDatos(2) == 0)
            {
                importarDatos(2);
            }
            //Si esPadre esta vacio, importo
            if (Datos.comprobarDatos(3) == 0)
            {
                importarDatos(3);
            }
            //Si cae esta vacio, importo
            if (Datos.comprobarDatos(4) == 0)
            {
                importarDatos(4);
            }
        }

        //Importo 
         private void importarDatos(int n)
        {
            //exportar
            String line;
            String[] aux;
            String[] separador = { "|" };
            
            switch(n)
            {
                case 1: //Progenitores
                    StreamReader sr = new StreamReader((AppDomain.CurrentDomain.BaseDirectory + "../..") + "\\\\ExamenFich\\progenitor.txt");

                    while ((line = sr.ReadLine()) != null)
                    {
                        aux = line.Split(separador, StringSplitOptions.RemoveEmptyEntries);
                        Datos.insertarDatos(1, aux);
                    }
                    break;
                case 2 : //niños
                    StreamReader sr2 = new StreamReader((AppDomain.CurrentDomain.BaseDirectory + "../..") + "\\\\ExamenFich\\niño.txt");

                    while ((line = sr2.ReadLine()) != null)
                    {
                        aux = line.Split(separador, StringSplitOptions.RemoveEmptyEntries);
                        Datos.insertarDatos(2, aux);
                    }
                    break;
                case 3://espadre
                    StreamReader sr3 = new StreamReader((AppDomain.CurrentDomain.BaseDirectory + "../..") + "\\\\ExamenFich\\espadre.txt");

                    while ((line = sr3.ReadLine()) != null)
                    {
                        aux = line.Split(separador, StringSplitOptions.RemoveEmptyEntries);
                        Datos.insertarDatos(3, aux);
                    }
                    break;
                case 4://cae
                    StreamReader sr4 = new StreamReader((AppDomain.CurrentDomain.BaseDirectory + "../..") + "\\\\ExamenFich\\cae.txt");

                    while ((line = sr4.ReadLine()) != null)
                    {
                        aux = line.Split(separador, StringSplitOptions.RemoveEmptyEntries);
                        Datos.insertarDatos(4, aux);
                    }
                    break;
            }
           

        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (cbLogin.SelectedItem == null)
            {
                System.Windows.Forms.MessageBox.Show("Debe escoger un Usuario");
            } else if (cbLogin.SelectedItem.ToString() == "RATON PEREZ")
            {
                InterfazRatonPerez raton = new InterfazRatonPerez();
                raton.Show();
                this.Hide();
            }
            else
            {
                InterfazProgenitores prog = new InterfazProgenitores(cbLogin.SelectedItem.ToString());
                prog.Show();
                this.Hide();
            }

        }
    }
}
