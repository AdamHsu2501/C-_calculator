namespace MyCalculator
{
    public class NumberNode : TreeNode
    {
        public NumberNode(string value = "0", int priority = 0, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
        {
        }

        public override string GetResult()
        {
            return Value;
        }
    }
}