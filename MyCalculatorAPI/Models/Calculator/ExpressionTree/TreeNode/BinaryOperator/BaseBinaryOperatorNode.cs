using System;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Base binary operator node of TreeNode
    /// </summary>
    public abstract class BaseBinaryOperatorNode : TreeNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Operator sign</param>
        /// <param name="priority">Priority of operator</param>
        /// <param name="left">Left child tree node</param>
        /// <param name="right">Right child tree node</param>
        public BaseBinaryOperatorNode(string value, int priority = 1, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
        {
        }

        /// <summary>
        /// return calculate result
        /// </summary>
        /// <returns></returns>
        public override string GetResult()
        {
            return Calc(
                    Convert.ToDouble(Left.GetResult()), 
                    Convert.ToDouble(Right.GetResult())
                ).ToString();
        }

        /// <summary>
        /// Custom Calculate method
        /// </summary>
        /// <param name="a">Double value a</param>
        /// <param name="b">Double value b</param>
        /// <returns></returns>
        protected abstract double Calc(double a, double b);
    }
}