using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Math = MathematicsClass.Math;

namespace MathematicsClassTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SumOfIntTest()
        {
            int a = 10,
                b = 5,
                expected = 15;

            int actual = Math.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SumIntWithFloatTest()
        {
            int a = 10;
            float b = 5.2f,
                expected = 15.2f;

            float actual = Math.Add(a, b);

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

        [Test]
        public void SumOfStructsTest()
        {
            //Anonymous struct. "var" type definition is not possible for Generics
            (string MessageWriter, int Value) struct1 = ("Hello", 12);

            var result = Math.Add(struct1, struct1);

            //TODO result is (, 0). How to compare this with something?
        }

        [Test]
        public void SumStringWithIntTest()
        {
            int a = 5;
            string b = "Hello";

            //TODO Already not possible
            // int result = Math.Add(a, b);
        }
    }
}