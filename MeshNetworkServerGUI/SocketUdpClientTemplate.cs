using MeshNetworkServer;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MeshNetworkServerClient
{
    /* 
     * ПЕРЕД НАЧАЛОМ РАБОТЫ ВАЖНО ПРОЧИТАТЬ КОД И ВСЕ КОММЕНТАРИИ В ЭТОМ ФАЙЛЕ.
     * Можно сделать свою реализацию UDP узла, а можно воспользоватьэтим шаблоном.
     * Шаблон СПЕЦИАЛЬНО КОРЯВО НАПИСАН, чтобы у всех вышел разный код, 
     * ведь все будут по разному решать проблемы и баги.
     * Для тестирования работы вашего клиента можно запустить приложение и стартануть и сервер,
     * сервер пишет в логи все свои действия, там читайте, через них дебажте
     */
    class SocketUdpClientTemplate
    {
        struct u_id
        {
            public uint pack;
            public ushort node;
        };
        /* Тут вы должны придумать как вы будете хранить все соседние узлы
        * Лучше, если ввод параметров соседних узлов будет из интерфейса или консоли
        * Здесь для примера храниться только 1 сосед*/
        private static string remoteAddress = "192.168.1.3"; // адрес для отправки
        private static int remotePort = 8004; // порт для отправки
        private static int localPort = 8004; // порт для получения
        /* из-за не динамических портов два раза клиента или двух клиентов на одном пк не запустить,
         * надо иначе реализовать этот момент, читайте метанит */
        static Task taskReceive;
        static Task taskSend;
        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        static CancellationToken tokenReceive = cancellationTokenSource.Token;
        static CancellationTokenSource tokenSource = new CancellationTokenSource();
        static CancellationToken tokenSend = tokenSource.Token;

        //private static uint[] massId;
        private static u_id[] massId;
        static List<uint> IdArray = new List<uint>();
        private static int n = 0;
        private const int MASS_LENGHT = 255;

        public static void StartClient()
        {
            try
            {
                taskReceive = new Task(() => ReceiveMessage(tokenReceive));
                taskReceive.Start();
                taskSend = new Task(() => SendMessage(tokenSend));
                taskSend.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SendMessage(CancellationToken token)
        {
            UdpClient sender = new UdpClient();
            byte[] data = new byte[Package.bufferSize];
            try
            {
                while (true)
                {
                    if (token.IsCancellationRequested) break;
                    /* Здесь заполняете данные о ваших датчиках при помощи методов в файле Program.cs
                     * Для примера представлен вызов функции GenerateData, но это просто пример!*/
                    Package pack = GenerateData();
                    pack.ToBinary(data);
                    sender.Send(data, data.Length, remoteAddress, remotePort);
                    IdArray.Add(pack.PackageId);
                    Thread.Sleep(500); // задержка между сообщениями
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sender.Close();
            }
        }

        private static Package GenerateData()
        {
            Random rand = new Random();
            Package pack = new Package();
            /* Здесь вы генирируете пакеты с реалистичными рандомными значениями
            *  Не просто рандом, а хотя бы в реалистичных границах
            *  Для понимания смотрите файл Package.cs */
            pack.PackageId = (uint)rand.Next(100);  // Для примера
            pack.NodeId = 2;                        // Для примера
            pack.Time = DateTime.Now;               // Для примера
            pack.Humidity = 11;                     // Для примера
            pack.IsFire = false;                    // Для примера
            pack.Lighting = 11;                     // Для примера
            pack.Pressure = 11;                     // Для примера
            pack.Temperature = 11;                  // Для примера
            //
            return pack;
        } 

        private static void ReceiveMessage(CancellationToken token)
        {
            UdpClient receiver = new UdpClient(remotePort);
            IPEndPoint remoteIp = new IPEndPoint(IPAddress.Parse(remoteAddress), remotePort); // адрес входящего подключения
            try
            {
                while (true)
                {
                    MeshNetworkServerGUI.Program.log.Debug("Client is waiting your orders.");
                    byte[] data = receiver.Receive(ref remoteIp); // входящий пакет байт
                    Package pack = Package.FromBinary(data); // преобразование в пакет
                    MeshNetworkServerGUI.Program.log.Debug("Client accepted.");
                    if (IsUnicueList(data))
                    {
                        receiver.Send(data, data.Length, remoteAddress, remotePort);
                        IdArray.Add(pack.PackageId);
                        MeshNetworkServerGUI.Program.log.Debug("Client resended.");
                    }
                    else MeshNetworkServerGUI.Program.log.Debug("Client is not unique.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                receiver.Close();
            }
        }

        public static void ClientStop()
        {
            cancellationTokenSource.Cancel();
            tokenSource.Cancel();
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
            n++;
            if (n == MASS_LENGHT) n = 0;
            return true;
        }

        static bool IsUnicueList(byte[] data)
        {
            var IDOfPackage = Package.FromBinary(data);

            if (IdArray.Count == 0)
            {
                IdArray.Add(IDOfPackage.PackageId);
                return true;
            }

            foreach (var a in IdArray)
            {
                if (a == IDOfPackage.PackageId) return false;                
            }

            IdArray.Add(IDOfPackage.PackageId);
            return true;
        }
    }
}