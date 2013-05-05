using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AdvancedLogViewer.Common.Parser
{

    public class PatternManager
    {
        private static string systemPatternFileName = Path.Combine(Globals.AppDataDir, "ParserPatterns.def");
        private static string customPatternFileName = Path.Combine(Globals.UserDataDir, "CustomParserPatterns.def");

        public PatternManager()
        {
            this.CustomPatterns = GetPatternItems(customPatternFileName);
            this.SystemPatterns = GetPatternItems(SystemPatternFileName);
        }

        public List<LogPattern> CustomPatterns { get; private set; }
        public List<LogPattern> SystemPatterns { get; private set; }

        public static string SystemPatternFileName { get { return systemPatternFileName; } }
        public static string CustomPatternFileName { get { return customPatternFileName; } }

        public static LogPattern GetPatternForLog(string logFileName)
        {
            string[] patternLines = GetPatternLine(logFileName, false);
            if (patternLines == null)
                return null;
            else
                return new LogPattern(patternLines);
        }

        public static LogPattern GetPatternByName(string patternName)
        {
            string[] patternLines = GetPatternLine(patternName, true);
            if (patternLines == null)
                return null;
            else
                return new LogPattern(patternLines);
        }

        public void SaveCustomPatterns()
        {
            StringBuilder fileContent = new StringBuilder();
            foreach (LogPattern pattern in this.CustomPatterns)
            {
                fileContent.AppendLine(pattern.GetLineForConfigFile());
            }

            File.WriteAllText(customPatternFileName, fileContent.ToString());
        }



        private static string[] GetPatternLine(string patternId, bool exactMatch)
        {
            if (!exactMatch)
                patternId = Path.GetFileName(patternId);

            //User's Parser Patterns definition file (modified by an user)
            string[] result = GetPatternLine(patternId, customPatternFileName, exactMatch);
            if (result != null)
                return result;


            //Default Parser Patterns definition file (provided with application)
            if (!File.Exists(systemPatternFileName))
                throw new FileNotFoundException(systemPatternFileName);

            result = GetPatternLine(patternId, systemPatternFileName, exactMatch);
            return result;
        }

        private static string[] GetPatternLine(string patternId, string patternFile, bool exactMatch)
        {
            string[] patternLines;

            if (File.Exists(patternFile))
            {
                patternLines = File.ReadAllLines(patternFile);

                foreach (string line in patternLines)
                {
                    string[] lineParts = line.Split(new char[] { '|' });

                    if ((exactMatch && lineParts[0].Equals(patternId, StringComparison.OrdinalIgnoreCase)) || (!exactMatch && StringMatchWithWildcards(lineParts[0], patternId)))
                    {
                        return lineParts;
                    }
                }
            }
            return null;
        }

        private static List<string[]> GetPatternLines(string patternFile)
        {
            List<string[]> result = new List<string[]>();

            if (File.Exists(patternFile))
            {
                string[] patternLines = File.ReadAllLines(patternFile);

                foreach (string line in patternLines)
                {
                    string[] lineParts = line.Split(new char[] { '|' });
                    result.Add(lineParts);
                }
            }
            return result;
        }

        private static List<LogPattern> GetPatternItems(string patternFile)
        {
            List<LogPattern> result = new List<LogPattern>();
            List<string[]> patternLines = GetPatternLines(patternFile);

            foreach (string[] lineParts in patternLines)
            {
                result.Add(new LogPattern(lineParts));
            }

            return result;
        }


        private static bool StringMatchWithWildcards(string patternWithWildCards, string stringToMatch)
        {
            if (patternWithWildCards == "*")
                return true;
            if (patternWithWildCards.Length == 0)
                return stringToMatch.Length == 0;
            if (stringToMatch.Length == 0)
                return false;
            if (patternWithWildCards[0] == '*' && patternWithWildCards.Length > 1)
            {
                for (int index = 0; index < stringToMatch.Length; index++)
                {
                    if (StringMatchWithWildcards(patternWithWildCards.Substring(1), stringToMatch.Substring(index)))
                        return true;
                }
            }
            else if (patternWithWildCards[0] == '*')
                return true;
            else if (patternWithWildCards[0].Equals(stringToMatch[0]))
                return StringMatchWithWildcards(patternWithWildCards.Substring(1), stringToMatch.Substring(1));

            return false;
        }
    }
}
