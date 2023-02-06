namespace MyCalculator
{
    /// <summary>
    /// F MD S State of CalculatorContext
    /// </summary>
    public class FMDSState : FASSState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public FMDSState(CalculatorContext context) : base(context)
        {
            Context.Label.Text = "F MD S State";
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
        }

        /// <summary>
        /// Next State after handling Multiplication or Division
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextOpCState()
        {
            return new FMDState(Context);
        }

        /// <summary>
        /// Next State after handling Addition or Subtruction
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextOpSState()
        {
            return new FASState(Context);
        }
    }
}