using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshNetworkServerGUI
{
    public partial class Form1 : Form
    {
        private bool flag_server = false;
        private bool flag_client = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (!flag_server) { 
                Task ServerTask = new Task(start_server);
                ServerTask.Start();
                button_start.BackColor = Color.Green;
                button_start.Text = "Stop server";
                flag_server = true;
            }
            else {
                MeshNetworkServerSocket.SocketUdpServer.SocketListenEnd();
                flag_server = false;
                button_start.BackColor = Color.Red;
                button_start.Text = "Start server";
            }
        }
        
        private void start_server()
        {
            MeshNetworkServerSocket.SocketUdpServer.SocketListenStart(8005);
        }

        private void button_client_Click(object sender, EventArgs e)
        {
            if (!flag_client)
            {
                Task ClientTask = new Task(MeshNetworkServerClient.SocketUdpClientTemplate.StartClient);
                ClientTask.Start();
                button_client.BackColor = Color.Green;
                button_client.Text = "Stop test client";
                flag_client = true;
            }
            else
            {
                MeshNetworkServerClient.SocketUdpClientTemplate.ClientStop();
                flag_client = false;
                button_client.BackColor = Color.Red;
                button_client.Text = "Start test client";
            }
        }

        private void showCharts_Click(object sender, EventArgs e)
        {
            try
            {
                var nodeNumber = int.Parse(nodeNumberTextBox.Text);
                (new ChartsForm(nodeNumber)).Show();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
