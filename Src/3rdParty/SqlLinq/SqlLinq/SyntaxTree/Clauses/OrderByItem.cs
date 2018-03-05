using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Clauses
{
    [SyntaxNode(RuleConstants.RULE_ORDERLIST_ID_COMMA)]
    [SyntaxNode(RuleConstants.RULE_ORDERLIST_ID)]
    public class OrderByItem : NodeWithId
    {
        public OrderByItem()
        {
        }

        public MethodCallExpression CreateExpression(ParameterExpression param, Type tSource)
        {
            Debug.Assert(param != null);
            Debug.Assert(tSource != null);

            return CreateExpression(param, tSource, "OrderBy", "OrderByDescending");
        }

        public MethodCallExpression CreateThenByExpression(MethodCallExpression param, Type tSource)
        {
            Debug.Assert(param != null);
            Debug.Assert(tSource != null);

            return CreateExpression(param, tSource, "ThenBy", "ThenByDescending");
        }

        private MethodCallExpression CreateExpression(Expression param, Type tSource, string ascending, string descending)
        {
            LambdaExpression lambda = CreateLambaExpression(tSource);

            return Expression.Call(typeof(Enumerable), IsDescending ? descending : ascending, new Type[] { tSource, lambda.ReturnType }, param, lambda);
        }

        protected virtual LambdaExpression CreateLambaExpression(Type tSource)
        {
            Debug.Assert(tSource != null);
            Debug.Assert(string.IsNullOrEmpty(EvaluationId) == false);

            return ExpressionFactory.CreatePropertyOrFieldLambdaExpression(tSource, EvaluationId);
        }

        public bool IsDescending
        {
            get
            {
                return FindChild<NonTerminalNode>(RuleConstants.RULE_ORDERTYPE_DESC) != null;
            }
        }
    }
}
