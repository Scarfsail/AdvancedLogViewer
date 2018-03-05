using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LinqStatistics;

namespace QueryAnything.UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ScalarTests
    {
        public ScalarTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Where()
        {
            List<string> l = new List<string>();
            l.Add("don");
            l.Add("donald");
            l.Add("pihllip");

            IEnumerable<string> result = l.Query<string>("SELECT * FROM this WHERE Length > 3");
            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public void Sum()
        {
            IEnumerable<int> source = TestData.GetInts();
            int result = source.QueryScalar<int>("SELECT sum(value()) FROM this");

            Assert.IsTrue(result == source.Sum());
        }

        [TestMethod]
        public void AvgInt()
        {
            IEnumerable<int> source = TestData.GetInts();
            double result = source.QueryScalar<int, double>("SELECT avg(value()) FROM this");

            Assert.IsTrue(result == source.Average());
        }

        [TestMethod]
        public void AvgDouble()
        {
            IEnumerable<double> source = TestData.GetDoubles();
            double result = source.QueryScalar<double>("SELECT avg(value()) FROM this");

            Assert.IsTrue(result == source.Average());
        }

        [TestMethod]
        public void AvgFloat()
        {
            IEnumerable<float> source = TestData.GetFloats();
            float result = source.QueryScalar<float>("SELECT avg(value()) FROM this");

            Assert.IsTrue(result == source.Average());
        }

        [TestMethod]
        public void AvgProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            double result = source.QueryScalar<Person, double>("SELECT avg(AGE) FROM this");

            Assert.IsTrue(result == source.Average(p => p.Age));
        }

        [TestMethod]
        public void VarProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            double result = source.QueryScalar<Person, double>("SELECT var(age) FROM this");

            Assert.IsTrue(result == source.Variance(p => p.Age));
        }

        [TestMethod]
        public void Count()
        {
            IEnumerable<int> source = TestData.GetInts();
            int result = source.QueryScalar<int>("SELECT count(*) FROM this");

            Assert.IsTrue(result == source.Count());
        }

        [TestMethod]
        public void CountWhere()
        {
            IEnumerable<int> source = TestData.GetInts();
            int result = source.QueryScalar<int>("SELECT count(*) FROM this WHERE value() > 3");

            Assert.IsTrue(result == source.Where(i => i > 3).Count());
        }
    }
}
