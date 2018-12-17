namespace MeshNetworkServerGUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_start = new System.Windows.Forms.Button();
            this.button_client = new System.Windows.Forms.Button();
            this.showCharts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeNumberTextBox = new System.Windows.Forms.TextBox();
            this.ipAdress = new System.Windows.Forms.Label();
            this.clearBase = new System.Windows.Forms.Button();
            this.showStatisticButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.Red;
            this.button_start.Location = new System.Drawing.Point(54, 33);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(122, 36);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Start server";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_client
            // 
            this.button_client.BackColor = System.Drawing.Color.Red;
            this.button_client.Location = new System.Drawing.Point(54, 91);
            this.button_client.Name = "button_client";
            this.button_client.Size = new System.Drawing.Size(122, 36);
            this.button_client.TabIndex = 1;
            this.button_client.Text = "Start test client";
            this.button_client.UseVisualStyleBackColor = false;
            this.button_client.Click += new System.EventHandler(this.button_client_Click);
            // 
            // showCharts
            // 
            this.showCharts.Location = new System.Drawing.Point(54, 267);
            this.showCharts.Name = "showCharts";
            this.showCharts.Size = new System.Drawing.Size(122, 25);
            this.showCharts.TabIndex = 4;
            this.showCharts.Text = "Показать графики";
            this.showCharts.UseVisualStyleBackColor = true;
            this.showCharts.Click += new System.EventHandler(this.showCharts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Выбор узла";
            // 
            // nodeNumberTextBox
            // 
            this.nodeNumberTextBox.Location = new System.Drawing.Point(54, 241);
            this.nodeNumberTextBox.Name = "nodeNumberTextBox";
            this.nodeNumberTextBox.Size = new System.Drawing.Size(122, 20);
            this.nodeNumberTextBox.TabIndex = 6;
            // 
            // ipAdress
            // 
            this.ipAdress.AutoSize = true;
            this.ipAdress.Location = new System.Drawing.Point(12, 9);
            this.ipAdress.Name = "ipAdress";
            this.ipAdress.Size = new System.Drawing.Size(0, 13);
            this.ipAdress.TabIndex = 7;
            // 
            // clearBase
            // 
            this.clearBase.Location = new System.Drawing.Point(54, 298);
            this.clearBase.Name = "clearBase";
            this.clearBase.Size = new System.Drawing.Size(122, 25);
            this.clearBase.TabIndex = 8;
            this.clearBase.Text = "Очистить базу";
            this.clearBase.UseVisualStyleBackColor = true;
            this.clearBase.Click += new System.EventHandler(this.clearBase_Click);
            // 
            // showStatisticButton
            // 
            this.showStatisticButton.Location = new System.Drawing.Point(54, 161);
            this.showStatisticButton.Name = "showStatisticButton";
            this.showStatisticButton.Size = new System.Drawing.Size(122, 35);
            this.showStatisticButton.TabIndex = 4;
            this.showStatisticButton.Text = "Показать статистику";
            this.showStatisticButton.UseVisualStyleBackColor = true;
            this.showStatisticButton.Click += new System.EventHandler(this.showStatisticButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 362);
            this.Controls.Add(this.clearBase);
            this.Controls.Add(this.ipAdress);
            this.Controls.Add(this.nodeNumberTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showStatisticButton);
            this.Controls.Add(this.showCharts);
            this.Controls.Add(this.button_client);
            this.Controls.Add(this.button_start);
            this.Name = "Form1";
            this.Text = "MESH-сервер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_client;
        private System.Windows.Forms.Button showCharts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nodeNumberTextBox;
        private System.Windows.Forms.Label ipAdress;
        private System.Windows.Forms.Button clearBase;
        private System.Windows.Forms.Button showStatisticButton;
    }
}

