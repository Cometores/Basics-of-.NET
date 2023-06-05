using System;
using System.Collections.Generic;

namespace MathematicsClass
{
    /* dynamic type requires Microsoft.CSharp.dll*/
    public static class Math
    {
        [Obsolete]
        private static readonly HashSet<Type> AllowedTypes = new HashSet<Type>()
        {
            typeof(byte), typeof(int), typeof(float), typeof(double)
        };
        [Obsolete]
        private static bool TypeValidation<T>(T number1, T number2) where T : struct
        {
            Type type1 = number1.GetType();
            Type type2 = number1.GetType();
            if (!AllowedTypes.Contains(type1) || !AllowedTypes.Contains(type1))
                return false;
            return true;
        }

        [Obsolete]
        public static T AddGenerics<T>(T number1, T number2) where T : struct
        {
            if (!TypeValidation(number1, number2))
                return default(T);
            
            return (dynamic)number1 + (dynamic)number2;
        }

        /* Primitive solution with double */
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }
        
        public static double Sub(double number1, double number2)
        {
            return number1 + number2;
        }
        
        public static double Mult(double number1, double number2)
        {
            if (number1 == 0 || number2 == 0)
                return 0;
            return number1 * number2;
        }
        
        public static double Div(double number1, double number2)
        {
            if (number2 == 0)
                throw new DivideByZeroException();
            else if (number1 == 0)
                return 0;
            return number1 / number2;
        }
    }
}