using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlLinq.SyntaxTree.Literals
{
    [SyntaxNode(RuleConstants.RULE_VALUE_NULL)]
    public class NullLiteral : Literal<object>
    {
        public NullLiteral()
            : base(TypeCoercer, null)
        {
        }

        internal static object TypeCoercer(object o)
        {
            return o;
        }
    }
}
