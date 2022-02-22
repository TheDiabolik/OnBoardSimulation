using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    static class ActiveATPExtensions
    {
        public static byte ActiveATPToHex(this Enums.ActiveATP duration)
        {
            //burası değişecek vakit kaybetmemek için böle ayarlandı.
            byte ActiveATPToHex = Byte.Parse("0x01".Substring(2), NumberStyles.HexNumber);


            switch (duration)
            {
                case Enums.ActiveATP.First:
                    {
                        ActiveATPToHex = Byte.Parse("0x01".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
                case Enums.ActiveATP.Second:
                    {
                        ActiveATPToHex = Byte.Parse("0x02".Substring(2), NumberStyles.HexNumber);
                        break;
                    }

            }

            return ActiveATPToHex;

        }
    }
}
