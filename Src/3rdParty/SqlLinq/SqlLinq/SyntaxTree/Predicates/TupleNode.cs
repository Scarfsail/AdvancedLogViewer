using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using SqlLinq.SyntaxTree.Literals;

namespace SqlLinq.SyntaxTree.Predicates
{
    [SyntaxNode(RuleConstants.RULE_TUPLE_LPARAN_RPARAN2)]
    public class TupleNode : PredicateNode
    {
        public TupleNode()
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            return CreateChildExpression(param, 1); // a tuple will of the form '(' '<expression>' ')' so return the expression of the middle node
        }

        internal override LiteralNode GetExpressionType()
        {
            PredicateNode p = FindChild<PredicateNode>(1);
            if (p != null)
                return p.GetExpressionType();

            return base.GetExpressionType();
        }
    }
}
