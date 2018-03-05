using System;
using System.Collections.Generic;
using System.Linq;

using SqlLinq.SyntaxTree;

namespace QueryAnything
{
    public class ScalarQuery<TSource, TResult> : Query<TSource, TResult>
    {
        public ScalarQuery(string sql)
            : base(sql)
        {
        }

        protected override void OnCompile()
        {            
            if (SyntaxNode.Columns.Aggregates.Any())
                Aggregator = SyntaxNode.Columns.Aggregates.First().CreateAggregator<TSource, TResult>();
            else
                Select = SyntaxNode.CreateSelector<TSource, TResult>();

            if (SyntaxNode.WhereClause != null)
                Where = SyntaxNode.WhereClause.CreateEvaluator<TSource>();
        }

        public Func<TSource, TResult> Select { get; private set; }

        public Func<IEnumerable<TSource>, TResult> Aggregator { get; private set; }

        public Func<TSource, bool> Where { get; private set; }

        public override TResult Evaluate(IEnumerable<TSource> source)
        {
            if (Where != null)
                source = source.Where<TSource>(Where);

            if (Aggregator != null)
                return Aggregator(source);

            return source.Select<TSource, TResult>(Select).First<TResult>();
        }
    }
}
