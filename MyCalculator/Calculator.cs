using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCalculator
{
    public class Calculator
    {

        Stack<decimal> stack = new Stack<decimal>();
        string sign;
        Action action;

        string input = "0";
        Label MainLabel;
        Label SubLabel;

        public Calculator(Label mainLabel, Label subLabel)
        {
            MainLabel = mainLabel;
            SubLabel = subLabel;
        }


        public void DisplayInput()
        {
            string[] arr = input.Split('.');
            string pattern = @"\d+";
            Match match = Regex.Match(arr[0], pattern);
            Group tmp = match.Groups[0];
            string format = "#,0";
            string replacement = Convert.ToDecimal(tmp.ToString()).ToString(format);
            arr[0] = Regex.Replace(arr[0], pattern, replacement);

            MainLabel.Text = string.Join(".", arr);
           
        }
        
        public void DisplayProcess()
        {
        }

        public void Append(string x)
        {
            input = Convert.ToDecimal(input + x).ToString();
            DisplayInput();
        }

        public void Add()
        {
            var number = stack.Pop();
            var prevTotal = stack.Pop();

            var sum = prevTotal + number;
            MainLabel.Text = sum.ToString();



            SubLabel.Text = string.Format("{0} {1} {2} =", prevTotal, sign, number);

            stack.Push(sum);
            stack.Push(number);
        }

        public void AddStatus()
        {
            //TODO add
            action = Add;
            sign = "+";
            stack.Push(Convert.ToDecimal(input));
            SubLabel.Text = string.Format("{0} {1}", input, sign);
            input = "0";
        }

        public void Minus()
        {
        }

        public void MinusStatus()
        {
            //TODO minus
        }

        public void MultipleStatus()
        {
            // TODO multiple

        }

        public void DivideStatus()
        {
            // TODO divide
        }

        public void Clear()
        {
            input = "0";
            SubLabel.Text = "";
            DisplayInput();
        }

        public void Undo()
        {
            // TODO undo
        }

        public void Backspace()
        {
            string pattern = @"(^$)|(^\-$)";
            string match = Regex.Replace(input.Substring(0, Math.Max(input.Length - 1, 0)), pattern, "0");
            input = match;
            DisplayInput();
        }

        public void Switch()
        {
            input = (-Convert.ToDecimal(input)).ToString();
            DisplayInput();
        }

        public void Point()
        {
            List<string> list = new List<string>(input.Split('.'));
            list.Add("");

            for (var i = list.Count-1; i>1; i--)
            {
                list[1] += list[i];
                list.RemoveAt(i);
            }
            input = string.Join(".", list);

            DisplayInput();
        }

        public void Result()
        {
            // TODO result
            action();
        }

        
    }
}
