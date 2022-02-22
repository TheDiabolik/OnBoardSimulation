using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnBoard
{
    public class TrainObserver : ITrainObserver
    {

        private ThreadSafeList<ITrainCreatedWatcher> m_trainCreatedWatcher = new ThreadSafeList<ITrainCreatedWatcher>();
        private ThreadSafeList<ITrainMovementCreatedSendMessageWatcher> m_trainMovementCreatedWatcher = new ThreadSafeList<ITrainMovementCreatedSendMessageWatcher>();
        private ThreadSafeList<ITrainMovementRouteCreatedWatcher> m_trainMovementRouteCreatedWatcher = new ThreadSafeList<ITrainMovementRouteCreatedWatcher>();
        private ThreadSafeList<ITrainMovementUIWatcher> m_trainMovementUIWatcher = new ThreadSafeList<ITrainMovementUIWatcher>();
        private ThreadSafeList<ITrainNewMovementAuthorityCreatedWatcher> m_trainNewMovementAuthorityCreatedWatcher = new ThreadSafeList<ITrainNewMovementAuthorityCreatedWatcher>();

        private ThreadSafeList<ITrainDetailsWindowWatcher> m_trainDetailsWindowWatcher = new ThreadSafeList<ITrainDetailsWindowWatcher>();

        private OBATP m_OBATPSendMessage;
        private OBATP m_OBATP;

        private OBATP m_OBATPDetail;
        private OBATP m_OBATPUIRefresh;
        //private OBATP m_OBATP;




        private UIOBATP m_UIOBATP;
        private Route m_route;
        private ThreadSafeList<Track> m_newMovementAuthorityList;


        private readonly object m_lockOBATP = new object();


        public void InformTrainDetailsWindowWatcher()
        {
            foreach (ITrainDetailsWindowWatcher watcher in m_trainDetailsWindowWatcher)
            {
                watcher.TrainDetailsWindowCreated(m_OBATPDetail);
            }
        }




        public void InformTrainCreatedWatcher()
        {
            foreach (ITrainCreatedWatcher watcher in m_trainCreatedWatcher)
            {
                watcher.TrainCreated(m_OBATPSendMessage); 
            } 
        }

        public void InformTrainMovementCreatedSendMessageWatcher()
        {
            foreach (ITrainMovementCreatedSendMessageWatcher watcher in m_trainMovementCreatedWatcher)
            {
                watcher.TrainMovementCreatedSendMessage(m_OBATPSendMessage);
            }
        }

        public void InformTrainMovementRouteCreatedWatcher()
        {
            foreach (ITrainMovementRouteCreatedWatcher watcher in m_trainMovementRouteCreatedWatcher)
            {
                watcher.TrainMovementRouteCreated(m_route);
            }
        }


        public void InformTrainNewMovementAuthorityCreatedWatcher()
        {
            foreach (ITrainNewMovementAuthorityCreatedWatcher watcher in m_trainNewMovementAuthorityCreatedWatcher)
            {
                watcher.TrainNewMovementAuthorityCreated(m_newMovementAuthorityList, m_UIOBATP);
            }
        }


        public void InformTrainMovementUIAllTrainListWatcher()
        {
            foreach (ITrainMovementUIWatcher watcher in m_trainMovementUIWatcher)
            {
                watcher.TrainMovementUIRefreshAllTrainList(m_OBATP);
            }
        }


        public void InformTrainMovementUITracksListWatcher()
        {
            foreach (ITrainMovementUIWatcher watcher in m_trainMovementUIWatcher)
            {
                watcher.TrainMovementUIRefreshTracksList(m_OBATPUIRefresh, m_UIOBATP);
            }
        }

        public void DisposeTrainCreated(OBATP OBATP)
        {
            //this.m_OBATP = OBATP;
            //InformTrainCreatedWatcher();

            MovementTracks.Clear();
        }

        public void TrainDetailsWindowPropertiesChanged(OBATP OBATP)
        {
            //lock (m_lockOBATP)
            //lock (OBATP)
            {
                if (MainForm.m_mf.m_doubleClickTrainID != 0 && OBATP.Vehicle.TrainIndex == MainForm.m_mf.m_doubleClickTrainID)
                {
                    this.m_OBATPDetail = OBATP;

                    InformTrainDetailsWindowWatcher();
                }
            }
            

        
        }




        public void TrainCreated(OBATP OBATP)
        {
            //lock (m_lockOBATP)
            {
                this.m_OBATPSendMessage = OBATP;
                InformTrainCreatedWatcher();
            }
        }
        public void TrainMovementSendMessageCreated(OBATP OBATP)
        {
            //lock (m_lockOBATP)
            {
                this.m_OBATPSendMessage = OBATP;
                InformTrainMovementCreatedSendMessageWatcher();
            }
          
        }

        public void TrainMovementRouteCreated(Route route)
        {
            this.m_route = route;
            InformTrainMovementRouteCreatedWatcher();
        }

        
        public void TrainNewMovementAuthorityCreated(ThreadSafeList<Track> newMovementAuthorityList, UIOBATP UIOBATP)
        {
           

            if (DisplayManager.ComboBoxGetSelectedItemInvoke(MainForm.m_mf.m_comboBoxTrain) != null && UIOBATP.Train_Name == DisplayManager.ComboBoxGetSelectedItemInvoke(MainForm.m_mf.m_comboBoxTrain).ToString())
            {

                this.m_newMovementAuthorityList = newMovementAuthorityList;

                InformTrainNewMovementAuthorityCreatedWatcher();
            }
        }

        public void TrainMovementUIRefreshAllTrainList(OBATP OBATP)
        {
            //lock (m_lockOBATP)
            {

                this.m_OBATP = OBATP;
                //this.m_OBATPUIRefresh = OBATP;
                InformTrainMovementUIAllTrainListWatcher();
            }
        } 





            TrainOnTracks sdf = new TrainOnTracks();

        bool zozo;
       
        public ThreadSafeList<Track> MovementTracks = new ThreadSafeList<Track>();
        public void TrainMovementUIRefreshTracksList(OBATP OBATP, UIOBATP UIOBATP)
        {
            //lock (m_lockOBATP)
            { 

                if (DisplayManager.ComboBoxGetSelectedItemInvoke(MainForm.m_mf.m_comboBoxTrain) != null && OBATP.Train_Name == DisplayManager.ComboBoxGetSelectedItemInvoke(MainForm.m_mf.m_comboBoxTrain).ToString())
                {
                    OBATP localOBATP = OBATP;


                    using (UIOBATP adapter = new OBATPUIAdapter(localOBATP))
                    {
                        bool isSameActualLocationTracks = sdf.ActualLocationTracks.SequenceEqual(adapter.TrainOnTracks.ActualLocationTracks);
                        bool isSameVirtualOccupationTracks = sdf.VirtualOccupationTracks.SequenceEqual(adapter.TrainOnTracks.VirtualOccupationTracks);
                        bool isSameFootPrintTracks = sdf.FootPrintTracks.SequenceEqual(adapter.TrainOnTracks.FootPrintTracks);
                        //bool isSameRoute_Tracks = RouteTracks.SequenceEqual(OBATP.m_route.Route_Tracks);
                        bool isSameRoute_Tracks = MovementTracks.SequenceEqual(localOBATP.movementTrack);

                        //bool isSameMovement_Tracks = MovementTracks.SequenceEqual(OBATP.movementTrack);


                        if (isSameActualLocationTracks)
                        {
                            adapter.RefreshActualLocationTracks = false;
                        }
                        else
                        {
                            sdf.ActualLocationTracks = adapter.TrainOnTracks.ActualLocationTracks;
                            adapter.RefreshActualLocationTracks = true;
                        }


                        if (isSameVirtualOccupationTracks)
                        {
                            adapter.RefreshVirtualOccupationTracks = false;
                        }
                        else
                        {
                            sdf.VirtualOccupationTracks = adapter.TrainOnTracks.VirtualOccupationTracks;
                            adapter.RefreshVirtualOccupationTracks = true;
                        }


                        if (isSameFootPrintTracks)
                        {
                            adapter.RefreshFootPrintTracks = false;
                        }
                        else
                        {
                            sdf.FootPrintTracks = adapter.TrainOnTracks.FootPrintTracks;
                            adapter.RefreshFootPrintTracks = true;
                        }


                        #region Manuel Hareket Yetkisi ile Test edilmek istendiğinde bu kısım kullanılır
                        //if (isSameRoute_Tracks)
                        //{
                        //    adapter.RefreshRouteTracks = false;
                        //}
                        //else
                        //{ 
                        //    MovementTracks = OBATP.movementTrack;
                        //    adapter.RefreshRouteTracks = true;
                        //}
                        #endregion

                        #region WSATC - ATS Haberleşmeli Test Yapılacağı Zaman

                        //if(MovementTracks.Count > 0)
                        {

                            if (isSameRoute_Tracks)
                            {
                                adapter.RefreshRouteTracks = false;
                            }
                            else
                            {

                                adapter.NewMovementAuthorityTracksCome = false;

                                //RouteTracks = OBATP.m_route.Route_Tracks;
                                //MovementTracks = OBATP.movementTrack;
                                List<Track> ahmet = localOBATP.movementTrack.Except(MovementTracks).ToList();


                                if ((MovementTracks.Count == 0) && (ahmet.Count > 0))
                                {
                                    MovementTracks.AddRange(ahmet);
                                    //MovementTracks = OBATP.movementTrack;
                                    adapter.RefreshRouteTracks = true;
                                }
                                else if (ahmet.Count > 0)
                                {
                                    MovementTracks.AddRange(ahmet);

                                    ThreadSafeList<Track> NewMovementAuthorityTracks = new ThreadSafeList<Track>();
                                    NewMovementAuthorityTracks.AddRange(ahmet);


                                    adapter.NewMovementAuthorityTracksCome = true;

                                    adapter.NewMovementAuthorityTracks = NewMovementAuthorityTracks;

                                    adapter.RefreshRouteTracks = false;
                                }
                                else if (ahmet.Count == 0 && localOBATP.movementTrack.Count > 0)
                                {
                                    int tempCount = MovementTracks.Count;

                                    int rearTrackIndex = MovementTracks.FindIndex(x => x.Track_ID == localOBATP.ActualRearOfTrainCurrent.Track.Track_ID);

                                    //if (rearTrackIndex > 0)
                                    {
                                        MovementTracks.RemoveRange(0, rearTrackIndex);


                                        if (tempCount != MovementTracks.Count)
                                            adapter.RefreshRouteTracks = true;
                                    }

                                }



                            }

                        }

                        #endregion



                        this.m_UIOBATP = adapter;
                    }


                    this.m_OBATPUIRefresh = localOBATP;

                    InformTrainMovementUITracksListWatcher();
                }

   

            }

        }
        public void AddTrainDetailsWindowWatcher(ITrainDetailsWindowWatcher watcher)
        {
            if (m_trainDetailsWindowWatcher.Contains(watcher))
                m_trainDetailsWindowWatcher.Remove(watcher);

            m_trainDetailsWindowWatcher.Add(watcher);
        }


        public void RemoveTrainDetailsWindowWatcher(ITrainDetailsWindowWatcher watcher)
        {
            if (m_trainDetailsWindowWatcher.Contains(watcher))
                m_trainDetailsWindowWatcher.Remove(watcher);
        }



        public void AddTrainCreatedWatcher(ITrainCreatedWatcher watcher)
        {
            if (m_trainCreatedWatcher.Contains(watcher))
                m_trainCreatedWatcher.Remove(watcher);

            m_trainCreatedWatcher.Add(watcher);
        }

        public void RemoveTrainCreatedWatcher(ITrainCreatedWatcher watcher)
        {
            if (m_trainCreatedWatcher.Contains(watcher))
                m_trainCreatedWatcher.Remove(watcher);
        }




        public void AddTrainMovementCreatedSendMessageWatcher(ITrainMovementCreatedSendMessageWatcher watcher)
        {
            if (m_trainMovementCreatedWatcher.Contains(watcher))
                m_trainMovementCreatedWatcher.Remove(watcher);


            m_trainMovementCreatedWatcher.Add(watcher);
        }


        public void RemoveTrainMovementCreatedSendMessageWatcher(ITrainMovementCreatedSendMessageWatcher watcher)
        {
            if (m_trainMovementCreatedWatcher.Contains(watcher))
                m_trainMovementCreatedWatcher.Remove(watcher);
        }

         
        public void AddTrainNewMovementAuthorityCreatedWatcher(ITrainNewMovementAuthorityCreatedWatcher watcher)
        {
            m_trainNewMovementAuthorityCreatedWatcher.Add(watcher);
        }


        public void RemoveTrainNewMovementAuthorityCreatedWatcher(ITrainNewMovementAuthorityCreatedWatcher watcher)
        {
            if (m_trainNewMovementAuthorityCreatedWatcher.Contains(watcher))
                m_trainNewMovementAuthorityCreatedWatcher.Remove(watcher);
        }


        public void AddTrainMovementRouteCreatedWatcher(ITrainMovementRouteCreatedWatcher watcher)
        {
            m_trainMovementRouteCreatedWatcher.Add(watcher);
        }

        public void RemoveTrainMovementRouteCreatedWatcher(ITrainMovementRouteCreatedWatcher watcher)
        {
            if (m_trainMovementRouteCreatedWatcher.Contains(watcher))
                m_trainMovementRouteCreatedWatcher.Remove(watcher);
        }


        public void AddTrainMovementUIWatcher(ITrainMovementUIWatcher watcher)
        {
            m_trainMovementUIWatcher.Add(watcher);
        }


        public void RemoveTrainMovementUIWatcher(ITrainMovementUIWatcher watcher)
        {
            if (m_trainMovementUIWatcher.Contains(watcher))
                m_trainMovementUIWatcher.Remove(watcher);
        }


        //public void AddTrainMovementUITracksListWatcher(ITrainMovementUIWatcher watcher)
        //{
        //    m_trainMovementUIWatcher.Add(watcher);
        //}


        //public void RemoveTrainMovementUITracksListWatcher(ITrainMovementUIWatcher watcher)
        //{
        //    if (m_trainMovementUIWatcher.Contains(watcher))
        //        m_trainMovementUIWatcher.Remove(watcher);
        //}
    }
}
