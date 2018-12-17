using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace MeshNetworkServerGUI
{
    public partial class NetworkInfoChart : Form
    {
        public NetworkInfoChart()
        {
            InitializeComponent();
            UpdateChart();
        }

        private void UpdateChart()
        {
            using (var context = new ApplicationDbContext())
            {
                chart1.Series.Clear();

                var query =
                    from package in context.Packages
                    group package by package.NodeId;

                int deviceCounter = 0;

                foreach (var group in query)
                {
                    deviceCounter++;
                    string seriesName = $"Устройство {group.Key}";
                    chart1.Series.Add(seriesName);
                    foreach (var item in group)
                    {
                        chart1.Series[seriesName].Points.AddXY(item.Time, deviceCounter);
                    }
                }
            }

        }
    }
}
