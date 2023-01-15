using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCalculator
{
    public class Calculator
    {
        string Operator;
        Stack<string> ValueStack = new Stack<string>();

        Label Output;
        Label Process;

        string AppendPattern = @"^0$";
        string clearPattern = @".";
        string currentPattern;


        Action NewInputAction;
        string Zero = "0";
      

        public void idle() { }

        public void PushNewInput()
        {
            ValueStack.Push(Zero);
        }

        public Calculator(Label mainLabel, Label subLabel)
        {
            Output = mainLabel;
            Process = subLabel;
            currentPattern = AppendPattern;
            NewInputAction = PushNewInput;
        }


        public void DisplayOutput(string s)
        {
            string[] arr = s.Split('.');
            string format = "#,0";
            arr[0] = Convert.ToDecimal(arr[0]).ToString(format);
            Output.Text = string.Join(".", arr);
        }

        public void DisplayProcess()
        {
        }

        public void Append(string x)
        {
            NewInputAction();

            var input = ValueStack.Pop();
            input = Regex.Replace(input, currentPattern, "");
            input += x;
            ValueStack.Push(input);
            DisplayOutput(input);

            currentPattern = AppendPattern;
            NewInputAction = idle;
        }

        public void Addition()
        {
            //TODO add
            Operator = "+";
            var sum = Convert.ToDouble(ValueStack.Pop());
            var input = 0.0;
            try
            {
                input = Convert.ToDouble(ValueStack.Pop());
            }catch(Exception ex) { 
            }

            sum += input;
            ValueStack.Push(sum.ToString());
            Process.Text = string.Format("{0} {1}", ValueStack.Peek(), Operator);
            currentPattern = clearPattern;
            DisplayOutput(ValueStack.Peek());

            NewInputAction = PushNewInput;
        }


        public void Subtraction()
        {
            //TODO minus
        }

        public void Multiplication()
        {
            // TODO multiple

        }

        public void Division()
        {
            // TODO divide
        }

        public void Clear()
        {
            ValueStack.Clear();
            ValueStack.Push(Zero);
            Process.Text = "";
            DisplayOutput(ValueStack.Peek());
        }

        public void ClearEntry()
        {
            // TODO undo
        }

        public void Backspace()
        {
            string pattern = @"(^$)|(^\-$)";
            var input = ValueStack.Pop();
            input = Regex.Replace(input.Substring(0, Math.Max(input.Length - 1, 0)), pattern, "0");
            ValueStack.Push(input);
            DisplayOutput(input);
        }

        public void Negate()
        {
            var input = ValueStack.Pop();
            input = (-Convert.ToDecimal(input)).ToString();
            ValueStack.Push(input);
            DisplayOutput(input);
        }

        public void DecimalPoint()
        {
            NewInputAction();
            var input = ValueStack.Pop();
            input += ".";
            var pattern = @"\.";
            MatchCollection matches = Regex.Matches(input, pattern);
            for (var i = matches.Count-1; i>0; i--)
            {
                input = input.Remove(matches[i].Index, 1);
            }
            ValueStack.Push(input);
            DisplayOutput(input);


            NewInputAction = idle;
        }

        public void Equals()
        {
            // TODO result
            var sum = Convert.ToDouble(ValueStack.Pop());
            var input = 0.0;
            try
            {
                input = Convert.ToDouble(ValueStack.Pop());
            }
            catch(Exception ex) {
                input = sum;
            }
            Process.Text = string.Format("{0} {1} {2} =", sum, Operator, input);
            sum += input;
            ValueStack.Push(sum.ToString());
            DisplayOutput(ValueStack.Peek());
            NewInputAction = Clear;
        }


    }
}
