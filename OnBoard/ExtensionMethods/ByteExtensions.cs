using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public static class ByteExtensions
    {
        public static bool ByteToBool(this byte value)
        {
            bool byteToBoolValue = false;

            if (value == 85)
                byteToBoolValue = false;
            else if(value == 170)
                byteToBoolValue = true;

            return byteToBoolValue;

        }
    }
}
