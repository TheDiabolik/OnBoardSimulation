using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OnBoard 
{
    public partial class OBATP : IWSATP_TO_OBATPMessageWatcher, IATS_TO_OBATO_InitMessageWatcher, IATS_TO_OBATO_MessageWatcher, IATS, IWSATC, IDisposable
    {

        public void ATS_TO_OBATO_InitMessageInComing(Enums.Train_ID train_ID, ATS_TO_OBATO_InitAdapter ATS_TO_OBATO_InitAdapter)
        {
            lock (ATS_TO_OBATO_InitAdapter)
            {
                if (this.Vehicle.TrainID == train_ID)
                {

                    if (this.Status != Enums.Status.Create)
                        return; 
 

                    bool isGetValue = MainForm.m_allOBATP.TryGetValue(Convert.ToInt32(train_ID), out OBATP OBATP);

                    if (isGetValue)
                    {
                        #region WSATC Hareket Yetkisi Testi İçin
                        Track track = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == ATS_TO_OBATO_InitAdapter.TrackSectionID);

                        //Track track = Route.FindTrackInRoute(ATS_TO_OBATO_InitAdapter.TrackSectionID);



                        Direction = ATS_TO_OBATO_InitAdapter.ATStoOBATO_TrainDirection;

                        if(track != null)
                        {
                            ActualFrontOfTrainCurrent.Track = track;
                            ActualRearOfTrainCurrent.Track = track;


                            if (Direction == Enums.Direction.Right)
                            {
                                ActualFrontOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2;
                                ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - this.Vehicle.TrainLength;
                            }
                            else
                            {
                                ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1)  ;
                                ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location + this.Vehicle.TrainLength;
                            }


                            //wayside ilk başlatmada konum bilgisi gönderme testi için
                            //FrontOfTrainTrackWithFootPrint.Track = ActualFrontOfTrainCurrent.Track;
                            //RearOfTrainTrackWithFootPrint.Track = ActualRearOfTrainCurrent.Track;

                            FrontOfTrainTrackWithFootPrint.Track = track;
                            RearOfTrainTrackWithFootPrint.Track = track;


                            //if (Direction == Enums.Direction.Right)
                            //{
                            //    FrontOfTrainTrackWithFootPrint.Location = ActualFrontOfTrainCurrent.Location + FrontOfTrainLocationFault;
                            //    RearOfTrainTrackWithFootPrint.Location = ActualFrontOfTrainCurrent.Location - RearOfTrainLocationFault;
                            //}
                            //else
                            //{
                            //    FrontOfTrainTrackWithFootPrint.Location = ActualFrontOfTrainCurrent.Location - FrontOfTrainLocationFault;
                            //    RearOfTrainTrackWithFootPrint.Location = ActualFrontOfTrainCurrent.Location + RearOfTrainLocationFault;
                            //}



                            DwellTime = ATS_TO_OBATO_InitAdapter.DwellTime;


                            //double routeLength = 0;

                            //track.StartPositionInRoute = routeLength;
                            //track.StopPositionInRoute = routeLength + track.Track_Length;

                            this.movementTrack.Add(track); 
                        } 


                        #endregion

                        #region WSATC hareket yetkisi testi için commentlendi normalde çalışan kod 

                        //Track track = MainForm.m_mf.m_YNK1_KIR2_YNK1.Find(x => x.Track_ID == ATS_TO_OBATO_InitAdapter.TrackSectionID);


                        ////if(this.Vehicle.TrainID == Enums.Train_ID.Train1)
                        //movementTrack = Route.CreateMovementTracksStationToStation(track.Track_ID, MainForm.m_mf.m_YNK1_KIR2_YNK1, MainForm.m_mf.m_YNK2_HAV2_YNK2, true);
                        ////if (this.Vehicle.TrainID == Enums.Train_ID.Train2)
                        ////    movementTrack = Route.CreateMovementTracksStationToStation(track.Track_ID, MainForm.m_mf.m_YNK1_KIR2_YNK1, MainForm.m_mf.m_YNK2_HAV2_YNK2, false);


                        //if ((!string.IsNullOrEmpty(movementTrack.First().Station_Name)) && (movementTrack.First().Station_Name == "KRZ2"))
                        //{
                        //    ActualFrontOfTrainCurrent.Track = movementTrack.First();
                        //    ActualRearOfTrainCurrent.Track = movementTrack.First();

                        //    ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1);
                        //    ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location + this.Vehicle.TrainLength;
                        //}
                        //else if ((!string.IsNullOrEmpty(movementTrack.First().Station_Name)) && (movementTrack.First().Station_Name == "YNK1"))
                        //{
                        //    ActualFrontOfTrainCurrent.Track = movementTrack.First();
                        //    ActualRearOfTrainCurrent.Track = movementTrack.First();

                        //    ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);
                        //    ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - this.Vehicle.TrainLength;
                        //}

                        //else if ((!string.IsNullOrEmpty(movementTrack.First().Station_Name)) && (movementTrack.First().Station_Name == "HVL2"))
                        //{
                        //    ActualFrontOfTrainCurrent.Track = movementTrack.First();
                        //    ActualRearOfTrainCurrent.Track = movementTrack.First();

                        //    ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);
                        //    ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - this.Vehicle.TrainLength;
                        //}
                        //else if ((!string.IsNullOrEmpty(movementTrack.First().Station_Name)) && (movementTrack.First().Station_Name == "YNK2"))
                        //{
                        //    ActualFrontOfTrainCurrent.Track = movementTrack.First();
                        //    ActualRearOfTrainCurrent.Track = movementTrack.First();

                        //    ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);
                        //    ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - this.Vehicle.TrainLength;
                        //}
                        //else
                        //{
                        //    SetStart(track.Track_ID, true);

                        //}


                        #endregion






                        this.Speed = Vehicle.CurrentTrainSpeedKMH.ToString();
                        this.Front_Track_ID = ActualFrontOfTrainCurrent.Track.Track_ID.ToString();
                        this.Front_Track_Location = ActualFrontOfTrainCurrent.Location.ToString("0.##");
                        this.Front_Track_Length = ActualFrontOfTrainCurrent.Track.Track_Length.ToString();
                        this.Front_Track_Max_Speed = ActualFrontOfTrainCurrent.Track.MaxTrackSpeedKMH.ToString();
                        this.Rear_Track_ID = ActualRearOfTrainCurrent.Track.Track_ID.ToString();
                        this.Rear_Track_Location = ActualRearOfTrainCurrent.Location.ToString("0.##");
                        this.Rear_Track_Length = ActualRearOfTrainCurrent.Track.Track_Length.ToString();
                        this.Rear_Track_Max_Speed = ActualRearOfTrainCurrent.Track.MaxTrackSpeedKMH.ToString();
                        this.Total_Route_Distance = TotalTrainDistance.ToString("0.##");

                        MainForm.m_mf.m_allTrains.Add(OBATP);


                        //belki WSATC ye mesaj ilk mesajı gönderme kısmı değiştirilebilir.
                        //MainForm.m_trainObserver.TrainMovementSendMessageCreated(this);



                   


                        OBATP.RequestStartProcess();

                        //MainForm.m_trainObserver.TrainMovementSendMessageCreated(this);

                      
                    }



                }
            }


        }





        //public void ATS_TO_OBATO_InitMessageInComing(Enums.Train_ID train_ID, ATS_TO_OBATO_InitAdapter ATS_TO_OBATO_InitAdapter)
        //{
        //    //lock(ATS_TO_OBATO_InitAdapter)
        //    //{
        //    //    if (this.Vehicle.TrainID == train_ID)
        //    //    {

        //    //        if (this.Status != Enums.Status.Create)
        //    //            return;




        //    //        Debug.WriteLine(train_ID.ToString() + " created");



        //    //        bool isGetValue = MainForm.m_allOBATP.TryGetValue(Convert.ToInt32(train_ID), out OBATP OBATP);

        //    //        if (isGetValue)
        //    //        {

        //    //            Track track = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == ATS_TO_OBATO_InitAdapter.TrackSectionID); 
        //    //            //Route route = new Route();
        //    //            //route = Route.CreateNewRoute(track.Track_ID, 10311, MainForm.m_mf.m_allTracks);

        //    //            //List<Route> ahmet = Route.SimulationRoute(MainForm.m_simulationRouteTracks);
        //    //            //Route newRoute = Route.CreateNewRoute(ATS_TO_OBATO_InitAdapter.TrackSectionID, ahmet);

        //    //            Route newRoute;

        //    //            if(ATS_TO_OBATO_InitAdapter.ATStoOBATO_TrainDirection == Enums.Direction.Left)
        //    //            {
        //    //                newRoute = Route.CreateNewRoute(ATS_TO_OBATO_InitAdapter.TrackSectionID, MainForm.m_mf.m_ToYenikapıTracks);

        //    //                OBATP.m_route = newRoute;

        //    //                OBATP.ActualFrontOfTrainCurrent.Track = OBATP.m_route.Entry_Track; ;// startTrack;
        //    //                OBATP.ActualRearOfTrainCurrent.Track = OBATP.m_route.Entry_Track; ;// startTrack;startTrack; 

        //    //                OBATP.ActualFrontOfTrainCurrent.Location = (OBATP.ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1);//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;
        //    //                OBATP.ActualRearOfTrainCurrent.Location = OBATP.ActualFrontOfTrainCurrent.Location + OBATP.Vehicle.TrainLength;
        //    //            }

        //    //            else
        //    //            {
        //    //                newRoute = Route.CreateNewRoute(ATS_TO_OBATO_InitAdapter.TrackSectionID, MainForm.m_mf.m_FromYenikapıTracks);

        //    //                OBATP.m_route = newRoute;

        //    //                OBATP.ActualFrontOfTrainCurrent.Track = OBATP.m_route.Entry_Track; ;// startTrack;
        //    //                OBATP.ActualRearOfTrainCurrent.Track = OBATP.m_route.Entry_Track; ;// startTrack;startTrack; 

        //    //                OBATP.ActualFrontOfTrainCurrent.Location = (OBATP.ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;
        //    //                OBATP.ActualRearOfTrainCurrent.Location = OBATP.ActualFrontOfTrainCurrent.Location - OBATP.Vehicle.TrainLength;
        //    //            }









        //    //            this.Speed = Vehicle.CurrentTrainSpeedKMH.ToString();
        //    //            this.Front_Track_ID = ActualFrontOfTrainCurrent.Track.Track_ID.ToString();
        //    //            this.Front_Track_Location = ActualFrontOfTrainCurrent.Location.ToString("0.##");
        //    //            this.Front_Track_Length = ActualFrontOfTrainCurrent.Track.Track_Length.ToString();
        //    //            this.Front_Track_Max_Speed = ActualFrontOfTrainCurrent.Track.MaxTrackSpeedKMH.ToString();
        //    //            this.Rear_Track_ID = ActualRearOfTrainCurrent.Track.Track_ID.ToString();
        //    //            this.Rear_Track_Location = ActualRearOfTrainCurrent.Location.ToString("0.##");
        //    //            this.Rear_Track_Length = ActualRearOfTrainCurrent.Track.Track_Length.ToString();
        //    //            this.Rear_Track_Max_Speed = ActualRearOfTrainCurrent.Track.MaxTrackSpeedKMH.ToString();
        //    //            this.Total_Route_Distance = TotalTrainDistance.ToString("0.##");

        //    //            MainForm.m_mf.m_allTrains.Add(OBATP);
        //    //            //MainForm.m_mf.m_bindingSourceTrains.ResetBindings(false);

        //    //            OBATP.RequestStartProcess();
        //    //        }



        //    //    }
        //    //}


        //}
    }
}
