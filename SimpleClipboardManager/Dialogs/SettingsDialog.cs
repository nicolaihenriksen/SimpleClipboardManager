using SimpleClipboardManager.Model;
using System;
using System.Windows.Forms;

namespace SimpleClipboardManager.Dialogs
{
    public partial class SettingsDialog : Form
    {
        private PasteFromClipboardDialog _pasteFromClipboardDialog;
        private SettingsModel _model;

        public SettingsDialog(PasteFromClipboardDialog pasteFromClipboardDialog, SettingsModel model)
        {
            InitializeComponent();
            _pasteFromClipboardDialog = pasteFromClipboardDialog;
            _model = model;
            PopulateViewFromModel();

            // Wire up dynamic content (i.e. properties that modify the visual appearance)
            RadioThemeLight.CheckedChanged += DynamicContentChanged;
            RadioThemeDark.CheckedChanged += DynamicContentChanged;
            RadioThemeGreen.CheckedChanged += DynamicContentChanged;
            RadioThemeBlue.CheckedChanged += DynamicContentChanged;
            TrackOpacity.ValueChanged += DynamicContentChanged;
        }

        private void PopulateViewFromModel()
        {
            ComboMinDisplayItems.SelectedItem = "" + _model.MinDisplayItems;
            ComboMaxDisplayItems.SelectedItem = "" + _model.MaxDisplayItems;
            RadioHotKeyControlInsert.Checked = _model.HotKey == HotKey.ControlInsert;
            RadioHotKeyInsert.Checked = _model.HotKey == HotKey.Insert;
            CheckStorage.Checked = _model.StorageEnabled;
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
            _model.StorageEnabled = CheckStorage.Checked;
            _model.StartOnBoot = CheckStartOnBoot.Checked;
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
