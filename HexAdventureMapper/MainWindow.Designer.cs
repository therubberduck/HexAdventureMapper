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
            this.txtDetail = new RichTextBoxLinks.RichTextBoxEx();
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
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeAndWeatherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageAttributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weatherImagesDesignedByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sunAndMoonImageDesignedByFreepikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label1 = new System.Windows.Forms.Label();
            this.chk100GmIcons = new System.Windows.Forms.CheckBox();
            this.chk100PlayerIcons = new System.Windows.Forms.CheckBox();
            this.chk100FogOfWar = new System.Windows.Forms.CheckBox();
            this.chk50GmIcons = new System.Windows.Forms.CheckBox();
            this.chk50PlayerIcons = new System.Windows.Forms.CheckBox();
            this.chk50FogOfWar = new System.Windows.Forms.CheckBox();
            this.cmbFogOfWar = new System.Windows.Forms.ComboBox();
            this.rbFogOfWar = new System.Windows.Forms.RadioButton();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.chkOverlayGrid = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.imgLoadingIndicator = new System.Windows.Forms.PictureBox();
            this.imgLoading = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnGoto = new System.Windows.Forms.Button();
            this.imgHexMap = new HexAdventureMapper.Views.MapBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadingIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHexMap)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDetail
            // 
            this.txtDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetail.Location = new System.Drawing.Point(994, 42);
            this.txtDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(313, 813);
            this.txtDetail.TabIndex = 1;
            this.txtDetail.Text = "";
            this.txtDetail.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtDetail_LinkClicked);
            this.txtDetail.TextChanged += new System.EventHandler(this.txtDetail_TextChanged);
            // 
            // btnMoveWest1
            // 
            this.btnMoveWest1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveWest1.Location = new System.Drawing.Point(208, 260);
            this.btnMoveWest1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveWest1.Name = "btnMoveWest1";
            this.btnMoveWest1.Size = new System.Drawing.Size(45, 403);
            this.btnMoveWest1.TabIndex = 13;
            this.btnMoveWest1.Text = "<";
            this.btnMoveWest1.UseVisualStyleBackColor = true;
            this.btnMoveWest1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveWest1_MouseClick);
            // 
            // btnMoveEast2
            // 
            this.btnMoveEast2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveEast2.Location = new System.Drawing.Point(940, 97);
            this.btnMoveEast2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveEast2.Name = "btnMoveEast2";
            this.btnMoveEast2.Size = new System.Drawing.Size(45, 154);
            this.btnMoveEast2.TabIndex = 14;
            this.btnMoveEast2.Text = ">\r\n>";
            this.btnMoveEast2.UseVisualStyleBackColor = true;
            this.btnMoveEast2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveEast2_MouseClick);
            // 
            // btnMoveNorth1
            // 
            this.btnMoveNorth1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveNorth1.Location = new System.Drawing.Point(422, 42);
            this.btnMoveNorth1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveNorth1.Name = "btnMoveNorth1";
            this.btnMoveNorth1.Size = new System.Drawing.Size(351, 46);
            this.btnMoveNorth1.TabIndex = 15;
            this.btnMoveNorth1.Text = "^";
            this.btnMoveNorth1.UseVisualStyleBackColor = true;
            this.btnMoveNorth1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveNorth1_MouseClick);
            // 
            // btnMoveSouth1
            // 
            this.btnMoveSouth1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveSouth1.Location = new System.Drawing.Point(422, 835);
            this.btnMoveSouth1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveSouth1.Name = "btnMoveSouth1";
            this.btnMoveSouth1.Size = new System.Drawing.Size(351, 46);
            this.btnMoveSouth1.TabIndex = 16;
            this.btnMoveSouth1.Text = "V";
            this.btnMoveSouth1.UseVisualStyleBackColor = true;
            this.btnMoveSouth1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveSouth1_MouseClick);
            // 
            // rbSelect
            // 
            this.rbSelect.AutoSize = true;
            this.rbSelect.Location = new System.Drawing.Point(18, 42);
            this.rbSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbSelect.Name = "rbSelect";
            this.rbSelect.Size = new System.Drawing.Size(79, 24);
            this.rbSelect.TabIndex = 12;
            this.rbSelect.TabStop = true;
            this.rbSelect.Text = "Select";
            this.rbSelect.UseVisualStyleBackColor = true;
            this.rbSelect.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cmbTerrain
            // 
            this.cmbTerrain.FormattingEnabled = true;
            this.cmbTerrain.Location = new System.Drawing.Point(48, 77);
            this.cmbTerrain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTerrain.Name = "cmbTerrain";
            this.cmbTerrain.Size = new System.Drawing.Size(150, 28);
            this.cmbTerrain.TabIndex = 2;
            this.cmbTerrain.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbTerrain.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // cmbVegetation
            // 
            this.cmbVegetation.FormattingEnabled = true;
            this.cmbVegetation.Location = new System.Drawing.Point(48, 118);
            this.cmbVegetation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbVegetation.Name = "cmbVegetation";
            this.cmbVegetation.Size = new System.Drawing.Size(150, 28);
            this.cmbVegetation.TabIndex = 3;
            this.cmbVegetation.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbVegetation.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // cmbIcon
            // 
            this.cmbIcon.FormattingEnabled = true;
            this.cmbIcon.Location = new System.Drawing.Point(48, 160);
            this.cmbIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbIcon.Name = "cmbIcon";
            this.cmbIcon.Size = new System.Drawing.Size(150, 28);
            this.cmbIcon.TabIndex = 5;
            this.cmbIcon.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbIcon.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // rbTerrain
            // 
            this.rbTerrain.AutoSize = true;
            this.rbTerrain.Location = new System.Drawing.Point(18, 82);
            this.rbTerrain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbTerrain.Name = "rbTerrain";
            this.rbTerrain.Size = new System.Drawing.Size(21, 20);
            this.rbTerrain.TabIndex = 6;
            this.rbTerrain.TabStop = true;
            this.rbTerrain.UseVisualStyleBackColor = true;
            this.rbTerrain.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbIcons
            // 
            this.rbIcons.AutoSize = true;
            this.rbIcons.Location = new System.Drawing.Point(18, 165);
            this.rbIcons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbIcons.Name = "rbIcons";
            this.rbIcons.Size = new System.Drawing.Size(21, 20);
            this.rbIcons.TabIndex = 7;
            this.rbIcons.TabStop = true;
            this.rbIcons.UseVisualStyleBackColor = true;
            this.rbIcons.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbRiver
            // 
            this.rbRiver.AutoSize = true;
            this.rbRiver.Location = new System.Drawing.Point(18, 248);
            this.rbRiver.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbRiver.Name = "rbRiver";
            this.rbRiver.Size = new System.Drawing.Size(21, 20);
            this.rbRiver.TabIndex = 8;
            this.rbRiver.TabStop = true;
            this.rbRiver.UseVisualStyleBackColor = true;
            this.rbRiver.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cmbRiver
            // 
            this.cmbRiver.FormattingEnabled = true;
            this.cmbRiver.Location = new System.Drawing.Point(48, 243);
            this.cmbRiver.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRiver.Name = "cmbRiver";
            this.cmbRiver.Size = new System.Drawing.Size(150, 28);
            this.cmbRiver.TabIndex = 9;
            this.cmbRiver.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbRiver.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // rbRoad
            // 
            this.rbRoad.AutoSize = true;
            this.rbRoad.Location = new System.Drawing.Point(18, 289);
            this.rbRoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbRoad.Name = "rbRoad";
            this.rbRoad.Size = new System.Drawing.Size(21, 20);
            this.rbRoad.TabIndex = 10;
            this.rbRoad.TabStop = true;
            this.rbRoad.UseVisualStyleBackColor = true;
            this.rbRoad.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cmbRoad
            // 
            this.cmbRoad.FormattingEnabled = true;
            this.cmbRoad.Location = new System.Drawing.Point(48, 285);
            this.cmbRoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRoad.Name = "cmbRoad";
            this.cmbRoad.Size = new System.Drawing.Size(150, 28);
            this.cmbRoad.TabIndex = 11;
            this.cmbRoad.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbRoad.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // menuStrip
            // 
            this.menuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip.AutoSize = false;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.mapToolStripMenuItem,
            this.playerToolStripMenuItem,
            this.imageAttributionToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1328, 35);
            this.menuStrip.TabIndex = 17;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.loadToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.saveImageToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(54, 31);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(206, 34);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(206, 34);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(206, 34);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bmpToolStripMenuItem,
            this.pngToolStripMenuItem1});
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // bmpToolStripMenuItem
            // 
            this.bmpToolStripMenuItem.Name = "bmpToolStripMenuItem";
            this.bmpToolStripMenuItem.Size = new System.Drawing.Size(151, 34);
            this.bmpToolStripMenuItem.Text = "Bmp";
            this.bmpToolStripMenuItem.Click += new System.EventHandler(this.bitmapToolStripMenuItem_Click);
            // 
            // pngToolStripMenuItem1
            // 
            this.pngToolStripMenuItem1.Name = "pngToolStripMenuItem1";
            this.pngToolStripMenuItem1.Size = new System.Drawing.Size(151, 34);
            this.pngToolStripMenuItem1.Text = "Png";
            this.pngToolStripMenuItem1.Click += new System.EventHandler(this.pngToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(206, 34);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centerMapToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(64, 31);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // centerMapToolStripMenuItem
            // 
            this.centerMapToolStripMenuItem.Name = "centerMapToolStripMenuItem";
            this.centerMapToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.centerMapToolStripMenuItem.Text = "Center Map";
            this.centerMapToolStripMenuItem.Click += new System.EventHandler(this.centerMapToolStripMenuItem_Click);
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWindowToolStripMenuItem,
            this.timeAndWeatherToolStripMenuItem});
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(75, 31);
            this.playerToolStripMenuItem.Text = "Player";
            // 
            // openWindowToolStripMenuItem
            // 
            this.openWindowToolStripMenuItem.Name = "openWindowToolStripMenuItem";
            this.openWindowToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            this.openWindowToolStripMenuItem.Text = "Open Window";
            this.openWindowToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // timeAndWeatherToolStripMenuItem
            // 
            this.timeAndWeatherToolStripMenuItem.Name = "timeAndWeatherToolStripMenuItem";
            this.timeAndWeatherToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            this.timeAndWeatherToolStripMenuItem.Text = "Time And Weather";
            this.timeAndWeatherToolStripMenuItem.Click += new System.EventHandler(this.timeAndWeatherToolStripMenuItem_Click);
            // 
            // imageAttributionToolStripMenuItem
            // 
            this.imageAttributionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weatherImagesDesignedByToolStripMenuItem,
            this.sunAndMoonImageDesignedByFreepikToolStripMenuItem});
            this.imageAttributionToolStripMenuItem.Name = "imageAttributionToolStripMenuItem";
            this.imageAttributionToolStripMenuItem.Size = new System.Drawing.Size(169, 31);
            this.imageAttributionToolStripMenuItem.Text = "Image Attribution";
            // 
            // weatherImagesDesignedByToolStripMenuItem
            // 
            this.weatherImagesDesignedByToolStripMenuItem.Name = "weatherImagesDesignedByToolStripMenuItem";
            this.weatherImagesDesignedByToolStripMenuItem.Size = new System.Drawing.Size(638, 34);
            this.weatherImagesDesignedByToolStripMenuItem.Text = "Weather images designed by Designed by Titusurya - Freepik.com";
            this.weatherImagesDesignedByToolStripMenuItem.Click += new System.EventHandler(this.weatherImagesDesignedByToolStripMenuItem_Click);
            // 
            // sunAndMoonImageDesignedByFreepikToolStripMenuItem
            // 
            this.sunAndMoonImageDesignedByFreepikToolStripMenuItem.Name = "sunAndMoonImageDesignedByFreepikToolStripMenuItem";
            this.sunAndMoonImageDesignedByFreepikToolStripMenuItem.Size = new System.Drawing.Size(638, 34);
            this.sunAndMoonImageDesignedByFreepikToolStripMenuItem.Text = "Sun and Moon image designed by Freepik";
            this.sunAndMoonImageDesignedByFreepikToolStripMenuItem.Click += new System.EventHandler(this.sunAndMoonImageDesignedByFreepikToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveBmpToolStripMenuItem,
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveBmpToolStripMenuItem
            // 
            this.saveBmpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitmapToolStripMenuItem,
            this.pngToolStripMenuItem});
            this.saveBmpToolStripMenuItem.Name = "saveBmpToolStripMenuItem";
            this.saveBmpToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.saveBmpToolStripMenuItem.Text = "Save Image";
            this.saveBmpToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // bitmapToolStripMenuItem
            // 
            this.bitmapToolStripMenuItem.Name = "bitmapToolStripMenuItem";
            this.bitmapToolStripMenuItem.Size = new System.Drawing.Size(170, 34);
            this.bitmapToolStripMenuItem.Text = "Bitmap";
            this.bitmapToolStripMenuItem.Click += new System.EventHandler(this.bitmapToolStripMenuItem_Click);
            // 
            // pngToolStripMenuItem
            // 
            this.pngToolStripMenuItem.Name = "pngToolStripMenuItem";
            this.pngToolStripMenuItem.Size = new System.Drawing.Size(170, 34);
            this.pngToolStripMenuItem.Text = "Png";
            this.pngToolStripMenuItem.Click += new System.EventHandler(this.pngToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // playerWindowToolStripMenuItem
            // 
            this.playerWindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.playerWindowToolStripMenuItem.Name = "playerWindowToolStripMenuItem";
            this.playerWindowToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.playerWindowToolStripMenuItem.Text = "Player Window";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 34);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // btnMoveEast1
            // 
            this.btnMoveEast1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveEast1.Location = new System.Drawing.Point(940, 260);
            this.btnMoveEast1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveEast1.Name = "btnMoveEast1";
            this.btnMoveEast1.Size = new System.Drawing.Size(45, 403);
            this.btnMoveEast1.TabIndex = 18;
            this.btnMoveEast1.Text = ">";
            this.btnMoveEast1.UseVisualStyleBackColor = true;
            this.btnMoveEast1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveEast1_MouseClick);
            // 
            // btnMoveEast3
            // 
            this.btnMoveEast3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveEast3.Location = new System.Drawing.Point(940, 672);
            this.btnMoveEast3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveEast3.Name = "btnMoveEast3";
            this.btnMoveEast3.Size = new System.Drawing.Size(45, 154);
            this.btnMoveEast3.TabIndex = 19;
            this.btnMoveEast3.Text = ">\r\n>\r\n>";
            this.btnMoveEast3.UseVisualStyleBackColor = true;
            this.btnMoveEast3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveEast3_MouseClick);
            // 
            // btnMoveWest2
            // 
            this.btnMoveWest2.Location = new System.Drawing.Point(208, 97);
            this.btnMoveWest2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveWest2.Name = "btnMoveWest2";
            this.btnMoveWest2.Size = new System.Drawing.Size(45, 154);
            this.btnMoveWest2.TabIndex = 20;
            this.btnMoveWest2.Text = "<\r\n<";
            this.btnMoveWest2.UseVisualStyleBackColor = true;
            this.btnMoveWest2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveWest2_MouseClick);
            // 
            // btnMoveWest3
            // 
            this.btnMoveWest3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveWest3.Location = new System.Drawing.Point(208, 672);
            this.btnMoveWest3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveWest3.Name = "btnMoveWest3";
            this.btnMoveWest3.Size = new System.Drawing.Size(45, 154);
            this.btnMoveWest3.TabIndex = 21;
            this.btnMoveWest3.Text = "<\r\n<\r\n<";
            this.btnMoveWest3.UseVisualStyleBackColor = true;
            this.btnMoveWest3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveWest3_MouseClick);
            // 
            // btnMoveNorth2
            // 
            this.btnMoveNorth2.Location = new System.Drawing.Point(262, 42);
            this.btnMoveNorth2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveNorth2.Name = "btnMoveNorth2";
            this.btnMoveNorth2.Size = new System.Drawing.Size(150, 46);
            this.btnMoveNorth2.TabIndex = 22;
            this.btnMoveNorth2.Text = "^^";
            this.btnMoveNorth2.UseVisualStyleBackColor = true;
            this.btnMoveNorth2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveNorth2_MouseClick);
            // 
            // btnMoveNorth3
            // 
            this.btnMoveNorth3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveNorth3.Location = new System.Drawing.Point(782, 42);
            this.btnMoveNorth3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveNorth3.Name = "btnMoveNorth3";
            this.btnMoveNorth3.Size = new System.Drawing.Size(150, 46);
            this.btnMoveNorth3.TabIndex = 23;
            this.btnMoveNorth3.Text = "^^^";
            this.btnMoveNorth3.UseVisualStyleBackColor = true;
            this.btnMoveNorth3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveNorth3_MouseClick);
            // 
            // btnMoveSouth2
            // 
            this.btnMoveSouth2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveSouth2.Location = new System.Drawing.Point(262, 835);
            this.btnMoveSouth2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveSouth2.Name = "btnMoveSouth2";
            this.btnMoveSouth2.Size = new System.Drawing.Size(150, 46);
            this.btnMoveSouth2.TabIndex = 24;
            this.btnMoveSouth2.Text = "VV";
            this.btnMoveSouth2.UseVisualStyleBackColor = true;
            this.btnMoveSouth2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveSouth2_MouseClick);
            // 
            // btnMoveSouth3
            // 
            this.btnMoveSouth3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveSouth3.Location = new System.Drawing.Point(782, 835);
            this.btnMoveSouth3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveSouth3.Name = "btnMoveSouth3";
            this.btnMoveSouth3.Size = new System.Drawing.Size(150, 46);
            this.btnMoveSouth3.TabIndex = 25;
            this.btnMoveSouth3.Text = "VVV";
            this.btnMoveSouth3.UseVisualStyleBackColor = true;
            this.btnMoveSouth3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMoveSouth3_MouseClick);
            // 
            // rbPlayerIcon
            // 
            this.rbPlayerIcon.AutoSize = true;
            this.rbPlayerIcon.Location = new System.Drawing.Point(18, 206);
            this.rbPlayerIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbPlayerIcon.Name = "rbPlayerIcon";
            this.rbPlayerIcon.Size = new System.Drawing.Size(21, 20);
            this.rbPlayerIcon.TabIndex = 27;
            this.rbPlayerIcon.TabStop = true;
            this.rbPlayerIcon.UseVisualStyleBackColor = true;
            this.rbPlayerIcon.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cmbPlayerIcon
            // 
            this.cmbPlayerIcon.FormattingEnabled = true;
            this.cmbPlayerIcon.Location = new System.Drawing.Point(48, 202);
            this.cmbPlayerIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPlayerIcon.Name = "cmbPlayerIcon";
            this.cmbPlayerIcon.Size = new System.Drawing.Size(150, 28);
            this.cmbPlayerIcon.TabIndex = 26;
            this.cmbPlayerIcon.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbPlayerIcon.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 405);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "Layers";
            // 
            // chk100GmIcons
            // 
            this.chk100GmIcons.AutoSize = true;
            this.chk100GmIcons.Location = new System.Drawing.Point(50, 438);
            this.chk100GmIcons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk100GmIcons.Name = "chk100GmIcons";
            this.chk100GmIcons.Size = new System.Drawing.Size(104, 24);
            this.chk100GmIcons.TabIndex = 29;
            this.chk100GmIcons.Text = "GM Icons";
            this.chk100GmIcons.UseVisualStyleBackColor = true;
            this.chk100GmIcons.CheckStateChanged += new System.EventHandler(this.CheckBox_LayerChanged);
            // 
            // chk100PlayerIcons
            // 
            this.chk100PlayerIcons.AutoSize = true;
            this.chk100PlayerIcons.Location = new System.Drawing.Point(50, 474);
            this.chk100PlayerIcons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk100PlayerIcons.Name = "chk100PlayerIcons";
            this.chk100PlayerIcons.Size = new System.Drawing.Size(121, 24);
            this.chk100PlayerIcons.TabIndex = 30;
            this.chk100PlayerIcons.Text = "Player Icons";
            this.chk100PlayerIcons.UseVisualStyleBackColor = true;
            this.chk100PlayerIcons.CheckStateChanged += new System.EventHandler(this.CheckBox_LayerChanged);
            // 
            // chk100FogOfWar
            // 
            this.chk100FogOfWar.AutoSize = true;
            this.chk100FogOfWar.Location = new System.Drawing.Point(50, 509);
            this.chk100FogOfWar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk100FogOfWar.Name = "chk100FogOfWar";
            this.chk100FogOfWar.Size = new System.Drawing.Size(114, 24);
            this.chk100FogOfWar.TabIndex = 31;
            this.chk100FogOfWar.Text = "Fog of War";
            this.chk100FogOfWar.UseVisualStyleBackColor = true;
            this.chk100FogOfWar.CheckStateChanged += new System.EventHandler(this.CheckBox_LayerChanged);
            // 
            // chk50GmIcons
            // 
            this.chk50GmIcons.AutoSize = true;
            this.chk50GmIcons.Location = new System.Drawing.Point(18, 440);
            this.chk50GmIcons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk50GmIcons.Name = "chk50GmIcons";
            this.chk50GmIcons.Size = new System.Drawing.Size(22, 21);
            this.chk50GmIcons.TabIndex = 32;
            this.chk50GmIcons.UseVisualStyleBackColor = true;
            this.chk50GmIcons.CheckStateChanged += new System.EventHandler(this.CheckBox_LayerChanged);
            // 
            // chk50PlayerIcons
            // 
            this.chk50PlayerIcons.AutoSize = true;
            this.chk50PlayerIcons.Location = new System.Drawing.Point(18, 475);
            this.chk50PlayerIcons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk50PlayerIcons.Name = "chk50PlayerIcons";
            this.chk50PlayerIcons.Size = new System.Drawing.Size(22, 21);
            this.chk50PlayerIcons.TabIndex = 33;
            this.chk50PlayerIcons.UseVisualStyleBackColor = true;
            this.chk50PlayerIcons.CheckStateChanged += new System.EventHandler(this.CheckBox_LayerChanged);
            // 
            // chk50FogOfWar
            // 
            this.chk50FogOfWar.AutoSize = true;
            this.chk50FogOfWar.Location = new System.Drawing.Point(18, 511);
            this.chk50FogOfWar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk50FogOfWar.Name = "chk50FogOfWar";
            this.chk50FogOfWar.Size = new System.Drawing.Size(22, 21);
            this.chk50FogOfWar.TabIndex = 34;
            this.chk50FogOfWar.UseVisualStyleBackColor = true;
            this.chk50FogOfWar.CheckStateChanged += new System.EventHandler(this.CheckBox_LayerChanged);
            // 
            // cmbFogOfWar
            // 
            this.cmbFogOfWar.FormattingEnabled = true;
            this.cmbFogOfWar.Location = new System.Drawing.Point(48, 326);
            this.cmbFogOfWar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFogOfWar.Name = "cmbFogOfWar";
            this.cmbFogOfWar.Size = new System.Drawing.Size(150, 28);
            this.cmbFogOfWar.TabIndex = 36;
            this.cmbFogOfWar.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedIndexChanged);
            this.cmbFogOfWar.Click += new System.EventHandler(this.ComboBox_Clicked);
            // 
            // rbFogOfWar
            // 
            this.rbFogOfWar.AutoSize = true;
            this.rbFogOfWar.Location = new System.Drawing.Point(18, 331);
            this.rbFogOfWar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbFogOfWar.Name = "rbFogOfWar";
            this.rbFogOfWar.Size = new System.Drawing.Size(21, 20);
            this.rbFogOfWar.TabIndex = 35;
            this.rbFogOfWar.TabStop = true;
            this.rbFogOfWar.UseVisualStyleBackColor = true;
            this.rbFogOfWar.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.Location = new System.Drawing.Point(990, 862);
            this.lblCoordinates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(0, 20);
            this.lblCoordinates.TabIndex = 37;
            this.lblCoordinates.Click += new System.EventHandler(this.lblCoordinates_Click);
            // 
            // chkOverlayGrid
            // 
            this.chkOverlayGrid.AutoSize = true;
            this.chkOverlayGrid.Location = new System.Drawing.Point(48, 545);
            this.chkOverlayGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOverlayGrid.Name = "chkOverlayGrid";
            this.chkOverlayGrid.Size = new System.Drawing.Size(121, 24);
            this.chkOverlayGrid.TabIndex = 38;
            this.chkOverlayGrid.Text = "Overlay Grid";
            this.chkOverlayGrid.UseVisualStyleBackColor = true;
            this.chkOverlayGrid.CheckedChanged += new System.EventHandler(this.CheckBox_LayerChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(13, 853);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 35);
            this.btnSearch.TabIndex = 40;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // imgLoadingIndicator
            // 
            this.imgLoadingIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLoadingIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.imgLoadingIndicator.Image = global::HexAdventureMapper.Properties.Resources.LoadingIndicator;
            this.imgLoadingIndicator.Location = new System.Drawing.Point(940, 42);
            this.imgLoadingIndicator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imgLoadingIndicator.Name = "imgLoadingIndicator";
            this.imgLoadingIndicator.Size = new System.Drawing.Size(45, 46);
            this.imgLoadingIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLoadingIndicator.TabIndex = 39;
            this.imgLoadingIndicator.TabStop = false;
            this.imgLoadingIndicator.UseWaitCursor = true;
            this.imgLoadingIndicator.Visible = false;
            // 
            // imgLoading
            // 
            this.imgLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLoading.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imgLoading.Image = global::HexAdventureMapper.Properties.Resources.LoadingIndicator;
            this.imgLoading.Location = new System.Drawing.Point(627, 27);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Size = new System.Drawing.Size(30, 30);
            this.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLoading.TabIndex = 39;
            this.imgLoading.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Location = new System.Drawing.Point(13, 821);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(166, 26);
            this.txtSearch.TabIndex = 41;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnGoto
            // 
            this.btnGoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGoto.Location = new System.Drawing.Point(104, 853);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(75, 35);
            this.btnGoto.TabIndex = 42;
            this.btnGoto.Text = "GoTo";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // imgHexMap
            // 
            this.imgHexMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgHexMap.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.imgHexMap.Location = new System.Drawing.Point(262, 97);
            this.imgHexMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imgHexMap.Name = "imgHexMap";
            this.imgHexMap.Size = new System.Drawing.Size(669, 729);
            this.imgHexMap.TabIndex = 4;
            this.imgHexMap.TabStop = false;
            this.imgHexMap.MapClick += new HexAdventureMapper.Views.MapEventHandler(this.imgHexMap_MapClick);
            this.imgHexMap.MapDrag += new HexAdventureMapper.Views.MapEventHandler(this.imgHexMap_MapDrag);
            this.imgHexMap.SizeChanged += new System.EventHandler(this.imgHexMap_SizeChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 900);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.imgLoadingIndicator);
            this.Controls.Add(this.chkOverlayGrid);
            this.Controls.Add(this.lblCoordinates);
            this.Controls.Add(this.cmbFogOfWar);
            this.Controls.Add(this.rbFogOfWar);
            this.Controls.Add(this.chk50FogOfWar);
            this.Controls.Add(this.chk50PlayerIcons);
            this.Controls.Add(this.chk50GmIcons);
            this.Controls.Add(this.chk100FogOfWar);
            this.Controls.Add(this.chk100PlayerIcons);
            this.Controls.Add(this.chk100GmIcons);
            this.Controls.Add(this.label1);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1039, 739);
            this.Name = "MainWindow";
            this.Text = "Hex Adventure Mapper";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadingIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHexMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RichTextBoxLinks.RichTextBoxEx txtDetail;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk100GmIcons;
        private System.Windows.Forms.CheckBox chk100PlayerIcons;
        private System.Windows.Forms.CheckBox chk100FogOfWar;
        private System.Windows.Forms.CheckBox chk50GmIcons;
        private System.Windows.Forms.CheckBox chk50PlayerIcons;
        private System.Windows.Forms.CheckBox chk50FogOfWar;
        private System.Windows.Forms.ComboBox cmbFogOfWar;
        private System.Windows.Forms.RadioButton rbFogOfWar;
        private System.Windows.Forms.ToolStripMenuItem playerWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBmpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pngToolStripMenuItem;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.CheckBox chkOverlayGrid;
        private System.Windows.Forms.PictureBox imgLoadingIndicator;
        private System.Windows.Forms.PictureBox imgLoading;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bmpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeAndWeatherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageAttributionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weatherImagesDesignedByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sunAndMoonImageDesignedByFreepikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerMapToolStripMenuItem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnGoto;
    }
}

