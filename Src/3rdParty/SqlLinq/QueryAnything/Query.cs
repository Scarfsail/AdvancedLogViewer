using System;
using System.Collections.Generic;
using System.Diagnostics;

using SqlLinq;
using SqlLinq.SyntaxTree;

namespace QueryAnything
{
    public abstract class Query<TSource, TResult>
    {
        protected Query(string sql)
        {
            Debug.Assert(string.IsNullOrEmpty(sql) == false);
            Sql = sql;
        }

        private Query()
        {
            Sql = string.Empty;
        }

        public void Compile()
        {
            SqlParser parser = new SqlParser();
            if (parser.Parse(Sql) == false)
                throw new Exception(string.Format("SQL parse error:\n\t{0}\nin statement\n\t{1}", parser.ErrorString, parser.ErrorLine));

            SyntaxNode = parser.SyntaxTree as SelectNode;
            SyntaxNode.Prepare();

            OnCompile();
        }

        protected abstract void OnCompile();

        public abstract TResult Evaluate(IEnumerable<TSource> source);

        internal SelectNode SyntaxNode { get; private set; }

        public string Sql { get; private set; }

        public override string ToString()
        {
            return Sql;
        }
    }
}
