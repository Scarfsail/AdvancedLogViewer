using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

using SqlLinq.SyntaxTree.Literals;
using SqlLinq.SyntaxTree.Aggregates;
using SqlLinq.SyntaxTree.Predicates;

namespace SqlLinq.SyntaxTree.Clauses
{
    [SyntaxNode(RuleConstants.RULE_WHERECLAUSE_WHERE)]
    public class WhereClause : NonTerminalNode
    {
        public WhereClause()
        {
        }

        public Func<T, bool> CreateEvaluator<T>()
        {
            PredicateNode predicate = FindChild<PredicateNode>();
            if (predicate != null)
                return predicate.CreateFunction<T>();

            LiteralNode node = FindChild<LiteralNode>();
            if (node != null)
                return node.CreateFunction<T>();

            Debug.Assert(false);
            return null;
        }

        public IEnumerable<string> GetFieldList()
        {
            return FindDescendants<NodeWithId>().ToList().ConvertAll<string>(source => source.LookupId).Distinct(StringComparer.CurrentCultureIgnoreCase);
        }

        internal override void CheckSyntax()
        {
            if (FindDescendants<AggregateNode>().Any())
                throw new RuleException("Aggregate expressions are not valid in a WHERE clause.\nTry GROUP BY and HAVING instead.");
        }
    }
}
