namespace MyCalculatorAPI
{
    /// <summary>
    /// Operator state of state pattern
    /// </summary>
    public class ParenthesisOperandState : BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public ParenthesisOperandState(CalculatorContext context) : base(context)
        {
            Context.StateName = "Parenthesis Operand State";
        }

        /// <summary>
        /// Handle clear entry
        /// </summary>
        public override void HandleClearEntry()
        {
            Context.Tree.HandleClearEntry();
        }

        /// <summary>
        /// Handle number
        /// </summary>
        /// <param name="value">String number</param>
        public override void HandleNumber(string value)
        {
            Context.Tree.HandleNumber(value);
        }

        /// <summary>
        /// Handle decimal point
        /// </summary>
        public override void HandleDecialPoint()
        {
            Context.Tree.HandleDecimalPoint();
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        public override void HandleBackspace()
        {
            Context.Tree.HandleBackspace();
        }

        /// <summary>
        /// Handle negative 
        /// </summary>
        public override void HandleNegate()
        {
            Context.Tree.HandleNegate();
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        public override void HandleSquareRoot()
        {
            Context.Tree.HandleSquareRoot();
        }

        /// <summary>
        /// Handle addition
        /// </summary>
        public override void HandleAddition()
        {
            Context.Tree.InputAddValue();
            Context.Tree.SetAddition();
            Context.Tree.InputAddOperator();
            SetState(new ParenthesisOperatorState(Context));
        }

        /// <summary>
        /// Handle subtraction
        /// </summary>
        public override void HandleSubtraction()
        {
            Context.Tree.InputAddValue();
            Context.Tree.SetSubtraction();
            Context.Tree.InputAddOperator();
            SetState(new ParenthesisOperatorState(Context));
        }

        /// <summary>
        /// Handle multiplication
        /// </summary>
        public override void HandleMultiplication()
        {
            Context.Tree.InputAddValue();
            Context.Tree.SetMultiplication();
            Context.Tree.InputAddOperator();
            SetState(new ParenthesisOperatorState(Context));
        }

        /// <summary>
        /// Handle division
        /// </summary>
        public override void HandleDivision()
        {
            Context.Tree.InputAddValue();
            Context.Tree.SetDivision();
            Context.Tree.InputAddOperator();
            SetState(new ParenthesisOperatorState(Context));
        }

        /// <summary>
        /// Handle left parenthesis
        /// </summary>
        public override void HandleLeftParenthesis()
        {
            Context.Tree.InputAddValue();
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
            Context.Tree.InputAddValue();
            Context.Tree.HandleRightParenthesis();
            SetState(new RightParenthesisState(Context));
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