using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnBoard
{ 
        partial class SocketCommunication 
    {
        #region variables   
        internal System.Threading.Timer STTimer;
        bool kontrol = false;
        //Server m_server;
        public enum ClientType { ATS, WSATC };

        Client m_clientWSATC ;
        Client m_clientATS ;

        #endregion

        #region constructor
        public SocketCommunication()
        {
           
        }

        

        #endregion

        #region singletonpattern
            private static SocketCommunication m_do;

            public static SocketCommunication Singleton()
            {
                if (m_do == null)
                    m_do = new SocketCommunication();

                return m_do;
            }
        #endregion


       

        public void Start(Enums.CommunicationType communicationType, ClientType clientType, string ipAddress, int port)
        {

            if (communicationType == Enums.CommunicationType.Server)
            {

                SocketCommunication.Server.Singleton().StartServer(ipAddress, port);
                //Server server = new Server();
                //server.StartServer(ipAddress, port);
            }

            else
            {
                // Client  client = new Client();

                //client.StartClient(ipAddress, port);  m_client = client;
                //SocketCommunication.Client.Singleton().StartClient(ipAddress, port);
                if(clientType == ClientType.ATS)
                {
                    //m_clientATS = new ClientATS();

                    if(m_clientATS == null)
                    {
                        m_clientATS = new ClientATS();
                    }

                    m_clientATS.StartClient(ipAddress, port);
                }
                   
                else if (clientType == ClientType.WSATC)
                {
                    //m_clientWSATC = new ClientWSATC();

                    if (m_clientWSATC == null)
                    {
                        m_clientWSATC = new ClientWSATC();
                    }

                    m_clientWSATC.StartClient(ipAddress, port);
                }
                   



              

            }
        }

        public void Stop(Enums.CommunicationType communicationType, ClientType clientType)
        {

            if (communicationType == Enums.CommunicationType.Server)
            {
                //SocketCommunication.Server.Singleton().StopServer();

                //m_server.StopServer();
            }
            else
            {
                if (clientType == ClientType.ATS)
                {
                    //m_clientATS.StopObserverWatcher();

                    m_clientATS.StopClient(false);


                     
                }

                else if (clientType == ClientType.WSATC)
                {

                    //m_clientWSATC.StopObserverWatcher();

                    m_clientWSATC.StopClient(false);
                }


                //m_client.StopClient(false);
                //SocketCommunication.Client.Singleton().StopClient(false);
            }
        } 
         
            #region methods  

          
            private static int StringToByteMsg(string str, byte[] buf)
            {
               
                int textLen;

                textLen = Encoding.UTF8.GetBytes(str, 0, str.Length, buf, 4);
                byte[] bufLen = BitConverter.GetBytes(textLen);
                Array.Copy(bufLen, buf, 4);

                return textLen + 4;
               
            }

       
     


        #endregion

        #region classinfo
        class ClientInfo
            {
                private Socket m_sock;
                private byte[] m_bufRecv, m_bufSend;
                private int m_indexRecv, m_indexSend;
                private int m_leftRecv, m_leftSend;
                private bool m_lengthFlagRecv;


                public ClientInfo()
                {
                    m_bufRecv = new byte[1024];
                }

                public Socket Sock
                {
                    get { return m_sock; }
                    set { m_sock = value; }
                }

                public byte[] BufRecv
                {
                    get { return m_bufRecv; }
                    set { m_bufRecv = value; }
                }

                public byte[] BufSend
                {
                    get { return m_bufSend; }
                    set { m_bufSend = value; }
                }
                public int IndexRecv
                {
                    get { return m_indexRecv; }
                    set { m_indexRecv = value; }
                }
                public int LeftRecv
                {
                    get { return m_leftRecv; }
                    set { m_leftRecv = value; }
                }
                public int LeftSend
                {
                    get { return m_leftSend; }
                    set { m_leftSend = value; }
                }

                public bool LengthFlagRecv
                {
                    get { return m_lengthFlagRecv; }
                    set { m_lengthFlagRecv = value; }
                }

                public int IndexSend
                {
                    get { return m_indexSend; }
                    set { m_indexSend = value; }
                }
            }
            #endregion
        }
    }
 
