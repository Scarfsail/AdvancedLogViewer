using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueryAnything.UnitTests
{
    [TestClass]
    public class DistinctTests
    {
        [TestMethod]
        public void DistinctValue()
        {
            IEnumerable<int> source = TestData.GetInts();
            IEnumerable<int> result = source.Query<int>("SELECT DISTINCT * FROM this");
            Assert.IsTrue(result.SequenceEqual(source.Distinct()));        
        }

        [TestMethod]
        public void DistinctProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<string> result = source.Query<Person, string>("SELECT DISTINCT address FROM this");
            Assert.IsTrue(result.SequenceEqual(source.Select(p => p.Address).Distinct()));
        }
    }
}
