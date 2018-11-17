using MeshNetworkServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace MeshNetworkServerGUI
{
    static class Program
    {
        public static Logger log;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StartLoging();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            MeshNetworkServerSocket.SocketUdpServer.SocketListenStart(8005);
        }

        private static void StartLoging()
        {
            try
            {
                log = LogManager.GetCurrentClassLogger();
                log.Trace("Version: {0}", Environment.Version.ToString());
                log.Trace("OS: {0}", Environment.OSVersion.ToString());
                log.Trace("Command: {0}", Environment.CommandLine.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы с логированием!\n" + ex.Message);
            }
        }
    }
}
