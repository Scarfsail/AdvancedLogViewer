using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Clauses
{
    [SyntaxNode(RuleConstants.RULE_ORDERLIST_FUNCTION)]
    public class OrderByValueItem : OrderByItem
    {
        public OrderByValueItem()
        {
        }

        protected override LambdaExpression CreateLambaExpression(Type tSource)
        {
            Debug.Assert(tSource != null);
            return ExpressionFactory.CreateIdentityExpression(tSource);
        }
    }
}
