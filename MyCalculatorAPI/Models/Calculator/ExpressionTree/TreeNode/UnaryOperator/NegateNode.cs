using System;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Negate node of TreeNode
    /// </summary>
    public class NegateNode : TreeNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Operator sign</param>
        /// <param name="priority">Priority of operator</param>
        /// <param name="left">Left child tree node</param>
        /// <param name="right">Right child tree node</param>
        public NegateNode(string value = "negate", int priority = 0, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
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
                return (-Convert.ToDouble(Right.GetResult())).ToString();
            }

            return "0";
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