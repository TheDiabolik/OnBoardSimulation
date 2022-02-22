using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    class UnitConversion
    {
        public static double KilometerHourToCentimeterSecond(double kilometerHour)
        {
            double centimeterSecond = kilometerHour * 100000 / 3600;

            return centimeterSecond;
        }

        public static int CentimeterSecondToKilometerHour(double centimeterSecond)
        {
            int kilometerHour = Convert.ToInt32(centimeterSecond * 3600 / 100000);

            return kilometerHour;
        }

    }
}
