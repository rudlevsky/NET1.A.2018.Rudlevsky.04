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
            => WordGenerator.TransformToFormat(doubles, new WordFormatter());

        [TestCase(new double[] { -2.54, 0.35, 1.7 }, ExpectedResult = new string[]
        {"minus two point five four", "zero point three five", "one point seven"})]
        [TestCase(new double[] { 0.378, 6685.7 }, ExpectedResult = new string[]
        {"zero point three seven eight", "six six eight five point seven"})]
        public string[] TransformToWordsDelegateTest_CorrectArrays_CorrectRusult(double[] doubles) 
            => WordGenerator.TransformToFormat(doubles, new WordFormatter());

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

        [Test]
        public void FilterMethod_NullArgument_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => WordGenerator.Filter(null, new IntFilters()));
        }

        [Test]
        public void FilterMethod_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new int[] { }.Filter(new IntFilters()));
        }

        [Test]
        public void FilterMethod_IntInterface_NewCorrectArray()
        => CollectionAssert.AreEqual(new int[] { 1, 2, 4 }.Filter(new IntFilters()), new int[] { 2, 4 });

        [Test]
        public void FilterMethod_IntPredicate_NewCorrectArray()
        => CollectionAssert.AreEqual(new int[] { 1, 2, 4 }.Filter(new IntFilters().MoreZero), new int[] { 1, 2, 4 });

        [Test]
        public void FilterMethod_StringInterface_NewCorrectArray()
        => CollectionAssert.AreEqual(new string[] { "ABC", "test", "ANC"}.Filter(new StringFilters()), new string[] { "ABC", "ANC" });

        [Test]
        public void FilterMethod_StringPredicate_NewCorrectArray()
        => CollectionAssert.AreEqual(new string[] { "word", "cat", "a", "ab" }.Filter(new StringFilters().MoreTwo), new string[] { "word", "cat" });
    }
}
