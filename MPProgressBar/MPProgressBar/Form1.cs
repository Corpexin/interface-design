using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPProgressBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(progressBar1.Value<100)
                progressBar1.Value = progressBar1.Value + 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(progressBar1.Value>0)
                progressBar1.Value = progressBar1.Value - 10;
        }


        private void progressBar1_MouseClick(object sender, MouseEventArgs e)
        {
            // if (e.X > progressBar1.Size.Width/2)
            //if(e.X/2>progressBar1.Value)
            //{
            //if (progressBar1.Value < 100) 
            //progressBar1.Value = progressBar1.Value + 10;
            // }
            // else
            // {
            // if (progressBar1.Value > 0)
            // progressBar1.Value = progressBar1.Value - 10;
            // }
            progressBar1.Maximum = progressBar1.Size.Width;
            if (progressBar1.Value <= progressBar1.Maximum && progressBar1.Value >= 0)
                progressBar1.Value =  e.Location.X;
        }
    }
}
