using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    public interface ITrainMovementUIWatcher
    {
        void TrainMovementUIRefreshAllTrainList(OBATP OBATP);
        void TrainMovementUIRefreshTracksList(OBATP OBATP, UIOBATP UIOBATP);
    }
}
