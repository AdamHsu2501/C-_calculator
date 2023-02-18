using System;

namespace MyCalculator
{
    public abstract class BaseBinaryOperatorNode : TreeNode
    {
        public BaseBinaryOperatorNode(string value, int priority = 1, TreeNode left = null, TreeNode right = null) : base(value,priority, left, right)
        {
        }

        public override string GetResult()
        {
            return Calc(
                    Convert.ToDouble(Left.GetResult()), 
                    Convert.ToDouble(Right.GetResult())
                ).ToString();
        }

        protected abstract double Calc(double a, double b);

    }
}