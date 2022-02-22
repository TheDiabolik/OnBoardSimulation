using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public interface IATS_TO_OBATO_MessageWatcher
    {
        void ATS_TO_OBATO_MessageInComing(Enums.Train_ID train_ID, ATS_TO_OBATOAdapter ATS_TO_OBATOAdapter);
    }
}
