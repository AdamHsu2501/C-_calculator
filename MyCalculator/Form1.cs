using System;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        CalculatorContext Context;
        UIManager UIManager;

        public Form1()
        {
            InitializeComponent();

            Context = new CalculatorContext();
            UIManager = new UIManager(mainLabel, subLabel, modeLabel);
            button0.Tag = new OperandButton();
            button1.Tag = new OperandButton();
            button2.Tag = new OperandButton();
            button3.Tag = new OperandButton();
            button4.Tag = new OperandButton();
            button5.Tag = new OperandButton();
            button6.Tag = new OperandButton();
            button7.Tag = new OperandButton();
            button8.Tag = new OperandButton();
            button9.Tag = new OperandButton();
            buttonDecimalPoint.Tag = new OperandButton();
            buttonNegate.Tag = new NegateButton();
            buttonBackspace.Tag = new BackspaceButton();
            buttonSquareRoot.Tag = new SquareRootButton();

            buttonAddition.Tag = new AdditionButton();
            buttonSubtraction.Tag = new SubtractionButton();
            buttonMultiplication.Tag = new MultiplicationButton();
            buttonDivision.Tag = new DivisionButton();

            buttonClear.Tag = new ClearButton();
            buttonClearEntry.Tag = new ClearEntryButton();

            buttonEqual.Tag = new EqualsButton();
        }

        private void button_Click(object sender, EventArgs e)
        {
            string text = (sender as Button).Text;
            BaseButton button = (BaseButton)((Button)sender).Tag;
            button.Click(Context, text);

            UIManager.Display(Context.GetFormula(), Context.GetCurrentValue(), Context.StateName);
        }
    }
}
