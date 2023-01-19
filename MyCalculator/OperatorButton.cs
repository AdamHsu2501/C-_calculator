using System;
using System.Text.RegularExpressions;

namespace MyCalculator
{
    /// <summary>
    /// Operator button: +, -, *, /
    /// </summary>
    public class OperatorButton : BaseButton
    {
        /// <summary>
        /// Button click method
        /// </summary>
        /// <param name="manager">UIManager class</param>
        /// <param name="value">String type input value</param>
        public override void Click(UIManager manager, string value)
        {
            Tuple<string, double, double, double> result = manager.GetResult();

            string sum = result.Item4.ToString();
            string operand = "0";
            string label = string.Format("{0} {1}", sum, value);
            manager.OperatorProcess(value, sum, operand, label);
        }
    }
}
