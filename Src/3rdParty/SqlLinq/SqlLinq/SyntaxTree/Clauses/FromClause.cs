using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlLinq.SyntaxTree.Clauses
{
    [SyntaxNode(RuleConstants.RULE_FROMCLAUSE_FROM)]
    public class FromClause : NonTerminalNode
    {
        public FromClause()
        {
        }

        public IEnumerable<string> SourceList
        {
            get
            {
                IEnumerable<string> descendants = FindDescendants<NodeWithId>().Select(item => item.LookupId);
                if (descendants.Any())
                    return descendants;

                return new List<string>() { GetTerminalText("Id") };
            }
        }
    }
}
