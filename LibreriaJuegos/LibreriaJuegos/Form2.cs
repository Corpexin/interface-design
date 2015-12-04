using LibreriaJuegos.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaJuegos
{
    public partial class Form2 : Form
    {
        Form f;
        Form3 f3;
        SqlConnection con;
        ArrayList listaGeneros;
        ImageList il;
        String usuario;
        String contraseña;
        int index;
        Boolean comprobacionJuego;

        public Form2(Form form, String user, String pass)
        {
            f = form;
            usuario = user;
            contraseña = pass;
            InitializeComponent();
            cargarGeneros();
            cargarJuegos(Datos.seleccionarJuegos("", ""));
            cargarListaJuegosUsuario();
            menuStrip.ForeColor = Color.Gray;
            index = 0;
            lblListaUsuario.Text = "Lista de " + user;
            comprobacionJuego = false;
        }

        //Carga los generos de la base de datos
        private void cargarGeneros()
        {
            ArrayList lista = Datos.seleccionarGeneros();
            cbGenero.Items.Add("TODOS");
            foreach(String s in lista){cbGenero.Items.Add(s); }//Se agregan los resultados de la consulta al combobox
            cbGenero.SelectedItem = "TODOS";
        }

        private void cargarJuegos(ArrayList lista)
        {
            lvLibreria.Clear();
            int cont = 0;
            il = new ImageList();
            il.ImageSize = new Size(120, 56);

            //Cambiar por ruta relativa
            foreach (Juego j in lista)
            {
                il.Images.Add(Image.FromFile(@"C:\Users\Corpex\Documents\GitHub\interface-design\LibreriaJuegos\LibreriaJuegos\Resources\" + j.foto + ".jpg"));
            }

            lvLibreria.LargeImageList = il;
            lvLibreria.SmallImageList = il;

            foreach (Juego j in lista)
            {
                lvLibreria.Items.Add(new ListViewItem() {ImageIndex=cont, Text = j.nombre});
                cont++;
            }
        }

        //Carga los juegos de la lista que tenga el usuario
        private void cargarListaJuegosUsuario()
        {
            il = new ImageList();
            lvMiLista.Clear();
            int cont = 0;
            ArrayList lista = Datos.seleccionarJuegos(usuario, "");
            il.ImageSize = new Size(80, 32);

            //Cambiar por ruta relativa
            foreach (Juego j in lista)
            {
                il.Images.Add(Image.FromFile(@"C:\Users\Corpex\Documents\GitHub\interface-design\LibreriaJuegos\LibreriaJuegos\Resources\" + j.foto + ".jpg"));
            }
           
            lvMiLista.LargeImageList = il;
            lvMiLista.SmallImageList = il;

            foreach (Juego j in lista)
            {
                lvMiLista.Items.Add(new ListViewItem() { ImageIndex = cont, Text = j.nombre });
                cont++;
            }

        }

        //Metodo que muestra el siguiente formulario con la informacion de la carta cuando se hace click en un elemento
        private void entrarEnCarta(object sender, MouseEventArgs e)
        {
            f3 = new Form3();
            f3.Show();
        }

        private void cbGenero_SelectedValueChanged(object sender, EventArgs e)
        {
            string genero = cbGenero.SelectedItem.ToString();
            if (genero == "TODOS")
                genero = "";
            cargarJuegos(Datos.seleccionarJuegos("", genero));
        }



        //Drag&Drop
        private void lvLibreria_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lvLibreria_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(lvLibreria.SelectedItems, DragDropEffects.All);
        }

        private void lvMiLista_DragDrop(object sender, DragEventArgs e)
        {
            ListView.SelectedListViewItemCollection coleccionlv = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
            foreach (ListViewItem item in coleccionlv)
            {
                //Comprueba si ya existe el juego en la lista de usuario
                comprobarJuego(item);
                if (comprobacionJuego == false)
                {
                    Datos.insertarJuegoUsuario(item.Text, usuario);//insertamos los juegos dropeados en la lista de usuario
                    cargarListaJuegosUsuario();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("El juego ya se encuentra en tu lista");
                }

            }
        }

        private void comprobarJuego(ListViewItem item)
        {
            comprobacionJuego = false;
            ArrayList lista = Datos.seleccionarJuegos(usuario, ""); //saca los juegos de la lista del usuario
            foreach (Juego j in lista)
            {
                if(item.Text == j.nombre)//si el nombre de los juegos coincide con el nombre del juego dropeado no deja
                {
                    comprobacionJuego = true;
                }
            }
        }

        private void lvMiLista_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            f.Show();
            this.Close();
        }

        private void pbFlechaDer_Click(object sender, EventArgs e)
        {
            lvMiLista.Focus();
            SendKeys.Send("{Right}");
        }

        private void pbFlechaIzq_Click(object sender, EventArgs e)
        {
            lvMiLista.Focus();
            SendKeys.Send("{Left}");
        }

        private void programaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Libreria Juegos de Steam\nVersion 1.0 Beta");
        }

        private void sQLServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Microsoft SQL Server 12.0.2000 Express Edition(64 - bit)");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lvLibreria.Focus();
            SendKeys.Send("{Up}");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            lvLibreria.Focus();
            SendKeys.Send("{Down}");
        }


    }
}
