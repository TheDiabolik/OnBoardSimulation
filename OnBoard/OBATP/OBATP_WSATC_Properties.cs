using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public partial class OBATP : IWSATP_TO_OBATPMessageWatcher, IATS_TO_OBATO_InitMessageWatcher, IATS_TO_OBATO_MessageWatcher, IATS, IWSATC, IDisposable
    {
        #region IWSATC interface implemantation
        [Browsable(false)]
        public bool TrainAbsoluteZeroSpeed { get; set; }



        private bool m_OBATCtoWSATC_BerthingOk;


        [Browsable(false)]
        public bool OBATCtoWSATC_BerthingOk
        {
            get { return m_OBATCtoWSATC_BerthingOk; }

            set
            {
                if(value != m_OBATCtoWSATC_BerthingOk)
                {
                    m_OBATCtoWSATC_BerthingOk = value;

                    //if(!m_OBATCtoWSATC_BerthingOk)
                    //    DwellTime = Convert.ToUInt16(Enums.DwellTime.Movement);

                }


              
            }
        }





     


         
        

        public void CheckBerthingStatus(double currentSpeedCMS, bool DwellTimeFinished)
        { 
            TrackWithPosition berhthingTrack = ActualFrontOfTrainCurrent;

            Track track = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == berhthingTrack.Track.Track_ID);

            //Track track = Route.FindTrackInRoute(berhthingTrack.Track.Track_ID);

            if ((track != null) && (!string.IsNullOrEmpty(track.Station_Name)))
            {
                Enums.Direction direction = Direction;
                double location;

                if (direction == Enums.Direction.Right)
                {

                    location = track.Stopping_Point_Positon_2;

                    if (((location - 40) <= berhthingTrack.Location) && (berhthingTrack.Location <= (location + 40)) && (currentSpeedCMS == 0) && !DwellTimeFinished)
                    {
                        OBATCtoWSATC_BerthingOk = true;
                    }
                    else
                    {
                        OBATCtoWSATC_BerthingOk = false;
                    }
                }
                else if (direction == Enums.Direction.Left)
                {
                    location = track.Stopping_Point_Position_1;

                    if (((location - 40) <= berhthingTrack.Location) && (berhthingTrack.Location <= (location + 40)) && (currentSpeedCMS == 0) && !DwellTimeFinished)
                    {
                        OBATCtoWSATC_BerthingOk = true;
                    }
                    else
                    {
                        OBATCtoWSATC_BerthingOk = false;
                    }
                }
            }
        }


        public void CheckBerthingStatus(double currentSpeedCMS)
        {
            TrackWithPosition berhthingTrack = ActualFrontOfTrainCurrent;
            //TrackWithPosition berhthingTrack = FrontOfTrainTrackWithFootPrint;

            Track track = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == berhthingTrack.Track.Track_ID);

            //Track track = Route.FindTrackInRoute(berhthingTrack.Track.Track_ID);

            if ((track != null) && (!string.IsNullOrEmpty(track.Station_Name)))
            {
                Enums.Direction direction = Direction;
                double location;

                if (direction == Enums.Direction.Right)
                {

                    location = track.Stopping_Point_Positon_2;

                    //if (((location - 40) <= berhthingTrack.Location) && (berhthingTrack.Location <= (location + 40)) && (currentSpeedCMS == 0))
                    //if (((location - 400) <= berhthingTrack.Location) && (berhthingTrack.Location <= (location + 400)) && (currentSpeedCMS == 0))
                    if (((location - 400) <= berhthingTrack.Location) && (berhthingTrack.Location <= (location + 400)) && (currentSpeedCMS == 0))
                    //if (((location - 40) <= berhthingTrack.Location) && (berhthingTrack.Location <= (location + 40)) && (this.TrainAbsoluteZeroSpeed))
                    {
                        OBATCtoWSATC_BerthingOk = true;
                    }
                    else
                    {
                        OBATCtoWSATC_BerthingOk = false;
                    }
                }
                else if (direction == Enums.Direction.Left)
                {
                    location = track.Stopping_Point_Position_1;

                    //if (((location - 40) <= berhthingTrack.Location) && (berhthingTrack.Location <= (location + 40)) && (currentSpeedCMS == 0))
                    //if (((location - 400) <= berhthingTrack.Location) && (berhthingTrack.Location <= (location + 400)) && (currentSpeedCMS == 0))
                    if (((location - 400) <= berhthingTrack.Location) && (berhthingTrack.Location <= (location + 400)) && (currentSpeedCMS == 0))
                    //if (((location - 40) <= berhthingTrack.Location) && (berhthingTrack.Location <= (location + 40)) && (this.TrainAbsoluteZeroSpeed))
                    {
                        OBATCtoWSATC_BerthingOk = true;
                    }
                    else
                    {
                        OBATCtoWSATC_BerthingOk = false;
                    }
                }
            }
            //else
            //{
            //    OBATCtoWSATC_BerthingOk = false;

           
            //}
               
        }


        Stopwatch m_zeroSpeedStopwatch = new Stopwatch();

        public void CheckTrainAbsoluteZeroSpeed()
        {
            if (Vehicle.CurrentTrainSpeedCMS == 0 )
            {
                //#region Check Message Incoming
                //if (!m_zeroSpeedStopwatch.IsRunning)
                //{
                //    m_zeroSpeedStopwatch.Restart();
                //}

                //if(m_zeroSpeedStopwatch.Elapsed.TotalSeconds > 2)
                //{
                    this.TrainAbsoluteZeroSpeed = true;
                //}
                    


              
                //#endregion



              
            }
            else
            {

                //m_zeroSpeedStopwatch.Stop();

                this.TrainAbsoluteZeroSpeed = false;
            }
               
        }



        #endregion
    }
}
