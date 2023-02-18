namespace MyCalculator
{
    public class AdditionNode : BaseBinaryOperatorNode
    {
        public AdditionNode(string value = "+", int priority = 1, TreeNode left = null, TreeNode right = null) : base(value,priority, left, right)
        {
        }

        protected override double Calc(double a, double b)
        {
            return a + b;
        }
    }
}