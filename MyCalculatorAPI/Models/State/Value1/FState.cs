using System;

namespace MyCalculator
{
    /// <summary>
    /// F State of CalculatorContext
    /// </summary>
    public class FState : BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public FState(CalculatorContext context) : base(context)
        {
            Context.StateName = "F state";
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
            Context.ConfirmValue();

            Context.AddFormula(Context.GetCurrentValue());
            Context.AddFormula(sign);

            Context.AddOperator(op, sign);
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
        protected override void DoEqual(string sign)
        {
            Context.ClearFormula();
            string currentValue = Context.PopValue().Label;
            currentValue = Convert.ToDouble(currentValue).ToString();
            Context.AddValue(currentValue);

            Context.AddFormula(Context.GetCurrentValue());
            Context.AddFormula(sign);
        }

        /// <summary>
        /// Next State after handling Equal
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextEqualState()
        {
            return new SingleNumberEqualState(Context);
        }
    }
}
