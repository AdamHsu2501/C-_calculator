using System;

namespace MyCalculator
{
    public class ParenthesisState : BaseState
    {
        public ParenthesisState(CalculatorContext context) : base(context)
        {
            Context.StateName = "Parenthesis State";
        }

        private void Restart()
        {
            Context.Tree.Init();
            SetState(new InitialState(Context));
        }

        /// <summary>
        /// Handle clear entry
        /// </summary>
        public override void HandleClearEntry()
        {
            Restart();
        }

        /// <summary>
        /// Handle number: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        /// and decimal point: .
        /// </summary>
        /// <param name="value">Number and decimal point</param>
        public override void HandleOperand(string value)
        {
            Context.Tree.Init();
            string currentValue = Context.Tree.Values.Pop().Value;
            Context.Tree.PushValue(currentValue+value);
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        public override void HandleBackspace()
        {
        }

        public override void HandleNegate()
        {
            Restart();
        }

        public override void HandleSquareRoot()
        {
            Restart();
        }


        /// <summary>
        /// Handle Multiplication and Division
        /// </summary>
        public override void HandleOperator(TreeNode node)
        {
            Context.Tree.AddCurrentOperator(node);
            SetState(new OperatorState(Context));
        }


        public override void HandleLeftParenthesis()
        {
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
            Context.Tree.Evaluate();
            SetState(new EqualState(Context));
        }
    }
}