using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class OBATO_TO_ATS : IMessageType, IDisposable
    {
        private bool m_disposed = false;

        public byte OBATCActive { get; set; }
        public byte TrainEmergencyBrakeApplied { get; set; }
        public byte WaitingApprovalReleaseEmergencyBrake { get; set; }
        public byte TrainEmergencyBrakeReleased { get; set; }
        public byte EmergencyHandleActive { get; set; }

        public byte TrainTemporaryCoastingAccepted { get; set; }
        public byte TrainTemporaryCoastingRejected { get; set; }
        public byte HoldTrainAccepted { get; set; }
        public byte HoldTrainRejected { get; set; }
        public byte CancelHoldTrainAccepted { get; set; }


        public byte SkipStationAccepted { get; set; }
        public byte SkipStationRejected { get; set; }
        public byte CancelSkipStationAccepted { get; set; }
        public byte CancelSkipStationRejected { get; set; }
        public byte StandbyActive { get; set; }

        public byte StandbyCmdRejected { get; set; }
        public byte TrainLeftDoorOpened { get; set; }
        public byte TrainRightDoorOpened { get; set; }
        public byte TrainDoorClosedAndLocked { get; set; }
        public byte TrainDoorClosedAndLockedFault { get; set; }

        public byte TrainDoorWrongSideOpenedFault { get; set; }
        public byte DoorFaultAtStandby { get; set; }
        public byte DerailmentDetection { get; set; }
        public byte FireDetection { get; set; }
        public byte ObstacleDetection { get; set; }

        public byte BerthingOK { get; set; }
        public byte UnsuccessfulBerthingAlarm { get; set; }
        public byte TrainIntegrityAlarm { get; set; }
        public byte TrainActiveCab { get; set; }
        public byte TrainDirection { get; set; }
        //
        public byte OBATCOff { get; set; }
        public byte OBATCClockFault { get; set; }
        public byte TrainDepartureFailure { get; set; }
        public byte TrainRollBack { get; set; }
        public byte BatteryOK { get; set; }
        public byte TractionStatus { get; set; }
        public byte BrakingStatus { get; set; }
        public byte TrainCBTCMode { get; set; }
        public byte PerformanceLevel { get; set; }
        public byte OBATCSoftwareVersion { get; set; }
        public byte OBATCHardwareVersion { get; set; }
        public byte TrainNumber { get; set; }
        public byte TrainSetCarNumber { get; set; }
        public byte TrainSpeed { get; set; }

        //
        public ushort[] FootPrintTrackSectionID { get; set; } = new ushort[15];

        public ushort FootPrintFirstTrackSectionOffset { get; set; }
        public ushort FootPrintLastTrackSectionOffset { get; set; }

        public ushort[] VirtualOccupancyTrackSectionID { get; set; } = new ushort[20];

        public ushort VirtualOccupancyFirstTrackSectionOffset { get; set; }
        public ushort VirtualOccupancyLastTrackSectionOffset { get; set; }


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
        public byte TrainCoupled { get; set; }
        public ushort DwellTime { get; set; }

        //

        public byte OBATCtoATS_ReverseTrafficDirection { get; set; }
        public byte OBATCtoATS_RejectedStopTrainAtNextStation { get; set; }
        public byte OBATCtoATS_TrainLocationDeterminationFault { get; set; }
        public byte OBATCtoATS_TrainSpeedSensorFault { get; set; }
        public byte OBATCtoATS_MissedBalise { get; set; }
        public byte OBATCtoATS_DepartureTestStarted { get; set; }
        public byte OBATCtoATS_DepartureTestResults { get; set; }
        public byte OBATCtoATS_OverspeedAlarm { get; set; }
        public byte OBATCtoATS_SafeDistanceAlarm { get; set; }
        public byte OBATCtoATS_UnsuccessfulTrainStop { get; set; }
        public byte OBATCtoATS_UnexpectedSkipStation { get; set; }
        public byte OBATCtoATS_PSDEnableFault { get; set; }
        public byte OBATCtoATS_TrainDoorEnableFault { get; set; }
        public byte OBATCtoATS_PSDOpenFault { get; set; }
        public byte OBATCtoATS_TrainDoorOpenFault { get; set; }


        //bit conversation işlemleri

        //FaultyTrainDoors1
        public byte FaultyTrainDoors1_1 { get; set; }
        public byte FaultyTrainDoors1_2 { get; set; }
        public byte FaultyTrainDoors1_3 { get; set; }

        //FaultyTrainDoors2
        public byte FaultyTrainDoors2_1 { get; set; }
        public byte FaultyTrainDoors2_2 { get; set; }
        public byte FaultyTrainDoors2_3 { get; set; }
        //BypassedTrainDoors1
        public byte BypassedTrainDoors1_1 { get; set; }
        public byte BypassedTrainDoors1_2 { get; set; }
        public byte BypassedTrainDoors1_3 { get; set; }

        //BypassedTrainDoors2
        public byte BypassedTrainDoors2_1 { get; set; }
        public byte BypassedTrainDoors2_2 { get; set; }
        public byte BypassedTrainDoors2_3 { get; set; }


        public IMessageType CreateMessage(byte[] message)
        {
            this.OBATCActive = (byte)message.GetValue(0);

            this.TrainEmergencyBrakeApplied = (byte)message.GetValue(1);

            this.WaitingApprovalReleaseEmergencyBrake = (byte)message.GetValue(2);

            this.TrainEmergencyBrakeReleased = (byte)message.GetValue(3);

            this.EmergencyHandleActive = (byte)message.GetValue(4);

            this.TrainTemporaryCoastingAccepted = (byte)message.GetValue(5);

            


            return this;
        }



        //public override string ToString()
        //{
        //    return "Name = " + this.OBATCActive.ToString() + ", Age = " + TrainEmergencyBrakeApplied.ToString();
        //}
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();


            result.Add(this.OBATCActive);
            result.Add(this.TrainEmergencyBrakeApplied);

            result.Add(this.WaitingApprovalReleaseEmergencyBrake);

            result.Add(this.TrainEmergencyBrakeReleased);
            result.Add(this.EmergencyHandleActive);
            result.Add(this.TrainTemporaryCoastingAccepted);
            result.Add(this.TrainTemporaryCoastingRejected);
            result.Add(this.HoldTrainAccepted);
            result.Add(this.HoldTrainRejected);
            result.Add(this.CancelHoldTrainAccepted);


            result.Add(this.SkipStationAccepted);
            result.Add(this.SkipStationRejected);
            result.Add(this.CancelSkipStationAccepted);
            result.Add(this.CancelSkipStationRejected);
            result.Add(this.StandbyActive);


            result.Add(this.StandbyCmdRejected);
            result.Add(this.TrainLeftDoorOpened);
            result.Add(this.TrainRightDoorOpened);
            result.Add(this.TrainDoorClosedAndLocked);
            result.Add(this.TrainDoorClosedAndLockedFault);



            result.Add(this.TrainDoorWrongSideOpenedFault);
            result.Add(this.DoorFaultAtStandby);
            result.Add(this.DerailmentDetection);
            result.Add(this.FireDetection);
            result.Add(this.ObstacleDetection);

            result.Add(this.BerthingOK);
            result.Add(this.UnsuccessfulBerthingAlarm);
            result.Add(this.TrainIntegrityAlarm);
            result.Add(this.TrainActiveCab);
            result.Add(this.TrainDirection);

            result.Add(this.OBATCOff);
            result.Add(this.OBATCClockFault);
            result.Add(this.TrainDepartureFailure);
            result.Add(this.TrainRollBack);
            result.Add(this.BatteryOK);

            result.Add(this.TractionStatus);
            result.Add(this.BrakingStatus);
            result.Add(this.TrainCBTCMode);
            result.Add(this.PerformanceLevel);
            result.Add(this.OBATCSoftwareVersion);


            result.Add(this.OBATCHardwareVersion);
            result.Add(this.TrainNumber);
            result.Add(this.TrainSetCarNumber); 
            result.Add(this.TrainSpeed);

            for (int i = 0; i < FootPrintTrackSectionID.Length; i++)
            {
                result.AddRange(BitConverter.GetBytes((ushort)this.FootPrintTrackSectionID[i]));
            }


            result.AddRange(BitConverter.GetBytes(this.FootPrintFirstTrackSectionOffset));
            result.AddRange(BitConverter.GetBytes(this.FootPrintLastTrackSectionOffset));

            for (int i = 0; i < VirtualOccupancyTrackSectionID.Length; i++)
            {
                result.AddRange(BitConverter.GetBytes((ushort)this.VirtualOccupancyTrackSectionID[i]));
            }

            result.AddRange(BitConverter.GetBytes(this.VirtualOccupancyFirstTrackSectionOffset));
            result.AddRange(BitConverter.GetBytes(this.VirtualOccupancyLastTrackSectionOffset));



            result.AddRange(BitConverter.GetBytes(this.OBATCEquipmentStatus));
            result.AddRange(BitConverter.GetBytes(this.OBATCWarning1));
            result.AddRange(BitConverter.GetBytes(this.OBATCWarning2));
            result.AddRange(BitConverter.GetBytes(this.OBATCWarning3));
            result.AddRange(BitConverter.GetBytes(this.OBATCWarning4));
            result.AddRange(BitConverter.GetBytes(this.OBATCWarning5));
            result.AddRange(BitConverter.GetBytes(this.OBATCFault1));
            result.AddRange(BitConverter.GetBytes(this.OBATCFault2));
            result.AddRange(BitConverter.GetBytes(this.OBATCEquipmentFault1));
            result.AddRange(BitConverter.GetBytes(this.OBATCEquipmentFault2));
            result.AddRange(BitConverter.GetBytes(this.OBATCEquipmentFault3));
            result.AddRange(BitConverter.GetBytes(this.OBATCEquipmentFault4));
            result.AddRange(BitConverter.GetBytes(this.OBATCEquipmentFault5));

            result.AddRange(BitConverter.GetBytes(this.TrainFault1));
            result.AddRange(BitConverter.GetBytes(this.TrainFault2));
            result.AddRange(BitConverter.GetBytes(this.TrainFault3));
            result.AddRange(BitConverter.GetBytes(this.TrainFault4));
            result.AddRange(BitConverter.GetBytes(this.TrainFault5));


            result.Add(this.TrainCoupled);


            result.AddRange(BitConverter.GetBytes(this.DwellTime));


            result.Add(this.OBATCtoATS_ReverseTrafficDirection);
            result.Add(this.OBATCtoATS_RejectedStopTrainAtNextStation);
            result.Add(this.OBATCtoATS_TrainLocationDeterminationFault);
            result.Add(this.OBATCtoATS_TrainSpeedSensorFault);
            result.Add(this.OBATCtoATS_MissedBalise);
            result.Add(this.OBATCtoATS_DepartureTestStarted);
            result.Add(this.OBATCtoATS_DepartureTestResults);
            result.Add(this.OBATCtoATS_OverspeedAlarm);
            result.Add(this.OBATCtoATS_SafeDistanceAlarm);
            result.Add(this.OBATCtoATS_UnsuccessfulTrainStop);

            result.Add(this.OBATCtoATS_UnexpectedSkipStation);
            result.Add(this.OBATCtoATS_PSDEnableFault);
            result.Add(this.OBATCtoATS_TrainDoorEnableFault);
            result.Add(this.OBATCtoATS_PSDOpenFault);
            result.Add(this.OBATCtoATS_TrainDoorOpenFault);

            result.Add(this.FaultyTrainDoors1_1);
            result.Add(this.FaultyTrainDoors1_2);
            result.Add(this.FaultyTrainDoors1_3);

            result.Add(this.FaultyTrainDoors2_1);
            result.Add(this.FaultyTrainDoors2_2);
            result.Add(this.FaultyTrainDoors2_3);

            result.Add(this.BypassedTrainDoors1_1);
            result.Add(this.BypassedTrainDoors1_2);
            result.Add(this.BypassedTrainDoors1_3);

            result.Add(this.BypassedTrainDoors2_1);
            result.Add(this.BypassedTrainDoors2_2);
            result.Add(this.BypassedTrainDoors2_3);

            return result.ToArray();

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
