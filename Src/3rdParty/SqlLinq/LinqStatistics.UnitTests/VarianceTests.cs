using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LinqStatistics.UnitTests
{
    [TestFixture]
    public class VarianceTests
    {
        [Test]
        public void VarDouble()
        {
            IEnumerable<double> source = TestData.GetDoubles();

            double result = source.Variance();

            Assert.AreEqual(result, 4.1091666666666667, double.Epsilon);
        }

        [Test]
        public void VarNullableDouble()
        {
            IEnumerable<double?> source = TestData.GetNullableDoubles();

            double? result = source.Variance();

            Assert.AreEqual((double)result, 4.1091666666666667, double.Epsilon);
        }

        [Test]
        public void VarInt()
        {
            IEnumerable<int> source = TestData.GetInts();

            double result = source.Variance();

            Assert.AreEqual(result, 2.91666666666666667, double.Epsilon);
        }

        [Test]
        public void VarNullableInt()
        {
            IEnumerable<int?> source = TestData.GetNullableInts();

            double? result = source.Variance();

            Assert.AreEqual((double)result, 2.91666666666666667, double.Epsilon);
        }

        [Test]
        public void VarPDouble()
        {
            IEnumerable<double> source = TestData.GetDoubles();

            double result = source.VarianceP();

            Assert.AreEqual(result, 3.081875, double.Epsilon);
        }

        [Test]
        public void VarPNullableDouble()
        {
            IEnumerable<double?> source = TestData.GetNullableDoubles();

            double? result = source.VarianceP();

            Assert.AreEqual((double)result, 3.081875, double.Epsilon);
        }

        [Test]
        public void VarPInt()
        {
            IEnumerable<int> source = TestData.GetInts();

            double result = source.VarianceP();

            Assert.AreEqual(result, 2.1875, double.Epsilon);
        }

        [Test]
        public void VarPNullableInt()
        {
            IEnumerable<int?> source = TestData.GetNullableInts();

            double? result = source.VarianceP();

            Assert.AreEqual((double)result, 2.1875, double.Epsilon);
        }
    }
}
