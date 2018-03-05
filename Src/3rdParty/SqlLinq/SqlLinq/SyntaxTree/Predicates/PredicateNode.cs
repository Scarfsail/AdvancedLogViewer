using System;
using System.Diagnostics;
using System.Linq.Expressions;

using SqlLinq.SyntaxTree.Literals;
using SqlLinq.SyntaxTree.Functions;

namespace SqlLinq.SyntaxTree.Predicates
{
    public abstract class PredicateNode : NonTerminalNode
    {
        private Type m_defaultOperandType = typeof(string);
        private Type m_defaultReturnType = typeof(bool);

        protected PredicateNode()
        {
        }

        protected PredicateNode(Type defaultOperandType, Type defaultReturnType)
        {
            m_defaultOperandType = defaultOperandType;
            m_defaultReturnType = defaultReturnType;
        }

        public Func<T, bool> CreateFunction<T>()
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "arg");
            //traverse the tree to generate a lambda expression and then compile into a function
            return Expression.Lambda<Func<T, bool>>(CreateOperatorExpression(param, GetLeftExpression(param)), param).Compile();
        }

        protected abstract Expression CreateOperatorExpression(ParameterExpression param, Expression left);

        protected Expression CreateExpression(ParameterExpression param)
        {
            return CreateOperatorExpression(param, GetLeftExpression(param));
        }

        protected Expression CreateChildExpression(ParameterExpression param, int index)
        {
            LiteralNode constant = FindChild<LiteralNode>(index);
            if (constant != null)
                return constant.CreateExpression();           

            Expression expression = CreateDereferenceExpression(param, index);
            if (expression != null)
                return expression;

            PredicateNode predicate = FindChild<PredicateNode>(index);
            if (predicate != null)
                return predicate.CreateExpression(param);

            FunctionNode function = FindChild<FunctionNode>(index);
            if (function != null)
                return function.CreateExpression(param);

            // by not passing an index we pick up 'WHERE TRUE' etc
            LiteralNode literal = FindChild<LiteralNode>();
            if (literal != null)
                return literal.CreateExpression();

            return null;
        }

        internal virtual LiteralNode GetExpressionType()
        {
            return GetExpressionType(false);
        }

        internal virtual LiteralNode GetExpressionType(bool nested)
        {
            // first look for the type of the right hand operand
            LiteralNode node = FindCoercionType(2, nested);

            // if that doesn't work try the left hand
            if (node == null)
                node = FindCoercionType(0, nested);

            // we can't find a literal or predicate to drive the coercion, use defaults
            if (node == null && !nested)
                node = CreateLiteral(m_defaultReturnType);

            return node;
        }

        protected LiteralNode FindCoercionType(int index)
        {
            return FindCoercionType(index, false);
        }

        protected LiteralNode FindCoercionType(int index, bool nested)
        {
            if (index != 0 && index != 2)
                return null;

            LiteralNode node = FindChild<LiteralNode>(OppositeSide(index)); // look at what the child operand is being compared to

            if (node == null && (Index == 0 || Index == 2))
                node = Parent.FindChild<LiteralNode>(OppositeSide(this.Index)); // look at what the whole expression is being compared to

            // if we don't find any literals in the area look, for a predicate expression that can drive the type coercion
            if (node == null)
            {
                PredicateNode predicate = FindChild<PredicateNode>(OppositeSide(index)); // look at what the child operand is being compared to
                if (predicate == null && (Index == 0 || Index == 2))
                    predicate = Parent.FindChild<PredicateNode>(OppositeSide(this.Index)); // look at what the whole expression is being compared to

                if (predicate != null && !nested)
                    node = predicate.GetExpressionType(true);
            }

            return node;
        }

        private static LiteralNode CreateLiteral(Type type)
        {
            if (type == typeof(long) || type == typeof(int) || type == typeof(short) || type == typeof(byte))
                return new IntegerLiteral();

            if (type == typeof(double) || type == typeof(Single))
                return new RealLiteral();

            if (type == typeof(bool))
                return new BooleanLiteral();

            if (type == typeof(string))
                return new StringLiteral();

            if (type == typeof(DateTime))
                return new DateLiteral();

            return new NullLiteral();
        }

        private LiteralNode GetDefaultCoercionType()
        {
            return CreateLiteral(m_defaultOperandType);
        }

        private LiteralNode GetTypeCoercionNode(int index)
        {
            LiteralNode node = FindCoercionType(index);

            // we can't find a literal or predicate to drive the coercion, use defaults
            if (node == null)
                node = GetDefaultCoercionType();

            return node;
        }

        private Expression CreateDereferenceExpression(ParameterExpression param, int index)
        {
            NodeWithId idNode = FindChild<NodeWithId>(index);
            if (idNode != null)
            {
                LiteralNode node = GetTypeCoercionNode(index); // this is used to coerce the value to the correct type for comparison
                return ExpressionFactory.CreateReadPropertyExpression(param, idNode.EvaluationId, node.ValueType);
            }

            return null;
        }

        private static int OppositeSide(int index)
        {
            Debug.Assert(index == 0 || index == 2);
            return index == 0 ? 2 : 0;
        }

        public Expression GetLeftExpression(ParameterExpression param)
        {
            return CreateChildExpression(param, 0);
        }

        public Expression GetRightExpression(ParameterExpression param)
        {
            return CreateChildExpression(param, 2);
        }
    }
}
