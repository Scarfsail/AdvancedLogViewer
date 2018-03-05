using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SqlLinq.SyntaxTree.Literals
{
    public abstract class Literal<T> : LiteralNode
    {
        private Func<object, T> m_typeCoercion;
        private T m_nullRepresentation;

        protected Literal(Func<object, T> coercionMethod, T nullRepresentation)
        {
            Debug.Assert(coercionMethod != null);

            m_typeCoercion = coercionMethod;
            m_nullRepresentation = nullRepresentation;
        }

        internal override Type ValueType
        {
            get
            {
                return typeof(T);
            }
        }

        internal override object NullRepresentation
        {
            get
            {
                return m_nullRepresentation;
            }
        }

        internal override Delegate CoercionDelegate
        {
            get
            {
                return m_typeCoercion;
            }
        }

        internal override object ValueObject
        {
            get
            {
                return Value;
            }
        }

        public T Value
        {
            get
            {
                // the parsed node name and the class name are the same so using type name lookup works
                return m_typeCoercion(GetTerminalText(GetType().Name));
            }
        }
    }
}
