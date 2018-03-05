using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlLinq.SyntaxTree.Literals
{
    [SyntaxNode(RuleConstants.RULE_VALUE_STRINGLITERAL)]
    public class StringLiteral : Literal<string>
    {
        public StringLiteral()
            : base(TypeCoercer, null)
        {
        }

        internal static string TypeCoercer(object o)
        {
            return o != null ? o.ToString().Trim('\'') : string.Empty; //trim enclsoing quote marks from literal values
        }
    }
}
