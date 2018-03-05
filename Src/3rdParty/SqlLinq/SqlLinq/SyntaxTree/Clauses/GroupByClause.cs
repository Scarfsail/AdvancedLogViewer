using System.Collections.Generic;

namespace SqlLinq.SyntaxTree.Clauses
{
    [SyntaxNode(RuleConstants.RULE_GROUPCLAUSE_GROUP_BY)]
    public class GroupByClause : NonTerminalNode
    {
        public GroupByClause()
        {
        }

        public IEnumerable<NodeWithId> GroupByItems
        {
            get
            {
                return FindDescendants<NodeWithId>();
            }
        }
    }
}
