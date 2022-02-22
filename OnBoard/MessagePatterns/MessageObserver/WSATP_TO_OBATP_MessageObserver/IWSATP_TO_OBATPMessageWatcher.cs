using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public interface IWSATP_TO_OBATPMessageWatcher
    {
        void WSATP_TO_OBATPMessageInComing(Enums.Train_ID train_ID, WSATP_TO_OBATPAdapter WSATP_TO_OBATPAdapter);
    }
}
