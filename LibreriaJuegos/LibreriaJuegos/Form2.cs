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
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibreriaJuegos
{
    public partial class Form2 : Form
    {
        Form f;
        Form3 f3;
        ImageList il;
        String usuario;
        String contraseña;
        Boolean comprobacionJuego;
        Boolean juegoCom;
        String nombreFocus;
        public static String rutaResources = System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "../../Resources/");

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
                //il.Images.Add(Image.FromFile(rutaResources + j.foto + ".jpg"));
                il.Images.Add((Image)Resources.ResourceManager.GetObject(j.foto));
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
                //il.Images.Add(Image.FromFile(rutaResources + j.foto + ".jpg"));
                il.Images.Add((Image)Resources.ResourceManager.GetObject(j.foto));
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
           
            if (e.Button == MouseButtons.Right)
            {
                if (sender == lvLibreria)
                {
                    if (lvLibreria.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        nombreFocus = lvLibreria.FocusedItem.Text;
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }
                else if(sender == lvMiLista)
                {
                    if (lvMiLista.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        nombreFocus = lvMiLista.FocusedItem.Text;
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }
               
            }

        }

        //Cuando el elemento del menu secundario es pulsado (ver juego) se muestra el f3
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {          
            Juego juego = Datos.seleccionarJuegosCompleto(nombreFocus);
            juegoCom = false;
            foreach(ListViewItem i in lvMiLista.Items)
            {
                if(juego.nombre == i.Text)
                {
                    juegoCom = true;
                }
            }

            f3 = new Form3(juego, this, juegoCom);
            this.Hide();
            f3.Show();
        }

        public void adquirido(bool adquirido, String nombreJ)
        {
            //si cuando lo envie estaba comprado y ahora ya no es que lo ha eliminado de la lista
            if (juegoCom == true && adquirido == false)
            {
                Datos.borrarJuegoUsuario(nombreJ, usuario);
                cargarListaJuegosUsuario();
            }
            //si cualndo lo envie no estaba comprado y ahora si lo esta, habra que a;adirlo a la lista
            else if(juegoCom == false && adquirido == true)
            {
                Datos.insertarJuegoUsuario(nombreJ, usuario);
                cargarListaJuegosUsuario();
            }
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
            ((Control)pbBorrar).AllowDrop = false;
            lvMiLista.AllowDrop = true;
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

        private void lvMiLista_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lvMiLista_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ((Control)pbBorrar).AllowDrop = true;
            lvMiLista.AllowDrop = false;
            DoDragDrop(lvMiLista.SelectedItems, DragDropEffects.All);
        }

        private void pbBorrar_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void pbBorrar_DragDrop(object sender, DragEventArgs e)
        {
            ListView.SelectedListViewItemCollection coleccionlv = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
            foreach (ListViewItem item in coleccionlv)
            {
                Datos.borrarJuegoUsuario(item.Text, usuario);
                cargarListaJuegosUsuario();
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

        private void Form2_Load(object sender, EventArgs e)
        {
            ((Control)pbBorrar).AllowDrop = true;
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("corpex@programmer.net");
        }

        private void nETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(".NET Framework 4.5.2");
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("https://github.com/Corpexin");
        }
    }
}
