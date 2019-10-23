namespace HexAdventureMapper
{
    partial class SearchWindow
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
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListView();
            this.rtxtDetail = new System.Windows.Forms.RichTextBox();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.chkCloseWindow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchTerm.Location = new System.Drawing.Point(12, 16);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(567, 26);
            this.txtSearchTerm.TabIndex = 0;
            this.txtSearchTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchTerm_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(713, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.HideSelection = false;
            this.lstResults.Location = new System.Drawing.Point(12, 53);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(450, 727);
            this.lstResults.TabIndex = 2;
            this.lstResults.UseCompatibleStateImageBehavior = false;
            this.lstResults.View = System.Windows.Forms.View.List;
            this.lstResults.SelectedIndexChanged += new System.EventHandler(this.lstResults_SelectedIndexChanged);
            this.lstResults.DoubleClick += new System.EventHandler(this.lstResults_DoubleClick);
            // 
            // rtxtDetail
            // 
            this.rtxtDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtDetail.Enabled = false;
            this.rtxtDetail.Location = new System.Drawing.Point(468, 53);
            this.rtxtDetail.Name = "rtxtDetail";
            this.rtxtDetail.Size = new System.Drawing.Size(320, 727);
            this.rtxtDetail.TabIndex = 3;
            this.rtxtDetail.Text = "";
            // 
            // txtRange
            // 
            this.txtRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRange.ForeColor = System.Drawing.Color.Silver;
            this.txtRange.Location = new System.Drawing.Point(585, 16);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(122, 26);
            this.txtRange.TabIndex = 4;
            this.txtRange.Text = "Range";
            this.txtRange.Enter += new System.EventHandler(this.txtRange_Enter);
            this.txtRange.Leave += new System.EventHandler(this.txtRange_Leave);
            // 
            // chkCloseWindow
            // 
            this.chkCloseWindow.AutoSize = true;
            this.chkCloseWindow.Checked = true;
            this.chkCloseWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCloseWindow.Location = new System.Drawing.Point(561, 786);
            this.chkCloseWindow.Name = "chkCloseWindow";
            this.chkCloseWindow.Size = new System.Drawing.Size(227, 24);
            this.chkCloseWindow.TabIndex = 5;
            this.chkCloseWindow.Text = "Close Window after Search";
            this.chkCloseWindow.UseVisualStyleBackColor = true;
            this.chkCloseWindow.CheckedChanged += new System.EventHandler(this.chkCloseWindow_CheckedChanged);
            // 
            // SearchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 822);
            this.Controls.Add(this.chkCloseWindow);
            this.Controls.Add(this.txtRange);
            this.Controls.Add(this.rtxtDetail);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchTerm);
            this.Name = "SearchWindow";
            this.Text = "SearchWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lstResults;
        private System.Windows.Forms.RichTextBox rtxtDetail;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.CheckBox chkCloseWindow;
    }
}