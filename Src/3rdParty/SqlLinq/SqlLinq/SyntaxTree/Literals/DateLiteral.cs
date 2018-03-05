using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlLinq.SyntaxTree.Literals
{
    [SyntaxNode(RuleConstants.RULE_VALUE_DATELITERAL)]
    public class DateLiteral : Literal<DateTime>
    {
        public DateLiteral()
            : base(TypeCoercer, DateTime.MinValue)
        {
        }

        internal static DateTime TypeCoercer(object o)
        {
            return o != null ? DateTime.Parse(o.ToString()) : DateTime.MinValue;
        }
    }
}
