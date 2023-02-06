namespace MyCalculator
{
    /// <summary>
    /// Backspace button
    /// </summary>
    public class BackspaceButton : BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        /// <param name="value">String type input value</param>
        public override void Click(CalculatorContext context, string value)
        {
            context.HandleBackspace();
        }
    }
}
