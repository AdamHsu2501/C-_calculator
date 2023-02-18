namespace MyCalculator
{
    public class LeftParenthesisButton : BaseButton
    {
        public override void Click(CalculatorContext context, string value)
        {
            context.HandleLeftParenthesis();
        }
    }
}