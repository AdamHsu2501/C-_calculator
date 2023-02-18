using System.Collections.Generic;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Negate tree Builder
    /// </summary>
    public class NegateBuilder : BaseTreeBuilder
    {
        /// <summary>
        /// Action by Negate
        /// </summary>
        /// <param name="stack">Stack of TreeNode</param>
        public override void Action(Stack<TreeNode> stack)
        {
            if (stack.Peek().Value == new NumberNode().Value && stack.Peek().Right == null)
            {
                return;
            }

            TreeNode negateNode = new NegateNode();

            if (stack.Peek().Value == negateNode.Value)
            {
                TreeNode node = stack.Pop();
                stack.Push(node.Right);
            }
            else
            {
                negateNode.Right = stack.Pop();
                stack.Push(negateNode);
            }
        }
    }
}