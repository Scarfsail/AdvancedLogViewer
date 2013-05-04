using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLogViewer.Common.Parser
{
    public class PatternItem
    {
        public PatternItemType ItemType;
        public string EndsWith;
        public string StartsWith;
        public bool DoLTrim;

        public override string ToString()
        {
            return patternTypeToText[this.ItemType];
        }


        private static Dictionary<PatternItemType, string> patternTypeToText = new Dictionary<PatternItemType, string>(){
                                                                              {PatternItemType.Date, "Date"},
                                                                              {PatternItemType.Time, "Time"},
                                                                              {PatternItemType.Thread, "Thread"},
                                                                              {PatternItemType.Type, "Type"},
                                                                              {PatternItemType.Class, "Class"},
                                                                              {PatternItemType.Message, "Message"}};
    }
}
