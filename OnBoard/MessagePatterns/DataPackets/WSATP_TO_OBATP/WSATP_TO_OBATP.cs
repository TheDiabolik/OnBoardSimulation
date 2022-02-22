using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class WSATP_TO_OBATP : IMessageType, IDisposable
    {
        private bool m_disposed = false;

        public byte EmergencyBrakeCommand { get; set; }
        public byte PSD1EnableOK { get; set; }
        public byte PSD2EnableOK { get; set; }
        public byte PSD1ClosedAndLocked { get; set; }
        public byte PSD2ClosedAndLocked { get; set; }
      

        public ushort TrackSectionID1 { get; set; }

        public byte SpeedLimit1 { get; set; }


        public ushort TrackSectionID2 { get; set; }

        public byte SpeedLimit2 { get; set; }


        public ushort TrackSectionID3 { get; set; }

        public byte SpeedLimit3 { get; set; }


        public ushort TrackSectionID4 { get; set; }

        public byte SpeedLimit4 { get; set; }



        public ushort TrackSectionID5 { get; set; }

        public byte SpeedLimit5 { get; set; }





        public ushort TrackSectionID6 { get; set; }

        public byte SpeedLimit6 { get; set; }


        public ushort TrackSectionID7 { get; set; }

        public byte SpeedLimit7 { get; set; }


        public ushort TrackSectionID8 { get; set; }

        public byte SpeedLimit8 { get; set; }


        public ushort TrackSectionID9 { get; set; }

        public byte SpeedLimit9 { get; set; }



        public ushort TrackSectionID10 { get; set; }

        public byte SpeedLimit10 { get; set; }

        //dsd

        public ushort TrackSectionID11 { get; set; }

        public byte SpeedLimit11 { get; set; }


        public ushort TrackSectionID12 { get; set; }

        public byte SpeedLimit12 { get; set; }


        public ushort TrackSectionID13 { get; set; }

        public byte SpeedLimit13 { get; set; }


        public ushort TrackSectionID14 { get; set; }

        public byte SpeedLimit14 { get; set; }


        public ushort TrackSectionID15 { get; set; }

        public byte SpeedLimit15 { get; set; }


        public ushort TrackSectionID16 { get; set; }

        public byte SpeedLimit16 { get; set; }


        public ushort TrackSectionID17 { get; set; }

        public byte SpeedLimit17 { get; set; }


        public ushort TrackSectionID18 { get; set; }

        public byte SpeedLimit18 { get; set; }


        public ushort TrackSectionID19 { get; set; }

        public byte SpeedLimit19 { get; set; }


        public ushort TrackSectionID20 { get; set; }

        public byte SpeedLimit20 { get; set; }





        public  virtual IMessageType CreateMessage(byte[] message)
        {
            this.EmergencyBrakeCommand = (byte)message.GetValue(0);

            this.PSD1EnableOK = (byte)message.GetValue(1);

            this.PSD2EnableOK = (byte)message.GetValue(2);

            this.PSD1ClosedAndLocked = (byte)message.GetValue(3);

            this.PSD2ClosedAndLocked = (byte)message.GetValue(4); 
            //

            this.TrackSectionID1 = BitConverter.ToUInt16(message, 5);  
            this.SpeedLimit1 = (byte)message.GetValue(7);

            this.TrackSectionID2 = BitConverter.ToUInt16(message, 8);
            this.SpeedLimit2 = (byte)message.GetValue(10);

            this.TrackSectionID3 = BitConverter.ToUInt16(message, 11);
            this.SpeedLimit3 = (byte)message.GetValue(13);

            this.TrackSectionID4 = BitConverter.ToUInt16(message, 14);
            this.SpeedLimit4 = (byte)message.GetValue(16);

            this.TrackSectionID5 = BitConverter.ToUInt16(message, 17);
            this.SpeedLimit5 = (byte)message.GetValue(19);

            //
            //

            this.TrackSectionID6 = BitConverter.ToUInt16(message, 20);
            this.SpeedLimit6 = (byte)message.GetValue(22);

            this.TrackSectionID7 = BitConverter.ToUInt16(message, 23);
            this.SpeedLimit7 = (byte)message.GetValue(25);

            this.TrackSectionID8 = BitConverter.ToUInt16(message, 26);
            this.SpeedLimit8 = (byte)message.GetValue(28);

            this.TrackSectionID9 = BitConverter.ToUInt16(message, 29);
            this.SpeedLimit9 = (byte)message.GetValue(31);

            this.TrackSectionID10 = BitConverter.ToUInt16(message, 32);
            this.SpeedLimit10 = (byte)message.GetValue(34);

            //

            //

            this.TrackSectionID11 = BitConverter.ToUInt16(message, 35);
            this.SpeedLimit11 = (byte)message.GetValue(37);

            this.TrackSectionID12 = BitConverter.ToUInt16(message, 38);
            this.SpeedLimit12 = (byte)message.GetValue(40);

            this.TrackSectionID13 = BitConverter.ToUInt16(message, 41);
            this.SpeedLimit13 = (byte)message.GetValue(43);

            this.TrackSectionID14 = BitConverter.ToUInt16(message, 44);
            this.SpeedLimit14 = (byte)message.GetValue(46);

            this.TrackSectionID15 = BitConverter.ToUInt16(message, 47);
            this.SpeedLimit15 = (byte)message.GetValue(49);

            //
            //

            this.TrackSectionID16 = BitConverter.ToUInt16(message, 50);
            this.SpeedLimit16 = (byte)message.GetValue(52);

            this.TrackSectionID17 = BitConverter.ToUInt16(message, 53);
            this.SpeedLimit17 = (byte)message.GetValue(55);

            this.TrackSectionID18 = BitConverter.ToUInt16(message, 56);
            this.SpeedLimit18 = (byte)message.GetValue(58);

            this.TrackSectionID19 = BitConverter.ToUInt16(message, 59);
            this.SpeedLimit19 = (byte)message.GetValue(61);

            this.TrackSectionID20 = BitConverter.ToUInt16(message, 62);
            this.SpeedLimit20 = (byte)message.GetValue(64);

            //


            return this;
        }

        public virtual WSATP_TO_OBATPAdaptee Request()
        {

            return null;

        }

        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();


            result.Add(this.EmergencyBrakeCommand);

            result.Add(this.PSD1EnableOK);
            result.Add(this.PSD2EnableOK);

            result.Add(this.PSD1ClosedAndLocked);

            result.Add(this.PSD2ClosedAndLocked);



            result.AddRange(BitConverter.GetBytes(this.TrackSectionID1));
            result.Add(this.SpeedLimit1);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID2));
            result.Add(this.SpeedLimit2);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID3));
            result.Add(this.SpeedLimit3);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID4));
            result.Add(this.SpeedLimit4);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID5));
            result.Add(this.SpeedLimit5);



            result.AddRange(BitConverter.GetBytes(this.TrackSectionID6));
            result.Add(this.SpeedLimit6);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID7));
            result.Add(this.SpeedLimit7);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID8));
            result.Add(this.SpeedLimit8);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID9));
            result.Add(this.SpeedLimit9);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID10));
            result.Add(this.SpeedLimit10);


            result.AddRange(BitConverter.GetBytes(this.TrackSectionID11));
            result.Add(this.SpeedLimit11);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID12));
            result.Add(this.SpeedLimit12);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID13));
            result.Add(this.SpeedLimit13);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID14));
            result.Add(this.SpeedLimit14);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID15));
            result.Add(this.SpeedLimit15);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID16));
            result.Add(this.SpeedLimit16);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID17));
            result.Add(this.SpeedLimit17);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID18));
            result.Add(this.SpeedLimit18);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID19));
            result.Add(this.SpeedLimit19);

            result.AddRange(BitConverter.GetBytes(this.TrackSectionID20));
            result.Add(this.SpeedLimit20);


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
