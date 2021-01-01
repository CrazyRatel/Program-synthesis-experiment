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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        string path= "C:\\Users\\长威\\Desktop\\address_book.txt";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void Search_Click(object sender, EventArgs e)
        {
            if (File.Exists(path) == false)
            {
                MessageBox.Show("查无此人");
                return;
            }
            string file = File.ReadAllText(path, UTF8Encoding.Default);
            string[] records = Regex.Split(file, "\r\n");
            bool result = false;
            int index;
            for (index = 0; index < records.Length-1; index++)
            {
                string[] r1 = Regex.Split(records[index], " ");
                if (r1[0] == textBox1.Text)
                {
                    result = true;
                    break;
                }
                else if(r1[0]!=textBox1.Text&&index==(records.Length-1))
                {
                    break;
                }
                else if (r1[1] == textBox2.Text)
                {
                    result = true;
                    break;
                }
                else if (r1[1] != textBox1.Text && index == (records.Length - 1))
                {
                    break;
                }
                else if (r1[4] == textBox5.Text)
                {
                    result = true;
                    break;
                }
                else if (r1[4] != textBox1.Text && index == (records.Length - 1))
                {
                    break;
                }
            }
            if (result)
            {
                MessageBox.Show(records[index]);
            }

            else
            {
                MessageBox.Show("查无此人");
                return;
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 
/*
namespace 通讯录管理程序
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.listView1.Columns.Add("学号", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("姓名", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("性别", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("工作单位", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("电话", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("E-mail", 100, HorizontalAlignment.Center);
            this.listView1.View = System.Windows.Forms.View.Details;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int tab = 0;
                string file = File.ReadAllText("E:\\VS2019\\通讯录管理程序\\通讯录.txt", UTF8Encoding.Default);
                string[] renshu = Regex.Split(file, "\r\n");
                List<string> results = new List<string>();
                for (int i = 0; i < renshu.Length - 1; i++)
                {
                    string[] cnn = Regex.Split(renshu[i], " ");
                    if (cnn[0].Equals(this.textBox1.Text))
                    {
                        tab = 1;
                        this.listView1.BeginUpdate();
                        //清空原有视图
                        this.listView1.Items.Clear();
                        ListViewItem lvi = new ListViewItem(cnn);
                        lvi.SubItems[0].BackColor = Color.Red;
                        //把新生成的行加入到listview中
                        this.listView1.Items.Add(lvi);
                        this.listView1.EndUpdate();
                    }
                }
                if (tab == 0) MessageBox.Show("无此人信息!");
            }
            else MessageBox.Show("信息为空,重新输入!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int tab = 0;
                string file = File.ReadAllText("E:\\VS2019\\通讯录管理程序\\通讯录.txt", UTF8Encoding.Default);
                string[] renshu = Regex.Split(file, "\r\n");
                List<string> results = new List<string>();
                for (int i = 0; i < renshu.Length - 1; i++)
                {
                    string[] cnn = Regex.Split(renshu[i], " ");
                    if (cnn[1].Equals(this.textBox2.Text))
                    {
                        tab = 1;
                        this.listView1.BeginUpdate();
                        //清空原有视图
                        this.listView1.Items.Clear();
                        ListViewItem lvi = new ListViewItem(cnn);
                        lvi.SubItems[0].BackColor = Color.Red;
                        //把新生成的行加入到listview中
                        this.listView1.Items.Add(lvi);
                        this.listView1.EndUpdate();
                    }
                }
                if (tab == 0) MessageBox.Show("无此人信息!");
            }
            else MessageBox.Show("信息为空,重新输入!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                int tab = 0;
                string file = File.ReadAllText("E:\\VS2019\\通讯录管理程序\\通讯录.txt", UTF8Encoding.Default);
                string[] renshu = Regex.Split(file, "\r\n");
                List<string> results = new List<string>();
                for (int i = 0; i < renshu.Length - 1; i++)
                {
                    string[] cnn = Regex.Split(renshu[i], " ");
                    if (cnn[4].Equals(this.textBox3.Text))
                    {
                        tab = 1;
                        this.listView1.BeginUpdate();
                        //清空原有视图
                        this.listView1.Items.Clear();
                        ListViewItem lvi = new ListViewItem(cnn);
                        lvi.SubItems[0].BackColor = Color.Red;
                        //把新生成的行加入到listview中
                        this.listView1.Items.Add(lvi);
                        this.listView1.EndUpdate();
                    }
                }
                if (tab == 0) MessageBox.Show("无此人信息!");
            }
            else MessageBox.Show("信息为空,重新输入!");
        }
    }
}
*/
