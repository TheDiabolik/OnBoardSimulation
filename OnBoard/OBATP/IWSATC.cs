using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    interface IWSATC
    {
        bool TrainAbsoluteZeroSpeed { get; set; }

        bool OBATCtoWSATC_BerthingOk { get; set; }

        void CheckBerthingStatus(double currentSpeedCMS);
        void CheckTrainAbsoluteZeroSpeed();
    }
}
