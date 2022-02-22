using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    static class TrainCoupledExtensions
    {
        public static byte TrainCoupledToHex(this Enums.TrainCoupled duration)
        {
            //burası değişecek vakit kaybetmemek için böle ayarlandı.
            byte TrainCoupledToHex = Byte.Parse("0x00".Substring(2), NumberStyles.HexNumber);


            switch (duration)
            {
                case Enums.TrainCoupled.NotCoupled:
                    {
                        TrainCoupledToHex = Byte.Parse("0x00".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
                case Enums.TrainCoupled.MD1Coupled:
                    {
                        TrainCoupledToHex = Byte.Parse("0x01".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
                case Enums.TrainCoupled.MD2Coupled:
                    {
                        TrainCoupledToHex = Byte.Parse("0x02".Substring(2), NumberStyles.HexNumber);
                        break;
                    } 
                case Enums.TrainCoupled.MD1AndMD2Coupled:
                    {
                        TrainCoupledToHex = Byte.Parse("0x03".Substring(2), NumberStyles.HexNumber);
                        break;
                    }
            }  

            return TrainCoupledToHex;

        }
    }

   

  

    
    }
