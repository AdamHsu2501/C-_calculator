namespace MyCalculator
{
    /// <summary>
    /// Clear entry button
    /// </summary>
    public class ClearEntryButton : BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        /// <param name="value">String type input value</param>
        public override void Click(CalculatorContext context, string value)
        {
            context.HandleClearEntry();
        }
    }
}