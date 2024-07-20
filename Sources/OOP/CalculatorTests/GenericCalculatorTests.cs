using Calculator;
using NUnit.Framework;

namespace CalculatorTests
{
    /// <summary>
    /// Test class for generic calculator.
    /// </summary>
    [TestFixture]
    public class GenericCalculatorTests
    {
        [Test]
        public void CalculatorGeneric_SumOfInt_ShouldBe15()
        {
            int a = 10,
                b = 5,
                expected = 15;

            int actual = CalculatorGeneric.AddForGenericValues(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculatorGeneric_SumIntWithFloatTest_ShouldBe15p2()
        {
            int a = 10;
            float b = 5.2f,
                expected = 15.2f;

            float actual = CalculatorGeneric.AddForGenericValues(a, b);

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CalculatorGeneric_SumDoubleWithFloatTest_ShouldBe5p2()
        {
            float a = 10.4f;
            double b = 5.2,
                expected = a + b;

            double actual = CalculatorGeneric.AddForGenericValues(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}