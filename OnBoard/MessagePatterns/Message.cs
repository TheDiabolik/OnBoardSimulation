using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class Message : IMessage, IDisposable
    {
        public UInt32 DS { get; set; }
        public UInt32 Size { get; set; }
        public UInt32 ID { get; set; }
        public UInt32 DST { get; set; }
        public UInt32 SRC { get; set; }
        public ulong RTC { get; set; }
        public UInt32 NO { get; set; }
        public byte[] DATA { get; set; }
        public UInt64 CRC { get; set; }


        private bool m_disposed = false;

        public Message()
        {

        }

        public Message(byte[] data)
        {
            this.DS = BitConverter.ToUInt32(data, 0);

            this.Size = BitConverter.ToUInt32(data, 4);

            this.ID = BitConverter.ToUInt32(data, 8);

            this.DST = BitConverter.ToUInt32(data, 12);

            this.SRC = BitConverter.ToUInt32(data, 16);

            this.RTC = BitConverter.ToUInt64(data, 20);

            this.NO = BitConverter.ToUInt32(data, 28);

            #region message array
            int crcLen = 8;
            int dataMsgStart = 32;
            int dataLen = Convert.ToInt32(this.Size - crcLen - dataMsgStart);
            this.DATA = new byte[dataLen];
            //string dataString = Encoding.UTF8.GetString(data, 32, dataLen);
            //this.DATA = Encoding.GetEncoding("iso-8859-9").GetBytes(dataString);

            Array.Copy(data, 32, this.DATA, 0, dataLen);

           
             

            #endregion

            this.CRC = BitConverter.ToUInt64(data, Convert.ToInt32(this.Size - crcLen));
        }



        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("{0} : {1}", "DS", DS.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1} - {2}", "Size", ((Enums.Message.Size)Size).ToString(), Size.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1} - {2}", "ID", ((Enums.Message.ID)ID).ToString(), ID.ToString());

            //var asdokaposdk = ((Enums.Message.ID)ID).ToString();

            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "DST", DST.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "SRC", SRC.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "RTC", RTC.ToString());
            stringBuilder.AppendLine();
            
            stringBuilder.AppendFormat("{0} : {1}", "NO", NO.ToString());
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat("{0} : {1}", "DATA", "*");
            stringBuilder.AppendLine();


            stringBuilder.AppendFormat("{0} : {1}", "CRC", CRC.ToString());
            stringBuilder.AppendLine();


            return stringBuilder.ToString();

        }


            public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            result.AddRange(BitConverter.GetBytes((UInt32)DS));

            result.AddRange(BitConverter.GetBytes((UInt32)this.Size));

            result.AddRange(BitConverter.GetBytes((UInt32)this.ID));

            result.AddRange(BitConverter.GetBytes((UInt32)this.DST));

            result.AddRange(BitConverter.GetBytes((UInt32)this.SRC));

            result.AddRange(BitConverter.GetBytes((UInt64)this.RTC));

            result.AddRange(BitConverter.GetBytes((UInt32)this.NO));

         


            if (DATA != null)
                result.AddRange(this.DATA);
            else
                result.AddRange(BitConverter.GetBytes(0));

            result.AddRange(BitConverter.GetBytes((UInt64)this.CRC));

            return result.ToArray();
        }

        static volatile UInt32 m_msgCounter = 0;



        //public static byte[] PrepMsg(string msgToSend)
        //{
        //    byte[] sourceMessageData = UDPConnection.StringToByteMsg(msgToSend);
        //    byte[] destinationMessageData = new byte[472];

        //    Array.Copy(sourceMessageData, destinationMessageData, sourceMessageData.Length);

        //    Message message = new Message();
        //    message.DS = (UInt32)Enums.Message.DS.DS;
        //    message.Size = (UInt32)Enums.Message.Size.Size; //(40 + sourceMessageData.Length); //
        //    message.ID = (UInt32)Enums.Message.ID.OBATO_TO_WSATO;
        //    message.DST = 60001;
        //    message.SRC = 20001;
        //    message.RTC = DateTimeExtensions.GetAllMiliSeconds();
        //    message.NO = m_msgCounter++;
        //    message.DATA = destinationMessageData;

        //    //convert message struct to byte array
        //    byte[] byteData = message.ToByte();
        //    UInt64 calcCRC = Crc.Crc64_Standard_Calculate(destinationMessageData);
        //    //add crc to message struct
        //    message.CRC = calcCRC;
        //    //convert message struct with crc to byte array
        //    byteData = message.ToByte();

        //    return byteData;
        //}





        public void SetMessageDS(UInt32 DS)
        {
            this.DS = DS;
        }

        public void SetMessageSize(UInt32 Size)
        {
            this.Size = Size;
        }

        public void SetMessageID(UInt32 ID)
        {
            this.ID = ID;
        }

        public void SetMessageDST(UInt32 DST)
        {
            this.DST = DST;
        }

        public void SetMessageSRC(UInt32 SRC)
        {
            this.SRC = SRC;
        }

        public void SetMessageRTC(ulong RTC)
        {
            this.RTC = RTC;
        } 

        public void SetMessageNO(UInt32 NO)
        {
            this.NO = NO;

            //int intValued = 20;
            //byte[] intBytes = BitConverter.GetBytes(intValued);


            //int intValue = 20;

            //byte[] bytes = new byte[4];

            //bytes[0] = (byte)(intValue >> 24);
            //bytes[1] = (byte)(intValue >> 16);
            //bytes[2] = (byte)(intValue >> 8);
            //bytes[3] = (byte)intValue;
        }

        public void SetMessageDATA(byte[] DATA)
        {
            this.DATA = DATA;
        }

        public void SetMessageCRC(UInt64 CRC)
        {
            this.CRC = CRC;
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
