using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    interface IVehicle
    {
        int TrainIndex { get; set; }

        /// <summary>
        /// Tren uzunluğu (cm)
        /// </summary>
        double TrainLength { get; set; }


        /// <summary>
        /// True ise tren kapıları açık olduğunu belirtir. Hangi tarafın açık olduğunu belirtmez, bu versiyon için geçici olarak kullanılmaktadır.
        /// </summary>
        bool IsDoorOpened { get; set; }

        /// <summary>
        /// Tren kapısının kapanması için zaman sayar.
        /// </summary>
        int DoorTimerCounter { get; set; }

        /// <summary>
        /// Trenin bir önceki döngüde hesaplanan hız bilgisi (cm/s)
        /// </summary>
        double PreviousSpeedCMS { get; set; }

        /// <summary>
        /// Trenin o an ulaşması gereken hız bilgisidir. (cm/s)
        /// </summary>
        double TargetSpeedCMS { get; set; }
        /// <summary>
        /// Trenin o an ulaşması gereken hız bilgisidir. (km/h)
        /// </summary>
        double TargetSpeedKMH { get; set; }
        /// <summary>
        /// Trenin anlık durabileceği mesafe bilgisi (cm)
        /// </summary>
        double BrakingDistance { get; set; }

        /// <summary>
        /// Trenin anlık hız değeri (km/h)
        /// </summary>
        double CurrentTrainSpeedKMH { get; set; }

        int MaxTrainSpeedKMH { get; set; }
        /// <summary>
        /// Trenin uyguladığı anlık ivme değeri (cm/s²)
        /// </summary>
        double CurrentAcceleration { get; set; }
        /// <summary>
        /// Trenin maksimum uygulayabileceği pozitif yönde ivme değeri (cm/s²)
        /// </summary>
        double MaxTrainAcceleration { get; set; }
        /// <summary>
        /// Trenin maksimum uygulayabileceği negatif yönde ivme değeri (cm/s²)
        /// </summary>
        double MaxTrainDeceleration { get; set; }
    }
}
