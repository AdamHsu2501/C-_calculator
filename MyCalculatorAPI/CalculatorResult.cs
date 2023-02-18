namespace MyCalculatorAPI.Controllers
{
    public partial class CalculatorController
    {
        public class CalculatorResult
        {
            public string Formula { get; set; }
            public string Infix { get; set; }
            public string Prefix { get; set; }
            public string Postfix { get; set; }
            public string Result { get; set; }

            public CalculatorResult(MyCalculator.CalculatorContext Context)
            {
                Formula = Context.GetFormula();
                Infix = Context.Tree.GetInfix();
                Prefix = Context.Tree.GetPrefix();
                Postfix = Context.Tree.GetPostfix();
                Result = Context.GetResult();
            }
        }
    }
}
