using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueryAnything.UnitTests
{
    [TestClass]
    public class HavingTests
    {
        [TestMethod]
        public void HavingTestNewObject()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, Family>("SELECT Address, Avg(Age) AS AverageAge FROM this GROUP BY Address HAVING AverageAge > 40");

            var answer = from p in source
                         group p by p.Address into g 
                         where g.Average(p => p.Age) >  40
                         select new Family { Address = g.Key, AverageAge = g.Average(p => p.Age) };

            Assert.IsTrue(result.SequenceEqual(answer));
        }
    }
}
