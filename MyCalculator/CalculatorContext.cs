using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCalculator
{
    public class CalculatorContext
    {
        public string DefaultOperand { get; set; }

        public List<string> Process { get; set; }

        public BaseState State { get; set; }

        public string OutputValue { get; set; }

        public string[] Values { get; set; }
        public string[] TempValues { get; set; }

        public BaseArithmetic[] Operators { get; set; }
        public BaseArithmetic[] TempOperators { get; set; }


        public Label Label { get; set; }


        public CalculatorContext(Label label)
        {
            Label = label;
            Label.Text = "Start";
            DefaultOperand = "0";
            OutputValue = DefaultOperand;

            Init();

            State = new InitialState(this);
        }

        public void Init()
        {
            Values = new string[] { DefaultOperand, DefaultOperand, DefaultOperand };
            
            OutputValue = Values[0];
            Operators = new BaseArithmetic[] { new Addition(), new Addition() };
            Process = new List<string>();
        }

        public void HandleClear()
        {
            State.HandleClear();
        }

        public void HnadleEqual(string value)
        {
            State.HandleEqual(value);
        }

        public void HandleOperatorComplex(BaseArithmetic op, string value)
        {
            State.HandleOperatorComplex(op, value);
        }

        public void HandleOperatorSimple(BaseArithmetic op, string value)
        {
            State.HandleOperatorSimple(op, value);
        }

        public void HandleClearEntry()
        {
            State.HandleClearEntry();
        }

        public void HandleOperand(string value)
        {
            State.HandleNumber(value);
        }

        public void HandleBackspace()
        {
            State.HandleBackspace();
        }

        public void HandleNegative()
        {
            State.HandleNegate();
        }

        public void HandleSquareRoot(string value)
        {
            string label = Label.Text;
            State.HandleSquareRoot(value);
        }

        public string GetProcess()
        {
            return string.Join(" ", Process);
        }

        public string GetOutput()
        {
            return OutputValue;
        }

        public string Append(string s, string c)
        {
            return OutputFormat.Format(s + c);
        }

        public string RemoveLastOne(string s)
        {
            return OutputFormat.Format(s.Substring(0, Math.Max(s.Length - 1, 0)));
        }

        public string Negate(string s)
        {
            return OutputFormat.Format((-Convert.ToDecimal(s)).ToString());
        }

        public string Sqrt(string s)
        {
            return OutputFormat.Format(Math.Sqrt(Convert.ToDouble(s)).ToString());
        }

        public void Copy()
        {
            Values.CopyTo(TempValues, 0);
            Operators.CopyTo(TempOperators, 0);
        }

        public void Paste()
        {
            TempValues.CopyTo(Values, 0);
            TempOperators.CopyTo(Operators, 0);
        }
    }
}
