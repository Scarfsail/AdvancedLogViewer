using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace QueryAnything
{
    public static class SqlLinq
    {
        public static TSource QueryScalar<TSource>(this IEnumerable<TSource> enumerable, string sql)
        {
            Debug.Assert(enumerable != null);
            Debug.Assert(string.IsNullOrEmpty(sql) == false);

            return enumerable.QueryScalar<TSource, TSource>(sql);
        }

        public static TResult QueryScalar<TSource, TResult>(this IEnumerable<TSource> enumerable, string sql)
        {
            Debug.Assert(enumerable != null);
            Debug.Assert(string.IsNullOrEmpty(sql) == false);

            ScalarQuery<TSource, TResult> query = new ScalarQuery<TSource, TResult>(sql);
            query.Compile();
            return enumerable.QueryScalar<TSource, TResult>(query);
        }

        public static TResult QueryScalar<TSource, TResult>(this IEnumerable<TSource> enumerable, ScalarQuery<TSource, TResult> query)
        {
            Debug.Assert(enumerable != null);
            Debug.Assert(query != null);

            return query.Evaluate(enumerable);
        }

        public static IEnumerable<TSource> Query<TSource>(this IEnumerable<TSource> enumerable, string sql)
        {
            Debug.Assert(enumerable != null);
            Debug.Assert(string.IsNullOrEmpty(sql) == false);

            return enumerable.Query<TSource, TSource>(sql);
        }

        public static IEnumerable<TResult> Query<TSource, TResult>(this IEnumerable<TSource> enumerable, string sql)
        {
            Debug.Assert(enumerable != null);
            Debug.Assert(string.IsNullOrEmpty(sql) == false);

            EnumerableQuery<TSource, TResult> query = new EnumerableQuery<TSource, TResult>(sql);
            query.Compile();
            return enumerable.Query<TSource, TResult>(query);
        }

        public static IEnumerable<TResult> Query<TSource, TResult>(this IEnumerable<TSource> enumerable, EnumerableQuery<TSource, TResult> query)
        {
            Debug.Assert(enumerable != null);
            Debug.Assert(query != null);

            return query.Evaluate(enumerable);
        }
    }
}
