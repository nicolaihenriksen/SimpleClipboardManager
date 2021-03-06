﻿namespace SimpleClipboardManager.Dialogs
{
    partial class SettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TrackOpacity = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RadioThemeBlue = new System.Windows.Forms.RadioButton();
            this.RadioThemeGreen = new System.Windows.Forms.RadioButton();
            this.RadioThemeDark = new System.Windows.Forms.RadioButton();
            this.RadioThemeLight = new System.Windows.Forms.RadioButton();
            this.GroupBoxStorageAndStartup = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboMaxItemsStored = new System.Windows.Forms.ComboBox();
            this.CheckStartOnBoot = new System.Windows.Forms.CheckBox();
            this.CheckStorage = new System.Windows.Forms.CheckBox();
            this.LblDisclaimerText = new System.Windows.Forms.Label();
            this.LblDisclaimerHeader = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioHotKeyInsert = new System.Windows.Forms.RadioButton();
            this.RadioHotKeyControlInsert = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboMaxDisplayItems = new System.Windows.Forms.ComboBox();
            this.ComboMinDisplayItems = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboMaxPreviewLines = new System.Windows.Forms.ComboBox();
            this.CheckPreviewEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackOpacity)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.GroupBoxStorageAndStartup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.TrackOpacity);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 496);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(485, 75);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Opacity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(403, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Max.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Min.";
            // 
            // TrackOpacity
            // 
            this.TrackOpacity.LargeChange = 10;
            this.TrackOpacity.Location = new System.Drawing.Point(6, 21);
            this.TrackOpacity.Maximum = 100;
            this.TrackOpacity.Minimum = 20;
            this.TrackOpacity.Name = "TrackOpacity";
            this.TrackOpacity.Size = new System.Drawing.Size(434, 56);
            this.TrackOpacity.TabIndex = 6;
            this.TrackOpacity.TickFrequency = 10;
            this.TrackOpacity.Value = 50;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.BtnOk, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnCancel, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(159, 586);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(172, 29);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnOk.Location = new System.Drawing.Point(3, 3);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 0;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(94, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RadioThemeBlue);
            this.groupBox4.Controls.Add(this.RadioThemeGreen);
            this.groupBox4.Controls.Add(this.RadioThemeDark);
            this.groupBox4.Controls.Add(this.RadioThemeLight);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 437);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(485, 53);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Theme";
            // 
            // RadioThemeBlue
            // 
            this.RadioThemeBlue.AutoSize = true;
            this.RadioThemeBlue.Location = new System.Drawing.Point(219, 21);
            this.RadioThemeBlue.Name = "RadioThemeBlue";
            this.RadioThemeBlue.Size = new System.Drawing.Size(57, 21);
            this.RadioThemeBlue.TabIndex = 3;
            this.RadioThemeBlue.TabStop = true;
            this.RadioThemeBlue.Text = "Blue";
            this.RadioThemeBlue.UseVisualStyleBackColor = true;
            // 
            // RadioThemeGreen
            // 
            this.RadioThemeGreen.AutoSize = true;
            this.RadioThemeGreen.Location = new System.Drawing.Point(144, 21);
            this.RadioThemeGreen.Name = "RadioThemeGreen";
            this.RadioThemeGreen.Size = new System.Drawing.Size(69, 21);
            this.RadioThemeGreen.TabIndex = 2;
            this.RadioThemeGreen.TabStop = true;
            this.RadioThemeGreen.Text = "Green";
            this.RadioThemeGreen.UseVisualStyleBackColor = true;
            // 
            // RadioThemeDark
            // 
            this.RadioThemeDark.AutoSize = true;
            this.RadioThemeDark.Location = new System.Drawing.Point(79, 21);
            this.RadioThemeDark.Name = "RadioThemeDark";
            this.RadioThemeDark.Size = new System.Drawing.Size(59, 21);
            this.RadioThemeDark.TabIndex = 1;
            this.RadioThemeDark.TabStop = true;
            this.RadioThemeDark.Text = "Dark";
            this.RadioThemeDark.UseVisualStyleBackColor = true;
            // 
            // RadioThemeLight
            // 
            this.RadioThemeLight.AutoSize = true;
            this.RadioThemeLight.Location = new System.Drawing.Point(13, 21);
            this.RadioThemeLight.Name = "RadioThemeLight";
            this.RadioThemeLight.Size = new System.Drawing.Size(60, 21);
            this.RadioThemeLight.TabIndex = 0;
            this.RadioThemeLight.TabStop = true;
            this.RadioThemeLight.Text = "Light";
            this.RadioThemeLight.UseVisualStyleBackColor = true;
            // 
            // GroupBoxStorageAndStartup
            // 
            this.GroupBoxStorageAndStartup.Controls.Add(this.label6);
            this.GroupBoxStorageAndStartup.Controls.Add(this.ComboMaxItemsStored);
            this.GroupBoxStorageAndStartup.Controls.Add(this.CheckStartOnBoot);
            this.GroupBoxStorageAndStartup.Controls.Add(this.CheckStorage);
            this.GroupBoxStorageAndStartup.Controls.Add(this.LblDisclaimerText);
            this.GroupBoxStorageAndStartup.Controls.Add(this.LblDisclaimerHeader);
            this.GroupBoxStorageAndStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBoxStorageAndStartup.Location = new System.Drawing.Point(3, 287);
            this.GroupBoxStorageAndStartup.Name = "GroupBoxStorageAndStartup";
            this.GroupBoxStorageAndStartup.Size = new System.Drawing.Size(485, 144);
            this.GroupBoxStorageAndStartup.TabIndex = 7;
            this.GroupBoxStorageAndStartup.TabStop = false;
            this.GroupBoxStorageAndStartup.Text = "Storage && Startup";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(394, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "items will at most be stored (oldest non-favorites deleted first)";
            // 
            // ComboMaxItemsStored
            // 
            this.ComboMaxItemsStored.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMaxItemsStored.FormattingEnabled = true;
            this.ComboMaxItemsStored.Items.AddRange(new object[] {
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.ComboMaxItemsStored.Location = new System.Drawing.Point(13, 48);
            this.ComboMaxItemsStored.Name = "ComboMaxItemsStored";
            this.ComboMaxItemsStored.Size = new System.Drawing.Size(56, 24);
            this.ComboMaxItemsStored.TabIndex = 15;
            // 
            // CheckStartOnBoot
            // 
            this.CheckStartOnBoot.AutoSize = true;
            this.CheckStartOnBoot.Location = new System.Drawing.Point(13, 78);
            this.CheckStartOnBoot.Name = "CheckStartOnBoot";
            this.CheckStartOnBoot.Size = new System.Drawing.Size(268, 21);
            this.CheckStartOnBoot.TabIndex = 13;
            this.CheckStartOnBoot.Text = "Start application when Windows starts";
            this.CheckStartOnBoot.UseVisualStyleBackColor = true;
            // 
            // CheckStorage
            // 
            this.CheckStorage.AutoSize = true;
            this.CheckStorage.Location = new System.Drawing.Point(13, 21);
            this.CheckStorage.Name = "CheckStorage";
            this.CheckStorage.Size = new System.Drawing.Size(423, 21);
            this.CheckStorage.TabIndex = 12;
            this.CheckStorage.Text = "Store copied items in a file in the user-scoped isolated storage";
            this.CheckStorage.UseVisualStyleBackColor = true;
            // 
            // LblDisclaimerText
            // 
            this.LblDisclaimerText.AutoSize = true;
            this.LblDisclaimerText.Location = new System.Drawing.Point(10, 119);
            this.LblDisclaimerText.Name = "LblDisclaimerText";
            this.LblDisclaimerText.Size = new System.Drawing.Size(428, 17);
            this.LblDisclaimerText.TabIndex = 11;
            this.LblDisclaimerText.Text = "Items are stored in a binary file without encryption. Use at own risk.";
            // 
            // LblDisclaimerHeader
            // 
            this.LblDisclaimerHeader.AutoSize = true;
            this.LblDisclaimerHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDisclaimerHeader.Location = new System.Drawing.Point(10, 102);
            this.LblDisclaimerHeader.Name = "LblDisclaimerHeader";
            this.LblDisclaimerHeader.Size = new System.Drawing.Size(83, 17);
            this.LblDisclaimerHeader.TabIndex = 8;
            this.LblDisclaimerHeader.Text = "Disclaimer";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadioHotKeyInsert);
            this.groupBox2.Controls.Add(this.RadioHotKeyControlInsert);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 94);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Activation";
            // 
            // RadioHotKeyInsert
            // 
            this.RadioHotKeyInsert.AutoSize = true;
            this.RadioHotKeyInsert.Location = new System.Drawing.Point(13, 65);
            this.RadioHotKeyInsert.Name = "RadioHotKeyInsert";
            this.RadioHotKeyInsert.Size = new System.Drawing.Size(64, 21);
            this.RadioHotKeyInsert.TabIndex = 7;
            this.RadioHotKeyInsert.TabStop = true;
            this.RadioHotKeyInsert.Text = "Insert";
            this.RadioHotKeyInsert.UseVisualStyleBackColor = true;
            // 
            // RadioHotKeyControlInsert
            // 
            this.RadioHotKeyControlInsert.AutoSize = true;
            this.RadioHotKeyControlInsert.Location = new System.Drawing.Point(13, 38);
            this.RadioHotKeyControlInsert.Name = "RadioHotKeyControlInsert";
            this.RadioHotKeyControlInsert.Size = new System.Drawing.Size(116, 21);
            this.RadioHotKeyControlInsert.TabIndex = 6;
            this.RadioHotKeyControlInsert.TabStop = true;
            this.RadioHotKeyControlInsert.Text = "CTRL + Insert";
            this.RadioHotKeyControlInsert.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Choose hotkey for activation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ComboMaxDisplayItems);
            this.groupBox1.Controls.Add(this.ComboMinDisplayItems);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 90);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display Items";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "items displayed in the list";
            // 
            // ComboMaxDisplayItems
            // 
            this.ComboMaxDisplayItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMaxDisplayItems.FormattingEnabled = true;
            this.ComboMaxDisplayItems.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.ComboMaxDisplayItems.Location = new System.Drawing.Point(51, 53);
            this.ComboMaxDisplayItems.Name = "ComboMaxDisplayItems";
            this.ComboMaxDisplayItems.Size = new System.Drawing.Size(56, 24);
            this.ComboMaxDisplayItems.TabIndex = 3;
            // 
            // ComboMinDisplayItems
            // 
            this.ComboMinDisplayItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMinDisplayItems.FormattingEnabled = true;
            this.ComboMinDisplayItems.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.ComboMinDisplayItems.Location = new System.Drawing.Point(51, 27);
            this.ComboMinDisplayItems.Name = "ComboMinDisplayItems";
            this.ComboMinDisplayItems.Size = new System.Drawing.Size(56, 24);
            this.ComboMinDisplayItems.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.GroupBoxStorageAndStartup, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 628);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.ComboMaxPreviewLines);
            this.groupBox6.Controls.Add(this.CheckPreviewEnabled);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 199);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(485, 82);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Item Preview";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "lines will at most be previewed";
            // 
            // ComboMaxPreviewLines
            // 
            this.ComboMaxPreviewLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMaxPreviewLines.FormattingEnabled = true;
            this.ComboMaxPreviewLines.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.ComboMaxPreviewLines.Location = new System.Drawing.Point(13, 49);
            this.ComboMaxPreviewLines.Name = "ComboMaxPreviewLines";
            this.ComboMaxPreviewLines.Size = new System.Drawing.Size(56, 24);
            this.ComboMaxPreviewLines.TabIndex = 3;
            // 
            // CheckPreviewEnabled
            // 
            this.CheckPreviewEnabled.AutoSize = true;
            this.CheckPreviewEnabled.Location = new System.Drawing.Point(13, 22);
            this.CheckPreviewEnabled.Name = "CheckPreviewEnabled";
            this.CheckPreviewEnabled.Size = new System.Drawing.Size(166, 21);
            this.CheckPreviewEnabled.TabIndex = 0;
            this.CheckPreviewEnabled.Text = "Preview selected item";
            this.CheckPreviewEnabled.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(501, 638);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackOpacity)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.GroupBoxStorageAndStartup.ResumeLayout(false);
            this.GroupBoxStorageAndStartup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar TrackOpacity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton RadioThemeBlue;
        private System.Windows.Forms.RadioButton RadioThemeGreen;
        private System.Windows.Forms.RadioButton RadioThemeDark;
        private System.Windows.Forms.RadioButton RadioThemeLight;
        private System.Windows.Forms.GroupBox GroupBoxStorageAndStartup;
        private System.Windows.Forms.CheckBox CheckStartOnBoot;
        private System.Windows.Forms.CheckBox CheckStorage;
        private System.Windows.Forms.Label LblDisclaimerText;
        private System.Windows.Forms.Label LblDisclaimerHeader;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RadioHotKeyInsert;
        private System.Windows.Forms.RadioButton RadioHotKeyControlInsert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboMaxDisplayItems;
        private System.Windows.Forms.ComboBox ComboMinDisplayItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboMaxPreviewLines;
        private System.Windows.Forms.CheckBox CheckPreviewEnabled;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboMaxItemsStored;
    }
}