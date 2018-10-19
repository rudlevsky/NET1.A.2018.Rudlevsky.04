using System;
using NUnit.Framework;

namespace WordGeneration.Tests
{
    [TestFixture]
    public class WordGeneratorTests
    {
        //[TestCase(new double[] { 123, 0.89, -0.275, 0.44 },ExpectedResult = new string[] { "one two three", "zero point eight nine", "minus point two seven five", "zero point four four"})]
        //[TestCase(new double[] { 123 },ExpectedResult = new string[] { "one two three"})]
        [Test]
        public void TransformToWords_CorrectArrayOfDoubleNumbers_CorrectArrayOfStrings()
        {
            CollectionAssert.Equals(new string[] { "one" }, WordGenerator.TransformToWords(new double[] { 1 }));
        }

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
    }
}
