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
using System.ComponentModel;
using System.Security.Cryptography;
using System.IO;

namespace OpenGamesApp
{
    public partial class Form1 : Form
    {
        int click_counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenRL_Click(object sender, EventArgs e)
        {
            string item = listBox1.SelectedItem.ToString(); 
            
            Process.Start("c:\\Users\\kpell\\OneDrive\\Desktop\\Games\\"+item+".url");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm tt dddd, MMM dd");
            //ADD QUOTES

            string count_string = File.ReadAllText("Counter.txt");
            button1.Text = "Press me!\n"+count_string;
            click_counter = Convert.ToInt16(count_string);


            pictureBox1.Image = Image.FromFile("giphy.gif");
            pictureBox1.Show();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            FileInfo fileInfo = new FileInfo(desktopPath + @"\Games");

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);



            string path = desktopPath + @"\\Games";
            int count = path.Length;
            string[] files = System.IO.Directory.GetFiles(desktopPath + @"\Games");
            foreach(string file in files)
            {
                string name = file.Substring(count);
                string[] nameSplit = name.Split('.');
                listBox1.Items.Add(nameSplit[0]);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            click_counter = click_counter + 1;
            button1.Text = "Press me!\n" + click_counter.ToString();
        }

        private void Form1_closing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("Counter.txt", click_counter.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttonMessage = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("You weally wanna reset? :(", "DONT DO IT PLEASE", buttonMessage);
            if (result == DialogResult.Yes)
            {
                click_counter = 0;
                button1.Text = "Press me!\n" + click_counter.ToString();
            }
            else
            {
                
            }
        }



        private void form_key(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == ' ')
            {
                e.Handled = true;
                button1.PerformClick();
            }
        }
    }
}
