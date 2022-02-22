using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    class MessageSelector
    {
        public IMessageType GetMessageType(Enums.Message.ID messageID)
        {
            if (messageID == Enums.Message.ID.WSATP_TO_OBATP)
            {
                return new WSATP_TO_OBATP();
            }
           else if (messageID == Enums.Message.ID.OBATP_TO_WSATP)
            {
                return new OBATP_TO_WSATP();
            }
            else if (messageID == Enums.Message.ID.OBATO_TO_ATS_SERVER)
            {
                return new OBATO_TO_ATS();
            }
            else if (messageID == Enums.Message.ID.ATS_SERVER_TO_OBATO)
            {
                return new ATS_TO_OBATO();
            }
            else // (messageID == Enums.Message.ID.ATS_SERVER_TO_OBATO_Init)
            {
                return new ATS_TO_OBATO_Init();
            }
        }
    }
}
