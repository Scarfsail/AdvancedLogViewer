using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace SqlLinq.SyntaxTree.Literals
{
    [SyntaxNode(RuleConstants.RULE_VALUE_BOOLEANLITERAL)]
    public class BooleanLiteral : Literal<bool>
    {
        public BooleanLiteral()
            : base(TypeCoercer, false)
        {
        }

        internal static bool TypeCoercer(object o)
        {
            return o != null ? Convert.ToBoolean(o, CultureInfo.InvariantCulture) : false;
        }
    }
}
