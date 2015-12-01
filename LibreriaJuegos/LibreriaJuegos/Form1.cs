using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LibreriaJuegos
{
    public partial class FLogin : Form
    {
        Form2 f2;
        string confContraseña;

        public FLogin()
        {
            InitializeComponent();
        }

        //Evento que se ejecuta cuando gana el foco
        private void campoEnter(object sender, EventArgs e)
        {
            lblError.Visible = false;
            registrarUser.Visible = false;
            if (sender == tbContraseña)
            {
                tbContraseña.Text = "";
                tbContraseña.UseSystemPasswordChar = true;
            }
            else if (sender == tbUsuario)
            {
                tbUsuario.Text = "";
            }
        }

        //Evento que se ejecuta cuando pierde el foco
        private void campoLeave(object sender, EventArgs e)
        {
            if (sender == tbContraseña && tbContraseña.Text == "")
            {
                tbContraseña.Text = "Contraseña";
                tbContraseña.UseSystemPasswordChar = false;
            }
            else if (sender == tbUsuario && tbUsuario.Text == "")
            {
                tbUsuario.Text = "Usuario";
            }
        }

        //Evento que se ejecuta cuando presiona Enter
        private void confirmar(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                consultaUsuario();
            }
        }

        //Consulta con la base de datos si el usuario y contraseña existen, sino da la opcion de registrar
        private void consultaUsuario()
        {
            if (Datos.comprobarLogin(tbUsuario.Text, tbContraseña.Text) == 1)
            {
                this.Hide();
                f2 = new Form2(tbUsuario.Text, tbContraseña.Text);
                f2.Show();
            }
            else
            {
                lblError.Visible = true;
                if (tbUsuario.Text != "" && tbUsuario.Text != "Usuario" && tbContraseña.Text != "" && tbContraseña.Text != "Contraseña")
                {
                    registrarUser.Visible = true; //permite la opcion de registrar usuario si los campos no estan vacios
                }

            }
        }

        //Evento que se ejecuta si se hace click en el boton registrar
        private void registrarUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblError.Visible = false;
            registrarUser.Visible = false;
            Boolean entrada=false;
            do
            {
                if (entrada == false)
                    confContraseña = Prompt.ShowDialog("Reintroduce Pass:", "Registro");
                else
                    confContraseña = Prompt.ShowDialog("Pass Incorrecta. Re:", "Registro");
                entrada = true;
            } while (confContraseña!=""+tbContraseña.Text && confContraseña != "!q·r$t%ey&/(www24)=");

            if (confContraseña == "" + tbContraseña.Text)
            {

                Datos.insertarUsuario(tbUsuario.Text, tbContraseña.Text);
                consultaUsuario();//Si se registra, comprueba y entra directamente
            }
        }
    }
}
