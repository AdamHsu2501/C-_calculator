namespace MyCalculatorAPI
{
    /// <summary>
    /// Custom TreeNode
    /// </summary>
    public abstract class TreeNode
    {
        /// <summary>
        /// String value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Priority of node
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Left child TreeNode
        /// </summary>
        public TreeNode Left { get; set; }

        /// <summary>
        /// Right child TreeNode
        /// </summary>
        public TreeNode Right { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="priority">Priority of operator</param>
        /// <param name="left">Left child tree node</param>
        /// <param name="right">Right child tree node</param>
        public TreeNode(string value, int priority = 0, TreeNode left = null, TreeNode right = null)
        {
            Value = value;
            Priority = priority;
            Left = left;
            Right = right;
        }

        /// <summary>
        /// return calculate result
        /// </summary>
        /// <returns></returns>
        public abstract string GetResult();

        /// <summary>
        /// Get value of node
        /// </summary>
        /// <returns>string</returns>
        public virtual string GetValue()
        {
            return Value;
        }
    }
}