using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryAnything.UnitTests
{
    static class TestData
    {
        public const double Epsilon = 0.00000000000001;

        public static IEnumerable<int> GetInts()
        {
            return new int[] { 4, 2, 3, 6, 6, 4 };
        }

        public static IEnumerable<int?> GetNullableInts()
        {
            return new int?[] { 4, 2, null, 3, 6 };
        }

        public static IEnumerable<double> GetDoubles()
        {
            return new double[] { 4.6, 2.1, 3.5, 6.9 };
        }

        public static IEnumerable<double?> GetNullableDoubles()
        {
            return new double?[] { 4.6, 2.1, 3.5, null, 6.9 };
        }

        public static IEnumerable<float> GetFloats()
        {
            return new float[] { 4.6f, 2.1f, 3.5f, 6.9f };
        }

        public static IEnumerable<Person> GetPeople()
        {
            return new List<Person> 
            { 
                new Person { Age = 67, Name = "Jane", Address = "401 Main St., St. Paul, MN 55132" },
                new Person { Age = 40, Name = "Frank", Address = "56 23rd Ave., Minneapolis, MN 55406" },
                new Person { Age = 29, Name = "Louise", Address = "56 23rd Ave., Minneapolis, MN 55406" },
                new Person { Age = 47, Name = "Susan", Address = "42 Some Ct., Suburb, MN 55263" },
                new Person { Age = 45, Name = "Bill", Address = "6789 Flower St., St. Paul, MN 55869" }, 
                new Person { Age = 47, Name = "Betty", Address = "6789 Flower St., St. Paul, MN 55869" }, 
                new Person { Age = 18, Name = "Tim", Address = "42 Some Ct., Suburb, MN 55263" }, 
                new Person { Age = 19, Name = "Megan", Address = "42 Some Ct., Suburb, MN 55263" }, 
                new Person { Age = 67, Name = "Joe", Address = "401 Main St., St. Paul, MN 55132" }
            };
        }
    }
}
