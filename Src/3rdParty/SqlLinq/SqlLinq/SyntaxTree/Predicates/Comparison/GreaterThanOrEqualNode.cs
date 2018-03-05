using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_GTEQ)]
    public class GreaterThanOrEqualNode : PredicateNode
    {
        public GreaterThanOrEqualNode()
            : base(typeof(double), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.GreaterThanOrEqual(left, GetRightExpression(param));
        }
    }
}
