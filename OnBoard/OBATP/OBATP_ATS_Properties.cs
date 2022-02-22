using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public partial class OBATP : IWSATP_TO_OBATPMessageWatcher, IATS_TO_OBATO_InitMessageWatcher, IATS_TO_OBATO_MessageWatcher, IATS, IWSATC, IDisposable
    {
        #region IATS interface implemantation
        //[Browsable(false)]
        //public int DwellTime { get; set; } 
        private volatile int dwellTime;

        [Browsable(false)]
        public int DwellTime
        {
            get { return dwellTime; }

            set
            {
                if (value != Convert.ToUInt32(Enums.DwellTime.Non)) 
                { 

                    if (string.IsNullOrEmpty(this.setDwellTrackID))
                    {
                        this.setDwellTrackID = ActualFrontOfTrainCurrent.Track.Track_ID.ToString(); 
                        dwellTime = value; 
                        zongurt = dwellTime; 
                    }
                    else if (string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name) && (value == (int)Enums.DwellTime.Movement) && dwellTime != (int)Enums.DwellTime.Non)
                    {
                        dwellTime = (int)Enums.DwellTime.Non; 
                        zongurt = dwellTime; 
                       
                        this.setDwellTrackID = ActualFrontOfTrainCurrent.Track.Track_ID.ToString(); 
                    }
                    else if (!string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name) && (value != (int)Enums.DwellTime.Movement) && 
                        (this.setDwellTrackID != ActualFrontOfTrainCurrent.Track.Track_ID.ToString()))
                    {
                        dwellTime = value; 
                        zongurt = dwellTime; 
                        this.setDwellTrackID = ActualFrontOfTrainCurrent.Track.Track_ID.ToString();  
                    }   
 
                }
                
              
            }
        }


        private bool m_SkipStation;

        [Browsable(false)]
        public bool SkipStation
        {
            get { return m_SkipStation; }

            set
            {
                if ((value != m_SkipStation))
                {
                    //kabul edilmiş skipstation mevcut veya    //Bekleme süresi 5 ten az ise reddet
                    if ((value) && ((this.HoldTrainStatus == Enums.HoldTrain.Accepted) || (!string.IsNullOrEmpty(this.FrontOfTrainTrackWithFootPrint.Track.Station_Name))))
                    {
                        this.SkipStationStatus = Enums.SkipStation.Rejected;

                        m_SkipStation = false;
                    }
                    else if (value)
                    {
                        this.SkipStationStatus = Enums.SkipStation.Accepted;

                        m_SkipStation = true;
                    }
                    else if ((!value) && (this.SkipStationStatus == Enums.SkipStation.Non ))
                    {
                        m_SkipStation = false;
                    }
                }
            }

        }

        private bool m_HoldStation;


        [Browsable(false)]
        public bool HoldStation
        {
            get { return m_HoldStation; }

            set
            {
                if ((value != m_HoldStation))
                {
                    //kabul edilmiş skipstation mevcut veya    //Bekleme süresi 5 ten az ise reddet
                    if ((value) && ((this.SkipStationStatus == Enums.SkipStation.Accepted) || (zongurt < 5)))
                    { 

                        this.HoldTrainStatus = Enums.HoldTrain.Rejected;

                        //if (DisplayManager.TabControlSelectedIndexInvoke(MainForm.m_mf.m_tabControlLogs) == 3)
                            DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBoxTrainsLogs, this.Vehicle.TrainID.ToString() + " " + Localization.HoldStationRejectMessage, Color.Red);

                        m_HoldStation = false;
                    }
                    else if (value)
                    {
                        this.HoldTrainStatus = Enums.HoldTrain.Accepted;

                        //if (DisplayManager.TabControlSelectedIndexInvoke(MainForm.m_mf.m_tabControlLogs) == 3)
                            DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBoxTrainsLogs, this.Vehicle.TrainID.ToString() + " " + Localization.HoldStationAcceptMessage, Color.Red);

                        m_HoldStation = true;
                    } 
 
                }
            }

        }


        private bool m_cancelHoldStationAccepted;


        [Browsable(false)]
        public bool CancelHoldStationAccepted
        {
            get { return m_cancelHoldStationAccepted; }

            set
            {
                if ((value != m_cancelHoldStationAccepted))
                {
                    //kabul edilmiş skipstation mevcut veya    //Bekleme süresi 5 ten az ise reddet
                    if ((value) && (this.HoldTrainStatus == Enums.HoldTrain.Accepted))
                    {
                        this.HoldTrainStatus = Enums.HoldTrain.Non;

                        m_HoldStation = false;

                        //if (DisplayManager.TabControlSelectedIndexInvoke(MainForm.m_mf.m_tabControlLogs) == 3)
                            DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBoxTrainsLogs, this.Vehicle.TrainID.ToString() + " " + Localization.CancelHoldStationAccepted, Color.Red);

                        m_cancelHoldStationAccepted = true;
                    }
                    //else if (value)
                    //{
                    //    this.HoldTrainStatus = Enums.HoldTrain.Accepted;

                    //    m_HoldStation = true;
                    //}

                }
            }

        }


        private bool m_cancelSkipStation;


        [Browsable(false)]
        public bool CancelSkipStation
        {
            get { return m_cancelSkipStation; }

            set
            {
                if ((value != m_cancelSkipStation))
                {
                    //kabul edilmiş skipstation mevcut veya    //Bekleme süresi 5 ten az ise reddet
                    if ((value) && (this.SkipStationStatus == Enums.SkipStation.Accepted && string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name)))
                    {
                        this.SkipStationStatus = Enums.SkipStation.Non;


                        this.CancelSkipStationStatus = Enums.CancelSkipStation.Accepted;

                        //if (DisplayManager.TabControlSelectedIndexInvoke(MainForm.m_mf.m_tabControlLogs) == 3)
                            DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBoxTrainsLogs, this.Vehicle.TrainID.ToString() + " " + Localization.CancelSkipStationAcceptMessage, Color.Red);

                        m_cancelSkipStation = true; 
 
                    }
                    else if ((value) && (this.SkipStationStatus == Enums.SkipStation.Accepted && !string.IsNullOrEmpty(ActualFrontOfTrainCurrent.Track.Station_Name)))
                    {
                        this.CancelSkipStationStatus = Enums.CancelSkipStation.Rejected;

                        //if (DisplayManager.TabControlSelectedIndexInvoke(MainForm.m_mf.m_tabControlLogs) == 3)
                            DisplayManager.RichTextBoxInvoke(MainForm.m_mf.m_richTextBoxTrainsLogs, this.Vehicle.TrainID.ToString() + " " + Localization.CancelSkipStationRejectMessage, Color.Red);

                        m_cancelSkipStation = false;
                    }

                }
            }

        }



        #endregion
    }
}
