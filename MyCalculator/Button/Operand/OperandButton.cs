namespace MyCalculator
{
    /// <summary>
    /// Operand Button: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, .
    /// </summary>
    public class OperandButton : BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        /// <param name="value">String type input value</param>
        public override void Click(CalculatorContext context, string value)
        {
            context.HandleOperand(value);
        }
    }
}
