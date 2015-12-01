using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaJuegos
{
    static class Datos
    {
        //Creo la conexion general con la que se va a trabajar
        private static SqlConnection conexion()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDLibreriaJuegos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return con;
        }

        //Metodo para comprobar que un usuario/contraseña existen en la base de datos
        public static int comprobarLogin(String usuario, String contraseña)
        {
            SqlConnection con = conexion();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "SELECT COUNT(*) FROM USUARIO WHERE nombreU='" + usuario + "' AND contraseñaU='" + contraseña + "';";//Controla si el usuario/contraseña estan en la bd
            orden.CommandType = CommandType.Text; 
            orden.Connection = con;
            int datos = (int)orden.ExecuteScalar();
            con.Close();
            return datos;
        }

        //Metodo para insertar usuario/contraseña en base de datos
        public static void insertarUsuario(String usuario, String contraseña)
        {
            SqlConnection con = conexion();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "INSERT INTO [dbo].[USUARIO] ([nombreU], [contraseñaU]) VALUES (N'" + usuario + "', N'" + contraseña + "')";//Inserta Usuario y Contraseña en la BD
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            orden.ExecuteScalar();
            con.Close();
        }

        //Metodo para seleccionar los generos
        public static ArrayList seleccionarGeneros()
        {
            SqlConnection con = conexion();
            ArrayList lista = new ArrayList();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "SELECT DISTINCT [generoJ] FROM [dbo].[JUEGO];";//Carga todos los generos diferentes que se encuentran en los juegos
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            SqlDataReader reader = orden.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(reader[0].ToString());//Se agregan los resultados de la consulta al combobox
            }
            con.Close();
            return lista;
        }

        //Metodo para seleccionar los juegos
        public static ArrayList seleccionarJuegos()
        {
            SqlConnection con = conexion();
            ArrayList lista = new ArrayList();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "SELECT [nombreJ], [fotoJ] FROM [dbo].[JUEGO];";//Carga nombre y foto de juegos
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            SqlDataReader reader = orden.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Juego(reader[0].ToString(), reader[1].ToString()));
            }
            con.Close();
            return lista;
        }

        public static ArrayList seleccionarListaJuegosUsuario(String usuario)
        {
            SqlConnection con = conexion();
            ArrayList lista = new ArrayList();
            con.Open();
            SqlCommand orden = new SqlCommand();
            /////////////////////////////////////////
            orden.CommandText = "SELECT [dbo].[JUEGO].[nombreJ], [dbo].[JUEGO].[fotoJ] FROM [dbo].[TIENE], [dbo].[JUEGO] WHERE [nombreU] = 'admin';";//Carga los juegos de un usuario concreto
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            SqlDataReader reader = orden.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Juego(reader[0].ToString(), reader[1].ToString()));
            }
            con.Close();
            return lista;
        }
    }

}
