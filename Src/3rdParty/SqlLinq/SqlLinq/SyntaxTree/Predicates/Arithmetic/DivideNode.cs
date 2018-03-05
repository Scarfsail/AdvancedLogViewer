using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Arithmetic
{
    [SyntaxNode(RuleConstants.RULE_MULTEXP_DIV)]
    public class DivideNode : ArithmeticNode
    {
        public DivideNode()
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.Divide(left, GetRightExpression(param));
        }
    }
}
 