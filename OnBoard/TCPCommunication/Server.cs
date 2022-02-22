using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    partial class SocketCommunication
    {
        public class Server 
        {
            #region variables
            private static Server m_do = null;
            internal Socket m_serverSock;
            string m_protocolMsg, m_incomingMsg; 
            Stopwatch m_stopWatch;
            private ThreadSafeList<ClientInfo> m_clients;

            #endregion

            #region constructor
            public Server()
            { 
                m_stopWatch = new Stopwatch(); 
                m_clients = new ThreadSafeList<ClientInfo>();
            }

            #endregion

            #region singleton
            public static Server Singleton()
            {

                if (m_do == null)
                    m_do = new Server();

                return m_do;

            }
            #endregion  

            public void StartServer(string ipAddress, int port)
            {
                try
                {
                    m_serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    m_serverSock.Bind(new IPEndPoint(IPAddress.Any, port));
                    //m_serverSock.Bind(new IPEndPoint(ipAddress, port));
                    m_serverSock.Listen(30);
                    m_serverSock.NoDelay = true;
                    m_serverSock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);

                    
                  
                    m_serverSock.BeginAccept(new AsyncCallback(ServerAcceptProc), null);

                }
                catch (Exception ex)
                {
                   
                }
            }

            public void StopServer()
            {
                if (m_serverSock != null || (m_serverSock != null && m_serverSock.Connected))
                {
                    foreach (ClientInfo ci in m_clients)
                    {
                        if (ci != null && ci.Sock.Connected)
                            SendMsgToClient(ci, "LISTENINGSTOP$");
                    }

                    m_serverSock.Close();
               

                }
            }

            private void ServerAcceptProc(IAsyncResult iar)
            {
                try
                {
                    m_serverSock.BeginAccept(new AsyncCallback(ServerAcceptProc), null);

                    Socket clientSock;
                    clientSock = m_serverSock.EndAccept(iar);

                    ClientInfo ci = new ClientInfo();
                    ci.Sock = clientSock;
                    ci.Sock.NoDelay = true;
                    ci.Sock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);

                    m_clients.Add(ci); 
 

                    ci.LeftRecv = 4;
                    ci.IndexRecv = 0;
                    ci.LengthFlagRecv = true;

                    clientSock.BeginReceive(ci.BufRecv, ci.IndexRecv, ci.LeftRecv, SocketFlags.None, new AsyncCallback(ServerReceiveProc), ci);
                }
                catch (ObjectDisposedException)
                {
                   

                }
            }


            private void ServerReceiveProc(IAsyncResult iar)
            {
                ClientInfo ci = (ClientInfo)iar.AsyncState;
                int n = 0;

                try
                {
                    n = ci.Sock.EndReceive(iar);

                    ci.IndexRecv += n;
                    ci.LeftRecv -= n;

                    if (ci.LeftRecv == 0)
                    {
                        if (ci.LengthFlagRecv)
                        {
                            ci.LeftRecv = BitConverter.ToInt32(ci.BufRecv, 0);
                            ci.IndexRecv = 0;
                            ci.LengthFlagRecv = false;
                        }
                        else
                        {
                            string msg = Encoding.UTF8.GetString(ci.BufRecv, 0, ci.IndexRecv);
                            m_protocolMsg = msg.Substring(0, msg.IndexOf("$"));
                            m_incomingMsg = msg.Substring(msg.IndexOf("$") + 1);

                            if (!m_stopWatch.IsRunning)
                            {
                                m_stopWatch.Reset();
                                m_stopWatch.Start();
                            }

                           

                            ci.LengthFlagRecv = true;
                            ci.IndexRecv = 0;
                            ci.LeftRecv = 4;
                        }
                    }

                    ci.Sock.BeginReceive(ci.BufRecv, ci.IndexRecv, ci.LeftRecv, SocketFlags.None, new AsyncCallback(ServerReceiveProc), ci);
                }
                catch (Exception e)
                {
                    DisposeClient(ci);
                    
                }
            }



            private void ServerSendProc(IAsyncResult iar)
            {
                ClientInfo ci = (ClientInfo)iar.AsyncState;
                try
                {
                    int n = ci.Sock.EndSend(iar);

                    ci.IndexSend += n;
                    ci.LeftSend -= n;

                    //if (ci.LeftSend != 0)
                    //    ci.Sock.BeginSend(ci.BufSend, ci.IndexSend, ci.LeftSend, SocketFlags.None, new AsyncCallback(ServerSendProc), ci);
                    //}
                }
                catch (Exception e)
                {
                    DisposeClient(ci);
                    
                }
            }

            #region methods
            private void DisposeClient(ClientInfo ci)
            {
                ci.Sock.Dispose();

                m_clients.Remove(ci);
            }

            private void SendMsgToClient(ClientInfo ci, string msg)
            {
                try
                {
                    byte[] buf = new byte[5120];
                    int len;

                    len = StringToByteMsg(msg, buf);

                    ci.BufSend = buf;
                    ci.IndexSend = 0;
                    ci.LeftSend = len;

                    ci.Sock.BeginSend(ci.BufSend, ci.IndexSend, ci.LeftSend, SocketFlags.None, new AsyncCallback(ServerSendProc), ci);
                }
                catch (Exception e)
                {
                    DisposeClient(ci);

                    //Logging.WriteLog(DateTime.Now.ToString(), e.Message.ToString(), e.StackTrace.ToString(), e.TargetSite.ToString(), EDSType.CorridorSpeed);
                    //DisplayManager.RichTextBoxInvoke(SocketCommunication.Singleton().m_speedCorridor.richTextBox1, "Exception oluştu: SendMsgToClient ", Color.DarkRed);
                }
            }

            private void SendMsgToClient(ClientInfo ci, byte[] buf)
            {
                try
                {
                    ci.BufSend = buf;
                    ci.IndexSend = 0;
                    ci.LeftSend = buf.Length;


                    ci.Sock.BeginSend(ci.BufSend, ci.IndexSend, ci.LeftSend, SocketFlags.None, new AsyncCallback(ServerSendProc), ci);
                }
                catch (Exception e)
                {
                    DisposeClient(ci);
                    //Logging.WriteLog(DateTime.Now.ToString(), e.Message.ToString(), e.StackTrace.ToString(), e.TargetSite.ToString(), EDSType.CorridorSpeed);
                    //DisplayManager.RichTextBoxInvoke(SocketCommunication.Singleton().m_speedCorridor.richTextBox1, "Exception oluştu: SendMsgToClient ", Color.DarkRed);
                }
            }


        
        
            #endregion

        }
    }
}
