using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;
using System.Text.RegularExpressions;
using System.Reflection;

namespace notpad
{
    public partial class Form3 : Form
    {
        public static Form3 instance;


        public RichTextBox r2;

        public Form3()
        {
            InitializeComponent();
            instance = this;
            r2 = richTextBox2;
            richTextBox2.Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x1 = textBox1.Text;
            string x2 = textBox2.Text;
            string x3 = richTextBox2.Text;

            if (x3.Contains(x1))
            {
                int pos = x3.IndexOf(x1);

                x3 = x3.Substring(0, pos) + x2 + x3.Substring(pos + x1.Length);
                richTextBox2.Text = x3;
                Form1.instance.r1.Text= richTextBox2.Text ;

            }

            else
            {
                textBox1.Text = "not found";
                textBox2.Text = "";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
             
            Form1.instance.r1.SelectionBackColor = Color.White;


            if (textBox1.Text != "")
            {
                int index = 0;
                while (index < richTextBox2.TextLength)
                {
                    int start = richTextBox2.Find(textBox1.Text, index, richTextBox2.TextLength, RichTextBoxFinds.None);

                    if (start != -1)
                    {
                        Form1.instance.r1.SelectionStart = start;
                        Form1.instance.r1.SelectionLength = textBox1.Text.Length;
                        Form1.instance.r1.SelectionBackColor = Color.Pink;
                    }
                    else
                       break;
                    index = index + start + textBox1.Text.Length;

                }
               
            }
        }
    
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string x1 = textBox1.Text;
            string x2 = textBox2.Text;
           


            string x3 = richTextBox2.Text;
            if (x3.Contains(x1))
            {
                richTextBox2.Text = x3.Replace(x1, x2);
                Form1.instance.r1.Text = richTextBox2.Text;

            }
            else
            {
                textBox1.Text = "not found";
                textBox2.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
