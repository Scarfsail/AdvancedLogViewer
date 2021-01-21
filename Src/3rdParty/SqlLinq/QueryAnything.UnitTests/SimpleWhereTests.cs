using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace QueryAnything.UnitTests
{
    [TestFixture]
    public class SimpleWhereTests
    {
        [Test]
        public void WhereValue()
        {
            IEnumerable<int> source = TestData.GetInts();
            IEnumerable<int> result = source.Query<int>("SELECT * FROM this WHERE value() > 3");

            Assert.IsTrue(result.SequenceEqual(source.Where(i => i > 3)));
        }

        [Test]
        public void WhereProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<Person> result = source.Query<Person>("SELECT * FROM this WHERE age > 40");

            Assert.IsTrue(result.SequenceEqual(source.Where(p => p.Age > 40)));
        }

        [Test]
        public void PropertyWhere()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<int> result = source.Query<Person, int>("SELECT Age FROM this WHERE age > 40");

            Assert.IsTrue(result.SequenceEqual(source.Where(p => p.Age > 40).Select<Person, int>(p => p.Age)));
        }

        [Test]
        public void SelectOnePropertyWhereOtherProperty()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<int> result = source.Query<Person, int>("SELECT Age FROM this WHERE name = 'Frank'");

            Assert.IsTrue(result.SequenceEqual(source.Where(p => p.Name == "Frank").Select<Person, int>(p => p.Age)));
        }

        [Test]
        public void SelectOnePropertyWhereOtherProperty2()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            int result = source.QueryScalar<Person, int>("SELECT Age FROM this WHERE name = 'Frank'");

            Assert.IsTrue(result == source.Where(p => p.Name == "Frank").Select<Person, int>(p => p.Age).First());
        }


        [Test]
        public void SelectStringWhereTwoStrings()
        {
            List<string> source = new List<string>() {"aa","bb","xaax", "xbbx", "cc" };
            IEnumerable<string> result = source.Query("SELECT * FROM this WHERE value() = 'aa' OR value() LIKE 'bb'");

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void SelectPersonWhereTwoStrings()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<Person> result = source.Query("SELECT * FROM this WHERE Name = 'Frank' OR Address LIKE 'Main'");

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void SelectPersonWhereFourStrings()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<Person> result = source.Query("SELECT * FROM this WHERE (Name = 'Frank' OR Address LIKE 'Main' OR Name LIKE 'xyz') AND Age=20");

            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void SelectPersonWhereTwoStrings2()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<Person> result = source.Query("SELECT * FROM this WHERE (Name = 'Frank') OR (Address LIKE 'Main')");

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void SelectPersonWhereTwoStrings3()
        {
            IEnumerable<Person> source = TestData.GetPeople();
            IEnumerable<Person> result = source.Query("SELECT * FROM this WHERE ((Name = 'Frank') OR (Address LIKE 'Main')) OR (Name='Bla') AND (Age=67)");

            Assert.AreEqual(3, result.Count());
        }
    }
}
