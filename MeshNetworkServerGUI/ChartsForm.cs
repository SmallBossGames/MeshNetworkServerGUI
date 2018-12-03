using MeshNetworkServerSocket;
using System;
using System.Windows.Forms;
using System.Linq;

namespace MeshNetworkServerGUI
{
    public partial class ChartsForm : Form
    {
        private readonly int _nodeId;

        public ChartsForm(int nodeId)
        {
            _nodeId = nodeId;
            
            InitializeComponent();

            /*Random rand = new Random();

            OnRecivePackage(new PackageModel
            {
                PackageId = (uint)rand.Next(100),  // Для примера
                NodeId = 1,                        // Для примера
                Time = DateTime.Now,               // Для примера
                Humidity = 11,                     // Для примера
                IsFire = false,                    // Для примера
                Lighting = 11,                     // Для примера
                Pressure = 11,                     // Для примера
                Temperature = 11,
            });*/

            LoadQueryData();
        }

        void OnRecivePackage(PackageModel package)
        {
            if (package.NodeId != _nodeId)
            {
                return;
            }

            DrawCharts(package);
        }

        void LoadQueryData()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    from package in context.Packages
                    where package.NodeId == _nodeId
                    select package;

                foreach (var item in query)
                {
                    DrawCharts(item);
                }
            }
            
        }

        void DrawCharts(PackageModel package)
        {
            if (package.Temperature != null)
            {
                temperatureChart.Series[0].Points.AddXY(package.Time, package.Temperature.Value);
            }

            if (package.Pressure != null)
            {
                pressureChart.Series[0].Points.AddXY(package.Time, package.Pressure.Value);
            }

            if (package.IsFire != null)
            {
                isFireChart.Series[0].Points.AddXY(package.Time, package.IsFire.Value);
            }

            if (package.Lighting != null)
            {
                lighteingChart.Series[0].Points.AddXY(package.Time, package.Lighting.Value);
            }

            if (package.Humidity != null)
            {
                humidityChart.Series[0].Points.AddXY(package.Time, package.Humidity.Value);
            }
        }

        private void ChartsForm_Load(object sender, EventArgs e)
        {
            SocketUdpServer.OnRecivePackage += OnRecivePackage;
        }

        private void ChartsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SocketUdpServer.OnRecivePackage -= OnRecivePackage;
        }
    }
}
