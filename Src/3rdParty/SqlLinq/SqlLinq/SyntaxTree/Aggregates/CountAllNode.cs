using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SqlLinq.SyntaxTree.Aggregates
{
    [SyntaxNode(RuleConstants.RULE_AGGREGATE_COUNT_LPARAN_TIMES_RPARAN)]
    [SyntaxNode(RuleConstants.RULE_AGGREGATE_COUNT_LPARAN_RPARAN)]
    public class CountAllNode : AggregateNode
    {
        public CountAllNode()
        {
            Name = "Count";
        }

        protected override MethodInfo GetEvaluationMethod(Type paramType)
        {
            return (from method in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                    where method.Name == Name
                    && method.GetParameters().Length == 1
                    select method).FirstOrDefault();
        }
    }
}
