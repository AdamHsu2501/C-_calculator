using System;
using System.Net.Http;
using System.Windows.Forms;
using System.Text.Json;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        UIManager UIManager;
        HttpClient Client = new HttpClient();
        string Url = "http://localhost:56677/api/calculator/";

        public Form1()
        {
            InitializeComponent();
            UIManager = new UIManager(labelResult, labelFormula, modeLabel);

            button0.Tag = "number0";
            button1.Tag = "number1";
            button2.Tag = "number2";
            button3.Tag = "number3";
            button4.Tag = "number4";
            button5.Tag = "number5";
            button6.Tag = "number6";
            button7.Tag = "number7";
            button8.Tag = "number8";
            button9.Tag = "number9";
            buttonDecimalPoint.Tag = "decimalpoint";
            buttonNegate.Tag = "negate";
            buttonBackspace.Tag = "backspace";
            buttonSquareRoot.Tag = "squareroot";

            buttonAddition.Tag = "addition";
            buttonSubtraction.Tag = "subtraction";
            buttonMultiplication.Tag = "multiplication";
            buttonDivision.Tag = "division";

            buttonLeftParenthesis.Tag = "leftparenthesis";
            buttonRightParenthesis.Tag = "rightparenthesis";

            buttonClear.Tag = "clear";
            buttonClearEntry.Tag = "clearentry";

            buttonEqual.Tag = "equal";
        }

        private async void button_Click(object sender, EventArgs e)
        {
            string uri = Url + (string)((Button)sender).Tag;
            HttpResponseMessage response = await Client.GetAsync(uri);

            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            var content = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultObject>(jsonString);

            labelResult.Text = content.Result;
            labelFormula.Text = content.Formula;
            labelInfix.Text = content.Infix;
            labelPrefix.Text = content.Prefix;
            labelPostfix.Text = content.Postfix;
            modeLabel.Text = content.StateName;
        }
    }
}
