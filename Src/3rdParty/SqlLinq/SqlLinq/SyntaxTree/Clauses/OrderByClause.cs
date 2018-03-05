using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;

namespace SqlLinq.SyntaxTree.Clauses
{
    [SyntaxNode(RuleConstants.RULE_ORDERCLAUSE_ORDER_BY)]
    public class OrderByClause : NonTerminalNode
    {
        public OrderByClause()
        {
        }

        public Func<IEnumerable<T>, IEnumerable<T>> CreateFunction<T>()
        {
            ParameterExpression param = Expression.Parameter(typeof(IEnumerable<T>), "arg");

            IEnumerable<OrderByItem> items = OrderByItems; // this does a recursive search - cache it since we are using it twice
            OrderByItem first = items.First();
            Debug.Assert(first != null);

            MethodCallExpression call = first.CreateExpression(param, typeof(T));

            foreach (OrderByItem orderby in items.Except(new OrderByItem[] { first }))
                call = orderby.CreateThenByExpression(call, typeof(T));

            return Expression.Lambda<Func<IEnumerable<T>, IEnumerable<T>>>(call, param).Compile();
        }

        public IEnumerable<string> GetFieldList()
        {
            return FindDescendants<NodeWithId>().ToList().ConvertAll<string>(source => source.LookupId).Distinct(StringComparer.CurrentCultureIgnoreCase);
        }

        public IEnumerable<OrderByItem> OrderByItems
        {
            get
            {
                return FindDescendants<OrderByItem>();
            }
        }
    }
}
