using NUnit.Framework;
using Math = MathematicsClass.Math;

namespace MathematicsClassTests
{
    [TestFixture]
    public class AddGenericsTests
    {
        [Test]
        public void SumOfIntTest()
        {
            int a = 10,
                b = 5,
                expected = 15;

            int actual = Math.AddGenerics(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SumIntWithFloatTest()
        {
            int a = 10;
            float b = 5.2f,
                expected = 15.2f;

            float actual = Math.AddGenerics(a, b);

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void SumDoubleWithFloatTest()
        {
            float a = 10.4f;
            double b = 5.2,
                expected = a + b;

            double actual = Math.Add(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}