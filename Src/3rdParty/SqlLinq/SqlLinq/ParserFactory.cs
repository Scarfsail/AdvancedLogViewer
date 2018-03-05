using System.IO;
using System.Reflection;
using System.Diagnostics;

using GoldParser;

namespace SqlLinq
{
    static class ParserFactory
    {
        private static Grammar _grammar = InitializeFactoryFromResource();

        private static Grammar InitializeFactoryFromResource()
        {
            using (BinaryReader reader = new BinaryReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("SqlLinq.SQL-ANSI-89.4.cgt")))
                return new Grammar(reader);
        }

        public static Parser CreateParser(TextReader reader)
        {
            Debug.Assert(reader != null);
            Debug.Assert(_grammar != null);

            return new Parser(reader, _grammar);
        }
    }
}
