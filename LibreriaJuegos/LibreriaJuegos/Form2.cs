using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaJuegos
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        ArrayList listaGeneros;
        public Form2()
        {
            InitializeComponent();
            conexionBD();
            cargarGeneros();
            //cargarJuegosUsuario();
        }

        private void conexionBD()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BaseDatos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        //Carga los generos de la base de datos
        private void cargarGeneros()
        {
           
            con.Open();
            //
            SqlCommand orden = new SqlCommand();
            orden.CommandText = "SELECT DISTINCT [generoJ] FROM [dbo].[JUEGO];";//Carga todos los generos diferentes que se encuentran en los juegos
            orden.CommandType = CommandType.Text; 
            orden.Connection = con;
            SqlDataReader reader = orden.ExecuteReader();
            while (reader.Read())
            {
                cbGenero.Items.Add(reader[0].ToString());//Se agregan los resultados de la consulta al combobox
            }
            con.Close();

 
            

        }

        private void cargarJuegosUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
