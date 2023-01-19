using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        Stack<string> InputStack = new Stack<string>();

        UIManager UIManager;
        OperandButton OperandButton;
        BackspaceButton BackspaceButton;
        NegateButton NegateButton;
        ClearButton ClearButton;
        ClearEntryButton ClearEntryButton;
        OperatorButton OperatorButton;
        EqualsButton EqualsButton;


        public Form1()
        {
            InitializeComponent();
            UIManager = new UIManager(mainLabel, subLabel, InputStack);
            OperandButton = new OperandButton();
            BackspaceButton = new BackspaceButton();
            NegateButton = new NegateButton();
            ClearButton = new ClearButton();
            ClearEntryButton = new ClearEntryButton();
            OperatorButton = new OperatorButton();
            EqualsButton = new EqualsButton();
        }

        private void zeroBtn_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            MatchCollection matches;

            string operandPattern = @"^[\d|\.]$";
            matches = Regex.Matches(s, operandPattern);
            foreach(object match in matches)
            {
                OperandButton.Click(UIManager, s);
            }

            string operatorPattern = @"^[\+|\-|\*|\/]$";
            matches = Regex.Matches(s, operatorPattern);
            foreach (object match in matches)
            {
                OperatorButton.Click(UIManager, s);
            }

            string clearPattern = cBtn.Text;
            matches = Regex.Matches(s, clearPattern);
            foreach(object match in matches)
            {
                ClearButton.Click(UIManager, s);
            }

            string clearEntryPattern = ceBtn.Text;
            matches = Regex.Matches(s, clearEntryPattern);
            foreach (object match in matches)
            {
                ClearEntryButton.Click(UIManager, s);
            }

            string backspacePattern = backspaceBtn.Text;
            matches = Regex.Matches(s, backspacePattern);
            foreach (object match in matches)
            {
                BackspaceButton.Click(UIManager, s);
            }
         
            string nagatePattern = switchBtn.Text;
            matches = Regex.Matches(s, nagatePattern);
            foreach (object match in matches)
            {
                NegateButton.Click(UIManager, s);
            }

            string equalsPattern = equalBtn.Text;
            matches = Regex.Matches(s, equalsPattern);
            foreach (object match in matches)
            {
                EqualsButton.Click(UIManager, s);
            }
        }
    }
}
