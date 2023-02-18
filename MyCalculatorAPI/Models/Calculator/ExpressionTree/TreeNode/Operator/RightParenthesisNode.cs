namespace MyCalculatorAPI
{
    /// <summary>
    /// Right parenthesis node of TreeNode
    /// </summary>
    public class RightParenthesisNode : TreeNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Operator sign</param>
        /// <param name="priority">Priority of operator</param>
        /// <param name="left">Left child tree node</param>
        /// <param name="right">Right child tree node</param>
        public RightParenthesisNode(string value = ")", int priority = 3, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
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
                return Right.GetResult();
            }

            return string.Empty;
        }
    }
}