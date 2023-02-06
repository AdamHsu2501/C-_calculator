namespace MyCalculator
{
    /// <summary>
    /// Addition class of BaseArithmetic
    /// </summary>
    public class Addition : BaseArithmetic
    {
        /// <summary>
        /// Addition
        /// </summary>
        /// <param name="a">Double a</param>
        /// <param name="b">Double b</param>
        /// <returns>a + b</returns>
        protected override double DoAction(double a, double b)
        {
            return a + b;
        }
    }
}
