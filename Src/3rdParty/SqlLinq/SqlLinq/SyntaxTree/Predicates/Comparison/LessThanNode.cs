using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_LT)]
    public class LessThanNode : PredicateNode
    {
        public LessThanNode()
            : base(typeof(double), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.LessThan(left, GetRightExpression(param));
        }
    }
}
