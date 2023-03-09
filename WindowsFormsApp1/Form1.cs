using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private double num1, num2, result;
        private string op;
        private bool decimalFlag = false;
        public void NumClick(int num)
        {
            if (decimalFlag)
            {
                textBox1.Text = textBox1.Text + num;
            }
            else
            {
                if (textBox1.Text == "0.")
                    textBox1.Text = num + ".";
                else
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1) + num + ".";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            NumClick(0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NumClick(1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NumClick(2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NumClick(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NumClick(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NumClick(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NumClick(6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumClick(7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumClick(8);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NumClick(9);
        }

        //小数点
        private void button11_Click(object sender, EventArgs e)
        {
            decimalFlag = true;
        }
        //按键
        private void button16_Click(object sender, EventArgs e)
        {
            num1 = 0;num2 = 0;
            decimalFlag = false;
            textBox1.Text = "0.";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            op = "add";
            num1 = double.Parse(textBox1.Text);
            textBox1.Text = "0.";
            decimalFlag = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            op = "sub";
            num1 = double.Parse(textBox1.Text);
            textBox1.Text = "0.";
            decimalFlag = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text);
            textBox1.Text = "0.";
            decimalFlag = false;
            op = "multi";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            op = "divide";
            num1 = double.Parse(textBox1.Text);
            textBox1.Text = "0.";
            decimalFlag = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            num2 = double.Parse(textBox1.Text);
            switch (op)
            {
                case "add":
                    result = num1 + num2;
                    textBox1.Text = result.ToString();
                    break;
                case "sub":
                    result = num1 - num2;
                    textBox1.Text = result.ToString();
                    break;
                case "multi":
                    result = num1 * num2;
                    textBox1.Text = result.ToString();
                    break;
                case "divide":
                    if (num2 == 0)
                    {
                        textBox1.Text = "error:除数为0";
                    }
                    else
                    {
                        result = num1 / num2;
                        textBox1.Text = result.ToString();
                    }

                    break;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0.";
            textBox1.TextAlign = HorizontalAlignment.Right;
        }
    }
}
