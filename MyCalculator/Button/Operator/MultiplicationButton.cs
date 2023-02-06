namespace MyCalculator
{
    /// <summary>
    /// Multiplication Button
    /// </summary>
    public class MultiplicationButton : BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        /// <param name="value">String type input value</param>
        public override void Click(CalculatorContext context, string value)
        {
            context.HandleOperatorComplex(new Multiplication(), value);
        }
    }
}