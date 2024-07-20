using System;
using Calculator;
using NUnit.Framework;

namespace CalculatorTests
{
    /// <summary>
    /// Test class for default calculator.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        [Test]
        public void DivWithNullTest()
        {
            double a = 10,
                b = 0;

            Assert.Throws<DivideByZeroException>(() => CalculatorDefault.Div(a, b));
        }
    }
}