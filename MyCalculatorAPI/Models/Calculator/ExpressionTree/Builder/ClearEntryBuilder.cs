using System.Collections.Generic;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Clear entry Tree builder
    /// </summary>
    public class ClearEntryBuilder : BaseTreeBuilder
    {
        /// <summary>
        /// Action by clear entry
        /// </summary>
        /// <param name="stack">Stack of TreeNode</param>
        public override void Action(Stack<TreeNode> stack)
        {
            if (IsCompleteNode(stack.Peek()))
            {
                stack.Pop();
            }
            stack.Push(new NumberNode());
        }

        /// <summary>
        /// Check TreeNode is complete or not
        /// </summary>
        /// <param name="node">TreeNode class</param>
        /// <returns>Boolean</returns>
        private bool IsCompleteNode(TreeNode node)
        {
            if (node.Right != null)
            {
               return IsCompleteNode(node.Right);
            }

            return node.Value != new RightParenthesisNode().Value;
        }
    }
}