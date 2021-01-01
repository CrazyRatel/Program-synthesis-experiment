using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace 通讯录
{
    public partial class Reset : Form
    {
        public Reset()
        {
            InitializeComponent();
        }
        string path = "C:\\Users\\长威\\Desktop\\address_book.txt";
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (File.Exists(path) == false)
            {
                MessageBox.Show("无通讯录");
                return;
            }
            int tab = 0;
            List<string> lines = new List<string>(File.ReadAllLines("C:\\Users\\长威\\Desktop\\address_book.txt", UTF8Encoding.Default));
            string file = File.ReadAllText("C:\\Users\\长威\\Desktop\\address_book.txt", UTF8Encoding.Default);
            string[] records = Regex.Split(file, "\r\n");
            int index;
            for (index = 0; index < records.Length - 1; index++)
            {
                string[] r1 = Regex.Split(records[index], " ");
                if (r1[1] == textBox7.Text)
                {
                    lines.RemoveAt(index);
                    tab = 1;
                    continue;
                }
            }
            if(tab==0)
                MessageBox.Show("查无此人");
            File.WriteAllLines("C:\\Users\\长威\\Desktop\\address_book.txt", lines, UTF8Encoding.Default);
            //利用string的加法操作构造新纪录，作为一行，写入txt文件中
            string newrecord = this.textBox1.Text + " " + this.textBox2.Text + " " + this.textBox3.Text + " " + this.textBox4.Text + " " + this.textBox5.Text + " " + this.textBox6.Text + "\r\n";
            File.AppendAllText("C:\\Users\\长威\\Desktop\\address_book.txt", newrecord, UTF8Encoding.Default);
            //File.WriteAllLines("C:\\Users\\长威\\Desktop\\address_book.txt", lines, UTF8Encoding.Default);
            this.Dispose(false);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
