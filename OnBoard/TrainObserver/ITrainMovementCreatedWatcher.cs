using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    public interface ITrainMovementCreatedSendMessageWatcher
    {
        void TrainMovementCreatedSendMessage(OBATP OBATP);
    }
}
