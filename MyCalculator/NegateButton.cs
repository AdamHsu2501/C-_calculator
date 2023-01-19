using System;

namespace MyCalculator
{
    /// <summary>
    /// Negate button
    /// </summary>
    public class NegateButton : BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="manager">UIManager class</param>
        /// <param name="value">String type input value</param>
        public override void Click(UIManager manager, string value)
        {
            string currentValue = manager.Pop();
            currentValue = (-Convert.ToDecimal(currentValue)).ToString();
            manager.FormatPushAndOutput(currentValue);
        }
    }
}
