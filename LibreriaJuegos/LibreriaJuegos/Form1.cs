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
        Boolean presionT1 = true;
        Boolean presionT2 = true;
        SqlConnection con;
        Form2 f2;
        string confContraseña;

        public FLogin()
        {
            InitializeComponent();
            conexionBD();
        }

        private void conexionBD()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BaseDatos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void comprobar(int datos)
        {
            if(datos == 1)
            {
                this.Hide();
                f2 = new Form2();
                f2.Show();
            }
            else
            {
                lblError.Visible = true;
                if(tbUsuario.Text!="" && tbUsuario.Text!="Usuario" && tbContraseña.Text!="" && tbContraseña.Text != "Contraseña")
                {
                    registrarUser.Visible = true; //permite la opcion de registrar usuario si los campos no estan vacios
                }
                
            }
        }

        private void campoEnter(object sender, EventArgs e)
        {
            lblError.Visible = false;
            registrarUser.Visible = false;
            if (sender == tbContraseña && presionT1 == true)
            {
                tbContraseña.Text = "";
                tbContraseña.UseSystemPasswordChar = true;
                presionT1 = false;
            }
            else if (sender == tbUsuario && presionT2 == true)
            {
                tbUsuario.Text = "";
                presionT2 = false;
            }
        }

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

        private void confirmar(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                consultaUsuario();
            }
        }

        private void consultaUsuario()
        {
            con.Open();
            //
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "SELECT COUNT(*) FROM USUARIO WHERE nombreU='"+tbUsuario.Text+"' AND contraseñaU='"+tbContraseña.Text+"';";//Controlar si el usuario/contraseña estan en la bd
            orden.CommandType = CommandType.Text; //mirar opciones?
            orden.Connection = con;
            int datos = (int)orden.ExecuteScalar(); 
            con.Close();

            comprobar(datos);
        }

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
                //Introducir aqui insert de usuario
                insertUsuario();
                consultaUsuario();//Si se registra, comprueba y entra directamente
            }
        }

        private void insertUsuario()
        { 
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "INSERT INTO [dbo].[USUARIO] ([nombreU], [contraseñaU]) VALUES (N'"+tbUsuario.Text+"', N'"+tbContraseña.Text+"')";//Inserta Usuario y Contraseña en la BD
            orden.CommandType = CommandType.Text; //mirar opciones?
            orden.Connection = con;
            orden.ExecuteScalar();
            con.Close();
        }
    }
}
