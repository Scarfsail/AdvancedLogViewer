using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Arithmetic
{
    [SyntaxNode(RuleConstants.RULE_ADDEXP_PLUS)]
    public class PlusNode : ArithmeticNode
    {
        public PlusNode()
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.AddChecked(left, GetRightExpression(param));
        }
    }
}
