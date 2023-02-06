namespace MyCalculator
{
    /// <summary>
    /// F MD State of CalculatorContext
    /// </summary>
    public class FMDState : FASState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public FMDState(CalculatorContext context) : base(context)
        {
            Context.Label.Text = "F MD State";
        }

        /// <summary>
        /// Next State after handling operand
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextOpdState()
        {
            return new FMDSState(Context);
        }

        /// <summary>
        /// Next State after handling Multiplication or Division
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextOpCState()
        {
            return this;
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
