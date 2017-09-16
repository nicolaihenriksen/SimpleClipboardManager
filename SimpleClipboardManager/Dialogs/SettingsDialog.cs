using SimpleClipboardManager.Model;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleClipboardManager.Dialogs
{
    internal partial class SettingsDialog : Form
    {
        private ClipboardManager _manager;
        private PasteFromClipboardDialog _pasteFromClipboardDialog;
        private SettingsModel _model;
        private int _lastMaxStoredItemsValue;

        public SettingsDialog(PasteFromClipboardDialog pasteFromClipboardDialog, ClipboardManager manager)
        {
            InitializeComponent();
            _manager = manager;
            _pasteFromClipboardDialog = pasteFromClipboardDialog;
            _model = _manager.Settings;
            PopulateViewFromModel();

            // Wire up dynamic content (i.e. properties that modify the visual appearance for immediate preview)
            RadioThemeLight.CheckedChanged += DynamicContentChanged;
            RadioThemeDark.CheckedChanged += DynamicContentChanged;
            RadioThemeGreen.CheckedChanged += DynamicContentChanged;
            RadioThemeBlue.CheckedChanged += DynamicContentChanged;
            TrackOpacity.ValueChanged += DynamicContentChanged;

            ComboMaxItemsStored.SelectedValueChanged += ComboMaxItemsStored_SelectedValueChanged;

            ModifyLayoutBasedOnAppType();
        }

        private void ComboMaxItemsStored_SelectedValueChanged(object sender, EventArgs e)
        {
            var max = Convert.ToInt32(ComboMaxItemsStored.SelectedItem);
            if (_manager.ClipboardItems.Count <= max)
            {
                _lastMaxStoredItemsValue = max;
                return;
            }
            var numToDelete = _manager.ClipboardItems.Count - max;
            var result = MessageBox.Show(this, $"The {numToDelete} oldest, non-favorite, items will be deleted, are you sure you wish to continue?", "Items will be deleted", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _lastMaxStoredItemsValue = max;
                return;
            }
            if (max != _lastMaxStoredItemsValue)
                ComboMaxItemsStored.SelectedItem = "" + _lastMaxStoredItemsValue;
        }

        private void ModifyLayoutBasedOnAppType()
        {
            if (IsRunningAsUwp())
            {
                GroupBoxStorageAndStartup.Text = "Storage";
                CheckStartOnBoot.Visible = false;
                var removedPixels = CheckStartOnBoot.Height + 4;
                LblDisclaimerHeader.Top -= removedPixels;
                LblDisclaimerText.Top -= removedPixels;
                tableLayoutPanel1.RowStyles[3].Height -= removedPixels;
                Height -= removedPixels;
            }
        }

        private bool IsRunningAsUwp()
        {
            if (!OsSupportsUwp())
                return false;
            int length = 0;
            StringBuilder sb = new StringBuilder(0);
            var result = SafeNativeMethods.GetCurrentPackageFullName(ref length, sb);
            sb = new StringBuilder(length);
            result = SafeNativeMethods.GetCurrentPackageFullName(ref length, sb);
            return result != SafeNativeMethods.APPMODEL_ERROR_NO_PACKAGE;
        }

        private bool OsSupportsUwp()
        {
            var major = Environment.OSVersion.Version.Major;
            var minor = Environment.OSVersion.Version.Minor;
            double version = major + (double)minor / 10;
            return version > 6.1;
        }

        private void PopulateViewFromModel()
        {
            ComboMinDisplayItems.SelectedItem = "" + _model.MinDisplayItems;
            ComboMaxDisplayItems.SelectedItem = "" + _model.MaxDisplayItems;
            RadioHotKeyControlInsert.Checked = _model.HotKey == HotKey.ControlInsert;
            RadioHotKeyInsert.Checked = _model.HotKey == HotKey.Insert;
            CheckPreviewEnabled.Checked = _model.ShowItemPreview;
            ComboMaxPreviewLines.SelectedItem = "" + _model.MaxPreviewLines;
            CheckStorage.Checked = _model.StorageEnabled;
            ComboMaxItemsStored.SelectedItem = "" + _model.MaxStoredItems;
            _lastMaxStoredItemsValue = _model.MaxStoredItems;
            CheckStartOnBoot.Checked = _model.StartOnBoot;
            RadioThemeLight.Checked = _model.Theme == Theme.Light;
            RadioThemeDark.Checked = _model.Theme == Theme.Dark;
            RadioThemeGreen.Checked = _model.Theme == Theme.Green;
            RadioThemeBlue.Checked = _model.Theme == Theme.Blue;
            TrackOpacity.Value = (int)(_model.Opacity * 100);            
        }

        private void DynamicContentChanged(object sender, EventArgs e)
        {
            _pasteFromClipboardDialog?.UpdateTheme(GetTheme(), GetOpacity());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            PopulateModelFromView();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PopulateModelFromView()
        {
            _model.MinDisplayItems = Convert.ToInt32(ComboMinDisplayItems.SelectedItem);
            _model.MaxDisplayItems = Convert.ToInt32(ComboMaxDisplayItems.SelectedItem);
            _model.HotKey = RadioHotKeyControlInsert.Checked ? HotKey.ControlInsert : HotKey.Insert;
            _model.ShowItemPreview = CheckPreviewEnabled.Checked;
            _model.MaxPreviewLines = Convert.ToInt32(ComboMaxPreviewLines.SelectedItem);
            _model.StorageEnabled = CheckStorage.Checked;
            _model.MaxStoredItems = Convert.ToInt32(ComboMaxItemsStored.SelectedItem);
            _model.StartOnBoot = !IsRunningAsUwp() && CheckStartOnBoot.Checked;
            _model.Opacity = GetOpacity();
            _model.Theme = GetTheme();
        }

        private Theme GetTheme()
        {
            if (RadioThemeLight.Checked)
                return Theme.Light;
            if (RadioThemeDark.Checked)
                return Theme.Dark;
            if (RadioThemeGreen.Checked)
                return Theme.Green;
            return Theme.Blue;
        }

        private double GetOpacity()
        {
            return (double)TrackOpacity.Value / 100;
        }
    }
}
