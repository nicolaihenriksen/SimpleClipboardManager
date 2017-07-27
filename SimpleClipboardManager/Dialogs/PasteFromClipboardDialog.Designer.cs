namespace SimpleClipboardManager.Dialogs
{
    partial class PasteFromClipboardDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasteFromClipboardDialog));
            this.clipboardItemList = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ContentPanel = new SimpleClipboardManager.RoundCornerPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.LblHints = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.BtnClear = new System.Windows.Forms.PictureBox();
            this.BtnSettings = new System.Windows.Forms.PictureBox();
            this.LblPasteAppName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // clipboardItemList
            // 
            this.clipboardItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clipboardItemList.FormattingEnabled = true;
            this.clipboardItemList.ItemHeight = 16;
            this.clipboardItemList.Location = new System.Drawing.Point(6, 6);
            this.clipboardItemList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.clipboardItemList.Name = "clipboardItemList";
            this.clipboardItemList.Size = new System.Drawing.Size(785, 102);
            this.clipboardItemList.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ContentPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(803, 227);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.ContentPanel.BackgroundColor = System.Drawing.Color.Black;
            this.ContentPanel.Controls.Add(this.tableLayoutPanel3);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 26);
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Padding = new System.Windows.Forms.Padding(3);
            this.ContentPanel.Radius = 15;
            this.ContentPanel.Size = new System.Drawing.Size(803, 201);
            this.ContentPanel.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.clipboardItemList, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(797, 195);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.LblHints);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(8, 108);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(789, 87);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // LblHints
            // 
            this.LblHints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblHints.AutoSize = true;
            this.LblHints.Location = new System.Drawing.Point(0, 0);
            this.LblHints.Margin = new System.Windows.Forms.Padding(0);
            this.LblHints.Name = "LblHints";
            this.LblHints.Size = new System.Drawing.Size(54, 17);
            this.LblHints.TabIndex = 0;
            this.LblHints.Text = "<hints>";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.BtnClose, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnClear, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnSettings, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.LblPasteAppName, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(803, 25);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnClose.Image = global::SimpleClipboardManager.Properties.Resources.LightTheme_Close;
            this.BtnClose.Location = new System.Drawing.Point(762, 0);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(24, 24);
            this.BtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnClose.TabIndex = 0;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.BtnClose.MouseHover += new System.EventHandler(this.TitleButton_Hover);
            // 
            // BtnClear
            // 
            this.BtnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnClear.Image = global::SimpleClipboardManager.Properties.Resources.LightTheme_Clear;
            this.BtnClear.Location = new System.Drawing.Point(708, 0);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(24, 24);
            this.BtnClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnClear.TabIndex = 2;
            this.BtnClear.TabStop = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            this.BtnClear.MouseHover += new System.EventHandler(this.TitleButton_Hover);
            // 
            // BtnSettings
            // 
            this.BtnSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSettings.Image = global::SimpleClipboardManager.Properties.Resources.LightTheme_Settings;
            this.BtnSettings.Location = new System.Drawing.Point(735, 0);
            this.BtnSettings.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(24, 24);
            this.BtnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnSettings.TabIndex = 1;
            this.BtnSettings.TabStop = false;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            this.BtnSettings.MouseHover += new System.EventHandler(this.TitleButton_Hover);
            // 
            // LblPasteAppName
            // 
            this.LblPasteAppName.AutoSize = true;
            this.LblPasteAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPasteAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPasteAppName.Location = new System.Drawing.Point(13, 0);
            this.LblPasteAppName.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.LblPasteAppName.Name = "LblPasteAppName";
            this.LblPasteAppName.Size = new System.Drawing.Size(692, 25);
            this.LblPasteAppName.TabIndex = 3;
            this.LblPasteAppName.Text = "<app name>";
            this.LblPasteAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PasteFromClipboardDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(803, 227);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PasteFromClipboardDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Clipboard Manager";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox clipboardItemList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundCornerPanel ContentPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox BtnClose;
        private System.Windows.Forms.PictureBox BtnSettings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label LblHints;
        private System.Windows.Forms.PictureBox BtnClear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label LblPasteAppName;
    }
}