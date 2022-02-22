using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    public class OBATO_TO_ATS_MessageBuilder : MessageBuilder
    {
      



        public override void CreateMessageDS()
        {
            m_message.DS = (UInt32)Enums.Message.DS.OBATO_TO_ATS_SERVER;
        }
        public override void CreateMessageSize()
        {
            m_message.Size = (UInt32)Enums.Message.Size.OBATO_TO_ATS_SERVER;
        }
        public override void CreateMessageID()
        {
            m_message.ID = (UInt32)Enums.Message.ID.OBATO_TO_ATS_SERVER;
        }
        public override void CreateMessageDST(UInt32 DST)
        {
            m_message.DST = DST;
        }
        public override void CreateMessageSRC(UInt32 SRC)
        {
            m_message.SRC = SRC;
        }
        public override void CreateMessageRTC(ulong RTC)
        {
            m_message.RTC = RTC;
        }
        public override void CreateMessageNO(UInt32 NO)
        {
            //m_message.NO = NO;

            m_message.NO = MessageCounter.OBATO_TO_ATS_Counter;

            MessageCounter.OBATO_TO_ATS_Counter++;
        }

        public override void CreateMessageDATA(byte[] DATA)
        {
            m_message.DATA = DATA;

        }
        public override void CreateMessageCRC(UInt64 CRC)
        {
            m_message.CRC = CRC;
        }
    }
}
