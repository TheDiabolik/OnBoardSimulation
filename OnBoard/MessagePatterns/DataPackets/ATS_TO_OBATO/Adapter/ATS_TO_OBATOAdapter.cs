using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class ATS_TO_OBATOAdapter : IDisposable
    {
        private ATS_TO_OBATOAdaptee _adaptee;

        private bool m_disposed = false;


        public bool ApplyEmergencyBrake { get; set; }
        public bool ReleaseEmergencyBrake { get; set; }
        public bool ApprovalReleaseEmergencyBrake { get; set; }

        public bool BlockTrainDoor { get; set; }
        public bool UnblockTrainDoor { get; set; }
        public bool HoldTrain { get; set; }
        public bool CancelHoldTrain { get; set; }
        public bool SkipStation { get; set; }
        public bool CancelSkipStation { get; set; }
        public bool StandbyCmd { get; set; }
        public bool WakeUpTrain { get; set; }
        public bool OpenTrainLeftDoor { get; set; }
        //
        public bool OpenTrainRightDoor { get; set; }
        public bool CloseTrainLeftDoor { get; set; }
        public bool CloseTrainRightDoor { get; set; }
        public bool StopTrainAtNextStation { get; set; }
        public bool ResetOBATC { get; set; }
        public bool OutOfServiceTrain { get; set; }
        public bool TriggerAnnouncement { get; set; }


        public int CoastingStartTrackID { get; set; }
        public int CoastingEndTrackID { get; set; }
        public int CoastingMinimumSpeed { get; set; }
        public int PerformanceLevel { get; set; }
        public byte DoorOpenSequence { get; set; }

        public int DoorOpenTimeDelay { get; set; }

        //
        public int DwellTime { get; set; }
        public int StartingStationID { get; set; }
        public int TargetStationID { get; set; }
        public int TargetPlatformID { get; set; }


        public List<int> NextFourStationID { get; set; } = new List<int>();
        public int AnnouncementNumber { get; set; }
        public int TrackDatabaseVersionMajor { get; set; }
        public int TrackDatabaseVersionMinor { get; set; }


        public ATS_TO_OBATOAdapter(IMessageType message)
        {
            _adaptee = new ATS_TO_OBATOAdaptee(message);
            ATS_TO_OBATO ATS_TO_OBATO = _adaptee.GetMessageType();

            AdaptData(ATS_TO_OBATO);
        }

        public void AdaptData(ATS_TO_OBATO ATS_TO_OBATO)
        {

            this.ApplyEmergencyBrake =  ATS_TO_OBATO.ApplyEmergencyBrake.ByteToBool(); 


            this.ReleaseEmergencyBrake =  ATS_TO_OBATO.ReleaseEmergencyBrake.ByteToBool();

            this.ApprovalReleaseEmergencyBrake =  ATS_TO_OBATO.ApprovalReleaseEmergencyBrake.ByteToBool();


            this.BlockTrainDoor = ATS_TO_OBATO.BlockTrainDoor.ByteToBool();
            this.UnblockTrainDoor = ATS_TO_OBATO.UnblockTrainDoor.ByteToBool();
            this.HoldTrain = ATS_TO_OBATO.HoldTrain.ByteToBool();
            this.CancelHoldTrain = ATS_TO_OBATO.CancelHoldTrain.ByteToBool();
            this.SkipStation = ATS_TO_OBATO.SkipStation.ByteToBool();
            this.CancelSkipStation = ATS_TO_OBATO.CancelSkipStation.ByteToBool();
            this.StandbyCmd = ATS_TO_OBATO.StandbyCmd.ByteToBool();

            //buna bakılacak
            this.WakeUpTrain = ATS_TO_OBATO.WakeUpTrain.ByteToBool();

            //

            this.OpenTrainLeftDoor = ATS_TO_OBATO.OpenTrainLeftDoor.ByteToBool();
            this.OpenTrainRightDoor = ATS_TO_OBATO.OpenTrainRightDoor.ByteToBool();
            this.CloseTrainLeftDoor = ATS_TO_OBATO.CloseTrainLeftDoor.ByteToBool();

            this.CloseTrainRightDoor = ATS_TO_OBATO.CloseTrainRightDoor.ByteToBool();
            this.StopTrainAtNextStation = ATS_TO_OBATO.StopTrainAtNextStation.ByteToBool();
            this.ResetOBATC = ATS_TO_OBATO.ResetOBATC.ByteToBool();
            this.OutOfServiceTrain = ATS_TO_OBATO.OutOfServiceTrain.ByteToBool();
            this.TriggerAnnouncement = ATS_TO_OBATO.TriggerAnnouncement.ByteToBool();

            //
            this.CoastingStartTrackID = Convert.ToInt32(ATS_TO_OBATO.CoastingStartTrackID);
            this.CoastingEndTrackID = Convert.ToInt32(ATS_TO_OBATO.CoastingEndTrackID);
            this.CoastingMinimumSpeed = Convert.ToInt32(ATS_TO_OBATO.CoastingMinimumSpeed);
            this.PerformanceLevel = Convert.ToInt32(ATS_TO_OBATO.PerformanceLevel);
            this.DoorOpenSequence = ATS_TO_OBATO.DoorOpenSequence;

            this.DoorOpenTimeDelay = Convert.ToInt32(ATS_TO_OBATO.DoorOpenTimeDelay);


            this.DwellTime = Convert.ToInt32(ATS_TO_OBATO.DwellTime);
            this.StartingStationID = Convert.ToInt32(ATS_TO_OBATO.StartingStationID);
            this.TargetStationID = Convert.ToInt32(ATS_TO_OBATO.TargetStationID);
            this.TargetPlatformID = Convert.ToInt32(ATS_TO_OBATO.TargetPlatformID);




            int NextFourStationID1 = Convert.ToInt32(ATS_TO_OBATO.NextFourStationID1);
            int NextFourStationID2 = Convert.ToInt32(ATS_TO_OBATO.NextFourStationID2);
            int NextFourStationID3 = Convert.ToInt32(ATS_TO_OBATO.NextFourStationID3);
            int NextFourStationID4 = Convert.ToInt32(ATS_TO_OBATO.NextFourStationID4);

            this.NextFourStationID.Add(NextFourStationID1);
            this.NextFourStationID.Add(NextFourStationID2);
            this.NextFourStationID.Add(NextFourStationID3);
            this.NextFourStationID.Add(NextFourStationID4);



            this.AnnouncementNumber = Convert.ToInt32(ATS_TO_OBATO.AnnouncementNumber);

            this.TrackDatabaseVersionMajor = Convert.ToInt32(ATS_TO_OBATO.TrackDatabaseVersionMajor);
            this.TrackDatabaseVersionMinor = Convert.ToInt32(ATS_TO_OBATO.TrackDatabaseVersionMinor);

        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{0} : {1}", "ApplyEmergencyBrake", this.ApplyEmergencyBrake.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "ReleaseEmergencyBrake", this.ReleaseEmergencyBrake.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "ApprovalReleaseEmergencyBrake", this.ApprovalReleaseEmergencyBrake.ToString());
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat("{0} : {1}", "BlockTrainDoor", this.BlockTrainDoor.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "UnblockTrainDoor", this.UnblockTrainDoor.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "HoldTrain", this.HoldTrain.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "CancelHoldTrain", this.CancelHoldTrain.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "SkipStation", this.SkipStation.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "CancelSkipStation", this.CancelSkipStation.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "StandbyCmd", this.StandbyCmd.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "WakeUpTrain", this.WakeUpTrain.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "OpenTrainLeftDoor", this.OpenTrainLeftDoor.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "OpenTrainRightDoor", this.OpenTrainRightDoor.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "CloseTrainLeftDoor", this.CloseTrainLeftDoor.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "CloseTrainRightDoor", this.CloseTrainRightDoor.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "StopTrainAtNextStation", this.StopTrainAtNextStation.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "ResetOBATC", this.ResetOBATC.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "OutOfServiceTrain", this.OutOfServiceTrain.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "TriggerAnnouncement", this.TriggerAnnouncement.ToString());
            stringBuilder.AppendLine();



            stringBuilder.AppendFormat("{0} : {1}", "CoastingStartTrackID", this.CoastingStartTrackID.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "CoastingEndTrackID", this.CoastingEndTrackID.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "PerformanceLevel", this.PerformanceLevel.ToString());
            stringBuilder.AppendLine();



            stringBuilder.AppendFormat("{0} : {1}", "DoorOpenSequence", this.DoorOpenSequence.ToString());
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat("{0} : {1}", "DoorOpenTimeDelay", this.DoorOpenTimeDelay.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "DwellTime", this.DwellTime.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "StartingStationID", this.StartingStationID.ToString());
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "TargetStationID", this.TargetStationID.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "TargetPlatformID", this.TargetPlatformID.ToString());
            stringBuilder.AppendLine();


            for (int i = 0; i < this.NextFourStationID.Count; i++)
            {
                stringBuilder.AppendFormat("{0}{1} : {2}", "NextFourStationID", (i + 1).ToString(), this.NextFourStationID[i].ToString());
                stringBuilder.AppendLine();
            }


            stringBuilder.AppendFormat("{0} : {1}", "AnnouncementNumber", this.AnnouncementNumber.ToString());
            stringBuilder.AppendLine();



            stringBuilder.AppendFormat("{0} : {1}", "TrackDatabaseVersionMajor", this.TrackDatabaseVersionMajor.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "TrackDatabaseVersionMinor", this.TrackDatabaseVersionMinor.ToString());
            stringBuilder.AppendLine();

            return stringBuilder.ToString();
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