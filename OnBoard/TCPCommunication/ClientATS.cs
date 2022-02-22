using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnBoard 
{
    partial class SocketCommunication
    {
        class ClientATS : Client, ITrainCreatedWatcher, ITrainMovementCreatedSendMessageWatcher
        {
            #region variables
            private static ClientATS m_do = null;
            ConcurrentBag<OBATP> m_createdTrainsMessage;
            #endregion
            public ClientATS()
            {
                //m_clientBufRecv = new byte[1024];
                //m_clientBufSend = new byte[1024];

                ////m_stopWatch = new Stopwatch();
                ////m_timer = new System.Timers.Timer(1000);
                ////m_timer.Elapsed += m_stopWatch_Elapsed;

                m_createdTrainsMessage = new ConcurrentBag<OBATP>();

                #region ayarları okuma
                m_settings = XMLSerialization.Singleton();
                m_settings = m_settings.DeSerialize(m_settings);
                #endregion

              
                sda();

                //m_createdTrainsMessage = new ConcurrentBag<OBATP>();

                //create
                MainForm.m_trainObserver.AddTrainCreatedWatcher(this);
                //movement
                MainForm.m_trainObserver.AddTrainMovementCreatedSendMessageWatcher(this);
            }

            #region singleton
            public static ClientATS ClientATSSingleton()
            {
                if (m_do == null)
                    m_do = new ClientATS();

                return m_do;
            }
            #endregion

            #region TrainCreated
            public void TrainCreated(OBATP OBATP)
            {
                m_createdTrainsMessage.Add(OBATP);
            }
            #endregion


            #region TrainMovementCreated
            public void TrainMovementCreatedSendMessage(OBATP OBATP)
            {
                lock (OBATP)
                { 
                    using (MessageCreator messageCreator = new MessageCreator())
                    { 
                        OBATO_TO_ATS_MessageBuilder OBATO_TO_ATS_Message = new OBATO_TO_ATS_MessageBuilder();
                        messageCreator.SetMessageBuilder(OBATO_TO_ATS_Message);

                        using (OBATO_TO_ATSAdapter adappppppppp = new OBATO_TO_ATSAdapter(OBATP))
                        {
                            byte[] OBATO_TO_ATS_ByteArray = adappppppppp.ToByte();

                            int OBATP_ID = 20000 + Convert.ToInt32(OBATP.Vehicle.TrainID); 

                            messageCreator.CreateMessage(1, (UInt32)OBATP_ID, DateTimeExtensions.GetAllMiliSeconds(), 1, OBATO_TO_ATS_ByteArray, 47851476196393100); 
                            Message message = messageCreator.GetMessage();


                            //test için gelen mesajları durdurma
                            //giden mesajları durdur
                            if (MainForm.m_outgoingMsgStatus)
                            {
                                SendMsgToServer(message.ToByte(), Tuple.Create<DateTime, string, string>(DateTime.Now, message.ToString(), adappppppppp.ToString()));

                                //test için eklenen kod kısmı
                                //MainForm.m_outgoingMsgCounter++; 

                                //string outgoingMsgCounter = string.Format("({0})", MainForm.m_outgoingMsgCounter);
                                //MainForm.m_mf.m_outgoingMsgInformationPopup.Text = outgoingMsgCounter;


                                //MainForm.m_mf.m_databaseOperation.AsyncPOSTInsert(m_settings.PersonnelID, m_settings.PlayID, DateTime.Now, message.ToByte(), "OBATO_TO_ATS_SERVER");
                            }
                        }
                    }
                   

                }
            }

            #endregion


            public override void StopObserverWatcher()
            {
                //create
                MainForm.m_trainObserver.RemoveTrainCreatedWatcher(this);
                //movement
                MainForm.m_trainObserver.RemoveTrainMovementCreatedSendMessageWatcher(this);
            }


            #region SendCreatedTrain
            public   void SendTrainCreated()
            {

                while (!m_createdTrainsMessage.IsEmpty && m_clientSock.Connected)
                {
                    OBATP OBATP = null;

                    try
                    {
                        if (m_createdTrainsMessage.TryTake(out OBATP))
                        {
                            if (OBATP.Status == Enums.Status.Create)
                                m_createdTrainsMessage.Add(OBATP);



                            using (MessageCreator messageCreator = new MessageCreator())
                            {
                                OBATO_TO_ATS_MessageBuilder OBATO_TO_ATS_Message = new OBATO_TO_ATS_MessageBuilder();
                                messageCreator.SetMessageBuilder(OBATO_TO_ATS_Message);

                                using (OBATO_TO_ATSAdapter adappppppppp = new OBATO_TO_ATSAdapter(OBATP))
                                {
                                    byte[] OBATO_TO_ATS_ByteArray = adappppppppp.ToByte();

                                    int OBATP_ID = 20000 + Convert.ToInt32(OBATP.Vehicle.TrainID);
                                    messageCreator.CreateMessage(1, (UInt32)OBATP_ID, DateTimeExtensions.GetAllMiliSeconds(), 1, OBATO_TO_ATS_ByteArray, 47851476196393100);

                                    Message message = messageCreator.GetMessage();

                                    //test için gelen mesajları durdurma
                                    //giden mesajları durdur
                                    if (MainForm.m_outgoingMsgStatus)
                                    {
                                        SendMsgToServer(message.ToByte(), Tuple.Create<DateTime, string, string>(DateTime.Now, message.ToString(), adappppppppp.ToString()));

                                        //test için eklenen kod kısmı
                                        //MainForm.m_outgoingMsgCounter++;

                                        //string outgoingMsgCounter = string.Format("({0})", MainForm.m_outgoingMsgCounter);
                                        //MainForm.m_mf.m_outgoingMsgInformationPopup.Text = outgoingMsgCounter;

                                    }
                                }
                            }

                            //Thread.Sleep(1000);
                        }
                    }
                    catch(Exception ex)
                    {
                        Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "SendTrainCreated() ClientATS");
                    }
                    finally
                    {
                        if (OBATP != null &&  OBATP.Status == Enums.Status.Create && !m_createdTrainsMessage.Contains(OBATP))
                        {
                            m_createdTrainsMessage.Add(OBATP);
                        } 
                      
                    }

                

                }

            }
            #endregion

            public void sda()
            {
                if (!SocketCommunication.Singleton().kontrol)
                {
                    SocketCommunication.Singleton().kontrol = true;

                    if (SocketCommunication.Singleton().STTimer != null)
                        SocketCommunication.Singleton().STTimer.Dispose();

                    //this.STTimer = new System.Threading.Timer(DeleteInValidImages, null, 1000, System.Threading.Timeout.Infinite);
                    SocketCommunication.Singleton().STTimer = new System.Threading.Timer(DeleteInValidImages, null, 1000, 5000);
                }

            }

            public void DeleteInValidImages(object o)
            {
                try
                {

                    this.SendTrainCreated();

                }
                catch (ThreadInterruptedException ex)
                {
                    //SocketCommunication.Singleton().kontrol = false;
                    //sda();
                    Logging.WriteLog( ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "socket1");

                }
                catch (Exception ex)
                {
                    //SocketCommunication.Singleton().kontrol = false;
                    //sda();
                    Logging.WriteLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "socket2");
                }
            }















        }
    }
}
