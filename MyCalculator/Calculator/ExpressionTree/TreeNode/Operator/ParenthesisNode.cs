namespace MyCalculator
{
    public class ParenthesisNode : TreeNode
    {
        public ParenthesisNode(string value = "(", int priority = 3, TreeNode left = null, TreeNode right = null) : base(value, priority, left, right)
        {

        }

        public override string GetResult()
        {
            throw new System.NotImplementedException();
        }
    }
}