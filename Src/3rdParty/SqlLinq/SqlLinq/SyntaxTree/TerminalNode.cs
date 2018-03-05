using System;
using System.Diagnostics;

using GoldParser;

namespace SqlLinq.SyntaxTree
{
    public class TerminalNode : SyntaxNode
    {
        internal TerminalNode(Parser parser)
        {
            Debug.Assert(parser != null);

            Symbol = parser.TokenSymbol;
            Text = parser.TokenText;
            LineNumber = parser.LineNumber;
            LinePosition = parser.LinePosition;
        }

        internal Symbol Symbol { get; private set; }

        public string Text { get; private set; }

        public int LineNumber { get; private set; }

        public int LinePosition { get; private set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
