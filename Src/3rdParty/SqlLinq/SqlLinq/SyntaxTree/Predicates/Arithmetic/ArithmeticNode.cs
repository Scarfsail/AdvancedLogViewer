using System;

namespace SqlLinq.SyntaxTree.Predicates.Arithmetic
{
    public abstract class ArithmeticNode : PredicateNode
    {
        protected ArithmeticNode()
            : base(typeof(double), typeof(double))
        {
        }
    }
}
