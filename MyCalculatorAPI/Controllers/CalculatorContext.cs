using System.Collections.Generic;

namespace MyCalculator
{
    /// <summary>
    /// Calculator Context of state pattern
    /// </summary>
    public class CalculatorContext
    {
        public TreeBuilder Tree { get; set; }

        /// <summary>
        /// Current state of state pattern
        /// </summary>
        public BaseState State { get; set; }

        public string StateName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CalculatorContext()
        {
            Tree = new TreeBuilder();
            State = new InitialState(this);
        }


        public string GetResult()
        {
            return Tree.GetResult();
        }

        public string GetFormula()
        {
            return Tree.GetInputFormula();
        }

        /// <summary>
        /// Handle clear
        /// </summary>
        public void HandleClear()
        {
            Tree.Init();
            State = new InitialState(this);
        }

        /// <summary>
        /// Handle equal
        /// </summary>
        /// <param name="sign">Equal sign</param>
        public void HandleEqual()
        {
            State.HandleEqual();
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
        public void HandleSquareRoot()
        {
            State.HandleSquareRoot();
        }

        /// <summary>
        /// Handle Multiplication and Division
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">String operator</param>
        public void HandleOperator(BaseBinaryOperatorNode node)
        {
            State.HandleOperator(node);
        }

        public void HandleLeftParenthesis()
        {
            State.HandleLeftParenthesis();
        }

        public void HandleRightParenthesis()
        {
            State.HandleRightParenthesis();
        }
    }
}