using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Boolean
{
    [SyntaxNode(RuleConstants.RULE_EXPRESSION_OR)]
    public class OrNode : PredicateNode
    {
        public OrNode()
            : base(typeof(bool), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.OrElse(left, GetRightExpression(param));
        }
    }
}
