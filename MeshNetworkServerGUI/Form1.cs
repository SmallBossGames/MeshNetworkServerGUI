using MeshNetworkServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshNetworkServerGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var package = new Package
                {
                    PackageId = 23,
                    NodeId = 13,
                    Time = DateTime.Now,
                    Temperature = 14,
                };
                context.Packages.Add(PackageConverter.ToPackageModel(package));
                await context.SaveChangesAsync();
            }


            using (var context = new ApplicationDbContext())
            {
                var temp = await context.GetPackagesAsync();

                TemperatureChart.Series.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    TemperatureChart.Series.Add($"Устройство {temp[i][0].NodeId}");
                    TemperatureChart.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                    foreach (var package in temp[i])
                    {
                        TemperatureChart.Series[i].Points.AddXY(package.Time, package.Temperature.Value);
                    }
                }
                
            }
        }


    }
}
