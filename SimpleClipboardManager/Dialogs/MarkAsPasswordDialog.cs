using System;
using System.Windows.Forms;

namespace SimpleClipboardManager.Dialogs
{
    public partial class MarkAsPasswordDialog : Form
    {

        public string DisplayText { get; set; } = "My Password";

        private bool _firstCallToTextChanged = true;

        public MarkAsPasswordDialog()
        {
            InitializeComponent();
            TxtDisplayText.Select();
            TxtDisplayText.DataBindings.Add(new Binding("Text", this, nameof(DisplayText)));
            TxtDisplayText.TextChanged += TxtDisplayText_TextChanged;
        }

        private void TxtDisplayText_TextChanged(object sender, EventArgs e)
        {
            if (!_firstCallToTextChanged)
            {
                var useDisplayText = !string.IsNullOrWhiteSpace(TxtDisplayText.Text);
                RadioMasked.Checked = !useDisplayText;
                RadioDisplayText.Checked = useDisplayText;
            }
            _firstCallToTextChanged = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (RadioMasked.Checked)
                DisplayText = null;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
