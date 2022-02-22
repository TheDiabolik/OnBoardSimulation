using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnBoard 
{
    public partial class OBATP : IWSATP_TO_OBATPMessageWatcher, IATS_TO_OBATO_InitMessageWatcher, IATS_TO_OBATO_MessageWatcher, IATS, IWSATC, IDisposable
    {

        //waysidedan gelen haraket yetkisi tracklerini işleyen metot
        public void WSATP_TO_OBATPMessageInComing(Enums.Train_ID train_ID, WSATP_TO_OBATPAdapter WSATP_TO_OBATPAdapter)
        {
            lock (WSATP_TO_OBATPAdapter)//test için bu lock kodu açıldı
            {
                if (this.Vehicle.TrainID == train_ID)
                {

                   bool bakalım = WSATP_TO_OBATPAdapter.MovementAuthorityTracks.SequenceEqual(movementTrack); 

                    if (!bakalım)
                    { 
                        foreach (Track movementAuthorityTrack in WSATP_TO_OBATPAdapter.MovementAuthorityTracks)
                        { 
                            if ((!movementTrack.Contains(movementAuthorityTrack)))
                            { 

                                Track newMovementTrack = new Track();

                                newMovementTrack = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == movementAuthorityTrack.Track_ID);

                                double routeLength = movementTrack.Last().StopPositionInRoute;

                                movementAuthorityTrack.StartPositionInRoute = routeLength;
                                movementAuthorityTrack.StopPositionInRoute = routeLength + movementAuthorityTrack.Track_Length;

                                movementTrack.Add(movementAuthorityTrack); 

                            }

                        } 


                        int rearTrackIndex = this.movementTrack.FindIndex(x => x.Track_ID == this.ActualRearOfTrainCurrent.Track.Track_ID);

                        //if (rearTrackIndex > 0)
                            movementTrack.RemoveRange(0, rearTrackIndex);
 


                        if((movementTrack.Count > 1) && (!string.IsNullOrEmpty(movementTrack.First().Station_Name)) && (movementTrack.First().Station_Name == "YNK1" || 
                            movementTrack.First().Station_Name == "KRZ2" || movementTrack.First().Station_Name == "YNK2" || movementTrack.First().Station_Name == "HAV2"))
                        {
                            #region YNK1 - KRZ2

                            #region YNK1

                            if ((!string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name)) && (ActualFrontOfTrainCurrent.Track.Station_Name == "YNK1"))
                            {
                                Direction = Enums.Direction.Right;

                                if (ActualFrontOfTrainCurrent.Location != ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2)
                                    ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;

                                if (ActualRearOfTrainCurrent.Location != ActualFrontOfTrainCurrent.Location - 11200)
                                    ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - 11200;

                                Task<Track> taskSelect3 = MainForm.m_mf.m_databaseOperation.AsycSelectTrackFromYNK1_KIR2_YNK1(movementTrack.First().Track_ID, this.Direction);
                                Track newMovementTrack = taskSelect3.Result;

                                //movementTrack[0].StartPositionInRoute = newMovementTrack.StartPositionInRoute;
                                //movementTrack[0].StopPositionInRoute = newMovementTrack.StopPositionInRoute;
                            }

                            #endregion

                            #region KRZ2

                            if ((!string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name)) && (ActualFrontOfTrainCurrent.Track.Station_Name == "KRZ2"))
                            {
                                Direction = Enums.Direction.Left;

                                if (ActualFrontOfTrainCurrent.Location != ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1)
                                    ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1);//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;

                                if (ActualRearOfTrainCurrent.Location != ActualFrontOfTrainCurrent.Location + 11200)
                                    ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location + 11200;

                                Task<Track> taskSelect3 = MainForm.m_mf.m_databaseOperation.AsycSelectTrackFromYNK1_KIR2_YNK1(movementTrack.First().Track_ID, this.Direction);
                                Track newMovementTrack = taskSelect3.Result;

                                //movementTrack[0].StartPositionInRoute = newMovementTrack.StartPositionInRoute;
                                //movementTrack[0].StopPositionInRoute = newMovementTrack.StopPositionInRoute;

                            }
                            #endregion

                            #endregion


                            #region YNK2 - HAV2

                            #region YNK2

                            if ((!string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name)) && (ActualFrontOfTrainCurrent.Track.Station_Name == "YNK2"))
                            {
                                Direction = Enums.Direction.Right;

                                if (ActualFrontOfTrainCurrent.Location != ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2)
                                    ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;

                                if (ActualRearOfTrainCurrent.Location != ActualFrontOfTrainCurrent.Location - 11200)
                                    ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - 11200;

                                Task<Track> taskSelect3 = MainForm.m_mf.m_databaseOperation.AsycSelectTrackFromYNK2_HAV2_YNK2(movementTrack.First().Track_ID, this.Direction);
                                Track newMovementTrack = taskSelect3.Result;

                                //movementTrack[0].StartPositionInRoute = newMovementTrack.StartPositionInRoute;
                                //movementTrack[0].StopPositionInRoute = newMovementTrack.StopPositionInRoute;
                            }

                            #endregion

                            #region HAV2

                            if ((!string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name)) && (ActualFrontOfTrainCurrent.Track.Station_Name == "HAV2"))
                            {
                                Direction = Enums.Direction.Left;

                                if (ActualFrontOfTrainCurrent.Location != ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1)
                                    ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1);//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;

                                if (ActualRearOfTrainCurrent.Location != ActualFrontOfTrainCurrent.Location + 11200)
                                    ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location + 11200;

                                Task<Track> taskSelect3 = MainForm.m_mf.m_databaseOperation.AsycSelectTrackFromYNK2_HAV2_YNK2(movementTrack.First().Track_ID, this.Direction);
                                Track newMovementTrack = taskSelect3.Result;

                                //movementTrack[0].StartPositionInRoute = newMovementTrack.StartPositionInRoute;
                                //movementTrack[0].StopPositionInRoute = newMovementTrack.StopPositionInRoute;

                            }
                            #endregion

                            double lolo = 0;

                            foreach(Track movementTrack in movementTrack)
                            {
                                movementTrack.StartPositionInRoute = lolo;
                                movementTrack.StopPositionInRoute = lolo + movementTrack.Track_Length;

                                lolo = movementTrack.StopPositionInRoute;
                            }




                            #endregion



                            #region Depo Trackleri
                            if ((string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name)) && (ActualFrontOfTrainCurrent.Track.Track_ID >= 51011 && ActualFrontOfTrainCurrent.Track.Track_ID <= 51059))
                            {
                                Direction = Enums.Direction.Left;

                                if (ActualFrontOfTrainCurrent.Location != ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1)
                                    ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1);//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;

                                if (ActualRearOfTrainCurrent.Location != ActualFrontOfTrainCurrent.Location + 11200)
                                    ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location + 11200;

                                 Track newMovementTrack = movementTrack.First();

                                //movementTrack[0].StartPositionInRoute = newMovementTrack.StartPositionInRoute;
                                //movementTrack[0].StopPositionInRoute = newMovementTrack.StopPositionInRoute;

                            }


                            #endregion




                        }




                    }


               

                    //if (movementTrack.Count < 20)
                    //{
                    //    ThreadSafeList<Track> newMovementTracks = WSATP_TO_OBATPAdapter.MovementAuthorityTracks.Except(movementTrack);

                    //    for (int i = 0; i < newMovementTracks.Count; i++)
                    //    {
                    //        if ((!movementTrack.Contains(newMovementTracks[i])))
                    //        {
                    //            Track newMovementTrack = new Track();

                    //            newMovementTrack = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == newMovementTracks[i].Track_ID);

                    //            double routeLength = movementTrack.Last().StopPositionInRoute;

                    //            newMovementTracks[i].StartPositionInRoute = routeLength;
                    //            newMovementTracks[i].StopPositionInRoute = routeLength + newMovementTracks[i].Track_Length;

                    //            movementTrack.Add(newMovementTracks[i]);
                    //        }

                    //        //else if ((movementTrack.Contains(newMovementTracks[i])))
                    //        //    movementTrack.Add(newMovementTracks[i]);

                    //    }

                    //}



























                    ////if (movementTrack.Count < 20)
                    //{
                    //    ThreadSafeList<Track> newMovementTracks = WSATP_TO_OBATPAdapter.MovementAuthorityTracks.Except(movementTrack); 

                    //    for (int i = 0; i < newMovementTracks.Count; i++)
                    //    {
                    //        if ((!movementTrack.Contains(newMovementTracks[i])))
                    //        {
                    //            Track newMovementTrack = new Track();

                    //            newMovementTrack = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == newMovementTracks[i].Track_ID);

                    //            double routeLength = movementTrack.Last().StopPositionInRoute;

                    //            newMovementTracks[i].StartPositionInRoute = routeLength;
                    //            newMovementTracks[i].StopPositionInRoute = routeLength + newMovementTracks[i].Track_Length;

                    //            movementTrack.Add(newMovementTracks[i]);
                    //        }

                    //        //else if ((movementTrack.Contains(newMovementTracks[i])))
                    //        //    movementTrack.Add(newMovementTracks[i]);

                    //    }

                    //}

                }

            }
        }
    }
}
