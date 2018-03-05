using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlLinq.SyntaxTree.Aggregates
{
    [SyntaxNode(RuleConstants.RULE_AGGREGATE_STDEVP_LPARAN_RPARAN)]
    public class StandardDeviationPNode : VariancePNode
    {
        public StandardDeviationPNode()
        {
            Name = "StandardDeviationP";
        }
    }
}
