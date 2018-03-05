using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

using SqlLinq.SyntaxTree.Clauses;
using SqlLinq.SyntaxTree.Aggregates;

namespace SqlLinq.SyntaxTree
{
    [SyntaxNode(RuleConstants.RULE_SELECTSTM_SELECT)]
    public class SelectNode : NonTerminalNode
    {
        public SelectNode()
        {
        }

        /// <summary>
        /// Prepares the parse tree for evaluation. Specifically is creates the correct relationship
        /// between aliases that appear in sub clauses and the actual lookup ids that values are bound to
        /// </summary>
        public void Prepare()
        {
            IDictionary<string, string> aliasMap = Columns.ColumnSources.Where(item => item.HasAlias).ToDictionary(key => key.Alias, v => v.LookupId);

            DereferenceAliases(aliasMap, WhereClause);
            DereferenceAliases(aliasMap, GroupByClause);
            DereferenceAliases(aliasMap, HavingClause);
            DereferenceAliases(aliasMap, OrderByClause);
        }

        private static void DereferenceAliases(IDictionary<string, string> aliasMap, NonTerminalNode clause)
        {
            if (clause != null)
            {
                foreach (NodeWithId node in clause.FindDescendants<NodeWithId>().Where(item => aliasMap.ContainsKey(item.LookupId)))
                    node.EvaluationId = aliasMap[node.LookupId];
            }
        }

        public bool AllColumns
        {
            get
            {
                return Columns.AllColumns;
            }
        }

        public Columns Columns
        {
            get
            {
                Columns columns = FindChild<Columns>(RuleConstants.RULE_COLUMNS);
                if (columns != null)
                    return columns;

                return FindChild<Columns>(RuleConstants.RULE_COLUMNS_TIMES);
            }
        }

        public Func<TSource, TResult> CreateSelector<TSource, TResult>()
        {
            // if we are selecting * then result type should equal source type
            if (AllColumns)
                return ExpressionFactory.CreateIdentitySelector<TSource, TResult>().Compile();

            // if selecting only one field create a simple selection function
            IEnumerable<string> fields = Columns.GetFieldList();
            if (fields.Count() == 1)
                return ExpressionFactory.CreateSinglePropertySelector<TSource, TResult>(fields.First()).Compile();

            // if TResult is dynamic return an expando object
            if (typeof(TResult) == typeof(object))
                return ExpressionFactory.CreateExpandoSelector<TSource, TResult>(fields, Columns.GetResultList()).Compile();   

            // if return type has an empty constructor use it and memberinit
            if (typeof(TResult).HasEmptyConstructor())
                return ExpressionFactory.CreateMemberInitSelector<TSource, TResult>(fields, Columns.GetResultList()).Compile();

            // otherwise try and use a constructor that matches the field list types
            Type[] resultTypes = typeof(TSource).GetPropertyOrFieldTypes(fields);
            return ExpressionFactory.CreateConstructorCallSelector<TSource, TResult>(fields, resultTypes).Compile();
        }

        public Func<IEnumerable<TSource>, IEnumerable<TResult>> CreateGroupBySelector<TSource, TResult>()
        {
            if (Columns.Aggregates.Any() == false)
                throw new SqlException("At least one aggregate function must be present along with a GROUP BY clause.");

            NodeWithId groupByField = GroupByClause.GroupByItems.First();  // only one grouping field is supported atm
            return ExpressionFactory.CreateGroupBySelector<TSource, TResult>(groupByField.LookupId, groupByField.GetSourceType(typeof(TSource)), Columns.Aggregates).Compile();
        }

        public FromClause FromClause
        {
            get
            {
                return FindChild<FromClause>();
            }
        }

        public WhereClause WhereClause
        {
            get
            {
                return FindChild<WhereClause>(RuleConstants.RULE_WHERECLAUSE_WHERE);
            }
        }

        public OrderByClause OrderByClause
        {
            get
            {
                return FindChild<OrderByClause>();
            }
        }

        public GroupByClause GroupByClause
        {
            get
            {
                return FindChild<GroupByClause>();
            }
        }

        public HavingClause HavingClause
        {
            get
            {
                return FindChild<HavingClause>(RuleConstants.RULE_HAVINGCLAUSE_HAVING);
            }
        }
    }
}
