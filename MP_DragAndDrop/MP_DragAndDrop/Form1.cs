using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP_DragAndDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(textBox1.Text, DragDropEffects.All);
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            textBox1.Text = (String)e.Data.GetData(DataFormats.Text);
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(textBox2.Text, DragDropEffects.All);
        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            textBox2.Text = (String)e.Data.GetData(DataFormats.Text);
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(textBox3.Text, DragDropEffects.All);
        }

        private void textBox3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void textBox3_DragDrop(object sender, DragEventArgs e)
        {
            textBox3.Text = (String)e.Data.GetData(DataFormats.Text);
        }


        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(listBox1.SelectedItem, DragDropEffects.All);
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.Items.Add((String)e.Data.GetData(DataFormats.Text));
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = (String)e.Data.GetData(DataFormats.Text);
            lvi.SubItems.Add("pepe");
            listView1.Items.Add(lvi);
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(listView1.SelectedItems, DragDropEffects.All);
        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            ListView.SelectedListViewItemCollection coleccionlv = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
            foreach( ListViewItem item in coleccionlv)
            {
                listView2.Items.Add((ListViewItem) item.Clone());
            }
        }

        private void listView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }


    }
}
