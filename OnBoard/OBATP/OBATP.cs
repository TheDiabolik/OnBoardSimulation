using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnBoard
{
    [Serializable]
    public partial class OBATP : IWSATP_TO_OBATPMessageWatcher, IATS_TO_OBATO_InitMessageWatcher, IATS_TO_OBATO_MessageWatcher, IATS, IWSATC, IDisposable
    {

      
        public void RequestStartProcess()
        {
            this.Status = Enums.Status.Start;

            //m_shouldStop = false;


            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);


            //double deneme = (Convert.ToDouble(m_settings.OperationTimeCycle) / 1000);

            OperationTime = (Convert.ToDouble(m_settings.OperationTimeCycle) / 1000);

            //ManageMessageSendTimer();
            //ManageUIRefreshTimer();


            m_OBATCTimer.Change(0, m_settings.OBATCWorkingCycle);


            m_messageSendStopwatch.Start();
            m_UIRefreshStopwatch.Start();


            m_messageSendTimer.Change(0, m_settings.MessageSendWorkingCycle);
            m_UIRefreshTimer.Change(0, m_settings.UIRefreshWorkingCycle);
            //StartProcess(null);
        }


        //public void RequestStartProcess()
        //{
        //    this.Status = Enums.Status.Start;

        //    m_shouldStop = false;


        //    m_settings = XMLSerialization.Singleton();
        //    m_settings = m_settings.DeSerialize(m_settings);

        //    Thread thread = new Thread(new ParameterizedThreadStart(StartProcess));
        //    thread.IsBackground = true;
        //    thread.Start(); 

        //    //StartProcess(null);
        //}




        public void RequestStopProcess()
        {
            //m_shouldStop = true;

            this.Status = Enums.Status.Stop;


            m_OBATCTimer.Change(Timeout.Infinite, Timeout.Infinite);

            m_messageSendTimer.Change(Timeout.Infinite, Timeout.Infinite);
            m_UIRefreshTimer.Change(Timeout.Infinite, Timeout.Infinite);


            if (m_doorTimer != null)
                m_doorTimer.Stop();
        }



        //public void RequestStopProcess()
        //{
        //    m_shouldStop = true;

        //    this.Status = Enums.Status.Stop;

        //    if (m_doorTimer != null)
        //        m_doorTimer.Stop();
        //}

        public double TotalOperationTime { get; set; }

        //internal  readonly object zozo = new object();
        public void StartProcess(object o)
        {
            try
            {
                //lock (zozo)
                {
                    //if (Math.Round(FrontOfTrainLocationWithFootPrintInRoute) <= m_route.Length)



                    //if (FrontOfTrainNextTrack != MovementAuthorityTrack)

                    if (movementTrack.Count > 0)

                    {
                        //routeCompleted = true;

                        //istasyon sürelerini ölçmek için kullanılıyor...

                        //if (this.Vehicle.TrainID == Enums.Train_ID.Train1)
                        //{
                        //    if (DoorStatus == Enums.DoorStatus.Close)
                        //        TotalOperationTime += OperationTime;
                        //    else if (DoorStatus == Enums.DoorStatus.Open)
                        //    {
                        //        if (TotalOperationTime != 0)
                        //        {
                        //            //if (!string.IsNullOrEmpty(openStation) && !string.IsNullOrEmpty(closeStation))
                        //            if (!string.IsNullOrEmpty(openStation) && !string.IsNullOrEmpty(closeStation) && openStation != "DEPO" && closeStation != "DEPO")
                        //            {
                        //                //Logging.WriteStationTimeLog(closeStation, openStation, TotalOperationTime.ToString());

                        //                //int ahmet = Convert.ToInt32(TotalOperationTime);
                        //                //string zamanstrin = Convert.ToString(ahmet);

                        //                //Logging.WriteStationDateTimeLog(closeStation, openStation, TotalOperationTime.ToString(), closeStationDateTime, openStationDateTime, 
                        //                //    dneme.Elapsed.TotalSeconds.ToString());

                        //            }
                                    

                        //            TotalOperationTime = 0;
                        //        }


                        //    }
                        //}



                        //Direction = FindDirection(m_route.Route_Tracks, Direction);
                        Direction = FindDirection(movementTrack, Direction);


                        //trenin arkası ve önü için bir sonraki tracki verir
                        FrontOfTrainNextTrack = FindNextTrack(ActualFrontOfTrainCurrent.Track, Direction);
                        RearOfTrainNextTrack = FindNextTrack(ActualRearOfTrainCurrent.Track, Direction);

                        //trenin frenleme mesafesi hesaplaması
                        Vehicle.BrakingDistance = CalculateBrakingDistance(this.Vehicle.MaxTrainDeceleration, this.Vehicle.CurrentTrainSpeedCMS);


                        //trenin konumundaki hata payını bulma
                        this.FrontOfTrainLocationWithFootPrintInRoute = FindPositionFootPrintFront(ActualFrontOfTrainCurrent, Direction, movementTrack);
                        //this.RearOfTrainLocationWithFootPrintInRoute = FindPositionFootPrintRear(RearOfTrainCurrentTrack, RearDirection, m_route.Route_Tracks);
                        this.RearOfTrainLocationWithFootPrintInRoute = FindPositionFootPrintRear(ActualRearOfTrainCurrent, Direction, movementTrack);

                        //sanal meşguliyet hesaplama
                        this.FrontOfTrainVirtualOccupation = FindFrontVirtualOccupation(movementTrack, Direction);
                        //this.RearOfTrainVirtualOccupation = FindRearVirtualOccupation(m_route.Route_Tracks, RearDirection, MainForm.allTracks);
                        this.RearOfTrainVirtualOccupation = FindRearVirtualOccupation(movementTrack, Direction);


                        double? isTargetSpeed = FindTargetSpeed(movementTrack, ActualFrontOfTrainCurrent.Track, ActualRearOfTrainCurrent.Track, this.Vehicle);

                        if (isTargetSpeed.HasValue)
                            this.Vehicle.TargetSpeedKMH = isTargetSpeed.Value;
                        //else
                        //    this.Vehicle.TargetSpeedKMH = 0;


                        this.Vehicle.CurrentAcceleration = ManageAcceleration(this.Vehicle.CurrentTrainSpeedCMS, this.Vehicle, ActualFrontOfTrainCurrent.Track.MaxTrackSpeedCMS);

                        //this.Vehicle.CurrentTrainSpeedCMS = CalculateSpeed(this.Vehicle);

                        this.Vehicle = CalculateSpeed(this.Vehicle);



                        Tuple<TrackWithPosition, TrackWithPosition> calculateTrainLocationInTrack = CalculateTrainLocationInTrack(Vehicle, ActualFrontOfTrainCurrent, FrontOfTrainNextTrack, Direction,
                              ActualRearOfTrainCurrent, RearOfTrainNextTrack);

                        this.ActualFrontOfTrainCurrent = calculateTrainLocationInTrack.Item1;
                        this.ActualRearOfTrainCurrent = calculateTrainLocationInTrack.Item2;



                        //süreleri hesaplamak için eklanen test kısmı


                        //if (this.Vehicle.TrainID == Enums.Train_ID.Train1)
                        //{
                        //    if(closeStation != this.ActualFrontOfTrainCurrent.Track.Station_Name)
                        //    {
                        //        dneme.Stop();
                        //        openStationDateTime = DateTime.Now;
                        //        openStation = ActualFrontOfTrainCurrent.Track.Station_Name;
                        //    } 
                        //}




                        //this.ActualFrontOfTrainCurrent = CalculateLocationInTrack(ActualFrontOfTrainCurrent.Track, FrontOfTrainNextTrack, Direction, Vehicle, this.ActualFrontOfTrainCurrent.Location);
                        ////this.ActualRearOfTrainCurrent = CalculateLocationInTrack(ActualRearOfTrainCurrent.Track, RearOfTrainNextTrack, Direction, Vehicle, this.ActualRearOfTrainCurrent.Location);

                        //if (!m_shouldStopRear)
                        //{
                        //    //Tuple<double, Track> rearCurrent = CalculateLocation(RearOfTrainCurrentTrack, RearOfTrainNextTrack, RearDirection, Vehicle, ActualRearOfTrainCurrentLocation);
                        //    this.ActualRearOfTrainCurrent = CalculateLocationInTrack(ActualRearOfTrainCurrent.Track, RearOfTrainNextTrack, Direction, Vehicle, this.ActualRearOfTrainCurrent.Location);//ActualRearOfTrainCurrentLocation);

                        //}




                        #region WSATC
                        //WSATC method
                        //CheckBerthingStatus();
                        //CheckTrainAbsoluteZeroSpeed();
                        #endregion


                        //skiple hold station mesajları düzenlemek için
                        DenemeFrontOfTrainCurrentTrack = ActualFrontOfTrainCurrent.Track;

                        //hareket listesinden silmek için deneme yapıldığı kısım burada başlıyor
                        DenemeRearOfTrainCurrentTrack =  RearOfTrainTrackWithFootPrint.Track;


                        //MainForm.m_trainObserver.TrainMovementUI(this, new OBATPUIAdapter(this)); 
                    }


                    #region WSATC
                    //WSATC method
                    CheckBerthingStatus(this.Vehicle.CurrentTrainSpeedCMS);
                    //CheckBerthingStatus(this.Vehicle.CurrentTrainSpeedCMS, this.DwellTimeFinished);
                    CheckTrainAbsoluteZeroSpeed();
                    #endregion


                    //if (m_messageSendStopwatch.Elapsed.TotalMilliseconds >= m_settings.MessageSendWorkingCycle)
                    //    m_messageSendTimer.Change(0, Timeout.Infinite);


                    //if (m_UIRefreshStopwatch.Elapsed.TotalMilliseconds >= m_settings.UIRefreshWorkingCycle)
                    //    m_UIRefreshTimer.Change(0, Timeout.Infinite);

                    //if (m_messageSendStopwatch.Elapsed.TotalMilliseconds >= m_settings.MessageSendWorkingCycle)
                    //m_messageSendTimer.Change(0, Timeout.Infinite);


                    //if (m_UIRefreshStopwatch.Elapsed.TotalMilliseconds >= m_settings.UIRefreshWorkingCycle)
                    //m_UIRefreshTimer.Change(0, Timeout.Infinite);


                    //m_messageSendTimer.Change(0, Timeout.Infinite);


                    //MainForm.m_trainObserver.TrainMovementSendMessageCreated(this);

                    //ui göstermek için ui propertyleri burada set ediliyor
                    //bu kısım vakit olduğunda farklı bir mekanizma ile tekrar yazılacak

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

                }

            }
            catch (ThreadInterruptedException ex)
            {
                //m_controlOBATCTimer = false;
                //ManageOBATCTimer();

                //Debug.WriteLine("OBATCTimer1 : " + ex.Message.ToString() + ex.StackTrace.ToString() + ex.TargetSite.ToString());
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "OBATCTimer1");

            }
            catch (Exception ex)
            {
                //m_controlOBATCTimer = false;
                //ManageOBATCTimer();
                //Debug.WriteLine("OBATCTimer2 : " + ex.Message.ToString() + ex.StackTrace.ToString() + ex.TargetSite.ToString());
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "OBATCTimer2");
            }
        } 


     
      


        //bu metotun özelliği hem yeni trackı hem konumunu bulması
        public double FindPositionFootPrintFront(TrackWithPosition frontFootPrintTrackWithPosition, Enums.Direction direction, ThreadSafeList<Track> route)
        {
            double frontTrainLocationInRouteWithFootPrint = -1;


            //if (m_trainStop)
            //    return frontTrainLocationInRouteWithFootPrint = this.FrontOfTrainLocationWithFootPrintInRoute - 200;


            //FrontOfTrainTrackWithFootPrint.Track 


            // FrontTrainLocationFault değeri belirli aralıklarla artacak hata payı ortaya çıkacak, RFID tag okununca sıfırlanacak 
            //if (route.Count != 0)
            {
                if (direction == Enums.Direction.Right)
                {

                  


                    // Kendi Track'ini aştığında 
                    //yeni tracke geçtiğinde
                    if (frontFootPrintTrackWithPosition.Location + FrontOfTrainLocationFault >= frontFootPrintTrackWithPosition.Track.Track_Length)
                    //if ((frontFootPrintTrackWithPosition.Location + FrontOfTrainLocationFault >= frontFootPrintTrackWithPosition.Track.Track_Length) && (FrontOfTrainNextTrack != null))
                    {

                        if (FrontOfTrainTrackWithFootPrint.Track.Track_ID != FrontOfTrainNextTrack.Track_ID)
                        {
                            FrontOfTrainTrackWithFootPrint.Location = frontFootPrintTrackWithPosition.Location + FrontOfTrainLocationFault - frontFootPrintTrackWithPosition.Track.Track_Length;

                            FrontOfTrainTrackWithFootPrint.Track = FrontOfTrainNextTrack;

                            //if (m_trainStop)
                            //    return frontTrainLocationInRouteWithFootPrint = this.FrontOfTrainLocationWithFootPrintInRoute-200;
                            //else
                                frontTrainLocationInRouteWithFootPrint = FrontOfTrainTrackWithFootPrint.Track.StartPositionInRoute + FrontOfTrainTrackWithFootPrint.Location;

                        }
                        else
                        {
                            return frontTrainLocationInRouteWithFootPrint = this.FrontOfTrainLocationWithFootPrintInRoute ;
                        }


                        //frontTrainLocationInRouteWithFootPrint = FrontOfTrainTrackWithFootPrint.Track.StartPositionInRoute + FrontOfTrainTrackWithFootPrint.Location;
                    }
                    //else if ((frontFootPrintTrackWithPosition.Location + FrontOfTrainLocationFault >= frontFootPrintTrackWithPosition.Track.Track_Length) && (FrontOfTrainNextTrack == null))
                    //{
                    //    //böle olunca kendi konumu mu?
                    //    FrontOfTrainTrackWithFootPrint.Location = frontFootPrintTrackWithPosition.Location;

                    //    FrontOfTrainTrackWithFootPrint.Track = frontFootPrintTrackWithPosition.Track;
                    //}

                    //else if ((frontFootPrintTrackWithPosition.Location + FrontOfTrainLocationFault <= frontFootPrintTrackWithPosition.Track.Track_Length))
                    else
                    {
                        //içinde bulunduğu trackte ilerliyorsa
                        FrontOfTrainTrackWithFootPrint.Track = frontFootPrintTrackWithPosition.Track;
                        //böle değil
                        // FrontOfTrainTrackWithFootPrint.Location = ActualFrontOfTrainCurrentLocation + FrontOfTrainLocationFault;
                        //böle olmalısın
                        FrontOfTrainTrackWithFootPrint.Location = frontFootPrintTrackWithPosition.Location + FrontOfTrainLocationFault;// + track.Track_Start_Position;

                        //if (m_trainStop)
                        //    return frontTrainLocationInRouteWithFootPrint = this.FrontOfTrainLocationWithFootPrintInRoute-200;
                        //else
                            frontTrainLocationInRouteWithFootPrint = FrontOfTrainTrackWithFootPrint.Track.StartPositionInRoute + FrontOfTrainTrackWithFootPrint.Location;



                    }

                    //if (FrontOfTrainNextTrack != null)
                    //{
                    //    //burası incelenecek çünkü başlangıç pozisyonları sıfırdan başlamıyor
                    //    frontTrainLocationInRouteWithFootPrint = FrontOfTrainTrackWithFootPrint.Track.StartPositionInRoute + FrontOfTrainTrackWithFootPrint.Location;
                    //}


                    //frontTrainLocationInRouteWithFootPrint = FrontOfTrainTrackWithFootPrint.Track.StartPositionInRoute + FrontOfTrainTrackWithFootPrint.Location;



                    //FootPrintInTrackFrontOfTrainLocation = ActualFrontOfTrainCurrent.Location + FrontOfTrainLocationFault;

                    //frontTrainLocationInRouteWithFootPrint =  FrontOfTrainTrackWithFootPrint.Location;
                }
                else if (direction == Enums.Direction.Left)
                {



                    // Kendi Track'ini aşmışsa
                    //if (ActualFrontOfTrainCurrent.Location - FrontOfTrainLocationFault <= track.Track_Start_Position)
                    if (frontFootPrintTrackWithPosition.Location - FrontOfTrainLocationFault <= 0)
                    //if (frontFootPrintTrackWithPosition.Location - FrontOfTrainLocationFault <= 0 && (FrontOfTrainNextTrack != null))
                    {
                        if (FrontOfTrainTrackWithFootPrint.Track.Track_ID != FrontOfTrainNextTrack.Track_ID)
                        {

                            FrontOfTrainTrackWithFootPrint.Track = FrontOfTrainNextTrack;
                            FrontOfTrainTrackWithFootPrint.Location = FrontOfTrainTrackWithFootPrint.Track.Track_Length + (frontFootPrintTrackWithPosition.Location - FrontOfTrainLocationFault);


                            frontTrainLocationInRouteWithFootPrint = FrontOfTrainTrackWithFootPrint.Track.StartPositionInRoute + FrontOfTrainTrackWithFootPrint.Track.Track_Length - FrontOfTrainTrackWithFootPrint.Location;
                        }
                    }
                    else
                    {
                        FrontOfTrainTrackWithFootPrint.Track = frontFootPrintTrackWithPosition.Track;
                        FrontOfTrainTrackWithFootPrint.Location = frontFootPrintTrackWithPosition.Location - FrontOfTrainLocationFault;


                        frontTrainLocationInRouteWithFootPrint = FrontOfTrainTrackWithFootPrint.Track.StartPositionInRoute + FrontOfTrainTrackWithFootPrint.Track.Track_Length - FrontOfTrainTrackWithFootPrint.Location;
                    }

                    //burası incelenecek çünkü başlangıç pozisyonları sıfırdan başlamıyor
                    //frontTrainLocationInRouteWithFootPrint = FrontOfTrainTrackWithFootPrint.Track.StartPositionInRoute + FrontOfTrainTrackWithFootPrint.Track.Track_End_Position - FrontOfTrainTrackWithFootPrint.Location;

                    //frontTrainLocationInRouteWithFootPrint = FrontOfTrainTrackWithFootPrint.Track.StartPositionInRoute + FrontOfTrainTrackWithFootPrint.Track.Track_Length - FrontOfTrainTrackWithFootPrint.Location;
                }
            }

            return frontTrainLocationInRouteWithFootPrint - FrontOfTrainLocationFault;

        }

        public double FindPositionFootPrintRear(TrackWithPosition rearFootPrintTrackWithPosition, Enums.Direction direction, ThreadSafeList<Track> route) //bu incelenecek
        {
            double rearTrainLocationInRouteWithFootPrint = 0;
            // FrontTrainLocationFault değeri belirli aralıklarla artacak hata payı ortaya çıkacak, RFID tag okununca sıfırlanacak





            //if (m_trainStop)
            //    return rearTrainLocationInRouteWithFootPrint = this.RearOfTrainLocationWithFootPrintInRoute;

            //if (route.Count != 0)
            {
                if (direction == Enums.Direction.Right)
                {

                    if (rearFootPrintTrackWithPosition.Location - RearOfTrainLocationFault > rearFootPrintTrackWithPosition.Track.Track_End_Position)
                    {
                        // Track rearFootPrintTrack = route.Find(x => x == track);

                        Track rearFootPrintTrack = route.Find(x => x.Track_ID == rearFootPrintTrackWithPosition.Track.Track_ID);


                        if (rearFootPrintTrack != null)
                        {
                            RearOfTrainTrackWithFootPrint.Track = rearFootPrintTrack;
                            RearOfTrainTrackWithFootPrint.Location = RearOfTrainTrackWithFootPrint.Track.Track_End_Position + (rearFootPrintTrackWithPosition.Location - RearOfTrainLocationFault);
                            //RearOfTrainTrackWithFootPrint.Location = RearOfTrainTrackWithFootPrint.Track.Track_End_Position + (ActualRearOfTrainCurrent.Location - RearOfTrainLocationFault);
                        }
                    }
                    else
                    {
                        RearOfTrainTrackWithFootPrint.Track = rearFootPrintTrackWithPosition.Track;
                        RearOfTrainTrackWithFootPrint.Location = ActualRearOfTrainCurrent.Location - RearOfTrainLocationFault;
                        //rearTrainLocationInRouteWithFootPrint = rearFootPrintTrackWithPosition.Location - RearOfTrainLocationFault;
                    }
                 


                    //burası
                    rearTrainLocationInRouteWithFootPrint = RearOfTrainTrackWithFootPrint.Track.StartPositionInRoute + RearOfTrainTrackWithFootPrint.Location;


                    //if (ActualRearCurrentLocation - RearOfTrainLocationFault < track.Track_Start_Position)
                    ////if (ActualRearCurrentLocation - RearOfTrainLocationFault < track.StartPositionInRoute)
                    //{
                    //    Track rearFootPrintTrack = route.Find(x => x == track);

                    //    if (rearFootPrintTrack != null)
                    //    {
                    //        RearOfTrainTrackWithFootPrint.Track = rearFootPrintTrack;
                    //        RearOfTrainTrackWithFootPrint.Location = RearOfTrainTrackWithFootPrint.Track.Track_End_Position + (ActualRearCurrentLocation - RearOfTrainLocationFault);
                    //    }
                    //}
                    //else
                    //{
                    //    RearOfTrainTrackWithFootPrint.Track = track;
                    //    rearTrainLocationInRouteWithFootPrint = ActualRearCurrentLocation - RearOfTrainLocationFault;
                    //}
                }
                else if (direction == Enums.Direction.Left)
                {
                    //if (ActualRearOfTrainCurrent.Location + RearOfTrainLocationFault > track.Track_End_Position)
                    if (((rearFootPrintTrackWithPosition.Location + RearOfTrainLocationFault) ) > rearFootPrintTrackWithPosition.Track.Track_Length)
                    { 
                        Track rearFootPrintTrack = route.Find(x => x.Track_ID == rearFootPrintTrackWithPosition.Track.Track_ID);

                        if (rearFootPrintTrack != null)
                        {
                            RearOfTrainTrackWithFootPrint.Track = rearFootPrintTrack;
                            rearTrainLocationInRouteWithFootPrint = (rearFootPrintTrackWithPosition.Location + RearOfTrainLocationFault) - rearFootPrintTrackWithPosition.Track.Track_End_Position;
                           
                        }
                    }
                    else
                    {
                        RearOfTrainTrackWithFootPrint.Track = rearFootPrintTrackWithPosition.Track;
                        RearOfTrainTrackWithFootPrint.Location = rearFootPrintTrackWithPosition.Location + RearOfTrainLocationFault;
                        rearTrainLocationInRouteWithFootPrint = rearFootPrintTrackWithPosition.Location + RearOfTrainLocationFault;
                    }
                }
            }

            return rearTrainLocationInRouteWithFootPrint;
        }



        /// <summary>
        /// Trenin sanal meşguliyet konumunu hesaplar.
        /// </summary>
        public TrackWithPosition FindFrontVirtualOccupation(ThreadSafeList<Track> routeTracks, Enums.Direction direction)
        {
            TrackWithPosition frontOfTrainVirtualOccupation = new TrackWithPosition();


            if (routeTracks.Count != 0)
            {
                if (direction == Enums.Direction.Right)
                {
                    double frontOfTrainVirtualOcc = this.ActualFrontOfTrainCurrent.Location + this.FrontOfTrainLocationFault + this.Vehicle.BrakingDistance;

                    //tren başladığı trackin içindeyse
                    //if (frontOfTrainVirtualOccupation <= FrontOfTrainCurrentTrack.Track_End_Position)
                    if (frontOfTrainVirtualOcc <= ActualFrontOfTrainCurrent.Track.Track_Length)
                    {
                        frontOfTrainVirtualOccupation.Track = ActualFrontOfTrainCurrent.Track;
                        frontOfTrainVirtualOccupation.Location = frontOfTrainVirtualOcc;
                    }
                    else //trenin sanal meşguliyetli uzunluk bilgisi ile yeni tracke geçiyor
                    { 

                        //double distanceToFinishCurrentTrack = FrontOfTrainCurrentTrack.Track_End_Position - ActualFrontOfTrainCurrentLocation;
                        double distanceToFinishCurrentTrack = ActualFrontOfTrainCurrent.Track.Track_Length - ActualFrontOfTrainCurrent.Location;
                        double totalMovementDistance = FrontOfTrainNextTrack.Track_Length + distanceToFinishCurrentTrack;
                        double breakingDistanceWithFault = FrontOfTrainLocationFault + Vehicle.BrakingDistance;

                        //hata payı olmadan gidilmesi gereken toplam mesafe DEN hata payı ekli fren mesafesi büyük mü? yani tren bu anda frene bassa durmaz..
                        //frenleyince durma mesafesi kalan mesafeden büyükse
                        //if (breakingDistanceWithFault >= totalMovementDistance)
                        if ((breakingDistanceWithFault >= totalMovementDistance) )
                        {
                            //double de = virtualOccupationFrontTrackLocation - CurrentTrack.TrackEndPosition - NextTrack.TrackEndPosition;
                            //double totalMovementDistanceWithVirtualOccupation = frontOfTrainVirtualOccupation - (FrontOfTrainCurrentTrack.Track_End_Position + FrontOfTrainNextTrack.Track_End_Position);
                            double totalMovementDistanceWithVirtualOccupation = frontOfTrainVirtualOcc - (ActualFrontOfTrainCurrent.Track.Track_Length + FrontOfTrainNextTrack.Track_Length);

                            //trenin sanal meşguliyet uzunluğu kalan tracklerim mesadesinden fazlaysa
                            //trenin gidebileceği kalan mesafe
                            if (totalMovementDistanceWithVirtualOccupation >= 0)
                                frontOfTrainVirtualOccupation.Location = totalMovementDistanceWithVirtualOccupation;
                            else
                                frontOfTrainVirtualOccupation.Location = 0;

                            //frenleme mesafesi current ve nexttrack toplamından daha büyükse nexttrackten bir sonraki tracki next track olarak atıyoruz


                            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                            //int nextTrackID = FrontOfTrainNextTrack.Track_Connection_Exit_1;
                            //frontOfTrainVirtualOccupation.Track = MainForm.m_mf.m_allTracks.Find(x => x.Track_ID == nextTrackID);
                            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


                            //if (FrontOfTrainNextTrack != null)
                            //{
                            //    Track nextOne = FindNextTrack(FrontOfTrainNextTrack, Direction);
                            //    frontOfTrainVirtualOccupation.Track = nextOne;
                            //}
                            //else
                            //{
                                Track nextOne = FindNextTrack(FrontOfTrainNextTrack, Direction);
                                frontOfTrainVirtualOccupation.Track = nextOne;
                            //}

                        }
                        else
                        {
                            //double passingDistanceToCurrentTrack = frontOfTrainVirtualOccupation - FrontOfTrainCurrentTrack.Track_End_Position;
                            double passingDistanceToCurrentTrack = frontOfTrainVirtualOcc - ActualFrontOfTrainCurrent.Track.Track_Length;

                            //tren currenttracki ne kadar geçti
                            if (passingDistanceToCurrentTrack >= 0)
                                frontOfTrainVirtualOccupation.Location = passingDistanceToCurrentTrack; //doğal olarak currenttracki geçtiği mesafe nexttrackin içindeki yeni mesafe
                            else
                                frontOfTrainVirtualOccupation.Location = 0;



                            frontOfTrainVirtualOccupation.Track = FrontOfTrainNextTrack;
                        }

                    }
                }
                else if(direction == Enums.Direction.Left)
                {
                    double virtualOccupationFrontTrackLocation = this.ActualFrontOfTrainCurrent.Location - this.FrontOfTrainLocationFault - this.Vehicle.BrakingDistance;

                    //tren başladığı trackın içindeyse
                    //if (virtualOccupationFrontTrackLocation >= ActualFrontOfTrainCurrent.Track.Track_Start_Position)
                    if (virtualOccupationFrontTrackLocation >= 0)
                    {
                        frontOfTrainVirtualOccupation.Track = this.ActualFrontOfTrainCurrent.Track;
                        frontOfTrainVirtualOccupation.Location = virtualOccupationFrontTrackLocation;
                    }
                    else
                    {
                        //if (FrontOfTrainNextTrack != null)
                        {
                            double breakingDistanceWithFault = FrontOfTrainLocationFault + Vehicle.BrakingDistance;
                            double totalDistance = FrontOfTrainNextTrack.Track_Length + ActualFrontOfTrainCurrent.Location;

                            if (virtualOccupationFrontTrackLocation < 0 && (breakingDistanceWithFault >= totalDistance))
                            {
                                //frenleme mesafesi current ve nexttrack toplamından daha büyükse nexttrackten bir sonraki tracki next track olarak atıyoruz
                                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                //int nextTrackID = FrontOfTrainNextTrack.Track_Connection_Entry_1;
                                //frontOfTrainVirtualOccupation.Track = allTracks.Find(x => x.Track_ID == nextTrackID);//null kontrolü eklemek gerekebilir
                                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                                Track nextOne = FindNextTrack(FrontOfTrainNextTrack, Direction);
                                frontOfTrainVirtualOccupation.Track = nextOne;

                                //frontOfTrainVirtualOccupation.Location = frontOfTrainVirtualOccupation.Track.Track_End_Position - (breakingDistanceWithFault - totalDistance);
                                frontOfTrainVirtualOccupation.Location = frontOfTrainVirtualOccupation.Track.Track_Length - (breakingDistanceWithFault - totalDistance);
                            }
                            else
                            {
                                double passingDistanceToCurrentTrack = ActualFrontOfTrainCurrent.Track.Track_Length + virtualOccupationFrontTrackLocation;

                                frontOfTrainVirtualOccupation.Track = FrontOfTrainNextTrack;
                                frontOfTrainVirtualOccupation.Location = passingDistanceToCurrentTrack;

                                //frontOfTrainVirtualOccupation.Location = frontOfTrainVirtualOccupation.Track.Track_End_Position + virtualOccupationFrontTrackLocation;
                            }
                        }
                    }

                }


            }


            return frontOfTrainVirtualOccupation;


        }



        /// <summary>
        /// Trenin sanal meşguliyet konumunu hesaplar.
        /// </summary>
        public TrackWithPosition FindRearVirtualOccupation(ThreadSafeList<Track> routeTracks, Enums.Direction rearDirection)
        {
            TrackWithPosition rearOfTrainVirtualOccupation = new TrackWithPosition();


            if (routeTracks.Count != 0)
            {
                int rearCurrentTrackIndex = routeTracks.IndexOf(ActualRearOfTrainCurrent.Track);

                //int rearCurrentTrackIndex = allTracks.IndexOf(ActualRearOfTrainCurrent.Track);


                if (rearDirection == Enums.Direction.Right)
                {
                    double realRearCurrentLocation = this.ActualRearOfTrainCurrent.Location - this.RearOfTrainLocationFault;

                    //int sddsf = RouteTracks.IndexOf(RearCurrentTrack); 
                    //Track sddsfsdsd = RouteTracks.Find(x => x == RearCurrentTrack); 

                    //if (realRearCurrentLocation < ActualRearOfTrainCurrent.Track.Track_Start_Position)
                    //if (realRearCurrentLocation < RearOfTrainCurrentTrack.StopPositionInRoute)
                    if (realRearCurrentLocation > ActualRearOfTrainCurrent.Track.Track_Length)
                    {
                        if (rearCurrentTrackIndex > 0)//trenin arkası ikinci trackte ise
                        {
                            rearOfTrainVirtualOccupation.Track = routeTracks[rearCurrentTrackIndex - 1];

                            //rearOfTrainVirtualOccupation.Track = allTracks[rearCurrentTrackIndex - 1];
                            rearOfTrainVirtualOccupation.Location = rearOfTrainVirtualOccupation.Track.Track_End_Position + realRearCurrentLocation;
                        }
                    }
                    else
                    {
                        rearOfTrainVirtualOccupation.Track = ActualRearOfTrainCurrent.Track;
                        rearOfTrainVirtualOccupation.Location = realRearCurrentLocation;
                    }
                }
                else if (rearDirection == Enums.Direction.Left)
                {
                    double rearCurrentLocationWithFault = this.ActualRearOfTrainCurrent.Location + this.RearOfTrainLocationFault;

                    //if (rearCurrentLocationWithFault >= ActualRearOfTrainCurrent.Track.Track_End_Position)
                    if (rearCurrentLocationWithFault >= ActualRearOfTrainCurrent.Track.Track_Length)
                    {
                        if (rearCurrentTrackIndex > 0)
                        {
                            rearOfTrainVirtualOccupation.Location = rearCurrentLocationWithFault - ActualRearOfTrainCurrent.Track.Track_End_Position;
                            rearOfTrainVirtualOccupation.Track = routeTracks[rearCurrentTrackIndex - 1];
                        }

                    }
                    else
                    {
                        rearOfTrainVirtualOccupation.Track = ActualRearOfTrainCurrent.Track;
                        rearOfTrainVirtualOccupation.Location = rearCurrentLocationWithFault;
                    }
                }
            }

            return rearOfTrainVirtualOccupation;
        }





        /// <summary>
        /// Trenin gitmesi gereken hızı belirler.
        /// </summary>
        public double? FindTargetSpeed(ThreadSafeList<Track> routeTracks, Track frontCurrentTrack, Track rearCurrentTrack, Vehicle vehicle)
        {
            double? targetSpeedKM = null;

            try
            {
                

                bool IsConnectionOkayToGo = true;
                DoorStatus = ManageTrainDoors();

                Enums.Route isExceed = IsRouteLimitExceeded();
                Enums.Route cani = CanIGO();


                if ((isExceed == Enums.Route.Out))// || (!string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name) && ActualFrontOfTrainCurrent.Track.Station_Name == openDoorTrackName))// || !string.IsNullOrEmpty(FrontOfTrainCurrentTrack.Station_Name))
                {
                    targetSpeedKM = 0;
                }
                else if ((DoorStatus == Enums.DoorStatus.Open))// || (!string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name) && ActualFrontOfTrainCurrent.Track.Station_Name == openDoorTrackName))// || !string.IsNullOrEmpty(FrontOfTrainCurrentTrack.Station_Name))
                {
                    targetSpeedKM = 0;
                } 
                else  
                {
                    //if (IsRouteLimitExceeded() == Enums.Route.Out)
                    //{
                    //    targetSpeedKM = 0;
                    //}
                    //else
                    //{


                    int frontCurrentTrackIndex = movementTrack.FindIndex(x => x.Track_ID == frontCurrentTrack.Track_ID);
                    int remainingTracks = movementTrack.Count - frontCurrentTrackIndex;

                    List<Track> restOfMovementTracks = movementTrack.GetRange(frontCurrentTrackIndex, remainingTracks).ToList();
                    Stack<Track> reverseRestOfMovementTracks = new Stack<Track>(restOfMovementTracks.ToList());


                    foreach (Track item in restOfMovementTracks)
                    {
                        //int stoppingPoint = TrackStoppingPointForDirection(item, Direction);

                        //frenleme mesafesi frontcurrenttrackin konumu geçiyorsa
                        //if (FrontOfTrainLocationWithFootPrintInRoute + Vehicle.BrakingDistance >= item.StopPositionInRoute) //item.StartPositionInRoute)
                        {
                            do
                            {
                                Track reverseTracks = reverseRestOfMovementTracks.Pop();






                                #region Change Vehicle's Target Speed to Zero For Stopping Vehicle 
                                int stoppingPoint = TrackStoppingPointForDirection(item, Direction);

                                //bu if kontrolü tren bir sonraki tracke geçiyorsa demek
                                if (FrontOfTrainLocationWithFootPrintInRoute + Vehicle.BrakingDistance >= (item.StopPositionInRoute - stoppingPoint))
                                {
                                    #region Apply Zero Speed

                                    if ((item.Track_ID != FrontOfTrainNextTrack.Track_ID) && (FrontOfTrainNextTrack.Track_Speed_Limit_KMH == 0))
                                    {
                                        targetSpeedKM = 0;
                                        return targetSpeedKM;
                                    }

                                    //if (reverseTracks.Track_Speed_Limit_KMH == 0)
                                    //{
                                    //    targetSpeedKM = 0;
                                    //    return targetSpeedKM;
                                    //}
                                    #endregion

                                    #region Stop Vehicle In Station
                                    if (!string.IsNullOrEmpty(item.Station_Name) && (item.Station_Name != openDoorTrackName) && this.SkipStationStatus != Enums.SkipStation.Accepted)
                                    {
                                        targetSpeedKM = 0;
                                        return targetSpeedKM;
                                    }
                                    //if (!string.IsNullOrEmpty(item.Station_Name) && (item.Station_Name != openDoorTrackName))
                                    //{
                                    //    targetSpeedKM = 0;
                                    //    return targetSpeedKM;
                                    //}
                                    #endregion

                                    #region Stop Vehicle If Its Last Movement Authority Track 
                                    if ((reverseRestOfMovementTracks.Count == 0) && (rearCurrentTrack.Track_ID == movementTrack.Last().Track_ID))
                                    {
                                        targetSpeedKM = 0;
                                        return targetSpeedKM;
                                    }
                                    #endregion
                                }
                              
                                #endregion


                                #region Get Lowest Speed 
                                double tempSpeed;

                                if (item.MaxTrackSpeedCMS < vehicle.CurrentTrainSpeedCMS)
                                    tempSpeed = item.MaxTrackSpeedCMS;
                                else
                                    tempSpeed = vehicle.CurrentTrainSpeedCMS;
                                #endregion


                                double differenceOfMaxTrackSpeed = Math.Abs(tempSpeed - reverseTracks.MaxTrackSpeedCMS);
                                double timeToDifferenceOfMaxTrackSpeed = (differenceOfMaxTrackSpeed / vehicle.MaxTrainDeceleration);
                                double distanceToArrangeTheSpeed = (tempSpeed * timeToDifferenceOfMaxTrackSpeed);


                                ////iki track arasındaki hız farkı için toplam alınan mesafe
                                double distanceToSpeedDifference = (differenceOfMaxTrackSpeed) * (timeToDifferenceOfMaxTrackSpeed);


                                if ((tempSpeed > reverseTracks.MaxTrackSpeedCMS) &&
                                    (((FrontOfTrainLocationWithFootPrintInRoute + distanceToArrangeTheSpeed) - (0.5 * distanceToSpeedDifference)) < reverseTracks.StartPositionInRoute))
                                {


                                }
                                //mesafe yoksa
                                else if (tempSpeed > reverseTracks.MaxTrackSpeedCMS)
                                {
                                    targetSpeedKM = reverseTracks.MaxTrackSpeedKMH;

                                    //break;
                                    return targetSpeedKM;

                                }



                            } while (reverseRestOfMovementTracks.Count > 0);


                            if (item == frontCurrentTrack)
                            {




                                //#region Change Vehicle's Target Speed to Zero For Stopping Vehicle 
                                //int stoppingPoint = TrackStoppingPointForDirection(item, Direction);

                                ////bu if kontrolü tren bir sonraki tracke geçiyorsa demek
                                //if (FrontOfTrainLocationWithFootPrintInRoute + Vehicle.BrakingDistance >= (item.StopPositionInRoute - stoppingPoint))
                                //{
                                //    #region Apply Zero Speed

                                //    if ((item.Track_ID != FrontOfTrainNextTrack.Track_ID) && (FrontOfTrainNextTrack.Track_Speed_Limit_KMH == 0))
                                //    {
                                //        targetSpeedKM = 0;
                                //        return targetSpeedKM;
                                //    }

                                //    //if (reverseTracks.Track_Speed_Limit_KMH == 0)
                                //    //{
                                //    //    targetSpeedKM = 0;
                                //    //    return targetSpeedKM;
                                //    //}
                                //    #endregion

                                //    #region Stop Vehicle In Station
                                //    if (!string.IsNullOrEmpty(item.Station_Name) && (item.Station_Name != openDoorTrackName) && this.SkipStationStatus != Enums.SkipStation.Accepted)
                                //    {
                                //        targetSpeedKM = 0;
                                //        return targetSpeedKM;
                                //    }
                                //    //if (!string.IsNullOrEmpty(item.Station_Name) && (item.Station_Name != openDoorTrackName))
                                //    //{
                                //    //    targetSpeedKM = 0;
                                //    //    return targetSpeedKM;
                                //    //}
                                //    #endregion

                                //    #region Stop Vehicle If Its Last Movement Authority Track 
                                //    if ((reverseRestOfMovementTracks.Count == 0) && (rearCurrentTrack.Track_ID == movementTrack.Last().Track_ID))
                                //    {
                                //        targetSpeedKM = 0;
                                //        return targetSpeedKM;
                                //    }
                                //    #endregion
                                //}
                                ////else if (FrontOfTrainNextTrack == null)
                                ////{
                                ////    targetSpeedKM = 0;
                                ////    return targetSpeedKM;
                                ////}

                                //#endregion




                                //trackın maksimum hızı ile trenin hızı arasındakı fark
                                double differenceBetweenTrainAndTrackSpeed = vehicle.CurrentTrainSpeedCMS - item.MaxTrackSpeedCMS;
                                //trenin hızı trackın maksimum hızına çıkarmak için geçmesi gereken zaman saniye cinsinden
                                double time = Math.Abs(vehicle.CurrentTrainSpeedCMS - item.MaxTrackSpeedCMS) / vehicle.MaxTrainDeceleration;
                                //trenin trackin maksimum hızına çıkmak için alması gereken yol santimetre cinsinden
                                double distanceToArrangeTheSpeed = vehicle.CurrentTrainSpeedCMS * time;

                                // Anlık hız gelecek dikkate alınması gereken sonraki bir Track hızından düşükse
                                //trenin o anda bulunduğu hız haraket izni bulunan trackin maksimum hızından düşükse (hareket izni bulunan tracklerle sırasıyla karşılaştırıyoruz)
                                if (vehicle.CurrentTrainSpeedCMS < item.MaxTrackSpeedCMS) // burası end: ten sonraki koşul karşılaştırması
                                {
                                    // O hıza gidebileceği mesafeye geldiyse
                                    if (item.StartPositionInRoute - this.ActualFrontOfTrainCurrent.Location <= distanceToArrangeTheSpeed + (Math.Abs(differenceBetweenTrainAndTrackSpeed) * time / 2))
                                    {
                                        targetSpeedKM = FindMinSpeedInTracks(item, rearCurrentTrack, routeTracks);

                                        return targetSpeedKM;
                                    }
                                    //tren önünden itibaren bulunduğu trackın içindeyse tek bir trackin içindedir; o trackın hızını al
                                    else if (this.FrontOfTrainLocationWithFootPrintInRoute - vehicle.TrainLength >= item.StopPositionInRoute) //item.StartPositionInRoute)
                                    {
                                        targetSpeedKM = item.MaxTrackSpeedKMH;

                                        return targetSpeedKM;
                                    }
                                    //else if (Math.Round(FrontOfTrainLocationWithFootPrintInRoute) + Vehicle.BrakingDistance <= (item.StopPositionInRoute - stoppingPoint))
                                    else if (Math.Round(FrontOfTrainLocationWithFootPrintInRoute) + Vehicle.BrakingDistance <= (item.StopPositionInRoute))
                                    {
                                        targetSpeedKM = FindMinSpeedInTracks(item, rearCurrentTrack, routeTracks);

                                        return targetSpeedKM;
                                    }
                                    //sonradan eklendi durunca hareket ettirmek için
                                    else if (Math.Round(FrontOfTrainLocationWithFootPrintInRoute) + Vehicle.BrakingDistance > item.StopPositionInRoute)
                                       //else if (Math.Round(FrontOfTrainLocationWithFootPrintInRoute) + Vehicle.BrakingDistance > (item.StopPositionInRoute - stoppingPoint))
                                    {
                                        targetSpeedKM = FindMinSpeedInTracks(item, rearCurrentTrack, routeTracks);

                                        return targetSpeedKM;
                                    }
                                }
                                else if (vehicle.CurrentTrainSpeedCMS > item.MaxTrackSpeedCMS) // burası end: ten sonraki koşul karşılaştırması
                                {
                                    // O hıza gidebileceği mesafeye geldiyse
                                    if (item.StartPositionInRoute - this.ActualFrontOfTrainCurrent.Location <= distanceToArrangeTheSpeed - (Math.Abs(differenceBetweenTrainAndTrackSpeed) * time / 2))
                                    {
                                        targetSpeedKM = FindMinSpeedInTracks(item, rearCurrentTrack, routeTracks);

                                        return targetSpeedKM;
                                    }
                                    //tren önünden itibaren bulunduğu trackın içindeyse tek bir trackin içindedir; o trackın hızını al
                                    else if (this.FrontOfTrainLocationWithFootPrintInRoute - vehicle.TrainLength >= item.StartPositionInRoute)
                                    {
                                        targetSpeedKM = item.MaxTrackSpeedKMH;

                                        return targetSpeedKM;
                                    }
                                    else if (FrontOfTrainLocationWithFootPrintInRoute + Vehicle.BrakingDistance <= item.StopPositionInRoute)
                                    {
                                        targetSpeedKM = FindMinSpeedInTracks(item, rearCurrentTrack, routeTracks);

                                        return targetSpeedKM;
                                    }
                                }
                                break;

                            }

                            if (reverseRestOfMovementTracks.Count == 0)
                            {
                                List<Track> tempReverseRestOfMovementTracks = restOfMovementTracks.ToList();
                                tempReverseRestOfMovementTracks.Remove(item);
                                reverseRestOfMovementTracks = new Stack<Track>(tempReverseRestOfMovementTracks);


                            }
                        }

                    }

                }

                return targetSpeedKM;
            }
            catch(Exception ex)
            {
                return targetSpeedKM;
            }
          
        }




        public double ManageAcceleration(double currentTrainSpeed, Vehicle vehicle, double maxTrackSpeed)
        { 
            double? acc = null, dec = null, stopAcc = null;
            double acceleration = 0 ;


            if (vehicle.TargetSpeedKMH == 0)
            {
                stopAcc = StopTrain(vehicle);
            } 
            else if ((vehicle.TargetSpeedCMS != 0) && (currentTrainSpeed != vehicle.TargetSpeedCMS))
            {
                acc = SetAcceleration(currentTrainSpeed, vehicle.TargetSpeedCMS, vehicle.MaxTrainAcceleration, maxTrackSpeed);
                dec = SetDeceleration(currentTrainSpeed, vehicle.TargetSpeedCMS, vehicle.MaxTrainDeceleration);
            }

            if (stopAcc.HasValue)
                acceleration = stopAcc.Value;
            if (acc.HasValue)
                acceleration = acc.Value;
            else if (dec.HasValue)
                acceleration = dec.Value;

            return acceleration;
        }


        double totalDistance;
        public double? StopTrain(Vehicle vehicle)
        {
            double? currentAcceleration = null;

            if (vehicle.CurrentTrainSpeedKMH == 0)
            {
                vehicle.CurrentTrainSpeedCMS = 0;
                vehicle.CurrentAcceleration = 0;
            }
            else if (vehicle.CurrentTrainSpeedCMS > 0)
            {
                double distanceToTarget=0;

                Track station = movementTrack.Find(x => (x == ActualFrontOfTrainCurrent.Track) && !string.IsNullOrEmpty(x.Station_Name));

                if (station != null)
                {

                    int stoppingPoint = TrackStoppingPointForDirection(station, Direction);


                    //istasyonda durdurma kısmı burası önemli bu noktaya göre duracak tren
                    //distanceToTarget = station.StopPositionInRoute - FrontOfTrainLocationWithFootPrintInRoute;
                    //this.ActualFrontOfTrainCurrent.Location >= itemstationTrack_Length - item.Stopping_Point_Position_1

                    //if (station.Station_Name == "SGM2")
                    //    distanceToTarget = Math.Abs((station.StopPositionInRoute - station.Stopping_Point_Positon_2 ) - FrontOfTrainLocationWithFootPrintInRoute);
                    //else

                    //wayside
                    distanceToTarget = Math.Abs((station.StopPositionInRoute - stoppingPoint) - FrontOfTrainLocationWithFootPrintInRoute);
                    //distanceToTarget = ((station.StopPositionInRoute - stoppingPoint) - FrontOfTrainLocationWithFootPrintInRoute);
                    //distanceToTarget = Math.Abs((station.StopPositionInRoute - station.Stopping_Point_Position_1) - FrontOfTrainLocationWithFootPrintInRoute);

                    //int stopPosition;

                    //if (Direction == Enums.Direction.Right)
                    //    stopPosition = station.Stopping_Point_Positon_2;
                    //else
                    //    stopPosition = station.Stopping_Point_Position_1;


                    //distanceToTarget = (station.StopPositionInRoute - stopPosition) - FrontOfTrainLocationWithFootPrintInRoute;
                }
                //else if (ActualFrontOfTrainCurrent.Track == MovementAuthorityTrack)
                //{
                //    int stoppingPoint = TrackStoppingPointForDirection(ActualFrontOfTrainCurrent.Track, Direction);

                //    distanceToTarget = Math.Abs((ActualFrontOfTrainCurrent.Track.StopPositionInRoute - stoppingPoint) - FrontOfTrainLocationWithFootPrintInRoute);
                //}
                else
                {
                    //burayı değiştireceğim
                    //distanceToTarget = m_route.Length - FrontOfTrainLocationWithFootPrintInRoute;

                    //double totalDistance = movementTrack.Sum(x => x.Track_Length);

                    //distanceToTarget = totalDistance - Math.Floor(FrontOfTrainLocationWithFootPrintInRoute);

                    //distanceToTarget = MainForm.m_mf.m_YNK1_KIR2_YNK1.Last().StopPositionInRoute - Math.Floor(FrontOfTrainLocationWithFootPrintInRoute);


                    //distanceToTarget = movementTrack.Last().StopPositionInRoute - FrontOfTrainLocationWithFootPrintInRoute;
                }



                //double distanceToTarget = m_route.Route_Tracks[1].StopPositionInRoute - FrontOfTrainLocationWithFootPrintInRoute;


                //double distanceToTarget = m_route.Length - RealFrontCurrentLocation;// FrontTrainLocationInRouteWithFootPrint;

                // Vs² = Vi² + 2ax
                double acc = (0 - Math.Pow(vehicle.CurrentTrainSpeedCMS, 2)) / (2 * distanceToTarget);

                if (Math.Abs(acc) < (vehicle.MaxTrainDeceleration))
                {
                    currentAcceleration = acc;
                }
                else
                {
                    currentAcceleration = -vehicle.MaxTrainDeceleration;
                }
            }

            return currentAcceleration;
        }

        public double? StopTrain(Vehicle vehicle, double length)
        {
            double? currentAcceleration = null;

            if (vehicle.CurrentTrainSpeedKMH == 0)
            {
                vehicle.CurrentTrainSpeedCMS = 0;
                vehicle.CurrentAcceleration = 0;
            }
            else if (vehicle.CurrentTrainSpeedCMS > 0)
            {
                //burayı değiştireceğim
                double distanceToTarget = length - FrontOfTrainLocationWithFootPrintInRoute;



                //double distanceToTarget = m_route.Route_Tracks[1].StopPositionInRoute - FrontOfTrainLocationWithFootPrintInRoute;


                //double distanceToTarget = m_route.Length - RealFrontCurrentLocation;// FrontTrainLocationInRouteWithFootPrint;

                // Vs² = Vi² + 2ax
                double acc = (0 - Math.Pow(vehicle.CurrentTrainSpeedCMS, 2)) / (2 * distanceToTarget);

                if (Math.Abs(acc) < (vehicle.MaxTrainDeceleration))
                {
                    currentAcceleration = acc;
                }
                else
                {
                    currentAcceleration = -vehicle.MaxTrainDeceleration;
                }
            }

            return currentAcceleration;
        }

        public double? SetAcceleration(double currentTrainSpeed, double targetSpeed, double maxTrainAcceleration, double maxTrackSpeed)
        {
            double? acceleration = null;

            if (currentTrainSpeed < targetSpeed && currentTrainSpeed < maxTrackSpeed)//burada kaldım
                acceleration = maxTrainAcceleration; 

            return acceleration;
        }

        public double? SetDeceleration(double currentTrainSpeed, double targetSpeed, double maxTrainDeceleration)
        {
            double? deceleration = null;

            if (currentTrainSpeed > 0 && currentTrainSpeed > targetSpeed)
                deceleration = -maxTrainDeceleration;

            return deceleration;
        }



        readonly object m_manageDoor = new object();

        double total;
        public Enums.DoorStatus ManageTrainDoors()
        {

            //lock (m_manageDoor)
            //{

            if (this.OBATCtoWSATC_BerthingOk && this.TrainAbsoluteZeroSpeed)
            {
            
                //if ((!string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name) && !m_doorTimer.Enabled && (openDoorTrackName != ActualFrontOfTrainCurrent.Track.Station_Name) && Vehicle.CurrentTrainSpeedCMS == 0))
                if ((!string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name) && !m_doorTimer.Enabled && (openDoorTrackName != ActualFrontOfTrainCurrent.Track.Station_Name) && Vehicle.CurrentTrainSpeedCMS == 0))
                {

                    //Debug.WriteLine("Managedoora girdim");


                    //DwellTime = ActualFrontOfTrainCurrent.Track.DwellTime;

                    //if((string.IsNullOrEmpty(setDwellTrackID)) || (!string.IsNullOrEmpty(setDwellTrackID) &&  (setDwellTrackID != ActualFrontOfTrainCurrent.Track.Track_ID.ToString())))

                    if(DwellTime == Convert.ToInt32(Enums.DwellTime.Non))
                        DwellTime = ActualFrontOfTrainCurrent.Track.DwellTime;


                    if (DwellTime == 0)
                    {
                        DoorStatus = CloseTrainDoors(DoorStatus);
                        m_doorTimer.Start();

                        DwellTimeFinished = false;

                        //Debug.WriteLine("Close Doors - Dwell : " + DwellTimeFinished.ToString());

                    }
                    else
                    {
                      


                      

                        DoorStatus = OpenTrainDoors(DoorStatus);


                        //if (!string.IsNullOrEmpty(openStation) && !string.IsNullOrEmpty(closeStation) && openStation != "DEPO" && closeStation != "DEPO")
                        //    Logging.WriteStationTimeLog(closeStation, openStation, dneme.Elapsed.ToString());


                        if (DoorStatus == Enums.DoorStatus.Open)
                        {
                            m_doorTimer.Start();

                            DwellTimeFinished = false;

                            //if (DisplayManager.TabControlSelectedIndexInvoke(MainForm.m_mf.m_tabControlLogs) == 3)
                                DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBoxTrainsLogs, this.Vehicle.TrainID.ToString() + " " + Localization.OpenDoors, Color.Red);

                            //m_stopwatch.Start();
                        }

                    }
                     

                }
                return DoorStatus;
            }
            else
            {
                //Console.WriteLine("ManageTrainDoors index = 2");
                //Debug.WriteLine("ManageTrainDoors index = 2 - " + this.Vehicle.TrainID.ToString() + " " + "Doors - " + "Counter : " + DoorTimerCounter.ToString());


                //dwell bitti mi?
                if (string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name))
                {
                    DwellTimeFinished = false;
                    
                    DwellTime = Convert.ToUInt16(Enums.DwellTime.Movement);
                    //Debug.WriteLine("string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name) - Dwell : " + DwellTimeFinished.ToString());
                    //zongurt = -1;
                }




                return DoorStatus;
            }
            //} 
        }

        Stopwatch dneme = new Stopwatch();


        string openStation, closeStation;

        DateTime openStationDateTime, closeStationDateTime;

        [Browsable(false)]
        public  int zongurt  { get; set; }

        internal readonly object m_OnTrainDoors = new object();

        public void OnTrainDoorsOpenedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {

            if (zongurt <= 0)
            {

              
                openDoorTrackName = ActualFrontOfTrainCurrent.Track.Station_Name;

                //WSATC
                //OBATCtoWSATC_BerthingOk = false;

                DwellTimeFinished = true;
                //Debug.WriteLine("OnTrainDoorsOpenedEvent - Dwell : " + DwellTimeFinished.ToString());

                //DwellTime = Convert.ToUInt16(Enums.DwellTime.Movement);




                DoorStatus = CloseTrainDoors(DoorStatus);
                m_doorTimer.Stop();

                //MainForm.m_mf.m_UILogs.Add(Tuple.Create<string, Color>(this.Vehicle.TrainID.ToString() + " " + "Close Doors", Color.Red));

                //Debug.WriteLine(this.Vehicle.TrainID.ToString() + " " + "Close Doors - " + "Counter : " + DoorTimerCounter.ToString());

                //if (DisplayManager.TabControlSelectedIndexInvoke(MainForm.m_mf.m_tabControlLogs) == 3)
                    DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBoxTrainsLogs, this.Vehicle.TrainID.ToString() + " " + Localization.CloseDoors, Color.Red);


                //CheckBerthingStatus(this.Vehicle.CurrentTrainSpeedCMS, this.DwellTimeFinished);


                //zongurt = -1;


            }


            else if (zongurt >= 0)
            {

                //if (zongurt == 14)
                //    this.HoldStation = true;

                if (ActualFrontOfTrainCurrent.Track.Station_Name == "DEPO")
                {
                    goto AZALTMA;
                }


                //if ((zongurt == 6) && (movementTrack.Count <= 1))
                if ((zongurt <= 6) && (movementTrack.Last() == FrontOfTrainNextTrack) )
                {
                    //if  (zongurt <= 6) 
                    //{
                    //    if((FrontOfTrainNextTrack == null) || ((FrontOfTrainNextTrack != null && movementTrack.Last() == FrontOfTrainNextTrack)))
                    //    {
                    //if (DisplayManager.TabControlSelectedIndexInvoke(MainForm.m_mf.m_tabControlLogs) == 3)
                        DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBoxTrainsLogs, this.Vehicle.TrainID.ToString() + " " + Localization.WaitingForMA, Color.Red);
                    return;
                    //}


                }
                

                if ((zongurt == 6) && (this.HoldTrainStatus == Enums.HoldTrain.Accepted))
                {
                    //if (DisplayManager.TabControlSelectedIndexInvoke(MainForm.m_mf.m_tabControlLogs) == 3)
                        DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBoxTrainsLogs, this.Vehicle.TrainID.ToString() + " " + Localization.WaitingForHoldStation, Color.Red);
                    return;
                } 
    AZALTMA:          
                zongurt--;
            }

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
