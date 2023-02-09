using System;

namespace MyCalculator
{
    public class TreeNode
    {
        public string Label { get; set; }

        public BaseArithmetic Operator { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode(string label = "0", BaseArithmetic op = null, TreeNode left = null, TreeNode right = null)
        {
            Label = label;
            Operator = op;
            Left = left;
            Right = right;
        }

        public bool IsOperator()
        {
            return Operator != null;
        }

        public string GetResult()
        {
            if (!IsOperator())
            {
                return Convert.ToDouble(Label).ToString();
            }

            string left = Left != null ? Left.GetResult() : "0";
            string right = Right != null ? Right.GetResult() : left;

            return Operator.GetResult(left, right);
        }
    }
}