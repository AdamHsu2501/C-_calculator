using MyCalculatorAPI.Models;

namespace MyCalculator
{
    /// <summary>
    /// F AS S AS State of CalculatorContext
    /// </summary>
    public class FASSASState : BaseState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        public FASSASState(CalculatorContext context) : base(context)
        {
            Context.StateName = "F AS S AS State";
        }

        /// <summary>
        /// Handle Operand by custom method
        /// </summary>
        protected override void DoOperand()
        {
            TreeNode op = Context.PopOperator();
            Context.CalcOperator();

            Context.AddOperator(op.Operator, op.Label);
            Context.AddValue();
        }

        /// <summary>
        /// Next State after handling operand
        /// </summary>
        /// <returns>BaseState</returns>
        protected override BaseState GetNextOpdState()
        {
            return new FASSState(Context);
        }

        /// <summary>
        /// Handle Operator by custom method
        /// </summary>
        /// <param name="op">BaseArithmetic</param>
        /// <param name="sign">string operator</param>
        protected override void DoOperator(BaseArithmetic op, string sign)
        {
            Context.EditOperator(op, sign);
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
            return this;
        }

        /// <summary>
        /// Handle Equal by custom method
        /// </summary>
        /// <param name="sign">Equal sign</param>
        protected override void DoEqual(string sign)
        {
            string currentValue = Context.GetCurrentValue();
            Context.AddFormula(Context.GetCurrentValue());

            TreeNode op = Context.PopOperator();

            Context.CalcOperator();

            Context.AddOperator(op.Operator, op.Label);

            Context.AddValue(currentValue);

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