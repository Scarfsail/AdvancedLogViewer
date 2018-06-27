using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheCodeKing.Net.Messaging;

namespace AdvancedLogViewer.BL.Comm
{
    class CommDatagram
    {
        private CommDatagram()
        {
                        
        }     

        public static string GetMessage(Guid senderId, MessageType messageType, string data)
        {
            return senderId.ToString() + msgDelimiter + ((int)messageType).ToString() + msgDelimiter + data;
        }

        public static CommDatagram ParseDatagram(DataGram datagram)
        {
            CommDatagram result = new CommDatagram();
            int idx = -1;
            
            //Sender ID
            string msgPart = GetMessagePart(datagram.Message, ref idx);
            if (msgPart == null)
                return null;
            result.SenderId = new Guid(msgPart);
            
            //Message type
            msgPart = GetMessagePart(datagram.Message, ref idx);
            if (msgPart == null)
                return null;
            result.MessageType = (MessageType)Convert.ToInt32(msgPart);

            //Data
            msgPart = datagram.Message.Substring(idx + 1, datagram.Message.Length - idx - 1);
            result.Data = msgPart;

            return result;
        }

        private static string GetMessagePart(string fullMessage, ref int index)
        {
            int prevIndex = ++index;
            index = fullMessage.IndexOf(msgDelimiter, index);
            if (index == -1)
                return null;

            return fullMessage.Substring(prevIndex, index - prevIndex);
        }

        public Guid SenderId { get; private set; }
        public MessageType MessageType { get; private set; }
        public string Data { get; private set; }
        
        private const char msgDelimiter = '\n';
    }
}
