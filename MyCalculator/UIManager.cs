using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCalculator
{
    /// <summary>
    /// Manager UI
    /// </summary>
    public class UIManager
    {
        /// <summary>
        /// Main output label
        /// </summary>
        private Label OutputLabel;

        /// <summary>
        /// Process output label
        /// </summary>
        private Label ProcessLabel;

        /// <summary>
        /// Stack of input operand and operator
        /// </summary>
        private Stack<string> ValueStack;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="outputLabel">Main label class</param>
        /// <param name="processLabel">Processs label class</param>
        /// <param name="inputStack">Stack class</param>
        public UIManager(Label outputLabel, Label processLabel, Stack<string> inputStack)
        {
            OutputLabel = outputLabel;
            ProcessLabel = processLabel;
            ValueStack = inputStack;

            Init();
        }

        /// <summary>
        /// Init status if equals button pressed
        /// </summary>
        public void ClearIfIsEnd()
        {
            string pattern = @"=";
            var matches = Regex.Matches(ProcessLabel.Text, pattern);

            foreach (var match in matches)
            {
                Init();
            }
        }

        /// <summary>
        /// Initial UIManager
        /// </summary>
        public void Init()
        {
            ValueStack.Push("+");
            ValueStack.Push("0");
            ValueStack.Push("0");

            OutputLabel.Text = ValueStack.Peek();
            ProcessLabel.Text = "";
        }

        /// <summary>
        /// Pop ValueStack top value
        /// </summary>
        /// <returns></returns>
        public string Pop()
        {
            return ValueStack.Pop();
        }

        /// <summary>
        /// Display Process to Process Label
        /// </summary>
        /// <param name="pattern">Regex pattern</param>
        /// <param name="value">output string</param>
        public void DisplayProcess(string pattern, string value)
        {
            ProcessLabel.Text = Regex.Replace(ProcessLabel.Text, pattern, value);
        }

        /// <summary>
        /// push formal string number to stack
        /// and output
        /// </summary>
        /// <param name="s">string number</param>
        public void FormatPushAndOutput(string s)
        {
            s = OutputFormat.Format(s);
            ValueStack.Push(s);
            OutputLabel.Text = s;
        }

        /// <summary>
        /// Handle Result by GetResult
        /// Push new value to stack
        /// and display value
        /// </summary>
        /// <param name="operatorSign">+, -, *, /</param>
        /// <param name="sum">string number</param>
        /// <param name="operand">second string number</param>
        /// <param name="label">output string</param>
        public void OperatorProcess(string operatorSign, string sum, string operand, string label)
        {
            sum = OutputFormat.Format(sum);

            ValueStack.Push(operatorSign);
            ValueStack.Push(sum);
            ValueStack.Push(operand);

            ProcessLabel.Text = label;
            OutputLabel.Text = sum;
        }

        /// <summary>
        /// Calculate operands by operator
        /// </summary>
        /// <returns>Tuple(operator, prevSum, operand, currSum)</returns>
        public Tuple<string, double, double, double> GetResult()
        {
            double b = Convert.ToDouble(ValueStack.Pop());
            double a = Convert.ToDouble(ValueStack.Pop());
            double sum = 0;
            string op = ValueStack.Pop();
            MatchCollection matches;

            string addPattern = @"\+";
            matches = Regex.Matches(op, addPattern);
            foreach (object i in matches)
            {
                sum = a + b;
            }

            string subtractPattern = @"\-";
            matches = Regex.Matches(op, subtractPattern);
            foreach (object i in matches)
            {
                sum = a - b;
            }

            string multiplyPattern = @"x";
            matches = Regex.Matches(op, multiplyPattern);
            foreach (object i in matches)
            {
                sum = a * b;
            }

            string dividePattern = @"÷";
            matches = Regex.Matches(op, dividePattern);
            foreach (object i in matches)
            {
                sum = a / b;
            }
            
            return Tuple.Create(op, a, b, sum);
        }
    }
}


