using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public interface IATS_TO_OBATO_InitMessageWatcher
    {
        void ATS_TO_OBATO_InitMessageInComing(Enums.Train_ID m_train_ID, ATS_TO_OBATO_InitAdapter ATS_TO_OBATO_InitAdapter);
    }
}
