using HexAdventureMapper.Views;

namespace HexAdventureMapper
{
    partial class MainWindow
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
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.btnMoveWest1 = new System.Windows.Forms.Button();
            this.btnMoveEast2 = new System.Windows.Forms.Button();
            this.btnMoveNorth1 = new System.Windows.Forms.Button();
            this.btnMoveSouth1 = new System.Windows.Forms.Button();
            this.rbSelect = new System.Windows.Forms.RadioButton();
            this.cmbTerrain = new System.Windows.Forms.ComboBox();
            this.cmbVegetation = new System.Windows.Forms.ComboBox();
            this.cmbIcon = new System.Windows.Forms.ComboBox();
            this.rbTerrain = new System.Windows.Forms.RadioButton();
            this.rbIcons = new System.Windows.Forms.RadioButton();
            this.rbRiver = new System.Windows.Forms.RadioButton();
            this.cmbRiver = new System.Windows.Forms.ComboBox();
            this.rbRoad = new System.Windows.Forms.RadioButton();
            this.cmbRoad = new System.Windows.Forms.ComboBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMoveEast1 = new System.Windows.Forms.Button();
            this.btnMoveEast3 = new System.Windows.Forms.Button();
            this.btnMoveWest2 = new System.Windows.Forms.Button();
            this.btnMoveWest3 = new System.Windows.Forms.Button();
            this.btnMoveNorth2 = new System.Windows.Forms.Button();
            this.btnMoveNorth3 = new System.Windows.Forms.Button();
            this.btnMoveSouth2 = new System.Windows.Forms.Button();
            this.btnMoveSouth3 = new System.Windows.Forms.Button();
            this.rbPlayerIcon = new System.Windows.Forms.RadioButton();
            this.cmbPlayerIcon = new System.Windows.Forms.ComboBox();
            this.imgHexMap = new HexAdventureMapper.Views.MapBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgHexMap)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDetail
            // 
            this.txtDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetail.Location = new System.Drawing.Point(663, 27);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(210, 546);
            this.txtDetail.TabIndex = 1;
            this.txtDetail.TextChanged += new System.EventHandler(this.txtDetail_TextChanged);
            // 
            // btnMoveWest1
            // 
            this.btnMoveWest1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveWest1.Location = new System.Drawing.Point(139, 169);
            this.btnMoveWest1.Name = "btnMoveWest1";
            this.btnMoveWest1.Size = new System.Drawing.Size(30, 262);
            this.btnMoveWest1.TabIndex = 13;
            this.btnMoveWest1.Text = "<";
            this.btnMoveWest1.UseVisualStyleBackColor = true;
            this.btnMoveWest1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveWest1_MouseClick);
            // 
            // btnMoveEast2
            // 
            this.btnMoveEast2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveEast2.Location = new System.Drawing.Point(627, 63);
            this.btnMoveEast2.Name = "btnMoveEast2";
            this.btnMoveEast2.Size = new System.Drawing.Size(30, 100);
            this.btnMoveEast2.TabIndex = 14;
            this.btnMoveEast2.Text = ">\r\n>";
            this.btnMoveEast2.UseVisualStyleBackColor = true;
            this.btnMoveEast2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveEast2_MouseClick);
            // 
            // btnMoveNorth1
            // 
            this.btnMoveNorth1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveNorth1.Location = new System.Drawing.Point(281, 27);
            this.btnMoveNorth1.Name = "btnMoveNorth1";
            this.btnMoveNorth1.Size = new System.Drawing.Size(234, 30);
            this.btnMoveNorth1.TabIndex = 15;
            this.btnMoveNorth1.Text = "^";
            this.btnMoveNorth1.UseVisualStyleBackColor = true;
            this.btnMoveNorth1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveNorth1_MouseClick);
            // 
            // btnMoveSouth1
            // 
            this.btnMoveSouth1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveSouth1.Location = new System.Drawing.Point(281, 543);
            this.btnMoveSouth1.Name = "btnMoveSouth1";
            this.btnMoveSouth1.Size = new System.Drawing.Size(234, 30);
            this.btnMoveSouth1.TabIndex = 16;
            this.btnMoveSouth1.Text = "V";
            this.btnMoveSouth1.UseVisualStyleBackColor = true;
            this.btnMoveSouth1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveSouth1_MouseClick);
            // 
            // rbSelect
            // 
            this.rbSelect.AutoSize = true;
            this.rbSelect.Location = new System.Drawing.Point(12, 27);
            this.rbSelect.Name = "rbSelect";
            this.rbSelect.Size = new System.Drawing.Size(55, 17);
            this.rbSelect.TabIndex = 12;
            this.rbSelect.TabStop = true;
            this.rbSelect.Text = "Select";
            this.rbSelect.UseVisualStyleBackColor = true;
            this.rbSelect.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cmbTerrain
            // 
            this.cmbTerrain.FormattingEnabled = true;
            this.cmbTerrain.Location = new System.Drawing.Point(32, 50);
            this.cmbTerrain.Name = "cmbTerrain";
            this.cmbTerrain.Size = new System.Drawing.Size(101, 21);
            this.cmbTerrain.TabIndex = 2;
            this.cmbTerrain.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbTerrain.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // cmbVegetation
            // 
            this.cmbVegetation.FormattingEnabled = true;
            this.cmbVegetation.Location = new System.Drawing.Point(32, 77);
            this.cmbVegetation.Name = "cmbVegetation";
            this.cmbVegetation.Size = new System.Drawing.Size(101, 21);
            this.cmbVegetation.TabIndex = 3;
            this.cmbVegetation.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbVegetation.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // cmbIcon
            // 
            this.cmbIcon.FormattingEnabled = true;
            this.cmbIcon.Location = new System.Drawing.Point(32, 104);
            this.cmbIcon.Name = "cmbIcon";
            this.cmbIcon.Size = new System.Drawing.Size(101, 21);
            this.cmbIcon.TabIndex = 5;
            this.cmbIcon.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbIcon.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // rbTerrain
            // 
            this.rbTerrain.AutoSize = true;
            this.rbTerrain.Location = new System.Drawing.Point(12, 53);
            this.rbTerrain.Name = "rbTerrain";
            this.rbTerrain.Size = new System.Drawing.Size(14, 13);
            this.rbTerrain.TabIndex = 6;
            this.rbTerrain.TabStop = true;
            this.rbTerrain.UseVisualStyleBackColor = true;
            this.rbTerrain.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbIcons
            // 
            this.rbIcons.AutoSize = true;
            this.rbIcons.Location = new System.Drawing.Point(12, 107);
            this.rbIcons.Name = "rbIcons";
            this.rbIcons.Size = new System.Drawing.Size(14, 13);
            this.rbIcons.TabIndex = 7;
            this.rbIcons.TabStop = true;
            this.rbIcons.UseVisualStyleBackColor = true;
            this.rbIcons.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbRiver
            // 
            this.rbRiver.AutoSize = true;
            this.rbRiver.Location = new System.Drawing.Point(12, 161);
            this.rbRiver.Name = "rbRiver";
            this.rbRiver.Size = new System.Drawing.Size(14, 13);
            this.rbRiver.TabIndex = 8;
            this.rbRiver.TabStop = true;
            this.rbRiver.UseVisualStyleBackColor = true;
            this.rbRiver.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cmbRiver
            // 
            this.cmbRiver.FormattingEnabled = true;
            this.cmbRiver.Location = new System.Drawing.Point(32, 158);
            this.cmbRiver.Name = "cmbRiver";
            this.cmbRiver.Size = new System.Drawing.Size(101, 21);
            this.cmbRiver.TabIndex = 9;
            this.cmbRiver.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbRiver.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // rbRoad
            // 
            this.rbRoad.AutoSize = true;
            this.rbRoad.Location = new System.Drawing.Point(12, 188);
            this.rbRoad.Name = "rbRoad";
            this.rbRoad.Size = new System.Drawing.Size(14, 13);
            this.rbRoad.TabIndex = 10;
            this.rbRoad.TabStop = true;
            this.rbRoad.UseVisualStyleBackColor = true;
            this.rbRoad.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cmbRoad
            // 
            this.cmbRoad.FormattingEnabled = true;
            this.cmbRoad.Location = new System.Drawing.Point(32, 185);
            this.cmbRoad.Name = "cmbRoad";
            this.cmbRoad.Size = new System.Drawing.Size(101, 21);
            this.cmbRoad.TabIndex = 11;
            this.cmbRoad.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbRoad.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(885, 24);
            this.menuStrip.TabIndex = 17;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnMoveEast1
            // 
            this.btnMoveEast1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveEast1.Location = new System.Drawing.Point(627, 169);
            this.btnMoveEast1.Name = "btnMoveEast1";
            this.btnMoveEast1.Size = new System.Drawing.Size(30, 262);
            this.btnMoveEast1.TabIndex = 18;
            this.btnMoveEast1.Text = ">";
            this.btnMoveEast1.UseVisualStyleBackColor = true;
            this.btnMoveEast1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveEast1_MouseClick);
            // 
            // btnMoveEast3
            // 
            this.btnMoveEast3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveEast3.Location = new System.Drawing.Point(627, 437);
            this.btnMoveEast3.Name = "btnMoveEast3";
            this.btnMoveEast3.Size = new System.Drawing.Size(30, 100);
            this.btnMoveEast3.TabIndex = 19;
            this.btnMoveEast3.Text = ">\r\n>\r\n>";
            this.btnMoveEast3.UseVisualStyleBackColor = true;
            this.btnMoveEast3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveEast3_MouseClick);
            // 
            // btnMoveWest2
            // 
            this.btnMoveWest2.Location = new System.Drawing.Point(139, 63);
            this.btnMoveWest2.Name = "btnMoveWest2";
            this.btnMoveWest2.Size = new System.Drawing.Size(30, 100);
            this.btnMoveWest2.TabIndex = 20;
            this.btnMoveWest2.Text = "<\r\n<";
            this.btnMoveWest2.UseVisualStyleBackColor = true;
            this.btnMoveWest2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveWest2_MouseClick);
            // 
            // btnMoveWest3
            // 
            this.btnMoveWest3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveWest3.Location = new System.Drawing.Point(139, 437);
            this.btnMoveWest3.Name = "btnMoveWest3";
            this.btnMoveWest3.Size = new System.Drawing.Size(30, 100);
            this.btnMoveWest3.TabIndex = 21;
            this.btnMoveWest3.Text = "<\r\n<\r\n<";
            this.btnMoveWest3.UseVisualStyleBackColor = true;
            this.btnMoveWest3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveWest3_MouseClick);
            // 
            // btnMoveNorth2
            // 
            this.btnMoveNorth2.Location = new System.Drawing.Point(175, 27);
            this.btnMoveNorth2.Name = "btnMoveNorth2";
            this.btnMoveNorth2.Size = new System.Drawing.Size(100, 30);
            this.btnMoveNorth2.TabIndex = 22;
            this.btnMoveNorth2.Text = "^^";
            this.btnMoveNorth2.UseVisualStyleBackColor = true;
            this.btnMoveNorth2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveNorth2_MouseClick);
            // 
            // btnMoveNorth3
            // 
            this.btnMoveNorth3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveNorth3.Location = new System.Drawing.Point(521, 27);
            this.btnMoveNorth3.Name = "btnMoveNorth3";
            this.btnMoveNorth3.Size = new System.Drawing.Size(100, 30);
            this.btnMoveNorth3.TabIndex = 23;
            this.btnMoveNorth3.Text = "^^^";
            this.btnMoveNorth3.UseVisualStyleBackColor = true;
            this.btnMoveNorth3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveNorth3_MouseClick);
            // 
            // btnMoveSouth2
            // 
            this.btnMoveSouth2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveSouth2.Location = new System.Drawing.Point(175, 543);
            this.btnMoveSouth2.Name = "btnMoveSouth2";
            this.btnMoveSouth2.Size = new System.Drawing.Size(100, 30);
            this.btnMoveSouth2.TabIndex = 24;
            this.btnMoveSouth2.Text = "VV";
            this.btnMoveSouth2.UseVisualStyleBackColor = true;
            this.btnMoveSouth2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveSouth2_MouseClick);
            // 
            // btnMoveSouth3
            // 
            this.btnMoveSouth3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveSouth3.Location = new System.Drawing.Point(521, 543);
            this.btnMoveSouth3.Name = "btnMoveSouth3";
            this.btnMoveSouth3.Size = new System.Drawing.Size(100, 30);
            this.btnMoveSouth3.TabIndex = 25;
            this.btnMoveSouth3.Text = "VVV";
            this.btnMoveSouth3.UseVisualStyleBackColor = true;
            this.btnMoveSouth3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveSouth3_MouseClick);
            // 
            // rbPlayerIcon
            // 
            this.rbPlayerIcon.AutoSize = true;
            this.rbPlayerIcon.Location = new System.Drawing.Point(12, 134);
            this.rbPlayerIcon.Name = "rbPlayerIcon";
            this.rbPlayerIcon.Size = new System.Drawing.Size(14, 13);
            this.rbPlayerIcon.TabIndex = 27;
            this.rbPlayerIcon.TabStop = true;
            this.rbPlayerIcon.UseVisualStyleBackColor = true;
            this.rbPlayerIcon.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cmbPlayerIcon
            // 
            this.cmbPlayerIcon.FormattingEnabled = true;
            this.cmbPlayerIcon.Location = new System.Drawing.Point(32, 131);
            this.cmbPlayerIcon.Name = "cmbPlayerIcon";
            this.cmbPlayerIcon.Size = new System.Drawing.Size(101, 21);
            this.cmbPlayerIcon.TabIndex = 26;
            this.cmbPlayerIcon.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbPlayerIcon.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // imgHexMap
            // 
            this.imgHexMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgHexMap.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.imgHexMap.Location = new System.Drawing.Point(175, 63);
            this.imgHexMap.Name = "imgHexMap";
            this.imgHexMap.Size = new System.Drawing.Size(446, 474);
            this.imgHexMap.TabIndex = 4;
            this.imgHexMap.TabStop = false;
            this.imgHexMap.SizeChanged += new System.EventHandler(this.imgHexMap_SizeChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 585);
            this.Controls.Add(this.rbPlayerIcon);
            this.Controls.Add(this.cmbPlayerIcon);
            this.Controls.Add(this.btnMoveSouth3);
            this.Controls.Add(this.btnMoveSouth2);
            this.Controls.Add(this.btnMoveNorth3);
            this.Controls.Add(this.btnMoveNorth2);
            this.Controls.Add(this.btnMoveWest3);
            this.Controls.Add(this.btnMoveWest2);
            this.Controls.Add(this.btnMoveEast3);
            this.Controls.Add(this.btnMoveEast1);
            this.Controls.Add(this.imgHexMap);
            this.Controls.Add(this.btnMoveSouth1);
            this.Controls.Add(this.btnMoveNorth1);
            this.Controls.Add(this.btnMoveEast2);
            this.Controls.Add(this.btnMoveWest1);
            this.Controls.Add(this.rbSelect);
            this.Controls.Add(this.cmbRoad);
            this.Controls.Add(this.rbRoad);
            this.Controls.Add(this.cmbRiver);
            this.Controls.Add(this.rbRiver);
            this.Controls.Add(this.rbIcons);
            this.Controls.Add(this.rbTerrain);
            this.Controls.Add(this.cmbIcon);
            this.Controls.Add(this.cmbVegetation);
            this.Controls.Add(this.cmbTerrain);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.menuStrip);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainWindow";
            this.Text = "Hex Adventure Mapper";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgHexMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Button btnMoveWest1;
        private System.Windows.Forms.Button btnMoveEast2;
        private System.Windows.Forms.Button btnMoveNorth1;
        private System.Windows.Forms.Button btnMoveSouth1;
        private MapBox imgHexMap;
        private System.Windows.Forms.RadioButton rbSelect;
        private System.Windows.Forms.ComboBox cmbTerrain;
        private System.Windows.Forms.ComboBox cmbVegetation;
        private System.Windows.Forms.ComboBox cmbIcon;
        private System.Windows.Forms.RadioButton rbTerrain;
        private System.Windows.Forms.RadioButton rbIcons;
        private System.Windows.Forms.RadioButton rbRiver;
        private System.Windows.Forms.ComboBox cmbRiver;
        private System.Windows.Forms.RadioButton rbRoad;
        private System.Windows.Forms.ComboBox cmbRoad;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Button btnMoveEast1;
        private System.Windows.Forms.Button btnMoveEast3;
        private System.Windows.Forms.Button btnMoveWest2;
        private System.Windows.Forms.Button btnMoveWest3;
        private System.Windows.Forms.Button btnMoveNorth2;
        private System.Windows.Forms.Button btnMoveNorth3;
        private System.Windows.Forms.Button btnMoveSouth2;
        private System.Windows.Forms.Button btnMoveSouth3;
        private System.Windows.Forms.RadioButton rbPlayerIcon;
        private System.Windows.Forms.ComboBox cmbPlayerIcon;
    }
}

