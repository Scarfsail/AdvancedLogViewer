using System;

namespace SqlLinq
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]    
    sealed class SyntaxNodeAttribute : Attribute
    {
        public SyntaxNodeAttribute(RuleConstants constant)
        {
            RuleConstant = constant;
        }

        public RuleConstants RuleConstant { get; private set; }
    }
}
