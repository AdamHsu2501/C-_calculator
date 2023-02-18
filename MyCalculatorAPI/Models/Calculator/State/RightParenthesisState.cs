namespace MyCalculatorAPI
{
    /// <summary>
    /// Equal State of CalculatorContext
    /// </summary>
    public class RightParenthesisState : BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public RightParenthesisState(CalculatorContext context) : base(context)
        {
            Context.StateName = "Right Parenthesis State";
        }

        /// <summary>
        /// Restart calculator and go to initial state
        /// </summary>
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
        /// Handle number
        /// </summary>
        /// <param name="value">String number</param>
        public override void HandleNumber(string value)
        {
            Context.Tree.Init(value);
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle decimal point
        /// </summary>
        public override void HandleDecialPoint()
        {
            Context.Tree.Init();
            Context.Tree.HandleDecimalPoint();
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
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        public override void HandleSquareRoot()
        {
            Restart();
        }

        /// <summary>
        /// Handle addition
        /// </summary>
        public override void HandleAddition()
        {
            Context.Tree.SetAddition();
            Context.Tree.InputAddOperator();
            SetState(new ParenthesisOperatorState(Context));
        }

        /// <summary>
        /// Handle subtraction
        /// </summary>
        public override void HandleSubtraction()
        {
            Context.Tree.SetSubtraction();
            Context.Tree.InputAddOperator();
            SetState(new ParenthesisOperatorState(Context));
        }

        /// <summary>
        /// Handle multiplication
        /// </summary>
        public override void HandleMultiplication()
        {
            Context.Tree.SetMultiplication();
            Context.Tree.InputAddOperator();
            SetState(new ParenthesisOperatorState(Context));
        }

        /// <summary>
        /// Handle division
        /// </summary>
        public override void HandleDivision()
        {
            Context.Tree.SetDivision();
            Context.Tree.InputAddOperator();
            SetState(new ParenthesisOperatorState(Context));
        }

        /// <summary>
        /// Handle left parenthesis
        /// </summary>
        public override void HandleLeftParenthesis()
        {
            Context.Tree.SetMultiplication();
            Context.Tree.InputAddOperator();
            Context.Tree.HandleOperator();
            Context.Tree.HandleLeftParenthesis();
            Context.Tree.CreateNode();

            SetState(new ParenthesisInitialState(Context));
        }

        /// <summary>
        /// Hnalde right parenthesis
        /// </summary>
        public override void HandleRightParenthesis()
        {
            Context.Tree.HandleRightParenthesis();
        }

        /// <summary>
        /// Handle equal
        /// </summary>
        public override void HandleEqual()
        {
            Context.Tree.HandleEqual();
            SetState(new EqualState(Context));
        }
    }
}
