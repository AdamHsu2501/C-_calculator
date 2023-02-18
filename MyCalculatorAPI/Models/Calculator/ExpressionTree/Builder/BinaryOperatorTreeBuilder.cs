using System.Collections.Generic;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Binary operator tree builder
    /// </summary>
    public class BinaryOperatorTreeBuilder
    {
        /// <summary>
        /// Action with binary operator
        /// </summary>
        /// <param name="stack">Stack of TreeNode</param>
        /// <param name="operators">Stack of operators TreeNode</param>
        /// <param name="node">Current input Operator TreeNode</param>
        public virtual void Action(Stack<TreeNode> stack, Stack<TreeNode> operators, TreeNode node)
        {
            if (operators.Count > 0 && operators.Peek().Value != new LeftParenthesisNode().Value && operators.Peek().Priority >= node.Priority)
            {
                TreeNode op = operators.Pop();
                op.Right = stack.Pop();
                op.Left = stack.Pop();
                AddRightParenthesis(op.Right, 1);

                TreeNode leftParenthesisNode = new LeftParenthesisNode();
                leftParenthesisNode.Right = op;
                
                stack.Push(leftParenthesisNode);
                Action(stack, operators, node);
            }
            else
            {
                operators.Push(node);
            }
        }

        /// <summary>
        /// Add right parenthesis
        /// </summary>
        /// <param name="node">TreeNode class</param>
        /// <param name="count">Count of left parenthesis</param>
        private void AddRightParenthesis(TreeNode node, int count)
        {
            if (node.Value == new LeftParenthesisNode().Value)
            {
                count++;
            }

            if (node.Value == new RightParenthesisNode().Value)
            {
                count--;
            }

            if (node.Right != null)
            {
                AddRightParenthesis(node.Right, count);
            }
            else
            {
                if (count > 0)
                {
                    node.Right = new RightParenthesisNode();
                    AddRightParenthesis(node.Right, --count);
                }
            }
        }
    }
}