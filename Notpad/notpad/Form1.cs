using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Reflection;
using Font = System.Drawing.Font;
using word = Microsoft.Office.Interop;

namespace notpad
{
    public partial class Form1 : Form
    {
        public static Form1 instance;

        public RichTextBox r1;

        public Form1()
        {
            InitializeComponent();
            instance = this;
            fontDialog1.ShowColor = true;
            fontDialog1.ShowApply = true;
            fontDialog1.ShowEffects = true;
            fontDialog1.ShowHelp = true;
            r1 = richTextBox1;
           

        }
        //Stack<string> undo = new Stack<string>();
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void updoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            //    if (undo.Count < 1)
            //    {
            //        return;
            //    }
            //    richTextBox1.Text = undo.Pop();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = System.DateTime.Now.ToString();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = Path.Combine(@"c:\Users\Public\Documents\" + "richTextBox1.Text");
            File.WriteAllText(filepath, richTextBox1.Text);

        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "open";
            dialog.InitialDirectory = "decktop\\";
            dialog.Filter = "Text Documents(*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
            this.Text = dialog.FileName;

        }
        Document doc = new Document();
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog dialog = new SaveFileDialog();
            //dialog.Title = "save as";
            //dialog.Filter = "txt file|*.txt|pdf file|*.pdf|docx file|*.docx";
            //dialog.FileName = "trxt1";
            //dialog.InitialDirectory = "decktop\\";
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    File.WriteAllText(dialog.FileName, richTextBox1.Text);
            //}
            SaveFileDialog sft = new SaveFileDialog();
            dialog.Title = "save as";
            dialog.Filter = "txt file|*.txt|pdf file|*.pdf|docx file|*.docx";
            dialog.FileName = "trxt1";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PdfWriter.GetInstance(doc, new FileStream(dialog.FileName, FileMode.Create));
                doc.Open();
                doc.Add(new iTextSharp.text.Paragraph(richTextBox1.Text));
                doc.Close();
            }

        }


        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.WordWrap =false;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog();
            col.ShowDialog();
            richTextBox1.BackColor = col.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.Font = fontDialog1.Font;
                richTextBox1.ForeColor = fontDialog1.Color;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "save as";
            dialog.Filter = "txt file|*.txt|pdf file|*.pdf|docx file|*.docx";
            dialog.FileName = "trxt1";
            dialog.InitialDirectory = @"c:\decktop\";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, richTextBox1.Text);
            }
        }
            private void panel1_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "le" + richTextBox1.Lines.Length + " , Col" + richTextBox1.Text.Length;
        }



        private void newWindesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new Form();

            form2 = new Form1();
            form2.Show();


        }



        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            zoom +=0.1f;
            richTextBox1.ZoomFactor = zoom;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoom -= 0.1f;
            richTextBox1.ZoomFactor = zoom;
        }

        private void zoomVirtualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = 1;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        float zoom= 1;
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            zoom += 0.1f;
            richTextBox1.ZoomFactor = zoom;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           
            zoom -= 0.1f;
            richTextBox1.ZoomFactor = zoom;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Font f=new Font("arial",14,FontStyle.Bold);
            richTextBox1.Font = f;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Font f = new Font("arial",14, FontStyle.Underline);
            richTextBox1.Font = f;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Font f = new Font("arial", 14, FontStyle.Italic);
            richTextBox1.Font = f;
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is a diary programmed and designed by Asmaa Dalil");
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            richTextBox1.RightToLeft = RightToLeft.Yes;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            richTextBox1.RightToLeft = RightToLeft.No;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog();
            col.ShowDialog();
            richTextBox1.BackColor = col.Color;
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            Form3.instance.r2.Text = richTextBox1.Text;


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            string filepath = Path.Combine(@"c:\Users\Public\Documents\" + "richTextBox1.Text");
            File.WriteAllText(filepath, richTextBox1.Text);
        }
           
    }
}

