using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCalculator
{
    public class Calculator
    {

        Stack<decimal> stack = new Stack<decimal>(new decimal[] { 0 });

        Stack<string> st = new Stack<string>(new string[] { "0" });

        string sign;
        Action action;

        //string input = "0";
        Label MainLabel;
        Label SubLabel;

        public Calculator(Label mainLabel, Label subLabel)
        {
            MainLabel = mainLabel;
            SubLabel = subLabel;
        }


        public void DisplayInput()
        {


            string[] arr = st.Peek().Split('.');
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
            var d = st.Pop();
            st.Push(Convert.ToDecimal(d + x).ToString());



            //input = Convert.ToDecimal(input + x).ToString();
            DisplayInput();
        }

        public void Add()
        {
            var sum = st.Pop();
            var tmp = st.Pop();
            st.Push(tmp);
            st.Push((Convert.ToDecimal(sum) + Convert.ToDecimal(tmp)).ToString());

            SubLabel.Text = string.Format("{0} {1} {2} =", sum, sign, tmp);
            DisplayInput();
        }

        public void AddStatus()
        {
            //TODO add
            action = Add;
            sign = "+";
            SubLabel.Text = string.Format("{0} {1}", st.Peek(), sign);
            st.Push(st.Peek());
        }

        public void Minus()
        {
            var tmp = st.Pop();
            var sum = st.Pop();
            st.Push((Convert.ToDecimal(sum) - Convert.ToDecimal(tmp)).ToString());
            st.Push(tmp);

            SubLabel.Text = string.Format("{0} {1} {2} =", sum, sign, tmp);
            DisplayInput();
        }

        public void MinusStatus()
        {
            //TODO minus
            action = Minus;
            sign = "-";
            SubLabel.Text = string.Format("{0} {1}", st.Peek(), sign);
            st.Push(st.Peek());
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
            st.Clear();
            st.Push("0");
            SubLabel.Text = "";
            DisplayInput();
        }

        public void Undo()
        {
            // TODO undo
        }

        public void Backspace()
        {
            var tmp = st.Pop();
            string pattern = @"(^$)|(^\-$)";
            string match = Regex.Replace(tmp.Substring(0, Math.Max(tmp.Length - 1, 0)), pattern, "0");
            st.Push(match);
            DisplayInput();
        }

        public void Switch()
        {
            var tmp = st.Pop();
            st.Push((-Convert.ToDecimal(tmp)).ToString());
            DisplayInput();
        }

        public void Point()
        {
            var tmp = st.Pop();
            List<string> list = new List<string>(tmp.Split('.'));
            list.Add("");

            for (var i = list.Count - 1; i > 1; i--)
            {
                list[1] += list[i];
                list.RemoveAt(i);
            }
            st.Push(string.Join(".", list));

            DisplayInput();
        }

        public void Result()
        {
            // TODO result
            action();
        }


    }
}
