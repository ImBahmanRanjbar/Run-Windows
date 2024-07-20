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

namespace Run
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
            Process.Start(comboBox1.Text);
            comboBox1.Items.Remove(comboBox1.Text);
            comboBox1.Items.Add(comboBox1.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        
        }

        private void btnbrow_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            op.Title = "Browse  ";
            comboBox1.Text = op.FileName;
        }
     

       
        private void Form1_Load(object sender, EventArgs e)
        {
          
            if (!File.Exists(Application.StartupPath+"applist.txt"))
            {
                File.CreateText(Application.StartupPath + "applist.txt");

            }
            else
            {
                string[] list = File.ReadAllLines(Application.StartupPath + "applist.txt");
                for (int i = 0; i < list.Length; i++)
                {
                    comboBox1.Items.Add(list[i]);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            string[] list = new string[comboBox1.Items.Count];
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                list[i] = comboBox1.Items[i].ToString();
            }
                File.WriteAllLines(Application.StartupPath + "applist.txt", list);
        }
    }
}
