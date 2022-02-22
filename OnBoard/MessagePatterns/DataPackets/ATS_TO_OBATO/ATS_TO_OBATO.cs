using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard

{
    public class ATS_TO_OBATO : IMessageType, IDisposable
    {
        private bool m_disposed = false;

        public byte ApplyEmergencyBrake { get; set; }
        public byte ReleaseEmergencyBrake { get; set; }
        public byte ApprovalReleaseEmergencyBrake { get; set; }

        public byte BlockTrainDoor { get; set; }
        public byte UnblockTrainDoor { get; set; }
        public byte HoldTrain { get; set; }
        public byte CancelHoldTrain { get; set; }
        public byte SkipStation { get; set; }
        public byte CancelSkipStation { get; set; }
        public byte StandbyCmd { get; set; }
        public byte WakeUpTrain { get; set; }
        public byte OpenTrainLeftDoor { get; set; }
        //
        public byte OpenTrainRightDoor { get; set; }
        public byte CloseTrainLeftDoor { get; set; }
        public byte CloseTrainRightDoor { get; set; }
        public byte StopTrainAtNextStation { get; set; }
        public byte ResetOBATC { get; set; }
        public byte OutOfServiceTrain { get; set; }
        public byte TriggerAnnouncement { get; set; }


        public ushort CoastingStartTrackID { get; set; }
        public ushort CoastingEndTrackID { get; set; }
        public byte CoastingMinimumSpeed { get; set; }
        public byte PerformanceLevel { get; set; }
        public byte DoorOpenSequence { get; set; }

        public byte DoorOpenTimeDelay { get; set; }
        //
        public ushort DwellTime { get; set; }
        public byte StartingStationID { get; set; }
        public byte TargetStationID { get; set; }
        public byte TargetPlatformID { get; set; }
        public byte NextFourStationID1 { get; set; }
        public byte NextFourStationID2 { get; set; }
        public byte NextFourStationID3 { get; set; }
        public byte NextFourStationID4 { get; set; }

        public ushort AnnouncementNumber { get; set; }
        public byte TrackDatabaseVersionMajor { get; set; }
        public byte TrackDatabaseVersionMinor { get; set; }


        public IMessageType CreateMessage(byte[] message)
        {
            this.ApplyEmergencyBrake = (byte)message.GetValue(0);
            this.ReleaseEmergencyBrake = (byte)message.GetValue(1);

            this.ApprovalReleaseEmergencyBrake = (byte)message.GetValue(2);

            this.BlockTrainDoor = (byte)message.GetValue(3);
            this.UnblockTrainDoor = (byte)message.GetValue(4);
            this.HoldTrain = (byte)message.GetValue(5);
            this.CancelHoldTrain = (byte)message.GetValue(6);
            this.SkipStation = (byte)message.GetValue(7);
            this.CancelSkipStation = (byte)message.GetValue(8);
            this.StandbyCmd = (byte)message.GetValue(9);
            this.WakeUpTrain = (byte)message.GetValue(10);

            //

            this.OpenTrainLeftDoor = (byte)message.GetValue(11);
            this.OpenTrainRightDoor = (byte)message.GetValue(12);
            this.CloseTrainLeftDoor = (byte)message.GetValue(13);

            this.CloseTrainRightDoor = (byte)message.GetValue(14);
            this.StopTrainAtNextStation = (byte)message.GetValue(15);
            this.ResetOBATC = (byte)message.GetValue(16);
            this.OutOfServiceTrain = (byte)message.GetValue(17);
            this.TriggerAnnouncement = (byte)message.GetValue(18);
            //

            this.CoastingStartTrackID = BitConverter.ToUInt16(message, 19);
            this.CoastingEndTrackID = BitConverter.ToUInt16(message, 21);
            this.CoastingMinimumSpeed = (byte)message.GetValue(23);
            this.PerformanceLevel = (byte)message.GetValue(24);
            this.DoorOpenSequence = (byte)message.GetValue(25);

            this.DoorOpenTimeDelay = (byte)message.GetValue(26);
            //



            this.DwellTime = BitConverter.ToUInt16(message, 27);
            this.StartingStationID = (byte)message.GetValue(29);
            this.TargetStationID = (byte)message.GetValue(30);
            this.TargetPlatformID = (byte)message.GetValue(31);
            this.NextFourStationID1 = (byte)message.GetValue(32);
            this.NextFourStationID2 = (byte)message.GetValue(33);
            this.NextFourStationID3 = (byte)message.GetValue(34);
            this.NextFourStationID4 = (byte)message.GetValue(35);

            //
            this.AnnouncementNumber = BitConverter.ToUInt16(message, 36);
            this.TrackDatabaseVersionMajor = (byte)message.GetValue(38);
            this.TrackDatabaseVersionMinor = (byte)message.GetValue(39);

            return this;
        }



        public byte[] ToByte()
        {
            //not implemented
            return null;

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