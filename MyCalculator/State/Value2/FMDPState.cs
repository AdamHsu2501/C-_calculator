namespace MyCalculator
{
    public class FMDPState : FMDSState
    {
        public FMDPState(CalculatorContext context) : base(context)
        {
            Context.StateName = "F MD (S) State";
        }

        /// <summary>
        /// Handle Operand by custom method
        /// </summary>
        protected override void DoOperand()
        {
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
            Context.CalcOperator();

            Context.AddFormula(sign);
            Context.AddOperator(op, sign);
        }

        protected override BaseState GetRollBackState()
        {
            return new FState(Context);
        }

        protected override void DoLeftParenthesis()
        {
            Context.CalcOperator();

            Context.AddOperator(new Multiplication(), "*");
            Context.AddFormula("*");
        }

        protected override void DoRightParenthesis()
        {
            Context.AddFormula(Context.GetCurrentValue());
        }
    }
}