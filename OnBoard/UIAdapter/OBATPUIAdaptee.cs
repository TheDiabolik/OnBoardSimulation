using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    class OBATPUIAdaptee
    {
        //general
        public string ID { get; set; }
        public string Train_Name { get; set; }
        public string Speed { get; set; }
        //front
        public string Front_Track_ID { get; set; }
        public string Front_Track_Location { get; set; }
        public string Front_Track_Length { get; set; }
        public string Front_Track_Max_Speed { get; set; }
        //rear
        public string Rear_Track_ID { get; set; }
        public string Rear_Track_Location { get; set; }
        public string Rear_Track_Length { get; set; }
        public string Rear_Track_Max_Speed { get; set; }

        //general
        public string Total_Route_Distance { get; set; }


        [Browsable(false)]
        public TrainOnTracks TrainOnTracks = new TrainOnTracks();
        [Browsable(false)]
        public ushort[] footPrintTracks = new ushort[15];
        [Browsable(false)]
        public ushort[] virtualOccupationTracks = new ushort[20];

        public OBATPUIAdaptee(OBATP OBATP)
        {

            this.ID = OBATP.Vehicle.TrainIndex.ToString();
            this.Train_Name = OBATP.Vehicle.TrainName;
            this.Speed = OBATP.Vehicle.CurrentTrainSpeedKMH.ToString();
            this.Front_Track_ID = OBATP.ActualFrontOfTrainCurrent.Track.Track_ID.ToString();
            this.Front_Track_Location = OBATP.ActualFrontOfTrainCurrent.Location.ToString("0.##");
            this.Front_Track_Length = OBATP.ActualFrontOfTrainCurrent.Track.Track_Length.ToString();
            this.Front_Track_Max_Speed = OBATP.ActualFrontOfTrainCurrent.Track.MaxTrackSpeedKMH.ToString();
            this.Rear_Track_ID = OBATP.ActualRearOfTrainCurrent.Track.Track_ID.ToString();
            this.Rear_Track_Location = OBATP.ActualRearOfTrainCurrent.Location.ToString("0.##");
            this.Rear_Track_Length = OBATP.ActualRearOfTrainCurrent.Track.Track_Length.ToString();
            this.Rear_Track_Max_Speed = OBATP.ActualRearOfTrainCurrent.Track.MaxTrackSpeedKMH.ToString();
            this.Total_Route_Distance = OBATP.TotalTrainDistance.ToString("0.##");



            

              //footPrintTracks = HelperClass.FindTrackRangeInAllTracks(OBATP.FrontOfTrainTrackWithFootPrint.Track, OBATP.RearOfTrainTrackWithFootPrint.Track, MainForm.m_mf.m_allTracks);
              //virtualOccupationTracks = HelperClass.FindTrackRangeInAllTracks(OBATP.FrontOfTrainVirtualOccupation.Track, OBATP.RearOfTrainVirtualOccupation.Track, MainForm.m_mf.m_allTracks);
              //ushort[] actual = HelperClass.FindTrackRangeInAllTracks(OBATP.ActualFrontOfTrainCurrent.Track, OBATP.ActualRearOfTrainCurrent.Track, MainForm.m_mf.m_allTracks);

              //  footPrintTracks = HelperClass.FindTrackRangeInAllTracks(OBATP.FrontOfTrainTrackWithFootPrint.Track, OBATP.RearOfTrainTrackWithFootPrint.Track, OBATP.m_route.Route_Tracks);
              //virtualOccupationTracks = HelperClass.FindTrackRangeInAllTracks(OBATP.FrontOfTrainVirtualOccupation.Track, OBATP.RearOfTrainVirtualOccupation.Track, OBATP.m_route.Route_Tracks);
              //ushort[] actual = HelperClass.FindTrackRangeInAllTracks(OBATP.ActualFrontOfTrainCurrent.Track, OBATP.ActualRearOfTrainCurrent.Track, OBATP.m_route.Route_Tracks);

              footPrintTracks = HelperClass.FindTrackRangeInAllTracks(OBATP.FrontOfTrainTrackWithFootPrint.Track, OBATP.RearOfTrainTrackWithFootPrint.Track, OBATP.movementTrack);
            virtualOccupationTracks = HelperClass.FindTrackRangeInAllTracks(OBATP.FrontOfTrainVirtualOccupation.Track, OBATP.RearOfTrainVirtualOccupation.Track, OBATP.movementTrack);
            ushort[] actual = HelperClass.FindTrackRangeInAllTracks(OBATP.ActualFrontOfTrainCurrent.Track, OBATP.ActualRearOfTrainCurrent.Track, OBATP.movementTrack);

            //arayüzde göstermek için liste
            //TrainOnTracks.VirtualOccupationTracks.Clear();
            //TrainOnTracks.FootPrintTracks.Clear();
            //TrainOnTracks.ActualLocationTracks.Clear();






            foreach (ushort item in footPrintTracks)
                TrainOnTracks.FootPrintTracks.Add(MainForm.m_mf.m_tracks.Find(x => x.Track_ID == item));

            foreach (ushort item in virtualOccupationTracks)
                TrainOnTracks.VirtualOccupationTracks.Add(MainForm.m_mf.m_tracks.Find(x => x.Track_ID == item));

            foreach (ushort item in actual)
                TrainOnTracks.ActualLocationTracks.Add(MainForm.m_mf.m_tracks.Find(x => x.Track_ID == item));












            //foreach (ushort item in footPrintTracks)
            //    TrainOnTracks.FootPrintTracks.Add(MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == item));

            //foreach (ushort item in virtualOccupationTracks)
            //    TrainOnTracks.VirtualOccupationTracks.Add(MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == item));

            //foreach (ushort item in actual)
            //    TrainOnTracks.ActualLocationTracks.Add(MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == item));



            var sfsef = TrainOnTracks.FootPrintTracks;

            //foreach (ushort item in footPrintTracks)
            //    TrainOnTracks.FootPrintTracks.Add(MainForm.m_allTracks.Find(x => x.Track_ID == item));

            //foreach (ushort item in virtualOccupationTracks)
            //    TrainOnTracks.VirtualOccupationTracks.Add(MainForm.m_allTracks.Find(x => x.Track_ID == item));

            //foreach (ushort item in actual)
            //    TrainOnTracks.ActualLocationTracks.Add(MainForm.m_allTracks.Find(x => x.Track_ID == item)); 

         }
    }
}
