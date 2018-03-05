using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scarfsail.Common.Utils
{
    public class StringIgnoreCaseEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string s1, string s2)
        {
            return s1.Equals(s2, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(string str)
        {
            return str.ToUpperInvariant().GetHashCode();
        }
    }
}
