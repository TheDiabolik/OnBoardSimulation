using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{

    public class OBATP_TO_WSATP : IMessageType, IDisposable
    {
        private bool m_disposed = false; 

        public byte EmergencyBrakeApplied { get; set; }
        public byte TrainAbsoluteZeroSpeed { get; set; }
        public byte AllTrainDoorsClosedAndLocked { get; set; }
        public byte EnablePSD1 { get; set; }
        public byte EnablePSD2 { get; set; }
        public byte ActiveATP { get; set; }
        public byte ActiveCab { get; set; }
        public byte TrainDirection { get; set; }
        public byte TrainCoupled { get; set; }
        public byte TrainIntegrity { get; set; }
        public byte TrainLocationDeterminationFault { get; set; }
        public byte TrackDatabaseVersionMajor { get; set; }
        public byte TrackDatabaseVersionMinor { get; set; }
        public byte TrainDerailment { get; set; }



//        public ushort FootPrintTrackSectionID1 { get; set; }

//    public ushort FootPrintTrackSectionID2{ get; set; }

//public ushort FootPrintTrackSectionID3{ get; set; }
 
// public ushort FootPrintTrackSectionID4{ get; set; }
  
// public ushort FootPrintTrackSectionID5{ get; set; }

// public ushort FootPrintTrackSectionID6{ get; set; }

// public ushort FootPrintTrackSectionID7{ get; set; }

// public ushort FootPrintTrackSectionID8{ get; set; }

// public ushort FootPrintTrackSectionID9{ get; set; }

// public ushort FootPrintTrackSectionID10{ get; set; }

// public ushort FootPrintTrackSectionID11{ get; set; }

// public ushort FootPrintTrackSectionID12{ get; set; }

// public ushort FootPrintTrackSectionID13{ get; set; }

// public ushort FootPrintTrackSectionID14{ get; set; }

// public ushort FootPrintTrackSectionID15{ get; set; }

// public ushort VirtualOccupancyTrackSectionID1{ get; set; }

// public ushort VirtualOccupancyTrackSectionID2{ get; set; }

// public ushort VirtualOccupancyTrackSectionID3{ get; set; }

// public ushort VirtualOccupancyTrackSectionID4{ get; set; }

// public ushort VirtualOccupancyTrackSectionID5{ get; set; }

// public ushort VirtualOccupancyTrackSectionID6{ get; set; }

// public ushort VirtualOccupancyTrackSectionID7{ get; set; }

// public ushort VirtualOccupancyTrackSectionID8{ get; set; }

// public ushort VirtualOccupancyTrackSectionID9{ get; set; }

// public ushort VirtualOccupancyTrackSectionID10{ get; set; }

// public ushort VirtualOccupancyTrackSectionID11{ get; set; }

// public ushort VirtualOccupancyTrackSectionID12{ get; set; }

// public ushort VirtualOccupancyTrackSectionID13{ get; set; }

// public ushort VirtualOccupancyTrackSectionID14{ get; set; }

// public ushort VirtualOccupancyTrackSectionID15{ get; set; }

// public ushort VirtualOccupancyTrackSectionID16{ get; set; }

// public ushort VirtualOccupancyTrackSectionID17{ get; set; }

// public ushort VirtualOccupancyTrackSectionID18{ get; set; }

// public ushort VirtualOccupancyTrackSectionID19{ get; set; }

// public ushort VirtualOccupancyTrackSectionID20{ get; set; } 


      
        public ushort[] FootPrintTrackSectionID { get; set; } = new ushort[15];

     
        public ushort[] VirtualOccupancyTrackSectionID { get; set; } = new ushort[20];
        public byte BerthingOk { get; set; }
        public byte TrainNumber { get; set; }


        public IMessageType CreateMessage(byte[] message)
        {
            this.EmergencyBrakeApplied = (byte)message.GetValue(0);

            this.TrainAbsoluteZeroSpeed = (byte)message.GetValue(1);

            this.AllTrainDoorsClosedAndLocked = (byte)message.GetValue(2);

            this.EnablePSD1 = (byte)message.GetValue(3);

            this.EnablePSD2 = (byte)message.GetValue(4);

            this.ActiveATP = (byte)message.GetValue(5);

            this.TrainDirection = (byte)message.GetValue(6);

            this.TrainCoupled = (byte)message.GetValue(7);

            this.TrainIntegrity = (byte)message.GetValue(8);

            this.TrainLocationDeterminationFault = (byte)message.GetValue(9);

            this.TrackDatabaseVersionMajor = (byte)message.GetValue(10);

            this.TrainDerailment = (byte)message.GetValue(8);

            Buffer.BlockCopy(message, 14, this.FootPrintTrackSectionID, 0, FootPrintTrackSectionID.Length * 2);

            Buffer.BlockCopy(message, 44, this.VirtualOccupancyTrackSectionID, 0, VirtualOccupancyTrackSectionID.Length * 2);

            this.BerthingOk = (byte)message.GetValue(84);

            this.TrainNumber = (byte)message.GetValue(85);


            return this;
        }


        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();


            result.Add(this.EmergencyBrakeApplied);

            result.Add(this.TrainAbsoluteZeroSpeed);
            result.Add(this.AllTrainDoorsClosedAndLocked);

            result.Add(this.EnablePSD1);

            result.Add(this.EnablePSD2);

            result.Add(this.ActiveATP);

            result.Add(this.ActiveCab);

            result.Add(this.TrainDirection);
            result.Add(this.TrainCoupled);
            result.Add(this.TrainIntegrity);
            result.Add(this.TrainLocationDeterminationFault);
            result.Add(this.TrackDatabaseVersionMajor);
            result.Add(this.TrackDatabaseVersionMinor);
            result.Add(this.TrainDerailment); 
 

            for (int i = 0; i < FootPrintTrackSectionID.Length; i++)
            { 
                result.AddRange(BitConverter.GetBytes((ushort)this.FootPrintTrackSectionID[i]));
            }

            for (int i = 0; i < VirtualOccupancyTrackSectionID.Length; i++)
            {
                result.AddRange(BitConverter.GetBytes((ushort)this.VirtualOccupancyTrackSectionID[i]));
            }


            result.Add(this.BerthingOk);
            result.Add(this.TrainNumber);

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
 
