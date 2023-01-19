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
        /// <param name="manager">UIManager class</param>
        /// <param name="value">String type input value</param>
        public override void Click(UIManager manager, string value)
        {
            manager.ClearIfIsEnd();

            string currentValue = manager.Pop();
            currentValue += value;
            manager.FormatPushAndOutput(currentValue);
        }
    }
}
