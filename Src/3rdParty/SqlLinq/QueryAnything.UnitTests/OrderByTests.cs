using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

namespace QueryAnything.UnitTests
{
    [TestFixture]
    public class OrderByTests
    {
        [Test]
        public void OrderByValue()
        {
            IEnumerable<int> source = TestData.GetInts();
            IEnumerable<int> result = source.Query<int>("SELECT * FROM this ORDER BY value()");
            Assert.IsTrue(result.SequenceEqual(source.OrderBy(i => i)));
        }

        [Test]
        public void OrderByProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<Person> result = source.Query<Person>("SELECT * FROM this ORDER BY age");
            Assert.IsTrue(result.SequenceEqual(source.OrderBy(p => p.Age)));
        }

        [Test]
        public void OrderByTwoProperties()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<Person> result = source.Query<Person>("SELECT * FROM this ORDER BY age, name");
            Assert.IsTrue(result.SequenceEqual(source.OrderBy(p => p.Age).ThenBy(p => p.Name)));
        }

        [Test]
        public void OrderByPropertySelectOtherProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<string> result = source.Query<Person, string>("SELECT Name FROM this ORDER BY age");
            Assert.IsTrue(result.SequenceEqual(source.OrderBy(p => p.Age).Select(p => p.Name)));
        }

        private static void Dump(IEnumerable<Person> list)
        {
            foreach (Person p in list)
                Debug.WriteLine("{0} {1}", p.Age, p.Name);
        }

        [Test]
        public void OrderByPropertyDescending()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<Person> result = source.Query<Person>("SELECT * FROM this ORDER BY age DESC");
            Assert.IsTrue(result.SequenceEqual(source.OrderByDescending(p => p.Age)));
        }
    }
}
