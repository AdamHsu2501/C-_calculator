namespace MyCalculatorAPI
{
    /// <summary>
    /// Calculator Result
    /// </summary>
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
        /// Current state name
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cal">CalculatorContext class</param>
        public CalculatorResult(CalculatorContext cal)
        {
            Formula = cal.Tree.GetInputFormula();
            Infix = cal.Tree.GetInfix();
            Prefix = cal.Tree.GetPrefix();
            Postfix = cal.Tree.GetPostfix();
            Result = cal.Tree.GetResult();
            StateName = cal.StateName;
        }
    }
}
