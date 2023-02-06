namespace MyCalculator
{
    /// <summary>
    /// Subtraction class of BaseArithmetic
    /// </summary>
    public class Subtraction : BaseArithmetic
    {
        /// <summary>
        /// Subtraction
        /// </summary>
        /// <param name="a">Double a</param>
        /// <param name="b">Double b</param>
        /// <returns>a - b</returns>
        protected override double DoAction(double a, double b)
        {
            return a - b;
        }
    }
}
