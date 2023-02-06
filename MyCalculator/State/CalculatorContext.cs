using System.Collections.Generic;
using System.Windows.Forms;

namespace MyCalculator
{
    /// <summary>
    /// Calculator Context of state pattern
    /// </summary>
    public class CalculatorContext
    {
        /// <summary>
        /// Default value is string zero
        /// </summary>
        private const string DefaultValue = "0";

        /// <summary>
        /// Storage values
        /// </summary>
        private Stack<string> Values;

        /// <summary>
        /// Storage Operators
        /// </summary>
        private Stack<BaseArithmetic> Operators;

        /// <summary>
        /// Storage Formula
        /// </summary>
        private List<string> Formula;

        /// <summary>
        /// Current state of state pattern
        /// </summary>
        private BaseState State;

        /// <summary>
        /// Format value
        /// </summary>
        private OutputFormat OutputFormat;

        /// <summary>
        /// Current state name
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Display state label</param>
        public CalculatorContext()
        {
            OutputFormat = new OutputFormat();
            Init();
            SetState(new InitialState(this));
        }

        /// <summary>
        /// Set State
        /// </summary>
        /// <param name="state">BaseState</param>
        public void SetState(BaseState state)
        {
            State = state;
        }

        /// <summary>
        /// Initial Storage
        /// </summary>
        /// <param name="value">Serial number</param>
        public void Init(string value = DefaultValue)
        {
            Formula = new List<string>();
            Operators = new Stack<BaseArithmetic>();
            Values = new Stack<string>();
            AddValue(value);
        }

        /// <summary>
        /// Get Top value of value stack
        /// </summary>
        /// <returns></returns>
        public string GetCurrentValue()
        {
            return Values.Peek();
        }

        /// <summary>
        /// Push value to value stack
        /// </summary>
        /// <param name="value">Serial number</param>
        public void AddValue(string value = DefaultValue)
        {
            Values.Push(OutputFormat.Format(value));
        }

        /// <summary>
        /// Pop value from value stack
        /// </summary>
        /// <returns></returns>
        public string PopValue()
        {
            return Values.Pop();
        }

        /// <summary>
        /// Push operator to operator stack
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        public void AddOperator(BaseArithmetic op)
        {
            Operators.Push(op);
        }

        /// <summary>
        /// Pop operator from operator stack
        /// </summary>
        /// <returns></returns>
        public BaseArithmetic PopOperator()
        {
            return Operators.Pop();
        }

        /// <summary>
        /// Edit top operator of operator stack
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">String operator</param>
        public void EditOperator(BaseArithmetic op, string sign)
        {
            Formula[Formula.Count - 1] = sign;

            Operators.Pop();
            Operators.Push(op);
        }

        /// <summary>
        /// Add value to formula list
        /// </summary>
        /// <param name="value">String number and operator</param>
        public void AddFormula(string value)
        {
            Formula.Add(value);
        }

        /// <summary>
        /// Clear formula list
        /// </summary>
        public void ClearFormula()
        {
            Formula.Clear();
        }

        /// <summary>
        /// Calculate top operator of operator stack with top two value of value stack
        /// </summary>
        public void CalcOperator()
        {
            string b = Values.Pop();
            string a = Values.Pop();
            BaseArithmetic op = Operators.Pop();
            AddValue(op.GetResult(a, b));
        }

        /// <summary>
        /// Calculate top operator of operator stack with top two value of value stack
        /// and make sum value to the top of value stack
        /// </summary>
        /// <param name="sign">Equal sign</param>
        public void CalcEqual(string sign)
        {
            AddFormula(sign);

            string b = Values.Pop();
            string a = Values.Pop();
            BaseArithmetic op = Operators.Peek();
            AddValue(b);
            AddValue(op.GetResult(a, b));
        }

        /// <summary>
        /// Calculate the sum value with the last operand and operator again
        /// </summary>
        public void UpdateEqual()
        {
            Formula.RemoveRange(1, Formula.Count - 3);
            string a = PopValue();
            string b = GetCurrentValue();
            BaseArithmetic op = Operators.Peek();
            AddValue(op.GetResult(a, b));
            Formula[0] = GetCurrentValue();
        }

        /// <summary>
        /// Get string formula from formula list
        /// </summary>
        /// <returns></returns>
        public string GetFormula()
        {
            return string.Join(" ", Formula);
        }

        /// <summary>
        /// Handle clear
        /// </summary>
        public void HandleClear()
        {
            State.HandleClear();
        }

        /// <summary>
        /// Handle equal
        /// </summary>
        /// <param name="sign">Equal sign</param>
        public void HandleEqual(string sign)
        {
            State.HandleEqual(sign);
        }

        /// <summary>
        /// Handle Multiplication and Division
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">String operator</param>
        public void HandleOperatorComplex(BaseArithmetic op, string sign)
        {
            State.HandleOperatorComplex(op, sign);
        }

        /// <summary>
        /// Handle Addition and Subtraction
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">String operator</param>
        public void HandleOperatorSimple(BaseArithmetic op, string sign)
        {
            State.HandleOperatorSimple(op, sign);
        }

        /// <summary>
        /// Handle clear entry
        /// </summary>
        public void HandleClearEntry()
        {
            State.HandleClearEntry();
        }

        /// <summary>
        /// Handle number: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        /// and decimal point: .
        /// </summary>
        /// <param name="value">Number and decimal point</param>
        public void HandleOperand(string value)
        {
            State.HandleOperand(value);
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        public void HandleBackspace()
        {
            State.HandleBackspace();
        }

        /// <summary>
        /// Handle negative 
        /// </summary>
        public void HandleNegative()
        {
            State.HandleNegate();
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        /// <param name="value">square root sign</param>
        public void HandleSquareRoot(string value)
        {
            State.HandleSquareRoot(value);
        }
    }
}