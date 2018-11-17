using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace MeshNetworkServerSocket
{
    static class SocketUdpServer
    {
        static int localPort;
        static Socket listeningSocket;

        public static void SocketListenStart(int port)
        {
            localPort = port;

            try
            {
                listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                /*
                 * TODO : следить за закрытием окна и сделать кнопки выключения и перезапуска сервера
                 * 
                 * Заготовка для слушанья в отдельном потоке:
                 * Task listeningTask = new Task(Listen);
                 * listeningTask.Start();
                 */
                Listen();
            }
            catch (Exception ex)
            {
                MeshNetworkServerGUI.Program.log.Error("Socket Err: {0}", ex.Message);
            }
            finally
            {
                MeshNetworkServerGUI.Program.log.Error("Socket close");
                Close();
            }
        }

        private static void Listen()
        {
            try
            {
                IPEndPoint localIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), localPort);
                listeningSocket.Bind(localIP);

                while (true)
                {
                    int bytes = 0;
                    byte[] dataIn = new byte[36];

                    EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);

                    do
                    {
                        bytes = listeningSocket.ReceiveFrom(dataIn, ref remoteIp);
                        if (dataIn.Length != MeshNetworkServer.Package.bufferSize)
                        {
                            MeshNetworkServerGUI.Program.log.Warn("Received package invalid.");
                        }
                        else
                        { 
                            if (IsUnicue(dataIn))
                            {
                                MeshNetworkServer.Package packIn = MeshNetworkServer.Package.FromBinary(dataIn);
                                MeshNetworkServerGUI.Program.log.Debug("Received unique package.");
                                // TODO: отправка спарсенного пакета в БД
                            }
                            else
                            {
                                MeshNetworkServerGUI.Program.log.Debug("Received retry package.");
                            }
                        }
                    }
                    while (listeningSocket.Available > 0);
                }
            }
            catch (Exception ex)
            {
                MeshNetworkServerGUI.Program.log.Error("Listen Err: {0}", ex.Message);
            }
            finally
            {
                MeshNetworkServerGUI.Program.log.Trace("Listen close");
                Close();
            }
        }

        private static void Close()
        {
            if (listeningSocket != null)
            {
                listeningSocket.Shutdown(SocketShutdown.Both);
                listeningSocket.Close();
                listeningSocket = null;
            }
        }
        
        private static bool IsUnicue(byte[] data)
        {
            // TODO: проверка на уникальность
            return true;
        }
    }
}
