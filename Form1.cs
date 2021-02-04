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
using System.Text.RegularExpressions;
namespace NotepadGpn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "text files|*.txt|all files|*.*";
           DialogResult dr= ofd.ShowDialog();

           if (dr == DialogResult.OK)
           {
               richTextBox1.Text = File.ReadAllText(ofd.FileName);
           }

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            File.WriteAllText(sfd.FileName, richTextBox1.Text);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "text files|*.txt|all files|*.*";
           DialogResult dr= ofd.ShowDialog();

           if (dr == DialogResult.OK)
           {
               StreamReader sr = new StreamReader(ofd.FileName);
               richTextBox1.Text= sr.ReadToEnd();
               sr.Close();
           }
        }

        private void saveToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            StreamWriter sw = new StreamWriter(sfd.FileName);
            string[] lines = richTextBox1.Text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                sw.WriteLine(lines[i]);
            }
            sw.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s=richTextBox1.SelectedText;
            Clipboard.SetText(s);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = Clipboard.GetText();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = richTextBox1.SelectedText;
            Clipboard.SetText(s);
            richTextBox1.SelectedText = "";
        }

        private void mobileNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input= richTextBox1.Text;
            string pattern = "[0-9]{10}"; // "[A-Z][0-9]"
            Regex reg = new Regex(pattern);
           string output="";
            Match m=reg.Match(input);

            while(m.Success)
            {
                output=output+m.Value+"\n";
                m = m.NextMatch();
            }

            richTextBox2.Text = output;
        }

        private void rEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
