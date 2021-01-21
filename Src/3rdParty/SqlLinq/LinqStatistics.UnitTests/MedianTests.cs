using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LinqStatistics.UnitTests
{
    [TestFixture]
    public class MedianTests
    {
        [Test]
        public void MedianDouble()
        {
            IEnumerable<double> source = TestData.GetDoubles();

            double result = source.Median();

            Assert.AreEqual(result, 4.05, double.Epsilon);
        }

        [Test]
        public void MedianNullableDouble()
        {
            IEnumerable<double?> source = TestData.GetNullableDoubles();

            double? result = source.Median();

            Assert.AreEqual((double)result, 4.05, double.Epsilon);
        }

        [Test]
        public void MedianInt()
        {
            IEnumerable<int> source = TestData.GetInts();

            double result = source.Median();

            Assert.AreEqual(result, 3.5, double.Epsilon);
        }

        [Test]
        public void MedianIntOddCount()
        {
            IEnumerable<int> source = TestData.GetInts().Concat(new List<int> { 4 });

            double result = source.Median();

            Assert.AreEqual(result, 4, double.Epsilon);
        }


        [Test]
        public void MedianNullableInt()
        {
            IEnumerable<int?> source = TestData.GetNullableInts();

            double? result = source.Median();

            Assert.AreEqual((double)result, 3.5, double.Epsilon);
        }
        [Test]

        public void MedianNullableIntOddCount()
        {
            IEnumerable<int?> source = TestData.GetNullableInts().Concat(new List<int?> { 4 });

            double? result = source.Median();

            Assert.AreEqual((double)result, 4, double.Epsilon);
        }
    }
}
