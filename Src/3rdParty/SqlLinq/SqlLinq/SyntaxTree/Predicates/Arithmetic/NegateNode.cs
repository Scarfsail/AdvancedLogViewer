using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Predicates.Arithmetic
{
    [SyntaxNode(RuleConstants.RULE_NEGATEEXP_MINUS)]
    public class NegateNode : ArithmeticNode
    {
        public NegateNode()
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return Expression.NegateChecked(left);
        }
    }
}
