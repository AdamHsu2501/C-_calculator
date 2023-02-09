namespace MyCalculator
{
    /// <summary>
    /// F AS S State of CalculatorContext
    /// </summary>
    public class FASSState : BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public FASSState(CalculatorContext context) : base(context)
        {
            Context.StateName = "F AS S State";
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
            Context.AddFormula(Context.GetValueResult());
            Context.AddFormula(sign);

            Context.AddOperator(op, sign);
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
        protected override void DoEqual()
        {
            Context.AddFormula(Context.GetValueResult());
            Context.CalcEqual();
        }

        /// <summary>
        /// Next State after handling Equal
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextEqualState()
        {
            return new EqualState(Context);
        }

        protected override BaseState GetRollBackState()
        {
            return new FASSMDPState(Context);
        }

        protected override void DoLeftParenthesis()
        {
            Context.AddOperator(new Multiplication(), "*");
            Context.AddFormula("*");
        }

        protected override void DoRightParenthesis()
        {
            Context.AddFormula(Context.GetValueResult());
            Context.CalcOperator();
        }
    }
}
