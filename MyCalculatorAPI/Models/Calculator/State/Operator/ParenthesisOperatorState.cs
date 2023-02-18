namespace MyCalculatorAPI
{
    /// <summary>
    /// Operator state of state pattern
    /// </summary>
    public class ParenthesisOperatorState : BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public ParenthesisOperatorState(CalculatorContext context) : base(context)
        {
            Context.StateName = "Parenthesis Operator State";
        }

        /// <summary>
        /// Handle clear entry
        /// </summary>
        public override void HandleClearEntry()
        {
            Context.Tree.HandleOperator();
            Context.Tree.CreateNode();
            Context.Tree.HandleClearEntry();
            SetState(new ParenthesisOperandState(Context));
        }

        /// <summary>
        /// Handle number
        /// </summary>
        /// <param name="value">String number</param>
        public override void HandleNumber(string value)
        {
            Context.Tree.HandleOperator();
            Context.Tree.CreateNode();
            Context.Tree.HandleNumber(value);
            SetState(new ParenthesisOperandState(Context));
        }

        /// <summary>
        /// Handle decimal point
        /// </summary>
        public override void HandleDecialPoint()
        {
            Context.Tree.HandleOperator();
            Context.Tree.CreateNode();
            Context.Tree.HandleDecimalPoint();
            SetState(new ParenthesisOperandState(Context));
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
            Context.Tree.HandleOperator();
            Context.Tree.PushPeekNode();
            Context.Tree.HandleNegate();
            SetState(new ParenthesisOperandState(Context));
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        public override void HandleSquareRoot()
        {
            Context.Tree.HandleOperator();
            Context.Tree.PushPeekNode();
            Context.Tree.HandleSquareRoot();
            SetState(new ParenthesisOperandState(Context));
        }

        /// <summary>
        /// Handle addition
        /// </summary>
        public override void HandleAddition()
        {
            Context.Tree.SetAddition();
            Context.Tree.InputUpdateOperator();
        }

        /// <summary>
        /// Handle subtraction
        /// </summary>
        public override void HandleSubtraction()
        {
            Context.Tree.SetSubtraction();
            Context.Tree.InputUpdateOperator();
        }

        /// <summary>
        /// Handle multiplication
        /// </summary>
        public override void HandleMultiplication()
        {
            Context.Tree.SetMultiplication();
            Context.Tree.InputUpdateOperator();
        }

        /// <summary>
        /// Handle division
        /// </summary>
        public override void HandleDivision()
        {
            Context.Tree.SetDivision();
            Context.Tree.InputUpdateOperator();
        }

        /// <summary>
        /// Handle left parenthesis
        /// </summary>
        public override void HandleLeftParenthesis()
        {
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
            Context.Tree.HandleOperator();
            Context.Tree.PushPeekNode();
            Context.Tree.InputAddValue();
            Context.Tree.HandleRightParenthesis();
            SetState(new RightParenthesisState(Context));
        }

        /// <summary>
        /// Handle left Bracket
        /// </summary>
        public override void HandleLeftBracket()
        {
            Context.Tree.HandleOperator();
            Context.Tree.HandleLeftBrackets();
            Context.Tree.CreateNode();
            SetState(new ParenthesisInitialState(Context));
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
            Context.Tree.HandleOperator();
            Context.Tree.PushPeekNode();
            Context.Tree.InputAddValue();
            Context.Tree.HandleEqual();
            SetState(new EqualState(Context));
        }
    }
}