namespace MyCalculatorAPI
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
            Context.Tree.InitalWithResult();
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
            Context.Tree.InitalWithResult();
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
            Context.Tree.InitalWithResult();
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
            Context.Tree.InitalWithResult();
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
            Restart();
        }

        /// <summary>
        /// Hnalde right parenthesis
        /// </summary>
        public override void HandleRightParenthesis()
        {
            Restart();
        }

        /// <summary>
        /// Handle left Bracket
        /// </summary>
        public override void HandleLeftBracket()
        {
            Restart();
        }

        /// <summary>
        /// Hnalde right Bracket
        /// </summary>
        public override void HandleRightBracket()
        {
            HandleRightParenthesis();
        }

        /// <summary>
        /// Handle equal
        /// </summary>
        public override void HandleEqual()
        {
        }
    }
}
