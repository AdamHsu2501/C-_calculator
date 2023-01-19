using System;
using System.Text.RegularExpressions;

namespace MyCalculator
{
    /// <summary>
    /// Equals button
    /// </summary>
    public class EqualsButton : BaseButton
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
            string zeroPattern = @"^0$";
            string operand = Regex.Replace(result.Item3.ToString(), zeroPattern, result.Item2.ToString());
            string label = string.Format("{0} {1} {2} =", result.Item2, result.Item1, operand);
            manager.OperatorProcess(result.Item1, sum, operand, label);
        }
    }
}
