using System;

namespace MyCalculator
{
    public class OperatorState : BaseState
    {
        public OperatorState(CalculatorContext context) : base(context)
        {
            Context.StateName = "Operator State";
        }

        /// <summary>
        /// Handle clear entry
        /// </summary>
        public override void HandleClearEntry()
        {
            Context.Tree.ConfirmOperator();
            Context.Tree.PushValue();
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle number: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        /// and decimal point: .
        /// </summary>
        /// <param name="value">Number and decimal point</param>
        public override void HandleOperand(string value)
        {
            Context.Tree.ConfirmOperator();
            Context.Tree.PushValue(value);
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        public override void HandleBackspace()
        {
        }

        /// <summary>
        /// Handle negative 
        /// </summary>
        public override void HandleNegate()
        {
            Context.Tree.ConfirmOperator();
            string currentValue = Context.Tree.Values.Peek().Value;
            Context.Tree.PushValue((-Convert.ToDecimal(currentValue)).ToString());
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        /// <param name="value">square root sign</param>
        public override void HandleSquareRoot()
        {
            Context.Tree.ConfirmOperator();
            string currentValue = Context.Tree.Values.Peek().Value;
            Context.Tree.PushValue(Math.Sqrt(Convert.ToDouble(currentValue)).ToString());
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle Multiplication and Division
        /// </summary>
        public override void HandleOperator(TreeNode node)
        {
            Context.Tree.UpdateCurrentOperator(node);
        }


        public override void HandleLeftParenthesis()
        {
            Context.Tree.ConfirmOperator();
            Context.Tree.PushValue();
            Context.Tree.AddLeftParenthesis();
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
            Context.Tree.ConfirmOperator();
            Context.Tree.PushAndInputPrevValue();
            Context.Tree.Evaluate();
            SetState(new EqualState(Context));
        }
    }
}