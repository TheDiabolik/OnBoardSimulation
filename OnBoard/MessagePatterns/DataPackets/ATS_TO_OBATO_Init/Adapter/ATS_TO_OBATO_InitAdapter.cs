using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class ATS_TO_OBATO_InitAdapter : IDisposable
    {
        private ATS_TO_OBATO_InitAdaptee _adaptee;
        private bool m_disposed = false;

        public Enums.Train_ID ATStoOBATO_TrainNumber { get; set; }
        public int TrackSectionID { get; set; }
        public Enums.Direction ATStoOBATO_TrainDirection { get; set; }
        public int ATStoOBATO_TrainSpeed { get; set; }

        public int DwellTime { get; set; }


        public ATS_TO_OBATO_InitAdapter(IMessageType message)
        {
            _adaptee = new ATS_TO_OBATO_InitAdaptee(message);
            ATS_TO_OBATO_Init ATS_TO_OBATO_Init = _adaptee.GetMessageType();

            AdaptData(ATS_TO_OBATO_Init);
        }
        public void AdaptData(ATS_TO_OBATO_Init ATS_TO_OBATO_Init)
        {

            this.ATStoOBATO_TrainNumber = (Enums.Train_ID)(ATS_TO_OBATO_Init.ATStoOBATO_TrainNumber);
            this.TrackSectionID = Convert.ToInt32(ATS_TO_OBATO_Init.TrackSectionID);

            int direction = Convert.ToInt32(ATS_TO_OBATO_Init.ATStoOBATO_TrainDirection);

            if (direction == 1)
                this.ATStoOBATO_TrainDirection = Enums.Direction.Left;
            else
                this.ATStoOBATO_TrainDirection = Enums.Direction.Right;


            this.ATStoOBATO_TrainSpeed = Convert.ToInt32(ATS_TO_OBATO_Init.ATStoOBATO_TrainSpeed);

            this.DwellTime = Convert.ToUInt16(ATS_TO_OBATO_Init.DwellTime);


            if (this.ATStoOBATO_TrainNumber == Enums.Train_ID.Train25)
            {

            }


            //Debug.WriteLine("initte dwell gönderdim");

        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{0} : {1}", "TrainNumber", ((Enums.Train_ID)this.ATStoOBATO_TrainNumber).ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("{0} : {1}", "TrackSectionID", this.TrackSectionID.ToString());
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat("{0} : {1}", "Direction", ((Enums.Direction)this.ATStoOBATO_TrainDirection).ToString());
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat("{0} : {1}", "TrainSpeed", this.ATStoOBATO_TrainSpeed.ToString());
            stringBuilder.AppendLine();

            stringBuilder.AppendFormat("{0} : {1}", "DwellTime", this.DwellTime.ToString());
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
