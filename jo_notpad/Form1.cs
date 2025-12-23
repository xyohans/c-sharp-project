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

namespace jo_notpad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int lastSearchIndex = 0;

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            this.Text = "untitled";
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text=File.ReadAllText(ofd.FileName);
                this.Text= ofd.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (File.Exists(this.Text))
            {
                File.WriteAllText(this.Text, richTextBox1.Text);
                
            }
            
            else
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Text Files (*.txt)|*.txt";

                this.Text = saveFile.FileName;
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                   

                    File.WriteAllText(saveFile.FileName, richTextBox1.Text);
                }
            }
            //this.Text = saveFile.FileName;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            this.Text = saveFile.FileName;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                saveFile.Filter = "Text Files (*.txt)|*.txt";
                File.WriteAllText(saveFile.FileName, richTextBox1.Text);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Text!="notepad")
            {
                DialogResult r = MessageBox.Show("do u want to close the file there is unsaved file?");
                if (r == DialogResult.OK)
                {
                    if (File.Exists(this.Text))
                    {
                        File.WriteAllText(this.Text, richTextBox1.Text);
                        this.Text = "notepad";
                        richTextBox1.Text = "";
                    }
                    else
                    {
                        SaveFileDialog saveFile = new SaveFileDialog();
                        if (saveFile.ShowDialog() == DialogResult.OK)
                        {
                            saveFile.Filter = "Text Files (*.txt)|*.txt";
                            File.WriteAllText(saveFile.FileName, richTextBox1.Text);
                            this.Text = "notepad";
                            richTextBox1.Text = "";
                        }
                        this.Text = "notepad";
                        richTextBox1.Text = "";

                    }

                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Text) && File.Exists(this.Text) )
            {
                File.Delete(this.Text);
                this.Text = "notepad";
                richTextBox1.Text = string.Empty;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if(font.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font=font.Font;
            }
        }

        private void findTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible= true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;

            if (string.IsNullOrEmpty(searchText))
                return;

            int index = richTextBox1.Text.IndexOf(
                searchText,
                StringComparison.CurrentCultureIgnoreCase
            );

            if (index != -1)
            {
                richTextBox1.Select(index, searchText.Length);
                richTextBox1.ScrollToCaret();
                richTextBox1.Focus();
            }
            else
            {
                MessageBox.Show("Text not found", "Find");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;

            if (string.IsNullOrEmpty(searchText))
                return;

            int index = richTextBox1.Text.IndexOf(
                searchText,
                lastSearchIndex,
                StringComparison.CurrentCultureIgnoreCase
            );

            if (index != -1)
            {
                richTextBox1.Select(index, searchText.Length);
                richTextBox1.ScrollToCaret();
                richTextBox1.Focus();

                lastSearchIndex = index + searchText.Length;
            }
            else
            {
                MessageBox.Show("No more matches found.", "Find");
                lastSearchIndex = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;

            if (string.IsNullOrEmpty(searchText))
                return;

            int startIndex;

            // If nothing selected yet, start from end
            if (richTextBox1.SelectionStart == 0)
                startIndex = richTextBox1.Text.Length;
            else
                startIndex = richTextBox1.SelectionStart - 1;

            int index = richTextBox1.Text.LastIndexOf(
                searchText,
                startIndex,
                StringComparison.CurrentCultureIgnoreCase
            );

            if (index != -1)
            {
                richTextBox1.Select(index, searchText.Length);
                richTextBox1.ScrollToCaret();
                richTextBox1.Focus();

                lastSearchIndex = index;
            }
            else
            {
                MessageBox.Show("No previous matches found.", "Find");
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void zoomInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.ZoomFactor != 3.0f)
            {
                richTextBox1.ZoomFactor += 0.15f;
            }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.ZoomFactor != 0.5f)
            {
                richTextBox1.ZoomFactor -= 0.15f;
            }
        }
    }
}
