using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            if(i == 50)
            {
                i = 0;
            }
            label1.Text = i.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop(); 
            if(i>=0 && i <= 10 && checkBox1.Checked)
            {
                textBox2.Text = checkBox1.Text;
                textBox1.Text = i.ToString();
            }
            else if (i > 10 && i <= 20 && checkBox5.Checked)
            {
                textBox2.Text = checkBox5.Text;
                textBox1.Text = i.ToString();
            }
            else if (i > 20 && i <= 30 && checkBox4.Checked)
            {
                textBox2.Text = checkBox4.Text;
                textBox1.Text = i.ToString();
            }
            else if (i >30 && i <= 40 && checkBox3.Checked)
            {
                textBox2.Text = checkBox3.Text;
                textBox1.Text = i.ToString();
            }
            else if (i > 40 && checkBox2.Checked)
            {
                textBox2.Text = checkBox2.Text;
                textBox1.Text = i.ToString();
            }
            else
            {
                textBox1.Text = i.ToString();
                textBox2.Text = "";
            }
            i = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
