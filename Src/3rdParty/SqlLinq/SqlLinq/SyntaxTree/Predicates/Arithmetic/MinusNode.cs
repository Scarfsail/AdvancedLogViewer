using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Arithmetic
{
    [SyntaxNode(RuleConstants.RULE_ADDEXP_MINUS)]
    public class MinusNode : ArithmeticNode
    {
        public MinusNode()
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.SubtractChecked(left, GetRightExpression(param));
        }
    }
}
