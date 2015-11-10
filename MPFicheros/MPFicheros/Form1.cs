using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPFicheros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbRaza.Items.Add("Humano");
            cbRaza.Items.Add("Orco");
            cbRaza.Items.Add("Goblins");
        }

        private void cbRaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProfesion.Items.Clear();
            switch (cbRaza.SelectedIndex)
            {
                case 0:
                    cbProfesion.Items.Add("Arquero");
                    cbProfesion.Items.Add("Guerrero");
                    cbProfesion.Items.Add("Herrero");
                    break;
                case 1:
                    cbProfesion.Items.Add("Lancero");
                    cbProfesion.Items.Add("Peletero");
                    cbProfesion.Items.Add("Peluquero");
                    break;
                case 2:
                    cbProfesion.Items.Add("Banquero");
                    cbProfesion.Items.Add("Ingeniero");
                    cbProfesion.Items.Add("Minero");
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            

            String[] lines = { ""+cbRaza.SelectedItem, ""+cbProfesion.SelectedItem };
            StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory+"\\SavePJ.txt");
            foreach (string line in lines)
            {
                file.WriteLine(line);
                    
             }
            file.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\SavePJ.txt");
            cbRaza.SelectedItem = lines[0];
            cbProfesion.SelectedItem = lines[1];
        }
    }
}
