using System;
using System.Collections.Generic;
using System.Linq;

using SqlLinq.SyntaxTree.Aggregates;

namespace SqlLinq.SyntaxTree
{
    [SyntaxNode(RuleConstants.RULE_COLUMNS_TIMES)]
    [SyntaxNode(RuleConstants.RULE_COLUMNS)]
    public class Columns : NonTerminalNode
    {
        public Columns()
        {
        }

        public bool AllColumns
        {
            get
            {
                return Rule.Index == (int)RuleConstants.RULE_COLUMNS_TIMES || CountAll;
            }
        }

        public bool CountAll
        {
            get
            {
                return FindDescendants<CountAllNode>().Any();
            }
        }

        public bool Distinct
        {
            get
            {
                return FindChild<NonTerminalNode>(RuleConstants.RULE_RESTRICTION_DISTINCT) != null;
            }
        }
        public IEnumerable<AggregateNode> Aggregates
        {
            get
            {
                 return FindDescendants<AggregateNode>();
            }
        }

        public IEnumerable<string> GetFieldList()
        {
            // first get all the fields being specifically returned
            // depending on how the slect statement is contructed the parser may or may not elimate some intermediate reductions
            // the where statement here will elimate those instances where reductions are not elimated by the parser
            return (from c in ColumnSources
                    from f in c.GetFields()
                    select f).Select(field => field.SourceId).Distinct(StringComparer.CurrentCultureIgnoreCase);
        }

        public IEnumerable<string> GetResultList()
        {
            // first get all the fields being specifically returned
            // depending on how the slect statement is contructed the parser may or may not elimate some intermediate reductions
            // the where statement here will elimate those instances where reductions are not elimated by the parser
            return (from c in ColumnSources
                    from f in c.GetFields()
                    select f).Select(field => field.Alias).Distinct(StringComparer.CurrentCultureIgnoreCase);
        }

        internal bool IncludeInResultSet(string id)
        {
            return ColumnSources.Where(source => source.SourceId == id && source is AggregateNode == false).Any();
        }

        public IEnumerable<ColumnSource> ColumnSources
        {
            get
            {
                return FindDescendants<ColumnSource>().Where(item => item.FindChild<ColumnSource>() == null);
            }
        }
    }
}
