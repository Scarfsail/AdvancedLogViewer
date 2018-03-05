using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using SqlLinq;
using SqlLinq.SyntaxTree;

namespace QueryAnything
{
    public class EnumerableQuery<TSource, TResult> : Query<TSource, IEnumerable<TResult>> 
    {
        public EnumerableQuery(string sql)
            : base(sql)
        {
        }

        protected override void OnCompile()
        {
            if (SyntaxNode.GroupByClause == null)
                Select = SyntaxNode.CreateSelector<TSource, TResult>();
            else
                GroupBySelect = SyntaxNode.CreateGroupBySelector<TSource, TResult>();

            if (SyntaxNode.WhereClause != null)
                Where = SyntaxNode.WhereClause.CreateEvaluator<TSource>();

            if (SyntaxNode.OrderByClause != null)
                OrderBy = SyntaxNode.OrderByClause.CreateFunction<TSource>();

            if(SyntaxNode.HavingClause != null)
                Having = SyntaxNode.HavingClause.CreateEvaluator<TResult>();
        }

        public Func<TSource, TResult> Select { get; private set; }

        public Func<IEnumerable<TSource>, IEnumerable<TResult>> GroupBySelect { get; private set; }

        public Func<TSource, bool> Where { get; private set; }

        public Func<TResult, bool> Having { get; private set; }

        public Func<IEnumerable<TSource>, IEnumerable<TSource>> OrderBy { get; private set; }

        public override IEnumerable<TResult> Evaluate(IEnumerable<TSource> source)
        {
            if (Where != null)
                source = source.Where<TSource>(Where);

            if (OrderBy != null)
                source = OrderBy(source);

            IEnumerable<TResult> result = Enumerable.Empty<TResult>();
            if (Select != null)
                result = source.Select<TSource, TResult>(Select);
            else
                result = GroupBySelect(source);

            if (Having != null)
                result = result.Where<TResult>(Having);

            if (SyntaxNode.Columns.Distinct)
                return result.Distinct();

            return result;
        }
    }
}
