using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    class ATS_TO_OBATOAdaptee
    {
        ATS_TO_OBATO m_messageType;

        public ATS_TO_OBATOAdaptee(IMessageType ATS_TO_OBATO)
        {
            m_messageType = (ATS_TO_OBATO)ATS_TO_OBATO;
        }


        public ATS_TO_OBATO GetMessageType()
        {

            return m_messageType;
        }
    }
}
