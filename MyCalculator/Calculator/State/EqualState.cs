using System;

namespace MyCalculator
{
    /// <summary>
    /// Equal State of CalculatorContext
    /// </summary>
    public class EqualState : BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public EqualState(CalculatorContext context) : base(context)
        {
            Context.StateName = "Equal State";
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
            Context.Tree.PushValue(currentValue + value);
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        public override void HandleBackspace()
        {
            Restart();
        }

        /// <summary>
        /// Handle negative 
        /// </summary>
        public override void HandleNegate()
        {
            Restart();
            //TreeNode currentNode = Context.Tree.Values.Pop();
            //TreeNode node = new NegateNode();
            //node.Right = currentNode;
            //Context.Tree.Values.Push(node);
            //Context.Tree.AddInput(string.Format("{0}({1})", node.Value, currentNode.GetResult()));

            //SetState(new NegateState(Context));
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        /// <param name="value">square root sign</param>
        public override void HandleSquareRoot()
        {
            Restart();
            //TreeNode currentNode = Context.Tree.Values.Pop();
            //TreeNode node = new SqrtNode();
            //node.Right = currentNode;
            //Context.Tree.Values.Push(node);
            //Context.Tree.AddInput(string.Format("{0}({1})", node.Value, currentNode.GetResult()));

            //SetState(new SqrtState(Context));
        }

        /// <summary>
        /// Handle Multiplication and Division
        /// </summary>
        public override void HandleOperator(TreeNode node)
        {
            string currentValue = Context.Tree.GetResult();

            Context.Tree.Init();
            Context.Tree.Values.Pop();
            Context.Tree.PushValue(currentValue);
            Context.Tree.ConfirmAndInputValue();

            Context.Tree.AddCurrentOperator(node);

            SetState(new OperatorState(Context));
        }


        public override void HandleLeftParenthesis()
        {
            Restart();
        }


        public override void HandleRightParenthesis()
        {
            Restart();
        }

        /// <summary>
        /// Handle equal
        /// </summary>
        /// <param name="sign">Equal sign</param>
        public override void HandleEqual()
        {
        }
    }
}
