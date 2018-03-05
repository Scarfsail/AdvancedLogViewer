using System;
using System.Linq;
using System.Collections.Generic;

namespace SqlLinq.SyntaxTree.Aggregates
{
    [SyntaxNode(RuleConstants.RULE_AGGREGATE_SUM_LPARAN_RPARAN)]
    public class SumNode : AggregateNode
    {
        public SumNode()
        {
            Name = "Sum";
        }
    }
}
