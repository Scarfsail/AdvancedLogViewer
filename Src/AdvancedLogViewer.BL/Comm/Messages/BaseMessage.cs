using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLogViewer.BL.Comm.Messages
{
    public abstract class BaseMessage
    {
        public abstract string GetTextMessage();

        protected const char msgDelimiter = '\n';

        protected static string GetMessagePart(string fullMessage, ref int index)
        {
            int prevIndex = ++index;
            index = fullMessage.IndexOf(msgDelimiter, index);
            if (index == -1)
                return null;

            return fullMessage.Substring(prevIndex, index - prevIndex);
        }

        protected string GetRestOfMessage(string fullMessage, int index)
        {
            return fullMessage.Substring(index + 1, fullMessage.Length - index - 1);
        }
        
    }
}
