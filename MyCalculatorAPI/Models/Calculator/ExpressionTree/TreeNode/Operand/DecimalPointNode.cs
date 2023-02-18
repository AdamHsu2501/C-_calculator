namespace MyCalculatorAPI
{
    /// <summary>
    /// Number node of TreeNode
    /// </summary>
    public class DecimalPointNode : TreeNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">value of number</param>
        /// <param name="priority">Priority of node</param>
        /// <param name="left">Left child tree node</param>
        /// <param name="right">Right child tree node</param>
        public DecimalPointNode(string value = ".", int priority = 0, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
        {
        }

        /// <summary>
        /// return calculate result
        /// </summary>
        /// <returns></returns>
        public override string GetResult()
        {
            if (Right != null)
            {
                return Value + Right.GetResult();
            }

            return Value;
        }
    }
}