using System;
using System.Windows.Forms;

namespace MyCalculator
{


    public partial class Form1 : Form
    {
        Calculator calculator;
        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator(mainLabel, subLabel);
        }

        private void zeroBtn_Click(object sender, EventArgs e)
        {
            calculator.Append("0");
        }

        private void oneBtn_Click(object sender, EventArgs e)
        {
            calculator.Append("1");
        }

        private void twoBtn_Click(object sender, EventArgs e)
        {
            calculator.Append("2");
        }

        private void threeBtn_Click(object sender, EventArgs e)
        {
            calculator.Append("3");
        }

        private void fourBtn_Click(object sender, EventArgs e)
        {
            calculator.Append("4");
        }

        private void fiveBtn_Click(object sender, EventArgs e)
        {
            calculator.Append("5");
        }

        private void sixBtn_Click(object sender, EventArgs e)
        {
            calculator.Append("6");
        }

        private void sevenBtn_Click(object sender, EventArgs e)
        {
            calculator.Append("7");
        }

        private void eightBtn_Click(object sender, EventArgs e)
        {
            calculator.Append("8");
        }

        private void nineBtn_Click(object sender, EventArgs e)
        {
            calculator.Append("9");
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            calculator.AddStatus();
        }

        private void minusBtn_Click(object sender, EventArgs e)
        {
            calculator.MinusStatus();
        }

        private void multipliedBtn_Click(object sender, EventArgs e)
        {
            calculator.MultipleStatus();
        }

        private void dividedBtn_Click(object sender, EventArgs e)
        {
            calculator.DivideStatus();
        }

        private void cBtn_Click(object sender, EventArgs e)
        {
            calculator.Clear();
        }

        private void ceBtn_Click(object sender, EventArgs e)
        {
            calculator.Undo();
        }

        private void backspaceBtn_Click(object sender, EventArgs e)
        {
            calculator.Backspace();
        }

        private void switchBtn_Click(object sender, EventArgs e)
        {
            calculator.Switch();
        }

        private void pointBtn_Click(object sender, EventArgs e)
        {
            calculator.Point();
        }

        private void equalBtn_Click(object sender, EventArgs e)
        {
            calculator.Result();
        }
    }
}
