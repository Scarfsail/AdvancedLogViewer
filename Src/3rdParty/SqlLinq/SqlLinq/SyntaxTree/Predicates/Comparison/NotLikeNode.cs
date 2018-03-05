using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_NOT_LIKE_STRINGLITERAL)]
    public class NotLikeNode : LikeNode
    {
        public NotLikeNode()
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.Not(base.CreateOperatorExpression(param, left));
        }
    }
}
