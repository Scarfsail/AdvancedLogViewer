using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using GoldParser;

namespace SqlLinq.SyntaxTree
{
    public class NonTerminalNode : SyntaxNode
    {
        private IList<SyntaxNode> m_children = new List<SyntaxNode>();

        public NonTerminalNode()
        {
        }

        internal Rule Rule { get; set; }
        
        internal RuleConstants RuleId
        {
            get
            {
                return (RuleConstants)Rule.Index;
            }
        }

        /// <summary>
        /// This method is used during parsing to enforce syntax rules not expressed in the grammar
        /// </summary>
        internal virtual void CheckSyntax()
        {
        }

        public override string ToString()
        {
            return string.Format("{0} [Rule Id={1} Class={2}]", Rule.Name, this.RuleId, this.GetType().Name);
        }

        public IEnumerable<SyntaxNode> Children
        {
            get
            {
                return m_children;
            }
        }

        internal protected string GetTerminalText(string name)
        {
            TerminalNode terminal = m_children.OfType<TerminalNode>().SingleOrDefault(node => node.Symbol.Name == name);
            return terminal != null ? terminal.Text : string.Empty;
        }

        internal protected IEnumerable<T> FindDescendants<T>() where T : NonTerminalNode
        {
            IList<T> list = new List<T>();
            foreach (NonTerminalNode node in m_children.OfType<NonTerminalNode>())
            {
                if (node is T)
                    list.Add(node as T);

                list = list.Concat<T>(node.FindDescendants<T>()).ToList();
            }

            return list;
        }

        internal protected IEnumerable<T> FindChildren<T>(RuleConstants child) where T : NonTerminalNode
        {
            return m_children.OfType<T>().Where(node => node.Rule.Index == (int)child);
        }

        internal protected IEnumerable<T> FindChildren<T>() where T : SyntaxNode
        {
            return m_children.OfType<T>();
        }

        internal protected T FindChild<T>(RuleConstants child) where T : NonTerminalNode
        {
            return m_children.OfType<T>().SingleOrDefault(node => node.Rule.Index == (int)child);
        }

        internal protected T FindChild<T>() where T : SyntaxNode
        {
            return m_children.OfType<T>().SingleOrDefault();
        }

        internal protected T FindChild<T>(int index) where T : SyntaxNode
        {
            return m_children[index] as T;
        }

        internal void AppendChildNode(SyntaxNode node)
        {
            Debug.Assert(node != null);

            m_children.Add(node);
            node.Index = m_children.IndexOf(node);
            node.Parent = this;
        }
    }
}
