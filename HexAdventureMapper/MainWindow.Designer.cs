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
            this.btnMoveWest = new System.Windows.Forms.Button();
            this.btnMoveEast = new System.Windows.Forms.Button();
            this.btnMoveNorth = new System.Windows.Forms.Button();
            this.btnMoveSouth = new System.Windows.Forms.Button();
            this.rbSelect = new System.Windows.Forms.RadioButton();
            this.cmbTerrain = new System.Windows.Forms.ComboBox();
            this.cmbVegetation = new System.Windows.Forms.ComboBox();
            this.cmbIcon = new System.Windows.Forms.ComboBox();
            this.rbTerrain = new System.Windows.Forms.RadioButton();
            this.rbIcons = new System.Windows.Forms.RadioButton();
            this.rbRiver = new System.Windows.Forms.RadioButton();
            this.cmbRiver = new System.Windows.Forms.ComboBox();
            this.rdRoad = new System.Windows.Forms.RadioButton();
            this.cmbRoad = new System.Windows.Forms.ComboBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            // btnMoveWest
            // 
            this.btnMoveWest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveWest.Location = new System.Drawing.Point(139, 53);
            this.btnMoveWest.Name = "btnMoveWest";
            this.btnMoveWest.Size = new System.Drawing.Size(30, 491);
            this.btnMoveWest.TabIndex = 13;
            this.btnMoveWest.Text = "<";
            this.btnMoveWest.UseVisualStyleBackColor = true;
            this.btnMoveWest.Click += new System.EventHandler(this.btnMoveWest_Click);
            // 
            // btnMoveEast
            // 
            this.btnMoveEast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveEast.Location = new System.Drawing.Point(627, 53);
            this.btnMoveEast.Name = "btnMoveEast";
            this.btnMoveEast.Size = new System.Drawing.Size(30, 491);
            this.btnMoveEast.TabIndex = 14;
            this.btnMoveEast.Text = ">";
            this.btnMoveEast.UseVisualStyleBackColor = true;
            this.btnMoveEast.Click += new System.EventHandler(this.btnMoveEast_Click);
            // 
            // btnMoveNorth
            // 
            this.btnMoveNorth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveNorth.Location = new System.Drawing.Point(158, 27);
            this.btnMoveNorth.Name = "btnMoveNorth";
            this.btnMoveNorth.Size = new System.Drawing.Size(463, 30);
            this.btnMoveNorth.TabIndex = 15;
            this.btnMoveNorth.Text = "^";
            this.btnMoveNorth.UseVisualStyleBackColor = true;
            this.btnMoveNorth.Click += new System.EventHandler(this.btnMoveNorth_Click);
            // 
            // btnMoveSouth
            // 
            this.btnMoveSouth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveSouth.Location = new System.Drawing.Point(165, 543);
            this.btnMoveSouth.Name = "btnMoveSouth";
            this.btnMoveSouth.Size = new System.Drawing.Size(463, 30);
            this.btnMoveSouth.TabIndex = 16;
            this.btnMoveSouth.Text = "V";
            this.btnMoveSouth.UseVisualStyleBackColor = true;
            this.btnMoveSouth.Click += new System.EventHandler(this.btnMoveSouth_Click);
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
            this.rbSelect.CheckedChanged += new System.EventHandler(this.rbSelect_CheckedChanged);
            // 
            // cmbTerrain
            // 
            this.cmbTerrain.FormattingEnabled = true;
            this.cmbTerrain.Location = new System.Drawing.Point(32, 50);
            this.cmbTerrain.Name = "cmbTerrain";
            this.cmbTerrain.Size = new System.Drawing.Size(101, 21);
            this.cmbTerrain.TabIndex = 2;
            this.cmbTerrain.SelectedIndexChanged += new System.EventHandler(this.cmbTerrain_SelectedIndexChanged);
            // 
            // cmbVegetation
            // 
            this.cmbVegetation.FormattingEnabled = true;
            this.cmbVegetation.Location = new System.Drawing.Point(32, 77);
            this.cmbVegetation.Name = "cmbVegetation";
            this.cmbVegetation.Size = new System.Drawing.Size(101, 21);
            this.cmbVegetation.TabIndex = 3;
            this.cmbVegetation.SelectedIndexChanged += new System.EventHandler(this.cmbVegetation_SelectedIndexChanged);
            // 
            // cmbIcon
            // 
            this.cmbIcon.FormattingEnabled = true;
            this.cmbIcon.Location = new System.Drawing.Point(32, 104);
            this.cmbIcon.Name = "cmbIcon";
            this.cmbIcon.Size = new System.Drawing.Size(101, 21);
            this.cmbIcon.TabIndex = 5;
            this.cmbIcon.SelectedIndexChanged += new System.EventHandler(this.cmbIcon_SelectedIndexChanged);
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
            this.rbTerrain.CheckedChanged += new System.EventHandler(this.rbTerrain_CheckedChanged);
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
            this.rbIcons.CheckedChanged += new System.EventHandler(this.rbIcons_CheckedChanged);
            // 
            // rbRiver
            // 
            this.rbRiver.AutoSize = true;
            this.rbRiver.Location = new System.Drawing.Point(12, 134);
            this.rbRiver.Name = "rbRiver";
            this.rbRiver.Size = new System.Drawing.Size(14, 13);
            this.rbRiver.TabIndex = 8;
            this.rbRiver.TabStop = true;
            this.rbRiver.UseVisualStyleBackColor = true;
            this.rbRiver.CheckedChanged += new System.EventHandler(this.rbRiver_CheckedChanged);
            // 
            // cmbRiver
            // 
            this.cmbRiver.FormattingEnabled = true;
            this.cmbRiver.Location = new System.Drawing.Point(32, 131);
            this.cmbRiver.Name = "cmbRiver";
            this.cmbRiver.Size = new System.Drawing.Size(101, 21);
            this.cmbRiver.TabIndex = 9;
            this.cmbRiver.SelectedIndexChanged += new System.EventHandler(this.cmbRiver_SelectedIndexChanged);
            // 
            // rdRoad
            // 
            this.rdRoad.AutoSize = true;
            this.rdRoad.Location = new System.Drawing.Point(12, 161);
            this.rdRoad.Name = "rdRoad";
            this.rdRoad.Size = new System.Drawing.Size(14, 13);
            this.rdRoad.TabIndex = 10;
            this.rdRoad.TabStop = true;
            this.rdRoad.UseVisualStyleBackColor = true;
            this.rdRoad.CheckedChanged += new System.EventHandler(this.rdRoad_CheckedChanged);
            // 
            // cmbRoad
            // 
            this.cmbRoad.FormattingEnabled = true;
            this.cmbRoad.Location = new System.Drawing.Point(32, 158);
            this.cmbRoad.Name = "cmbRoad";
            this.cmbRoad.Size = new System.Drawing.Size(101, 21);
            this.cmbRoad.TabIndex = 11;
            this.cmbRoad.SelectedIndexChanged += new System.EventHandler(this.cmbRoad_SelectedIndexChanged);
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
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // imgHexMap
            // 
            this.imgHexMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgHexMap.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.Controls.Add(this.imgHexMap);
            this.Controls.Add(this.btnMoveSouth);
            this.Controls.Add(this.btnMoveNorth);
            this.Controls.Add(this.btnMoveEast);
            this.Controls.Add(this.btnMoveWest);
            this.Controls.Add(this.rbSelect);
            this.Controls.Add(this.cmbRoad);
            this.Controls.Add(this.rdRoad);
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
        private System.Windows.Forms.Button btnMoveWest;
        private System.Windows.Forms.Button btnMoveEast;
        private System.Windows.Forms.Button btnMoveNorth;
        private System.Windows.Forms.Button btnMoveSouth;
        private MapBox imgHexMap;
        private System.Windows.Forms.RadioButton rbSelect;
        private System.Windows.Forms.ComboBox cmbTerrain;
        private System.Windows.Forms.ComboBox cmbVegetation;
        private System.Windows.Forms.ComboBox cmbIcon;
        private System.Windows.Forms.RadioButton rbTerrain;
        private System.Windows.Forms.RadioButton rbIcons;
        private System.Windows.Forms.RadioButton rbRiver;
        private System.Windows.Forms.ComboBox cmbRiver;
        private System.Windows.Forms.RadioButton rdRoad;
        private System.Windows.Forms.ComboBox cmbRoad;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

