using System;
using System.Linq;
using System.Windows.Forms;

namespace SimpleClipboardManager.Dialogs
{
    internal partial class MarkAsFavoriteDialog : Form
    {
        private ClipboardManager _manager;

        public int? FavoriteKey { get; private set; }

        public MarkAsFavoriteDialog(ClipboardManager manager, ClipboardItem currentItem)
        {
            InitializeComponent();
            _manager = manager;
            PopulateView(currentItem);
        }

        private void PopulateView(ClipboardItem currentItem)
        {
            for (var i = 0; i < 12; i++)
            {
                var occupied = _manager.ClipboardItems.Any(ci => ci != currentItem && ci.Favorite == i);
                var item = new ComboBoxItem { Value = i, Text = "F" + (i + 1), Occupied = occupied };
                ComboFavorites.Items.Add(item);
            }
            ComboFavorites.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            var item = (ComboFavorites.SelectedItem as ComboBoxItem);
            if (item != null) {
                if (item.Occupied)
                    if (MessageBox.Show($"Are you sure you wish to overwrite the favorite at F{item.Value + 1}?", "Overwrite", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                FavoriteKey = (ComboFavorites.SelectedItem as ComboBoxItem)?.Value;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    internal class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public bool Occupied { get; set; }

        public override string ToString()
        {
            return Text + (Occupied ? "  --  In use" : "");
        }
    }

}
