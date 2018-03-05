using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using SqlLinq.SyntaxTree.Literals;

namespace SqlLinq.SyntaxTree.Predicates.Comparison
{
    [SyntaxNode(RuleConstants.RULE_PREDEXP_IN)]
    public class InNode : PredicateNode
    {
        public InNode()
            : base(typeof(string), typeof(bool))
        {
        }

        protected override Expression CreateOperatorExpression(ParameterExpression param, Expression left)
        {
            Expression expression = null;
            foreach (LiteralNode literal in GetLiteralList())
            {
                Expression equal = Expression.Equal(left, Expression.Constant(literal.ValueObject, literal.ValueType));
                if (expression == null)
                    expression = equal;
                else
                    expression = Expression.OrElse(expression, equal);
            }

            return expression;
        }

        private IEnumerable<LiteralNode> GetLiteralList()
        {
            return FindDescendants<LiteralNode>();
        }
    }
}
