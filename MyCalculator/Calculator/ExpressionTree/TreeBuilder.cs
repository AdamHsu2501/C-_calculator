using System;
using System.Collections.Generic;

namespace MyCalculator
{
    public class TreeBuilder
    {
        /// <summary>
        /// Storage values
        /// </summary>
        public Stack<TreeNode> Values { get; set; }

        public TreeNode CurrentOperator { get; set; }

        /// <summary>
        /// Storage Operators
        /// </summary>
        public Stack<TreeNode> Operators { get; set; }

        public int ParenthesisCount { get; set; }

        public OutputFormat OutputFormat { get; set; }

        public List<string> Inputs { get; set; }

        public TreeBuilder()
        {
            OutputFormat = new OutputFormat();
            Init();
        }

        public void Init()
        {
            Values = new Stack<TreeNode>();
            Values.Push(new NumberNode());
            Operators = new Stack<TreeNode>();
            Inputs = new List<string>();
            ParenthesisCount = 0;
        }

        public void PushAndInputPrevValue()
        {
            Values.Push(Values.Peek());
            AddInput(Values.Peek().Value);
        }

        public void PushValue(string value = "0")
        {
            TreeNode node = new NumberNode(OutputFormat.Format(value));
            Values.Push(node);
        }

        public void ResetCurrentValue()
        {
            Values.Pop();
            PushValue();
        }

        public void ConfirmAndInputValue()
        {
            Console.WriteLine(Values.Peek().Value);
            Values.Peek().Value = Convert.ToDouble(Values.Peek().Value).ToString();
            AddInput(Values.Peek().Value);
        }

        public void AddCurrentOperator(TreeNode node)
        {
            CurrentOperator = node;
            Inputs.Add(node.Value);
        }

        public void UpdateCurrentOperator(TreeNode node)
        {
            CurrentOperator = node;
            Inputs[Inputs.Count - 1] = node.Value;
        }

        public void ConfirmOperator()
        {
            CalcAtOperator(CurrentOperator);
            Operators.Push(CurrentOperator);
        }

        public string GetResult()
        {
            return OutputFormat.Format(Values.Peek().GetResult());
        }

        public void AddInput(string value)
        {
            Inputs.Add(value);
        }

        public string GetInputFormula()
        {
            return string.Join(" ", Inputs);
        }

        public void AddLeftParenthesis()
        {
            ParenthesisCount++;
            TreeNode node = new ParenthesisNode();
            Operators.Push(node);
            AddInput(node.Value);
        }


        public void AddRightParenthesis()
        {

            ParenthesisCount--;
            AddInput(")");
            CalcAtParenthesis();
        }

        public void Evaluate()
        {
            CalcAtEqual();
            AddInput("=");
        }

        private void Calc()
        {
            TreeNode right = Values.Pop();
            TreeNode left = Values.Pop();
            TreeNode op = Operators.Pop();
            op.Left = left;
            op.Right = right;
            Values.Push(op);
        }

        private void CalcAtOperator(TreeNode node)
        {
            if (Operators.Count > 0 && Operators.Peek().Priority >= node.Priority && Operators.Peek().Value != new ParenthesisNode().Value)
            {
                Calc();
                CalcAtOperator(node);
            }
        }

        private void CalcAtParenthesis()
        {
            if (Operators.Count > 0)
            {
                if (Operators.Peek().Value == new ParenthesisNode().Value)
                {
                    Operators.Pop();
                }
                else
                {
                    Calc();
                    CalcAtParenthesis();
                }
            }
        }

        private void CalcAtEqual()
        {
            if (ParenthesisCount > 0)
            {
                AddRightParenthesis();
                CalcAtEqual();

            }
            else if (Operators.Count > 0)
            {
                Calc();
                CalcAtEqual();
            }
        }







        public string GetPrefix()
        {
            return Preorder(Values.Peek()).Trim();
        }

        private string Preorder(TreeNode node)
        {
            if (node == null)
            {
                return "";
            }

            List<string> list = new List<string>() { node.Value };

            string left = Preorder(node.Left);
            if (left.Length > 0)
            {
                list.Add(left);
            }

            string right = Preorder(node.Right);
            if (right.Length > 0)
            {
                list.Add(right);
            }

            return string.Join(" ", list);
        }

        public string GetInfix()
        {
            return Inorder(Values.Peek()).Trim();
        }

        private string Inorder(TreeNode node)
        {
            if (node == null)
            {
                return "";
            }

            string left = Inorder(node.Left);
            string right = Inorder(node.Right);
            if (left.Length > 0)
            {
                return "( " + left + " " + node.Value + " " + right + " )";
            }

            return node.Value;
        }

        public string GetPostfix()
        {
            return Postorder(Values.Peek()).Trim();
        }

        private string Postorder(TreeNode node)
        {
            if (node == null)
            {
                return "";
            }

            List<string> list = new List<string>();

            string left = Postorder(node.Left);
            if (left.Length > 0)
            {
                list.Add(left);
            }

            string right = Postorder(node.Right);
            if (right.Length > 0)
            {
                list.Add(right);
            }

            list.Add(node.Value);
            return string.Join(" ", list);
        }
    }
}