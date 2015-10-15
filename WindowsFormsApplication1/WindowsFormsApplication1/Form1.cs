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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int pos=50;
        int cont = 0;
       // ArrayList lista = new ArrayList();
        Random rnd = new Random();                          
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /**
            if(checkBox1.Checked == true && checkBox2.Checked == true)
            {
                checkBox3.Checked = false;
            }
            else if(checkBox1.Checked == true && checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
            }
            else
            {
                if (checkBox2.Checked == false)
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox3.Checked = true;
                }
            }
            **/
            if (checkBox1.Checked == false)
                checkBox1.Checked = true;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked == false && checkBox1.Checked == true)
                checkBox2.Checked = true;
            else if (checkBox2.Checked == true && checkBox1.Checked == false)
                checkBox2.Checked = false;
            /**
            if (checkBox2.Checked == true && checkBox1.Checked == true)
            {
                checkBox3.Checked = false;
            }
            else if (checkBox2.Checked == true && checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
            }
            else
            {
                if (checkBox1.Checked == false)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox3.Checked = true;
                }
            }
            **/

            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false && checkBox2.Checked == true && checkBox1.Checked == true)
                checkBox3.Checked = true;
            else if (checkBox3.Checked == true && checkBox1.Checked == false && checkBox2.Checked == false)
                checkBox3.Checked = false;
            else if (checkBox3.Checked == true && checkBox1.Checked == true && checkBox2.Checked == false)
                checkBox3.Checked = false;

            /**
            if (checkBox3.Checked == true && checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
            else if (checkBox3.Checked == true && checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
            else
            {
                if (checkBox2.Checked == false)
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox1.Checked = true;
                }
            }
             **/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cont<10)
            {
                CheckBox cb = new CheckBox();
                cb.Visible = true;
                cb.Text = "TextBox" + pos;
                cb.Location = new Point(rnd.Next(500), rnd.Next(500));
                pos = pos + 30;
                this.Controls.Add(cb);
               // lista.Add(cb);
                cont++;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            /**
           foreach(CheckBox cb in lista)
            {
                cb.Checked = false;
            }
            **/
            foreach (Object o in Controls)
            {
                if (o is CheckBox)
                {
                    ((CheckBox)o).Checked = false;
                }

            }
        }
    }
}
