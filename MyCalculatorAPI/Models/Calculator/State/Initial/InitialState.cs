namespace MyCalculatorAPI
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
            //Context.Tree.ResetCurrentNode();
        }

        /// <summary>
        /// Handle clear entry
        /// </summary>
        public override void HandleClearEntry()
        {
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle number
        /// </summary>
        /// <param name="value">String number</param>
        public override void HandleNumber(string value)
        {
            Context.Tree.HandleNumber(value);
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle decimal point
        /// </summary>
        public override void HandleDecialPoint()
        {
            Context.Tree.HandleDecimalPoint();
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
        public override void HandleSquareRoot()
        {
            SetState(new OperandState(Context));
        }

        /// <summary>
        /// Handle addition
        /// </summary>
        public override void HandleAddition()
        {
            Context.Tree.InputAddValue();
            Context.Tree.SetAddition();
            Context.Tree.InputAddOperator();
            SetState(new OperatorState(Context));
        }

        /// <summary>
        /// Handle subtraction
        /// </summary>
        public override void HandleSubtraction()
        {
            Context.Tree.InputAddValue();
            Context.Tree.SetSubtraction();
            Context.Tree.InputAddOperator();
            SetState(new OperatorState(Context));
        }

        /// <summary>
        /// Handle multiplication
        /// </summary>
        public override void HandleMultiplication()
        {
            Context.Tree.InputAddValue();
            Context.Tree.SetMultiplication();
            Context.Tree.InputAddOperator();
            SetState(new OperatorState(Context));
        }

        /// <summary>
        /// Handle division
        /// </summary>
        public override void HandleDivision()
        {
            Context.Tree.InputAddValue();
            Context.Tree.SetDivision();
            Context.Tree.InputAddOperator();
            SetState(new OperatorState(Context));
        }

        /// <summary>
        /// Handle left parenthesis
        /// </summary>
        public override void HandleLeftParenthesis()
        {
            Context.Tree.HandleLeftParenthesis();
            SetState(new ParenthesisInitialState(Context));
        }

        /// <summary>
        /// Hnalde right parenthesis
        /// </summary>
        public override void HandleRightParenthesis()
        {
        }

        /// <summary>
        /// Handle left Bracket
        /// </summary>
        public override void HandleLeftBracket()
        {
            Context.Tree.HandleLeftBrackets();
            SetState(new ParenthesisInitialState(Context));
        }

        /// <summary>
        /// Hnalde right Bracket
        /// </summary>
        public override void HandleRightBracket()
        {
        }

        /// <summary>
        /// Handle equal
        /// </summary>
        public override void HandleEqual()
        {
            Context.Tree.InputAddValue();
            Context.Tree.HandleEqual();
            SetState(new EqualState(Context));
        }
    }
}