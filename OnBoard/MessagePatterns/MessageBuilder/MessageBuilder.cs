using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public abstract class MessageBuilder
    {
        protected Message m_message; 

        public void MessageCreate()
        {
            m_message = new Message();
        }

        public Message GetMessage()
        {
            return m_message;
        }
        //public Message GetMessageToByte()
        //{
        //    return m_message;
        //}


        public abstract void CreateMessageDS();
        public abstract void CreateMessageSize();
        public abstract void CreateMessageID();
        public abstract void CreateMessageDST(UInt32 DST);
        public abstract void CreateMessageSRC(UInt32 SRC);
        public abstract void CreateMessageRTC(ulong RTC);
        public abstract void CreateMessageNO(UInt32 NO);

        public abstract void CreateMessageDATA(byte[] DATA);
        public abstract void CreateMessageCRC(UInt64 CRC);


    }
}
