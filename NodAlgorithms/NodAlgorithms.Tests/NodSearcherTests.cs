using System;
using NUnit.Framework;

namespace NodAlgorithms.Tests
{
    [TestFixture]
    public class NodSearcherTests
    {
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(10, -5, ExpectedResult = 5)]
        [TestCase(5, 0, ExpectedResult = 5)]
        [TestCase(25, 50, ExpectedResult = 25)]
        public int MethodGetNodE_ArrayOfNumbers_ReturnCorrectNod(int num1, int num2) =>
            NodSearcher.GetNodE(out _, num1, num2);
        
        [TestCase(24, 18, 48, ExpectedResult = 6)]
        [TestCase(234, 58, 17, ExpectedResult = 1)]
        [TestCase(4, 134, 28, ExpectedResult = 2)]
        public int MethodGetNodE_ArrayOfNumbers_ReturnCorrectNod(int num1, int num2, int num3) =>
            NodSearcher.GetNodE(out _, num1, num2, num3);

        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(10, -5, ExpectedResult = 5)]
        [TestCase(5, 0, ExpectedResult = 5)]
        [TestCase(25, 50, ExpectedResult = 25)]
        public int MethodGetNodS_ArrayOfNumbers_ReturnCorrectNod(int num1, int num2) =>
            NodSearcher.GetNodS(out _, num1, num2);

        [TestCase(24, 18, 48, ExpectedResult = 6)]
        [TestCase(234, 58, 17, ExpectedResult = 1)]
        [TestCase(4, 134, 28, ExpectedResult = 2)]
        public int MethodGetNodS_ArrayOfNumbers_ReturnCorrectNod(int num1, int num2, int num3) =>
            NodSearcher.GetNodS(out _, num1, num2, num3);

        [Test]
        public void MethodGetNodE_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => NodSearcher.GetNodE(out _));
        }

        [Test]
        public void MethodGetNodE_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => NodSearcher.GetNodE(out _, null));
        }

        [Test]
        public void MethodGetNodS_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => NodSearcher.GetNodS(out _, null));
        }

        [Test]
        public void MethodGetNodS_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => NodSearcher.GetNodS(out _));
        }
    }
}
