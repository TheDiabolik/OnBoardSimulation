using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    partial class DatabaseOperation
    {
        public async Task<List<Track>> AsycSelectYNK1_KIR2()
        { 
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                List<Track> exitDates = new List<Track>();

                try
                {
                    await conn.OpenAsync();

                    string selectsyncFileNames = "SELECT *  FROM YNK1_KIR2"; 

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = conn;
                    command.CommandText = selectsyncFileNames;
                    //command.Parameters.AddWithValue("@Plate", plate);


                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Track track = new Track();

                        track.Station_Name = reader["StationName"].ToString();
                        track.Track_ID = int.Parse(reader["Track"].ToString());
                        track.Track_Length = int.Parse(reader["Length"].ToString());
                        track.StartPositionInRoute = int.Parse(reader["StartPositionInRoute"].ToString());
                        track.StopPositionInRoute = int.Parse(reader["StopPositionInRoute"].ToString());

                        exitDates.Add(track);
                    }

                    reader.Dispose();
                    command.Dispose(); 
                


                    return exitDates;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsycSelectYNK1_KIR2()");
                    return exitDates;
                }
            }
        }

        public async Task<List<Track>> AsycSelectKIR2_YNK1()
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                List<Track> exitDates = new List<Track>();

                try
                {
                    await conn.OpenAsync();

                    string selectsyncFileNames = "SELECT *  FROM KIR2_YNK1";

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = conn;
                    command.CommandText = selectsyncFileNames;
                    //command.Parameters.AddWithValue("@Plate", plate);


                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Track track = new Track();

                        track.Station_Name = reader["StationName"].ToString();
                        track.Track_ID = int.Parse(reader["Track"].ToString());
                        track.Track_Length = int.Parse(reader["Length"].ToString());
                        track.StartPositionInRoute = int.Parse(reader["StartPositionInRoute"].ToString());
                        track.StopPositionInRoute = int.Parse(reader["StopPositionInRoute"].ToString());

                      

                        exitDates.Add(track);
                    }

                    reader.Dispose();
                    command.Dispose();



                    return exitDates;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsycSelectKIR2_YNK1()");
                    return exitDates;
                }
            }
        }

        public async Task<List<Track>> AsycSelectYNK1_KIR2_YNK1()
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                List<Track> exitDates = new List<Track>();

                try
                {
                    await conn.OpenAsync();

                    string selectsyncFileNames = "SELECT *  FROM YNK1_KIR2_YNK1";

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = conn;
                    command.CommandText = selectsyncFileNames;
                    //command.Parameters.AddWithValue("@Plate", plate);


                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Track track = new Track();

                        track.Station_Name = reader["StationName"].ToString();
                        track.Track_ID = int.Parse(reader["Track"].ToString());
                        track.Track_Length = int.Parse(reader["Length"].ToString());
                        track.StartPositionInRoute = int.Parse(reader["StartPositionInRoute"].ToString());
                        track.StopPositionInRoute = int.Parse(reader["StopPositionInRoute"].ToString());

                        track.Station_Start_Position = int.Parse(reader["StationStartPosition"].ToString());
                        track.Station_End_Position = int.Parse(reader["StationEndPosition"].ToString());
                        track.Track_Start_Position = int.Parse(reader["TrackStartPosition"].ToString());
                        track.Track_End_Position = int.Parse(reader["TrackEndPosition"].ToString());
                        track.Track_Speed_Limit_KMH = int.Parse(reader["TrackSpeedLimitKMH"].ToString());
                        track.Track_Speed_Limit_CMSEC = int.Parse(reader["TrackSpeedLimitCMSEC"].ToString());
                        track.Stopping_Point_Position_1 = int.Parse(reader["StoppingPointPosition1"].ToString());
                        track.Stopping_Point_Type_1 = int.Parse(reader["StoppingPointType1"].ToString());
                        track.Stopping_Point_Positon_2 = int.Parse(reader["StoppingPointPosition2"].ToString());
                        track.Stopping_Point_Type_2 = int.Parse(reader["StoppingPointType2"].ToString());

                        track.Track_Connection_Entry_1 = int.Parse(reader["TrackConnectionEntry1"].ToString());
                        track.Track_Connection_Entry_2 = int.Parse(reader["TrackConnectionEntry2"].ToString());
                        track.Track_Connection_Exit_1 = int.Parse(reader["TrackConnectionExit1"].ToString());
                        track.Track_Connection_Exit_2 = int.Parse(reader["TrackConnectionExit2"].ToString());


                        track.SpeedChangeVMax = track.Track_Speed_Limit_KMH;

                        track.MaxTrackSpeedKMH = track.SpeedChangeVMax;
                        track.MaxTrackSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(track.SpeedChangeVMax);

                        if (!string.IsNullOrEmpty(track.Station_Name))
                            track.DwellTime = 20;

                        //track.DwellTime = 0;

                        exitDates.Add(track);
                    }

                    reader.Dispose();
                    command.Dispose();



                    return exitDates;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsycSelectYNK1_KIR2()");
                    return exitDates;
                }
            }
        }


        public async Task<Track> AsycSelectTrackFromYNK1_KIR2_YNK1(int trackID, Enums.Direction direction)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                Track ztrack = new Track();
                List<Track> mytrack = new List<Track>(); 

                try
                {
                    await conn.OpenAsync();

                    string selectsyncFileNames = "SELECT * FROM YNK1_KIR2_YNK1 where Track=@Track";

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = conn;
                    command.CommandText = selectsyncFileNames;

                    command.Parameters.AddWithValue("@Track", trackID);


                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Track track = new Track();

                        track.Station_Name = reader["StationName"].ToString();
                        track.Track_ID = int.Parse(reader["Track"].ToString());
                        track.Track_Length = int.Parse(reader["Length"].ToString());
                        track.StartPositionInRoute = int.Parse(reader["StartPositionInRoute"].ToString());
                        track.StopPositionInRoute = int.Parse(reader["StopPositionInRoute"].ToString());

                        track.Station_Start_Position = int.Parse(reader["StationStartPosition"].ToString());
                        track.Station_End_Position = int.Parse(reader["StationEndPosition"].ToString());
                        track.Track_Start_Position = int.Parse(reader["TrackStartPosition"].ToString());
                        track.Track_End_Position = int.Parse(reader["TrackEndPosition"].ToString());
                        track.Track_Speed_Limit_KMH = int.Parse(reader["TrackSpeedLimitKMH"].ToString());
                        track.Track_Speed_Limit_CMSEC = int.Parse(reader["TrackSpeedLimitCMSEC"].ToString());
                        track.Stopping_Point_Position_1 = int.Parse(reader["StoppingPointPosition1"].ToString());
                        track.Stopping_Point_Type_1 = int.Parse(reader["StoppingPointType1"].ToString());
                        track.Stopping_Point_Positon_2 = int.Parse(reader["StoppingPointPosition2"].ToString());
                        track.Stopping_Point_Type_2 = int.Parse(reader["StoppingPointType2"].ToString());

                        track.Track_Connection_Entry_1 = int.Parse(reader["TrackConnectionEntry1"].ToString());
                        track.Track_Connection_Entry_2 = int.Parse(reader["TrackConnectionEntry2"].ToString());
                        track.Track_Connection_Exit_1 = int.Parse(reader["TrackConnectionExit1"].ToString());
                        track.Track_Connection_Exit_2 = int.Parse(reader["TrackConnectionExit2"].ToString());


                        track.SpeedChangeVMax = track.Track_Speed_Limit_KMH;

                        track.MaxTrackSpeedKMH = track.SpeedChangeVMax;
                        track.MaxTrackSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(track.SpeedChangeVMax);

                        if (!string.IsNullOrEmpty(track.Station_Name))
                            track.DwellTime = 20;

                        //track.DwellTime = 0;

                        mytrack.Add(track);
                    }

                    reader.Dispose();
                    command.Dispose();


                    if (direction == Enums.Direction.Right)
                        ztrack = mytrack.First();
                    else if (direction == Enums.Direction.Left)
                        ztrack = mytrack.Last();


                    return ztrack;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsycSelectYNK1_KIR2()");
                    return ztrack;
                }
            }
        }

        public async Task<Track> AsycSelectTrackFromTracksTable(int trackID)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                Track ztrack = new Track();
                List<Track> mytrack = new List<Track>();

                try
                {
                    await conn.OpenAsync();

                    string selectsyncFileNames = "SELECT * FROM Tracks where Track=@Track";

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = conn;
                    command.CommandText = selectsyncFileNames;

                    command.Parameters.AddWithValue("@Track", trackID);


                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Track track = new Track();

                        track.Station_Name = reader["StationName"].ToString();
                        track.Track_ID = int.Parse(reader["Track"].ToString());
                        track.Track_Length = int.Parse(reader["Length"].ToString());
                        track.StartPositionInRoute = int.Parse(reader["StartPositionInRoute"].ToString());
                        track.StopPositionInRoute = int.Parse(reader["StopPositionInRoute"].ToString());

                        track.Station_Start_Position = int.Parse(reader["StationStartPosition"].ToString());
                        track.Station_End_Position = int.Parse(reader["StationEndPosition"].ToString());
                        track.Track_Start_Position = int.Parse(reader["TrackStartPosition"].ToString());
                        track.Track_End_Position = int.Parse(reader["TrackEndPosition"].ToString());
                        track.Track_Speed_Limit_KMH = int.Parse(reader["TrackSpeedLimitKMH"].ToString());
                        track.Track_Speed_Limit_CMSEC = int.Parse(reader["TrackSpeedLimitCMSEC"].ToString());
                        track.Stopping_Point_Position_1 = int.Parse(reader["StoppingPointPosition1"].ToString());
                        track.Stopping_Point_Type_1 = int.Parse(reader["StoppingPointType1"].ToString());
                        track.Stopping_Point_Positon_2 = int.Parse(reader["StoppingPointPosition2"].ToString());
                        track.Stopping_Point_Type_2 = int.Parse(reader["StoppingPointType2"].ToString());

                        track.Track_Connection_Entry_1 = int.Parse(reader["TrackConnectionEntry1"].ToString());
                        track.Track_Connection_Entry_2 = int.Parse(reader["TrackConnectionEntry2"].ToString());
                        track.Track_Connection_Exit_1 = int.Parse(reader["TrackConnectionExit1"].ToString());
                        track.Track_Connection_Exit_2 = int.Parse(reader["TrackConnectionExit2"].ToString());


                        track.SpeedChangeVMax = track.Track_Speed_Limit_KMH;

                        track.MaxTrackSpeedKMH = track.SpeedChangeVMax;
                        track.MaxTrackSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(track.SpeedChangeVMax);

                        if (!string.IsNullOrEmpty(track.Station_Name))
                            track.DwellTime = 20;

                        //track.DwellTime = 0;

                        mytrack.Add(track);
                    }

                    reader.Dispose();
                    command.Dispose();  


                    return ztrack;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsycSelectTrackFromTracksTable()");
                    return ztrack;
                }
            }
        }





        public async Task<Track> AsycSelectTrackFromYNK2_HAV2_YNK2(int trackID, Enums.Direction direction)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                Track ztrack = new Track();
                List<Track> mytrack = new List<Track>();

                try
                {
                    await conn.OpenAsync();

                    string selectsyncFileNames = "SELECT * FROM YNK2_HAV2_YNK2 where Track=@Track";

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = conn;
                    command.CommandText = selectsyncFileNames;

                    command.Parameters.AddWithValue("@Track", trackID);


                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Track track = new Track();

                        track.Station_Name = reader["StationName"].ToString();
                        track.Track_ID = int.Parse(reader["Track"].ToString());
                        track.Track_Length = int.Parse(reader["Length"].ToString());
                        track.StartPositionInRoute = int.Parse(reader["StartPositionInRoute"].ToString());
                        track.StopPositionInRoute = int.Parse(reader["StopPositionInRoute"].ToString());

                        track.Station_Start_Position = int.Parse(reader["StationStartPosition"].ToString());
                        track.Station_End_Position = int.Parse(reader["StationEndPosition"].ToString());
                        track.Track_Start_Position = int.Parse(reader["TrackStartPosition"].ToString());
                        track.Track_End_Position = int.Parse(reader["TrackEndPosition"].ToString());
                        track.Track_Speed_Limit_KMH = int.Parse(reader["TrackSpeedLimitKMH"].ToString());
                        track.Track_Speed_Limit_CMSEC = int.Parse(reader["TrackSpeedLimitCMSEC"].ToString());
                        track.Stopping_Point_Position_1 = int.Parse(reader["StoppingPointPosition1"].ToString());
                        track.Stopping_Point_Type_1 = int.Parse(reader["StoppingPointType1"].ToString());
                        track.Stopping_Point_Positon_2 = int.Parse(reader["StoppingPointPosition2"].ToString());
                        track.Stopping_Point_Type_2 = int.Parse(reader["StoppingPointType2"].ToString());

                        track.Track_Connection_Entry_1 = int.Parse(reader["TrackConnectionEntry1"].ToString());
                        track.Track_Connection_Entry_2 = int.Parse(reader["TrackConnectionEntry2"].ToString());
                        track.Track_Connection_Exit_1 = int.Parse(reader["TrackConnectionExit1"].ToString());
                        track.Track_Connection_Exit_2 = int.Parse(reader["TrackConnectionExit2"].ToString());


                        track.SpeedChangeVMax = track.Track_Speed_Limit_KMH;

                        track.MaxTrackSpeedKMH = track.SpeedChangeVMax;
                        track.MaxTrackSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(track.SpeedChangeVMax);

                        if (!string.IsNullOrEmpty(track.Station_Name))
                            track.DwellTime = 20;

                        //track.DwellTime = 0;

                        mytrack.Add(track);
                    }

                    reader.Dispose();
                    command.Dispose();


                    if (direction == Enums.Direction.Right)
                        ztrack = mytrack.First();
                    else if (direction == Enums.Direction.Left)
                        ztrack = mytrack.Last();


                    return ztrack;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsycSelectTrackFromYNK2_HAV2_YNK2()");
                    return ztrack;
                }
            }
        }



        public async Task<Track> AsycSelectTrackIDAndStartPositionFromYNK2_HAV2_YNK2(int trackID, double startPositionInRoute, Enums.Direction direction)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                Track ztrack = new Track();
                List<Track> mytrack = new List<Track>();

                try
                {
                    await conn.OpenAsync();

                    string selectsyncFileNames = "SELECT * FROM YNK2_HAV2_YNK2 where Track=@Track and StartPositionInRoute=@StartPositionInRoute";

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = conn;
                    command.CommandText = selectsyncFileNames;

                    command.Parameters.AddWithValue("@Track", trackID);
                    command.Parameters.AddWithValue("@StartPositionInRoute", startPositionInRoute);


                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Track track = new Track();

                        track.Station_Name = reader["StationName"].ToString();
                        track.Track_ID = int.Parse(reader["Track"].ToString());
                        track.Track_Length = int.Parse(reader["Length"].ToString());
                        track.StartPositionInRoute = int.Parse(reader["StartPositionInRoute"].ToString());
                        track.StopPositionInRoute = int.Parse(reader["StopPositionInRoute"].ToString());

                        track.Station_Start_Position = int.Parse(reader["StationStartPosition"].ToString());
                        track.Station_End_Position = int.Parse(reader["StationEndPosition"].ToString());
                        track.Track_Start_Position = int.Parse(reader["TrackStartPosition"].ToString());
                        track.Track_End_Position = int.Parse(reader["TrackEndPosition"].ToString());
                        track.Track_Speed_Limit_KMH = int.Parse(reader["TrackSpeedLimitKMH"].ToString());
                        track.Track_Speed_Limit_CMSEC = int.Parse(reader["TrackSpeedLimitCMSEC"].ToString());
                        track.Stopping_Point_Position_1 = int.Parse(reader["StoppingPointPosition1"].ToString());
                        track.Stopping_Point_Type_1 = int.Parse(reader["StoppingPointType1"].ToString());
                        track.Stopping_Point_Positon_2 = int.Parse(reader["StoppingPointPosition2"].ToString());
                        track.Stopping_Point_Type_2 = int.Parse(reader["StoppingPointType2"].ToString());

                        track.Track_Connection_Entry_1 = int.Parse(reader["TrackConnectionEntry1"].ToString());
                        track.Track_Connection_Entry_2 = int.Parse(reader["TrackConnectionEntry2"].ToString());
                        track.Track_Connection_Exit_1 = int.Parse(reader["TrackConnectionExit1"].ToString());
                        track.Track_Connection_Exit_2 = int.Parse(reader["TrackConnectionExit2"].ToString());


                        track.SpeedChangeVMax = track.Track_Speed_Limit_KMH;

                        track.MaxTrackSpeedKMH = track.SpeedChangeVMax;
                        track.MaxTrackSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(track.SpeedChangeVMax);

                        if (!string.IsNullOrEmpty(track.Station_Name))
                            track.DwellTime = 20;

                        //track.DwellTime = 0;

                        mytrack.Add(track);
                    }

                    reader.Dispose();
                    command.Dispose();


                    if (direction == Enums.Direction.Right)
                        ztrack = mytrack.First();
                    else if (direction == Enums.Direction.Left)
                        ztrack = mytrack.Last();


                    return ztrack;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsycSelectTrackFromYNK2_HAV2_YNK2()");
                    return ztrack;
                }
            }
        }


        public async Task<ThreadSafeList<Track>> AsycSelectYNK2_HAV2_YNK2()
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                ThreadSafeList<Track> exitDates = new ThreadSafeList<Track>();

                try
                {
                    await conn.OpenAsync();

                    string selectsyncFileNames = "SELECT *  FROM YNK2_HAV2_YNK2";

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = conn;
                    command.CommandText = selectsyncFileNames;
                    //command.Parameters.AddWithValue("@Plate", plate);


                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Track track = new Track();

                        track.Station_Name = reader["StationName"].ToString();
                        track.Track_ID = int.Parse(reader["Track"].ToString());
                        track.Track_Length = int.Parse(reader["Length"].ToString());
                        track.StartPositionInRoute = int.Parse(reader["StartPositionInRoute"].ToString());
                        track.StopPositionInRoute = int.Parse(reader["StopPositionInRoute"].ToString());

                        track.Station_Start_Position = int.Parse(reader["StationStartPosition"].ToString());
                        track.Station_End_Position = int.Parse(reader["StationEndPosition"].ToString());
                        track.Track_Start_Position = int.Parse(reader["TrackStartPosition"].ToString());
                        track.Track_End_Position = int.Parse(reader["TrackEndPosition"].ToString());
                        track.Track_Speed_Limit_KMH = int.Parse(reader["TrackSpeedLimitKMH"].ToString());
                        track.Track_Speed_Limit_CMSEC = int.Parse(reader["TrackSpeedLimitCMSEC"].ToString());
                        track.Stopping_Point_Position_1 = int.Parse(reader["StoppingPointPosition1"].ToString());
                        track.Stopping_Point_Type_1 = int.Parse(reader["StoppingPointType1"].ToString());
                        track.Stopping_Point_Positon_2 = int.Parse(reader["StoppingPointPosition2"].ToString());
                        track.Stopping_Point_Type_2 = int.Parse(reader["StoppingPointType2"].ToString());

                        track.Track_Connection_Entry_1 = int.Parse(reader["TrackConnectionEntry1"].ToString());
                        track.Track_Connection_Entry_2 = int.Parse(reader["TrackConnectionEntry2"].ToString());
                        track.Track_Connection_Exit_1 = int.Parse(reader["TrackConnectionExit1"].ToString());
                        track.Track_Connection_Exit_2 = int.Parse(reader["TrackConnectionExit2"].ToString());


                        track.SpeedChangeVMax = track.Track_Speed_Limit_KMH;

                        track.MaxTrackSpeedKMH = track.SpeedChangeVMax;
                        track.MaxTrackSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(track.SpeedChangeVMax);

                        if (!string.IsNullOrEmpty(track.Station_Name))
                            track.DwellTime = 20;

                        //track.DwellTime = 0;

                        exitDates.Add(track);
                    }

                    reader.Dispose();
                    command.Dispose();



                    return exitDates;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsycSelectYNK2_HAV2_YNK2()");
                    return exitDates;
                }
            }
        }

        public async Task<ThreadSafeList<Track>> AsycSelectTracks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                ThreadSafeList<Track> exitDates = new ThreadSafeList<Track>();

                try
                {
                    await conn.OpenAsync();

                    string selectsyncFileNames = "SELECT *  FROM Tracks";

                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = conn;
                    command.CommandText = selectsyncFileNames;
                    //command.Parameters.AddWithValue("@Plate", plate);


                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Track track = new Track();

                        track.Station_Name = reader["StationName"].ToString();
                        track.Track_ID = int.Parse(reader["Track"].ToString());
                        track.Track_Length = int.Parse(reader["Length"].ToString());

                        track.Station_Start_Position = int.Parse(reader["StationStartPosition"].ToString());
                        track.Station_End_Position = int.Parse(reader["StationEndPosition"].ToString());
                        track.Track_Start_Position = int.Parse(reader["TrackStartPosition"].ToString());
                        track.Track_End_Position = int.Parse(reader["TrackEndPosition"].ToString());
                        track.Track_Speed_Limit_KMH = int.Parse(reader["TrackSpeedLimitKMH"].ToString());
                        track.Track_Speed_Limit_CMSEC = int.Parse(reader["TrackSpeedLimitCMSEC"].ToString());
                        track.Stopping_Point_Position_1 = int.Parse(reader["StoppingPointPosition1"].ToString());
                        track.Stopping_Point_Type_1 = int.Parse(reader["StoppingPointType1"].ToString());
                        track.Stopping_Point_Positon_2 = int.Parse(reader["StoppingPointPosition2"].ToString());
                        track.Stopping_Point_Type_2 = int.Parse(reader["StoppingPointType2"].ToString());

                        track.Track_Connection_Entry_1 = int.Parse(reader["TrackConnectionEntry1"].ToString());
                        track.Track_Connection_Entry_2 = int.Parse(reader["TrackConnectionEntry2"].ToString());
                        track.Track_Connection_Exit_1 = int.Parse(reader["TrackConnectionExit1"].ToString());
                        track.Track_Connection_Exit_2 = int.Parse(reader["TrackConnectionExit2"].ToString());


                        track.SpeedChangeVMax = track.Track_Speed_Limit_KMH;

                        track.MaxTrackSpeedKMH = track.SpeedChangeVMax;
                        track.MaxTrackSpeedCMS = UnitConversion.KilometerHourToCentimeterSecond(track.SpeedChangeVMax);

                        if (!string.IsNullOrEmpty(track.Station_Name))
                            track.DwellTime = 20;

                        //track.DwellTime = 0;

                        exitDates.Add(track);
                    }

                    reader.Dispose();
                    command.Dispose();



                    return exitDates;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsycSelectYNK2_HAV2_YNK2()");
                    return exitDates;
                }
            }
        }





        public async Task<int> AsyncInsert(List<string> value)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                int result = 0;
                try
                {
                    await conn.OpenAsync();

                    SQLiteCommand command = new SQLiteCommand("insert into HAV2_YNK2 (StationName, Track, Length, StartPositionInRoute, StopPositionInRoute) values (@StationName, @Track, @Length, @StartPositionInRoute, @StopPositionInRoute)",
                       conn);

                    //SQLiteCommand command = new SQLiteCommand("insert into YNK2_HAV2 (StationName, Track, Length) values (@StationName, @Track, @Length)",
                    //  conn);
                    command.Parameters.AddWithValue("@StationName", value[0]);
                    command.Parameters.AddWithValue("@Track", value[1]);
                    command.Parameters.AddWithValue("@Length", value[2]);
                    command.Parameters.AddWithValue("@StartPositionInRoute", value[3]);
                    command.Parameters.AddWithValue("@StopPositionInRoute", value[4]);

                    result = await command.ExecuteNonQueryAsync();

                    command.Dispose();

                    return result;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsyncInsert(List<string> value)");
                    return result;
                }
            }
        }

      

        public async Task<int> AsyncTracksInsert(List<string> value)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                int result = 0;
                try
                {
                    await conn.OpenAsync();

                    SQLiteCommand command = new SQLiteCommand("insert into Tracks (StationName, Track, Length, StationStartPosition,StationEndPosition, TrackStartPosition, TrackEndPosition," +
                        "TrackSpeedLimitKMH, TrackSpeedLimitCMSEC, StoppingPointPosition1, StoppingPointType1, StoppingPointPosition2,  StoppingPointType2, TrackConnectionEntry1,TrackConnectionEntry2," +
                        "TrackConnectionExit1,TrackConnectionExit2) values (@StationName, @Track, @Length, @StationStartPosition,@StationEndPosition, @TrackStartPosition, @TrackEndPosition," +
                        "@TrackSpeedLimitKMH, @TrackSpeedLimitCMSEC, @StoppingPointPosition1, @StoppingPointType1, @StoppingPointPosition2,  @StoppingPointType2, @TrackConnectionEntry1,@TrackConnectionEntry2," +
                        "@TrackConnectionExit1,@TrackConnectionExit2)",
                       conn);

                    //SQLiteCommand command = new SQLiteCommand("insert into YNK2_HAV2 (StationName, Track, Length) values (@StationName, @Track, @Length)",
                    //  conn);
                    command.Parameters.AddWithValue("@StationName", value[0]);
                    command.Parameters.AddWithValue("@Track", value[1]);
                    command.Parameters.AddWithValue("@Length", value[2]);
                    command.Parameters.AddWithValue("@StationStartPosition", value[3]);
                    command.Parameters.AddWithValue("@StationEndPosition", value[4]);

                    command.Parameters.AddWithValue("@TrackStartPosition", value[5]);
                    command.Parameters.AddWithValue("@TrackEndPosition", value[6]);
                    command.Parameters.AddWithValue("@TrackSpeedLimitKMH", value[7]);
                    command.Parameters.AddWithValue("@TrackSpeedLimitCMSEC", value[8]);

                    command.Parameters.AddWithValue("@StoppingPointPosition1", value[9]);
                    command.Parameters.AddWithValue("@StoppingPointType1", value[10]);
                    command.Parameters.AddWithValue("@StoppingPointPosition2", value[11]);
                    command.Parameters.AddWithValue("@StoppingPointType2", value[12]);

                    command.Parameters.AddWithValue("@TrackConnectionEntry1", value[13]);
                    command.Parameters.AddWithValue("@TrackConnectionEntry2", value[14]);
                    command.Parameters.AddWithValue("@TrackConnectionExit1", value[15]);
                    command.Parameters.AddWithValue("@TrackConnectionExit2", value[16]); 

                    result = await command.ExecuteNonQueryAsync();

                    command.Dispose();

                    return result;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsyncTracksInsert(List<string> value)");
                    return result;
                }
            }
        }



        public async Task<int> AsyncUpdateYNK1_KIR2_YNK1(List<string> value)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
            {
                int result = 0;
                try
                {
                    await conn.OpenAsync();

                    //SQLiteCommand command = new SQLiteCommand("update YNK1_KIR2_YNK1 set StartPositionInRoute=@StartPositionInRoute, StopPositionInRoute=@StopPositionInRoute  where ID=@ID",
                    //   conn);

                    SQLiteCommand command = new SQLiteCommand("update YNK1_KIR2_YNK1 set StationStartPosition=@StationStartPosition, StationEndPosition=@StationEndPosition," +
                        "TrackStartPosition=@TrackStartPosition, TrackEndPosition=@TrackEndPosition,TrackSpeedLimitKMH=@TrackSpeedLimitKMH, TrackSpeedLimitCMSEC=@TrackSpeedLimitCMSEC, StoppingPointPosition1=@StoppingPointPosition1," +
                        "StoppingPointType1=@StoppingPointType1, StoppingPointPosition2=@StoppingPointPosition2,StoppingPointType2=@StoppingPointType2, TrackConnectionEntry1=@TrackConnectionEntry1," +
                        "TrackConnectionEntry2=@TrackConnectionEntry2, TrackConnectionExit1=@TrackConnectionExit1,TrackConnectionExit2=@TrackConnectionExit2 where ID=@ID",
                      conn);

                    //SQLiteCommand command = new SQLiteCommand("insert into YNK2_HAV2 (StationName, Track, Length) values (@StationName, @Track, @Length)",
                    //  conn);
                    //command.Parameters.AddWithValue("@StationName", value[0]);
                    //command.Parameters.AddWithValue("@Track", value[1]);
                    //command.Parameters.AddWithValue("@Length", value[2]);
                    command.Parameters.AddWithValue("@StationStartPosition", value[0]);
                    command.Parameters.AddWithValue("@StationEndPosition", value[1]);
                    command.Parameters.AddWithValue("@TrackStartPosition", value[2]);
                    command.Parameters.AddWithValue("@TrackEndPosition", value[3]);
                    command.Parameters.AddWithValue("@TrackSpeedLimitKMH", value[4]);
                    command.Parameters.AddWithValue("@TrackSpeedLimitCMSEC", value[5]);
                    command.Parameters.AddWithValue("@StoppingPointPosition1", value[6]);
                    command.Parameters.AddWithValue("@StoppingPointType1", value[7]);
                    command.Parameters.AddWithValue("@StoppingPointPosition2", value[8]);
                    command.Parameters.AddWithValue("@StoppingPointType2", value[9]);
                    command.Parameters.AddWithValue("@TrackConnectionEntry1", value[10]);
                    command.Parameters.AddWithValue("@TrackConnectionEntry2", value[11]);
                    command.Parameters.AddWithValue("@TrackConnectionExit1", value[12]);
                    command.Parameters.AddWithValue("@TrackConnectionExit2", value[13]);


                    command.Parameters.AddWithValue("@ID", value[14]);
                    result = await command.ExecuteNonQueryAsync();

                    command.Dispose();

                    return result;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsyncUpdateYNK1_KIR2_YNK1(List<string> value)");
                    return result;
                }
            }
        }
            public async Task<int> AsyncUpdateYNK2_HAV2_YNK2(List<string> value)
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString.CnnString))
                {
                    int result = 0;
                    try
                    {
                        await conn.OpenAsync();

                        //SQLiteCommand command = new SQLiteCommand("update YNK1_KIR2_YNK1 set StartPositionInRoute=@StartPositionInRoute, StopPositionInRoute=@StopPositionInRoute  where ID=@ID",
                        //   conn);

                        SQLiteCommand command = new SQLiteCommand("update YNK2_HAV2_YNK2 set  StartPositionInRoute=@StartPositionInRoute, StopPositionInRoute=@StopPositionInRoute, StationStartPosition=@StationStartPosition, StationEndPosition=@StationEndPosition," +
                            "TrackStartPosition=@TrackStartPosition, TrackEndPosition=@TrackEndPosition,TrackSpeedLimitKMH=@TrackSpeedLimitKMH, TrackSpeedLimitCMSEC=@TrackSpeedLimitCMSEC, StoppingPointPosition1=@StoppingPointPosition1," +
                            "StoppingPointType1=@StoppingPointType1, StoppingPointPosition2=@StoppingPointPosition2,StoppingPointType2=@StoppingPointType2, TrackConnectionEntry1=@TrackConnectionEntry1," +
                            "TrackConnectionEntry2=@TrackConnectionEntry2, TrackConnectionExit1=@TrackConnectionExit1,TrackConnectionExit2=@TrackConnectionExit2 where ID=@ID",
                          conn);

                    //SQLiteCommand command = new SQLiteCommand("insert into YNK2_HAV2 (StationName, Track, Length) values (@StationName, @Track, @Length)",
                    //  conn);
                    //command.Parameters.AddWithValue("@StationName", value[0]);
                    //command.Parameters.AddWithValue("@Track", value[1]);
                    //command.Parameters.AddWithValue("@Length", value[2]);
                    command.Parameters.AddWithValue("@StartPositionInRoute", value[0]);
                    command.Parameters.AddWithValue("@StopPositionInRoute", value[1]);

                    command.Parameters.AddWithValue("@StationStartPosition", value[2]);
                        command.Parameters.AddWithValue("@StationEndPosition", value[3]);
                        command.Parameters.AddWithValue("@TrackStartPosition", value[4]);
                        command.Parameters.AddWithValue("@TrackEndPosition", value[5]);
                        command.Parameters.AddWithValue("@TrackSpeedLimitKMH", value[6]);
                        command.Parameters.AddWithValue("@TrackSpeedLimitCMSEC", value[7]);
                        command.Parameters.AddWithValue("@StoppingPointPosition1", value[8]);
                        command.Parameters.AddWithValue("@StoppingPointType1", value[9]);
                        command.Parameters.AddWithValue("@StoppingPointPosition2", value[10]);
                        command.Parameters.AddWithValue("@StoppingPointType2", value[11]);
                        command.Parameters.AddWithValue("@TrackConnectionEntry1", value[12]);
                        command.Parameters.AddWithValue("@TrackConnectionEntry2", value[13]);
                        command.Parameters.AddWithValue("@TrackConnectionExit1", value[14]);
                        command.Parameters.AddWithValue("@TrackConnectionExit2", value[15]);


                        command.Parameters.AddWithValue("@ID", value[16]);
                        result = await command.ExecuteNonQueryAsync();

                        command.Dispose();

                        return result;
                    }
                    catch (Exception ex)
                    {
                        Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AsyncUpdateYNK2_HAV2_YNK2(List<string> value)");
                        return result;
                    }
                }
            }
         
    }
}
