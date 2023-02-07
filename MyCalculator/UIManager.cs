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
        /// Title label
        /// </summary>
        private Label TitleLabel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="outputLabel">Main label</param>
        /// <param name="processLabel">Processs label</param>
        /// <param name="titleLabel">Title label </param>
        public UIManager(Label outputLabel, Label processLabel, Label titleLabel)
        {
            OutputLabel = outputLabel;
            ProcessLabel = processLabel;
            TitleLabel = titleLabel;
        }

        /// <summary>
        /// Display value
        /// </summary>
        /// <param name="formula">String of formula</param>
        /// <param name="value">String of sum value</param>
        /// <param name="title">title  of current state</param>
        public void Display(string formula, string value, string title)
        {
            ProcessLabel.Text = formula;
            OutputLabel.Text = value;
            TitleLabel.Text = title;
        }
    }
}