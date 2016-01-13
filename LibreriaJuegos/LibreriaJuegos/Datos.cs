using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace LibreriaJuegos
{
    static class Datos
    {
        //Creo la conexion general con la que se va a trabajar
        internal static SqlConnection conexion()
        {
            //añadida referencia system.configuration
            SqlConnection con = new SqlConnection();
            //Con este metodo, puedo cambiar el datadirectory a la carpeta donde realmente esta la base de datos.
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "../.."));
            con.ConnectionString = Properties.Settings.Default.BDLib;
            //con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Corpex\\Documents\\GitHub\\interface-design\\LibreriaJuegos\\LibreriaJuegos\\BaseDatos\\BDSteam.mdf;Integrated Security=True;Connect Timeout=30";
            return con;
        }

        //Metodo para comprobar que un usuario/contraseña existen en la base de datos
        internal static int comprobarLogin(String usuario, String contraseña)
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
        internal static void insertarUsuario(String usuario, String contraseña)
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
        internal static ArrayList seleccionarGeneros()
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
        internal static ArrayList seleccionarJuegos(String usuario, String genero)
        {
            String query = "";
            //Carga la lista de usuario
            if (usuario != "")
            {
                query = "SELECT [dbo].[JUEGO].[nombreJ], [dbo].[JUEGO].[fotoJ] FROM [dbo].[TIENE], [dbo].[JUEGO] WHERE [dbo].[TIENE].[nombreU] = '" + usuario + "' AND [dbo].[JUEGO].[nombreJ] = [dbo].[TIENE].[nombreJ];";//Carga los juegos de un usuario concreto
            }
            
            //Carga la lista con un genero concreto
            if(genero != "")
            {
                query = "SELECT [dbo].[JUEGO].[nombreJ], [dbo].[JUEGO].[fotoJ] FROM [dbo].[JUEGO] WHERE [dbo].[JUEGO].[generoJ] = '" + genero + "' ;";//Carga los juegos de un genero concreto
            }

            //Carga toda la lista
            if(usuario == "" && genero == "")
            {
                query = "SELECT [nombreJ], [fotoJ] FROM [dbo].[JUEGO];";//Carga nombre y foto de juegos
            }

            SqlConnection con = conexion();
            ArrayList lista = new ArrayList();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = query;
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

        //Metodo que saca juego completo como clase
        internal static Juego seleccionarJuegosCompleto(string nombreJ)
        {
            Juego j = new Juego("", "");
            SqlConnection con = conexion();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "SELECT * FROM [dbo].[JUEGO] WHERE [dbo].[JUEGO].[nombreJ] = '"+nombreJ+"' ;";
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            SqlDataReader reader = orden.ExecuteReader();
            while (reader.Read())
            {
                j =  new Juego(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
            }
            con.Close();
            return j;
        }


        //Metodo para introducir un juego en la tabla TIENE de la bd
        internal static void insertarJuegoUsuario(string nombreJuego, string usuario)
        {
            SqlConnection con = conexion();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "INSERT INTO [dbo].[TIENE] ([nombreU], [nombreJ]) VALUES (N'" + usuario + "', N'" + nombreJuego + "')";//Inserta Usuario y Contraseña en la BD
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            orden.ExecuteScalar();
            con.Close();
        }
        
        //Metodo para borrar un juego en la tabla TIENE de la bd
        internal static void borrarJuegoUsuario(string nombreJuego, string usuario)
        {
            SqlConnection con = conexion();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "DELETE FROM [dbo].[TIENE]  WHERE [nombreU] = '" + usuario + "' AND [nombreJ] = '" + nombreJuego+"';";//Borra juego de un usuario concreto
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            orden.ExecuteScalar();
            con.Close();
        }
    }

}
