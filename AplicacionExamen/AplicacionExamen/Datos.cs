using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionExamen
{
    static class Datos
    {
        //Creo la conexion general con la que se va a trabajar
        internal static SqlConnection conexion()
        {
            //añadida referencia system.configuration
            SqlConnection con = new SqlConnection();
            //Con este metodo, puedo cambiar el datadirectory a la carpeta donde realmente esta la base de datos.
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "../.."));
            con.ConnectionString = Properties.Settings.Default.BDEx;
            //con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Corpex\\Documents\\GitHub\\interface-design\\LibreriaJuegos\\LibreriaJuegos\\BaseDatos\\BDSteam.mdf;Integrated Security=True;Connect Timeout=30";
            return con;
        }

        internal static ArrayList sacarDientesCaidos(String nombreNiño)
        {
            String query = "SELECT numDientes FROM Cae, Niño WHERE Cae.id_N = Niño.id_N AND Niño.nombre_N = '"+nombreNiño+"'";

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
                lista.Add(reader[0].ToString());
            }
            con.Close();
            return lista;
        }

        internal static ArrayList sacarProgenitores()
        {
            String query = "SELECT nombre_p FROM Progenitor";
            
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
                lista.Add(reader[0].ToString());
            }
            con.Close();
            return lista;

        }

        internal static ArrayList sacarNiños(String progenitor)
        {
            String query = "SELECT nombre_N FROM Niño, esPadre, Progenitor WHERE Progenitor.nombre_p = '"+progenitor+"' AND Niño.id_N = esPadre.id_N  AND Progenitor.idP = esPadre.id_P";

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
                lista.Add(reader[0].ToString());
            }
            con.Close();
            return lista;

        }

        //Metodo para comprobar hay progrenitores en la base de datos
        internal static int comprobarDatos(int n)
        {
            String query="";
            switch (n)
            {
                case 1://progenitor
                    query = "SELECT COUNT(*) FROM Progenitor;";
                    break;
                case 2://niño
                    query = "SELECT COUNT(*) FROM Niño;";
                    break;
                case 3://espadre
                    query = "SELECT COUNT(*) FROM esPadre;";
                    break;
                case 4://cae
                    query = "SELECT COUNT(*) FROM Cae;";
                    break;
            }
            SqlConnection con = conexion();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = query;
            orden.CommandType = CommandType.Text; 
            orden.Connection = con;
            int datos = (int)orden.ExecuteScalar();
            con.Close();
            return datos;
        }

        internal static int consultarFecha(string f)
        {
            String query = "SELECT COUNT(fecha) FROM Cae WHERE fecha = '"+f+"'";
            SqlConnection con = conexion();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = query;
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            int datos = (int)orden.ExecuteScalar();
            con.Close();
            return datos;
        }

        internal static int sacarIdNiños(string text)
        {
            String query = "SELECT id_N FROM Niño WHERE Niño.nombre_N = '"+text+"'";
            SqlConnection con = conexion();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = query;
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            int datos = (int)orden.ExecuteScalar();
            con.Close();
            return datos;
        }

        internal static void insertarDienteCaido(String numDiente, int idN, string fecha)
        {
            String query = "INSERT INTO [dbo].[Cae] ([id_N], [numDientes], [fecha]) VALUES (N'"+idN+"', N'"+numDiente+"', N'"+fecha+"')";
            SqlConnection con = conexion();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = query;
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            orden.ExecuteScalar();
            con.Close();
        }

        //Metodo para insertar usuario/contraseña en base de datos
        internal static void insertarDatos(int n, String[] datos)
        {
            String query = "";
            switch (n)
            {
                case 1://progenitor
                    query = "INSERT INTO [dbo].[Progenitor] ([idP], [nombre_p]) VALUES (N'"+datos[0]+"', N'"+datos[1]+"')";
                    break;
                case 2://niño
                    query = "INSERT INTO [dbo].[Niño] ([id_N], [nombre_N], [ciudad_N]) VALUES (N'" + datos[0] + "', N'" + datos[1] + "', N'"+datos[2]+"')";
                    break;
                case 3://espadre
                    query = "INSERT INTO [dbo].[esPadre] ([id_P], [id_N]) VALUES (N'" + datos[0] + "', N'" + datos[1] + "')";
                    break;
                case 4://cae
                    query = "INSERT INTO [dbo].[Cae] ([id_N], [numDientes], [fecha]) VALUES (N'" + datos[0] + "', N'" + datos[1] + "', N'"+datos[2]+"')";
                    break;
            }
            SqlConnection con = conexion();
            con.Open();
            SqlCommand orden = new SqlCommand();
            orden.CommandText = query;
            orden.CommandType = CommandType.Text;
            orden.Connection = con;
            orden.ExecuteScalar();
            con.Close();
        }

      
    }

}

