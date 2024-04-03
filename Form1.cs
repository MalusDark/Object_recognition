using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace II_4
{
    public partial class Form1 : Form
    {
        int x1, y1, x2, y2;
        private Bitmap bmp;
        private Pen blackPen;
        static double[] p = new double[4];

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(50, 50);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            x2 = Convert.ToInt32(e.X); 
            y2 = Convert.ToInt32(e.Y); 
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                blackPen = new Pen(Color.Black, comboBox1.SelectedIndex);
                g.DrawLine(blackPen, x1, y1, x2, y2);
                blackPen.Dispose();
            }
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();
            x1 = x2;
            y1 = y2;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = Convert.ToInt32(e.X);
            y1 = Convert.ToInt32(e.Y);
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                blackPen = new Pen(Color.Black, comboBox1.SelectedIndex);
                g.DrawLine(blackPen, x1, y1, x2, y2);
                blackPen.Dispose();
            }
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();
            x1 = x2;
            y1 = y2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialog1.FileName;
            MessageBox.Show("Файл открыт");
            pictureBox1.Image = Image.FromFile(filename);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            pictureBox1.Image = null;
            bmp = new Bitmap(50, 50);
            for(int i = 0; i<4; i++)
            {
                p[i] = 0;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int[] counter = new int[4];
            for (int k = 1; k <= 5; k++)
            {
                Bitmap drawlink = new Bitmap(pictureBox1.Image);
                Bitmap load = new Bitmap(Image.FromFile("C:\\Users\\artem\\source\\repos\\II_4\\training_data\\O\\O_" + Convert.ToString(k) + ".png"));

                for (int i = 0; i < 50; i++)
                    for (int j = 0; j < 50; j++)
                    {
                        if (drawlink.GetPixel(i, j) != load.GetPixel(i, j))
                            counter[1]++;
                    }
                p[1] += 1000.0 / (1.0 + counter[1] * counter[1]);
            }

            listBox1.Items.Add($"Расстояние по Хэммингу: {counter[1]}");
            listBox1.Items.Add($"Потенциал {p[1]}, что это буква O");
            listBox1.Items.Add("");
            for (int k = 1; k <= 5; k++)
            {
                Bitmap drawlink = new Bitmap(pictureBox1.Image);
                Bitmap load = new Bitmap(Image.FromFile("C:\\Users\\artem\\source\\repos\\II_4\\training_data\\C\\C_" + Convert.ToString(k) + ".png"));

                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        if (drawlink.GetPixel(i, j) != load.GetPixel(i, j))
                        {
                            counter[0]++;
                        }
                    }
                    p[0] += 1000.0 / (1.0 + counter[0] * counter[0]);
                }
            }

            listBox1.Items.Add($"Расстояние по Хэммингу: {counter[0]}");
            listBox1.Items.Add($"Потенциал {p[0]}, что это буква C");
            listBox1.Items.Add("");

            for (int k = 1; k <= 5; k++)
            {
                Bitmap drawlink = new Bitmap(pictureBox1.Image);
                Bitmap load = new Bitmap(Image.FromFile("C:\\Users\\artem\\source\\repos\\II_4\\training_data\\P\\П_" + Convert.ToString(k) + ".png"));

                for (int i = 0; i < 50; i++)
                    for (int j = 0; j < 50; j++)
                    {
                        if (drawlink.GetPixel(i, j) != load.GetPixel(i, j))
                            counter[2]++;
                    }
                p[2] += 1000.0 / (1.0 + counter[2] * counter[2]);
            }

            listBox1.Items.Add($"Расстояние по Хэммингу: {counter[2]}");
            listBox1.Items.Add($"Потенциал {p[2]}, что это буква П");
            listBox1.Items.Add("");

            for (int k = 1; k <= 5; k++)
            {
                Bitmap drawlink = new Bitmap(pictureBox1.Image);
                Bitmap load = new Bitmap(Image.FromFile("C:\\Users\\artem\\source\\repos\\II_4\\training_data\\R\\Р_" + Convert.ToString(k) + ".png"));

                for (int i = 0; i < 50; i++)
                    for (int j = 0; j < 50; j++)
                    {
                        if (drawlink.GetPixel(i, j) != load.GetPixel(i, j))
                            counter[3]++;
                    }
                p[3] += 1000.0 / (1.0 + counter[3] * counter[3]);
            }
            listBox1.Items.Add($"Расстояние по Хэммингу: {counter[3]}");
            listBox1.Items.Add($"Потенциал {p[3]}, что это буква Р");
            listBox1.Items.Add("");
            double maxP=0;
            int maxX = 10000000;
            for(int k = 0;k <= 3; k++)
            {
                if (maxP < p[k])
                {
                    maxP = p[k];
                }
                if(maxX > counter[k])
                {
                    maxX = counter[k];
                }
            }
            string Symbol =" ";
            string SymbolX = " ";
            if(maxP == p[0])
            {
                Symbol = "C";
            }
            if (maxP == p[1])
            {
                Symbol = "O";
            }
            if (maxP == p[2])
            {
                Symbol = "П";
            }
            if (maxP == p[3])
            {
                Symbol = "Р";
            }
            if (maxX == counter[0])
            {
                SymbolX = "C";
            }
            if (maxX == counter[1])
            {
                SymbolX = "O";
            }
            if (maxX == counter[2])
            {
                SymbolX = "П";
            }
            if (maxX == counter[3])
            {
                SymbolX = "Р";
            }
            listBox1.Items.Add($"Результат по Потенциалу : буква "+Symbol);
            listBox1.Items.Add($"Результат по Хэммингу : буква " + SymbolX);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

    }
}
