using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlLinq.SyntaxTree.Aggregates
{
    [SyntaxNode(RuleConstants.RULE_AGGREGATE_MAX_LPARAN_RPARAN)]
    public class MaxNode : AggregateNode
    {
        public MaxNode()
        {
            Name = "Max";
        }
    }
}
