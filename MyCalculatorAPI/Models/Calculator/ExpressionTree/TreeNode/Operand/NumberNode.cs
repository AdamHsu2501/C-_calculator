namespace MyCalculatorAPI
{
    /// <summary>
    /// Number node of TreeNode
    /// </summary>
    public class NumberNode : TreeNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">value of number</param>
        /// <param name="priority">Priority of node</param>
        /// <param name="left">Left child tree node</param>
        /// <param name="right">Right child tree node</param>
        public NumberNode(string value = "0", int priority = 0, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
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

        /// <summary>
        /// Get value of node
        /// </summary>
        /// <returns>string</returns>
        public override string GetValue()
        {
            return GetResult();
        }
    }
}