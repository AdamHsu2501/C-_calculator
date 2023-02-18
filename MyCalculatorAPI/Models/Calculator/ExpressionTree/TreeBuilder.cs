using System.Collections.Generic;

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
        /// Current operator tree node out of tree
        /// </summary>
        public TreeNode CurrentOperator { get; set; }

        /// <summary>
        /// Stack all Operators tree nodes
        /// </summary>
        public Stack<TreeNode> Operators { get; set; }

        /// <summary>
        /// Count left Parenthesis 
        /// </summary>
        private int ParenthesisCount = 0;

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
        /// Initial tree
        /// </summary>
        /// <param name="value">Initial number value</param>
        public void Init(string value = "0")
        {
            Values = new Stack<TreeNode>();
            Values.Push(new NumberNode(value));
            Operators = new Stack<TreeNode>();
            Inputs = new List<string>();
            ParenthesisCount = 0;
        }

        /// <summary>
        /// Initial tree with last result
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

            if (node.Value == new LeftParenthesisNode().Value)
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

            if (node.Value == new LeftParenthesisNode().Value)
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

            if (node.Value == new LeftParenthesisNode().Value)
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
        /// Handle clear entry
        /// </summary>
        public void HandleClearEntry()
        {
            BaseTreeBuilder builder = new ClearEntryBuilder();
            builder.Action(Values);
        }

        /// <summary>
        /// Handle number: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        /// </summary>
        /// <param name="value">Number and decimal point</param>
        public void HandleNumber(string value)
        {
            NumberBuilder builder = new NumberBuilder();
            builder.Action(Values, value);
        }

        /// <summary>
        /// Handle decimal point
        /// </summary>
        public void HandleDecimalPoint()
        {
            BaseTreeBuilder builder = new DecimalPointBuilder();
            builder.Action(Values);
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        public void HandleBackspace()
        {
            BaseTreeBuilder builder = new BackspaceBuilder();
            builder.Action(Values);
        }

        /// <summary>
        /// Handle negative 
        /// </summary>
        public void HandleNegate()
        {
            BaseTreeBuilder builder = new NegateBuilder();
            builder.Action(Values);
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        public void HandleSquareRoot()
        {
            BaseTreeBuilder builder = new SquareRootBuilder();
            builder.Action(Values);
        }

        /// <summary>
        /// Handle Operator
        /// </summary>
        public void HandleOperator()
        {
            BinaryOperatorTreeBuilder builder = new BinaryOperatorTreeBuilder();
            builder.Action(Values, Operators, CurrentOperator);
        }

        /// <summary>
        /// Input list add value of peek node of values stack 
        /// </summary>
        public void InputAddValue()
        {
            Inputs.Add(GetValue(Values.Peek()));
        }

        /// <summary>
        /// Value stack push peek node
        /// </summary>
        public void PushPeekNode()
        {
            Values.Push(Values.Peek());
        }

        /// <summary>
        /// Input list update operator sign
        /// </summary>
        public void InputUpdateOperator()
        {
            Inputs[Inputs.Count - 1] = CurrentOperator.Value;
        }

        /// <summary>
        /// Input list add operator sign
        /// </summary>
        public void InputAddOperator()
        {
            Inputs.Add(CurrentOperator.Value);
        }

        /// <summary>
        /// Set current operator to addition
        /// </summary>
        public void SetAddition()
        {
            CurrentOperator = new AdditionNode();
        }

        /// <summary>
        /// Set current operator to subtraction
        /// </summary>
        public void SetSubtraction()
        {
            CurrentOperator = new SubtractionNode();
        }

        /// <summary>
        /// Set current operator to multiplication
        /// </summary>
        public void SetMultiplication()
        {
            CurrentOperator = new MultiplicationNode();
        }

        /// <summary>
        /// Set current operator to division
        /// </summary>
        public void SetDivision()
        {
            CurrentOperator = new DivisionNode();
        }

        /// <summary>
        /// Handle left parenthesis
        /// </summary>
        public void HandleLeftParenthesis()
        {
            TreeNode node = new LeftParenthesisNode();
            Operators.Push(node);
            Inputs.Add(node.Value);
            ParenthesisCount++;
        }

        /// <summary>
        /// Hnalde right parenthesis
        /// </summary>
        public void HandleRightParenthesis()
        {
            if (ParenthesisCount > 0)
            {
                Calculate();
                Inputs.Add(new RightParenthesisNode().Value);
                ParenthesisCount--;
            }
        }

        /// <summary>
        /// Handle equal
        /// </summary>
        public void HandleEqual()
        {
            int count = ParenthesisCount;
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
        public void Calculate()
        {
            if (Operators.Count == 0)
            {
                return;
            }

            TreeNode op = Operators.Pop();

            if (op.Value != new LeftParenthesisNode().Value)
            {
                op.Right = Values.Pop();
                op.Left = Values.Pop();
                Values.Push(op);
                Calculate();
            }
            else
            {
                op.Right = Values.Pop();
                Values.Push(op);
                AddRightParenthesis(op.Right);
            }
        }

        /// <summary>
        /// Add right parenthesis
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
                node.Right = new RightParenthesisNode();
            }
        }
    }
}