using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCalculator
{
    public class Calculator
    {
        Label OutputLabel;
        Label ProcessLabel;
        Stack<string> InputStack = new Stack<string>();
        Stack<double> ResultStack = new Stack<double>();
        Stack<Action<double, double>> OperatorStack = new Stack<Action<double, double>>();
        string Zero = "0";
        string Operator;
        Action AppendAction;
        Action ClearEntryAction;

        public void idle() { }


        public void InputStackAddNewValue()
        {
            InputStack.Push(Zero);
        }

        public void ResultStackAddNewValue()
        {
            ResultStack.Push(0);
        }


        public Calculator(Label mainLabel, Label subLabel)
        {
            OutputLabel = mainLabel;
            ProcessLabel = subLabel;
            ResultStackAddNewValue();

            ResultStack.Push(0);
            InputStack.Push(Zero);
            OperatorStack.Push(Add);
            AppendAction = idle;
            ClearEntryAction = Undo;
        }


        public void DisplayOutput(string s)
        {
            string[] arr = s.Split('.');
            string regex = "[-]?(\\d)(?=(\\d{3})+$)";
            arr[0] = Regex.Replace(arr[0], regex, "$1,");
            OutputLabel.Text = string.Join(".", arr);
        }

     
        public void DisplayResult()
        {
            var a = ResultStack.Pop();
            InputStack.Pop();
            ProcessLabel.Text = string.Format("{0} {1} {2} =", ResultStack.Peek(), Operator, InputStack.Peek());
            ResultStack.Push(a);
        }

        public void Append(string x)
        {
            AppendAction();

            var input = InputStack.Pop();
            var pattern = @"^0$";
            input = Regex.Replace(input, pattern, "");
            input += x;
            InputStack.Push(input);
            DisplayOutput(input);

            AppendAction = idle;
        }

        public void Evaluate()
        {
            var input = Convert.ToDouble(InputStack.Peek());
            var sum = ResultStack.Peek();
            OperatorStack.Peek()(sum, input);
            ProcessLabel.Text = string.Format("{0} {1}", ResultStack.Peek(), Operator);
            DisplayOutput(ResultStack.Peek().ToString());
            InputStackAddNewValue();
        }

        public void Add(double a, double b)
        {
            ResultStack.Push(a+b);
        }

        public void Addition()
        {
            Operator = "+";
            Evaluate();
            OperatorStack.Push(Add);
        }

        private void subtract(double a, double b)
        {
            ResultStack.Push(a - b);
        }

        public void Subtraction()
        {
            Operator = "-";
            Evaluate();
            OperatorStack.Push(subtract);

        }

        public void Multiply(double a, double b)
        {
            ResultStack.Push(a * b);
        }

        public void Multiplication()
        {
            Operator = "x";
            Evaluate();
            OperatorStack.Push(Multiply);
        }

        public void Divide(double a, double b)
        {
            ResultStack.Push(a / b);
        }

        public void Division()
        {
            Operator = "÷";
            Evaluate();
            OperatorStack.Push(Divide);
        }

        public void Clear()
        {
            InputStack.Clear();
            InputStackAddNewValue();
            ResultStack.Clear();
            ResultStack.Push(0);
            ProcessLabel.Text = "";
            DisplayOutput(InputStack.Peek());
        }

        public void Undo()
        {
            InputStack.Pop();
            InputStackAddNewValue();
            DisplayOutput(InputStack.Peek());
        }

        public void ClearEntry()
        {
            ClearEntryAction();
            ClearEntryAction = Undo;
        }

        public void Backspace()
        {
            string pattern = @"(^$)|(^\-$)";
            var input = InputStack.Pop();
            input = Regex.Replace(input.Substring(0, Math.Max(input.Length - 1, 0)), pattern, "0");
            InputStack.Push(input);
            DisplayOutput(InputStack.Peek());
        }

        public void Negate()
        {
            var input = InputStack.Pop();
            InputStack.Push((-Convert.ToDecimal(input)).ToString());
            DisplayOutput(InputStack.Peek());
        }

        public void DecimalPoint()
        {
            AppendAction();
            var input = InputStack.Pop();
            input += ".";
            var pattern = @"\.";
            MatchCollection matches = Regex.Matches(input, pattern);
            for (var i = matches.Count - 1; i > 0; i--)
            {
                input = input.Remove(matches[i].Index, 1);
            }
            InputStack.Push(input);
            DisplayOutput(InputStack.Peek());


            AppendAction = idle;
        }

        public void Equals()
        {
            // TODO result
            Evaluate();
            DisplayResult();
            AppendAction = Clear;
            ClearEntryAction = Clear;
        }


    }
}
