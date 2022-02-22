using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    static class TrainLeftDoorOpenedExtensions
    {
        public static byte TrainLeftDoorOpenedToHex(this Enums.DoorStatus doorStatus)
        {
            //burası değişecek vakit kaybetmemek için böle ayarlandı.
            byte TrainCoupledToHex = Byte.Parse("0x00".Substring(2), NumberStyles.HexNumber);

            switch (doorStatus)
            {
                case Enums.DoorStatus.Open:
                    {
                        TrainCoupledToHex = Byte.Parse("0xAA".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
                case Enums.DoorStatus.Close:
                    {
                        TrainCoupledToHex = Byte.Parse("0x55".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
            }

            return TrainCoupledToHex;

        }
    }
}
