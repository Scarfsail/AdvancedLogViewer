using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_NOT_BETWEEN_AND)]
    public class NotBetweenNode : BetweenNode
    {
        public NotBetweenNode()
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.Not(CreateBetweenExpression(param, CreateChildExpression(param, 3), CreateChildExpression(param, 5)));
        }
    }
}
