using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SqlLinq.SyntaxTree.Aggregates
{
    /// <summary>
    /// Base class for other aggregate nodes
    /// </summary>
    /// <remarks>This is one case where using the parser's TrimReductions feature
    /// makes this code more complicated. TrimReductions will remove nodes from the tree that
    /// are not directly expressed in the input even though they are yielded by the state tables.
    /// For a statement like "SELECT AVG(field) FROM source" no Column Source node ends up in the tree.
    /// However for "SELECT field1, AVG(field2)" or "SELECT AVG(field) AS alias" the aggregate
    /// node will be the child of a column source node. So in order to deal with this difference in the resulting tree
    /// AggregateNode inherits from ColumnSource and can also be the child of ColumnSource</remarks>
    public abstract class AggregateNode : ColumnSource
    {
        private string m_evaluationId;

        public string Name { get; protected set; }

        protected AggregateNode()
        {
        }

        public override bool HasAlias
        {
            get
            {
                if (Parent is ColumnSource)
                    return ((ColumnSource)Parent).HasAlias;

                return base.HasAlias;
            }
        }

        public override string Alias
        {
            get
            {
                if (Parent is ColumnSource)
                    return ((ColumnSource)Parent).Alias;

                return base.Alias;
            }
        }

        public override string LookupId
        {
            get
            {
                return Name + SourceId;
            }
        }

        public override string SourceId
        {
            get
            {
                NodeWithId id = FindChild<NodeWithId>();
                if (id != null)
                    return id.LookupId;

                return base.SourceId;
            }
        }

        internal override IEnumerable<FieldReference> GetFields()
        {
            IList<FieldReference> list = new List<FieldReference>();

            foreach (NodeWithId id in FindDescendants<NodeWithId>())
            {
                FieldReference field = new FieldReference();
                field.EvaluationId = id.EvaluationId;
                field.SourceId = id.LookupId;
                field.LookupId = id.LookupId;
                list.Add(field);
            }

            return list;
        }

        /// <summary>
        /// A deterministically derived id that can be used to query the data regardless
        /// of the use of aliases
        /// </summary>
        internal string EvaluationId
        {
            get
            {
                if (string.IsNullOrEmpty(m_evaluationId) == false)
                    return m_evaluationId;

                return LookupId;
            }
            set
            {
                m_evaluationId = value;
            }
        }

        public Func<IEnumerable<TSource>, TAggregate> CreateAggregator<TSource, TAggregate>()
        {
            ParameterExpression param = Expression.Parameter(typeof(IEnumerable<TSource>), "arg");
            Expression body = Expression.Convert(GetCallExpression(typeof(IEnumerable<TSource>), typeof(TSource), param), typeof(TAggregate));
            return Expression.Lambda<Func<IEnumerable<TSource>, TAggregate>>(body, param).Compile();
        }

        public MethodCallExpression GetCallExpression(Type enumerableType, Type tSource, Expression param)
        {
            if (string.IsNullOrEmpty(SourceId))
            {
                // get that method that calculates the aggregate from the source collection
                MethodInfo method = GetEvaluationMethod(enumerableType);
                if (method.IsGenericMethodDefinition)
                    method = method.MakeGenericMethod(tSource);

                return Expression.Call(method, param);
            }

            LambdaExpression lambda = ExpressionFactory.CreatePropertyOrFieldLambdaExpression(tSource, SourceId);

            return Expression.Call(GetEvaluatatorType(), Name, new Type[] { tSource }, param, lambda);
        }

        protected virtual Type GetEvaluatatorType()
        {
            return typeof(Enumerable);
        }

        protected virtual MethodInfo GetEvaluationMethod(Type paramType)
        {
            return GetEvaluatatorType().GetMethod(Name, new Type[] { paramType });
        }
    }
}
