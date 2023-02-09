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

        /// <summary>
        /// Handle clear
        /// </summary>
        public void HandleClear()
        {
            Context.Init();
            Context.SetState(new InitialState(Context));
        }

        /// <summary>
        /// Handle Operand by custom method in child class
        /// </summary>
        protected abstract void DoOperand();

        /// <summary>
        /// Next State after handling operand
        /// </summary>
        /// <returns>BaseState</returns>
        protected abstract BaseState GetNextOpdState();

        /// <summary>
        /// Handle clear entry
        /// </summary>
        public void HandleClearEntry()
        {
            DoOperand();
            Context.PopValue();
            Context.AddValue();
            Context.SetState(GetNextOpdState());
        }

        /// <summary>
        /// Handle number: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        /// and decimal point: .
        /// </summary>
        /// <param name="value">Number and decimal point</param>
        public void HandleOperand(string value)
        {
            DoOperand();
            string CurrentValue = Context.PopValue().Label;
            Context.AddValue(CurrentValue + value);
            Context.SetState(GetNextOpdState());
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        public void HandleBackspace()
        {
            DoOperand();
            string CurrentValue = Context.PopValue().Label;
            int length = Math.Max(CurrentValue.Length - 1, 0);
            Context.AddValue(CurrentValue.Substring(0, length));
            Context.SetState(GetNextOpdState());
        }

        /// <summary>
        /// Handle negative 
        /// </summary>
        public void HandleNegate()
        {
            DoOperand();
            string CurrentValue = Context.PopValue().Label;
            Context.AddValue((-Convert.ToDecimal(CurrentValue)).ToString());
            Context.SetState(GetNextOpdState());
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        /// <param name="value">square root sign</param>
        public void HandleSquareRoot(string value)
        {
            DoOperand();
            string CurrentValue = Context.PopValue().Label;
            Context.AddValue(Math.Sqrt(Convert.ToDouble(CurrentValue)).ToString());
            Context.SetState(GetNextOpdState());
        }

        /// <summary>
        /// Handle Operator by custom method in child class
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">string operator</param>
        protected abstract void DoOperator(BaseArithmetic op, string sign);

        /// <summary>
        /// Next State after handling Multiplication or Division
        /// </summary>
        /// <returns>BaseState</returns>
        protected abstract BaseState GetNextOpCState();

        /// <summary>
        /// Handle Multiplication and Division
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">String operator</param>
        public void HandleOperatorComplex(BaseArithmetic op, string sign)
        {
            DoOperator(op, sign);
            Context.SetState(GetNextOpCState());
        }

        /// <summary>
        /// Next State after handling Addition or Subtruction
        /// </summary>
        /// <returns>BaseState</returns>
        protected abstract BaseState GetNextOpSState();

        /// <summary>
        /// Handle Addition and Subtraction
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">String operator</param>
        public void HandleOperatorSimple(BaseArithmetic op, string sign)
        {
            DoOperator(op, sign);
            Context.SetState(GetNextOpSState());
        }

        /// <summary>
        /// Handle Equal by custom method in child class
        /// </summary>
        /// <param name="sign">Equal sign</param>
        protected abstract void DoEqual(string sign);

        /// <summary>
        /// Next State after handling Equal
        /// </summary>
        /// <returns>BaseState</returns>
        protected abstract BaseState GetNextEqualState();

        /// <summary>
        /// Handle equal
        /// </summary>
        /// <param name="sign">Equal sign</param>
        public void HandleEqual(string sign)
        {
            DoEqual(sign);
            Context.SetState(GetNextEqualState());
        }
    }
}