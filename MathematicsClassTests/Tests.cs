using System;
using NUnit.Framework;
using Math = MathematicsClass.Math;

namespace MathematicsClassTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void DivWithNullTest()
        {
            double a = 10,
                b = 0;

            Assert.Throws<DivideByZeroException>(() => Math.Div(a, b));

        }
    }
}