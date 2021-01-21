using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace QueryAnything.UnitTests
{
    [TestFixture]
    public class DynamicTests
    {
        [Test]
        public void DynamicOneProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, dynamic>("SELECT address FROM this");
            Assert.IsTrue(result.SequenceEqual(source.Select(p => p.Address)));
        }

        [Test]
        public void DynamicTwoProperties()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, dynamic>("SELECT age, address FROM this");

            var answer = from p in source
                         select new { p.Age, p.Address };

            IEnumerable<int> ages = result.Select<dynamic, int>(x => x.age);
            IEnumerable<int> ages1 = answer.Select(x => x.Age);
            Assert.IsTrue(ages.SequenceEqual(ages1));

            IEnumerable<string> addresses = result.Select<dynamic, string>(x => x.address);
            IEnumerable<string> addresses1 = answer.Select(x => x.Address);
            Assert.IsTrue(addresses.SequenceEqual(addresses1));
        }

        [Test]
        public void NewObjectTwoProperties()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, BasicPerson>("SELECT name, address FROM this");

            var answer = from p in source select new BasicPerson { Name = p.Name, Address = p.Address };

            Assert.IsTrue(result.SequenceEqual(answer));
        }

        [Test]
        public void NewObjectTwoPropertiesWithAs()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, OtherPerson>("SELECT name, address AS location FROM this");

            var answer = from p in source select new OtherPerson { Name = p.Name, Location = p.Address };

            Assert.IsTrue(result.SequenceEqual(answer));
        }

        [Test]
        public void NewObjectTwoPropertiesConstructor()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, Tuple<string, string>>("SELECT name, address FROM this");

            var answer = from p in source select new Tuple<string, string>(p.Name,  p.Address );

            Assert.IsTrue(result.SequenceEqual(answer));
        }

        [Test]
        public void NewObjectThreePropertiesConstructor()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            var result = source.Query<Person, Tuple<string, int, string>>("SELECT name, age, address FROM this");

            var answer = from p in source select new Tuple<string, int, string>(p.Name, p.Age, p.Address);

            Assert.IsTrue(result.SequenceEqual(answer));
        }
    }
}
