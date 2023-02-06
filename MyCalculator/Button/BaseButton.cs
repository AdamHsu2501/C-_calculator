namespace MyCalculator
{
    /// <summary>
    /// Button Base class
    /// </summary>
    public abstract class BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        /// <param name="value">String type input value</param>
        public abstract void Click(CalculatorContext context, string value);
    }
}
