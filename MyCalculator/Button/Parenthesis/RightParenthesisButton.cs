namespace MyCalculator
{
    public class RightParenthesisButton : BaseButton
    {
        public override void Click(CalculatorContext context, string value)
        {
            context.HandleRightParenthesis(value);
        }
    }
}