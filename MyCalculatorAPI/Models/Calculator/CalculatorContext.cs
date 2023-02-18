namespace MyCalculatorAPI
{
    /// <summary>
    /// Calculator Context of state pattern
    /// </summary>
    public class CalculatorContext
    {
        /// <summary>
        /// Build tree by user inputs
        /// </summary>
        public TreeBuilder Tree { get; set; }

        /// <summary>
        /// Current state of state pattern
        /// </summary>
        public BaseState State { get; set; }

        /// <summary>
        /// Current state name of state pattern 
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CalculatorContext()
        {
            Tree = new TreeBuilder();
            State = new InitialState(this);
        }

        /// <summary>
        /// Return CalculatorResult class
        /// </summary>
        /// <returns></returns>
        public CalculatorResult GetResult()
        {
            return new CalculatorResult(this);
        }

        /// <summary>
        /// Handle clear
        /// </summary>
        public void HandleClear()
        {
            Tree.Init();
            State = new InitialState(this);
        }

        /// <summary>
        /// Handle equal
        /// </summary>
        public void HandleEqual()
        {
            State.HandleEqual();
        }

        /// <summary>
        /// Handle clear entry
        /// </summary>
        public void HandleClearEntry()
        {
            State.HandleClearEntry();
        }

        /// <summary>
        /// Handle Number
        /// </summary>
        /// <param name="value">String number</param>
        public void HandleNumber(string value)
        {
            State.HandleNumber(value);
        }

        /// <summary>
        /// Handle decimal point
        /// </summary>
        public void HandleDecimalPoint()
        {
            State.HandleDecialPoint();
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        public void HandleBackspace()
        {
            State.HandleBackspace();
        }

        /// <summary>
        /// Handle negative 
        /// </summary>
        public void HandleNegate()
        {
            State.HandleNegate();
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        public void HandleSquareRoot()
        {
            State.HandleSquareRoot();
        }

        /// <summary>
        /// Handle addition
        /// </summary>
        public void HandleAddition()
        {
            State.HandleAddition();
        }

        /// <summary>
        /// Handle subtraction
        /// </summary>
        public void HandleSubtraction()
        {
            State.HandleSubtraction();
        }

        /// <summary>
        /// Handle multiplication
        /// </summary>
        public void HandleMultiplication()
        {
            State.HandleMultiplication();
        }

        /// <summary>
        /// Handle division
        /// </summary>
        public void HandleDivision()
        {
            State.HandleDivision();
        }

        /// <summary>
        /// Handle left parenthesis
        /// </summary>
        public void HandleLeftParenthesis()
        {
            State.HandleLeftParenthesis();
        }

        /// <summary>
        /// Hnalde right parenthesis
        /// </summary>
        public void HandleRightParenthesis()
        {
            State.HandleRightParenthesis();
        }

        /// <summary>
        /// Handle left Bracket
        /// </summary>
        public void HandleLeftBracket()
        {
            State.HandleLeftBracket();
        }

        /// <summary>
        /// Hnalde right Bracket
        /// </summary>
        public void HandleRightBracket()
        {
            State.HandleRightBracket();
        }
    }
}