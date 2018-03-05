using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Boolean
{
    [SyntaxNode(RuleConstants.RULE_ANDEXP_AND)]
    public class AndNode : PredicateNode
    {
        public AndNode()
            : base(typeof(bool), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.AndAlso(left, GetRightExpression(param));
        }
    }
}
