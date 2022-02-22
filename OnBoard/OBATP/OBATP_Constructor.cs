using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnBoard 
{
    public partial class OBATP : IWSATP_TO_OBATPMessageWatcher, IATS_TO_OBATO_InitMessageWatcher, IATS_TO_OBATO_MessageWatcher, IATS, IWSATC, IDisposable
    {

        public OBATP()
        {

        }


        public OBATP DeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (OBATP)formatter.Deserialize(ms);
            }
        }

        public OBATP MemberwiseCopy()
        {

            return (OBATP)this.MemberwiseClone();

        } 


        #region WSATC Movement Yetkisi Testi
        //wayside hareket yetkisi testi
        public OBATP(Enums.Train_ID trainID, double maxTrainAcceleration, double maxTrainDeceleration)
        {

            //System.Threading.Timer STTimer = new System.Threading.Timer(DenemeTimer, null, 0, 1000);

            //tren parametreleri set ediliyor
            Vehicle.MaxTrainAcceleration = maxTrainAcceleration * 100;
            Vehicle.MaxTrainDeceleration = maxTrainDeceleration * 100;
            Vehicle.MaxTrainSpeedKMH = 80;
            Vehicle.TrainLength = 11200;
            Vehicle.TrainIndex = (int)trainID;
            Vehicle.TrainID = trainID;
            Vehicle.TrainName = trainID.ToString();


            FrontOfTrainLocationFault = 200;
            RearOfTrainLocationFault = 0;





            Track track = MainForm.m_mf.m_tracks.Find(x => x.Track_ID == 10101);


            //movementTrack.Add(track);

            ActualFrontOfTrainCurrent.Track = track;
            ActualRearOfTrainCurrent.Track = track;


            int stoppingPoint;

            Direction = Enums.Direction.Right;

            if (Direction == Enums.Direction.Right)
            {
                ActualFrontOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2;
                ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - this.Vehicle.TrainLength;
            }
            else
            {
                ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1);
                ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location + this.Vehicle.TrainLength;
            }

            //wayside ilk başlatmada konum bilgisi gönderme testi için
            FrontOfTrainTrackWithFootPrint.Track = ActualFrontOfTrainCurrent.Track;
            RearOfTrainTrackWithFootPrint.Track = ActualRearOfTrainCurrent.Track;


            //movementTrack.Add(track);


            //DwellTimeFinished = false;
            m_stopwatch = new Stopwatch();


            m_messageSendStopwatch = new Stopwatch();
            m_UIRefreshStopwatch = new Stopwatch();

            //m_doorTimer = new System.Timers.Timer();
            //m_doorTimer.Interval = 11000;
            //m_doorTimer.Elapsed += OnTrainDoorsOpenedEvent;


            m_OBATCTimer = new System.Threading.Timer(StartProcess);
            m_messageSendTimer = new System.Threading.Timer(SendOBATCMessage);
            m_UIRefreshTimer = new System.Threading.Timer(UIRefresh);

            //m_messageSendTimer = new System.Threading.Timer(SendOBATCMessage, this, Timeout.Infinite, Timeout.Infinite);
            //m_UIRefreshTimer = new System.Threading.Timer(UIRefresh, this, Timeout.Infinite, Timeout.Infinite);


            m_doorTimer = new System.Timers.Timer();
            m_doorTimer.Interval = 1000;
            m_doorTimer.Elapsed += OnTrainDoorsOpenedEvent;

            DoorStatus = Enums.DoorStatus.Close;   

            //ui göstermek için ui propertyleri burada set ediliyor
            //bu kısım vakit olduğunda farklı bir mekanizma ile tekrar yazılacak
            this.ID = Convert.ToString(Vehicle.TrainIndex);
            this.Train_Name = Vehicle.TrainName;


            this.Status = Enums.Status.Create;

            MainForm.m_trainObserver.TrainCreated(this);
        }

        #endregion



        #region ATS - WSATC Movement Yetkisi Testi
        //public OBATP(Enums.Train_ID trainID, double maxTrainAcceleration, double maxTrainDeceleration, int maxTrainSpeedKMH)
        //{

        //    //System.Threading.Timer STTimer = new System.Threading.Timer(DenemeTimer, null, 0, 1000);

        //    //tren parametreleri set ediliyor
        //    Vehicle.MaxTrainAcceleration = maxTrainAcceleration * 100;
        //    Vehicle.MaxTrainDeceleration = maxTrainDeceleration * 100;
        //    Vehicle.MaxTrainSpeedKMH = maxTrainSpeedKMH;
        //    Vehicle.TrainLength = 11200;
        //    Vehicle.TrainIndex = (int)trainID;
        //    Vehicle.TrainID = trainID;
        //    Vehicle.TrainName = trainID.ToString();


        //    FrontOfTrainLocationFault = 200;
        //    RearOfTrainLocationFault = 0;

        //    //DwellTimeFinished = false;
        //    m_stopwatch = new Stopwatch();


        //    m_messageSendStopwatch = new Stopwatch();
        //    m_UIRefreshStopwatch = new Stopwatch();

        //    //m_doorTimer = new System.Timers.Timer();
        //    //m_doorTimer.Interval = 11000;
        //    //m_doorTimer.Elapsed += OnTrainDoorsOpenedEvent;


        //    m_OBATCTimer = new System.Threading.Timer(StartProcess);
        //    //m_messageSendTimer = new System.Threading.Timer(SendOBATCMessage);
        //    //m_UIRefreshTimer = new System.Threading.Timer(UIRefresh);

        //    m_messageSendTimer = new System.Threading.Timer(SendOBATCMessage, this, Timeout.Infinite, Timeout.Infinite);
        //    m_UIRefreshTimer = new System.Threading.Timer(UIRefresh, this, Timeout.Infinite, Timeout.Infinite);


        //    m_doorTimer = new System.Timers.Timer();
        //    m_doorTimer.Interval = 1000;
        //    m_doorTimer.Elapsed += OnTrainDoorsOpenedEvent;

        //    DoorStatus = Enums.DoorStatus.Close;
        //    DoorTimerCounter = 11 - Convert.ToInt32(m_stopwatch.Elapsed.TotalSeconds);

        //    //ui göstermek için ui propertyleri burada set ediliyor
        //    //bu kısım vakit olduğunda farklı bir mekanizma ile tekrar yazılacak
        //    this.ID = Convert.ToString(Vehicle.TrainIndex);
        //    this.Train_Name = Vehicle.TrainName;


        //    this.Status = Enums.Status.Create;

        //    MainForm.m_trainObserver.TrainCreated(this);
        //}

        #endregion








        public OBATP(Enums.Train_ID trainID, double maxTrainAcceleration, double maxTrainDeceleration, int maxTrainSpeedKMH, double trainLength)
        {

            //System.Threading.Timer STTimer = new System.Threading.Timer(DenemeTimer, null, 0, 1000);

            //tren parametreleri set ediliyor
            Vehicle.MaxTrainAcceleration = maxTrainAcceleration * 100;
            Vehicle.MaxTrainDeceleration = maxTrainDeceleration * 100;
            Vehicle.MaxTrainSpeedKMH = maxTrainSpeedKMH;
            Vehicle.TrainLength = trainLength;
            Vehicle.TrainIndex = (int)trainID;
            Vehicle.TrainID = trainID;
            Vehicle.TrainName = trainID.ToString();


 

            FrontOfTrainLocationFault = 0;
            RearOfTrainLocationFault = 0;

            //DwellTimeFinished = false;
           


            m_messageSendStopwatch = new Stopwatch();
            m_UIRefreshStopwatch = new Stopwatch();

            //m_doorTimer = new System.Timers.Timer();
            //m_doorTimer.Interval = 11000;
            //m_doorTimer.Elapsed += OnTrainDoorsOpenedEvent;


            m_OBATCTimer = new System.Threading.Timer(StartProcess);
            //m_messageSendTimer = new System.Threading.Timer(SendOBATCMessage);
            //m_UIRefreshTimer = new System.Threading.Timer(UIRefresh);

            m_messageSendTimer = new System.Threading.Timer(SendOBATCMessage, this, Timeout.Infinite, Timeout.Infinite);
            m_UIRefreshTimer = new System.Threading.Timer(UIRefresh, this, Timeout.Infinite, Timeout.Infinite);


            m_doorTimer = new System.Timers.Timer();
            m_doorTimer.Interval = 1000;
            m_doorTimer.Elapsed += OnTrainDoorsOpenedEvent;

            DoorStatus = Enums.DoorStatus.Close;
            

            //ui göstermek için ui propertyleri burada set ediliyor
            //bu kısım vakit olduğunda farklı bir mekanizma ile tekrar yazılacak
            this.ID = Convert.ToString(Vehicle.TrainIndex);
            this.Train_Name = Vehicle.TrainName;


            this.Status = Enums.Status.Create;

            MainForm.m_trainObserver.TrainCreated(this);
        }


        public OBATP(Enums.Train_ID trainID, double maxTrainAcceleration, double maxTrainDeceleration, int maxTrainSpeedKMH, double trainLength, int startTrackID)
        {
            //tren parametreleri set ediliyor
            Vehicle.MaxTrainAcceleration = maxTrainAcceleration * 100;
            Vehicle.MaxTrainDeceleration = maxTrainDeceleration * 100;
            Vehicle.MaxTrainSpeedKMH = maxTrainSpeedKMH;
            Vehicle.TrainLength = trainLength;
            Vehicle.TrainIndex = (int)trainID;
            Vehicle.TrainID = trainID;
            Vehicle.TrainName = trainID.ToString();


            m_startTrackID = startTrackID;

            FrontOfTrainLocationFault = 200;
            RearOfTrainLocationFault = 0;


            //if (this.Vehicle.TrainID == Enums.Train_ID.Train1)

            //wayside hareket yetkisi için commentlendi
            //movementTrack = Route.CreateMovementTracksStationToStation(startTrackID, MainForm.m_mf.m_YNK1_KIR2_YNK1, MainForm.m_mf.m_YNK2_HAV2_YNK2, true);
            
            
            //if (this.Vehicle.TrainID == Enums.Train_ID.Train2)
            //    movementTrack = Route.CreateMovementTracksStationToStation(startTrackID, MainForm.m_mf.m_YNK1_KIR2_YNK1, MainForm.m_mf.m_YNK2_HAV2_YNK2, false);

            //Direction = FindDirection(movementTrack, Direction);


            ActualFrontOfTrainCurrent.Track = movementTrack.First();
            ActualRearOfTrainCurrent.Track = movementTrack.First();

            ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);
            ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - this.Vehicle.TrainLength;


            if ((!string.IsNullOrEmpty(movementTrack.First().Station_Name)) && (movementTrack.First().Station_Name == "KRZ2"))
            {
                ActualFrontOfTrainCurrent.Track = movementTrack.First();
                ActualRearOfTrainCurrent.Track = movementTrack.First();

                ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1);
                ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location + this.Vehicle.TrainLength;
            }
            else if ((!string.IsNullOrEmpty(movementTrack.First().Station_Name)) && (movementTrack.First().Station_Name == "YNK1"))
            {
                ActualFrontOfTrainCurrent.Track = movementTrack.First();
                ActualRearOfTrainCurrent.Track = movementTrack.First();

                ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);
                ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - this.Vehicle.TrainLength;
            }
            else if ((!string.IsNullOrEmpty(movementTrack.First().Station_Name)) && (movementTrack.First().Station_Name == "YNK2"))
            {
                ActualFrontOfTrainCurrent.Track = movementTrack.First();
                ActualRearOfTrainCurrent.Track = movementTrack.First();

                ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);
                ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - this.Vehicle.TrainLength;
            }
            else if ((!string.IsNullOrEmpty(movementTrack.First().Station_Name)) && (movementTrack.First().Station_Name == "HVL2"))
            {
                ActualFrontOfTrainCurrent.Track = movementTrack.First();
                ActualRearOfTrainCurrent.Track = movementTrack.First();

                ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);
                ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - this.Vehicle.TrainLength;
            }




            //DwellTimeFinished = false;
            
            m_doorTimer = new System.Timers.Timer();
            m_doorTimer.Interval = 11000;
            m_doorTimer.Elapsed += OnTrainDoorsOpenedEvent;


            DoorStatus = Enums.DoorStatus.Close;
         


            //ui göstermek için ui propertyleri burada set ediliyor
            //bu kısım vakit olduğunda farklı bir mekanizma ile tekrar yazılacak
            this.ID = Convert.ToString(Vehicle.TrainIndex);
            this.Train_Name = Vehicle.TrainName;


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


            //wayside ilk başlatmada konum bilgisi gönderme testi için
            FrontOfTrainTrackWithFootPrint.Track = ActualFrontOfTrainCurrent.Track;
            RearOfTrainTrackWithFootPrint.Track = ActualRearOfTrainCurrent.Track;


            this.Status = Enums.Status.Create;

            MainForm.m_trainObserver.TrainCreated(this);
        }




        public OBATP(Enums.Train_ID trainID, double maxTrainAcceleration, double maxTrainDeceleration, int maxTrainSpeedKMH, double trainLength, Route route)
        {
            //tren parametreleri set ediliyor
            Vehicle.MaxTrainAcceleration = maxTrainAcceleration * 100;
            Vehicle.MaxTrainDeceleration = maxTrainDeceleration * 100;
            Vehicle.MaxTrainSpeedKMH = maxTrainSpeedKMH;
            Vehicle.TrainLength = trainLength;
            Vehicle.TrainIndex = (int)trainID;
            Vehicle.TrainID = trainID;
            Vehicle.TrainName = trainID.ToString();

            //MovementAuthorityTrack = route.Route_Tracks.Find(x => x.Track_ID == 11101);


            FrontOfTrainLocationFault = 200;
            RearOfTrainLocationFault = 0;



            //Track startTrack = MainForm.m_mf.m_simulationAllTracks.Find(x => x.Track_ID == route.Entry_Track.Track_ID);

            ActualFrontOfTrainCurrent.Track = route.Entry_Track;// startTrack;
            ActualRearOfTrainCurrent.Track = route.Entry_Track;// startTrack;startTrack;


            //ActualFrontOfTrainCurrent.Track =  startTrack;
            //ActualRearOfTrainCurrent.Track =   startTrack;

            //ActualFrontOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Track.Track_Length - ((ActualFrontOfTrainCurrent.Track.Track_End_Position - ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2) - ActualFrontOfTrainCurrent.Track.Track_Start_Position);//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;
            //ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - trainLength;

            Direction = FindDirection(route.Route_Tracks, Direction);

            if (Direction == Enums.Direction.Right)
            {
                ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Positon_2);//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;
                ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location - trainLength;
            }
            else
            {
                ActualFrontOfTrainCurrent.Location = (ActualFrontOfTrainCurrent.Track.Stopping_Point_Position_1);//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;
                ActualRearOfTrainCurrent.Location = ActualFrontOfTrainCurrent.Location + trainLength;
            }

            //RealFrontCurrentLocation = 11200;
            //ActualFrontOfTrainCurrent.Location = trainLength;//FrontOfTrainCurrentTrack.Track_Start_Position + trainLength;
            //ActualRearOfTrainCurrent.Location = 0;



            //DwellTimeFinished = false;
           
            m_doorTimer = new System.Timers.Timer();
            m_doorTimer.Interval = 11000;
            m_doorTimer.Elapsed += OnTrainDoorsOpenedEvent;


            DoorStatus = Enums.DoorStatus.Close;
           

            //m_route = new Route();
            //m_route.Entry_Track = route.Entry_Track;
            //m_route.Entry_Track_ID = route.Entry_Track_ID;
            //m_route.Exit_Track = route.Exit_Track;
            //m_route.Exit_Track_ID = route.Exit_Track_ID;
            //m_route.Route_No = route.Route_No;
            //m_route.Length = route.Length;
            //m_route.Route_Tracks = route.Route_Tracks;

            //DwellTime = 20;


            //MainForm.m_trainMovement.AddWatcher(MainForm.m_mf);



            //ui göstermek için ui propertyleri burada set ediliyor
            //bu kısım vakit olduğunda farklı bir mekanizma ile tekrar yazılacak
            this.ID = Convert.ToString(Vehicle.TrainIndex);
            this.Train_Name = Vehicle.TrainName;


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


            this.Status = Enums.Status.Create;

            MainForm.m_trainObserver.TrainCreated(this);
        }





    }
}
