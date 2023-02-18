using System;

namespace MyCalculator
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

        public void SetState(BaseState state)
        {
            Context.State = state;
        }

        /// <summary>
        /// Handle clear entry
        /// </summary>
        public abstract void HandleClearEntry();

        /// <summary>
        /// Handle number: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        /// and decimal point: .
        /// </summary>
        /// <param name="value">Number and decimal point</param>
        public abstract void HandleOperand(string value);

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
        /// <param name="value">square root sign</param>
        public abstract void HandleSquareRoot();

        /// <summary>
        /// Handle Multiplication and Division
        /// </summary>
        public abstract void HandleOperator(TreeNode node);


        public abstract void HandleLeftParenthesis();


        public abstract void HandleRightParenthesis();

        /// <summary>
        /// Handle equal
        /// </summary>
        /// <param name="sign">Equal sign</param>
        public abstract void HandleEqual();
    }
}