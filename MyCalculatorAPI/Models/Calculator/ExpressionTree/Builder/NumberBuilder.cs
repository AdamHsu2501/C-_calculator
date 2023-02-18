using System.Collections.Generic;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Number tree builder
    /// </summary>
    public class NumberBuilder
    {
        /// <summary>
        /// Action by number
        /// </summary>
        /// <param name="stack">Stack of TreeNode</param>
        /// <param name="value">String number</param>
        public void Action(Stack<TreeNode> stack, string value)
        {
            if (stack.Peek().Right == null && (stack.Peek().Value == new NumberNode().Value || stack.Peek().Value == new NegateNode().Value))
            {
                stack.Peek().Value = value;
            }
            else
            {
                if (!InsertNode(stack.Peek(), value))
                {
                    stack.Push(new NumberNode(value));
                }
            }
        }

        /// <summary>
        /// Insert Node
        /// </summary>
        /// <param name="node">TreeNode Class</param>
        /// <param name="value">string number</param>
        /// <returns>Boolean</returns>
        public bool InsertNode(TreeNode node, string value)
        {
            if (node.Right != null)
            {
                return InsertNode(node.Right, value);
            }

            if (node.Value == new RightParenthesisNode().Value)
            {
                return false;
            }
            else
            {
                node.Right = new NumberNode(value);
                return true;
            }
        }
    }
}