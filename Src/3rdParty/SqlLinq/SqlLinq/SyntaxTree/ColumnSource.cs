using System.Collections.Generic;

using SqlLinq.SyntaxTree.Aggregates;

namespace SqlLinq.SyntaxTree
{
    [SyntaxNode(RuleConstants.RULE_COLUMNSOURCE_ID2)]  // AS Alias
    [SyntaxNode(RuleConstants.RULE_COLUMNSOURCE_ID)]
    [SyntaxNode(RuleConstants.RULE_COLUMNSOURCE2)]
    public class ColumnSource : NonTerminalNode
    {
        public ColumnSource()
        {
        }

        public virtual bool HasAlias
        {
            get
            {
                return FindChild<NonTerminalNode>(RuleConstants.RULE_COLUMNALIAS_AS_ID) != null;
            }
        }

        public virtual string Alias
        {
            get
            {
                NodeWithId alias = FindChild<NodeWithId>(RuleConstants.RULE_COLUMNALIAS_AS_ID);
                if (alias != null)
                    return alias.LookupId;

                return SourceId;
            }
        }

        public virtual string LookupId
        {
            get
            {
                AggregateNode aggregate = FindChild<AggregateNode>();
                if (aggregate != null)
                    return aggregate.LookupId;

                return GetTerminalText("Id").Trim('[', ']');
            }
        }

        public virtual string SourceId
        {
            get
            {
                AggregateNode aggregate = FindChild<AggregateNode>();
                if (aggregate != null)
                    return aggregate.SourceId;

                return GetTerminalText("Id").Trim('[', ']');
            }
        }

        internal virtual IEnumerable<FieldReference> GetFields()
        {
            IList<FieldReference> list = new List<FieldReference>();

            FieldReference field = new FieldReference();
            field.EvaluationId = LookupId;
            field.SourceId = SourceId;
            field.LookupId = LookupId;
            field.Alias = Alias;
            list.Add(field);

            return list;
        }
    }
}
