using System;

namespace MyCalculator
{
    /// <summary>
    /// Initail state of CalculatorContext
    /// </summary>
    public class InitialState : BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public InitialState(CalculatorContext context) : base(context)
        {
            Context.StateName = "Initial State";
            Context.Tree.ResetCurrentValue();
        }


        /// <summary>
        /// Handle clear entry
        /// </summary>
        public override void HandleClearEntry()
        {
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle number: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        /// and decimal point: .
        /// </summary>
        /// <param name="value">Number and decimal point</param>
        public override void HandleOperand(string value)
        {
            string currentValue = Context.Tree.Values.Pop().Value;
            Context.Tree.PushValue(currentValue + value);
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        public override void HandleBackspace()
        {
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle negative 
        /// </summary>
        public override void HandleNegate()
        {
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        /// <param name="value">square root sign</param>
        public override void HandleSquareRoot()
        {
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle Multiplication and Division
        /// </summary>
        public override void HandleOperator(TreeNode node)
        {
            Context.Tree.ConfirmAndInputValue();
            Context.Tree.AddCurrentOperator(node);
            SetState(new OperatorState(Context));
        }


        public override void HandleLeftParenthesis()
        {
            Context.Tree.AddLeftParenthesis();
            SetState(new InitialState(Context));
        }


        public override void HandleRightParenthesis()
        {
            for(int i = 0; i< Context.Tree.ParenthesisCount;)
            {
                Context.Tree.ConfirmAndInputValue();
                Context.Tree.AddRightParenthesis();
                SetState(new ParenthesisState(Context));
            }
        }

        /// <summary>
        /// Handle equal
        /// </summary>
        /// <param name="sign">Equal sign</param>
        public override void HandleEqual()
        {
            Context.Tree.ConfirmAndInputValue();
            Console.WriteLine(Context.Tree.Values.Count);
            Console.WriteLine(Context.Tree.Operators.Count);
            Context.Tree.Evaluate();
            SetState(new EqualState(Context));
        }
    }
}