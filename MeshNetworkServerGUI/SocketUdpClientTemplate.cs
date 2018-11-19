using MeshNetworkServer;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace MeshNetworkServerClient
{
    /* 
     * ПЕРЕД НАЧАЛОМ РАБОТЫ ВАЖНО ПРОЧИТАТЬ КОД И ВСЕ КОММЕНТАРИИ В ЭТОМ ФАЙЛЕ.
     * Можно сделать свою реализацию UDP узла, а можно воспользоватьэтим шаблоном.
     * Шаблон специально коряво написан, чтобы у всех вышел разный код, 
     * ведь все будут по разному решать проблемы и баги.
     * Для тестирования работы вашего клиента можно запустить приложение и стартануть и сервер,
     * сервер пишет в логи все свои действия, там читайте, через них дебажте
     */
    class SocketUdpClientTemplate
    {
        //Тут вы должны придумать как вы будете хранить все соседние узлы
        //Лучше, если ввод параметров соседних узлов будет из интерфейса или консоли
        //Здесь для примера храниться только 1 сосед
        private static string remoteAddress = "127.0.0.1"; // адрес для отправки
        private static int remotePort = 8005; // порт для отправки
        private static int localPort = 8004; // порт для получения
        private static Thread receiveThread;
        private static bool flag_stop;

        public static void StartClient()
        {
            try
            {
                flag_stop = false;
                receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
                SendMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SendMessage()
        {
            UdpClient sender = new UdpClient();
            byte[] data = new byte[Package.bufferSize];
            try
            {
                while (true)
                {
                    /* Здесь заполняете данные о ваших датчиках при помощи методов в файле Program.cs
                     * Для примерпа представлен вызов функции GenerateData, но это просто пример!
                     */
                    Package pack = GenerateData();
                    pack.ToBinary(data);
                    sender.Send(data, data.Length, remoteAddress, remotePort);
                    Thread.Sleep(100);//задержка между сообщениями
                    if (flag_stop) break;
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
            //Здесь вы генирируете пакеты с реалистичными рандомными значениями
            //Не просто рандом, а хотябы в реалистичных границах
            //Для понимания смотрите файл Package.cs
            pack.PackageId = (uint)rand.Next(100);  // Для примера
            pack.NodeId = 1;                        // Для примера
            pack.Time = DateTime.Now;               // Для примера
            pack.Humidity = 11;                     // Для примера
            pack.IsFire = false;                    // Для примера
            pack.Lighting = 11;                     // Для примера
            pack.Pressure = 11;                     // Для примера
            pack.Temperature = 11;                  // Для примера
            //
            return pack;
        }

        private static void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(localPort);            
            IPEndPoint remoteIp = null; // адрес входящего подключения
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp); // входящий пакет байт
                    Package pack = Package.FromBinary(data); //преобразование в пакет
                    /*
                     * Здесь нужно проверить id пакета (как? - смотри файл Package.cs и думай)
                     * И если пакет с таким id ранее не был получен, то:
                     *     - отправить всем соседям
                     *      (хорошо бы использовать широкофещательную рассылку: https://metanit.com/sharp/net/5.3.php)
                     *     - сохранить его id в список или перезаписываемый массив 
                     *      (достаточно хранить 255 последних пакетов)
                     * Иначе забыть про этот пакет
                     */
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
            // Эту функцию тоже желательно не так коряво реализовать, 
            //она на данный момент вообще не всего клиента завершает
            receiveThread.Abort();
            flag_stop = true;
        }
    }
}