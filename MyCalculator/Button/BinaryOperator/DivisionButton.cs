namespace MyCalculator
{
    /// <summary>
    /// Division Button
    /// </summary>
    public class DivisionButton : BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="context">CalculatorContext</param>
        /// <param name="value">String type input value</param>
        public override void Click()
        {
            context.HandleOperator(new DivisionNode());
        }
    }
}