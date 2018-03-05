using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using LinqStatistics;

namespace SqlLinq.SyntaxTree.Aggregates
{
    [SyntaxNode(RuleConstants.RULE_AGGREGATE_VAR_LPARAN_RPARAN)]
    public class VarianceNode : AggregateNode
    {
        public VarianceNode()
        {
            Name = "Variance";
        }

        protected override Type GetEvaluatatorType()
        {
            return typeof(EnumerableStats);
        }
    }
}
