using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    static class ActiveCabExtensions
    {
        public static byte ActiveCabToHex(this Enums.ActiveCab duration)
        {
            //burası değişecek vakit kaybetmemek için böle ayarlandı.
            byte ActiveCabToHex = Byte.Parse("0x01".Substring(2), NumberStyles.HexNumber);


            switch (duration)
            {
                case Enums.ActiveCab.MD1Active:
                    {
                        ActiveCabToHex = Byte.Parse("0x01".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
                case Enums.ActiveCab.MD2Active:
                    {
                        ActiveCabToHex = Byte.Parse("0x02".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
                case Enums.ActiveCab.NotActive:
                    {
                        ActiveCabToHex = Byte.Parse("0x03".Substring(2), NumberStyles.HexNumber);
                        break;
                    }

            }

            return ActiveCabToHex;

        }

    }
}
