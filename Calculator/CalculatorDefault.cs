using System;

namespace Calculator
{
    /// <summary>
    /// Calculator that only works with doubles.
    /// </summary>
    public class CalculatorDefault
    {
        public static double Add(double number1, double number2) => number1 + number2;

        public static double Sub(double number1, double number2) => number1 + number2;

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