using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public static class BoolExtensions
    {
        public static byte BoolToHex(this bool value)
        {
            byte boolToHexValue;

            if (value)
                boolToHexValue = Byte.Parse("0xAA".Substring(2), NumberStyles.HexNumber);
            else
                boolToHexValue = Byte.Parse("0x55".Substring(2), NumberStyles.HexNumber);

            return boolToHexValue;

        }
    }
}
