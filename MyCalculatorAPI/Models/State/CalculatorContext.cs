using MyCalculatorAPI.Models;
using System;
using System.Collections.Generic;

namespace MyCalculator
{
    public class TreeStack
    {
        private Stack<TreeNode> Stack;

        public TreeStack()
        {
            Stack = new Stack<TreeNode>();
        }

        public void Push(TreeNode node)
        {
            Stack.Push(node);
        }

        public TreeNode Pop()
        {
            return Stack.Pop();
        }

        public void Edit(string value, BaseArithmetic op = null)
        {
            Stack.Peek().Label = value;
            Stack.Peek().Operator = op;
        }
        
        public string GetCurrentLabel()
        {
            return Stack.Peek().Label;
        }
    }

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
        private Stack<TreeNode> Values;

        /// <summary>
        /// Storage Operators
        /// </summary>
        private Stack<TreeNode> Operators;

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
            Operators = new Stack<TreeNode>();
            Values = new Stack<TreeNode>();
            AddValue(value);
        }

        /// <summary>
        /// Get Top value of value stack
        /// </summary>
        /// <returns></returns>
        public string GetCurrentValue()
        {
            return Values.Peek().Label;
        }

        public void ConfirmValue()
        {
            TreeNode node = Values.Peek();
            node.Label = Convert.ToDouble(node.Label).ToString();
        }

        /// <summary>
        /// Push value to value stack
        /// </summary>
        /// <param name="value">Serial number</param>
        public void PushValue(TreeNode node)
        {
            Values.Push(node);
        }

        /// <summary>
        /// Pop value from value stack
        /// </summary>
        /// <returns></returns>
        public TreeNode PopValue()
        {
            return Values.Pop();
        }

        public void AddValue(string value = DefaultValue)
        {
            TreeNode node = new TreeNode(OutputFormat.Format(value));
            PushValue(node);
        }

        public void PushOperator(TreeNode node)
        {
            Operators.Push(node);
        }

        /// <summary>
        /// Pop operator from operator stack
        /// </summary>
        /// <returns></returns>
        public TreeNode PopOperator()
        {
            return Operators.Pop();
        }

        /// <summary>
        /// Push operator to operator stack
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        public void AddOperator(BaseArithmetic op, string sign)
        {
            TreeNode node = new TreeNode(sign, op);
            PushOperator(node);
        }

        /// <summary>
        /// Edit top operator of operator stack
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">String operator</param>
        public void EditOperator(BaseArithmetic op, string sign)
        {
            Formula[Formula.Count - 1] = sign;

            Operators.Peek().Label = sign;
            Operators.Peek().Operator = op;
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
            TreeNode right = Values.Pop();
            TreeNode left = Values.Pop();
            TreeNode op = Operators.Pop();
            op.Left = left;
            op.Right = right;
            PushValue(op);
        }

        /// <summary>
        /// Calculate top operator of operator stack with top two value of value stack
        /// and make sum value to the top of value stack
        /// </summary>
        /// <param name="sign">Equal sign</param>
        public void CalcEqual(string sign)
        {
            AddFormula(sign);

            TreeNode right = PopValue();
            TreeNode left = PopValue();
            TreeNode op = Operators.Peek();

            op.Left = left;
            op.Right = right;

            PushValue(right);
            PushValue(op);
        }

        /// <summary>
        /// Calculate the sum value with the last operand and operator again
        /// </summary>
        public void UpdateEqual()
        {
            Formula.RemoveRange(1, Formula.Count - 3);

            TreeNode left = PopValue();
            TreeNode right = Values.Peek();
            TreeNode op = Operators.Peek();

            op.Left = left;
            op.Right = right;
            PushValue(op);
            Formula[0] = Values.Peek().Label;
        }

        /// <summary>
        /// Get string formula from formula list
        /// </summary>
        /// <returns></returns>
        public string GetFormula()
        {
            return string.Join(" ", Formula);
        }

        public string GetResult()
        {
            return OutputFormat.Format(Values.Peek().GetResult());
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