using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    interface IMessage
    {
        UInt32 DS { get; set; }
        UInt32 Size { get; set; }
        UInt32 ID { get; set; }
        UInt32 DST { get; set; }
        UInt32 SRC { get; set; }
        ulong RTC { get; set; }
        UInt32 NO { get; set; }
        byte[] DATA { get; set; }
        UInt64 CRC { get; set; }
    }
}
