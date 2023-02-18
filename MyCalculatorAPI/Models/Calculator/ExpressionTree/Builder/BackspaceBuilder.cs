using System.Collections.Generic;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Build Tree with backspace
    /// </summary>
    public class BackspaceBuilder : BaseTreeBuilder
    {
        /// <summary>
        /// Action by backspace
        /// </summary>
        /// <param name="stack">Stack of TreeNode</param>
        public override void Action(Stack<TreeNode> stack)
        {
            TreeNode node = stack.Pop();

            if (node.Right == null)
            {
                stack.Push(new NumberNode());
            }
            else
            {
                RemoveNode(node);

                if (node.Value == new NegateNode().Value && node.Right == null)
                {
                    stack.Push(new NumberNode());
                }
                else
                {
                    stack.Push(node);
                }
            }
        }

        /// <summary>
        /// Remove node
        /// </summary>
        /// <param name="node">TreeNode class</param>
        public void RemoveNode(TreeNode node)
        {
            if (node.Right != null && node.Right.Right != null)
            {
                RemoveNode(node.Right);
            }
            else
            {
                if (node.Right != null && node.Right.Value != new RightParenthesisNode().Value)
                {
                    node.Right = null;
                }
            }
        }
    }
}