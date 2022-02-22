using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    [Serializable]
    public struct Vehicle : IVehicle
    {

        //[DisplayName("First Name")]
        public int TrainIndex { get; set; }

        public Enums.Train_ID TrainID { get; set; }

        //public Enums.OBATP_ID OBATP_ID { get; set; }

        //public Enums.OBATO_ID OBATO_ID { get; set; }



        //[DisplayName("First Name"), Description("Emp Last Name")]
        public string TrainName { get; set; }

        /// <summary>
        /// Tren uzunluğu (cm)
        /// </summary>
        public double TrainLength { get; set; }


        /// <summary>
        /// True ise tren kapıları açık olduğunu belirtir. Hangi tarafın açık olduğunu belirtmez, bu versiyon için geçici olarak kullanılmaktadır.
        /// </summary>
        public bool IsDoorOpened { get; set; }

        /// <summary>
        /// Tren kapısının kapanması için zaman sayar.
        /// </summary>
        public int DoorTimerCounter { get; set; }

        /// <summary>
        /// Trenin bir önceki döngüde hesaplanan hız bilgisi (cm/s)
        /// </summary>
        public double PreviousSpeedCMS { get; set; }

        /// <summary>
        /// Trenin o an ulaşması gereken hız bilgisidir. (cm/s)
        /// </summary>
        //public double TargetSpeed { get; set; }

        private double targetSpeedCMS;
        public double TargetSpeedCMS
        {
            get { return targetSpeedCMS; }

            set
            {
                if (value != targetSpeedCMS)
                {
                    targetSpeedCMS = value;
                    TargetSpeedKMH = UnitConversion.CentimeterSecondToKilometerHour(targetSpeedCMS);
                }
            }
        }





        /// <summary>
        /// Trenin o an ulaşması gereken hız bilgisidir. (km/h)
        /// </summary>
        //public double TargetSpeedKM { get; set; }

        private double targetSpeedKMH;  
        public double TargetSpeedKMH
        {
            get { return targetSpeedKMH; }

            set
            {
                if (value != targetSpeedKMH)
                {
                    targetSpeedKMH = value; 
                    TargetSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(targetSpeedKMH); 
                }
            }

        }

        /// <summary>
        /// Trenin anlık durabileceği mesafe bilgisi (cm)
        /// </summary>
        public double BrakingDistance { get; set; }

        /// <summary>
        /// Trenin anlık hız değeri (km/h)
        /// </summary>
        //public int CurrentTrainSpeedKM { get; set; }
        private double currentTrainSpeedKM;
        public double CurrentTrainSpeedKMH
        {
            get { return currentTrainSpeedKM; }

            set
            {
                if (value != currentTrainSpeedKM)
                {
                    currentTrainSpeedKM = value;

                    //if (currentTrainSpeedKM > TargetSpeedKMH)
                    //    currentTrainSpeedKM = TargetSpeedKMH;



                    CurrentTrainSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(currentTrainSpeedKM);
                }
            }

        }

        /// <summary>
        /// Trenin anlık hız değeri (cm/s)
        /// </summary>
        private double currentTrainSpeedCMS;
        public double CurrentTrainSpeedCMS
        {
            get { return currentTrainSpeedCMS; }

            set
            {
                if (value != currentTrainSpeedCMS)
                {
                    currentTrainSpeedCMS = value;

                    //double maxTrainSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(MaxTrainSpeedKMH);


                    //if (currentTrainSpeedCMS > TargetSpeedCMS)
                    //    currentTrainSpeedCMS = TargetSpeedCMS;

                    CurrentTrainSpeedKMH = UnitConversion.CentimeterSecondToKilometerHour(currentTrainSpeedCMS);

                    

                }
            }

        }


    





        public int MaxTrainSpeedKMH { get; set; }
        /// <summary>
        /// Trenin uyguladığı anlık ivme değeri (cm/s²)
        /// </summary>
        public double CurrentAcceleration { get; set; }
        /// <summary>
        /// Trenin maksimum uygulayabileceği pozitif yönde ivme değeri (cm/s²)
        /// </summary>
        public double MaxTrainAcceleration { get; set; }
        /// <summary>
        /// Trenin maksimum uygulayabileceği negatif yönde ivme değeri (cm/s²)
        /// </summary>
        public double MaxTrainDeceleration { get; set; }
    }
}
