using System;
using NUnit.Framework;

namespace WordGeneration.Tests
{
    [TestFixture]
    public class WordGeneratorTests
    {

        [TestCase(new double[] { -2.54, 0.35, 1.7 },ExpectedResult = new string[]
        {"minus two point five four", "zero point three five", "one point seven"})]
        [TestCase(new double[] { 0.378, 6685.7 },ExpectedResult = new string[]
        {"zero point three seven eight", "six six eight five point seven"})]
        public string[] TransformToWordsTest_WithCorrectArrays_CorrectRusult(double[] doubles)
        => WordGenerator.TransformToWords(doubles);

        [TestCase(new double[] { -255.255, 255.255, 4294967295.0 }, ExpectedResult = new string[]
        {"1100000001101111111010000010100011110101110000101000111101011100",
         "0100000001101111111010000010100011110101110000101000111101011100",
         "0100000111101111111111111111111111111111111000000000000000000000" })]
        public string[] TransformToIEEEFormat_WithCorrectArrays_CorrectResult(double[] doubles)
        => WordGenerator.TransformToIEEEFormat(doubles);

        [Test]
        public void TransformToWords_NullReference_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => WordGenerator.TransformToWords(null));
        }

        [Test]
        public void TransformToWords_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => WordGenerator.TransformToWords(new double[] { }));
        }

        [Test]
        public void TransformToIEEEFormat_NullReference_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => WordGenerator.TransformToIEEEFormat(null));
        }

        [Test]
        public void TransformToIEEEFormat_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => WordGenerator.TransformToIEEEFormat(new double[] { }));
        }
    }
}
