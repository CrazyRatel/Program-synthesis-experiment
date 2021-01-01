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
    public partial class Input_data : Form
    {
        public Input_data()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                return;
            if (Convert.ToInt32(textBox1.Text) > 150 || Convert.ToInt32(textBox1.Text) < (-150) || Convert.ToInt32(textBox2.Text) > 150 || Convert.ToInt32(textBox2.Text) < (-150))
            {
                MessageBox.Show("请输入正确格式的坐标");
                textBox1.Text = textBox2.Text = "";
                return;
            }
            string file = textBox1.Text + " " + textBox2.Text + "\r\n"; 
            File.AppendAllText("C:\\Users\\长威\\Desktop\\超市1.txt",file ,UTF8Encoding.Default);
            MessageBox.Show("添加成功");
            textBox1.Text=textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Users\\长威\\Desktop\\超市1.txt") == false)
            {
                MessageBox.Show("文件不存在");
                return;
            }
            File.Delete("C:\\Users\\长威\\Desktop\\超市1.txt");
        }
    }
}
