using System;
using System.Linq;
using System.Diagnostics;

using GoldParser;

using Kackman.RuntimeTypeLoader;

using SqlLinq.SyntaxTree;

namespace SqlLinq
{
    static class SyntaxRuleFactory
    {
        private static TypeLoader<NonTerminalNode, int> _nodeImplTypeMap = LoadImplTypes();

        public static NonTerminalNode CreateNode(Rule rule)
        {
            Debug.Assert(rule != null);

            NonTerminalNode node = null;
            if (_nodeImplTypeMap.ContainsKey(rule.Index))
                node = _nodeImplTypeMap.CreateInstance(rule.Index);
            else
                node = new NonTerminalNode();// if no type is bound to the rule then just create a base non-terminal node

            node.Rule = rule;
            return node;
        }

        private static TypeLoader<NonTerminalNode, int> LoadImplTypes()
        {
            TypeLoader<NonTerminalNode, int> loader = new TypeLoader<NonTerminalNode, int>();
            loader.SearchDirectories = false;
            loader.LoadMany((Type t) => { return t.GetCustomAttributes(typeof(SyntaxNodeAttribute), false).Select(attr => (int)((SyntaxNodeAttribute)attr).RuleConstant); });

            return loader;
        }
    }
}
