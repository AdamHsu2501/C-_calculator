using System;

namespace MyCalculator
{
    public class SqrtNode : TreeNode
    {
        public SqrtNode(string value= "√", int priority = 0, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
        {
        }

        public override string GetResult()
        {
            return Math.Sqrt(Convert.ToDouble(Right.GetResult())).ToString();
        }
    }
}