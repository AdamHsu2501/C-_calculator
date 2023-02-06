namespace MyCalculator
{
    /// <summary>
    /// Division class of BaseArithmetic
    /// </summary>
    public class Division : BaseArithmetic
    {
        /// <summary>
        /// Division
        /// </summary>
        /// <param name="a">Double a</param>
        /// <param name="b">Double b</param>
        /// <returns>a / b</returns>
        protected override double DoAction(double a, double b)
        {
            return a / b;
        }
    }
}
