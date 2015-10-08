using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBox cbox = new ComboBox();
            cbox.Location = new Point(50, 50);
            cbox.Height = 100;
            cbox.Width = 100;
            cbox.Visible = true;
            cbox.Items.Add("1-5");
            cbox.Items.Add("6-10");
            cbox.Items.Add("11-15");
            cbox.SelectedIndex = 0;
            cbox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cbox);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int ind =0;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ind = 1;
                    break;
                case 1:
                    ind = 6;
                    break;
                case 2:
                    ind = 11;
                    break;
            }
            comboBox1.Items.Clear();
            String[] arr1 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
            for(int i = ind; i<ind+5; i++)
            {
                comboBox1.Items.Add(i);
            }

        }
    }
}
