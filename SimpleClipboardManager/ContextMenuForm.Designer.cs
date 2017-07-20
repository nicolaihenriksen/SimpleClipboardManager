namespace SimpleClipboardManager
{
    partial class ContextMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContextMenuForm));
            this.clipboardItemList = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.roundCornerPanel1 = new SimpleClipboardManager.RoundCornerPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.LblHints = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundCornerPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.clipboardItemList.Size = new System.Drawing.Size(568, 119);
            this.clipboardItemList.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.roundCornerPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(586, 227);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // roundCornerPanel1
            // 
            this.roundCornerPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(104)))));
            this.roundCornerPanel1.Controls.Add(this.tableLayoutPanel3);
            this.roundCornerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundCornerPanel1.Location = new System.Drawing.Point(0, 26);
            this.roundCornerPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.roundCornerPanel1.Name = "roundCornerPanel1";
            this.roundCornerPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.roundCornerPanel1.Radius = 15;
            this.roundCornerPanel1.Size = new System.Drawing.Size(586, 201);
            this.roundCornerPanel1.TabIndex = 3;
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
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(580, 195);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.LblHints);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(8, 125);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(572, 70);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // LblHints
            // 
            this.LblHints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblHints.AutoSize = true;
            this.LblHints.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LblHints.Location = new System.Drawing.Point(0, 0);
            this.LblHints.Margin = new System.Windows.Forms.Padding(0);
            this.LblHints.Name = "LblHints";
            this.LblHints.Size = new System.Drawing.Size(54, 17);
            this.LblHints.TabIndex = 0;
            this.LblHints.Text = "<hints>";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtnClose);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(566, 25);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // BtnClose
            // 
            this.BtnClose.Image = ((System.Drawing.Image)(resources.GetObject("BtnClose.Image")));
            this.BtnClose.Location = new System.Drawing.Point(540, 0);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(26, 26);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(511, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::SimpleClipboardManager.Properties.Resources.Clear;
            this.pictureBox2.Location = new System.Drawing.Point(5, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0, 0, 450, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 26);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // ContextMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 227);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContextMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Clipboard Manager";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundCornerPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox clipboardItemList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundCornerPanel roundCornerPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox BtnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label LblHints;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}