using System.Text.RegularExpressions;

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
        /// <param name="manager">UIManager class</param>
        /// <param name="value">String type input value</param>
        public override void Click(UIManager manager, string value)
        {
            manager.Pop();
            manager.FormatPushAndOutput("0");

            string pattern = @".+=";
            string label = "";
            manager.DisplayProcess(pattern, label);
        }
    }
}
