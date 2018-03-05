using System;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Functions
{
    [SyntaxNode(RuleConstants.RULE_VALUE_FUNCTION)]
    public class Value : FunctionNode
    {
        public Value()
        {
        }

        public override Expression CreateExpression(ParameterExpression param)
        {
            return Expression.Convert(param, WidenType(param.Type));
        }
    }
}
