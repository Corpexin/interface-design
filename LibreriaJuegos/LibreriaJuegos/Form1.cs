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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            conexionBD();
        }

        private void conexionBD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "";//ruta a la conexion. mirar en internete
            con.Open();
            //
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "SELECT COUNT(*) FROM USUARIO WHERE nombreU='1' AND contraseñaU='0';";
            orden.CommandType = CommandType.Text; //mirar opciones?
            orden.Connection = con;
            int datos = (int)orden.ExecuteScalar(); //el casting sobra? integer? casting a String?
            con.Close();

            //para saber si el usuario existe select count(x) from usuario where usuario='' and nick=''; si devuelve 1 existe sino no

            
        }
    }
}
