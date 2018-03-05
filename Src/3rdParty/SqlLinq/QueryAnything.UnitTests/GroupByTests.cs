using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueryAnything.UnitTests
{
    [TestClass]
    public class GroupByTests
    {
        [TestMethod]
        public void GroupByIntoTuple()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, Tuple<string, double>>("SELECT Address, Avg(Age) FROM this GROUP BY Address");

            var answer = from p in source
                         group p by p.Address into g
                         select new Tuple<string, double>(g.Key, g.Average(p => p.Age));

            Assert.IsTrue(result.SequenceEqual(answer));
        }

        [TestMethod]
        public void GroupByIntoNewObject()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, Family>("SELECT Address, Avg(Age) AS AverageAge FROM this GROUP BY Address");

            var answer = from p in source
                         group p by p.Address into g
                         select new Family { Address = g.Key, AverageAge = g.Average(p => p.Age) };

            Assert.IsTrue(result.SequenceEqual(answer));
        }

        [TestMethod]
        public void GroupByIntoNewObjectTwoAggregates()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, Family>("SELECT Address, Avg(Age) AS AverageAge, Sum(Age) AS TotalAge FROM this GROUP BY Address");

            var answer = from p in source
                         group p by p.Address into g
                         select new Family { Address = g.Key, AverageAge = g.Average(p => p.Age), TotalAge = g.Sum(p => p.Age) };

            Assert.IsTrue(result.SequenceEqual(answer));
        }

        [TestMethod]
        public void GroupByIntoNewObjectDynamic()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, dynamic>("SELECT Address, Avg(Age) AS AverageAge FROM this GROUP BY Address");

            var answer = from p in source
                         group p by p.Address into g
                         select new Family { Address = g.Key, AverageAge = g.Average(p => p.Age) };

            IEnumerable<double> ages = result.Select<dynamic, double>(x => x.AverageAge);
            IEnumerable<double> ages1 = answer.Select(x => x.AverageAge);
            Assert.IsTrue(ages.SequenceEqual(ages1));

            IEnumerable<string> addresses = result.Select<dynamic, string>(x => x.Address);
            IEnumerable<string> addresses1 = answer.Select(x => x.Address);
            Assert.IsTrue(addresses.SequenceEqual(addresses1));
        }
    }
}
