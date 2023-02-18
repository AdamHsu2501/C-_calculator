using System;
using System.Runtime.Caching;

namespace MyCalculatorAPI
{
    /// <summary>
    /// Calculator manager
    /// </summary>
    public static class CalculatorManager
    {
        /// <summary>
        /// Is memory cache contains id
        /// </summary>
        /// <param name="id">Calculator id</param>
        /// <returns></returns>
        public static bool IsContains(string id)
        {
            return MemoryCache.Default.Contains(id);
        }

        /// <summary>
        /// Get calculator from cache or create new one
        /// </summary>
        /// <param name="id">Calculator id</param>
        /// <returns></returns>
        public static CalculatorContext GetOrCreate(string id)
        {
            if (!IsContains(id))
            {
                return Create(id);
            }
            return (CalculatorContext)MemoryCache.Default.Get(id);
        }

        /// <summary>
        /// Create calculator and storage in cache
        /// </summary>
        /// <param name="id">Calculator id</param>
        /// <returns></returns>
        public static CalculatorContext Create(string id)
        {
            CalculatorContext context = new CalculatorContext();
            MemoryCache.Default.Add(id, context, DateTimeOffset.Now.AddDays(1));
            return context;
        }

        /// <summary>
        /// Create guid
        /// </summary>
        /// <returns></returns>
        public static string CreateId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
