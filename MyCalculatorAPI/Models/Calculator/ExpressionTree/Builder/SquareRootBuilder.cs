using System;
using System.Collections.Generic;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Square root tree builder
    /// </summary>
    public class SquareRootBuilder : BaseTreeBuilder
    {
        /// <summary>
        /// Action by square root
        /// </summary>
        /// <param name="stack">Stack of TreeNode</param>
        public override void Action(Stack<TreeNode> stack)
        {
            if (Convert.ToDouble(stack.Peek().GetResult()) < 0)
            {
                return;
            }

            TreeNode node = stack.Pop();
            InsertNode(node);

            TreeNode sqrtNode = new SqrtNode();
            sqrtNode.Right = node;

            TreeNode leftParenthesisNode = new LeftParenthesisNode();
            leftParenthesisNode.Right = sqrtNode;

            stack.Push(leftParenthesisNode);
        }

        /// <summary>
        /// Insert Node
        /// </summary>
        /// <param name="node">TreeNode class</param>
        private void InsertNode(TreeNode node)
        {
            if (node.Right != null)
            {
                InsertNode(node.Right);
            }
            else
            {
                node.Right = new RightParenthesisNode();
            }
        }
    }
}