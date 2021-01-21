using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace QueryAnything.UnitTests
{
    [TestFixture]
    public class SelectTests
    {
        [Test]
        public void SelectProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<int> result = source.Query<Person, int>("SELECT age FROM this");
            Assert.IsTrue(result.SequenceEqual(source.Select(p => p.Age)));
        }

        [Test]
        public void SelectPropertyWhereOtherProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<int> result = source.Query<Person, int>("SELECT age FROM this WHERE name = 'Frank'");
            Assert.IsTrue(result.SequenceEqual(source.Where(p => p.Name == "Frank").Select(p => p.Age)));
        }

        [Test]
        public void SelectPropertyWhereWithAddition()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<int> result = source.Query<Person, int>("SELECT age FROM this WHERE age = 39 + 1");

            Assert.IsTrue(result.SequenceEqual(source.Where(p => p.Age == 39 + 1).Select(p => p.Age)));
        }
    }
}
