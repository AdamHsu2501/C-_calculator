using System;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Division node of BaseBinaryOperatorNode
    /// </summary>
    public class DivisionNode : BaseBinaryOperatorNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Operator sign</param>
        /// <param name="priority">Priority of operator</param>
        /// <param name="left">Left child tree node</param>
        /// <param name="right">Right child tree node</param>
        public DivisionNode(string value = "/", int priority = 2, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
        {
        }

        /// <summary>
        /// Calculate Division
        /// </summary>
        /// <param name="a">double value a</param>
        /// <param name="b">double value b</param>
        /// <returns>a / b</returns>
        protected override double Calculate(double a, double b)
        {
            return a / b;
        }
    }
}