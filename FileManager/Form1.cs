using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MetroFramework.Components;

namespace FileManager
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MetroStyleManager metroStyleManager = null;
            this.StyleManager = metroStyleManager;
        }

        private void metroButton1_Click(object sender, EventArgs e) // кнопка next
        {
            listBox1.Items.Clear();
            DirectoryInfo a = new DirectoryInfo(metroTextBox1.Text);
            DirectoryInfo[] b = a.GetDirectories();
            foreach (DirectoryInfo c in b)
            {
                listBox1.Items.Add(c);
            }
            FileInfo[] q = a.GetFiles(); // отображиение файлов
            foreach (FileInfo w in q) // вывод файлов на экран
            {
                listBox1.Items.Add(w);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e) // кнопка back
        {
            if (metroTextBox1.Text[metroTextBox1.Text.Length - 1] == '\\')  // удаляем слеши из адреса
            {
                metroTextBox1.Text = metroTextBox1.Text.Remove(metroTextBox1.Text.Length - 1, 1); // удаляем символ
                while (metroTextBox1.Text[metroTextBox1.Text.Length - 1] != '\\')
                {
                    metroTextBox1.Text = metroTextBox1.Text.Remove(metroTextBox1.Text.Length - 1, 1);
                }
            }
            else if (metroTextBox1.Text[metroTextBox1.Text.Length - 1] != '\\')
            {
                while (metroTextBox1.Text[metroTextBox1.Text.Length - 1] != '\\')
                {
                    metroTextBox1.Text = metroTextBox1.Text.Remove(metroTextBox1.Text.Length - 1, 1);
                }
            }

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (Path.GetExtension(Path.Combine(metroTextBox1.Text, listBox1.SelectedItem.ToString())) == "")
            {
                metroTextBox1.Text = Path.Combine(metroTextBox1.Text, listBox1.SelectedItem.ToString());
                listBox1.Items.Clear();
                DirectoryInfo a = new DirectoryInfo(metroTextBox1.Text);
                DirectoryInfo[] b = a.GetDirectories();
                foreach (DirectoryInfo c in b)
                {
                    listBox1.Items.Add(c);
                }
                FileInfo[] q = a.GetFiles();
                foreach (FileInfo w in q)
                {
                    listBox1.Items.Add(w);
                }

            }
            else
            {
                Process.Start(Path.Combine(metroTextBox1.Text, listBox1.SelectedItem.ToString()));
            }
        }
    } }

