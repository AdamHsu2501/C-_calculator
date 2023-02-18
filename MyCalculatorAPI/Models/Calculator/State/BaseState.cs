namespace MyCalculatorAPI
{
    /// <summary>
    /// Base state class of State pattern
    /// design with template pattern
    /// </summary>
    public abstract class BaseState
    {
        /// <summary>
        /// Context of State pattern
        /// </summary>
        protected CalculatorContext Context { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public BaseState(CalculatorContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Set next state of state pattern
        /// </summary>
        /// <param name="state">Next state of state pattern</param>
        public void SetState(BaseState state)
        {
            Context.State = state;
        }

        /// <summary>
        /// Handle clear entry
        /// </summary>
        public abstract void HandleClearEntry();

        /// <summary>
        /// Handle number
        /// </summary>
        /// <param name="value">String number</param>
        public abstract void HandleNumber(string value);

        /// <summary>
        /// Handle decimal point
        /// </summary>
        public abstract void HandleDecialPoint();

        /// <summary>
        /// Handle backspace
        /// </summary>
        public abstract void HandleBackspace();

        /// <summary>
        /// Handle negative 
        /// </summary>
        public abstract void HandleNegate();

        /// <summary>
        /// Handle square root
        /// </summary>
        public abstract void HandleSquareRoot();

        /// <summary>
        /// Handle addition
        /// </summary>
        public abstract void HandleAddition();

        /// <summary>
        /// Handle subtraction
        /// </summary>
        public abstract void HandleSubtraction();

        /// <summary>
        /// Handle multiplication
        /// </summary>
        public abstract void HandleMultiplication();

        /// <summary>
        /// Handle division
        /// </summary>
        public abstract void HandleDivision();

        /// <summary>
        /// Handle left parenthesis
        /// </summary>
        public abstract void HandleLeftParenthesis();

        /// <summary>
        /// Hnalde right parenthesis
        /// </summary>
        public abstract void HandleRightParenthesis();

        /// <summary>
        /// Handle equal
        /// </summary>
        public abstract void HandleEqual();
    }
}