using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class ATS_TO_OBATO_Init : IMessageType, IDisposable
    {
        private bool m_disposed = false;

        public byte ATStoOBATO_TrainNumber { get; set; }
        public ushort TrackSectionID { get; set; }
        public byte ATStoOBATO_TrainDirection { get; set; }
        public byte ATStoOBATO_TrainSpeed { get; set; }

        public ushort DwellTime { get; set; }

        public IMessageType CreateMessage(byte[] message)
        {
            this.ATStoOBATO_TrainNumber = (byte)message.GetValue(0);

            this.TrackSectionID = BitConverter.ToUInt16(message, 1);

            this.ATStoOBATO_TrainDirection = (byte)message.GetValue(3);
            this.ATStoOBATO_TrainSpeed = (byte)message.GetValue(4);

            this.DwellTime = BitConverter.ToUInt16(message, 5);

            return this;
        }

        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();


            result.Add(this.ATStoOBATO_TrainNumber); 
            result.AddRange(BitConverter.GetBytes(this.TrackSectionID));
            result.Add(this.ATStoOBATO_TrainDirection); 
            result.Add(this.ATStoOBATO_TrainSpeed); 

            return result.ToArray();

        }


        //yukarıdaki yapıdan bi sürü olacak bu kısım ayarlanacak


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
