using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueryAnything.UnitTests
{
    [TestClass]
    public class SimpleTests
    {
        [TestMethod]
        public void UnityQueryValueType()
        {
            IEnumerable<int> source = TestData.GetInts();
            IEnumerable<int> results = source.Query<int>("SELECT * FROM this");
            Assert.IsTrue(results.SequenceEqual<int>(source));
        }

        [TestMethod]
        public void UnityQueryReferenceType()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<Person> results = source.Query<Person>("SELECT * FROM this");
            Assert.IsTrue(results.SequenceEqual<Person>(source));
        }

        [TestMethod]
        public void SinglePropertyQuery()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<int> results = source.Query<Person, int>("SELECT Age FROM this");

            Assert.IsTrue(results.SequenceEqual<int>(source.Select(p => p.Age)));
        }
    }
}
