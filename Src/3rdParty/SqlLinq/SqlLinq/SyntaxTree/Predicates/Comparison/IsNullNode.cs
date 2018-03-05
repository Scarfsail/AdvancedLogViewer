using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_IS_NULL)]
    public class IsNullNode : PredicateNode
    {
        public IsNullNode()
            : base(null, typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            // both null and DbNull can represent NULL
            Expression equalNull = Expression.Equal(left, Expression.Constant(null, typeof(object)));
            Expression equalDbNull = Expression.Equal(left, Expression.Constant(DBNull.Value, typeof(DBNull)));

            return Expression.Or(equalNull, equalDbNull);
        }
    }
}
