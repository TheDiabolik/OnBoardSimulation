using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    static class TrainDirectionExtensions
    {
        public static byte TrainDirectionToHex(this Enums.TrainDirection duration)
        {
            //burası değişecek vakit kaybetmemek için böle ayarlandı.
            byte TrainCoupledToHex = Byte.Parse("0x00".Substring(2), NumberStyles.HexNumber); 

            switch (duration)
            {
                case Enums.TrainDirection.ToYenikapı:
                    {
                        TrainCoupledToHex = Byte.Parse("0xAA".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
                case Enums.TrainDirection.FromYenikapı:
                    {
                        TrainCoupledToHex = Byte.Parse("0x55".Substring(2), NumberStyles.HexNumber);
                        break;
                    } 
            }

            return TrainCoupledToHex;

        }
    }
}
