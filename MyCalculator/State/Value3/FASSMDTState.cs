namespace MyCalculator
{
    /// <summary>
    /// F AS S MD T State of CalculatorContext
    /// </summary>
    public class FASSMDTState : BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public FASSMDTState(CalculatorContext context) : base(context)
        {
            Context.Label.Text = "F AS S MD T State";
        }

        /// <summary>
        /// Handle Operand by custom method
        /// </summary>
        protected override void DoOperand()
        {
        }

        /// <summary>
        /// Next State after handling operand
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextOpdState()
        {
            return this;
        }

        /// <summary>
        /// Handle Operator by custom method
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">string operator</param>
        protected override void DoOperator(BaseArithmetic op, string sign)
        {
            Context.AddFormula(Context.GetCurrentValue());
            Context.AddFormula(sign);
            Context.CalcOperator();
            Context.AddOperator(op);
        }

        /// <summary>
        /// Next State after handling Multiplication or Division
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextOpCState()
        {
            return new FASSMDState(Context);
        }

        /// <summary>
        /// Next State after handling Addition or Subtruction
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextOpSState()
        {
            return new FASSASState(Context);
        }

        /// <summary>
        /// Handle Equal by custom method
        /// </summary>
        /// <param name="sign">Equal sign</param>
        protected override void DoEqual(string sign)
        {
            Context.AddFormula(Context.GetCurrentValue());
            Context.CalcOperator();
            Context.CalcEqual(sign);
        }

        /// <summary>
        /// Next State after handling Equal
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextEqualState()
        {
            return new EqualState(Context);
        }
    }
}