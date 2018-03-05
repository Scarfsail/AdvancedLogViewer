using System;
using System.Diagnostics;

namespace SqlLinq.SyntaxTree
{
    public abstract class SyntaxNode
    {
        public NonTerminalNode Parent { get; internal set; }
        public int Index { get; internal set; }

        protected SyntaxNode()
        {
        }

        public void TraceNode()
        {
            TraceNode(this);
        }

        private static void TraceNode(SyntaxNode node)
        {
            if (node == null)
                return;

            Trace.Indent();
            Trace.WriteLine(node.ToString());

            if (node is TerminalNode == false)
            {
                foreach (SyntaxNode n in ((NonTerminalNode)node).Children)
                    TraceNode(n);
            }

            Trace.Unindent();
        }
    }
}
