using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Boolean
{
    [SyntaxNode(RuleConstants.RULE_NOTEXP_NOT)]
    public class NotNode : PredicateNode
    {
        public NotNode()
            : base(typeof(bool), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.Not(left);
        }
    }
}
