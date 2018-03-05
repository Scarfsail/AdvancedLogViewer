using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryAnything.UnitTests
{
    class BasicPerson
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public static bool operator ==(BasicPerson a, BasicPerson b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BasicPerson a, BasicPerson b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, this))
                return true;

            BasicPerson other = obj as BasicPerson;
            if (object.ReferenceEquals(other, null))
                return false;

            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Name != null ? Name.GetHashCode() : 0) ^ (Address != null ? Address.GetHashCode() : 0);
            }
        }
    }

    class Person : BasicPerson
    {
        public int Age { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                return base.GetHashCode() ^ Age.GetHashCode();
            }
        }
    }

    class Family
    {
        public string Address { get; set; }
        public double AverageAge { get; set; }
        public int TotalAge { get; set; }

        public static bool operator ==(Family a, Family b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Family a, Family b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, this))
                return true;

            Family other = obj as Family;
            if (object.ReferenceEquals(other, null))
                return false;

            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Address != null ? Address.GetHashCode() : 0) ^ AverageAge.GetHashCode() ^ TotalAge.GetHashCode();
            }
        }
    }

    class OtherPerson
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public static bool operator ==(OtherPerson a, OtherPerson b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(OtherPerson a, OtherPerson b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, this))
                return true;

            OtherPerson other = obj as OtherPerson;
            if (object.ReferenceEquals(other, null))
                return false;

            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Name != null ? Name.GetHashCode() : 0) ^ (Location != null ? Location.GetHashCode() : 0);
            }
        }
    }
}
