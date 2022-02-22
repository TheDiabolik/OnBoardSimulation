using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    [Serializable]
    public class Route : IDisposable
    {
        public string Route_Name {get; set; }
        public int Route_No { get; set; }

        public int Entry_Track_ID { get; set; }

        public Track Entry_Track { get; set; } = new Track();

        public int Exit_Track_ID { get; set; }


        public Track Exit_Track { get; set; } = new Track();

        public ThreadSafeList<Track> Route_Tracks { get; set; } = new ThreadSafeList<Track>();

        public ThreadSafeList<Track> R_Tracks { get; set; } = new ThreadSafeList<Track>();
        public  double Length { get; set; }

        public Route()
        {
            
        }
        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }


        //static  
        public List<Route> AllRoute(DataTable dt, ThreadSafeList<Track> allTracks)
        {
            List<Route> routeList = new List<Route>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(row.ItemArray[0].ToString()))
                    {
                        Route route = new Route();



                        int route_No;

                        if (int.TryParse(row[0].ToString(), out route_No))
                            route.Route_No = route_No;

                        string[] routeTracks = row[1].ToString().Split('-');



                        Track rtrack;

                        for (int i = 0; i < routeTracks.Length; i++)
                        {
                            int routeTrackID = Convert.ToInt32(routeTracks[i]);

                            rtrack = allTracks.Find(x => x.Track_ID == routeTrackID).MemberwiseCopy();
                            //Track track = trackList.Find(x => x.Track_ID == routeTrackID);

                            route.Route_Tracks.Add(rtrack);
                            route.R_Tracks.Add(rtrack);
                            //route.Route_Tracks.Add(track);
                            //trackList.Add(track);
                        }




                        Track track;

                        if (int.TryParse(row[2].ToString(), out int entry_Track_ID))
                        {
                            route.Entry_Track_ID = entry_Track_ID;

                            if (route.Entry_Track_ID != 0)
                            {
                                track = allTracks.Find(x => x.Track_ID == route.Entry_Track_ID);

                                //route.Entry_Track = allTracks.Find(x => x.Track_ID == route.Entry_Track_ID); 
                                //route.Entry_Track = trackList.Find(x => x.Track_ID == route.Entry_Track_ID); 
                                if (track != null)
                                {
                                    route.Entry_Track = track.MemberwiseCopy();

                                    //ilk track ve uzunluğunu ekliyoruz
                                    route.Route_Tracks.Insert(0, route.Entry_Track);
                                    route.R_Tracks.Insert(0, route.Entry_Track);
                                    //route.Route_Tracks.Insert(0, route.Entry_Track);
                                    //route.Route_Tracks.Insert(0, route.Entry_Track);
                                    //trackList.Insert(0, route.Entry_Track);
                                    //route.Length += route.Entry_Track.Track_Length;
                                }

                            }

                        }



                        Track etrack;
                        if (int.TryParse(row[3].ToString(), out int exit_Track_ID))
                        {
                            route.Exit_Track_ID = exit_Track_ID;

                            if (route.Exit_Track_ID != 0)
                            {
                                etrack = allTracks.Find(x => x.Track_ID == route.Exit_Track_ID);

                                if (etrack != null)
                                {
                                    route.Exit_Track = etrack.MemberwiseCopy();

                                }
                            }

                            //route.Exit_Track = allTracks.Find(x => x.Track_ID == route.Exit_Track_ID);
                        }


                        double routeLength = 0;



                        //for (int i = 0; i < routeTrack.Count; i++)
                        //{
                        //    route.Route_Tracks[i].StartPositionInRoute = routeLength;
                        //    route.Route_Tracks[i].StopPositionInRoute = routeLength + route.Route_Tracks[i].Track_Length;
                        //    //routeLength = routeLength + route.Route_Tracks[i].Track_Length;
                        //    //routeLength = routeLength + route.Route_Tracks[i].Track_Length;
                        //}

                        foreach (Track item in route.Route_Tracks)
                        {
                            item.StartPositionInRoute = routeLength;
                            item.StopPositionInRoute = routeLength + item.Track_Length;
                            routeLength += item.Track_Length;
                        }

                        //route.Length = routeLength;

                        foreach (Track item in route.R_Tracks)
                        {
                            item.StartPositionInRoute = routeLength;
                            item.StopPositionInRoute = routeLength + item.Track_Length;
                            routeLength += item.Track_Length;
                        }

                        route.Length = routeLength;



                        routeList.Add(route);


                    }

                    //routeList.Add(route); 
                }


                return routeList;
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "AllRoute(DataTable dt, ThreadSafeList < Track > allTracks)");
                return routeList;
            }
        }


        public static List<Route> SimulationRoute(DataTable dt)
        {

            HashSet<string> stationName = new HashSet<string>();
            List<Route> routeList = new List<Route>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(row.ItemArray[0].ToString()))
                    {
                        stationName.Add(row[0].ToString());

                        Route route = new Route();

                        if (int.TryParse(row[1].ToString(), out int route_No))
                            route.Route_No = route_No;




                        string[] routeTracks = row[2].ToString().Split('-');



                        Track rtrack;

                        for (int i = 0; i < routeTracks.Length; i++)
                        {
                            int routeTrackID = Convert.ToInt32(routeTracks[i]);

                            //rtrack = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == routeTrackID);
                            rtrack = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == routeTrackID);
                            //Track track = trackList.Find(x => x.Track_ID == routeTrackID);

                            route.Route_Tracks.Add(rtrack);

                        }




                        Track track;

                        if (int.TryParse(row[3].ToString(), out int entry_Track_ID))
                        {
                            route.Entry_Track_ID = entry_Track_ID;

                            if (route.Entry_Track_ID != 0)
                            {
                                
                                   //track = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == route.Entry_Track_ID);
                                track = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == route.Entry_Track_ID);
                                if (track != null)
                                {
                                    route.Entry_Track = track;

                                    //ilk track ve uzunluğunu ekliyoruz
                                    route.Route_Tracks.Insert(0, route.Entry_Track);

                                }

                            }

                        }

                        Track etrack;
                        if (int.TryParse(row[4].ToString(), out int exit_Track_ID))
                        {
                            route.Exit_Track_ID = exit_Track_ID;

                            if (route.Exit_Track_ID != 0)
                            {
                                //etrack = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == route.Exit_Track_ID);
                                etrack = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == route.Exit_Track_ID);

                                if (etrack != null)
                                {
                                    route.Exit_Track = etrack;

                                }
                            }

                            //route.Exit_Track = allTracks.Find(x => x.Track_ID == route.Exit_Track_ID);
                        }



                        routeList.Add(route);
                    }
                }


                return routeList;
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "SimulationRoute(DataTable dt)");
                return routeList;
            }

        }


        public static List<Route> SimulationRouteStationToStation(DataTable dt)
        {

            HashSet<string> stationName = new HashSet<string>();
            List<Route> routeList = new List<Route>();

            try
            {

                foreach (DataRow row in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(row.ItemArray[0].ToString()))
                    {

                        Route route = new Route();


                        stationName.Add(row[0].ToString());

                        route.Route_Name = row[0].ToString();



                        if (int.TryParse(row[1].ToString(), out int route_No))
                            route.Route_No = route_No;




                        string[] routeTracks = row[2].ToString().Split('-');



                        Track rtrack;

                        for (int i = 0; i < routeTracks.Length; i++)
                        {
                            int routeTrackID = Convert.ToInt32(routeTracks[i]);

                            //rtrack = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == routeTrackID);
                            rtrack = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == routeTrackID);

                            //Track track = trackList.Find(x => x.Track_ID == routeTrackID);

                            route.Route_Tracks.Add(rtrack);

                        }




                        Track track;

                        if (int.TryParse(row[3].ToString(), out int entry_Track_ID))
                        {
                            route.Entry_Track_ID = entry_Track_ID;

                            if (route.Entry_Track_ID != 0)
                            {
                                //track = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == route.Entry_Track_ID);
                                track = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == route.Entry_Track_ID);

                                if (track != null)
                                {
                                    route.Entry_Track = track;

                                    //ilk track ve uzunluğunu ekliyoruz
                                    route.Route_Tracks.Insert(0, route.Entry_Track);

                                }

                            }

                        }

                        Track etrack;
                        if (int.TryParse(row[4].ToString(), out int exit_Track_ID))
                        {
                            route.Exit_Track_ID = exit_Track_ID;

                            if (route.Exit_Track_ID != 0)
                            {
                                //etrack = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == route.Exit_Track_ID);
                                etrack = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == route.Exit_Track_ID);

                                if (etrack != null)
                                {
                                    route.Exit_Track = etrack;

                                }
                            }

                            //route.Exit_Track = allTracks.Find(x => x.Track_ID == route.Exit_Track_ID);
                        } 

                        routeList.Add(route);
                    }
                } 

                return routeList;
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "SimulationRouteStationToStation");
                return routeList;
            }
        }





        public Track FindLast(Track startTrack, Track stopTrack, List<Track> tracks)
        {
            Track tempTrack = startTrack;

            tempTrack = tracks.Find(x => x.Track_ID == tempTrack.Track_Connection_Exit_1);

            if (tempTrack.Track_ID != stopTrack.Track_ID)
                FindLast(tempTrack, stopTrack, tracks);


            return tempTrack;


        }


        public static Route CreateNewRoute(List<Route> routes)
        {
            Route route = new Route();

            foreach (Route item in routes)
            {
                if (route.Route_Tracks.Count == 0)
                    route.Route_Tracks.AddRange(item.Route_Tracks);

            } 

            return route;
        }


        public static Route CreateNewRoute(int startTrackID, List<Route> routes)
        {
            Route route = new Route();
            try
            {
                Route entry = routes.Find(x => x.Entry_Track_ID == startTrackID);
                int index = routes.FindIndex(x => x == entry);
                List<Route> routesRange = routes.GetRange(index, routes.Count - index);


                foreach (Route item in routesRange)
                {
                    if (route.Route_Tracks.Count == 0)
                    {
                        route.Route_Tracks.AddRange(item.Route_Tracks);
                        continue;
                    }
                    else if (route.Route_Tracks.Count >= 20)
                        break;

                    foreach (Track tra in item.Route_Tracks)
                    {
                        if ((route.Route_Tracks.Count < 20))
                        {
                            bool hasTrack = route.Route_Tracks.Contains(tra);

                            if (!hasTrack)
                                route.Route_Tracks.Add(tra);
                        }
                        else if ((route.Route_Tracks.Count >= 20) && (tra.Track_ID != item.Exit_Track_ID))
                        //else if ((route.Route_Tracks.Count >= 20) && (!string.IsNullOrEmpty(tra.Station_Name)))
                        {
                            int zindex = item.Route_Tracks.ToList().FindIndex(x => x == tra);
                            List<Track> loloahmet = item.Route_Tracks.ToList().GetRange(zindex, item.Route_Tracks.Count - zindex);

                            route.Route_Tracks.AddRange(loloahmet);

                            break;
                        }
                        else
                            break;
                    }

                }


                route.Entry_Track_ID = route.Route_Tracks[0].Track_ID;
                route.Entry_Track = route.Route_Tracks[0];
                route.Exit_Track_ID = route.Route_Tracks[route.Route_Tracks.Count - 1].Track_ID;
                route.Exit_Track = route.Route_Tracks[route.Route_Tracks.Count - 1];

                double routeLength = 0;

                foreach (Track track in route.Route_Tracks)
                {
                    track.StartPositionInRoute = routeLength;
                    track.StopPositionInRoute = routeLength + track.Track_Length;
                    routeLength += track.Track_Length;
                }

                route.Length = routeLength; 
                return route;

            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "CreateNewRoute(int startTrackID, List<Route> routes)");
                return route;
            }
        }



        public static Route CreateNewRoute(int startTrackID, List<Track> routes)
        {
            Route route = new Route();
            try
            {
                Track entry = routes.Find(x => x.Track_ID == startTrackID);
            int index = routes.FindIndex(x => x == entry);
            List<Track> trackRange = routes.GetRange(index, routes.Count - index);


            route.Route_Tracks.Add(routes.ElementAt(index));

            for (int i = ++index; i < routes.Count; i++)
            {
                Track track = routes.ElementAt(i);

                route.Route_Tracks.Add(track);

                if (!string.IsNullOrEmpty(track.Station_Name))
                    break;
            }


            route.Entry_Track_ID = route.Route_Tracks.First().Track_ID;
            route.Entry_Track = route.Route_Tracks.First();
            route.Exit_Track_ID = route.Route_Tracks.Last().Track_ID;
            route.Exit_Track = route.Route_Tracks.Last();

            double routeLength = 0;

            foreach (Track track in route.Route_Tracks)
            {
                track.StartPositionInRoute = routeLength;
                track.StopPositionInRoute = routeLength + track.Track_Length;
                routeLength += track.Track_Length;
            }

            route.Length = routeLength;  



            return route;
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "CreateNewRoute(int startTrackID, List<Track> routes)");
                return route;
            }
        }

        public static Route CreateDatabaseRoute(int startTrackID, List<Track> routes)
        {
            Route route = new Route();
            try
            {
                Track entry = routes.Find(x => x.Track_ID == startTrackID);
                int index = routes.FindIndex(x => x == entry);
                List<Track> trackRange = routes.GetRange(index, routes.Count - index);


                route.Route_Tracks.Add(routes.ElementAt(index));

                for (int i = ++index; i < routes.Count; i++)
                {
                    Track track = routes.ElementAt(i);

                    route.Route_Tracks.Add(track);

                    if (entry.Track_ID == track.Track_ID)
                        break;
                }


                route.Entry_Track_ID = route.Route_Tracks.First().Track_ID;
                route.Entry_Track = route.Route_Tracks.First();
                route.Exit_Track_ID = route.Route_Tracks.Last().Track_ID;
                route.Exit_Track = route.Route_Tracks.Last();

                double routeLength = 0;

                foreach (Track track in route.Route_Tracks)
                {
                    track.StartPositionInRoute = routeLength;
                    track.StopPositionInRoute = routeLength + track.Track_Length;
                    routeLength += track.Track_Length;
                }

                route.Length = routeLength;



                return route;
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "CreateRingRoute(int startTrackID, List<Track> routes)");
                return route;
            }
        }


        //public static Track FindTrackInRoute(int trackID)
        //{

        //    Track trackSectionInYNK1_KIR2_YNK1 = MainForm.m_mf.m_WSATCMovement_YNK1_KIR2_YNK1.Find(x => x.Track_ID == trackID);

        //    if (trackSectionInYNK1_KIR2_YNK1 != null)
        //    {
        //        return trackSectionInYNK1_KIR2_YNK1;
        //    }
        //    else
        //    {
        //        Track trackSectionInYNK2_HAV2_YNK2 = MainForm.m_mf.m_YNK2_HAV2_YNK2.Find(x => x.Track_ID == trackID);

        //        return trackSectionInYNK2_HAV2_YNK2;
        //    } 
        //}


      

















        //public static Track FindTrackInRoute(int trackID, double stopPositionInRoute, Enums.Direction direction)
        //{
        //    Track ztrack = new Track();

        //    ThreadSafeList<Track> trackSectionInYNK1_KIR2_YNK1 = MainForm.m_mf.m_WSATCMovement_YNK1_KIR2_YNK1.FindAll(x => x.Track_ID == trackID && x.StartPositionInRoute == stopPositionInRoute);


        //    if(trackSectionInYNK1_KIR2_YNK1.Count >= 1)
        //    {
        //        if (direction == Enums.Direction.Right)
        //            ztrack = trackSectionInYNK1_KIR2_YNK1.First();
        //        else if (direction == Enums.Direction.Left)
        //            ztrack = trackSectionInYNK1_KIR2_YNK1.Last();
        //    }
        //    else
        //    {
        //        ThreadSafeList<Track> trackSectionInYNK2_HAV2_YNK2 = MainForm.m_mf.m_YNK2_HAV2_YNK2.FindAll(x => x.Track_ID == trackID && x.StartPositionInRoute == stopPositionInRoute);

        //        if (trackSectionInYNK2_HAV2_YNK2.Count >= 1)
        //        {
        //            if (direction == Enums.Direction.Right)
        //                ztrack = trackSectionInYNK2_HAV2_YNK2.First();
        //            else if (direction == Enums.Direction.Left)
        //                ztrack = trackSectionInYNK2_HAV2_YNK2.Last();
        //        } 
        //    }



        //    return ztrack;



        //    //if (trackSectionInYNK1_KIR2_YNK1 != null)
        //    //{
        //    //    return trackSectionInYNK1_KIR2_YNK1;
        //    //}
        //    //else
        //    //{
        //    //    ThreadSafeList<Track> trackSectionInYNK2_HAV2_YNK2 = MainForm.m_mf.m_YNK2_HAV2_YNK2.Find(x => x.Track_ID == trackID && x.StartPositionInRoute == stopPositionInRoute);

        //    //    return trackSectionInYNK2_HAV2_YNK2;
        //    //}
        //}


        public static ThreadSafeList<Track>  CreateMovementTracksStationToStation(int startTrackID, List<Track> YNK1_KIR2_YNK1, List<Track> m_YNK2_HAV2_YNK2, bool circle)
        {
            ThreadSafeList<Track> movementTrack = new ThreadSafeList<Track>();
            try
            {
                Track entry;
                List<Track> circleRouteTracks = new List<Track>(); 
                

                if(circle)
                {
                    entry = YNK1_KIR2_YNK1.Find(x => x.Track_ID == startTrackID);

                    if (entry != null)
                    {
                        circleRouteTracks = YNK1_KIR2_YNK1;
                    }
                }
                else
                {
                    entry = m_YNK2_HAV2_YNK2.Find(x => x.Track_ID == startTrackID);

                    if (entry != null)
                    {
                        circleRouteTracks = m_YNK2_HAV2_YNK2;
                    } 
                }

               

              

                int index = circleRouteTracks.FindIndex(x => x == entry);
                List<Track> trackRange = circleRouteTracks.GetRange(index, circleRouteTracks.Count - index); 

                movementTrack.Add(circleRouteTracks.ElementAt(index));

                for (int i = ++index; i < circleRouteTracks.Count; i++)
                {
                    Track track = circleRouteTracks.ElementAt(i);

                    movementTrack.Add(track);

                    if (!string.IsNullOrEmpty(track.Station_Name))
                        break;
                } 
 

                return movementTrack;
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "CreatemovementTracksStationToStation(int startTrackID, List<Track> database)");
                return movementTrack;
            }
        }


        public static Route CreateRingRoute(int startTrackID, List<Track> routes)
        {
            Route route = new Route();
            try
            {
                Track entry = routes.Find(x => x.Track_ID == startTrackID);
                int index = routes.FindIndex(x => x == entry);
                List<Track> trackRange = routes.GetRange(index, routes.Count - index);


                route.Route_Tracks.Add(routes.ElementAt(index));

                for (int i = ++index; i < routes.Count; i++)
                {
                    Track track = routes.ElementAt(i);

                    route.Route_Tracks.Add(track);

                    if (entry.Track_ID == track.Track_ID)
                        break;
                }


                route.Entry_Track_ID = route.Route_Tracks.First().Track_ID;
                route.Entry_Track = route.Route_Tracks.First();
                route.Exit_Track_ID = route.Route_Tracks.Last().Track_ID;
                route.Exit_Track = route.Route_Tracks.Last();

                double routeLength = 0;

                foreach (Track track in route.Route_Tracks)
                {
                    track.StartPositionInRoute = routeLength;
                    track.StopPositionInRoute = routeLength + track.Track_Length;
                    routeLength += track.Track_Length;
                }

                route.Length = routeLength;



                return route;
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "CreateRingRoute(int startTrackID, List<Track> routes)");
                return route;
            }
        }



        public static Route CreateNewRouteStationToStation(int startTrackID, List<Route> routes)
        {
            HashSet<string> stationNames = new HashSet<string>();
            List<KeyValuePair<string, Route>> stationToStationRoute = new List<KeyValuePair<string, Route>>();
            Route routez = new Route();
            try
            {

                Route entryRoute = routes.Find(x => x.Entry_Track_ID == startTrackID && !string.IsNullOrEmpty(x.Route_Name));
                int index = routes.FindIndex(x => x == entryRoute);

                foreach (Route item in routes)
                {
                    stationNames.Add(item.Route_Name);
                }


                foreach (string stationName in stationNames)
                {
                    if (stationName == entryRoute.Route_Name)
                    {
                        string entryStation = stationName.Split('-')[0];
                        string exitStation = stationName.Split('-')[1];


                        List<Route> bulduk = routes.FindAll(x => x.Route_Name == stationName);


                        foreach (Route item in bulduk)
                        {
                            foreach (Track trackitem in item.Route_Tracks)
                            {
                                if (!routez.Route_Tracks.Contains(trackitem))
                                    routez.Route_Tracks.Add(trackitem);
                            }
                        }


                        Track entryTrack = routez.Route_Tracks.Find(x => x.Station_Name == entryStation);
                        Track exitTrack = routez.Route_Tracks.Find(x => x.Station_Name == exitStation);
                        //stationToStationRoute.Add(new KeyValuePair<string, Route>(stationName, bulduk));


                        routez.Entry_Track_ID = entryTrack.Track_ID;
                        routez.Entry_Track = entryTrack;
                        routez.Exit_Track_ID = exitTrack.Track_ID;
                        routez.Exit_Track = exitTrack;

                        double routezLength = 0;

                        foreach (Track track in routez.Route_Tracks)
                        {
                            track.StartPositionInRoute = routezLength;
                            track.StopPositionInRoute = routezLength + track.Track_Length;
                            routezLength += track.Track_Length;
                        }

                        routez.Length = routezLength; 

                        routez.Route_Name = stationName;
                    } 
                }


                return routez;

            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "CreateNewRouteStationToStation");
                return routez;
            }
        }


        public static Route CreateNewRoute(int startTrackID, int stopTrackID, ThreadSafeList<Track> tracks)
        {
            Route route = new Route();
            try
            {
                //List<Track> routeList = new List<Track>();

                //Track startTrack = tracks.Find(x => x.Track_ID == startTrackID).MemberwiseCopy();
                Track startTrack = tracks.Find(x => x.Track_ID == startTrackID);
                route.Route_Tracks.Add(startTrack);

                Track tempTrack = startTrack;

                do
                {
                    //if (startTrack.Track_ID < stopTrackID)
                    //    tempTrack = tracks.Find(x => x.Track_ID == tempTrack.Track_Connection_Exit_1).MemberwiseCopy();
                    //else
                    //    tempTrack = tracks.Find(x => x.Track_ID == tempTrack.Track_Connection_Entry_1).MemberwiseCopy();

                    if (startTrack.Track_ID < stopTrackID)
                        tempTrack = tracks.Find(x => x.Track_ID == tempTrack.Track_Connection_Exit_1);
                    else
                        tempTrack = tracks.Find(x => x.Track_ID == tempTrack.Track_Connection_Entry_1);

                    //Length += tempTrack.Track_Length;

                    route.Route_Tracks.Add(tempTrack);
                }
                while (tempTrack.Track_ID != stopTrackID);


                //Track exitTrack = tracks.Find(x => x.Track_ID == stopTrackID).MemberwiseCopy();
                Track exitTrack = tracks.Find(x => x.Track_ID == stopTrackID);




                double routeLength = 0;
                //double routeLength = route.Route_Tracks[0].Track_Start_Position;


                foreach (Track track in route.Route_Tracks)
                {
                    track.StartPositionInRoute = routeLength;
                    track.StopPositionInRoute = routeLength + track.Track_Length;
                    routeLength += track.Track_Length;

                    //routeLength += track.Track_End_Position - track.Track_Start_Position;
                }

                //foreach (Track track in route.Route_Tracks)
                //{
                //    track.StartPositionInRoute = track.Track_Start_Position;
                //    track.StopPositionInRoute = track.Track_End_Position;
                //    routeLength += track.Track_Length;

                //    //routeLength += track.Track_End_Position - track.Track_Start_Position;
                //}

                //foreach (Track track in route.Route_Tracks)
                //{
                //    track.StartPositionInRoute = track.Track_Start_Position;
                //    track.StopPositionInRoute = track.Track_End_Position;
                //    routeLength += track.Track_Length;
                //}

                route.Length = routeLength;



                route.Entry_Track_ID = startTrackID;
                route.Entry_Track = startTrack;
                route.Exit_Track_ID = stopTrackID;
                route.Exit_Track = exitTrack;
                //route.Route_Tracks = route.Route_Tracks;

                return route;

            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "CreateNewRoute");
                return route;
            }
        }

 

        public double FindTrainLocationInRoute(Enums.Direction direction, Track frontOfTheTrainTrack, double frontOfTheTrainWithFault)
        {
            double frontTrainLocationInRoute = 0;

            //if(direction = Enums.Direction.One)
            //    frontTrainLocationInRoute = frontOfTheTrainTrack.


            return frontTrainLocationInRoute;
        }



        public static void CreateNewRoute(Route route)
        {
            double routeLength = 0;


            foreach (Track track in route.Route_Tracks)
            {
                track.StartPositionInRoute = routeLength;
                track.StopPositionInRoute = routeLength + track.Track_Length;
                routeLength += track.Track_Length;
            }

            route.Length = routeLength;


            routeLength = 0;
        }
    }
}

