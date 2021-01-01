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

namespace 超市2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Input_data form = new Input_data();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";//每次将结果框清空
            //定义画布，用Bitmap格式
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);//在pictureBox控件里定义Graphics对象
            //建立坐标，x轴
            g.DrawLine(new Pen(Color.Black), new Point(50, 200), new Point(350, 200));
            g.DrawLine(new Pen(Color.Black), new Point(350, 200), new Point(345, 195));
            g.DrawLine(new Pen(Color.Black), new Point(350, 200), new Point(345, 205));
            //建立坐标，y轴
            g.DrawLine(new Pen(Color.Black), new Point(200, 50), new Point(200, 350));
            g.DrawLine(new Pen(Color.Black), new Point(200, 350), new Point(195, 345));
            g.DrawLine(new Pen(Color.Black), new Point(200, 350), new Point(205, 345));
            //建立画笔，用于描点
            Pen p1 = new Pen(Color.Black);
            Brush p = p1.Brush;
            Pen q1 = new Pen(Color.Red);
            Brush q = q1.Brush;
            int number = 6;
            int[] arrayx= { 0,0,0,0,0,0 };
            int[] arrayy= { 0,0,0,0,0,0 };
            Random k = new Random();
            this.textBox1.Text += "居民点坐标:" + "\r\n";
            for (int i = 0; i < number; i++)
            {
                int x = k.Next(50,350);
                int y = k.Next(50, 350);
                arrayx[i]=x;
                arrayy[i] = y;
                this.textBox1.Text += ("(" + x + "," + y + ")"+"\r\n");
                g.FillEllipse(p, x , y , 5, 5);
            }
            //排序，寻找中位数
            Array.Sort(arrayx);
            Array.Sort(arrayy);
            int midx, midy; double answer = 0, length = 0;
            if (number % 2 == 0)
            {
                midx = (arrayx[number / 2 - 1] + arrayx[number / 2]) / 2;
                midy = (arrayy[number / 2 - 1] + arrayy[number / 2]) / 2;
            }
            else
            {
                midx = arrayx[(number - 1) / 2];
                midy = arrayy[(number - 1) / 2];
            }
            g.FillEllipse(q, midx , midy , 5, 5);
            //计算距离
            for (int i = 0; i < number; i++)
            {
                length = System.Math.Pow(arrayx[i] - midx, 2) + System.Math.Pow(arrayy[i] - midy, 2);
                answer += System.Math.Sqrt(length);
            }
            g.Dispose();
            pictureBox1.Image = bmp;
            this.textBox1.Text += "得到超市坐标：" + "\r\n" + "(" + midx + "," + midy + ")" + "\r\n";
            this.textBox1.Text += "居民点到超市的距离最小总和为：" + "\r\n" + answer.ToString("0.0000") + "\r\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Users\\长威\\Desktop\\超市1.txt") == false)
            {
                MessageBox.Show("文件不存在");
                return;
            }
            string file = File.ReadAllText("C:\\Users\\长威\\Desktop\\超市1.txt", UTF8Encoding.Default);
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            this.textBox1.Text = "";//每次将结果框清空
            //定义画布，用Bitmap格式
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);//在pictureBox控件里定义Graphics对象
            //建立坐标，x轴
            g.DrawLine(new Pen(Color.Black), new Point(50, 200), new Point(350, 200));
            g.DrawLine(new Pen(Color.Black), new Point(350, 200), new Point(345, 195));
            g.DrawLine(new Pen(Color.Black), new Point(350, 200), new Point(345, 205));
            //建立坐标，y轴
            g.DrawLine(new Pen(Color.Black), new Point(200, 50), new Point(200, 350));
            g.DrawLine(new Pen(Color.Black), new Point(200, 350), new Point(195, 345));
            g.DrawLine(new Pen(Color.Black), new Point(200, 350), new Point(205, 345));
            //建立画笔，用于描点
            Pen p1 = new Pen(Color.Black);
            Brush p = p1.Brush;
            Pen q1 = new Pen(Color.Red);
            Brush q = q1.Brush;
            int number = records.Length-1;
            List<int> arrayx = new List<int>();
            List<int> arrayy = new List<int>();
            this.textBox1.Text += "居民点数量:" + number + "\r\n" + "居民点坐标:" + "\r\n";
            for (int i = 0; i < number; i++)
            {
                string[] cnn = Regex.Split(records[i], " ");
                arrayx.Add(Convert.ToInt32(cnn[0]));
                arrayy.Add(Convert.ToInt32(cnn[1]));
                this.textBox1.Text += "(" + cnn[0] + "," + cnn[1] + ")" + "\r\n";
                //坐标原点在窗口中的坐标为（200,200）
                g.FillEllipse(p, arrayx.Last() + 200, arrayy.Last() + 200, 5, 5);
            }
            //排序，寻找中位数
            arrayx.Sort();
            arrayy.Sort();
            int midx, midy; double answer = 0, length = 0;
            if (number % 2 == 0)
            {
                midx = (arrayx[number / 2 - 1] + arrayx[number / 2]) / 2;
                midy = (arrayy[number / 2 - 1] + arrayy[number / 2]) / 2;
            }
            else
            {
                midx = arrayx[(number - 1) / 2];
                midy = arrayy[(number - 1) / 2];
            }
            g.FillEllipse(q, midx + 200, midy + 200, 5, 5);
            //计算距离
            for (int i = 0; i < number; i++)
            {
                length = System.Math.Pow(arrayx[i] - midx, 2) + System.Math.Pow(arrayy[i] - midy, 2);
                answer += System.Math.Sqrt(length);
            }
            g.Dispose();
            pictureBox1.Image = bmp;
            this.textBox1.Text += "得到超市坐标：" + "\r\n" + "(" + midx + "," + midy + ")" + "\r\n";
            this.textBox1.Text += "居民点到超市的距离最小总和为：" + "\r\n" + answer.ToString("0.0000") + "\r\n";
        }
    }
}
