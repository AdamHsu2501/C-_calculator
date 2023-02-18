namespace MyCalculator
{
    public abstract class TreeNode
    {
        public string Value { get; set; }

        public int Priority { get; set; }


        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }


        public TreeNode(string value, int priority=0, TreeNode left= null, TreeNode right = null)
        {

            Value = value;
            Priority = priority;
            Left = left;
            Right = right;
        }

        public abstract string GetResult();
    }
}