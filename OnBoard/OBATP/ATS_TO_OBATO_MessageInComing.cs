using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard 
{
    public partial class OBATP : IWSATP_TO_OBATPMessageWatcher, IATS_TO_OBATO_InitMessageWatcher, IATS_TO_OBATO_MessageWatcher, IATS, IWSATC, IDisposable
    {
        public void ATS_TO_OBATO_MessageInComing(Enums.Train_ID train_ID, ATS_TO_OBATOAdapter ATS_TO_OBATOAdapter)
        {
            lock (ATS_TO_OBATOAdapter)
            {
                if (this.Vehicle.TrainID == train_ID)
                {
                    //if (!this.DwellTimeFinished)
                    {
                        //Debug.WriteLine("geldim1 ATS_TO_OBATO_MessageInComing dwell gönderdim : " + ATS_TO_OBATOAdapter.DwellTime.ToString());
                        this.DwellTime = ATS_TO_OBATOAdapter.DwellTime;



                        //if (ATS_TO_OBATOAdapter.DwellTime > 2)
                        //this.HoldStation = true;


                        this.HoldStation = ATS_TO_OBATOAdapter.HoldTrain;


                        //if(this.ActualFrontOfTrainCurrent.Track.Track_ID == 10104)
                        //    this.SkipStation = true;
                        ////else
                        this.SkipStation = ATS_TO_OBATOAdapter.SkipStation;

                        //this.SkipStation = true;


                        this.CancelHoldStationAccepted = ATS_TO_OBATOAdapter.CancelHoldTrain;

                        this.CancelSkipStation = ATS_TO_OBATOAdapter.CancelSkipStation;

                        //Debug.WriteLine("this.HoldStation: " + ATS_TO_OBATOAdapter.HoldTrain.ToString());
                        //Debug.WriteLine("this.SkipStation : " + ATS_TO_OBATOAdapter.SkipStation.ToString());

                        //Debug.WriteLine("geldim2 ATS_TO_OBATO_MessageInComing dwell gönderdim : " + ATS_TO_OBATOAdapter.DwellTime.ToString());
                    }
                    //else
                    //{
                    //    Debug.WriteLine("true ATS_TO_OBATO_MessageInComing dwell gönderdim : " + ATS_TO_OBATOAdapter.DwellTime.ToString());
                    //}
                       

                    //this.DwellTime = ATS_TO_OBATOAdapter.DwellTime;


                }
            }
        }
    }
}
