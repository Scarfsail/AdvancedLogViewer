using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlLinq.SyntaxTree.Aggregates
{
    [SyntaxNode(RuleConstants.RULE_AGGREGATE_STDEV_LPARAN_RPARAN)]
    public class StandardDeviationNode : VarianceNode
    {
        public StandardDeviationNode()
        {
            Name = "StandardDeviation";
        }
    }
}
