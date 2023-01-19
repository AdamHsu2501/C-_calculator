using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        /// <param name="manager">UIManager class</param>
        /// <param name="value">String type input value</param>
        public override void Click(UIManager manager, string value)
        {
            string currentValue = manager.Pop();
            currentValue = currentValue.Substring(0, Math.Max(currentValue.Length - 1, 0));
            manager.FormatPushAndOutput(currentValue);
        }
    }
}
