namespace HexAdventureMapper
{
    partial class PlayerWindow
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
            this.btnMoveSouth3 = new System.Windows.Forms.Button();
            this.btnMoveSouth2 = new System.Windows.Forms.Button();
            this.btnMoveNorth3 = new System.Windows.Forms.Button();
            this.btnMoveNorth2 = new System.Windows.Forms.Button();
            this.btnMoveWest3 = new System.Windows.Forms.Button();
            this.btnMoveWest2 = new System.Windows.Forms.Button();
            this.btnMoveEast3 = new System.Windows.Forms.Button();
            this.btnMoveEast1 = new System.Windows.Forms.Button();
            this.btnMoveSouth1 = new System.Windows.Forms.Button();
            this.btnMoveNorth1 = new System.Windows.Forms.Button();
            this.btnMoveEast2 = new System.Windows.Forms.Button();
            this.btnMoveWest1 = new System.Windows.Forms.Button();
            this.imgLoadingIndicator = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblWeather = new System.Windows.Forms.Label();
            this.imgPlayerMap = new HexAdventureMapper.Views.MapBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadingIndicator)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayerMap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMoveSouth3
            // 
            this.btnMoveSouth3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveSouth3.Location = new System.Drawing.Point(895, 888);
            this.btnMoveSouth3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveSouth3.Name = "btnMoveSouth3";
            this.btnMoveSouth3.Size = new System.Drawing.Size(150, 46);
            this.btnMoveSouth3.TabIndex = 38;
            this.btnMoveSouth3.Text = "VVV";
            this.btnMoveSouth3.UseVisualStyleBackColor = true;
            this.btnMoveSouth3.Click += new System.EventHandler(this.btnMoveSouth3_Click);
            // 
            // btnMoveSouth2
            // 
            this.btnMoveSouth2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveSouth2.Location = new System.Drawing.Point(72, 888);
            this.btnMoveSouth2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveSouth2.Name = "btnMoveSouth2";
            this.btnMoveSouth2.Size = new System.Drawing.Size(150, 46);
            this.btnMoveSouth2.TabIndex = 37;
            this.btnMoveSouth2.Text = "VV";
            this.btnMoveSouth2.UseVisualStyleBackColor = true;
            this.btnMoveSouth2.Click += new System.EventHandler(this.btnMoveSouth2_Click);
            // 
            // btnMoveNorth3
            // 
            this.btnMoveNorth3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveNorth3.Location = new System.Drawing.Point(895, 14);
            this.btnMoveNorth3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveNorth3.Name = "btnMoveNorth3";
            this.btnMoveNorth3.Size = new System.Drawing.Size(150, 46);
            this.btnMoveNorth3.TabIndex = 36;
            this.btnMoveNorth3.Text = "^^^";
            this.btnMoveNorth3.UseVisualStyleBackColor = true;
            this.btnMoveNorth3.Click += new System.EventHandler(this.btnMoveNorth3_Click);
            // 
            // btnMoveNorth2
            // 
            this.btnMoveNorth2.Location = new System.Drawing.Point(72, 15);
            this.btnMoveNorth2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveNorth2.Name = "btnMoveNorth2";
            this.btnMoveNorth2.Size = new System.Drawing.Size(150, 46);
            this.btnMoveNorth2.TabIndex = 35;
            this.btnMoveNorth2.Text = "^^";
            this.btnMoveNorth2.UseVisualStyleBackColor = true;
            this.btnMoveNorth2.Click += new System.EventHandler(this.btnMoveNorth2_Click);
            // 
            // btnMoveWest3
            // 
            this.btnMoveWest3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveWest3.Location = new System.Drawing.Point(18, 725);
            this.btnMoveWest3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveWest3.Name = "btnMoveWest3";
            this.btnMoveWest3.Size = new System.Drawing.Size(45, 154);
            this.btnMoveWest3.TabIndex = 34;
            this.btnMoveWest3.Text = "<\r\n<\r\n<";
            this.btnMoveWest3.UseVisualStyleBackColor = true;
            this.btnMoveWest3.Click += new System.EventHandler(this.btnMoveWest3_Click);
            // 
            // btnMoveWest2
            // 
            this.btnMoveWest2.Location = new System.Drawing.Point(18, 71);
            this.btnMoveWest2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveWest2.Name = "btnMoveWest2";
            this.btnMoveWest2.Size = new System.Drawing.Size(45, 154);
            this.btnMoveWest2.TabIndex = 33;
            this.btnMoveWest2.Text = "<\r\n<";
            this.btnMoveWest2.UseVisualStyleBackColor = true;
            this.btnMoveWest2.Click += new System.EventHandler(this.btnMoveWest2_Click);
            // 
            // btnMoveEast3
            // 
            this.btnMoveEast3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveEast3.Location = new System.Drawing.Point(1053, 725);
            this.btnMoveEast3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveEast3.Name = "btnMoveEast3";
            this.btnMoveEast3.Size = new System.Drawing.Size(45, 154);
            this.btnMoveEast3.TabIndex = 32;
            this.btnMoveEast3.Text = ">\r\n>\r\n>";
            this.btnMoveEast3.UseVisualStyleBackColor = true;
            this.btnMoveEast3.Click += new System.EventHandler(this.btnMoveEast3_Click);
            // 
            // btnMoveEast1
            // 
            this.btnMoveEast1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveEast1.Location = new System.Drawing.Point(1053, 234);
            this.btnMoveEast1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveEast1.Name = "btnMoveEast1";
            this.btnMoveEast1.Size = new System.Drawing.Size(45, 482);
            this.btnMoveEast1.TabIndex = 31;
            this.btnMoveEast1.Text = ">";
            this.btnMoveEast1.UseVisualStyleBackColor = true;
            this.btnMoveEast1.Click += new System.EventHandler(this.btnMoveEast1_Click);
            // 
            // btnMoveSouth1
            // 
            this.btnMoveSouth1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveSouth1.Location = new System.Drawing.Point(231, 888);
            this.btnMoveSouth1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveSouth1.Name = "btnMoveSouth1";
            this.btnMoveSouth1.Size = new System.Drawing.Size(656, 46);
            this.btnMoveSouth1.TabIndex = 30;
            this.btnMoveSouth1.Text = "V";
            this.btnMoveSouth1.UseVisualStyleBackColor = true;
            this.btnMoveSouth1.Click += new System.EventHandler(this.btnMoveSouth1_Click);
            // 
            // btnMoveNorth1
            // 
            this.btnMoveNorth1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveNorth1.Location = new System.Drawing.Point(231, 15);
            this.btnMoveNorth1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveNorth1.Name = "btnMoveNorth1";
            this.btnMoveNorth1.Size = new System.Drawing.Size(656, 46);
            this.btnMoveNorth1.TabIndex = 29;
            this.btnMoveNorth1.Text = "^";
            this.btnMoveNorth1.UseVisualStyleBackColor = true;
            this.btnMoveNorth1.Click += new System.EventHandler(this.btnMoveNorth1_Click);
            // 
            // btnMoveEast2
            // 
            this.btnMoveEast2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveEast2.Location = new System.Drawing.Point(1053, 71);
            this.btnMoveEast2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveEast2.Name = "btnMoveEast2";
            this.btnMoveEast2.Size = new System.Drawing.Size(45, 154);
            this.btnMoveEast2.TabIndex = 28;
            this.btnMoveEast2.Text = ">\r\n>";
            this.btnMoveEast2.UseVisualStyleBackColor = true;
            this.btnMoveEast2.Click += new System.EventHandler(this.btnMoveEast2_Click);
            // 
            // btnMoveWest1
            // 
            this.btnMoveWest1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveWest1.Location = new System.Drawing.Point(18, 234);
            this.btnMoveWest1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveWest1.Name = "btnMoveWest1";
            this.btnMoveWest1.Size = new System.Drawing.Size(45, 482);
            this.btnMoveWest1.TabIndex = 27;
            this.btnMoveWest1.Text = "<";
            this.btnMoveWest1.UseVisualStyleBackColor = true;
            this.btnMoveWest1.Click += new System.EventHandler(this.btnMoveWest1_Click);
            // 
            // imgLoadingIndicator
            // 
            this.imgLoadingIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLoadingIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.imgLoadingIndicator.Image = global::HexAdventureMapper.Properties.Resources.LoadingIndicator;
            this.imgLoadingIndicator.Location = new System.Drawing.Point(1053, 15);
            this.imgLoadingIndicator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imgLoadingIndicator.Name = "imgLoadingIndicator";
            this.imgLoadingIndicator.Size = new System.Drawing.Size(45, 46);
            this.imgLoadingIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLoadingIndicator.TabIndex = 40;
            this.imgLoadingIndicator.TabStop = false;
            this.imgLoadingIndicator.UseWaitCursor = true;
            this.imgLoadingIndicator.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblWeather);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Location = new System.Drawing.Point(1105, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 925);
            this.panel1.TabIndex = 41;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 12);
            this.lblDate.MaximumSize = new System.Drawing.Size(219, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(51, 20);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "label1";
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.Location = new System.Drawing.Point(12, 89);
            this.lblWeather.MaximumSize = new System.Drawing.Size(219, 0);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(51, 20);
            this.lblWeather.TabIndex = 1;
            this.lblWeather.Text = "label1";
            // 
            // imgPlayerMap
            // 
            this.imgPlayerMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgPlayerMap.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.imgPlayerMap.Location = new System.Drawing.Point(72, 71);
            this.imgPlayerMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imgPlayerMap.Name = "imgPlayerMap";
            this.imgPlayerMap.Size = new System.Drawing.Size(973, 808);
            this.imgPlayerMap.TabIndex = 26;
            this.imgPlayerMap.TabStop = false;
            this.imgPlayerMap.MapClick += new HexAdventureMapper.Views.MapEventHandler(this.imgPlayerMap_Click);
            // 
            // PlayerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 952);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.imgLoadingIndicator);
            this.Controls.Add(this.btnMoveSouth3);
            this.Controls.Add(this.btnMoveSouth2);
            this.Controls.Add(this.btnMoveNorth3);
            this.Controls.Add(this.btnMoveNorth2);
            this.Controls.Add(this.btnMoveWest3);
            this.Controls.Add(this.btnMoveWest2);
            this.Controls.Add(this.btnMoveEast3);
            this.Controls.Add(this.btnMoveEast1);
            this.Controls.Add(this.imgPlayerMap);
            this.Controls.Add(this.btnMoveSouth1);
            this.Controls.Add(this.btnMoveNorth1);
            this.Controls.Add(this.btnMoveEast2);
            this.Controls.Add(this.btnMoveWest1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PlayerWindow";
            this.Text = "PlayerWindow";
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadingIndicator)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayerMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMoveSouth3;
        private System.Windows.Forms.Button btnMoveSouth2;
        private System.Windows.Forms.Button btnMoveNorth3;
        private System.Windows.Forms.Button btnMoveNorth2;
        private System.Windows.Forms.Button btnMoveWest3;
        private System.Windows.Forms.Button btnMoveWest2;
        private System.Windows.Forms.Button btnMoveEast3;
        private System.Windows.Forms.Button btnMoveEast1;
        private Views.MapBox imgPlayerMap;
        private System.Windows.Forms.Button btnMoveSouth1;
        private System.Windows.Forms.Button btnMoveNorth1;
        private System.Windows.Forms.Button btnMoveEast2;
        private System.Windows.Forms.Button btnMoveWest1;
        private System.Windows.Forms.PictureBox imgLoadingIndicator;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.Label lblDate;
    }
}