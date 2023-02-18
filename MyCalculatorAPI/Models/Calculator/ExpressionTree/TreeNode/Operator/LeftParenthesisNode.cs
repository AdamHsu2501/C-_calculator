namespace MyCalculatorAPI
{
    /// <summary>
    /// Left parenthesis node of TreeNode
    /// </summary>
    public class LeftParenthesisNode : TreeNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Operator sign</param>
        /// <param name="priority">Priority of operator</param>
        /// <param name="left">Left child tree node</param>
        /// <param name="right">Right child tree node</param>
        public LeftParenthesisNode(string value = "(", int priority = 0, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
        {
        }

        /// <summary>
        /// return calculate result
        /// </summary>
        /// <returns></returns>
        public override string GetResult()
        {
            return Right.GetResult();
        }

        /// <summary>
        /// Get value of node
        /// </summary>
        /// <returns>string</returns>
        public override string GetValue()
        {
            if (Right != null)
            {
                return Right.GetValue();
            }
            return string.Empty;
        }
    }
}