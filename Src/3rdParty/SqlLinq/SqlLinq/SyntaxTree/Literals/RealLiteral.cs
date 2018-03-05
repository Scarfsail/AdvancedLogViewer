using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace SqlLinq.SyntaxTree.Literals
{
    [SyntaxNode(RuleConstants.RULE_VALUE_REALLITERAL)]
    public class RealLiteral : Literal<double>
    {
        public RealLiteral()
            : base(TypeCoercer, double.NaN)
        {
        }

        internal static double TypeCoercer(object o)
        {
            return o != null ? Convert.ToDouble(o, CultureInfo.CurrentCulture) : 0.0;
        }
    }
}
