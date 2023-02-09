using System;

namespace MyCalculator
{
    /// <summary>
    /// Arithmetic Class
    /// </summary>
    public class BaseArithmetic
    {
        /// <summary>
        /// Calculate string number a and b
        /// </summary>
        /// <param name="a">String number a</param>
        /// <param name="b">String number b</param>
        /// <returns></returns>
        public string GetResult(string a, string b)
        {
            Console.WriteLine(a + a.GetType());
            Console.WriteLine(b + b.GetType());
            return DoAction(Convert.ToDouble(a), Convert.ToDouble(b)).ToString();
        }

        /// <summary>
        /// Handle Action by custom method in child class 
        /// </summary>
        /// <param name="a">Double a</param>
        /// <param name="b">Double b</param>
        /// <returns></returns>
        protected virtual double DoAction(double a, double b)
        {
            return a;
        }
    }
}
