using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    class HelperClass
    {
        private static readonly object m_lock = new object();

        public static byte BoolToHex(bool value)
        {
            byte boolToHexValue;

           if (value)
                boolToHexValue = Byte.Parse("0xAA".Substring(2), NumberStyles.HexNumber);
           else
                boolToHexValue = Byte.Parse("0x55".Substring(2), NumberStyles.HexNumber);

            return boolToHexValue;

        }

        //public static ushort[] FindTrackRangeInAllTracks(Track frontTrack, Track rearTrack, ThreadSafeList<Track> allTracks)
        public static ushort[] FindTrackRangeInAllTracks(Track frontTrack, Track rearTrack, ThreadSafeList<Track> routeTracks)
        {
            lock (m_lock)
            {


                ushort[] trackRangeList = new ushort[15];

                try
                { 
                    //if(frontTrack.Track_ID.ToString().StartsWith("6") || rearTrack.Track_ID.ToString().StartsWith("6"))
                    //{
                    //    return trackRangeList ;
                    //}

                    int frontTrackIndex = routeTracks.FindIndex(x => x == frontTrack);
                    int rearTrackIndex = routeTracks.FindIndex(x => x == rearTrack);



                    if (frontTrackIndex != -1 || rearTrackIndex != -1)
                        trackRangeList = routeTracks.Where((element, index) => (index <= frontTrackIndex) && (index >= rearTrackIndex)).Select(x => (ushort)x.Track_ID).ToArray();



                    //if (frontTrackIndex != -1 && rearTrackIndex != -1)
                    //{
                    //    if (frontTrackIndex >= rearTrackIndex)
                    //        trackRangeList = routeTracks.Where((element, index) => (index <= frontTrackIndex) && (index >= rearTrackIndex)).Select(x => (ushort)x.Track_ID).ToList().ToArray();
                    //    else if (frontTrackIndex <= rearTrackIndex)
                    //        trackRangeList = routeTracks.Where((element, index) => (index >= frontTrackIndex) && (index <= rearTrackIndex)).Select(x => (ushort)x.Track_ID).ToList().ToArray();
                    //}

                    //else if (frontTrackIndex != -1 && rearTrackIndex == -1)
                    //{
                    //    if (frontTrackIndex >= rearTrackIndex)
                    //        trackRangeList = routeTracks.Where((element, index) => (index <= frontTrackIndex) && (index >= frontTrackIndex - 1)).Select(x => (ushort)x.Track_ID).ToList().ToArray();
                    //    else if (frontTrackIndex <= rearTrackIndex)
                    //        trackRangeList = routeTracks.Where((element, index) => (index >= frontTrackIndex) && (index <= frontTrackIndex - 1)).Select(x => (ushort)x.Track_ID).ToList().ToArray();
                    //}


                    if (trackRangeList[0] == 0)
                    {

                    }


                    return trackRangeList;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "FindTrackRangeInAllTracks");
                    return trackRangeList;
                }

            }
        }


        private static readonly object m_lock2 = new object();
        public static List<Track> FindTrackRangeInAllTracksTrainDetail(Track frontTrack, Track rearTrack, ThreadSafeList<Track> routeTracks)
        {
            lock (m_lock2)
            {
                List<Track> trackRangeList = new List<Track>();

                //Track[] trackRangeList = new ushort[15];

                try
                {
                   

                    int frontTrackIndex = routeTracks.FindIndex(x => x == frontTrack);
                    int rearTrackIndex = routeTracks.FindIndex(x => x == rearTrack);



                    if (frontTrackIndex != -1 || rearTrackIndex != -1)
                        trackRangeList = routeTracks.Where((element, index) => (index <= frontTrackIndex) && (index >= rearTrackIndex)).ToList();


 


                    return trackRangeList;
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "FindTrackRangeInAllTracksTrainDetail");
                    return trackRangeList;
                }

            }
        }



        public static ushort[] FindTrackRangeInAllTracks(Track frontTrack, Track rearTrack, ThreadSafeList<Track> routeTracks, Enums.Direction direction)
        {
            //lock (m_lock)
            {


                ushort[] trackRangeList = new ushort[15];

                try
                {

                    int frontTrackIndex; 
                    int rearTrackIndex;

                    if (direction == Enums.Direction.Left)
                    {
                        frontTrackIndex = 0;
                          //frontTrackIndex = routeTracks.FindAll(x => x.Track_ID == frontTrack.Track_ID).Last();
                          rearTrackIndex = routeTracks.ToList().FindLastIndex(x => x.Track_ID == rearTrack.Track_ID); 
                    }
                    else
                    {
                          frontTrackIndex = routeTracks.ToList().FindIndex(x => x.Track_ID == frontTrack.Track_ID);
                          rearTrackIndex = routeTracks.ToList().FindIndex(x => x.Track_ID == rearTrack.Track_ID);
                    }

                    //if(frontTrack.Track_ID.ToString().StartsWith("6") || rearTrack.Track_ID.ToString().StartsWith("6"))
                    //{
                    //    return trackRangeList ;
                    //}



                    if (frontTrackIndex != -1 && rearTrackIndex != -1)
                    {
                        if (frontTrackIndex >= rearTrackIndex)
                            trackRangeList = routeTracks.Where((element, index) => (index <= frontTrackIndex) && (index >= rearTrackIndex)).Select(x => (ushort)x.Track_ID).ToList().ToArray();
                        else if (frontTrackIndex <= rearTrackIndex)
                            trackRangeList = routeTracks.Where((element, index) => (index >= frontTrackIndex) && (index <= rearTrackIndex)).Select(x => (ushort)x.Track_ID).ToList().ToArray();
                    }

                    else if (frontTrackIndex != -1 && rearTrackIndex == -1)
                    {
                        if (frontTrackIndex >= rearTrackIndex)
                            trackRangeList = routeTracks.Where((element, index) => (index <= frontTrackIndex) && (index >= frontTrackIndex - 1)).Select(x => (ushort)x.Track_ID).ToList().ToArray();
                        else if (frontTrackIndex <= rearTrackIndex)
                            trackRangeList = routeTracks.Where((element, index) => (index >= frontTrackIndex) && (index <= frontTrackIndex - 1)).Select(x => (ushort)x.Track_ID).ToList().ToArray();
                    }


                    //if (trackRangeList.Length > 15)
                    //{
                    //    trackRangeList = new ushort[15];
                    //}
                    return trackRangeList;
                }
                catch (Exception ex)
                {
                    return trackRangeList;
                }

            }

        }
    }
}
