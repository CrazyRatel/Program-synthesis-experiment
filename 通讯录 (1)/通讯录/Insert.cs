using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 通讯录
{
    public partial class Insert : Form
    {
        public Insert()
        {
            InitializeComponent();
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
            if(textBox1.Text.Length!=2)
            {
                MessageBox.Show("学号格式错误\n请输入两位学号");
                return;
            }
            //利用string的加法操作构造新纪录，作为一行，写入txt文件中
            string newrecord = this.textBox1.Text + " " + this.textBox2.Text + " " + this.textBox3.Text + " " + this.textBox4.Text + " " + this.textBox5.Text + " " + this.textBox6.Text + "\r\n";
            File.AppendAllText("C:\\Users\\长威\\Desktop\\address_book.txt", newrecord, UTF8Encoding.Default);
            //结束form2的调用
            this.Dispose(false);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
