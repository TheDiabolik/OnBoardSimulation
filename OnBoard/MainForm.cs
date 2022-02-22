using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace OnBoard
{
    public partial class MainForm : Form, ITrainMovementUIWatcher, ISettingsWindowsWatcher, ITrainNewMovementAuthorityCreatedWatcher //ITrainMovementCreatedSendMessageWatcher, ITrainMovementUIWatcher, ISettingsWindowsWatcher
    {
        //test için eklenen değişkenler
        internal static int m_incomingMsgCounter = 0;
        internal static bool m_incomingMsgStatus = true;
        internal static int m_outgoingMsgCounter = 0;
        internal static bool m_outgoingMsgStatus = true;



        internal XMLSerialization m_settings;
        //SocketCommunication m_OBATPToWSATCSocket;
        //SocketCommunication m_OBATPToATSSocket;
        //SocketCommunication m_ATSToOBATPSocket;
        //SocketCommunication m_WSATCToOBATPSocket;
        internal SocketCommunication m_ATSSocket;
        internal SocketCommunication m_WSATCSocket;
        internal DatabaseOperation m_databaseOperation;
        //List<OBATPUIAdapter> m_ListList;

        //internal   BindingList<OBATP> m_allTrains;
        private System.Timers.Timer STTimer;
        private System.Threading.Timer AllTrainTimer;



        internal ThreadedBindingList<OBATP> m_allTrains;

        Stopwatch stopwatch = new Stopwatch();

        //internal BlockingCollection<Message> m_communicationLogs;

        //internal BlockingCollection<Tuple<DateTime, string, string, byte[]>> m_communicationLogs;
        //internal BlockingCollection<Tuple<DateTime, string, string, byte[]>> m_incomingMessageLogs;
        //internal BlockingCollection<Tuple<DateTime, string, string, byte[]>> m_outcomingMessageLogs;

        internal BlockingCollection<Tuple<DateTime, string, string>> m_communicationLogs;
        internal BlockingCollection<Tuple<DateTime, string, string>> m_incomingMessageLogs;
        internal BlockingCollection<Tuple<DateTime, string, string>> m_outcomingMessageLogs;

        internal BlockingCollection<Tuple<string, Color>> m_UILogs;

        //internal BlockingCollection<Tuple<DateTime, string, string>> m_communicationLogssdsd;

        internal static TrainObserver m_trainObserver;

        //internal static TRAİNmove ATS_TO_OBATO_MessageInComing m_ATS_TO_OBATO_MessageInComing;


        internal static WSATP_TO_OBATPMessageInComing m_WSATP_TO_OBATPMessageInComing;
        internal static ATS_TO_OBATO_InitMessageInComing m_ATS_TO_OBATO_InitMessageInComing;
        internal static ATS_TO_OBATO_MessageInComing m_ATS_TO_OBATO_MessageInComing;
         
        internal static SettingsWindowsObserver m_settingsWindowsObserver;



        public static MainForm m_mf;
        internal static ConcurrentDictionary<int, OBATP> m_allOBATP;
        //public ThreadSafeList<Track> m_allTracks;

        //public List<Track> m_ToYenikapıTracks;
        //public List<Track> m_FromYenikapıTracks;

        //public List<Track> m_KIR2_YNK1;
        //public List<Track> m_YNK1_KIR2;
        //public List<Track> m_YNK1_KIR2_YNK1;


        //public ThreadSafeList<Track> m_WSATCMovement_YNK1_KIR2_YNK1;

        //public ThreadSafeList<Track> m_WSATCMovement_KIR2_YNK1;
        //public ThreadSafeList<Track> m_WSATCMovement_YNK1_KIR2; 

        //public ThreadSafeList<Track> m_YNK2_HAV2_YNK2;

        public ThreadSafeList<Track> m_tracks;

        //public ThreadSafeList<Track> m_simulationAllTracks;
        //public  List<Route> m_allRoute;
        //internal static DataTable m_fromFileTracks;
        //internal static DataTable m_simulationRouteTracks;
        //internal static Route m_route;
        readonly object m_movement = new object();
        readonly object m_newRoute = new object();
        readonly object m_movementUI = new object();

        public MainForm()
        {
            InitializeComponent();

            m_mf = this;

            #region ayarları okuma
            m_settings = XMLSerialization.Singleton();
            m_settings = m_settings.DeSerialize(m_settings);
            #endregion

            #region SocketCreation
            //m_OBATPToWSATCSocket = new SocketCommunication();
            //m_WSATCToOBATPSocket = new SocketCommunication();

            //m_OBATPToATSSocket = new SocketCommunication();
            //m_ATSToOBATPSocket = new SocketCommunication();

            m_ATSSocket = new SocketCommunication();
            m_WSATCSocket = new SocketCommunication();
            #endregion


            //m_communicationLogs = new BlockingCollection<Tuple<DateTime, string, string, byte[]>>();
            //m_incomingMessageLogs = new BlockingCollection<Tuple<DateTime, string, string, byte[]>>();
            //m_outcomingMessageLogs = new BlockingCollection<Tuple<DateTime, string, string, byte[]>>();

            m_communicationLogs = new BlockingCollection<Tuple<DateTime, string, string>>();
            m_incomingMessageLogs = new BlockingCollection<Tuple<DateTime, string, string>>();
            m_outcomingMessageLogs = new BlockingCollection<Tuple<DateTime, string, string>>();

            m_UILogs = new BlockingCollection<Tuple<string, Color>>();

            AllTrainTimer = new System.Threading.Timer(ManageAllTrain);


            STTimer = new System.Timers.Timer();
            STTimer.Elapsed += OnTimerElapsed;

            //m_allTrains = new BindingList<OBATP>();
            m_allTrains = new ThreadedBindingList<OBATP>();

            //m_ToYenikapıTracks = new List<Track>();
            //m_FromYenikapıTracks = new List<Track>();

            //m_KIR2_YNK1 = new List<Track>();
            //m_YNK1_KIR2 = new List<Track>();
            //m_YNK1_KIR2_YNK1 = new List<Track>();

            //m_YNK2_HAV2_YNK2 = new ThreadSafeList<Track>();

            //m_WSATCMovement_YNK1_KIR2_YNK1 = new ThreadSafeList<Track>();


            m_tracks = new ThreadSafeList<Track>();
            //m_WSATCMovement_YNK1_KIR2 = new ThreadSafeList<Track>();
            //m_WSATCMovement_KIR2_YNK1 = new ThreadSafeList<Track>();


            //m_simulationAllTracks = new ThreadSafeList<Track>();

            m_allOBATP = new ConcurrentDictionary<int, OBATP>();
            m_trainObserver = new TrainObserver();

            m_WSATP_TO_OBATPMessageInComing = new WSATP_TO_OBATPMessageInComing();
            m_ATS_TO_OBATO_InitMessageInComing = new ATS_TO_OBATO_InitMessageInComing();
            m_ATS_TO_OBATO_MessageInComing = new ATS_TO_OBATO_MessageInComing();


            m_settingsWindowsObserver = new SettingsWindowsObserver();

            //MainForm.m_trainObserver.AddTrainMovementCreatedSendMessageWatcher(this);

            MainForm.m_trainObserver.AddTrainNewMovementAuthorityCreatedWatcher(this);

            MainForm.m_trainObserver.AddTrainMovementUIWatcher(this);

         
            //MainForm.m_trainObserver.AddTrainMovementUIall TracksListWatcher(this);

            MainForm.m_settingsWindowsObserver.AddSettingsWindowWatcher(this);



            //excel tablosundan track listesini ve özelliklerini okuyoruz    
            //m_fromFileTracks = FileOperation.Singleton().EPPlusReadTrackTableInExcel();
            //m_fromFileTracks = FileOperation.Singleton().ReadTrackTableInExcel();

            //m_allTracks = Track.AllTracks(m_fromFileTracks);

            //if (m_settings.TrackInput == Enums.TrackInput.Manuel)
            //{
            //    m_allTracks = Track.AllTracksAAA(m_settings.RouteTrack);
            //}
            //else if (m_settings.TrackInput == Enums.TrackInput.FromFile)
            //{
            //    m_allTracks = Track.AllTracks(m_fromFileTracks);
            //}

            #region veritabanı için commentlendi


            //FileOperation.Singleton().EPPlusReadTrackTableInExcel();



            //m_simulationRouteTracks = FileOperation.Singleton().ReadSimulationRouteTableInExcel();
            //m_simulationRouteTracks = FileOperation.Singleton().EPPlusReadSimulationRouteTableInExcel();
            //m_allRoute =  Route.SimulationRoute(m_simulationRouteTracks);
            //m_allRoute = Route.SimulationRouteStationToStation(m_simulationRouteTracks);


            //m_simulationAllTracks = Track.SimulationTrack(m_simulationRouteTracks);

            //Track lastStation = m_simulationAllTracks.Find(x => x.Track_ID == 11502);
            //int indexLastStation = m_simulationAllTracks.IndexOf(lastStation);

            //Track len = m_simulationAllTracks.ToList().FindLastIndex(x => x.Track_ID == 10101);
            //int indexlen = m_simulationAllTracks.IndexOf(len);

            //int indexlen = m_simulationAllTracks.ToList().FindLastIndex(x => x.Track_ID == 10101);

            //m_FromYenikapıTracks = m_simulationAllTracks.Where((element, index) => (index >= 0) && (index <= indexLastStation)).ToList();

            //m_ToYenikapıTracks = m_simulationAllTracks.Where((element, index) => (index >= indexLastStation) && (index <= indexlen)).ToList();

            #endregion



            m_databaseOperation = new DatabaseOperation(); 


            //Task<List<Track>> taskSelect2 = m_databaseOperation.AsycSelectYNK1_KIR2_YNK1();
            //taskSelect2.Wait();  
            //m_YNK1_KIR2_YNK1 = taskSelect2.Result;
            

            //Task<Track> taskSelect3 = m_databaseOperation.AsycSelectTrackFromYNK1_KIR2_YNK1(10101);
            //taskSelect3.Wait();
            //Track sdfk  = taskSelect3.Result;


            //Task<List<Track>> taskSelect3 = m_databaseOperation.AsycSelectKIR2_YNK1();
            //taskSelect3.Wait();
            //m_KIR2_YNK1 = taskSelect3.Result;

            //Task<List<Track>> taskSelect4 = m_databaseOperation.AsycSelectYNK1_KIR2();
            //taskSelect4.Wait();
            //m_YNK1_KIR2 = taskSelect4.Result;


            //m_WSATCMovement_YNK1_KIR2_YNK1.AddRange(m_YNK1_KIR2_YNK1);
            //m_WSATCMovement_YNK1_KIR2.AddRange(m_YNK1_KIR2);
            //m_WSATCMovement_KIR2_YNK1.AddRange(m_KIR2_YNK1);

            //Task<ThreadSafeList<Track>> taskSelect3 = m_databaseOperation.AsycSelectYNK2_HAV2_YNK2();
            //taskSelect3.Wait();
            //m_YNK2_HAV2_YNK2 = taskSelect3.Result;

            //m_YNK2_HAV2_YNK2 = taskSelect3.Result;


            Task<ThreadSafeList<Track>> taskSelect4 = m_databaseOperation.AsycSelectTracks();
            taskSelect4.Wait();
            m_tracks = taskSelect4.Result;



            //ThreadSafeList<Track> olmayanlar = new ThreadSafeList<Track>();

            //foreach (Track item in m_allTracks)
            //{
            //    Track zozo = m_tracks.Find(x => x.Track_ID == item.Track_ID);

            //    if (zozo == null)
            //        olmayanlar.Add(item);
            //}


            //ThreadSafeList<Track> olmayanlar = m_allTracks.Except(m_tracks);

            //HashSet<Track> tracks = new HashSet<Track>();

            //foreach (Track item in m_WSATCMovement_YNK1_KIR2_YNK1)
            //{
            //    tracks.Add(item);
            //}


            //foreach (Track item in m_YNK2_HAV2_YNK2)
            //{
            //    tracks.Add(item);
            //}


            //foreach (Track item in olmayanlar)
            //{

            //    List<string> values = new List<string>();


            //    values.Add(item.Station_Name);
            //    values.Add(item.Track_ID.ToString());
            //    values.Add(item.Track_Length.ToString());
            //    values.Add(item.Station_Start_Position.ToString());
            //    values.Add(item.Station_End_Position.ToString());
            //    values.Add(item.Track_Start_Position.ToString());
            //    values.Add(item.Track_End_Position.ToString());
            //    values.Add(item.MaxTrackSpeedKMH.ToString());
            //    values.Add(item.MaxTrackSpeedCMS.ToString());
            //    values.Add(item.Stopping_Point_Position_1.ToString());
            //    values.Add(item.Stopping_Point_Type_1.ToString());
            //    values.Add(item.Stopping_Point_Positon_2.ToString());

            //    values.Add(item.Stopping_Point_Type_2.ToString());
            //    values.Add(item.Track_Connection_Entry_1.ToString());
            //    values.Add(item.Track_Connection_Entry_2.ToString());

            //    values.Add(item.Track_Connection_Exit_1.ToString());
            //    values.Add(item.Track_Connection_Exit_2.ToString());


            //    Task<int> lolo = m_databaseOperation.AsyncTracksInsert(values);
            //    lolo.Wait();

            //}




            if (m_settings.m_language == Enums.Language.English)
                Localization.Culture = new CultureInfo("en-US");
            else if (m_settings.m_language == Enums.Language.Turkish)
                Localization.Culture = new CultureInfo("tr-TR");



            //m_OBATPToATSSocket.Start(m_settings.OBATPToATSCommunicationType, m_settings.OBATPToATSIPAddress, Convert.ToInt32(m_settings.OBATPToATSPort));
            //m_ATSToOBATPSocket.Start(m_settings.ATSToOBATPCommunicationType, m_settings.ATSToOBATPIPAddress, Convert.ToInt32(m_settings.ATSToOBATPPort));

            //m_OBATPToWSATCSocket.Start(m_settings.OBATPToWSATCCommunicationType, m_settings.OBATPToWSATCIPAddress, Convert.ToInt32(m_settings.OBATPToWSATCPort));
            //m_WSATCToOBATPSocket.Start(m_settings.WSATCToOBATPCommunicationType, m_settings.WSATCToOBATPIPAddress, Convert.ToInt32(m_settings.WSATCToOBATPPort));

            m_ATSSocket.Start(m_settings.ATSCommunicationType, SocketCommunication.ClientType.ATS, m_settings.ATSIPAddress, Convert.ToInt32(m_settings.ATSPort));
            m_WSATCSocket.Start(m_settings.WSATCCommunicationType, SocketCommunication.ClientType.WSATC, m_settings.WSATCIPAddress, Convert.ToInt32(m_settings.WSATCPort));



            #region playid yi 1 arttır
            int playID = m_settings.PlayID;
            m_settings.PlayID = playID + 1;
            m_settings.Serialize(m_settings);

            m_settings = m_settings.DeSerialize(m_settings);
            #endregion









            foreach (int index in m_settings.Trains)
            {
                int trainIndex = index + 1;
                Enums.Train_ID train_ID = (Enums.Train_ID)trainIndex;

                OBATP OBATP = new OBATP(train_ID, m_settings.MaxTrainAcceleration, m_settings.MaxTrainDeceleration, m_settings.TrainSpeedLimit, m_settings.TrainLength);

                m_allOBATP.TryAdd(trainIndex, OBATP);

                m_comboBoxTrain.Items.Add(train_ID.ToString());

                #region Communication Add Watchers
                MainForm.m_WSATP_TO_OBATPMessageInComing.AddWatcher(OBATP);
                MainForm.m_ATS_TO_OBATO_InitMessageInComing.AddWatcher(OBATP);
                MainForm.m_ATS_TO_OBATO_MessageInComing.AddWatcher(OBATP);
                #endregion

                //Thread.Sleep(5);

            }

            #region controls doublebuffered
            UIOperation.SetDoubleBuffered(this);
            UIOperation.SetDoubleBuffered(m_listView);
            UIOperation.SetDoubleBuffered(m_listViewFootPrintTracks);
            UIOperation.SetDoubleBuffered(m_listViewVirtualOccupation);
            UIOperation.SetDoubleBuffered(m_dataGridViewAllTrains);
            UIOperation.SetDoubleBuffered(m_richTextBoxCommunicationLogs);
            UIOperation.SetDoubleBuffered(m_richTextBoxIncomingMessage);
            UIOperation.SetDoubleBuffered(m_richTextBoxOutgoingMessage);
            UIOperation.SetDoubleBuffered(m_richTextBoxTrainsLogs);
            UIOperation.SetDoubleBuffered(m_comboBoxTrain);
            UIOperation.SetDoubleBuffered(m_mainMenu);
            #endregion 

        }



        public void LocalizationControlsText()
        {
            if (m_settings.m_language == Enums.Language.English)
                Localization.Culture = new CultureInfo("en-US");
            else if (m_settings.m_language == Enums.Language.Turkish)
                Localization.Culture = new CultureInfo("tr-TR");

            #region Localization
            m_settingsPopup.Text = Localization.m_settingsPopup;
            m_tabPageCommunication.Text = Localization.m_tabPageCommunication;
            m_tabPageIncomingMessage.Text = Localization.m_tabPageIncomingMessage;
            m_groupBoxLog.Text = Localization.m_groupBoxLog;
            m_tabPageOutgoingMessage.Text = Localization.m_tabPageOutgoingMessage;
            m_tabPageCommunication.Text = Localization.m_tabPageCommunication;

            m_trainItem.Text = Localization.m_trainItem;

            m_tabPageTrain.Text = Localization.m_tabPageTrain;
            m_communicationItem.Text = Localization.m_communicationItem;
            m_generalItem.Text = Localization.m_generalItem;
            m_groupBoxAllTrains.Text = Localization.m_groupBoxAllTrains;
            m_groupBoxTrainSettings.Text = Localization.m_groupBoxTrainSettings;

            m_labelCurrentAcceleration.Text = Localization.m_labelCurrentAcceleration;
            m_labelCurrentLocation.Text = Localization.m_labelCurrentLocation;
            m_labelCurrentTrainSpeedKM.Text = Localization.m_labelCurrentTrainSpeedKM;
            m_labelDoorStatus.Text = Localization.m_labelDoorStatus;
            m_labelDoorTimerCounter.Text = Localization.m_labelDoorTimerCounter;
            m_labelRearCurrentLocation.Text = Localization.m_labelRearCurrentLocation;

            m_labelTrains.Text = Localization.m_labelTrains;



            m_dataGridViewAllTrains.Columns[1].HeaderText = Localization.Train_Name;
            m_dataGridViewAllTrains.Columns[2].HeaderText = Localization.Speed;
            //front
            m_dataGridViewAllTrains.Columns[3].HeaderText = Localization.Front_Track_ID;
            m_dataGridViewAllTrains.Columns[4].HeaderText = Localization.Front_Track_Location;
            m_dataGridViewAllTrains.Columns[5].HeaderText = Localization.Front_Track_Length;
            //rear
            m_dataGridViewAllTrains.Columns[6].HeaderText = Localization.Rear_Track_ID;
            m_dataGridViewAllTrains.Columns[7].HeaderText = Localization.Rear_Track_Location;
            m_dataGridViewAllTrains.Columns[8].HeaderText = Localization.Rear_Track_Length;



            m_listView.Columns[0].Text = Localization.ListviewColumnRouteTrack;
            m_listView.Columns[1].Text = Localization.ListviewColumnStation;
            m_listView.Columns[2].Text = Localization.ListviewColumnSpeed;

            m_listViewVirtualOccupation.Columns[0].Text = Localization.ListviewColumnVir;

            m_listViewFootPrintTracks.Columns[0].Text = Localization.ListviewColumnFoot;


            m_aboutPopup.Text = Localization.AboutBox;

            #endregion
        }



        private void MainForm_Load(object sender, EventArgs e)
        {  


            m_labelDoorCounter.Text = "";
            m_labelDoorCounter.BorderStyle = BorderStyle.None;

            //TrainSimModal trainSimModal = new TrainSimModal();
            //trainSimModal.Owner = this;
            //trainSimModal.Show();

            if(m_settings.Trains.Count > 0)
                m_comboBoxTrain.SelectedIndex = 0;

            m_allTrains.SynchronizationContext = SynchronizationContext.Current;
            m_dataGridViewAllTrains.DataSource = m_allTrains;


            //general
            m_dataGridViewAllTrains.Columns[0].Width = 50;
            m_dataGridViewAllTrains.Columns[1].Width = 90;
            m_dataGridViewAllTrains.Columns[2].Width = 100;
            //front
            m_dataGridViewAllTrains.Columns[3].Width = 110;
            m_dataGridViewAllTrains.Columns[4].Width = 160;
            m_dataGridViewAllTrains.Columns[5].Width = 150;
            //rear
            m_dataGridViewAllTrains.Columns[6].Width = 110;
            m_dataGridViewAllTrains.Columns[7].Width = 160;
            m_dataGridViewAllTrains.Columns[8].Width = 150;
            //total route
            //m_dataGridViewAllTrains.Columns[9].Width = 150; 

            LocalizationControlsText();





            if (!m_backgroundWorkerCommunicationLogs.IsBusy)
                m_backgroundWorkerCommunicationLogs.RunWorkerAsync();

            if (!m_backgroundWorkerUILogs.IsBusy)
                m_backgroundWorkerUILogs.RunWorkerAsync();


            if (!m_backgroundWorkerIncomingMessage.IsBusy)
                m_backgroundWorkerIncomingMessage.RunWorkerAsync();

            if (!m_backgroundWorkerOutcomingMessage.IsBusy)
                m_backgroundWorkerOutcomingMessage.RunWorkerAsync();


        } 
        private void m_buttonStart_Click(object sender, EventArgs e)
        {
            //if (!m_backgroundWorker.IsBusy)
            //    m_backgroundWorker.RunWorkerAsync(); 

            int waitingMinuteToMiliSecond = Convert.ToInt32(m_settings.TrainFrequencyMinute) * 60000;
            int waitingSecondToMiliSecond = Convert.ToInt32(m_settings.TrainFrequencySecond) * 1000;
            int waitingMiliSecond = waitingMinuteToMiliSecond + waitingSecondToMiliSecond;


            AllTrainTimer.Change(0, waitingMiliSecond);
        }

        #region TrainMovementUIRefreshAllTrainList  

        public void TrainMovementUIRefreshAllTrainList(OBATP OBATP)
        {
            try
            {
                lock (m_movement)
                {
                    int index = m_allTrains.ToList().FindIndex(x => x == OBATP);
                    m_allTrains.ResetItem(index);

                    if ((DisplayManager.ComboBoxGetSelectedItemInvoke(m_comboBoxTrain) != null) && (DisplayManager.ComboBoxGetSelectedItemInvoke(m_comboBoxTrain).ToString() == OBATP.Vehicle.TrainName))
                    {
                        //general train
                        DisplayManager.TextBoxInvoke(m_textBoxCurrentTrainSpeedKM, OBATP.Vehicle.CurrentTrainSpeedKMH.ToString());
                        DisplayManager.TextBoxInvoke(m_textBoxCurrentLocation, OBATP.ActualFrontOfTrainCurrent.Location.ToString("0.##"));
                        DisplayManager.TextBoxInvoke(m_textBoxRearCurrentLocation, OBATP.ActualRearOfTrainCurrent.Location.ToString("0.##"));
                        DisplayManager.TextBoxInvoke(m_textBoxCurrentAcceleration, (OBATP.Vehicle.CurrentAcceleration / 100).ToString("0.##"));

                        if (OBATP.DoorStatus == Enums.DoorStatus.Open)
                        {
                            DisplayManager.PanelInvoke(panel1, Color.Red);
                            DisplayManager.PictureBoxInvoke(m_pictureBoxDoorStatus, Properties.Resources.dooropen);
                        }
                        else
                        {
                            DisplayManager.PanelInvoke(panel1, default(Color));
                            DisplayManager.PictureBoxInvoke(m_pictureBoxDoorStatus, Properties.Resources.doorclose);
                        }


                        ////if(OBATP.DoorTimerCounter.ToString() == "11")
                        ////{
                        ////    DisplayManager.LabelInvoke(m_labelDoorCounter, "");
                        ////}
                        ////else
                        ////{
                        ////DisplayManager.LabelInvoke(m_labelDoorCounter, OBATP.DoorTimerCounter.ToString()); 
                        ////}
                        ///

                        if (OBATP.zongurt.ToString() == "65535")
                        {
                            //DisplayManager.LabelInvokeWithColor(m_labelDoorCounter, "");
                            DisplayManager.LabelInvoke(m_labelDoorCounter, "");
                        }
                        else
                        {
                            //DisplayManager.LabelInvokeWithColor(m_labelDoorCounter, OBATP.zongurt.ToString());
                            DisplayManager.LabelInvoke(m_labelDoorCounter, OBATP.zongurt.ToString());
                            //DisplayManager.LabelInvoke(m_labelDoorCounter, "");
                        }


                        DisplayManager.TextBoxInvoke(m_textBoxDoorTimerCounter, OBATP.DoorTimerCounter.ToString());

                        //if (OBATP.DoorStatus == Enums.DoorStatus.Open)
                        //    DisplayManager.TextBoxInvoke(m_textBoxDoorStatus, "Open");
                        //else
                        //    DisplayManager.TextBoxInvoke(m_textBoxDoorStatus, "Close"); 
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "TrainMovementCreated");

            }

        }
    
        #endregion

        #region TrainMovementUI 
        public void TrainMovementUIRefreshTracksList(OBATP OBATP, UIOBATP UIOBATP)
        {
            try
            {
                lock (OBATP)
                {
                    if ((DisplayManager.ComboBoxGetSelectedItemInvoke(m_comboBoxTrain) != null) && (DisplayManager.ComboBoxGetSelectedItemInvoke(m_comboBoxTrain).ToString() == OBATP.Vehicle.TrainName))
                    {
                        //List<int> listValueRoute_Tracks = m_listView.Items.Cast<ListViewItem>().Select(item => Convert.ToInt32(item.Text)).ToList();
                        //bool difflistValuesRoute_Tracks = OBATP.m_route.Route_Tracks.Select(x => x.Track_ID).ToList().SequenceEqual(listValueRoute_Tracks);


                        //if (!difflistValuesRoute_Tracks)
                        if (UIOBATP.RefreshRouteTracks)
                        {

                            DisplayManager.ListViewItemsClearInvoke(m_listView);

                            //foreach (var item in OBATP.m_route.Route_Tracks)
                            foreach (var item in OBATP.movementTrack)
                            {
                                DisplayManager.ListViewItemsAddInvoke(m_listView, new ListViewItem(new string[] { item.Track_ID.ToString(), item.Station_Name, item.SpeedChangeVMax.ToString() }));
                            }

                            //DisplayManager.ListViewItemBackColorInvoke(m_listView, 0, Color.Red);  
                        }
                        else if (!UIOBATP.RefreshRouteTracks  && UIOBATP.NewMovementAuthorityTracksCome)
                        {
                            foreach (var item in UIOBATP.NewMovementAuthorityTracks)
                            {
                                DisplayManager.ListViewItemsAddInvoke(m_listView, new ListViewItem(new string[] { item.Track_ID.ToString(), item.Station_Name, item.SpeedChangeVMax.ToString() }));
                            }
                        }



                        //List<int> listValuesVirtualOccupation = m_listViewVirtualOccupation.Items.Cast<ListViewItem>().Select(item => Convert.ToInt32(item.Text)).ToList();
                        //bool difflistValuesVirtualOccupation = UIOBATP.TrainOnTracks.VirtualOccupationTracks.Select(x => x.Track_ID).ToList().SequenceEqual(listValuesVirtualOccupation);

                        //if (!difflistValuesVirtualOccupation)

                        if (UIOBATP.RefreshVirtualOccupationTracks)
                        {

                            DisplayManager.ListViewItemsClearInvoke(m_listViewVirtualOccupation);

                            foreach (var item in UIOBATP.TrainOnTracks.VirtualOccupationTracks)
                            {
                                DisplayManager.ListViewItemsAddInvoke(m_listViewVirtualOccupation, new ListViewItem(new string[] { item.Track_ID.ToString() }));
                            } 
                          
                        } 

                        if (UIOBATP.RefreshFootPrintTracks)
                        { 

                            DisplayManager.ListViewItemsClearInvoke(m_listViewFootPrintTracks);

                            foreach (var item in UIOBATP.TrainOnTracks.FootPrintTracks)
                            {
                                DisplayManager.ListViewItemsAddInvoke(m_listViewFootPrintTracks, new ListViewItem(new string[] { item.Track_ID.ToString() }));
                            } 
 
                        } 


                        if ((UIOBATP.RefreshActualLocationTracks) ||  (UIOBATP.RefreshRouteTracks))
                        {
                            m_listView.Invoke((Action)(() =>
                            {
                                //trenin tracklerini kırmızıya boyama
                                foreach (ListViewItem li in m_listView.Items)
                                {
                                    int itemText = Convert.ToInt32(li.Text);

                                    Track lolo = UIOBATP.TrainOnTracks.ActualLocationTracks.Find(x => x.Track_ID == itemText);

                                    if (lolo != null)
                                    {
                                        //li.ForeColor = Color.Red;
                                        li.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        li.BackColor = Color.White;
                                    }
                                }
                            }));
                        }
                        //else
                        //{
                        //    m_listView.Invoke((Action)(() =>
                        //    { 
                        //        //trenin tracklerini kırmızıya boyama
                        //        foreach (ListViewItem li in m_listView.Items)
                        //        {
                        //            int itemText = Convert.ToInt32(li.Text); 
                        //            Track lolo = UIOBATP.TrainOnTracks.ActualLocationTracks.Find(x => x.Track_ID == itemText);

                        //            if ((lolo != null) && (li.BackColor == Color.White))
                        //            { 
                        //                li.BackColor = Color.Red;
                        //            }
                                    
                        //        }

                        //    }));

                        //}



                    }
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "TrainMovementUI");

            }
        }
        #endregion

        #region TrainNewMovementAuthorityCreated

        public void TrainNewMovementAuthorityCreated(ThreadSafeList<Track> newMovementAuthorityList, UIOBATP UIOBATP)
        {

            //foreach (var item in newMovementAuthorityList)
            //{
            //    DisplayManager.ListViewItemsAddInvoke(m_listView, new ListViewItem(new string[] { item.Track_ID.ToString(), item.Station_Name, item.SpeedChangeVMax.ToString() }));
            //}
        }

        #endregion

        #region TrainMovementRouteCreated 
        public void TrainMovementRouteCreated(Route route)
        {
            //lock(m_newRoute)
            //{
            //    //if ((m_comboBoxTrain.SelectedItem != null) && (m_comboBoxTrain.SelectedItem.ToString() == OBATP.Vehicle.TrainName))
            //    {

            //        var ds = m_comboBoxTrain.SelectedItem;

            //        var dssadasd = m_comboBoxTrain.Text;
            //        var asdasdsaddssadasd = m_comboBoxTrain.SelectedText;

            //        if(dssadasd == "Train8")
            //        {

            //        }
            //        //m_listView.Items.Clear();
            //        //route.Route_Tracks.ForEach(x => m_listView.Items.Add(new ListViewItem(new string[] { x.Track_ID.ToString(), x.Station_Name, x.SpeedChangeVMax.ToString() }))); 

            //        List<int> listValueRoute_Tracks = m_listView.Items.Cast<ListViewItem>().Select(item => Convert.ToInt32(item.Text)).ToList();
            //        bool difflistValuesRoute_Tracks =  route.Route_Tracks.Select(x => x.Track_ID).ToList().SequenceEqual(listValueRoute_Tracks);


            //        if (!difflistValuesRoute_Tracks)
            //        {
            //            m_listView.Items.Clear();
                      
            //            foreach (var item in  route.Route_Tracks)
            //            {
            //                m_listView.Items.Add(new ListViewItem(new string[] { item.Track_ID.ToString(), item.Station_Name, item.SpeedChangeVMax.ToString() }));
            //            }
            //        }




            //    }
            //} 
        }

        #endregion

  

        private void m_trainItem_Click(object sender, EventArgs e)
        {
            TrainSettingsModal trainSettingsModal = new TrainSettingsModal();
            trainSettingsModal.Owner = this;

            bool isModalDisposed = trainSettingsModal.IsDisposed;

            if (!isModalDisposed)
                trainSettingsModal.ShowDialog();
        }

        private void m_generalItem_Click(object sender, EventArgs e)
        {
            //m_ATSSocket.Stop(Enums.CommunicationType.Client, SocketCommunication.ClientType.ATS); 

            GeneralSettingsModal generalSettingsModal = new GeneralSettingsModal(this);
            generalSettingsModal.Owner = this;


            bool isModalDisposed = generalSettingsModal.IsDisposed;

            if(!isModalDisposed)
                generalSettingsModal.ShowDialog();
        }
       
        private void m_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.STTimer.Start();
        }

     
        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (KeyValuePair<int, OBATP> item in m_allOBATP)
            {
                OBATP OBATP = item.Value;

                if (!m_allTrains.Contains(OBATP))
                    m_allTrains.Add(OBATP);


                if (OBATP.Status == Enums.Status.Create)
                {

                    //Track sdf =  MainForm.m_mf.m_YNK1_KIR2_YNK1.Find(x => x.Track_ID == 11402);

                    OBATP.SetStart(10101, true);

                    //OBATP.ActualFrontOfTrainCurrent.Track.Track_ID = 11402;
                    //OBATP.m_startTrackID = 11402;

                    OBATP.RequestStartProcess();
                    break;
                }
                else if (OBATP.Status == Enums.Status.Stop)
                {

                    OBATP.RequestStartProcess();
                }
            }

            int waitingMinuteToMiliSecond = Convert.ToInt32(m_settings.TrainFrequencyMinute) * 60000;
            int waitingSecondToMiliSecond = Convert.ToInt32(m_settings.TrainFrequencySecond) * 1000;
            int waitingMiliSecond = waitingMinuteToMiliSecond + waitingSecondToMiliSecond;

            this.STTimer.Interval = waitingMiliSecond;


            //var dsfıjop = m_allOBATP.Values.ToList();

        }


        public void ManageAllTrain(object o)
        {
            //try
            //{


            foreach (KeyValuePair<int, OBATP> item in m_allOBATP)
            {
                OBATP OBATP = item.Value;

                if (!m_allTrains.Contains(OBATP))
                    m_allTrains.Add(OBATP);


                if (OBATP.Status == Enums.Status.Create)
                {

                    //Track sdf =  MainForm.m_mf.m_YNK1_KIR2_YNK1.Find(x => x.Track_ID == 11402);

                    OBATP.SetStart(10101, true);

                    //OBATP.ActualFrontOfTrainCurrent.Track.Track_ID = 11402;
                    //OBATP.m_startTrackID = 11402;

                    OBATP.RequestStartProcess();
                    break;
                }
                else if (OBATP.Status == Enums.Status.Stop)
                {

                    OBATP.RequestStartProcess();
                }
            }


            int startOBATCCount = m_allOBATP.Values.ToList().Where(x => x.Status == Enums.Status.Start).Count();

            if (startOBATCCount == m_allOBATP.Count())
                AllTrainTimer.Change(Timeout.Infinite, Timeout.Infinite);

          
            //}
            //catch (ThreadInterruptedException ex)
            //{
            //    kontrol = false;
            //    sda();
            //    //Logging.WriteLog(DateTime.Now.ToString(), ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "socket1");

            //}
            //catch (Exception ex)
            //{
            //    kontrol = false;
            //    sda();
            //    //Logging.WriteLog(DateTime.Now.ToString(), ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "socket2");
            //}
        }


        public void DeleteInValidImages(object o)
        {
            //try
            //{

                m_settings = m_settings.DeSerialize(m_settings);
                //List<Track> route = Route.CreateNewRoute(10101, 10103, allTracks);


                Stopwatch sw = new Stopwatch();


                int counter = 0;


                foreach (KeyValuePair<int, OBATP> item in m_allOBATP)
                { 
                    OBATP OBATP = item.Value; 

                    //lock(OBATP)
                    {
                        if (!m_allTrains.Contains(OBATP))
                            m_allTrains.Add(OBATP);
                    }


                    //}

                    if(OBATP.Status == Enums.Status.Create)
                        OBATP.RequestStartProcess(); 

                }


            //}
            //catch (ThreadInterruptedException ex)
            //{
            //    kontrol = false;
            //    sda();
            //    //Logging.WriteLog(DateTime.Now.ToString(), ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "socket1");

            //}
            //catch (Exception ex)
            //{
            //    kontrol = false;
            //    sda();
            //    //Logging.WriteLog(DateTime.Now.ToString(), ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "socket2");
            //}
        }




        private void m_dataGridViewAllTrains_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void m_dataGridViewAllTrains_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void m_richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (m_richTextBoxCommunicationLogs.Text.Length > 5000)
            {
                
                m_richTextBoxCommunicationLogs.ResetText();
            }

            m_richTextBoxCommunicationLogs.ScrollToCaret();
        }

        private void m_mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void m_communicationItem_Click(object sender, EventArgs e)
        {
            CommunicationSettingsModal communicationSettingsModal = new CommunicationSettingsModal();
            communicationSettingsModal.Owner = this;

            bool isModalDisposed = communicationSettingsModal.IsDisposed;

            if (!isModalDisposed) 
                communicationSettingsModal.ShowDialog();
        }
         
        private void m_trainSimItem_Click(object sender, EventArgs e)
        {
            TrainSimModal trainSimModal = new TrainSimModal();
            trainSimModal.Owner = this;
            trainSimModal.Show();
        }

        private void m_routeItem_Click(object sender, EventArgs e)
        {
            TrackSettingsModal trackSettingsModal = new TrackSettingsModal();
            trackSettingsModal.Owner = this;
            trackSettingsModal.ShowDialog();
        }

        private void m_listViewVirtualOccupation_SelectedIndexChanged(object sender, EventArgs e)
        {

            int coun = 0;
            foreach (ListViewItem lvw in m_listViewVirtualOccupation.Items)
            {


                if (coun % 2 == 0)// lvw.SubItems[coun].ToString() == "True")
                {
                    lvw.ForeColor = Color.Red;
                }

                coun++;
            }

        }

   
        private void m_buttonStop_Click(object sender, EventArgs e)
        {
            //if(m_comboBoxTrain.SelectedItem != null)
            //{ 
            //    bool isGetValue = MainForm.m_allOBATP.TryGetValue(Convert.ToInt32(m_comboBoxTrain.SelectedIndex + 1), out OBATP OBATP);

            //    if (isGetValue)
            //        OBATP.RequestStopProcess();
            //}  

            if(STTimer.Enabled)
            {
                STTimer.Stop();
                STTimer.Interval = 1;
            }

            foreach (KeyValuePair<int, OBATP> item in m_allOBATP)
            {
                OBATP OBATP = item.Value;

                OBATP.RequestStopProcess();

            }
        }

        private void m_backgroundWorkerCommunicationLogs_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Tuple<DateTime, string, string> messageToWriteLog in m_communicationLogs.GetConsumingEnumerable())
            {

                if (m_settings.WriteLogATS_TO_OBATO || m_settings.WriteLogATS_TO_OBATO_Init || m_settings.WriteLogOBATO_TO_ATS || m_settings.WriteLogOBATP_TO_WSATP ||
                    m_settings.WriteLogWSATP_TO_OBATP)
                {
                    if (!string.IsNullOrEmpty(messageToWriteLog.Item3))
                    {
                        StringBuilder messageToWriteLogStringBuilder = new StringBuilder(messageToWriteLog.Item2);
                        messageToWriteLogStringBuilder.Replace("*", messageToWriteLog.Item3);

                        Logging.WriteCommunicationLog(messageToWriteLog.Item1, messageToWriteLogStringBuilder);
                    }
                    else
                    {
                        Logging.WriteCommunicationLog(messageToWriteLog.Item1, messageToWriteLog.Item2);

                    }
                }

                //if (m_settings.WriteLogSQL)
                //{
                //    string[] logToWriteSplitArray = messageToWriteLog.Item2.ToString().Split('\r');
                //    string idName = logToWriteSplitArray[2];
                //    string[] idNameSplitArray = idName.Split(' ');
                //    string id = idNameSplitArray[2];


                //    //Task<int> resultTask = m_databaseOperation.AsyncPOSTInsert(m_settings.PersonnelID, m_settings.PlayID, messageToWriteLog.Item1, messageToWriteLog.Item4, id);
                //    //resultTask.Wait();

                //    m_databaseOperation.POSTInsert(m_settings.PersonnelID, m_settings.PlayID, messageToWriteLog.Item1, messageToWriteLog.Item4, id);

                //}

            }
        }

        private void m_backgroundWorkerUILogs_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Tuple<string, Color> messageToWriteLog in m_UILogs.GetConsumingEnumerable())
            {
                Color col = new Color();

                //string splitText = messageToWriteLog.Item1.Split('-')[1].Trim();


                //if (splitText == "WSATC")
                //{
                //    col = Color.Red;
                //}
                //else if (splitText == "ATS")
                //{
                //    col = Color.Yellow;
                //}
                DisplayManager.RichTextBoxInvoke(m_richTextBoxCommunicationLogs, messageToWriteLog.Item1, Color.Red);

               

            }
        }

        public Enums.SettingsWindowStatus SettingsWindowStatus(Enums.SettingsWindowStatus settingsWindowStatus, Enums.SettingsWindow settingsWindow)
        {
            Enums.SettingsWindowStatus returnSettingsWindowStatus = Enums.SettingsWindowStatus.Cancel;

            if (settingsWindowStatus == Enums.SettingsWindowStatus.Open)
            {
             
                returnSettingsWindowStatus = settingsWindowStatus;
            }
            else if (settingsWindowStatus == Enums.SettingsWindowStatus.Save)
            {
                #region stop before start new settings
                if (STTimer.Enabled)
                {
                    STTimer.Stop();
                    STTimer.Interval = 1;
                }



                m_ATSSocket.Stop(m_settings.ATSCommunicationType, SocketCommunication.ClientType.ATS);
                m_WSATCSocket.Stop(m_settings.WSATCCommunicationType, SocketCommunication.ClientType.WSATC);



                foreach (KeyValuePair<int, OBATP> item in m_allOBATP)
                {
                    OBATP OBATP = item.Value;

                    if (m_allTrains.Contains(OBATP))
                        m_allTrains.Remove(OBATP);

                    if (OBATP.Status == Enums.Status.Start)
                    {
                        OBATP.RequestStopProcess();

                    }

                    OBATP.Dispose();

                    MainForm.m_WSATP_TO_OBATPMessageInComing.RemoveWatcher(OBATP);
                    MainForm.m_ATS_TO_OBATO_InitMessageInComing.RemoveWatcher(OBATP);
                    MainForm.m_ATS_TO_OBATO_MessageInComing.RemoveWatcher(OBATP);

                }

                m_allOBATP.Clear();
                m_comboBoxTrain.Items.Clear();

                DisplayManager.ListViewItemsClearInvoke(m_listView);
                DisplayManager.ListViewItemsClearInvoke(m_listViewVirtualOccupation);
                DisplayManager.ListViewItemsClearInvoke(m_listViewFootPrintTracks);

                DisplayManager.TextBoxClearInvoke(m_textBoxCurrentTrainSpeedKM);
                DisplayManager.TextBoxClearInvoke(m_textBoxCurrentLocation);
                DisplayManager.TextBoxClearInvoke(m_textBoxRearCurrentLocation);
                DisplayManager.TextBoxClearInvoke(m_textBoxCurrentAcceleration);


                DisplayManager.PanelInvoke(panel1, default(Color));
                DisplayManager.PictureBoxInvoke(m_pictureBoxDoorStatus, Properties.Resources.doorclose);

                m_labelDoorCounter.Text = "";

                m_richTextBoxCommunicationLogs.Clear();
                m_richTextBoxTrainsLogs.Clear();

                #endregion


                #region start with new settings
                m_settings = m_settings.DeSerialize(m_settings);

                m_ATSSocket.Start(m_settings.ATSCommunicationType, SocketCommunication.ClientType.ATS, m_settings.ATSIPAddress, Convert.ToInt32(m_settings.ATSPort));
                m_WSATCSocket.Start(m_settings.WSATCCommunicationType, SocketCommunication.ClientType.WSATC, m_settings.WSATCIPAddress, Convert.ToInt32(m_settings.WSATCPort));


                foreach (int index in m_settings.Trains)
                {
                    int trainIndex = index + 1;
                    Enums.Train_ID train_ID = (Enums.Train_ID)trainIndex;

                    OBATP OBATP = new OBATP(train_ID, m_settings.MaxTrainAcceleration, m_settings.MaxTrainDeceleration, m_settings.TrainSpeedLimit, m_settings.TrainLength);


                    m_allOBATP.TryAdd(trainIndex, OBATP);

                    m_comboBoxTrain.Items.Add(train_ID.ToString());

                    MainForm.m_WSATP_TO_OBATPMessageInComing.AddWatcher(OBATP);
                    MainForm.m_ATS_TO_OBATO_InitMessageInComing.AddWatcher(OBATP);
                    MainForm.m_ATS_TO_OBATO_MessageInComing.AddWatcher(OBATP);
                }

                if (m_comboBoxTrain.Items.Count > 0)
                    m_comboBoxTrain.SelectedIndex = 0;

                #endregion



                LocalizationControlsText();
            } 

            else
            {
                #region stop before start new settings
                if (STTimer.Enabled)
                {
                    STTimer.Stop();
                    STTimer.Interval = 1;
                }



                m_ATSSocket.Stop(m_settings.ATSCommunicationType, SocketCommunication.ClientType.ATS);
                m_WSATCSocket.Stop(m_settings.WSATCCommunicationType, SocketCommunication.ClientType.WSATC);



                foreach (KeyValuePair<int, OBATP> item in m_allOBATP)
                {
                    OBATP OBATP = item.Value;

                    if (m_allTrains.Contains(OBATP))
                        m_allTrains.Remove(OBATP);

                    if (OBATP.Status == Enums.Status.Start)
                    {
                        OBATP.RequestStopProcess();

                    }

                    OBATP.Dispose();

                    MainForm.m_WSATP_TO_OBATPMessageInComing.RemoveWatcher(OBATP);
                    MainForm.m_ATS_TO_OBATO_InitMessageInComing.RemoveWatcher(OBATP);
                    MainForm.m_ATS_TO_OBATO_MessageInComing.RemoveWatcher(OBATP);

                }

                m_allOBATP.Clear();
                m_comboBoxTrain.Items.Clear();

                DisplayManager.ListViewItemsClearInvoke(m_listView);
                DisplayManager.ListViewItemsClearInvoke(m_listViewVirtualOccupation);
                DisplayManager.ListViewItemsClearInvoke(m_listViewFootPrintTracks);

                DisplayManager.TextBoxClearInvoke(m_textBoxCurrentTrainSpeedKM);
                DisplayManager.TextBoxClearInvoke(m_textBoxCurrentLocation);
                DisplayManager.TextBoxClearInvoke(m_textBoxRearCurrentLocation);
                DisplayManager.TextBoxClearInvoke(m_textBoxCurrentAcceleration);


                DisplayManager.PanelInvoke(panel1, default(Color));
                DisplayManager.PictureBoxInvoke(m_pictureBoxDoorStatus, Properties.Resources.doorclose);

                m_labelDoorCounter.Text = "";

                m_richTextBoxCommunicationLogs.Clear();
                m_richTextBoxTrainsLogs.Clear();

                #endregion


                #region start with new settings
                m_settings = m_settings.DeSerialize(m_settings);

                m_ATSSocket.Start(m_settings.ATSCommunicationType, SocketCommunication.ClientType.ATS, m_settings.ATSIPAddress, Convert.ToInt32(m_settings.ATSPort));
                m_WSATCSocket.Start(m_settings.WSATCCommunicationType, SocketCommunication.ClientType.WSATC, m_settings.WSATCIPAddress, Convert.ToInt32(m_settings.WSATCPort));


                foreach (int index in m_settings.Trains)
                {
                    int trainIndex = index + 1;
                    Enums.Train_ID train_ID = (Enums.Train_ID)trainIndex;

                    OBATP OBATP = new OBATP(train_ID, m_settings.MaxTrainAcceleration, m_settings.MaxTrainDeceleration, m_settings.TrainSpeedLimit, m_settings.TrainLength);


                    m_allOBATP.TryAdd(trainIndex, OBATP);

                    m_comboBoxTrain.Items.Add(train_ID.ToString());

                    MainForm.m_WSATP_TO_OBATPMessageInComing.AddWatcher(OBATP);
                    MainForm.m_ATS_TO_OBATO_InitMessageInComing.AddWatcher(OBATP);
                    MainForm.m_ATS_TO_OBATO_MessageInComing.AddWatcher(OBATP);
                }

                if (m_comboBoxTrain.Items.Count > 0)
                    m_comboBoxTrain.SelectedIndex = 0;

                #endregion 





            }

            return returnSettingsWindowStatus;

        }

        private void m_richTextBoxTrainsLogs_TextChanged(object sender, EventArgs e)
        {
            if (m_richTextBoxTrainsLogs.Text.Length > 5000)
            {

                m_richTextBoxTrainsLogs.ResetText();
            }

            m_richTextBoxTrainsLogs.ScrollToCaret();
        }

        private void m_backgroundWorkerIncomingMessage_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Tuple<DateTime, string, string> messageToWriteLog in m_incomingMessageLogs.GetConsumingEnumerable())
            {
                string writeMessage = "";


                if (!string.IsNullOrEmpty(messageToWriteLog.Item3))
                {
                    StringBuilder messageToWriteLogStringBuilder = new StringBuilder(messageToWriteLog.Item2);
                    messageToWriteLogStringBuilder.Replace("*", messageToWriteLog.Item3);

                    string[] logToWriteSplitArray = messageToWriteLogStringBuilder.ToString().Split('\n');
                    string sizeName = logToWriteSplitArray[1];
                    string[] sizeNameSplitArray = sizeName.Split(' ');
                    string idPath = sizeNameSplitArray[2];

                    string DST = logToWriteSplitArray[3];
                    string[] DSTSplitArray = DST.Split(' ');

                    uint msgDST = Convert.ToUInt32(DSTSplitArray[2].Trim());

                    uint lastdigit = (msgDST % 100);
                    Enums.Train_ID train_ID = (Enums.Train_ID)lastdigit;




                    writeMessage = string.Format("{0} {1} {2}", messageToWriteLog.Item1.ToString("MM.dd.yyyy HH:mm:ss-ffffff"), idPath, train_ID.ToString());// "");
                }
                else
                {
                    writeMessage = string.Format("{0} {1} {2}", messageToWriteLog.Item1.ToString("MM.dd.yyyy HH:mm:ss-ffffff"), messageToWriteLog.Item2, "");
                }

                //if (DisplayManager.TabControlSelectedIndexInvoke(MainForm.m_mf.m_tabControlLogs) == 1)
                    DisplayManager.RichTextBoxInvoke(m_richTextBoxIncomingMessage, writeMessage, Color.Red);

            }
        }

        private void m_backgroundWorkerOutcomingMessage_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Tuple<DateTime, string, string> messageToWriteLog in m_outcomingMessageLogs.GetConsumingEnumerable())
            {

                StringBuilder messageToWriteLogStringBuilder = new StringBuilder(messageToWriteLog.Item2);
                messageToWriteLogStringBuilder.Replace("*", messageToWriteLog.Item3);

                string[] logToWriteSplitArray = messageToWriteLogStringBuilder.ToString().Split('\n');
                string sizeName = logToWriteSplitArray[1];
                string[] sizeNameSplitArray = sizeName.Split(' ');
                string idPath = sizeNameSplitArray[2];


                string SRC = logToWriteSplitArray[4];
                string[] SRCSplitArray = SRC.Split(' ');

                uint msgSRC = Convert.ToUInt32(SRCSplitArray[2].Trim());

                uint lastdigit = (msgSRC % 100);
                Enums.Train_ID train_ID = (Enums.Train_ID)lastdigit;


                string writeMessage = string.Format("{0} {1} {2}", messageToWriteLog.Item1.ToString("MM.dd.yyyy HH:mm:ss-ffffff"), idPath, train_ID.ToString());// "");

                //if (DisplayManager.TabControlSelectedIndexInvoke(m_tabControlLogs) == 2)
                    DisplayManager.RichTextBoxInvoke(m_richTextBoxOutgoingMessage, writeMessage, Color.Red);



            }
        }

        private void m_richTextBoxIncomingMessage_TextChanged(object sender, EventArgs e)
        {
            if (m_richTextBoxIncomingMessage.Text.Length > 5000)
            {

                m_richTextBoxIncomingMessage.ResetText();
            }

            m_richTextBoxIncomingMessage.ScrollToCaret();
        }

        private void m_richTextBoxOutgoingMessage_TextChanged(object sender, EventArgs e)
        {
            if (m_richTextBoxOutgoingMessage.Text.Length > 5000)
            {

                m_richTextBoxOutgoingMessage.ResetText();
            }

            m_richTextBoxOutgoingMessage.ScrollToCaret();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }



        internal int m_doubleClickTrainID = 0;

        private void m_dataGridViewAllTrains_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_doubleClickTrainID  = Convert.ToInt32(m_dataGridViewAllTrains[0, e.RowIndex].Value);

            TrainDetailModal trainDetailModal = new TrainDetailModal(this);
            trainDetailModal.Owner = this;

            trainDetailModal.ShowDialog();

     
        }

        private void outgoingMsgCounterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void m_incomingMsgStatusInformationPopup_Click(object sender, EventArgs e)
        {
            //ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;

            //if (toolStripMenuItem == m_incomingMsgStatusInformationPopup)
            //{
            //    if (m_incomingMsgStatus)
            //    {
            //        m_incomingMsgStatus = false;

            //        m_incomingMsgStatusInformationPopup.Text = "TCP Comm. On";
            //    }
            //    else
            //    {
            //        m_incomingMsgStatus = true;

            //        m_incomingMsgStatusInformationPopup.Text = "TCP Comm. Off";
            //    }
            
            //}
            //else if (toolStripMenuItem == m_outgoingMsgStatusInformationPopup)
            //{
            //    if (m_outgoingMsgStatus)
            //    {
            //        m_outgoingMsgStatus = false;

            //        m_outgoingMsgStatusInformationPopup.Text = "TCP Comm. On";
            //    }
            //    else
            //    {
            //        m_outgoingMsgStatus = true;

            //        m_outgoingMsgStatusInformationPopup.Text = "TCP Comm. Off";
            //    }
            //}
        }

        private void m_comboBoxTrain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
