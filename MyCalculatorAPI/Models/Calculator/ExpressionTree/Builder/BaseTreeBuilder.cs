using System.Collections.Generic;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Base Tree Builder
    /// </summary>
    public abstract class BaseTreeBuilder
    {
        /// <summary>
        /// Action by builder
        /// </summary>
        /// <param name="stack">Stack of TreeNode</param>
        public abstract void Action(Stack<TreeNode> stack);
    }
}