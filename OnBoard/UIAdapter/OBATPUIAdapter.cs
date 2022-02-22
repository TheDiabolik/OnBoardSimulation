using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    class OBATPUIAdapter : UIOBATP
    {
        private static OBATPUIAdapter m_OBATPUIAdapter = new OBATPUIAdapter();

        private OBATPUIAdaptee _adaptee;


        public OBATPUIAdapter()
        {
            

             
        }


        #region singleton
        public static OBATPUIAdapter Singleton()
        {
            return m_OBATPUIAdapter;
        }
        #endregion


        public OBATPUIAdapter(OBATP OBATPToAdapt)
        {
            _adaptee = new OBATPUIAdaptee(OBATPToAdapt);


            AdaptData();
        }


        public void AdaptData()
        {
            base.ID = _adaptee.ID;
            base.Train_Name = _adaptee.Train_Name;
            base.Speed = _adaptee.Speed;
            base.Front_Track_ID = _adaptee.Front_Track_ID;
            base.Front_Track_Location = _adaptee.Front_Track_Location;
            base.Front_Track_Length = _adaptee.Front_Track_Length;
            base.Front_Track_Max_Speed = _adaptee.Front_Track_Max_Speed;
            base.Rear_Track_ID = _adaptee.Rear_Track_ID;
            base.Rear_Track_Location = _adaptee.Rear_Track_Location;
            base.Rear_Track_Length = _adaptee.Rear_Track_Length;
            base.Rear_Track_Max_Speed = _adaptee.Rear_Track_Max_Speed;
            base.Total_Route_Distance = _adaptee.Total_Route_Distance;

            base.TrainOnTracks = _adaptee.TrainOnTracks;
        }



        public  void AdaptData1(OBATP OBATP)
        {
            base.ID = OBATP.Vehicle.TrainIndex.ToString();
            base.Train_Name = OBATP.Vehicle.TrainName;
            base.Speed = OBATP.Vehicle.CurrentTrainSpeedKMH.ToString();
            base.Front_Track_ID = OBATP.ActualFrontOfTrainCurrent.Track.Track_ID.ToString();
            base.Front_Track_Location = OBATP.ActualFrontOfTrainCurrent.Location.ToString("0.##");
            base.Front_Track_Length = OBATP.ActualFrontOfTrainCurrent.Track.Track_Length.ToString();
            base.Front_Track_Max_Speed = OBATP.ActualFrontOfTrainCurrent.Track.MaxTrackSpeedKMH.ToString();
            base.Rear_Track_ID = OBATP.ActualRearOfTrainCurrent.Track.Track_ID.ToString();
            base.Rear_Track_Location = OBATP.ActualRearOfTrainCurrent.Location.ToString("0.##");
            base.Rear_Track_Length = OBATP.ActualRearOfTrainCurrent.Track.Track_Length.ToString();
            base.Rear_Track_Max_Speed = OBATP.ActualRearOfTrainCurrent.Track.MaxTrackSpeedKMH.ToString();
            base.Total_Route_Distance = OBATP.TotalTrainDistance.ToString("0.##");
        }

    }
}
