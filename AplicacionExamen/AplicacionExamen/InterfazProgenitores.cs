using AplicacionExamen.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AplicacionExamen
{
    public partial class InterfazProgenitores : Form
    {
        String usuario;

        public InterfazProgenitores(String nombreUsuario)
        {
            InitializeComponent();
            usuario = nombreUsuario;
        }

        private void InterfazProgenitores_Load(object sender, EventArgs e)
        {
            cargarComboboxNiño();
            cargarLvDientesBoca();

        }

        //BOCA DIENTES
        private void cargarLvDientesBoca()
        {

            ImageList il = new ImageList();
            //il.ImageSize = new Size(120, 56);


            il.Images.Add(Resources.dientePeq);
            lvDientesEnBoca.LargeImageList = il;
            lvDientesEnBoca.SmallImageList = il;

            for(int i=1; i<=32; i++)
            {
                lvDientesEnBoca.Items.Add(new ListViewItem() { ImageIndex = 0 , Text = ""+i });
            }
            
        }



        //SI CAMBIA DE NIÑO SE CARGAN SUS DIENTES
        private void cbNombreNiño_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbNombreNiño.SelectedItem != null)
            {
                cargarLvDientesCaidos(true);
            }
        }

        //DIENTES CAIDOS
        private void cargarLvDientesCaidos(Boolean b)
        {

            lvDientesCaidos.Clear();
            ImageList il = new ImageList();
            //il.ImageSize = new Size(120, 56);

                
            il.Images.Add(Resources.dientePeq);
            lvDientesCaidos.LargeImageList = il;
            lvDientesCaidos.SmallImageList = il;


            ArrayList dientesCaidos = Datos.sacarDientesCaidos(cbNombreNiño.SelectedItem.ToString());
            //Añadimos los dientes 
            foreach (String s in dientesCaidos)
            {
                lvDientesCaidos.Items.Add( new ListViewItem() { ImageIndex = 0, Text = s});
            }
        }


        //NIÑOS
        private void cargarComboboxNiño()
        {
            ArrayList nombresNiños = Datos.sacarNiños(usuario);
            //Añadimos los progenitores
            foreach (String s in nombresNiños)
            {
                cbNombreNiño.Items.Add(s);
            }
        }


        private void lvDientesEnBoca_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(lvDientesEnBoca.SelectedItems, DragDropEffects.All);
        }

        private void lvDientesEnBoca_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lvDientesCaidos_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lvDientesCaidos_DragDrop(object sender, DragEventArgs e)
        {
            DateTime fecha = DateTime.Now;
            String f = ""+fecha.Year + fecha.Month + fecha.Day;
            //hago consulta a ver cuantas fechas para hoy hay
            while (Datos.consultarFecha(f)>5)
            {
                fecha = fecha.AddDays(1);
                f = "" + fecha.Year + fecha.Month + fecha.Day;
            }
            //si hay + de 5 aumento en uno la fecha

            //sino la agrego
            ListView.SelectedListViewItemCollection coleccionlv = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
            if(cbNombreNiño.SelectedItem != null)
            {
                foreach (ListViewItem item in coleccionlv)
                {
                    //Comprueba si ya existe
                    if (comprobacionDiente(item) == false)
                    {
                        int idNiño = Datos.sacarIdNiños(cbNombreNiño.SelectedItem.ToString());
                        Datos.insertarDienteCaido(item.Text, idNiño, f);
                                                                                 
                        cargarLvDientesCaidos(false);
                        addTicket(cbNombreNiño.SelectedItem.ToString(), item.Text, f);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("El diente ya esta caido");
                    }

                }
            }
        }

        private void addTicket(string nombreNiño, string numDiente, string fecha)
        {
            lvTickets.Items.Add(nombreNiño+"        "+numDiente+"       "+fecha);
        
        }

        private bool comprobacionDiente(ListViewItem item)
        {
            Boolean result = false;
            String s = item.Text;

            foreach(ListViewItem it in lvDientesCaidos.Items)
            {
                if(s == it.Text)
                {
                    result = true;
                }
            }

            return result;
        }



    }

}
