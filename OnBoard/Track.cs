using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    [Serializable]
    public  class Track
    {
        public int Track_No { get; set; }
        public int Station_Start_Position { get; set; }
        public int Station_End_Position { get; set; }
        public string Station_Name { get; set; }
        public int Track_ID { get; set; }
        public int Line_ID { get; set; }
        public int Track_Type { get; set; }
        public int Track_Start_Position { get; set; }
        public int Track_End_Position { get; set; }
        public int Track_Length { get; set; }



        private int track_Speed_Limit_KMH { get; set; }
         


        public int Track_Speed_Limit_KMH
        {
            get { return track_Speed_Limit_KMH; }

            set
            {
                if (value != track_Speed_Limit_KMH)
                {
                    track_Speed_Limit_KMH = value;


                    SpeedLimitCommand(track_Speed_Limit_KMH);

                    Track_Speed_Limit_CMSEC = UnitConversion.KilometerHourToCentimeterSecond(track_Speed_Limit_KMH);
                }
            }
        }



        private double track_Speed_Limit_CMSEC { get; set; }

        //public double Track_Speed_Limit_CMSEC { get; set; }


        public double Track_Speed_Limit_CMSEC
        {
            get { return track_Speed_Limit_CMSEC; }

            set
            {
                if (value != track_Speed_Limit_CMSEC)
                {
                    track_Speed_Limit_CMSEC = value;


                    Track_Speed_Limit_KMH = UnitConversion.CentimeterSecondToKilometerHour(track_Speed_Limit_CMSEC);
                }
            }
        }







        public int Stopping_Point_Position_1 { get; set; }
        public int Stopping_Point_Type_1 { get; set; }
        public int Stopping_Point_Positon_2 { get; set; }
        public int Stopping_Point_Type_2 { get; set; }
        public int Track_Connection_Entry_1 { get; set; }
        public int Track_Connection_Entry_2 { get; set; }
        public int Track_Connection_Exit_1 { get; set; }
        public int Track_Connection_Exit_2 { get; set; }
        public int X1_Point { get; set; }
        public int X2_Point { get; set; }
        public int Y1_Point { get; set; }
        public int Y2_Point { get; set; }


        //kapı için

        public int DwellTime { get; set; }
        public bool DwellTimeFinished { get; set; }

        //ahmet rota konum bilgisi
        public double StartPositionInRoute { get; set; }
        public double StopPositionInRoute { get; set; }

        /// <summary>
        /// Track hız sınırı kalıcı hat verisi. (km/h)
        /// </summary>
        public int SpeedChangeVMax { get; set; }

        /// <summary>
        /// Track için tespit edilen maksimum hız değeridir. (km/h)
        /// </summary>
        private double maxTrackSpeedKMH { get; set; }

        public double MaxTrackSpeedKMH
        {
            get { return maxTrackSpeedKMH; }

            set
            {
                if (value != maxTrackSpeedKMH)
                {
                    maxTrackSpeedKMH = value;
                    MaxTrackSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(maxTrackSpeedKMH);
                }
            }
        }
       
       
       
       
       /// <summary>
        /// Track için tespit edilen maksimum hız değeridir. (cm/s)
        /// </summary>
        private double maxTrackSpeedCMS { get; set; }


        public double MaxTrackSpeedCMS
        {
            get { return maxTrackSpeedCMS; }

            set
            {
                if (value != maxTrackSpeedCMS)
                {
                    maxTrackSpeedCMS = value;
                    MaxTrackSpeedKMH = UnitConversion.CentimeterSecondToKilometerHour(maxTrackSpeedCMS);
                }
            }
        }


        public Track MemberwiseCopy()
        {

            return (Track)this.MemberwiseClone();

        }

        public static ThreadSafeList<Track> AllTracks(DataTable dt)
        {
            ThreadSafeList<Track> trackList = new ThreadSafeList<Track>();


            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    Track track = new Track();

                    track.Track_No = Convert.ToInt32(row[0]);

                    if (int.TryParse(row[1].ToString(), out int station_Start_Position))
                        track.Station_Start_Position = station_Start_Position;

                    if (int.TryParse(row[2].ToString(), out int station_End_Position))
                        track.Station_End_Position = station_End_Position;


                    if (row[3].ToString() == 0.ToString())
                        track.Station_Name = null;
                    else
                        track.Station_Name = row[3].ToString();


                    track.Track_ID = Convert.ToInt32(row[4]);
                    track.Line_ID = Convert.ToInt32(row[5]);


                    if (int.TryParse(row[6].ToString(), out int track_Type))
                        track.Track_Type = track_Type;

                    //track.Track_Type = Convert.ToInt32(row[6]);


                    track.Track_Start_Position = Convert.ToInt32(row[7]);
                    track.Track_End_Position = Convert.ToInt32(row[8]);
                    track.Track_Length = Convert.ToInt32(row[9]);
                    track.Track_Speed_Limit_KMH = Convert.ToInt32(row[10]);
                    track.Stopping_Point_Position_1 = Convert.ToInt32(row[11]);
                    track.Stopping_Point_Type_1 = Convert.ToInt32(row[12]);

                    track.Stopping_Point_Positon_2 = Convert.ToInt32(row[13]);
                    track.Stopping_Point_Type_2 = Convert.ToInt32(row[14]);
                    track.Track_Connection_Entry_1 = Convert.ToInt32(row[15]);
                    track.Track_Connection_Entry_2 = Convert.ToInt32(row[16]);
                    track.Track_Connection_Exit_1 = Convert.ToInt32(row[17]);
                    track.Track_Connection_Exit_2 = Convert.ToInt32(row[18]);


                    //int X1_Point = Convert.ToInt32(row[19]);
                    //int X2_Point = Convert.ToInt32(row[20]);
                    //int Y1_Point = Convert.ToInt32(row[21]);
                    //int Y2_Point = Convert.ToInt32(row[22]);

                    track.SpeedChangeVMax = track.Track_Speed_Limit_KMH;

                    track.MaxTrackSpeedKMH = track.SpeedChangeVMax;
                    track.MaxTrackSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(track.SpeedChangeVMax);

                    //hız limiti hesaplanıyor
                    //değiştirilebilir
                    //SpeedLimitCommand(track.SpeedChangeVMax);



                    if (!string.IsNullOrEmpty(track.Station_Name))
                        track.DwellTime = 20;



                    trackList.Add(track);
                }



                return trackList;

            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AllTracks");
                return trackList;
            }

        }


        public static ThreadSafeList<Track> AllTracksAAA(DataTable dt)
        {
            ThreadSafeList<Track> trackList = new ThreadSafeList<Track>();

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    Track track = new Track();

                    track.Track_No = Convert.ToInt32(row[0]);






                    if (int.TryParse(row[1].ToString(), out int Track_ID))
                        track.Track_ID = Track_ID;



                    if (int.TryParse(row[2].ToString(), out int Track_Start_Position))
                        track.Track_Start_Position = Track_Start_Position;

                    if (int.TryParse(row[3].ToString(), out int Track_End_Position))
                        track.Track_End_Position = Track_End_Position;

                    if (int.TryParse(row[4].ToString(), out int Track_Length))
                        track.Track_Length = Track_Length;

                    if (int.TryParse(row[5].ToString(), out int Track_Speed_Limit_KMH))
                        track.Track_Speed_Limit_KMH = Track_Speed_Limit_KMH;



                    if (int.TryParse(row[6].ToString(), out int Track_Connection_Exit_1))
                        track.Track_Connection_Exit_1 = Track_Connection_Exit_1;



                    //track.Track_ID = Convert.ToInt32(row[1]);
                    //track.Track_Start_Position = Convert.ToInt32(row[2]);
                    //track.Track_End_Position = Convert.ToInt32(row[3]);
                    //track.Track_Length = Convert.ToInt32(row[4]);
                    //track.Track_Speed_Limit_KMH = Convert.ToInt32(row[5]);
                    //track.Track_Connection_Exit_1 = Convert.ToInt32(row[6]); 


                    //int X1_Point = Convert.ToInt32(row[19]);
                    //int X2_Point = Convert.ToInt32(row[20]);
                    //int Y1_Point = Convert.ToInt32(row[21]);
                    //int Y2_Point = Convert.ToInt32(row[22]);

                    track.SpeedChangeVMax = track.Track_Speed_Limit_KMH;

                    track.MaxTrackSpeedKMH = track.SpeedChangeVMax;
                    track.MaxTrackSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(track.SpeedChangeVMax);

                    //hız limiti hesaplanıyor
                    //değiştirilebilir
                    //SpeedLimitCommand(track.SpeedChangeVMax);


                    trackList.Add(track);
                }



                return trackList;

            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AllTracksAAA");
                return trackList;
            }
        }


        /// <summary>
        /// Uygulanacak olan hız kısıtlaması.
        /// </summary>bunu eklemek çok gereksiz bence bunu sonra silmem gerekecek
        public  void SpeedLimitCommand(int speedLimit)
        {
            if (speedLimit < SpeedChangeVMax)
            {
                MaxTrackSpeedKMH = speedLimit;
                //MaxTrackSpeedCMS = (double)(speedLimit * 100000) / 3600;
            }
            else
            {
                MaxTrackSpeedKMH = SpeedChangeVMax;
                //MaxTrackSpeedCMS = (double)(SpeedChangeVMax * 100000) / 3600;
            }
        }

        public static ThreadSafeList<Track> SimulationTrack(DataTable dt)
        {
            ThreadSafeList<Track> trackList = new ThreadSafeList<Track>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(row.ItemArray[0].ToString()))
                    {

                        //giriş
                        if (int.TryParse(row[3].ToString(), out int enttyTrackNo))
                        {
                         
                               //Track rtrack = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == enttyTrackNo);
                            Track rtrack = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == enttyTrackNo);
                            if ((trackList.Count == 0))
                            {
                                trackList.Add(rtrack);
                            }
                            else if (trackList.Last() != rtrack)
                            {
                                trackList.Add(rtrack);
                            }
                        }

                        //güzergah hat blokları
                        if (!string.IsNullOrEmpty(row.ItemArray[2].ToString()))
                        {
                            string[] routeTracks = row[2].ToString().Split('-');

                            for (int i = 0; i < routeTracks.Length; i++)
                            {
                                int routeTrackID = Convert.ToInt32(routeTracks[i]);

                                Track track = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == routeTrackID);
                                //Track track = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == routeTrackID);

                                trackList.Add(track);
                            }
                        }


                        //çıkış
                        if (int.TryParse(row[4].ToString(), out int exitTrackNo))
                        {
                            //Track rtrack = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == exitTrackNo);
                            Track rtrack = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == exitTrackNo);

                            if (trackList.Last() != rtrack)
                            {
                                trackList.Add(rtrack);
                            }
                        }
                    }
                }


                return trackList;
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "SimulationTrack");
                return trackList;
            }
        }

        



    }
}
