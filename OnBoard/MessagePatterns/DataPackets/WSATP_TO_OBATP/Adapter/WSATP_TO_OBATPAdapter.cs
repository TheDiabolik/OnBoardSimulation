using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard

{

  public  class WSATP_TO_OBATPAdapter :  IDisposable// : IWSATP_TO_OBATPAdapter//WSATP_TO_OBATP, WSATP_TO_OBATPAdaptee, IDisposable
    {
        private WSATP_TO_OBATPAdaptee _adaptee;
        private bool m_disposed = false;

        public bool EmergencyBrakeCommand { get; set; }
        public ushort PSD1EnableOK { get; set; }
        public ushort PSD2EnableOK { get; set; }
        public bool PSD1ClosedAndLocked { get; set; }
        public bool PSD2ClosedAndLocked { get; set; }
        //public List<Track> MovementAuthorityTracks { get; set; } = new List<Track>();

        public ThreadSafeList<Track> MovementAuthorityTracks { get; set; } = new ThreadSafeList<Track>();

        public WSATP_TO_OBATPAdapter(IMessageType message)
        {
            _adaptee = new WSATP_TO_OBATPAdaptee(message);
            WSATP_TO_OBATP WSATP_TO_OBATP = _adaptee.GetMessageType();

            AdaptData(WSATP_TO_OBATP);
        }

        #region WSATC Hareket Yetkisi Testi
        public void AdaptData(WSATP_TO_OBATP WSATP_TO_OBATP)
        { 

            this.EmergencyBrakeCommand = WSATP_TO_OBATP.EmergencyBrakeCommand.ByteToBool();
            this.PSD1EnableOK = Convert.ToUInt16(WSATP_TO_OBATP.PSD1EnableOK);
            this.PSD2EnableOK = Convert.ToUInt16(WSATP_TO_OBATP.PSD2EnableOK);
            this.PSD1ClosedAndLocked = WSATP_TO_OBATP.PSD1ClosedAndLocked.ByteToBool();
            this.PSD2ClosedAndLocked = WSATP_TO_OBATP.PSD2ClosedAndLocked.ByteToBool();



            //Track TrackSectionID1 = MainForm.m_mf.m_WSATCMovement_YNK1_KIR2_YNK1.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID1));
            //Track TrackSectionID1 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID1));
            Track TrackSectionID1 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID1));

            if (TrackSectionID1 != null)
            {
                TrackSectionID1.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit1;
                this.MovementAuthorityTracks.Add(TrackSectionID1);
            }



            Track TrackSectionID2 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID2));
            //Track TrackSectionID2 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID2));

            if (TrackSectionID2 != null)
            {
                TrackSectionID2.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit2;
                this.MovementAuthorityTracks.Add(TrackSectionID2);
            }

            Track TrackSectionID3 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID3));
            //Track TrackSectionID3 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID3));

            if (TrackSectionID3 != null)
            {
                TrackSectionID3.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit3;
                this.MovementAuthorityTracks.Add(TrackSectionID3);
            }

            Track TrackSectionID4 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID4));
            //Track TrackSectionID4 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID4));

            if (TrackSectionID4 != null)
            {
                TrackSectionID4.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit4;
                this.MovementAuthorityTracks.Add(TrackSectionID4);
            }

            Track TrackSectionID5 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID5));
            //Track TrackSectionID5 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID5));

            if (TrackSectionID5 != null)
            {
                TrackSectionID5.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit5;
                this.MovementAuthorityTracks.Add(TrackSectionID5);
            }

            Track TrackSectionID6 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID6));
            //Track TrackSectionID6 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID6));

            if (TrackSectionID6 != null)
            {
                TrackSectionID6.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit6;
                this.MovementAuthorityTracks.Add(TrackSectionID6);
            }



            Track TrackSectionID7 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID7));
            //Track TrackSectionID7 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID7));

            if (TrackSectionID7 != null)
            {
                TrackSectionID7.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit7;
                this.MovementAuthorityTracks.Add(TrackSectionID7);
            }



            Track TrackSectionID8 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID8));
            //Track TrackSectionID8 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID8));

            if (TrackSectionID8 != null)
            {
                TrackSectionID8.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit8;
                this.MovementAuthorityTracks.Add(TrackSectionID8);
            }

            Track TrackSectionID9 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID9));
            //Track TrackSectionID9 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID9));

            if (TrackSectionID9 != null)
            {
                TrackSectionID9.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit9;
                this.MovementAuthorityTracks.Add(TrackSectionID9);
            }

            Track TrackSectionID10 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID10));
            //Track TrackSectionID10 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID10));

            if (TrackSectionID10 != null)
            {
                TrackSectionID10.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit10;
                this.MovementAuthorityTracks.Add(TrackSectionID10);
            }


            ///


            Track TrackSectionID11 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID11));
            //Track TrackSectionID11 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID11));

            if (TrackSectionID11 != null)
            {
                TrackSectionID11.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit11;
                this.MovementAuthorityTracks.Add(TrackSectionID11);
            }


            Track TrackSectionID12 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID12));
            //Track TrackSectionID12 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID12));

            if (TrackSectionID12 != null)
            {
                TrackSectionID12.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit12;
                this.MovementAuthorityTracks.Add(TrackSectionID12);
            }

            Track TrackSectionID13 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID13));
            //Track TrackSectionID13 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID13));

            if (TrackSectionID13 != null)
            {
                TrackSectionID13.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit13;
                this.MovementAuthorityTracks.Add(TrackSectionID13);
            }

            Track TrackSectionID14 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID14));
            //Track TrackSectionID14 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID14));

            if (TrackSectionID14 != null)
            {
                TrackSectionID14.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit14;
                this.MovementAuthorityTracks.Add(TrackSectionID14);
            }

            Track TrackSectionID15 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID15));
            //Track TrackSectionID15 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID15));

            if (TrackSectionID15 != null)
            {
                TrackSectionID15.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit15;
                this.MovementAuthorityTracks.Add(TrackSectionID15);
            }

            Track TrackSectionID16 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID16));
            //Track TrackSectionID16 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID16));

            if (TrackSectionID16 != null)
            {
                TrackSectionID6.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit16;
                this.MovementAuthorityTracks.Add(TrackSectionID16);
            }



            Track TrackSectionID17 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID17));
            //Track TrackSectionID17 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID17));

            if (TrackSectionID17 != null)
            {
                TrackSectionID7.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit17;
                this.MovementAuthorityTracks.Add(TrackSectionID17);
            }



            Track TrackSectionID18 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID18));
            //Track TrackSectionID18 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID18));

            if (TrackSectionID18 != null)
            {
                TrackSectionID18.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit18;
                this.MovementAuthorityTracks.Add(TrackSectionID18);
            }

            Track TrackSectionID19 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID19));
            //Track TrackSectionID19 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID19));

            if (TrackSectionID19 != null)
            {
                TrackSectionID19.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit19;
                this.MovementAuthorityTracks.Add(TrackSectionID19);
            }

            Track TrackSectionID20 = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID20));
            //Track TrackSectionID20 = Route.FindTrackInRoute(Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID20));

            if (TrackSectionID20 != null)
            {
                TrackSectionID20.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit20;
                this.MovementAuthorityTracks.Add(TrackSectionID20);
            } 

        }
#endregion

        #region OBATC Normalde Olması gereken
        //public void AdaptData(WSATP_TO_OBATP WSATP_TO_OBATP)
        //{

        //    this.EmergencyBrakeCommand = Convert.ToBoolean(WSATP_TO_OBATP.EmergencyBrakeCommand);
        //    this.PSD1EnableOK = Convert.ToUInt16(WSATP_TO_OBATP.PSD1EnableOK);
        //    this.PSD2EnableOK = Convert.ToUInt16(WSATP_TO_OBATP.PSD2EnableOK);
        //    this.PSD1ClosedAndLocked = Convert.ToBoolean(WSATP_TO_OBATP.PSD1ClosedAndLocked);
        //    this.PSD2ClosedAndLocked = Convert.ToBoolean(WSATP_TO_OBATP.PSD2ClosedAndLocked);



        //    Track TrackSectionID1 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID1));

        //    if (TrackSectionID1 != null)
        //    {
        //        TrackSectionID1.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit1;
        //        this.MovementAuthorityTracks.Add(TrackSectionID1);
        //    }


        //    Track TrackSectionID2 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID2));

        //    if (TrackSectionID2 != null)
        //    {
        //        TrackSectionID2.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit2;
        //        this.MovementAuthorityTracks.Add(TrackSectionID2);
        //    }

        //    Track TrackSectionID3 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID3));

        //    if (TrackSectionID3 != null)
        //    {
        //        TrackSectionID3.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit3;
        //        this.MovementAuthorityTracks.Add(TrackSectionID3);
        //    }

        //    Track TrackSectionID4 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID4));

        //    if (TrackSectionID4 != null)
        //    {
        //        TrackSectionID4.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit4;
        //        this.MovementAuthorityTracks.Add(TrackSectionID4);
        //    }

        //    Track TrackSectionID5 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID5));

        //    if (TrackSectionID5 != null)
        //    {
        //        TrackSectionID5.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit5;
        //        this.MovementAuthorityTracks.Add(TrackSectionID5);
        //    }

        //    Track TrackSectionID6 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID6));

        //    if (TrackSectionID6 != null)
        //    {
        //        TrackSectionID6.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit6;
        //        this.MovementAuthorityTracks.Add(TrackSectionID6);
        //    }



        //    Track TrackSectionID7 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID7));

        //    if (TrackSectionID7 != null)
        //    {
        //        TrackSectionID7.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit7;
        //        this.MovementAuthorityTracks.Add(TrackSectionID7);
        //    }



        //    Track TrackSectionID8 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID8));

        //    if (TrackSectionID8 != null)
        //    {
        //        TrackSectionID8.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit8;
        //        this.MovementAuthorityTracks.Add(TrackSectionID8);
        //    }

        //    Track TrackSectionID9 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID9));

        //    if (TrackSectionID9 != null)
        //    {
        //        TrackSectionID9.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit9;
        //        this.MovementAuthorityTracks.Add(TrackSectionID9);
        //    }

        //    Track TrackSectionID10 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID10));

        //    if (TrackSectionID10 != null)
        //    {
        //        TrackSectionID10.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit10;
        //        this.MovementAuthorityTracks.Add(TrackSectionID10);
        //    }


        //    ///


        //    Track TrackSectionID11 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID11));

        //    if (TrackSectionID11 != null)
        //    {
        //        TrackSectionID11.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit11;
        //        this.MovementAuthorityTracks.Add(TrackSectionID11);
        //    }


        //    Track TrackSectionID12 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID12));

        //    if (TrackSectionID12 != null)
        //    {
        //        TrackSectionID12.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit12;
        //        this.MovementAuthorityTracks.Add(TrackSectionID12);
        //    }

        //    Track TrackSectionID13 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID13));

        //    if (TrackSectionID13 != null)
        //    {
        //        TrackSectionID13.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit13;
        //        this.MovementAuthorityTracks.Add(TrackSectionID13);
        //    }

        //    Track TrackSectionID14 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID14));

        //    if (TrackSectionID14 != null)
        //    {
        //        TrackSectionID14.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit14;
        //        this.MovementAuthorityTracks.Add(TrackSectionID14);
        //    }

        //    Track TrackSectionID15 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID15));

        //    if (TrackSectionID15 != null)
        //    {
        //        TrackSectionID15.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit15;
        //        this.MovementAuthorityTracks.Add(TrackSectionID15);
        //    }

        //    Track TrackSectionID16 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID16));

        //    if (TrackSectionID16 != null)
        //    {
        //        TrackSectionID6.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit16;
        //        this.MovementAuthorityTracks.Add(TrackSectionID16);
        //    }



        //    Track TrackSectionID17 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID17));

        //    if (TrackSectionID17 != null)
        //    {
        //        TrackSectionID7.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit17;
        //        this.MovementAuthorityTracks.Add(TrackSectionID17);
        //    }



        //    Track TrackSectionID18 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID18));

        //    if (TrackSectionID18 != null)
        //    {
        //        TrackSectionID18.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit18;
        //        this.MovementAuthorityTracks.Add(TrackSectionID18);
        //    }

        //    Track TrackSectionID19 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID19));

        //    if (TrackSectionID19 != null)
        //    {
        //        TrackSectionID19.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit19;
        //        this.MovementAuthorityTracks.Add(TrackSectionID19);
        //    }

        //    Track TrackSectionID20 = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == Convert.ToInt32(WSATP_TO_OBATP.TrackSectionID20));

        //    if (TrackSectionID20 != null)
        //    {
        //        TrackSectionID20.Track_Speed_Limit_KMH = WSATP_TO_OBATP.SpeedLimit20;
        //        this.MovementAuthorityTracks.Add(TrackSectionID20);
        //    }

    //}
    #endregion

    public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{0} : {1}", "EmergencyBrakeCommand", this.EmergencyBrakeCommand.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "PSD1EnableOK", this.PSD1EnableOK.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "PSD2EnableOK", this.PSD2EnableOK.ToString());
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat("{0} : {1}", "PSD1ClosedAndLocked", this.PSD1ClosedAndLocked.ToString());
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat("{0} : {1}", "PSD2ClosedAndLocked", this.PSD2ClosedAndLocked.ToString());
            stringBuilder.AppendLine();



            for (int i = 0; i < this.MovementAuthorityTracks.Count; i++)
            {
                stringBuilder.AppendFormat("{0}{1} : {2}", "TrackSectionID", (i + 1).ToString(), this.MovementAuthorityTracks[i].Track_ID.ToString());
                stringBuilder.AppendLine();

                stringBuilder.AppendFormat("{0}{1} : {2}", "SpeedLimit", (i + 1).ToString(), this.MovementAuthorityTracks[i].Track_Speed_Limit_KMH.ToString());
                stringBuilder.AppendLine();
            }




            return stringBuilder.ToString();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Dispose time code 
                    //buraya sonlanma için method eklenecek
                }

                // Finalize time code 
                m_disposed = true;
            }


        }

        public void Dispose()
        {
            //if (m_disposed)
            {
                Dispose(true);

                GC.SuppressFinalize(this);
            }
        }

    }

    }
