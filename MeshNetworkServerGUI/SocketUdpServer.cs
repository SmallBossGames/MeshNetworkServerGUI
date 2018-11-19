using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using MeshNetworkServer;
using MeshNetworkServerGUI;

namespace MeshNetworkServerSocket
{
    static class SocketUdpServer
    {
        public static event EventHandler<PackageModel> OnRecivePackage; 

        private static int localPort;
        private static Socket listeningSocket;

        public static void SocketListenStart(int port)
        {
            localPort = port;
            try
            {
                listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                /* Заготовка для слушанья в отдельном потоке:
                 * Task listeningTask = new Task(Listen);
                 * listeningTask.Start();
                 */
                Listen();
            }
            catch (Exception ex)
            {
                MeshNetworkServerGUI.Program.log.Error("Socket: {0}", ex.Message);
            }
            finally
            {
                MeshNetworkServerGUI.Program.log.Trace("Socket close");
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
                    byte[] dataIn = new byte[MeshNetworkServer.Package.bufferSize];
                    bool flag_close = false;
                    EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);

                    do
                    {
                        try
                        {
                            bytes = listeningSocket.ReceiveFrom(dataIn, ref remoteIp);
                        }
                        catch(Exception exept)
                        {
                            MeshNetworkServerGUI.Program.log.Trace("Server hard shutdown: {0}", exept.Message);
                            flag_close = true;
                            break;
                        }
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

                                SavePackage(packIn);
                            }
                            else
                            {
                                MeshNetworkServerGUI.Program.log.Debug("Received retry package.");
                            }
                        }
                    }
                    while (listeningSocket.Available > 0);
                    if (flag_close) break;
                }
            }
            catch (Exception ex)
            {
                MeshNetworkServerGUI.Program.log.Error("Listen: {0}", ex.Message);
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

        public static void SocketListenEnd()
        {
            //TODO : исправить остановку сервера, неправильно завершается listen, 
            //т.к. прерывается блокирующая операция ReceiveFrom (ну, в приниципе, и так сойдёт)
            Close();
            MeshNetworkServerGUI.Program.log.Trace("Forsed stop");
        }


        private static bool IsUnicue(byte[] data)
        {
            uint number = BitConverter.ToUInt32(data, 0);
            // TODO: проверка на уникальность:
            // поиск номера в бд и если его там нет, то:
            return true;
            // иначе:
            // return false;
        }

        private static void SavePackage(Package package)
        {
            var packageModel = PackageConverter.ToPackageModel(package);

            OnRecivePackage(null, packageModel);
            using (var context = new ApplicationDbContext())
            {
                context.Packages.Add(packageModel);
                context.SaveChanges();
            }
        }
    }
}
