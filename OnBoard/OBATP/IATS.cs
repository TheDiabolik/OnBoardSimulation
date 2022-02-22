using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    interface IATS
    {
        int DwellTime { get; set; }
        bool SkipStation { get; set; }
        bool HoldStation { get; set; }



    }
}
