using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_EQ)]
    public class EqualityNode : PredicateNode
    {
        public EqualityNode()
            : base(typeof(string), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.Equal(left, GetRightExpression(param));
        }
    }
}
