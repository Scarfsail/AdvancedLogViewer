using System;
using System.Reflection;

namespace SqlLinq.SyntaxTree
{
    [SyntaxNode(RuleConstants.RULE_IDMEMBER_ID)]
    [SyntaxNode(RuleConstants.RULE_VALUE_ID)]
    [SyntaxNode(RuleConstants.RULE_COLUMNALIAS_AS_ID)]
    public class NodeWithId : NonTerminalNode
    {
        private string m_evaluationId;

        public NodeWithId()
        {
        }

        /// <summary>
        /// The physical data model name 
        /// </summary>
        public string LookupId
        {
            get
            {
                return GetTerminalText("Id").Trim('[', ']');
            }
        }

        public Type GetSourceType(Type tSource)
        {
            return tSource.GetPropertyOrFieldType(LookupId);
        }

        /// <summary>
        /// A deterministically derived id that can be used to query the data regardless
        /// of the use of aliases
        /// </summary>
        internal string EvaluationId
        {
            get
            {
                if (string.IsNullOrEmpty(m_evaluationId) == false)
                    return m_evaluationId;

                return LookupId;
            }
            set
            {
                m_evaluationId = value;
            }
        }
    }
}
