namespace MyCalculator
{
    /// <summary>
    /// Addition Button
    /// </summary>
    public class AdditionButton : BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        /// <param name="value">String type input value</param>
        public override void Click(CalculatorContext context, string value)
        {
            context.HandleOperatorSimple(new Addition(), value);
        }
    }
}