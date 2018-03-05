using System;
using System.Runtime.Serialization;

namespace SqlLinq
{
    [Serializable()]
    public class SqlException : ApplicationException
    {
        public SqlException()
        {
        }

        public SqlException(string message)
            : base(message)
        {
        }

        public SqlException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected SqlException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    [Serializable()]
    public class SymbolException : ApplicationException
    {
        public SymbolException()
        {
        }

        public SymbolException(string message)
            : base(message)
        {
        }

        public SymbolException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    [Serializable()]
    public class RuleException : ApplicationException
    {
        public RuleException()
        {
        }

        public RuleException(string message)
            : base(message)
        {
        }

        public RuleException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
