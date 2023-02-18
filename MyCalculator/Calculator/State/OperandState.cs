using System;

namespace MyCalculator
{
    public class OperandState: BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public OperandState(CalculatorContext context) : base(context)
        {
            Context.StateName = "Operand State";
        }


        /// <summary>
        /// Handle clear entry
        /// </summary>
        public override void HandleClearEntry()
        {
            Context.Tree.ResetCurrentValue();
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
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        public override void HandleBackspace()
        {
            string currentValue = Context.Tree.Values.Pop().Value;
            int length = Math.Max(currentValue.Length - 1, 0);
            Context.Tree.PushValue(currentValue.Substring(0, length));
        }

        /// <summary>
        /// Handle negative 
        /// </summary>
        public override void HandleNegate()
        {
            string currentValue = Context.Tree.Values.Pop().Value;
            Context.Tree.PushValue((-Convert.ToDecimal(currentValue)).ToString());
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        /// <param name="value">square root sign</param>
        public override void HandleSquareRoot()
        {
            string currentValue = Context.Tree.Values.Pop().Value;
            Context.Tree.PushValue(Math.Sqrt(Convert.ToDouble(currentValue)).ToString());
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
            Context.Tree.ConfirmAndInputValue();

            TreeNode node = new MultiplicationNode();
            Context.Tree.AddCurrentOperator(node);
            Context.Tree.ConfirmOperator();

            Context.Tree.AddLeftParenthesis();

            Context.Tree.PushValue();

            SetState(new InitialState(Context));
        }


        public override void HandleRightParenthesis()
        {
            for (int i = 0; i < Context.Tree.ParenthesisCount;)
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
            Context.Tree.Evaluate();
            SetState(new EqualState(Context));
        }
    }
}