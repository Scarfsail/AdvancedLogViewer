using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace SqlLinq.SyntaxTree.Literals
{
    public abstract class LiteralNode : NonTerminalNode
    {
        protected LiteralNode()
        {
        }

        internal ConstantExpression CreateExpression()
        {
            return Expression.Constant(ValueObject, ValueType);
        }

        public Func<T, bool> CreateFunction<T>()
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "arg");

            //traverse the tree to generate a lambda expression and then compiile into a function
            return Expression.Lambda<Func<T, bool>>(CreateExpression(), param).Compile();
        }

        internal abstract object ValueObject { get; }
        internal abstract Type ValueType { get; }
        internal abstract Delegate CoercionDelegate { get; }
        internal abstract object NullRepresentation { get; }
    }
}
