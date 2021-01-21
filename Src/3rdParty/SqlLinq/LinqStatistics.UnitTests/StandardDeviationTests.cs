using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LinqStatistics.UnitTests
{
    [TestFixture]
    public class StandardDeviationTests
    {
        [Test]
        public void StdevDouble()
        {
            IEnumerable<double> source = TestData.GetDoubles();

            double result = source.StandardDeviation();

            Assert.AreEqual(result, 2.0271079563424013, double.Epsilon);
        }

        [Test]
        public void StdevNullableDouble()
        {
            IEnumerable<double?> source = TestData.GetNullableDoubles();

            double? result = source.StandardDeviation();

            Assert.AreEqual((double)result, 2.0271079563424013, double.Epsilon);
        }

        [Test]
        public void StdevInt()
        {
            IEnumerable<int> source = TestData.GetInts();

            double result = source.StandardDeviation();

            Assert.AreEqual(result, 1.707825127659933, double.Epsilon);
        }

        [Test]
        public void StdevNullableInt()
        {
            IEnumerable<int?> source = TestData.GetNullableInts();

            double? result = source.StandardDeviation();

            Assert.AreEqual((double)result, 1.707825127659933, double.Epsilon);
        }

        [Test]
        public void StdevPDouble()
        {
            IEnumerable<double> source = TestData.GetDoubles();

            double result = source.StandardDeviationP();

            Assert.AreEqual(result, 1.7555269864060763, double.Epsilon);
        }

        [Test]
        public void StdevPNullableDouble()
        {
            IEnumerable<double?> source = TestData.GetNullableDoubles();

            double? result = source.StandardDeviationP();

            Assert.AreEqual((double)result, 1.7555269864060763, double.Epsilon);
        }

        [Test]
        public void StdevPInt()
        {
            IEnumerable<int> source = TestData.GetInts();

            double result = source.StandardDeviationP();

            Assert.AreEqual(result, 1.479019945774904, double.Epsilon);
        }

        [Test]
        public void StdevPNullableInt()
        {
            IEnumerable<int?> source = TestData.GetNullableInts();

            double? result = source.StandardDeviationP();

            Assert.AreEqual((double)result, 1.479019945774904, double.Epsilon);
        }
    }
}
