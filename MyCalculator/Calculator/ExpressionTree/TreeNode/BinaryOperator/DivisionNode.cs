﻿namespace MyCalculator
{
    public class DivisionNode : BaseBinaryOperatorNode
    {
        public DivisionNode(string value = "/", int priority = 2, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
        {
        }

        protected override double Calc(double a, double b)
        {
            return a / b;
        }
    }
}