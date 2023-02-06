using System.Windows.Forms;

namespace MyCalculator
{
    /// <summary>
    /// Manager UI
    /// </summary>
    public class UIManager
    {
        /// <summary>
        /// Main output label
        /// </summary>
        private Label OutputLabel;

        /// <summary>
        /// Process output label
        /// </summary>
        private Label ProcessLabel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="outputLabel">Main label class</param>
        /// <param name="processLabel">Processs label class</param>
        public UIManager(Label outputLabel, Label processLabel)
        {
            OutputLabel = outputLabel;
            ProcessLabel = processLabel;
        }

        /// <summary>
        /// Display value
        /// </summary>
        /// <param name="formula">String of formula</param>
        /// <param name="value">String of sum value</param>
        public void Display(string formula, string value)
        {
            ProcessLabel.Text = formula;
            OutputLabel.Text = value;
        }
    }
}