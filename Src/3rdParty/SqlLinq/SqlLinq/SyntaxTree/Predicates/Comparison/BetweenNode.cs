using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_BETWEEN_AND)]
    public class BetweenNode : PredicateNode
    {
        public BetweenNode()
            : base(typeof(long), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return CreateBetweenExpression(param, CreateChildExpression(param, 2), CreateChildExpression(param, 4));
        }

        protected Expression CreateBetweenExpression(ParameterExpression param, Expression start, Expression end)
        {
            Expression gte = Expression.GreaterThanOrEqual(GetLeftExpression(param), start);
            Expression lte = Expression.LessThanOrEqual(GetLeftExpression(param), end);
            return Expression.And(gte, lte);
        }
    }
}
