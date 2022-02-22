using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class WSATP_TO_OBATPAdaptee
    {
        WSATP_TO_OBATP m_messageType;
        public WSATP_TO_OBATPAdaptee(IMessageType WSATP_TO_OBATP)
        {
             m_messageType = (WSATP_TO_OBATP)WSATP_TO_OBATP;
        }
        
        
        public WSATP_TO_OBATP GetMessageType()
        { 

            return m_messageType;
        }


     
    }
}
