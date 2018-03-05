using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlLinq.SyntaxTree.Literals
{
    [SyntaxNode(RuleConstants.RULE_VALUE_INTEGERLITERAL)]
    public class IntegerLiteral : Literal<long>
    {
        public IntegerLiteral()
            : base(TypeCoercer, long.MinValue)
        {
        }

        internal static long TypeCoercer(object o)
        {
            return Convert.ToInt64(RealLiteral.TypeCoercer(o));
        }
    }
}
