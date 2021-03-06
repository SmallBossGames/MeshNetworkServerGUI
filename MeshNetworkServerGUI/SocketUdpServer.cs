﻿using System;
using System.Net;
using System.Net.Sockets;

namespace MeshNetworkServerSocket
{
    static class SocketUdpServer
    {
        struct u_id
        {
            public uint pack;
            public ushort node;
        };

        private static int localPort;
        private static Socket listeningSocket;
        private static u_id[] massId;
        private static int n = 0;
        private const int MASS_LENGHT = 255;
        public static void SocketListenStart(int port)
        {
            massId = new u_id[MASS_LENGHT];
            localPort = port;
            try
            {
                listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
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
                IPEndPoint localIP = new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), localPort);
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
                        catch (Exception exept)
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
                                MeshNetworkServerGUI.Program.log.Debug("Received unique package from {0} number {1}", packIn.NodeId, packIn.PackageId);
                                SavePackage(packIn);
                            }
                            else
                            {
                                ushort node = BitConverter.ToUInt16(dataIn, 4);
                                MeshNetworkServerGUI.Program.log.Debug("Received retry package from: {0}", node);
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
            Close();
            MeshNetworkServerGUI.Program.log.Trace("Forsed stop");
        }

        private static bool IsUnicue(byte[] data)
        {
            ushort node = BitConverter.ToUInt16(data, 4);
            uint number = BitConverter.ToUInt32(data, 0);
            for (int i = 0; i < MASS_LENGHT; i++)
            {
                if (massId[i].pack == number && massId[i].node == node) return false;
            }
            massId[n].pack = number;
            massId[n].node = node;
            n = (n + 1) % MASS_LENGHT;
            return true;
        }

        private static void SavePackage(MeshNetworkServer.Package package)
        {
            var packageModel = MeshNetworkServerGUI.PackageConverter.ToPackageModel(package);
            using (var context = new MeshNetworkServerGUI.ApplicationDbContext())
            {
                context.Packages.Add(packageModel);
                context.SaveChanges();
            }
        }

        public static string GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ipAddress in host.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddress.ToString();
                }
            }
            throw new Exception("No network adapters with an IP v4");
        }

    }
}