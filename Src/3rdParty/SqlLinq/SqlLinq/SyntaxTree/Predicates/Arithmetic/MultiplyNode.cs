using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Arithmetic
{
    [SyntaxNode(RuleConstants.RULE_MULTEXP_TIMES)]
    public class MultiplyNode : ArithmeticNode
    {
        public MultiplyNode()
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.MultiplyChecked(left, GetRightExpression(param));
        }
    }
}
