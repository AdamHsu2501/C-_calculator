namespace MyCalculatorAPI
{
    public partial class CalculatorController
    {
        public class CalculatorResult
        {
            /// <summary>
            /// User input Formula
            /// </summary>
            public string Formula { get; set; }

            /// <summary>
            /// Infix of formula 
            /// </summary>
            public string Infix { get; set; }

            /// <summary>
            /// Prefix of formula
            /// </summary>
            public string Prefix { get; set; }

            /// <summary>
            /// Postfix of formula
            /// </summary>
            public string Postfix { get; set; }

            /// <summary>
            /// Formula calculate result
            /// </summary>
            public string Result { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="Tree">TreeBuilder</param>
            public CalculatorResult(TreeBuilder Tree)
            {
                Formula = Tree.GetInputFormula();
                Infix = Tree.GetInfix();
                Prefix = Tree.GetPrefix();
                Postfix = Tree.GetPostfix();
                Result = Tree.GetResult();
            }
        }
    }
}
