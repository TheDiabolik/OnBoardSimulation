using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    static class WakeUpTrainExtensions
    {
        public static byte WakeUpTrainToHex(this Enums.WakeUpTrain duration)
        {
            //burası değişecek vakit kaybetmemek için böle ayarlandı.
            byte WakeUpTrainToHex = Byte.Parse("0x55".Substring(2), NumberStyles.HexNumber);


            switch (duration)
            {
                case Enums.WakeUpTrain.WithDepartureTest:
                    {
                        WakeUpTrainToHex = Byte.Parse("0xAA".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
                case Enums.WakeUpTrain.WithOutDepartureTest:
                    {
                        WakeUpTrainToHex = Byte.Parse("0xCC".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
                case Enums.WakeUpTrain.False:
                    {
                        WakeUpTrainToHex = Byte.Parse("0x55".Substring(2), NumberStyles.HexNumber);
                        break;
                    }

            }

            return WakeUpTrainToHex;

        }
    }
}
