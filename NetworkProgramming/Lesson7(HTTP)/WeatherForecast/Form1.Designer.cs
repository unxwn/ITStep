namespace WeatherForecast
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLatitude = new System.Windows.Forms.TextBox();
            this.textBoxLongitude = new System.Windows.Forms.TextBox();
            this.btnGetForecast = new System.Windows.Forms.Button();
            this.textBoxAddress = new System.Windows.Forms.Label();
            this.weatherChart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitude:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Longitude:";
            // 
            // textBoxLatitude
            // 
            this.textBoxLatitude.Location = new System.Drawing.Point(82, 19);
            this.textBoxLatitude.Name = "textBoxLatitude";
            this.textBoxLatitude.Size = new System.Drawing.Size(67, 20);
            this.textBoxLatitude.TabIndex = 2;
            // 
            // textBoxLongitude
            // 
            this.textBoxLongitude.Location = new System.Drawing.Point(248, 19);
            this.textBoxLongitude.Name = "textBoxLongitude";
            this.textBoxLongitude.Size = new System.Drawing.Size(67, 20);
            this.textBoxLongitude.TabIndex = 3;
            // 
            // btnGetForecast
            // 
            this.btnGetForecast.Location = new System.Drawing.Point(348, 17);
            this.btnGetForecast.Name = "btnGetForecast";
            this.btnGetForecast.Size = new System.Drawing.Size(75, 23);
            this.btnGetForecast.TabIndex = 4;
            this.btnGetForecast.Text = "Get forecast";
            this.btnGetForecast.UseVisualStyleBackColor = true;
            this.btnGetForecast.Click += new System.EventHandler(this.btnGetForecast_Click);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.AutoSize = true;
            this.textBoxAddress.Enabled = false;
            this.textBoxAddress.Location = new System.Drawing.Point(28, 52);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(48, 13);
            this.textBoxAddress.TabIndex = 6;
            this.textBoxAddress.Text = "Address:";
            // 
            // weatherChart
            // 
            this.weatherChart.Location = new System.Drawing.Point(12, 81);
            this.weatherChart.Name = "weatherChart";
            this.weatherChart.Size = new System.Drawing.Size(776, 357);
            this.weatherChart.TabIndex = 7;
            this.weatherChart.Text = "weatherChart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.weatherChart);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.btnGetForecast);
            this.Controls.Add(this.textBoxLongitude);
            this.Controls.Add(this.textBoxLatitude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "YaTebeLyublyu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLatitude;
        private System.Windows.Forms.TextBox textBoxLongitude;
        private System.Windows.Forms.Button btnGetForecast;
        private System.Windows.Forms.Label textBoxAddress;
        private LiveCharts.WinForms.CartesianChart weatherChart;
    }
}

