using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    class ATS_TO_OBATO_InitAdaptee
    {
        ATS_TO_OBATO_Init m_messageType;
        public ATS_TO_OBATO_InitAdaptee(IMessageType ATS_TO_OBATO_Init)
        {
            m_messageType = (ATS_TO_OBATO_Init)ATS_TO_OBATO_Init;
        }


        public ATS_TO_OBATO_Init GetMessageType()
        {

            return m_messageType;
        }
    }
}
