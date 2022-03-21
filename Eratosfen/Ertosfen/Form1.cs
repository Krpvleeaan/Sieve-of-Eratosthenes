using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ertosfen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {}
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {}
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {}
        private void button1_Click(object sender, EventArgs e)
        {
            int input;
            richTextBox2.Text = "";
            if (Int32.TryParse(richTextBox1.Text, out input) == false)
            {
                MessageBox.Show("Некорректное число");
                return;
            }
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Введите число");
                return;
            }
            if (input < 2)
                return;
            if (input == 2) 
            {
                richTextBox2.Text += "2";
                return;
            }
            if (input <= 4)
            {
                richTextBox2.Text += "2 3";
                return;
            }
            if (input <= 5)
            {
                richTextBox2.Text += "2 3 5";
                return;
            }
            if (input > 2147483590)
            {
                MessageBox.Show("Вы ввели слишком большое число");
                return;
            }
            DateTime starttime = DateTime.Now;
            int n = Convert.ToInt32(richTextBox1.Text);
            richTextBox2.Text = "";
            bool[] A = new bool[n + 1];
            for (int i = 2; i < n + 1; i++)
                A[i] = true;
            for (int i = 2; i < Math.Sqrt(n + 1) + 1; ++i)
            {
                if (A[i])
                {
                    for (int j = i * i; j < n + 1; j += i)
                    {
                        A[j] = false;
                    }
                }
            }
            StreamWriter wr = new StreamWriter("temp.txt");
            for (int i = 2; i < n + 1; i++)
            {
                if (A[i])
                {
                    wr.Write(i.ToString() + ' ');
                }
            }
            wr.Close();
            StreamReader rd = new StreamReader("temp.txt");
            richTextBox2.Text = rd.ReadToEnd();
            rd.Close();
            DateTime endtime = DateTime.Now;
            MessageBox.Show("Выполнено");
            MessageBox.Show((endtime - starttime).ToString());
        }
        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
