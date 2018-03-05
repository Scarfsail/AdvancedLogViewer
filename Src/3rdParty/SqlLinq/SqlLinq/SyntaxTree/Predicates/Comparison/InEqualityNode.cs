using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_EXCLAMEQ)]
    [SyntaxNode(RuleConstants.RULE_PREDEXP_LTGT)]
    public class InequalityNode : PredicateNode
    {
        public InequalityNode()
            : base(typeof(string), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.NotEqual(left, GetRightExpression(param));
        }
    }
}
