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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Users\\长威\\Desktop\\address_book.txt") == false)
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
                if (r1[1] == textBox2.Text)
                {
                    lines.RemoveAt(index);
                    tab = 1;
                    continue;
                }
            }
            if(tab==1)
                MessageBox.Show("删除成功");
            else
                MessageBox.Show("查无此人");
            File.WriteAllLines("C:\\Users\\长威\\Desktop\\address_book.txt", lines, UTF8Encoding.Default);
            this.Dispose(false);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
