using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace QueryAnything.UnitTests
{
    [TestFixture]
    public class StandardDeviationTests
    {
        [Test]
        public void StdevDouble()
        {
            IEnumerable<double> source = TestData.GetDoubles();

            double result = source.QueryScalar<double>("SELECT Stdev(value()) FROM this");

            Assert.AreEqual(result, 2.0271079563424013, double.Epsilon);
        }

        [Test]
        public void StdevNullableDouble()
        {
            IEnumerable<double?> source = TestData.GetNullableDoubles();

            double? result = source.QueryScalar<double?>("SELECT Stdev(value()) FROM this");

            Assert.AreEqual((double)result, 2.0271079563424013, double.Epsilon);
        }

        [Test]
        public void StdevInt()
        {
            IEnumerable<int> source = TestData.GetInts();

            double result = source.QueryScalar<int, double>("SELECT Stdev(value()) FROM this");

            Assert.AreEqual(result, 1.60208197875972, TestData.Epsilon);
        }

        [Test]
        public void StdevNullableInt()
        {
            IEnumerable<int?> source = TestData.GetNullableInts();

            double? result = source.QueryScalar<int?, double?>("SELECT Stdev(value()) FROM this");

            Assert.AreEqual((double)result, 1.707825127659933, double.Epsilon);
        }

        [Test]
        public void StdevPDouble()
        {
            IEnumerable<double> source = TestData.GetDoubles();

            double result = source.QueryScalar<double>("SELECT StdevP(value()) FROM this");

            Assert.AreEqual(result, 1.7555269864060763, double.Epsilon);
        }

        [Test]
        public void StdevPNullableDouble()
        {
            IEnumerable<double?> source = TestData.GetNullableDoubles();

            double? result = source.QueryScalar<double?>("SELECT StdevP(value()) FROM this");

            Assert.AreEqual((double)result, 1.7555269864060763, double.Epsilon);
        }

        [Test]
        public void StdevPInt()
        {
            IEnumerable<int> source = TestData.GetInts();

            double result = source.QueryScalar<int, double>("SELECT StdevP(value()) FROM this");

            Assert.AreEqual(result, 1.46249406456535, TestData.Epsilon);
        }

        [Test]
        public void StdevPNullableInt()
        {
            IEnumerable<int?> source = TestData.GetNullableInts();

            double? result = source.QueryScalar<int?, double?>("SELECT StdevP(value()) FROM this");

            Assert.AreEqual((double)result, 1.479019945774904, double.Epsilon);
        }
    }
}
