using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    class OBATO_TO_ATSAdaptee
    {
        dynamic m_messageType;

        public bool OBATCActive { get; set; }
        public bool TrainEmergencyBrakeApplied { get; set; }
        public bool WaitingApprovalReleaseEmergencyBrake { get; set; }
        public bool TrainEmergencyBrakeReleased { get; set; }
        public bool EmergencyHandleActive { get; set; }

        public bool TrainTemporaryCoastingAccepted { get; set; }
        public bool TrainTemporaryCoastingRejected { get; set; }
        public bool HoldTrainAccepted { get; set; }
        public bool HoldTrainRejected { get; set; }
        public bool CancelHoldTrainAccepted { get; set; }


        public bool SkipStationAccepted { get; set; }
        public bool SkipStationRejected { get; set; }
        public bool CancelSkipStationAccepted { get; set; }
        public bool CancelSkipStationRejected { get; set; }
        public bool StandbyActive { get; set; }

        public bool StandbyCmdRejected { get; set; }
        public Enums.DoorStatus TrainLeftDoorOpened { get; set; }
        public bool TrainRightDoorOpened { get; set; }
        public Enums.DoorStatus TrainDoorClosedAndLocked { get; set; }
        public bool TrainDoorClosedAndLockedFault { get; set; }

        public bool TrainDoorWrongSideOpenedFault { get; set; }
        public bool DoorFaultAtStandby { get; set; }
        public bool DerailmentDetection { get; set; }
        public bool FireDetection { get; set; }
        public bool ObstacleDetection { get; set; }

        public bool BerthingOK { get; set; }
        public bool UnsuccessfulBerthingAlarm { get; set; }
        public bool TrainIntegrityAlarm { get; set; }
        public bool TrainActiveCab { get; set; }
        public Enums.TrainDirection TrainDirection { get; set; }
        //
        public bool OBATCOff { get; set; }
        public bool OBATCClockFault { get; set; }
        public bool TrainDepartureFailure { get; set; }
        public bool TrainRollBack { get; set; }
        public bool BatteryOK { get; set; }
        public bool TractionStatus { get; set; }
        public bool BrakingStatus { get; set; }
        public Enums.TrainCBTCMode TrainCBTCMode { get; set; }
        public int PerformanceLevel { get; set; }
        public int OBATCSoftwareVersion { get; set; }
        public int OBATCHardwareVersion { get; set; }
        public int TrainNumber { get; set; }
        public Enums.TrainSetCarNumber TrainSetCarNumber { get; set; }
        public int TrainSpeed { get; set; }
        public ushort[] FootPrintTrackSectionID { get; set; } = new ushort[15];

        public double FootPrintFirstTrackSectionOffset { get; set; }
        public double FootPrintLastTrackSectionOffset { get; set; }


        //public ushort VirtualOccupancyTrackSectionID { get; set; }
        public ushort[] VirtualOccupancyTrackSectionID { get; set; } = new ushort[20];

        public double VirtualOccupancyFirstTrackSectionOffset { get; set; }
        public double VirtualOccupancyLastTrackSectionOffset { get; set; }


        public ushort OBATCEquipmentStatus { get; set; }
        public ushort OBATCWarning1 { get; set; }
        public ushort OBATCWarning2 { get; set; }
        public ushort OBATCWarning3 { get; set; }
        public ushort OBATCWarning4 { get; set; }
        public ushort OBATCWarning5 { get; set; }
        public ushort OBATCFault1 { get; set; }
        public ushort OBATCFault2 { get; set; }
        public ushort OBATCEquipmentFault1 { get; set; }
        public ushort OBATCEquipmentFault2 { get; set; }
        public ushort OBATCEquipmentFault3 { get; set; }
        //

        public ushort OBATCEquipmentFault4 { get; set; }
        public ushort OBATCEquipmentFault5 { get; set; }
        public ushort TrainFault1 { get; set; }
        public ushort TrainFault2 { get; set; }
        public ushort TrainFault3 { get; set; }

        public ushort TrainFault4 { get; set; }
        public ushort TrainFault5 { get; set; }
        public Enums.TrainCoupled TrainCoupled { get; set; }
        public int DwellTime { get; set; }


        //buradan aşağısı sonra ayarlanacak
        public byte OBATCtoATS_ReverseTrafficDirection { get; set; }
        public byte OBATCtoATS_RejectedStopTrainAtNextStation { get; set; }
        public byte OBATCtoATS_TrainLocationDeterminationFault { get; set; }
        public byte OBATCtoATS_TrainSpeedSensorFault { get; set; }
        public byte OBATCtoATS_MissedBalise { get; set; }
        public byte OBATCtoATS_DepartureTestStarted { get; set; }
        public byte OBATCtoATS_DepartureTestResults { get; set; }
        public bool OBATCtoATS_OverspeedAlarm { get; set; }
        public bool OBATCtoATS_SafeDistanceAlarm { get; set; }
        public bool OBATCtoATS_UnsuccessfulTrainStop { get; set; }
        public bool OBATCtoATS_UnexpectedSkipStation { get; set; }
        public bool OBATCtoATS_PSDEnableFault { get; set; }
        public bool OBATCtoATS_TrainDoorEnableFault { get; set; }
        public bool OBATCtoATS_PSDOpenFault { get; set; }
        public bool OBATCtoATS_TrainDoorOpenFault { get; set; }


        //bit conversation işlemleri
        public bool FaultyTrainDoors1_1 { get; set; }
        public bool FaultyTrainDoors1_2 { get; set; }
        public bool FaultyTrainDoors1_3 { get; set; }
        public bool FaultyTrainDoors1_4 { get; set; }
        public bool FaultyTrainDoors1_5 { get; set; }
        public bool FaultyTrainDoors1_6 { get; set; }
        public bool FaultyTrainDoors1_7 { get; set; }
        public bool FaultyTrainDoors1_8 { get; set; }
        public bool FaultyTrainDoors1_9 { get; set; }
        public bool FaultyTrainDoors1_10 { get; set; }
        public bool FaultyTrainDoors1_11 { get; set; }
        public bool FaultyTrainDoors1_12 { get; set; }
        public bool FaultyTrainDoors1_13 { get; set; }
        public bool FaultyTrainDoors1_14 { get; set; }
        public bool FaultyTrainDoors1_15 { get; set; }
        public bool FaultyTrainDoors1_16 { get; set; }
        public bool FaultyTrainDoors1_17 { get; set; }
        public bool FaultyTrainDoors1_18 { get; set; }
        public bool FaultyTrainDoors1_19 { get; set; }
        public bool FaultyTrainDoors1_20 { get; set; }
        public bool FaultyTrainDoors1_21 { get; set; }
        public bool FaultyTrainDoors1_22 { get; set; }
        public bool FaultyTrainDoors1_23 { get; set; }
        public bool FaultyTrainDoors1_24 { get; set; }




        public bool FaultyTrainDoors2_1 { get; set; }
        public bool FaultyTrainDoors2_2 { get; set; }
        public bool FaultyTrainDoors2_3 { get; set; }
        public bool FaultyTrainDoors2_4 { get; set; }
        public bool FaultyTrainDoors2_5 { get; set; }
        public bool FaultyTrainDoors2_6 { get; set; }
        public bool FaultyTrainDoors2_7 { get; set; }
        public bool FaultyTrainDoors2_8 { get; set; }
        public bool FaultyTrainDoors2_9 { get; set; }
        public bool FaultyTrainDoors2_10 { get; set; }
        public bool FaultyTrainDoors2_11 { get; set; }
        public bool FaultyTrainDoors2_12 { get; set; }
        public bool FaultyTrainDoors2_13 { get; set; }
        public bool FaultyTrainDoors2_14 { get; set; }
        public bool FaultyTrainDoors2_15 { get; set; }
        public bool FaultyTrainDoors2_16 { get; set; }
        public bool FaultyTrainDoors2_17 { get; set; }
        public bool FaultyTrainDoors2_18 { get; set; }
        public bool FaultyTrainDoors2_19 { get; set; }
        public bool FaultyTrainDoors2_20 { get; set; }
        public bool FaultyTrainDoors2_21 { get; set; }
        public bool FaultyTrainDoors2_22 { get; set; }
        public bool FaultyTrainDoors2_23 { get; set; }
        public bool FaultyTrainDoors2_24 { get; set; }




        public bool BypassedTrainDoors1_1 { get; set; }
        public bool BypassedTrainDoors1_2 { get; set; }
        public bool BypassedTrainDoors1_3 { get; set; }
        public bool BypassedTrainDoors1_4 { get; set; }
        public bool BypassedTrainDoors1_5 { get; set; }
        public bool BypassedTrainDoors1_6 { get; set; }
        public bool BypassedTrainDoors1_7 { get; set; }
        public bool BypassedTrainDoors1_8 { get; set; }
        public bool BypassedTrainDoors1_9 { get; set; }
        public bool BypassedTrainDoors1_10 { get; set; }
        public bool BypassedTrainDoors1_11 { get; set; }
        public bool BypassedTrainDoors1_12 { get; set; }
        public bool BypassedTrainDoors1_13 { get; set; }
        public bool BypassedTrainDoors1_14 { get; set; }
        public bool BypassedTrainDoors1_15 { get; set; }
        public bool BypassedTrainDoors1_16 { get; set; }
        public bool BypassedTrainDoors1_17 { get; set; }
        public bool BypassedTrainDoors1_18 { get; set; }
        public bool BypassedTrainDoors1_19 { get; set; }
        public bool BypassedTrainDoors1_20 { get; set; }
        public bool BypassedTrainDoors1_21 { get; set; }
        public bool BypassedTrainDoors1_22 { get; set; }
        public bool BypassedTrainDoors1_23 { get; set; }
        public bool BypassedTrainDoors1_24 { get; set; }



        public bool BypassedTrainDoors2_1 { get; set; }
        public bool BypassedTrainDoors2_2 { get; set; }
        public bool BypassedTrainDoors2_3 { get; set; }
        public bool BypassedTrainDoors2_4 { get; set; }
        public bool BypassedTrainDoors2_5 { get; set; }
        public bool BypassedTrainDoors2_6 { get; set; }
        public bool BypassedTrainDoors2_7 { get; set; }
        public bool BypassedTrainDoors2_8 { get; set; }
        public bool BypassedTrainDoors2_9 { get; set; }
        public bool BypassedTrainDoors2_10 { get; set; }
        public bool BypassedTrainDoors2_11 { get; set; }
        public bool BypassedTrainDoors2_12 { get; set; }
        public bool BypassedTrainDoors2_13 { get; set; }
        public bool BypassedTrainDoors2_14 { get; set; }
        public bool BypassedTrainDoors2_15 { get; set; }
        public bool BypassedTrainDoors2_16 { get; set; }
        public bool BypassedTrainDoors2_17 { get; set; }
        public bool BypassedTrainDoors2_18 { get; set; }
        public bool BypassedTrainDoors2_19 { get; set; }
        public bool BypassedTrainDoors2_20 { get; set; }
        public bool BypassedTrainDoors2_21 { get; set; }
        public bool BypassedTrainDoors2_22 { get; set; }
        public bool BypassedTrainDoors2_23 { get; set; }
        public bool BypassedTrainDoors2_24 { get; set; }





        [Browsable(false)]
        public ushort[] footPrintTracks = new ushort[15];
        [Browsable(false)]
        public ushort[] virtualOccupationTracks = new ushort[20];






        private static readonly object m_reverse = new object();

        public OBATO_TO_ATSAdaptee(OBATP OBATP)
        {
            try
            {

          
            m_messageType = (OBATP)OBATP;

            this.OBATCActive = false;
            this.TrainEmergencyBrakeApplied = false;
            this.WaitingApprovalReleaseEmergencyBrake = false;
            this.TrainEmergencyBrakeReleased = false;
            this.EmergencyHandleActive = false;

            this.TrainTemporaryCoastingAccepted = false;
            this.TrainTemporaryCoastingRejected = false;


                


                //hold station
                if (OBATP.HoldTrainStatus == Enums.HoldTrain.Accepted)
                {
                    this.HoldTrainAccepted = true;
                    this.HoldTrainRejected = false;
                }
                else if (OBATP.HoldTrainStatus == Enums.HoldTrain.Rejected)
                {
                    this.HoldTrainAccepted = false;
                    this.HoldTrainRejected = true;
                }
                else if (OBATP.HoldTrainStatus == Enums.HoldTrain.Non)
                {
                    this.HoldTrainAccepted = false;
                    this.HoldTrainRejected = false;
                }






                this.CancelHoldTrainAccepted = OBATP.CancelHoldStationAccepted;




                //skip station
                if (OBATP.SkipStationStatus == Enums.SkipStation.Accepted)
                {
                    this.SkipStationAccepted = true;
                    this.SkipStationRejected = false;
                }
                else if (OBATP.SkipStationStatus == Enums.SkipStation.Rejected)
                {
                    this.SkipStationAccepted = false;
                    this.SkipStationRejected = true;
                }
                else if (OBATP.SkipStationStatus == Enums.SkipStation.Non)
                {
                    this.SkipStationAccepted = false;
                    this.SkipStationRejected = false;
                }

                 

                if (OBATP.CancelSkipStationStatus == Enums.CancelSkipStation.Accepted)
                {
                    this.CancelSkipStationAccepted = true;
                    this.CancelSkipStationRejected = false;
                }
                else if (OBATP.CancelSkipStationStatus == Enums.CancelSkipStation.Rejected)
                {
                    this.CancelSkipStationAccepted = false;
                    this.CancelSkipStationRejected = true;
                }
                else if (OBATP.CancelSkipStationStatus == Enums.CancelSkipStation.Non)
                {
                    this.CancelSkipStationAccepted = false;
                    this.CancelSkipStationRejected = false;
                }

           

               
            this.StandbyActive = false;

            this.StandbyCmdRejected = false;
            this.TrainLeftDoorOpened = OBATP.DoorStatus;
            this.TrainRightDoorOpened = false;
            this.TrainDoorClosedAndLocked = OBATP.DoorStatus;
            this.TrainDoorClosedAndLockedFault = false;

            this.TrainDoorWrongSideOpenedFault = false;
            this.DoorFaultAtStandby = false;
            this.DerailmentDetection = false;
            this.FireDetection = false;
            this.ObstacleDetection = false;

            this.BerthingOK = OBATP.OBATCtoWSATC_BerthingOk;
            this.UnsuccessfulBerthingAlarm = false;
            this.TrainIntegrityAlarm = false;
            this.TrainActiveCab = false;






            Enums.TrainDirection trainDirection;

            if (OBATP.Direction == Enums.Direction.Left)
                trainDirection = Enums.TrainDirection.ToYenikapı;
            else
                trainDirection = Enums.TrainDirection.FromYenikapı;

            this.TrainDirection = trainDirection;
            //
            this.OBATCOff = false;
            this.OBATCClockFault = false;
            this.TrainDepartureFailure = false;
            this.TrainRollBack = false;
            this.BatteryOK = false;
            this.TractionStatus = false;
            this.BrakingStatus = false;

            //

            this.TrainCBTCMode = Enums.TrainCBTCMode.UTO;
            this.PerformanceLevel = 0;
            this.OBATCSoftwareVersion = 0;
            this.OBATCHardwareVersion = 0;

            this.TrainNumber = Convert.ToInt32(OBATP.Vehicle.TrainID);

            this.TrainSetCarNumber = Enums.TrainSetCarNumber.Four;


            this.TrainSpeed = Convert.ToInt32(OBATP.Vehicle.CurrentTrainSpeedKMH);


                TrackWithPosition LocalFrontOfTrainTrackWithFootPrint = OBATP.FrontOfTrainTrackWithFootPrint;
                TrackWithPosition LocalRearOfTrainTrackWithFootPrint = OBATP.RearOfTrainTrackWithFootPrint; 


         
                footPrintTracks = HelperClass.FindTrackRangeInAllTracks(LocalFrontOfTrainTrackWithFootPrint.Track, LocalRearOfTrainTrackWithFootPrint.Track, OBATP.movementTrack);


                {
                    Array.Reverse(footPrintTracks);
                }
             

            Array.Copy(footPrintTracks, this.FootPrintTrackSectionID, footPrintTracks.Length);
                





                this.FootPrintFirstTrackSectionOffset = Math.Abs(LocalFrontOfTrainTrackWithFootPrint.Location);
                this.FootPrintLastTrackSectionOffset = Math.Abs(LocalRearOfTrainTrackWithFootPrint.Location);





                TrackWithPosition LocalFrontOfTrainVirtualOccupation = OBATP.FrontOfTrainVirtualOccupation;
                TrackWithPosition LocalRearOfTrainVirtualOccupation = OBATP.RearOfTrainVirtualOccupation;
                virtualOccupationTracks = HelperClass.FindTrackRangeInAllTracks(LocalFrontOfTrainVirtualOccupation.Track, LocalRearOfTrainVirtualOccupation.Track, OBATP.movementTrack);

               
                {
                    Array.Reverse(virtualOccupationTracks);

                }
                {
                    Array.Copy(virtualOccupationTracks, this.VirtualOccupancyTrackSectionID, virtualOccupationTracks.Length);

                }
        

            this.VirtualOccupancyFirstTrackSectionOffset = Math.Abs(LocalFrontOfTrainVirtualOccupation.Location);
                this.VirtualOccupancyLastTrackSectionOffset = Math.Abs(LocalRearOfTrainVirtualOccupation.Location);


                //belli olmayanlar

                this.TrainCoupled = Enums.TrainCoupled.NotCoupled;


            if(OBATP.ActualFrontOfTrainCurrent.Track != null)
            {
                    if (OBATP.zongurt == -1)
                        this.DwellTime = 0;//.ActualFrontOfTrainCurrent.Track.DwellTime;
                    else
                        this.DwellTime = OBATP.zongurt;//.ActualFrontOfTrainCurrent.Track.DwellTime;
                }
               

            //belli olmayanlar


            this.OBATCtoATS_OverspeedAlarm = false;
            this.OBATCtoATS_SafeDistanceAlarm = false;
            this.OBATCtoATS_UnsuccessfulTrainStop = false;
            this.OBATCtoATS_UnexpectedSkipStation = false;
            this.OBATCtoATS_PSDEnableFault = false;
            this.OBATCtoATS_TrainDoorEnableFault = false;
            this.OBATCtoATS_PSDOpenFault = false;
            this.OBATCtoATS_TrainDoorOpenFault = false;


            //bit conversation
            this.FaultyTrainDoors1_1 = false;
            this.FaultyTrainDoors1_2 = false;
            this.FaultyTrainDoors1_3 = false;
            this.FaultyTrainDoors1_4 = false;
            this.FaultyTrainDoors1_5 = false;
            this.FaultyTrainDoors1_6 = false;
            this.FaultyTrainDoors1_7 = false;
            this.FaultyTrainDoors1_8 = false;
            this.FaultyTrainDoors1_9 = false;
            this.FaultyTrainDoors1_10 = false;
            this.FaultyTrainDoors1_11 = false;
            this.FaultyTrainDoors1_12 = false;
            this.FaultyTrainDoors1_13 = false;
            this.FaultyTrainDoors1_14 = false;
            this.FaultyTrainDoors1_15 = false;
            this.FaultyTrainDoors1_16 = false;
            this.FaultyTrainDoors1_17 = false;
            this.FaultyTrainDoors1_18 = false;
            this.FaultyTrainDoors1_19 = false;
            this.FaultyTrainDoors1_20 = false;
            this.FaultyTrainDoors1_21 = false;
            this.FaultyTrainDoors1_22 = false;
            this.FaultyTrainDoors1_23 = false;
            this.FaultyTrainDoors1_24 = false;




            this.FaultyTrainDoors2_1 = false;
            this.FaultyTrainDoors2_2 = false;
            this.FaultyTrainDoors2_3 = false;
            this.FaultyTrainDoors2_4 = false;
            this.FaultyTrainDoors2_5 = false;
            this.FaultyTrainDoors2_6 = false;
            this.FaultyTrainDoors2_7 = false;
            this.FaultyTrainDoors2_8 = false;
            this.FaultyTrainDoors2_9 = false;
            this.FaultyTrainDoors2_10 = false;
            this.FaultyTrainDoors2_11 = false;
            this.FaultyTrainDoors2_12 = false;
            this.FaultyTrainDoors2_13 = false;
            this.FaultyTrainDoors2_14 = false;
            this.FaultyTrainDoors2_15 = false;
            this.FaultyTrainDoors2_16 = false;
            this.FaultyTrainDoors2_17 = false;
            this.FaultyTrainDoors2_18 = false;
            this.FaultyTrainDoors2_19 = false;
            this.FaultyTrainDoors2_20 = false;
            this.FaultyTrainDoors2_21 = false;
            this.FaultyTrainDoors2_22 = false;
            this.FaultyTrainDoors2_23 = false;
            this.FaultyTrainDoors2_24 = false;




            this.BypassedTrainDoors1_1 = false;
            this.BypassedTrainDoors1_2 = false;
            this.BypassedTrainDoors1_3 = false;
            this.BypassedTrainDoors1_4 = false;
            this.BypassedTrainDoors1_5 = false;
            this.BypassedTrainDoors1_6 = false;
            this.BypassedTrainDoors1_7 = false;
            this.BypassedTrainDoors1_8 = false;
            this.BypassedTrainDoors1_9 = false;
            this.BypassedTrainDoors1_10 = false;
            this.BypassedTrainDoors1_11 = false;
            this.BypassedTrainDoors1_12 = false;
            this.BypassedTrainDoors1_13 = false;
            this.BypassedTrainDoors1_14 = false;
            this.BypassedTrainDoors1_15 = false;
            this.BypassedTrainDoors1_16 = false;
            this.BypassedTrainDoors1_17 = false;
            this.BypassedTrainDoors1_18 = false;
            this.BypassedTrainDoors1_19 = false;
            this.BypassedTrainDoors1_20 = false;
            this.BypassedTrainDoors1_21 = false;
            this.BypassedTrainDoors1_22 = false;
            this.BypassedTrainDoors1_23 = false;
            this.BypassedTrainDoors1_24 = false;



            this.BypassedTrainDoors2_1 = false;
            this.BypassedTrainDoors2_2 = false;
            this.BypassedTrainDoors2_3 = false;
            this.BypassedTrainDoors2_4 = false;
            this.BypassedTrainDoors2_5 = false;
            this.BypassedTrainDoors2_6 = false;
            this.BypassedTrainDoors2_7 = false;
            this.BypassedTrainDoors2_8 = false;
            this.BypassedTrainDoors2_9 = false;
            this.BypassedTrainDoors2_10 = false;
            this.BypassedTrainDoors2_11 = false;
            this.BypassedTrainDoors2_12 = false;
            this.BypassedTrainDoors2_13 = false;
            this.BypassedTrainDoors2_14 = false;
            this.BypassedTrainDoors2_15 = false;
            this.BypassedTrainDoors2_16 = false;
            this.BypassedTrainDoors2_17 = false;
            this.BypassedTrainDoors2_18 = false;
            this.BypassedTrainDoors2_19 = false;
            this.BypassedTrainDoors2_20 = false;
            this.BypassedTrainDoors2_21 = false;
            this.BypassedTrainDoors2_22 = false;
            this.BypassedTrainDoors2_23 = false;
            this.BypassedTrainDoors2_24 = false;
            }

            catch (Exception ex)
            {

            }
        }


        public OBATO_TO_ATSAdaptee(IMessageType OBATP)
        {
            m_messageType = (OBATO_TO_ATS)OBATP;

            this.OBATCActive = false;
            this.TrainEmergencyBrakeApplied = false;
            this.WaitingApprovalReleaseEmergencyBrake = false;
            this.TrainEmergencyBrakeReleased = false;
            this.EmergencyHandleActive = false;

            this.TrainTemporaryCoastingAccepted = false;
            this.TrainTemporaryCoastingRejected = false;
            this.HoldTrainAccepted = false;
            this.HoldTrainRejected = false;
            this.CancelHoldTrainAccepted = false;


            this.SkipStationAccepted = false;
            this.SkipStationRejected = false;
            this.CancelSkipStationAccepted = false;
            this.CancelSkipStationRejected = false;
            this.StandbyActive = false;

            this.StandbyCmdRejected = false;
            this.TrainLeftDoorOpened = Enums.DoorStatus.Close;
            this.TrainRightDoorOpened = false;
            this.TrainDoorClosedAndLocked = Enums.DoorStatus.Close;
            this.TrainDoorClosedAndLockedFault = false;

            this.TrainDoorWrongSideOpenedFault = false;
            this.DoorFaultAtStandby = false;
            this.DerailmentDetection = false;
            this.FireDetection = false;
            this.ObstacleDetection = false;

            this.BerthingOK = false;
            this.UnsuccessfulBerthingAlarm = false;
            this.TrainIntegrityAlarm = false;
            this.TrainActiveCab = false;
            //this.TrainDirection = false;
            //
            this.OBATCOff = false;
            this.OBATCClockFault = false;
            this.TrainDepartureFailure = false;
            this.TrainRollBack = false;
            this.BatteryOK = false;
            this.TractionStatus = false;
            this.BrakingStatus = false;

            //

            this.TrainCBTCMode = Enums.TrainCBTCMode.ATO;
            this.PerformanceLevel = 0;
            this.OBATCSoftwareVersion = 0;
            this.OBATCHardwareVersion = 0;
            this.TrainNumber = 0;
            this.TrainSetCarNumber = Enums.TrainSetCarNumber.Four;


            this.TrainSpeed = 0;




            Array.Copy(m_messageType.FootPrintTrackSectionID, this.FootPrintTrackSectionID, m_messageType.FootPrintTrackSectionID.Length);


            Array.Copy(m_messageType.VirtualOccupancyTrackSectionID, this.VirtualOccupancyTrackSectionID, m_messageType.VirtualOccupancyTrackSectionID.Length);


            this.TrainCoupled = Enums.TrainCoupled.NotCoupled;

            //belli olmayanlar


            this.OBATCtoATS_OverspeedAlarm = false;
            this.OBATCtoATS_SafeDistanceAlarm = false;
            this.OBATCtoATS_UnsuccessfulTrainStop = false;
            this.OBATCtoATS_UnexpectedSkipStation = false;
            this.OBATCtoATS_PSDEnableFault = false;
            this.OBATCtoATS_TrainDoorEnableFault = false;
            this.OBATCtoATS_PSDOpenFault = false;
            this.OBATCtoATS_TrainDoorOpenFault = false;


            //bit conversation
            this.FaultyTrainDoors1_1 = false;
            this.FaultyTrainDoors1_2 = false;
            this.FaultyTrainDoors1_3 = false;
            this.FaultyTrainDoors1_4 = false;
            this.FaultyTrainDoors1_5 = false;
            this.FaultyTrainDoors1_6 = false;
            this.FaultyTrainDoors1_7 = false;
            this.FaultyTrainDoors1_8 = false;
            this.FaultyTrainDoors1_9 = false;
            this.FaultyTrainDoors1_10 = false;
            this.FaultyTrainDoors1_11 = false;
            this.FaultyTrainDoors1_12 = false;
            this.FaultyTrainDoors1_13 = false;
            this.FaultyTrainDoors1_14 = false;
            this.FaultyTrainDoors1_15 = false;
            this.FaultyTrainDoors1_16 = false;
            this.FaultyTrainDoors1_17 = false;
            this.FaultyTrainDoors1_18 = false;
            this.FaultyTrainDoors1_19 = false;
            this.FaultyTrainDoors1_20 = false;
            this.FaultyTrainDoors1_21 = false;
            this.FaultyTrainDoors1_22 = false;
            this.FaultyTrainDoors1_23 = false;
            this.FaultyTrainDoors1_24 = false;




            this.FaultyTrainDoors2_1 = false;
            this.FaultyTrainDoors2_2 = false;
            this.FaultyTrainDoors2_3 = false;
            this.FaultyTrainDoors2_4 = false;
            this.FaultyTrainDoors2_5 = false;
            this.FaultyTrainDoors2_6 = false;
            this.FaultyTrainDoors2_7 = false;
            this.FaultyTrainDoors2_8 = false;
            this.FaultyTrainDoors2_9 = false;
            this.FaultyTrainDoors2_10 = false;
            this.FaultyTrainDoors2_11 = false;
            this.FaultyTrainDoors2_12 = false;
            this.FaultyTrainDoors2_13 = false;
            this.FaultyTrainDoors2_14 = false;
            this.FaultyTrainDoors2_15 = false;
            this.FaultyTrainDoors2_16 = false;
            this.FaultyTrainDoors2_17 = false;
            this.FaultyTrainDoors2_18 = false;
            this.FaultyTrainDoors2_19 = false;
            this.FaultyTrainDoors2_20 = false;
            this.FaultyTrainDoors2_21 = false;
            this.FaultyTrainDoors2_22 = false;
            this.FaultyTrainDoors2_23 = false;
            this.FaultyTrainDoors2_24 = false;




            this.BypassedTrainDoors1_1 = false;
            this.BypassedTrainDoors1_2 = false;
            this.BypassedTrainDoors1_3 = false;
            this.BypassedTrainDoors1_4 = false;
            this.BypassedTrainDoors1_5 = false;
            this.BypassedTrainDoors1_6 = false;
            this.BypassedTrainDoors1_7 = false;
            this.BypassedTrainDoors1_8 = false;
            this.BypassedTrainDoors1_9 = false;
            this.BypassedTrainDoors1_10 = false;
            this.BypassedTrainDoors1_11 = false;
            this.BypassedTrainDoors1_12 = false;
            this.BypassedTrainDoors1_13 = false;
            this.BypassedTrainDoors1_14 = false;
            this.BypassedTrainDoors1_15 = false;
            this.BypassedTrainDoors1_16 = false;
            this.BypassedTrainDoors1_17 = false;
            this.BypassedTrainDoors1_18 = false;
            this.BypassedTrainDoors1_19 = false;
            this.BypassedTrainDoors1_20 = false;
            this.BypassedTrainDoors1_21 = false;
            this.BypassedTrainDoors1_22 = false;
            this.BypassedTrainDoors1_23 = false;
            this.BypassedTrainDoors1_24 = false;



            this.BypassedTrainDoors2_1 = false;
            this.BypassedTrainDoors2_2 = false;
            this.BypassedTrainDoors2_3 = false;
            this.BypassedTrainDoors2_4 = false;
            this.BypassedTrainDoors2_5 = false;
            this.BypassedTrainDoors2_6 = false;
            this.BypassedTrainDoors2_7 = false;
            this.BypassedTrainDoors2_8 = false;
            this.BypassedTrainDoors2_9 = false;
            this.BypassedTrainDoors2_10 = false;
            this.BypassedTrainDoors2_11 = false;
            this.BypassedTrainDoors2_12 = false;
            this.BypassedTrainDoors2_13 = false;
            this.BypassedTrainDoors2_14 = false;
            this.BypassedTrainDoors2_15 = false;
            this.BypassedTrainDoors2_16 = false;
            this.BypassedTrainDoors2_17 = false;
            this.BypassedTrainDoors2_18 = false;
            this.BypassedTrainDoors2_19 = false;
            this.BypassedTrainDoors2_20 = false;
            this.BypassedTrainDoors2_21 = false;
            this.BypassedTrainDoors2_22 = false;
            this.BypassedTrainDoors2_23 = false;
            this.BypassedTrainDoors2_24 = false;
        }


     
    }
}