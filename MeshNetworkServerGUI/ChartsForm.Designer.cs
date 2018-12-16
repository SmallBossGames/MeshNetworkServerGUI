namespace MeshNetworkServerGUI
{
    partial class ChartsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.temperatureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.isFireChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lighteingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pressureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.humidityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.deviceStatusChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isFireChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lighteingChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.humidityChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceStatusChart)).BeginInit();
            this.SuspendLayout();
            // 
            // temperatureChart
            // 
            chartArea1.Name = "ChartArea1";
            this.temperatureChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.temperatureChart.Legends.Add(legend1);
            this.temperatureChart.Location = new System.Drawing.Point(12, 12);
            this.temperatureChart.Name = "temperatureChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Температура";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.temperatureChart.Series.Add(series1);
            this.temperatureChart.Size = new System.Drawing.Size(392, 300);
            this.temperatureChart.TabIndex = 0;
            this.temperatureChart.Text = "chart1";
            // 
            // isFireChart
            // 
            chartArea2.Name = "ChartArea1";
            this.isFireChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.isFireChart.Legends.Add(legend2);
            this.isFireChart.Location = new System.Drawing.Point(410, 318);
            this.isFireChart.Name = "isFireChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Пожар";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.isFireChart.Series.Add(series2);
            this.isFireChart.Size = new System.Drawing.Size(392, 300);
            this.isFireChart.TabIndex = 1;
            this.isFireChart.Text = "chart2";
            // 
            // lighteingChart
            // 
            chartArea3.Name = "ChartArea1";
            this.lighteingChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.lighteingChart.Legends.Add(legend3);
            this.lighteingChart.Location = new System.Drawing.Point(410, 12);
            this.lighteingChart.Name = "lighteingChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Освещение";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.lighteingChart.Series.Add(series3);
            this.lighteingChart.Size = new System.Drawing.Size(392, 300);
            this.lighteingChart.TabIndex = 2;
            this.lighteingChart.Text = "chart3";
            // 
            // pressureChart
            // 
            chartArea4.Name = "ChartArea1";
            this.pressureChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.pressureChart.Legends.Add(legend4);
            this.pressureChart.Location = new System.Drawing.Point(12, 318);
            this.pressureChart.Name = "pressureChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Давление";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.pressureChart.Series.Add(series4);
            this.pressureChart.Size = new System.Drawing.Size(392, 300);
            this.pressureChart.TabIndex = 3;
            this.pressureChart.Text = "chart4";
            // 
            // humidityChart
            // 
            chartArea5.Name = "ChartArea1";
            this.humidityChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.humidityChart.Legends.Add(legend5);
            this.humidityChart.Location = new System.Drawing.Point(808, 12);
            this.humidityChart.Name = "humidityChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Влажность";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.humidityChart.Series.Add(series5);
            this.humidityChart.Size = new System.Drawing.Size(392, 300);
            this.humidityChart.TabIndex = 4;
            this.humidityChart.Text = "chart5";
            // 
            // deviceStatusChart
            // 
            chartArea6.Name = "ChartArea1";
            this.deviceStatusChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.deviceStatusChart.Legends.Add(legend6);
            this.deviceStatusChart.Location = new System.Drawing.Point(808, 318);
            this.deviceStatusChart.Name = "deviceStatusChart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Устройство";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.deviceStatusChart.Series.Add(series6);
            this.deviceStatusChart.Size = new System.Drawing.Size(392, 300);
            this.deviceStatusChart.TabIndex = 1;
            this.deviceStatusChart.Text = "chart2";
            // 
            // ChartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 619);
            this.Controls.Add(this.humidityChart);
            this.Controls.Add(this.pressureChart);
            this.Controls.Add(this.lighteingChart);
            this.Controls.Add(this.deviceStatusChart);
            this.Controls.Add(this.isFireChart);
            this.Controls.Add(this.temperatureChart);
            this.Name = "ChartsForm";
            this.Text = "ChartsForm";
            ((System.ComponentModel.ISupportInitialize)(this.temperatureChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isFireChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lighteingChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.humidityChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceStatusChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart temperatureChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart isFireChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart lighteingChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart pressureChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart humidityChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart deviceStatusChart;
    }
}