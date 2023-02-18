using System.Collections.Generic;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Decimal point tree builder
    /// </summary>
    public class DecimalPointBuilder : BaseTreeBuilder
    {
        /// <summary>
        /// Action by decimal point
        /// </summary>
        /// <param name="stack">Stack of TreeNode</param>
        public override void Action(Stack<TreeNode> stack)
        {
            DoAction(stack.Peek());
        }

        /// <summary>
        /// Insert node
        /// </summary>
        /// <param name="node">TreeNode class</param>
        private void DoAction(TreeNode node)
        {
            if (node.Value == new DecimalPointNode().Value || node.Value == new RightParenthesisNode().Value)
            {
                return;
            }

            if (node.Right != null)
            {
                DoAction(node.Right);
            }
            else
            {
                node.Right = new DecimalPointNode();
            }
        }
    }
}