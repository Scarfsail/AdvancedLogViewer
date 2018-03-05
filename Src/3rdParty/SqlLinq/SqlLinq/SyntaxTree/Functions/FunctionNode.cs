using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlLinq.SyntaxTree.Functions
{
    public abstract class FunctionNode : NonTerminalNode
    {
        public FunctionNode()
        {
        }

        protected static Type WidenType(Type type)
        {
            if (type == typeof(int) || type == typeof(short) || type == typeof(byte))
                return typeof(long);

            if (type == typeof(int?) || type == typeof(short?) || type == typeof(byte?))
                return typeof(long?);

            if (type == typeof(float))
                return typeof(double);

            if (type == typeof(float?))
                return typeof(double?);

            return type;
        }

        public abstract Expression CreateExpression(ParameterExpression param);
    }
}
