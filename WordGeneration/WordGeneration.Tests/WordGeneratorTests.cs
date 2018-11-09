using System;
using NUnit.Framework;
using WordGeneration.Tests.Models;

namespace WordGeneration.Tests
{
    [TestFixture]
    public class WordGeneratorTests
    {
        [TestCase(new double[] { -2.54, 0.35, 1.7 },ExpectedResult = new string[]
        {"minus two point five four", "zero point three five", "one point seven"})]
        [TestCase(new double[] { 0.378, 6685.7 },ExpectedResult = new string[]
        {"zero point three seven eight", "six six eight five point seven"})]
        public string[] TransformToWordsTest_CorrectArrays_CorrectRusult(double[] doubles)
            => WordGenerator.TransformToFormat(doubles, new WordFormetter());

        [TestCase(new double[] { -2.54, 0.35, 1.7 }, ExpectedResult = new string[]
        {"minus two point five four", "zero point three five", "one point seven"})]
        [TestCase(new double[] { 0.378, 6685.7 }, ExpectedResult = new string[]
        {"zero point three seven eight", "six six eight five point seven"})]
        public string[] TransformToWordsDelegateTest_CorrectArrays_CorrectRusult(double[] doubles) 
            => WordGenerator.TransformToFormat(doubles, new WordFormetter());

        [TestCase(new double[] { -255.255, 255.255, 4294967295.0 }, ExpectedResult = new string[]
        {"1100000001101111111010000010100011110101110000101000111101011100",
         "0100000001101111111010000010100011110101110000101000111101011100",
         "0100000111101111111111111111111111111111111000000000000000000000" })]
        public string[] TransformToIEEEFormatTest_CorrectArrays_CorrectResult(double[] doubles)
            => WordGenerator.TransformToFormat(doubles, new IEEEFormatter());

        [TestCase(new double[] { -255.255, 255.255, 4294967295.0 }, ExpectedResult = new string[]
        {"1100000001101111111010000010100011110101110000101000111101011100",
         "0100000001101111111010000010100011110101110000101000111101011100",
         "0100000111101111111111111111111111111111111000000000000000000000" })]
        public string[] TransformToIEEEFormatDelegateTest_CorrectArrays_CorrectResult(double[] doubles)
            => WordGenerator.TransformToFormat(doubles, new IEEEFormatter());

        [Test]
        public void TransformToFormat_NullReference_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => WordGenerator.TransformToFormat(null, new IEEEFormatter()));
        }

        [Test]
        public void TransformToFormat_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => WordGenerator.TransformToFormat(new double[] { }, new IEEEFormatter()));
        }
    }
}
