using System;

namespace MyCalculator
{
    public class NegateNode : TreeNode
    {
        public NegateNode(string value = "negate", int priority = 0, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
        {
        }

        public override string GetResult()
        {
            return (-Convert.ToDouble(Right.GetResult())).ToString();
        }
    }
}