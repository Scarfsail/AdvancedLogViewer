using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_LTEQ)]
    public class LessThanOrEqualNode : PredicateNode
    {
        public LessThanOrEqualNode()
            : base(typeof(double), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.LessThanOrEqual(left, GetRightExpression(param));
        }
    }
}
