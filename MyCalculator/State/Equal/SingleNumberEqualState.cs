namespace MyCalculator
{
    /// <summary>
    /// Single Number Equal State of CalculatorContext
    /// </summary>
    public class SingleNumberEqualState : BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public SingleNumberEqualState(CalculatorContext context) : base(context)
        {
            Context.StateName = "Single Number Equal State";
        }

        /// <summary>
        /// Handle Operand by custom method
        /// </summary>
        protected override void DoOperand()
        {
            Context.PopValue();
            Context.AddValue();
        }

        /// <summary>
        /// Next State after handling operand
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextOpdState()
        {
            return new FState(Context);
        }

        /// <summary>
        /// Handle Operator by custom method
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">string operator</param>
        protected override void DoOperator(BaseArithmetic op, string sign)
        {
            Context.ClearFormula();
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

        /// <summary>
        /// Handle Equal by custom method
        /// </summary>
        /// <param name="sign">Equal sign</param>
        protected override void DoEqual()
        {
        }

        /// <summary>
        /// Next State after handling Equal
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextEqualState()
        {
            return this;
        }

        protected override BaseState GetRollBackState()
        {
            return new FState(Context);
        }

        protected override void DoLeftParenthesis()
        {
        }

        protected override void DoRightParenthesis()
        {
        }
    }
}