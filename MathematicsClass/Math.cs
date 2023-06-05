using System;
using System.Collections.Generic;

namespace MathematicsClass
{
    /* dynamic type requires Microsoft.CSharp.dll*/
    public static class Math
    {
        private static readonly HashSet<Type> AllowedTypes = new HashSet<Type>()
        {
            typeof(byte), typeof(int), typeof(float), typeof(double)
        };

        private static bool TypeValidation<T>(T number1, T number2) where T : struct
        {
            Type type1 = number1.GetType();
            Type type2 = number1.GetType();
            if (!AllowedTypes.Contains(type1) || !AllowedTypes.Contains(type1))
                return false;
            return true;
        }

        public static T Add<T>(T number1, T number2) where T : struct
        {
            if (!TypeValidation(number1, number2))
                return default(T);
            
            return (dynamic)number1 + (dynamic)number2;
        }
    }
}