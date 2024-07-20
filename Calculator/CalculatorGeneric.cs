using System;
using System.Collections.Generic;

namespace Calculator
{
    /// <summary>
    /// Calculator that supports operands of 4 allowed types.
    /// </summary>
    public static class CalculatorGeneric
    {
        /// <summary>
        /// Allowed 4 types for arithmetic operations
        /// </summary>
        private static readonly HashSet<Type> AllowedTypes = new HashSet<Type>()
        {
            typeof(byte), typeof(int), typeof(float), typeof(double)
        };
        
        /// <summary>
        /// A + B
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <typeparam name="T">Type of operands</typeparam>
        /// <returns>Default value for a provided type or the sum otherwise.</returns>
        public static T AddForGenericValues<T>(T a, T b) where T : struct
        {
            if (!AllowedTypes.Contains(typeof(T)))
                return default(T);
            
            return (dynamic)a + (dynamic)b;
        }
    }
}