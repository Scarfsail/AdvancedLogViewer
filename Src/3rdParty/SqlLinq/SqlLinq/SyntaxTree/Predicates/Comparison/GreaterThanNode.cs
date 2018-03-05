using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_GT)]
    public class GreaterThanNode : PredicateNode
    {
        public GreaterThanNode()
            : base(typeof(double), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.GreaterThan(left, GetRightExpression(param));
        }
    }
}
