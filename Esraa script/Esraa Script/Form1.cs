using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.goldparser;

namespace Esraa_Script
{
    public partial class Esraa_Script : Form
    {
        MyParser p;
        public Esraa_Script()
        {
            InitializeComponent();
            p = new MyParser("Esraa Script.cgt",listBox1,listBox2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            p.Parse(textBox1.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
