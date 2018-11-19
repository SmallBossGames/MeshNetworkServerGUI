using MeshNetworkServerSocket;
using System;
using System.Windows.Forms;

namespace MeshNetworkServerGUI
{
    public partial class ChartsForm : Form
    {
        private readonly int _nodeId;

        public ChartsForm(int nodeId)
        {
            _nodeId = nodeId;
            
            InitializeComponent();
        }

        void OnRecivePackage(object sender, PackageModel package)
        {
            if (package.NodeId != _nodeId)
            {
                return;
            }

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
