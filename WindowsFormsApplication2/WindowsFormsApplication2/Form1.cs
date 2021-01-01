using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //初始化 操作数栈num 操作符栈op
        Stack<double> num = new Stack<double>();
        Stack<char> op = new Stack<char>();
        double Operate(double d1, double d2, char c1)
        {
            double result = 0;//用resul返回计算方法
            switch (c1)
            {
                case '+':
                    result = d1 + d2; break;
                case '-':
                    result = d1 - d2; break;
                case '*':
                    result = d1 * d2; break;
                case '/':
                    result = d1 / d2; break;
            }
            return result;
        }
        //优先级;判断优先级还可以将上面的优先级表填入二维数组，通过查表的方法得到对应优先级
        char precede(char c1, char c2)
        {
            char result = '.';//用result返回优先级
            switch (c1)
            {
                case '+':
                case '-':
                    if (c2 == '+' || c2 == '-' || c2 == ')')
                        result = '>';
                    else
                        result = '<';
                    break;
                case '*':
                case '/':
                    if (c2 == '(')
                        result = '<';
                    else
                        result = '>';
                    break;
                case '(':
                    if (c2 == ')')
                        result = '=';
                    else
                        result = '<';
                    break;
                case ')':
                    result = '<';
                    break;
            }
            return result;
        }
        private void Calculate_Show(object sender, EventArgs e)
        {
            String s = textBox1.Text + "=";
            int p = 0; double n;
            /*如果是运算数num.push,如果是运算符判断与op栈顶的优先级*/
            while (p < s.Length - 1)
            {
                string t = "";
                while (s[p] >= '0' && s[p] <= '9' || s[p] == '.')
                {
                    t += s[p];
                    p++;
                }
                if (t != "")
                {
                    n = double.Parse(t);
                    num.Push(n);
                }

                if (s[p] == '+' || s[p] == '-' || s[p] == '*' || s[p] == '/' || s[p] == '(' || s[p] == ')')
                {
                    if (op.Count == 0)
                    {
                        op.Push(s[p]);
                        p++;
                    }
                    else
                    {
                        char oprt = op.Peek();
                        switch (precede(oprt, s[p]))
                        {
                            case '<':
                                op.Push(s[p]); p++; break;
                            case '=':
                                op.Pop(); p++; break;
                            case '>':
                                double d2 = num.Pop();
                                double d1 = num.Pop();
                                char c1 = op.Pop();
                                num.Push(Operate(d1, d2, c1)); break;

                        }
                        /*if (precede(s[p], oprt))
                        {
                            double d1 = num.Pop();
                            double d2 = num.Pop();
                            char c1 = op.Pop();
                            num.Push(Operate(d1, d2, c1));
                        }
                        else
                        {
                            op.Push(s[p]);
                            p++;
                        }*/
                    }

                }
                if (s[p] == '=')
                {
                    while (op.Count != 0)
                    {
                        double d2 = num.Pop();
                        double d1 = num.Pop();
                        char c1 = op.Pop();
                        num.Push(Operate(d1, d2, c1));
                    }

                }
            }//while
            textBox1.Text = "" + num.Peek();
        }

        private void Input_1(object sender, EventArgs e)
        {
            this.textBox1.Text += "1";
        }
        private void Input_2(object sender, EventArgs e)
        {
            this.textBox1.Text += "2";
        }

        private void Input_3(object sender, EventArgs e)
        {
            this.textBox1.Text += "3";
        }

        private void Input_4(object sender, EventArgs e)
        {
            this.textBox1.Text += "4";
        }

        private void Input_5(object sender, EventArgs e)
        {
            this.textBox1.Text += "5";
        }

        private void Input_6(object sender, EventArgs e)
        {
            this.textBox1.Text += "6";
        }

        private void Input_7(object sender, EventArgs e)
        {
            this.textBox1.Text += "7";
        }

        private void Input_8(object sender, EventArgs e)
        {
            this.textBox1.Text += "8";
        }

        private void Input_9(object sender, EventArgs e)
        {
            this.textBox1.Text += "9";
        }

        private void Input_0(object sender, EventArgs e)
        {
            this.textBox1.Text += "0";
        }

        private void Add_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "+";
        }

        private void Subtract_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "-";
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "*";
        }

        private void Devide_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "/";
        }

        private void Float_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ".";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length > 0)
                this.textBox1.Text = this.textBox1.Text.Remove(this.textBox1.Text.Length - 1);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "(";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ")";
        }
        private void button21_Click(object sender, EventArgs e)
        {
            //实现背景变色
        }

    }
}
