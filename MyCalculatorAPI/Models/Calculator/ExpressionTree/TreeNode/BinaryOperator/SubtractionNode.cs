namespace MyCalculatorAPI
{
    /// <summary>
    /// Subtraction node of BaseBinaryOperatorNode
    /// </summary>
    public class SubtractionNode : BaseBinaryOperatorNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Operator sign</param>
        /// <param name="priority">Priority of operator</param>
        /// <param name="left">Left child tree node</param>
        /// <param name="right">Right child tree node</param>
        public SubtractionNode(string value = "-", int priority = 1, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
        {
        }

        /// <summary>
        /// Calculate Subtraction
        /// </summary>
        /// <param name="a">double value a</param>
        /// <param name="b">double value b</param>
        /// <returns>a - b</returns>
        protected override double Calc(double a, double b)
        {
            return a - b;
        }
    }
}