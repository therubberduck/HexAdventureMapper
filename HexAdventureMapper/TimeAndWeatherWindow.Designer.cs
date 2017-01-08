namespace HexAdventureMapper
{
    partial class TimeAndWeatherWindow
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
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.btnSubtractTime = new System.Windows.Forms.Button();
            this.txtTimeValueHours = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimeValueMinutes = new System.Windows.Forms.TextBox();
            this.chkAutoUpdateTime = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimeValueDays = new System.Windows.Forms.TextBox();
            this.lblCurrentYear = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClearTimes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Time:";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Location = new System.Drawing.Point(123, 83);
            this.lblCurrentTime.MaximumSize = new System.Drawing.Size(224, 0);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(51, 20);
            this.lblCurrentTime.TabIndex = 1;
            this.lblCurrentTime.Text = "label2";
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(17, 278);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(32, 30);
            this.btnAddTime.TabIndex = 2;
            this.btnAddTime.Text = "+";
            this.btnAddTime.UseVisualStyleBackColor = true;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // btnSubtractTime
            // 
            this.btnSubtractTime.Location = new System.Drawing.Point(55, 278);
            this.btnSubtractTime.Name = "btnSubtractTime";
            this.btnSubtractTime.Size = new System.Drawing.Size(32, 30);
            this.btnSubtractTime.TabIndex = 3;
            this.btnSubtractTime.Text = "-";
            this.btnSubtractTime.UseVisualStyleBackColor = true;
            this.btnSubtractTime.Click += new System.EventHandler(this.btnSubtractTime_Click);
            // 
            // txtTimeValueHours
            // 
            this.txtTimeValueHours.Location = new System.Drawing.Point(18, 195);
            this.txtTimeValueHours.Name = "txtTimeValueHours";
            this.txtTimeValueHours.Size = new System.Drawing.Size(61, 26);
            this.txtTimeValueHours.TabIndex = 4;
            this.txtTimeValueHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "hours";
            this.label2.Click += new System.EventHandler(this.lblHours_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "minutes";
            this.label3.Click += new System.EventHandler(this.lblMinutes_Click);
            // 
            // txtTimeValueMinutes
            // 
            this.txtTimeValueMinutes.Location = new System.Drawing.Point(18, 232);
            this.txtTimeValueMinutes.Name = "txtTimeValueMinutes";
            this.txtTimeValueMinutes.Size = new System.Drawing.Size(61, 26);
            this.txtTimeValueMinutes.TabIndex = 6;
            this.txtTimeValueMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
            // 
            // chkAutoUpdateTime
            // 
            this.chkAutoUpdateTime.AutoSize = true;
            this.chkAutoUpdateTime.Location = new System.Drawing.Point(174, 284);
            this.chkAutoUpdateTime.Name = "chkAutoUpdateTime";
            this.chkAutoUpdateTime.Size = new System.Drawing.Size(161, 24);
            this.chkAutoUpdateTime.TabIndex = 8;
            this.chkAutoUpdateTime.Text = "Auto-Update time";
            this.chkAutoUpdateTime.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Current Date:";
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Location = new System.Drawing.Point(123, 51);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(51, 20);
            this.lblCurrentDate.TabIndex = 10;
            this.lblCurrentDate.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "days";
            this.label5.Click += new System.EventHandler(this.lblDays_Click);
            // 
            // txtTimeValueDays
            // 
            this.txtTimeValueDays.Location = new System.Drawing.Point(17, 160);
            this.txtTimeValueDays.Name = "txtTimeValueDays";
            this.txtTimeValueDays.Size = new System.Drawing.Size(61, 26);
            this.txtTimeValueDays.TabIndex = 11;
            this.txtTimeValueDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
            // 
            // lblCurrentYear
            // 
            this.lblCurrentYear.AutoSize = true;
            this.lblCurrentYear.Location = new System.Drawing.Point(122, 18);
            this.lblCurrentYear.Name = "lblCurrentYear";
            this.lblCurrentYear.Size = new System.Drawing.Size(51, 20);
            this.lblCurrentYear.TabIndex = 14;
            this.lblCurrentYear.Text = "label5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Current Year:";
            // 
            // btnClearTimes
            // 
            this.btnClearTimes.Location = new System.Drawing.Point(95, 278);
            this.btnClearTimes.Name = "btnClearTimes";
            this.btnClearTimes.Size = new System.Drawing.Size(55, 30);
            this.btnClearTimes.TabIndex = 15;
            this.btnClearTimes.Text = "Clear";
            this.btnClearTimes.UseVisualStyleBackColor = true;
            this.btnClearTimes.Click += new System.EventHandler(this.btnClearTimes_Click);
            // 
            // TimeAndWeatherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 406);
            this.Controls.Add(this.btnClearTimes);
            this.Controls.Add(this.lblCurrentYear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTimeValueDays);
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAutoUpdateTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTimeValueMinutes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTimeValueHours);
            this.Controls.Add(this.btnSubtractTime);
            this.Controls.Add(this.btnAddTime);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.label1);
            this.Name = "TimeAndWeatherWindow";
            this.Text = "TimeAndWeatherWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.Button btnSubtractTime;
        private System.Windows.Forms.TextBox txtTimeValueHours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimeValueMinutes;
        private System.Windows.Forms.CheckBox chkAutoUpdateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimeValueDays;
        private System.Windows.Forms.Label lblCurrentYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClearTimes;
    }
}