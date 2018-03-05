using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

using GoldParser;

using SqlLinq.SyntaxTree;

namespace SqlLinq
{
    public class SqlParser
    {
        private Parser m_parser;

        public SqlParser()
        {
        }

        public string ErrorString { get; private set; }

        public NonTerminalNode SyntaxTree { get; private set; }

        public string ErrorLine
        {
            get
            {
                return m_parser.LineText;
            }
        }

        public int LinePosition
        {
            get
            {
                return m_parser.LinePosition;
            }
        }

        public int LineNumber
        {
            get
            {
                return m_parser.LineNumber;
            }
        }

        public bool Parse(string source)
        {
            Debug.Assert(string.IsNullOrEmpty(source) == false);

            using (TextReader reader = new StringReader(source))
                return Parse(reader);
        }

        public bool Parse(TextReader sourceReader)
        {
            Debug.Assert(sourceReader != null);

            m_parser = ParserFactory.CreateParser(sourceReader);
            m_parser.TrimReductions = true;

            while (true)
            {
                switch (m_parser.Parse())
                {
                    case ParseMessage.LexicalError:
                        ErrorString = string.Format("Lexical Error. Line {0}. Token {1} was not expected.", m_parser.LineNumber, m_parser.TokenText);
                        return false;

                    case ParseMessage.SyntaxError:
                        StringBuilder text = new StringBuilder();
                        foreach (Symbol tokenSymbol in m_parser.GetExpectedTokens())
                            text.AppendFormat(" {0}", tokenSymbol);

                        ErrorString = string.Format("Syntax Error. Line {0}. Expecting: {1}.", m_parser.LineNumber, text);

                        return false;

                    case ParseMessage.Reduction:
                        NonTerminalNode nonTerminal = SyntaxRuleFactory.CreateNode(m_parser.ReductionRule);
                        m_parser.TokenSyntaxNode = nonTerminal;

                        for (int i = 0; i < m_parser.ReductionCount; i++)
                            nonTerminal.AppendChildNode(m_parser.GetReductionSyntaxNode(i) as SyntaxNode);

                        // post parsing syntax check (used to segregate the difference between HAVING and WHERE 
                        // expressions in terms of the validtity of aggregate expressions)
                        nonTerminal.CheckSyntax();

                        break;

                    case ParseMessage.TokenRead:
                        m_parser.TokenSyntaxNode = new TerminalNode(m_parser);
                        break;

                    case ParseMessage.Accept:
                        SyntaxTree = m_parser.TokenSyntaxNode as NonTerminalNode;
                        ErrorString = null;
                        return true;

                    case ParseMessage.InternalError:
                        ErrorString = "Internal Error. Something is horribly wrong.";
                        return false;

                    case ParseMessage.NotLoadedError:
                        ErrorString = "Grammar Table is not loaded.";
                        return false;

                    case ParseMessage.CommentError:
                        ErrorString = "Comment Error. Unexpected end of input.";
                        return false;

                    case ParseMessage.CommentBlockRead:
                    case ParseMessage.CommentLineRead:
                        // don't do anything 
                        break;
                }
            }
        }
    }
}
