using LibreriaJuegos.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaJuegos
{
    public partial class Form3 : Form
    {
        Juego j;
        Form2 f2;
        Boolean adquirido;

        public Form3(Juego juego, Form2 f2, Boolean adquirido)
        {
            InitializeComponent();
            j = juego;
            this.adquirido = adquirido;
            iniciarCampos();
            this.f2 = f2;
        }

        //se acoplan los datos de cada juego a cada campo e inicializan los componentes
        private void iniciarCampos()
        {
            lblTitulo.Text = j.nombre;
            lblGenero.Text = j.genero;
            lblDescrip.Text = j.descripcion;
            lblDescrip.Enter += noFocus_Enter;
            lblGenero.Enter += noFocus_Enter;
            lblTitulo.Enter += noFocus_Enter;
            pbFoto.Image = (Image)Resources.ResourceManager.GetObject(j.foto);
            if (adquirido == true)
            {
                pbAdquirir.Image = Resources.rubbish;
            }
            else
            {
                pbAdquirir.Image = Resources.shopping232__1_;
            }
        }

        //Al desviar el foco, los textbox pierden la funcionalidad y permanecen como simples labels
        private void noFocus_Enter(object sender, EventArgs e)
        {
            pbFoto.Focus();
        }

        //Cierra el formulario y muestra el 2, devolviendole los cambios realizados
        private void pbCerrar_Click(object sender, EventArgs e)
        {
            f2.adquirido(adquirido, j.nombre);
            f2.Show();
            this.Close();
        }

        //Accion al comprar/ eliminar de la lista un juego en concreto
        private void pbAdquirir_Click(object sender, EventArgs e)
        {
            if(adquirido == true)
            {
                adquirido = false;
                pbAdquirir.Image = Resources.shopping232__1_;
            }
            else
            {
                adquirido = true;
                pbAdquirir.Image = Resources.rubbish;
            }
        }
    }
}
