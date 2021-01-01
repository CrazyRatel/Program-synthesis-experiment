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
    public partial class Form1 : Form
    {
        FileStream address_book = null;
        StreamWriter writer = null;
        string path = "C:\\Users\\长威\\Desktop\\address_book.txt";
        public Form1()
        {
            InitializeComponent();
            this.listView1.Columns.Add("学号", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("姓名", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("性别", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("工作单位", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("电话号码", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("E-mail", 100, HorizontalAlignment.Center);
            this.listView1.View = System.Windows.Forms.View.Details;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            Insert form2 = new Insert();
            form2.Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Delete form3 = new Delete();
            form3.Show();
        }

        private void Display_Click(object sender, EventArgs e)
        {
            if (File.Exists(path) == false) return;
            string file = File.ReadAllText(path, UTF8Encoding.Default);
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");
            //开始更新视图
            this.listView1.BeginUpdate();
            //清空原有视图
            this.listView1.Items.Clear();
            // records.Length为数组的元素个数
            for (int index = 0; index < records.Length; index++)
            {   //分割每行记录的各个字段
                string[] components = Regex.Split(records[index], " ");
                //生成listview的一行
                ListViewItem lvi = new ListViewItem(components);
                //添加背景色
                lvi.SubItems[0].BackColor = Color.DarkGray;
                //把新生成的行加入到listview中
                this.listView1.Items.Add(lvi);
            }
            //视图更新结束
            this.listView1.EndUpdate();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Search form5 = new Search();
            form5.Show();
        }

        private void Count_Click(object sender, EventArgs e)
        {
            if (File.Exists(path) == false)
            {
                MessageBox.Show("无");
                return;
            }
            string file = File.ReadAllText(path, UTF8Encoding.Default);
            string[] records = Regex.Split(file, "\r\n");
            int boy = 0, girl = 0, sum = 0;
            int index;
            for (index = 0; index < records.Length-1; index++)
            {
                string[] r1 = Regex.Split(records[index], " ");
                if (r1[2] == "男")
                {
                    boy += 1;
                    sum += 1;
                    continue;
                }
                else if (r1[2] == "女")
                {
                    girl += 1;
                    sum += 1;
                    continue;
                }
            }
            MessageBox.Show("男生："+boy+"\n"+"女生："+girl+"\n"+"总人数："+sum);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Reset form6 = new Reset();
            form6.Show();
        }

    }
}
