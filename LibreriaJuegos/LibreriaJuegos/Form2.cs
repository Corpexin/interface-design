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
        Form3 f3;
        SqlConnection con;
        ArrayList listaGeneros;
        ImageList il;
        String usuario;
        String contraseña;

        public Form2(String user, String pass)
        {
            usuario = user;
            contraseña = pass;
            InitializeComponent();
            cargarGeneros();
            cargarJuegos();
            cargarListaJuegosUsuario();
        }

        //Carga los generos de la base de datos
        private void cargarGeneros()
        {
            ArrayList lista = Datos.seleccionarGeneros();
            foreach(String s in lista){cbGenero.Items.Add(s); }//Se agregan los resultados de la consulta al combobox
        }

        private void cargarJuegos()
        {
            int cont = 0;
            il = new ImageList();
            ArrayList lista = Datos.seleccionarJuegos();//Obtengo de la bd la lista completa de juegos
            il.ImageSize = new Size(90, 42);
            String[] imageFiles = Directory.GetFiles(@"C:\Users\Corpex\Documents\GitHub\interface-design\LibreriaJuegos\LibreriaJuegos\Resources");
                //Cambiar por ruta relativa

            foreach(var file in imageFiles)
            {
                il.Images.Add(Image.FromFile(file));
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
            int cont = 0;
            ArrayList lista = Datos.seleccionarListaJuegosUsuario(usuario);
            il.ImageSize = new Size(90, 42);
            String[] imageFiles = Directory.GetFiles(@"C:\Users\Corpex\Documents\GitHub\interface-design\LibreriaJuegos\LibreriaJuegos\Resources");
            
            //Cambiar por ruta relativa
            foreach (var file in imageFiles)
            {
                il.Images.Add(Image.FromFile(file));
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
            this.Hide();
            f3 = new Form3();
            f3.Show();
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
                //insertamos aqui en la base de datos los datos y actualizamos el listview
                lvMiLista.Items.Add((ListViewItem)item.Clone());
            }
        }

        private void lvMiLista_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
