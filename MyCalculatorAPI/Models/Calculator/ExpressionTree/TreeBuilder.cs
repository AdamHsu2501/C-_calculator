﻿using System.Collections.Generic;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Tree builder class
    /// </summary>
    public class TreeBuilder
    {
        /// <summary>
        /// Output Format
        /// </summary>
        private OutputFormat OutputFormat;

        /// <summary>
        /// Stack all tree nodes
        /// </summary>
        public Stack<TreeNode> Values { get; set; }

        /// <summary>
        /// TreeNode current operator
        /// </summary>
        public TreeNode CurrentOperator { get; set; }

        /// <summary>
        /// Stack TreeNode operators waiting to calculate
        /// </summary>
        public Stack<TreeNode> Operators { get; set; }

        /// <summary>
        /// Stack TreeNode right Parenthesis and right brackets 
        /// </summary>
        public Stack<TreeNode> RightBrackets { get; set; }

        /// <summary>
        /// Value list from user inputs
        /// </summary>
        private List<string> Inputs;

        /// <summary>
        /// Constructor
        /// </summary>
        public TreeBuilder()
        {
            OutputFormat = new OutputFormat();
            Init();
        }

        /// <summary>
        /// Push new TreeNode to stack
        /// </summary>
        public void CreateNode()
        {
            Values.Push(new NumberNode());
        }

        /// <summary>
        /// Initial and Push zero to Stack Values
        /// </summary>
        /// <param name="value">Initial number value</param>
        public void Init(string value = "0")
        {
            Values = new Stack<TreeNode>();
            Values.Push(new NumberNode(value));
            Operators = new Stack<TreeNode>();
            RightBrackets = new Stack<TreeNode>();
            Inputs = new List<string>();
        }

        /// <summary>
        /// Initial and Push last result to Stack Values
        /// </summary>
        public void InitalWithResult()
        {
            Init(Values.Peek().GetResult());
        }

        /// <summary>
        /// Get result from peek node of values stack 
        /// </summary>
        /// <returns></returns>
        public string GetResult()
        {
            return OutputFormat.AddCommas(Values.Peek().GetResult());
        }

        /// <summary>
        /// Get input formula
        /// </summary>
        /// <returns></returns>
        public string GetInputFormula()
        {
            return string.Join(" ", Inputs);
        }

        /// <summary>
        /// Get value of TreeNode
        /// </summary>
        /// <param name="node">TreeNode class</param>
        /// <returns>Format number</returns>
        private string GetValue(TreeNode node)
        {
            return OutputFormat.AddCommas(node.GetValue());
        }

        /// <summary>
        /// Get prefix of tree
        /// </summary>
        /// <returns></returns>
        public string GetPrefix()
        {
            return Preorder(Values.Peek());
        }

        /// <summary>
        /// Preorder traversal
        /// </summary>
        /// <param name="node">TreeNode class</param>
        /// <returns>string</returns>
        private string Preorder(TreeNode node)
        {
            if (node == null)
            {
                return "";
            }

            if (node is LeftParenthesisNode)
            {
                return Preorder(node.Right);
            }

            if (node.Left == null)
            {
                return GetValue(node);
            }

            List<string> list = new List<string>();
            list.Add(GetValue(node));
            list.Add(Preorder(node.Left));
            list.Add(Preorder(node.Right));

            return string.Join(" ", list);
        }

        /// <summary>
        /// Get infix of tree
        /// </summary>
        /// <returns>string</returns>
        public string GetInfix()
        {
            return Inorder(Values.Peek());
        }

        /// <summary>
        /// Inorder traversal
        /// </summary>
        /// <param name="node">TreeNode class</param>
        /// <returns>string</returns>
        private string Inorder(TreeNode node)
        {
            if (node == null)
            {
                return "";
            }

            if (node is LeftParenthesisNode)
            {
                return Inorder(node.Right);
            }

            if (node.Left == null)
            {
                return GetValue(node);
            }

            List<string> list = new List<string>();
            list.Add("(");
            list.Add(Inorder(node.Left));
            list.Add(GetValue(node));
            list.Add(Inorder(node.Right));
            list.Add(")");

            return string.Join(" ", list);
        }

        /// <summary>
        /// Get postfix of tree
        /// </summary>
        /// <returns>string</returns>
        public string GetPostfix()
        {
            return Postorder(Values.Peek());
        }

        /// <summary>
        /// Postorder traversal 
        /// </summary>
        /// <param name="node">TreeNode class</param>
        /// <returns>string</returns>
        private string Postorder(TreeNode node)
        {
            if (node == null)
            {
                return "";
            }

            if (node is LeftParenthesisNode)
            {
                return Postorder(node.Right);
            }

            if (node.Left == null)
            {
                return GetValue(node);
            }

            List<string> list = new List<string>();
            list.Add(Postorder(node.Left));
            list.Add(Postorder(node.Right));
            list.Add(GetValue(node));

            return string.Join(" ", list);
        }

        /// <summary>
        /// Reset the node value at the top of Stack Values
        /// </summary>
        public void HandleClearEntry()
        {
            BaseTreeBuilder builder = new ClearEntryBuilder();
            builder.Action(Values);
        }

        /// <summary>
        /// Appends the node to the right of the node at the top of Stack Values
        /// </summary>
        /// <param name="value">Number and decimal point</param>
        public void HandleNumber(string value)
        {
            NumberBuilder builder = new NumberBuilder();
            builder.Action(Values, value);
        }

        /// <summary>
        /// Appends the node to the right of the node at the top of Stack Values
        /// </summary>
        public void HandleDecimalPoint()
        {
            BaseTreeBuilder builder = new DecimalPointBuilder();
            builder.Action(Values);
        }

        /// <summary>
        /// Remove the tail node on the right side of the top node of Stack Values
        /// </summary>
        public void HandleBackspace()
        {
            BaseTreeBuilder builder = new BackspaceBuilder();
            builder.Action(Values);
        }

        /// <summary>
        /// Insert or Remove Negate node to the top node of Stack Values
        /// </summary>
        public void HandleNegate()
        {
            BaseTreeBuilder builder = new NegateBuilder();
            builder.Action(Values);
        }

        /// <summary>
        /// Insert Square Root to the top node of Stack Values
        /// </summary>
        public void HandleSquareRoot()
        {
            BaseTreeBuilder builder = new SquareRootBuilder();
            builder.Action(Values);
        }

        /// <summary>
        /// 1.Compare CurrentOperater with the top node of Stack Operators
        /// 2.Combine the top of Stack Operators with the top two nodes of Stack Values if CurrentOperator has a lower priority
        /// 3.Push CurrentOperator to Stack Operators
        /// </summary>
        public void HandleOperator()
        {
            BinaryOperatorTreeBuilder builder = new BinaryOperatorTreeBuilder();
            builder.Action(Values, Operators, CurrentOperator);
        }

        /// <summary>
        /// List Input add value of the top node of Stack Values
        /// </summary>
        public void InputAddValue()
        {
            Inputs.Add(GetValue(Values.Peek()));
        }

        /// <summary>
        /// Push the top node of Stack Values to Stack Values 
        /// </summary>
        public void PushPeekNode()
        {
            Values.Push(Values.Peek());
        }

        /// <summary>
        /// List Input update the latest CurrentOperator symbol
        /// </summary>
        public void InputUpdateOperator()
        {
            Inputs[Inputs.Count - 1] = CurrentOperator.Value;
        }

        /// <summary>
        /// List Input add CurrentOperator symbol
        /// </summary>
        public void InputAddOperator()
        {
            Inputs.Add(CurrentOperator.Value);
        }

        /// <summary>
        /// Set CurrentOperator with addition TreeNode
        /// </summary>
        public void SetAddition()
        {
            CurrentOperator = new AdditionNode();
        }

        /// <summary>
        /// Set CurrentOperator with subtraction TreeNode 
        /// </summary>
        public void SetSubtraction()
        {
            CurrentOperator = new SubtractionNode();
        }

        /// <summary>
        /// Set CurrentOperator with multiplication TreeNode 
        /// </summary>
        public void SetMultiplication()
        {
            CurrentOperator = new MultiplicationNode();
        }

        /// <summary>
        /// Set CurrentOperator with division TreeNode 
        /// </summary>
        public void SetDivision()
        {
            CurrentOperator = new DivisionNode();
        }

        /// <summary>
        /// 1.Stack Operators push TreeNode left bracket  
        /// 2.List inputs add TreeNode left bracket value
        /// 3.Stack RightBrackets push TreeNode right bracket 
        /// </summary>
        /// <param name="left">Left Bracket TreeNode</param>
        /// <param name="right">Right Bracket TreeNode</param>
        private void DoLeftBracktes(TreeNode left, TreeNode right)
        {
            Operators.Push(left);
            Inputs.Add(left.Value);
            RightBrackets.Push(right);
        }

        /// <summary>
        /// 1.Stack Operators push TreeNode left parenthesis  
        /// 2.List inputs add TreeNode left parenthesis value
        /// 3.Stack RightBrackets push TreeNode right parenthesis 
        /// </summary>
        public void HandleLeftParenthesis()
        {
            DoLeftBracktes(new LeftParenthesisNode(), new RightParenthesisNode());
        }

        /// <summary>
        /// 1.Stack Operators push TreeNode left bracket  
        /// 2.List inputs add TreeNode left bracket value
        /// 3.Stack RightBrackets push TreeNode right bracket 
        /// </summary>
        public void HandleLeftBrackets()
        {
            DoLeftBracktes(new LeftParenthesisNode("["), new RightParenthesisNode("]"));
        }

        /// <summary>
        /// Calculate the formula in parentheses
        /// List Inputs add right bracket symbol
        /// </summary>
        public void HandleRightParenthesis()
        {
            if (RightBrackets.Count > 0)
            {
                Inputs.Add(RightBrackets.Peek().Value);
                Calculate();
            }
        }

        /// <summary>
        /// Calculate formula
        /// List Inputs add right bracket symbol if RightBrackets is not empty
        /// List Inputs add equal symbol
        /// </summary>
        public void HandleEqual()
        {
            int count = RightBrackets.Count;
            for (int i = 0; i < count; i++)
            {
                HandleRightParenthesis();
            }

            Calculate();
            Inputs.Add("=");
        }

        /// <summary>
        /// Calculate Result
        /// </summary>
        private void Calculate()
        {
            if (Operators.Count == 0)
            {
                return;
            }

            TreeNode op = Operators.Pop();

            if (op is LeftParenthesisNode)
            {
                op.Right = Values.Pop();
                Values.Push(op);
                AddRightParenthesis(op.Right);
            }
            else
            {
                op.Right = Values.Pop();
                op.Left = Values.Pop();
                Values.Push(op);
                Calculate();
            }
        }

        /// <summary>
        /// Append a right parenthesis to the right of the node
        /// </summary>
        /// <param name="node">TreeNode class</param>
        private void AddRightParenthesis(TreeNode node)
        {
            if (node.Right != null)
            {
                AddRightParenthesis(node.Right);
            }
            else
            {
                node.Right = RightBrackets.Pop();
            }
        }
    }
}