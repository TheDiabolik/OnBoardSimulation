using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class WSATP_TO_OBATP_MessageBuilder : MessageBuilder
    { 

        public override void CreateMessageDS()
        {
            m_message.DS = (UInt32)Enums.Message.DS.WSATP_TO_OBATP;
        }
        public override void CreateMessageSize()
        {
            m_message.Size = (UInt32)Enums.Message.Size.WSATP_TO_OBATP;
        }
        public override void CreateMessageID()
        {
            m_message.ID = (UInt32)Enums.Message.ID.WSATP_TO_OBATP;
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

            m_message.NO = MessageCounter.WSATP_TO_OBATP_Counter;

            MessageCounter.WSATP_TO_OBATP_Counter++;
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
