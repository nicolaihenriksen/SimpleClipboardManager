using SimpleClipboardManager.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleClipboardManager.Dialogs
{
    internal partial class PasteFromClipboardDialog : Form
    {
        private ClipboardManager _manager;
        private readonly ContextMenuStrip _itemContextMenu;
        private ClipboardItem _selectedItem;
        private ToolStripMenuItem _menuItemMarkAsPassword;
        private ToolStripMenuItem _menuItemClearMarkAsPassword;
        private ToolStripMenuItem _menuItemMarkAsFavorite;
        private ToolStripMenuItem _menuItemClearMarkAsFavorite;
        
        private bool _previouslyActivated;

        public PasteFromClipboardDialog(ClipboardManager manager, string activeAppTitle)
        {
            _manager = manager;
            InitializeComponent();
            PopulateList();
            Activated += (s, a) =>
            {
                BringInFocus();
                if (!_previouslyActivated)
                    HighlightFistClipboardItem();
                _previouslyActivated = true;
            };
            FormBorderStyle = FormBorderStyle.None;
            //Opacity = 0.9;
            UpdateTheme(_manager.Settings.Theme, _manager.Settings.Opacity);
            int displayedItemCount = Math.Min(_manager.Settings.MaxDisplayItems, _manager.ClipboardItems.Count);
            displayedItemCount = Math.Max(_manager.Settings.MinDisplayItems, displayedItemCount) + 2;
            Height = (int)tableLayoutPanel1.RowStyles[0].Height                 // Title header
                + (int)tableLayoutPanel3.RowStyles[1].Height                    // Hint pane
                + (displayedItemCount * ClipboardItemList.ItemHeight) - 14;     // Item list
            Region = Region.FromHrgn(SafeNativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 31, 31));
            LblPasteAppName.Text = "Pasting into: " + activeAppTitle;

            _itemContextMenu = new ContextMenuStrip();
            _itemContextMenu.Items.Add(_menuItemMarkAsPassword = new ToolStripMenuItem { Text = "Mark as password..." });
            _itemContextMenu.Items.Add(_menuItemClearMarkAsPassword = new ToolStripMenuItem { Text = "Unmark as password" });
            _itemContextMenu.Items.Add(_menuItemMarkAsFavorite = new ToolStripMenuItem { Text = "Mark as favorite..." });
            _itemContextMenu.Items.Add(_menuItemClearMarkAsFavorite = new ToolStripMenuItem());

            _menuItemMarkAsPassword.Click += (s, e) =>
            {
                var dialog = new MarkAsPasswordDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var displayText = string.IsNullOrWhiteSpace(dialog.DisplayText) ? "********" : dialog.DisplayText;
                    _selectedItem?.MarkAsPassword(displayText);
                    _manager.SaveClipboard();
                    // Update the UI
                    ClipboardItemList.Items[ClipboardItemList.SelectedIndex] = _selectedItem;
                }
            };
            _menuItemClearMarkAsPassword.Click += (s, e) =>
            {
                _selectedItem?.UnmarkAsPassword();
                _manager.SaveClipboard();
                // Update the UI
                ClipboardItemList.Items[ClipboardItemList.SelectedIndex] = _selectedItem;
            };
            _menuItemMarkAsFavorite.Click += (s, e) =>
            {
                var dialog = new MarkAsFavoriteDialog(_manager, _selectedItem);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _manager.ClipboardItems.ForEach(ci =>
                    {
                        if (ci.Favorite == dialog.FavoriteKey)
                            ci.UnmarkAsFavorite();
                    });
                    _selectedItem.Favorite = dialog.FavoriteKey;
                    _manager.SaveClipboard();
                    // Update the UI
                    ClipboardItemList.Items[ClipboardItemList.SelectedIndex] = _selectedItem;
                }
            };
            _menuItemClearMarkAsFavorite.Click += (s, e) =>
            {
                _selectedItem?.UnmarkAsFavorite();
                _manager.SaveClipboard();
                // Update the UI
                ClipboardItemList.Items[ClipboardItemList.SelectedIndex] = _selectedItem;
            };

            ClipboardItemList.MouseDown += ClipboardItemList_MouseDown;
            ClipboardItemList.MouseDoubleClick += ClipboardItemList_MouseDoubleClick;
            KeyPreview = true;
            KeyDown += ContextMenuForm_KeyDown;

            BtnClose.Tag = "Hide";
            BtnSettings.Tag = "Show settings";
            BtnClear.Tag = "Clear list";

            LblHints.Text = "Enter = Paste selected element"
                + Environment.NewLine
                + "Delete = Remove selected element"
                + Environment.NewLine
                + "CTRL+Up/Down = Move selected element"
                + Environment.NewLine
                + "CTRL+Enter = Show context menu for selected element"
                + Environment.NewLine
                + "CTRL+SHIFT+digit(1-9) = Paste the n'th element (only first 9)"
                + Environment.NewLine
                + "CTRL+SHIFT+FKey(1-12) = Paste the n'th favorite";
        }

        public void UpdateTheme(Theme theme, double opacity)
        {
            BackColor = ThemeResources.GetTitleBackColor(theme);
            ForeColor = ThemeResources.GetTitleForeColor(theme);
            ContentPanel.BackgroundColor = ThemeResources.GetContentBackColor(theme);
            ContentPanel.ForeColor = ThemeResources.GetContentForeColor(theme);
            BtnClose.Image = ThemeResources.GetCloseButtonIcon(theme);
            BtnSettings.Image = ThemeResources.GetSettingsButtonIcon(theme);
            BtnClear.Image = ThemeResources.GetClearButtonIcon(theme);
            Opacity = opacity;
        }

        private void ClipboardItemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var index = ClipboardItemList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches && index == ClipboardItemList.SelectedIndex)
            {
                Paste();
            }
        }

        private void PopulateList()
        {
            ClipboardItemList.Items.Clear();
            if (_manager.ClipboardItems != null)
                foreach (var item in _manager.ClipboardItems)
                    ClipboardItemList.Items.Add(item);
        }

        private void ContextMenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (ClipboardItemList.SelectedIndex == ListBox.NoMatches)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                if (ModifierKeys == Keys.Control)
                    ShowContextMenu(false);
                else
                    Paste();
            }
            else if (e.KeyCode == Keys.Up && ModifierKeys == Keys.Control)
            {
                MoveSelectedItem(-1);
            }
            else if (e.KeyCode == Keys.Down && ModifierKeys == Keys.Control)
            {
                MoveSelectedItem(1);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                var selectedItem = ClipboardItemList.SelectedItem as ClipboardItem;
                if (selectedItem != null)
                {
                    var selectedIndex = ClipboardItemList.SelectedIndex;
                    ClipboardItemList.Items.Remove(selectedItem);
                    _manager.ClipboardItems.Remove(selectedItem);
                    if (selectedIndex > ClipboardItemList.Items.Count - 1)
                        ClipboardItemList.SelectedIndex = ClipboardItemList.Items.Count - 1;
                    else if (ClipboardItemList.Items.Count > 0)
                        ClipboardItemList.SelectedIndex = selectedIndex;
                    _manager.SaveClipboard();
                }
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                // Suppress left and right arrows as these will auto-translate to a new key event for up and down respectively
                // which will cause the above code to start moving the wrong items around.
                e.SuppressKeyPress = true;
            }
        }

        private void MoveSelectedItem(int places)
        {
            if (places == 0)
                return;

            _selectedItem = ClipboardItemList.SelectedItem as ClipboardItem;
            if (_selectedItem != null)
            {
                var currentIndex = _manager.ClipboardItems.IndexOf(_selectedItem);
                if ((places > 0 && currentIndex + places > _manager.ClipboardItems.Count - 1) || (places < 0 && currentIndex + places < 0))
                    return;

                _manager.ClipboardItems.Remove(_selectedItem);
                var newIndex = currentIndex + places;
                _manager.ClipboardItems.Insert(newIndex, _selectedItem);
                _manager.SaveClipboard();
                PopulateList();
                ClipboardItemList.SelectedIndex = newIndex - places;
            }
        }

        private void ClipboardItemList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = ClipboardItemList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches && index == ClipboardItemList.SelectedIndex)
            {
                ShowContextMenu();
            }
            else
            {
                _itemContextMenu.Visible = false;
            }
        }

        private void ShowContextMenu(bool showAtMousePointer = true)
        {
            _selectedItem = ClipboardItemList.SelectedItem as ClipboardItem;
            if (_selectedItem != null)
            {
                _menuItemMarkAsPassword.Visible = !_selectedItem.IsPassword;
                _menuItemClearMarkAsPassword.Visible = _selectedItem.IsPassword;
                _menuItemMarkAsFavorite.Visible = !_selectedItem.Favorite.HasValue;
                _menuItemClearMarkAsFavorite.Visible = _selectedItem.Favorite.HasValue;
                if (_selectedItem.Favorite.HasValue)
                    _menuItemClearMarkAsFavorite.Text = $"Unmark as favorite (F{_selectedItem.Favorite.Value + 1})";

                var point = Cursor.Position;
                if (!showAtMousePointer)
                {
                    var rect = ClipboardItemList.GetItemRectangle(ClipboardItemList.SelectedIndex);
                    point = new Point(rect.Left + 20, rect.Top + ClipboardItemList.ItemHeight / 2);
                    point = ClipboardItemList.PointToScreen(point);
                }
                _itemContextMenu.Show(point);
                _itemContextMenu.Visible = true;
            }
        }

        private void HighlightFistClipboardItem()
        {
            ClipboardItemList.Focus();
            if (ClipboardItemList.Items.Count > 0)
                ClipboardItemList.SelectedIndex = 0;
        }

        public void BringInFocus()
        {
            var selectedItem = ClipboardItemList.SelectedItem;
            PopulateList();
            if (selectedItem != null)
                ClipboardItemList.SelectedItem = selectedItem;
            TopMost = true;
            TopMost = false;
            BringToFront();
            Activate();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Paste()
        {
            var text = (ClipboardItemList.SelectedItem as ClipboardItem)?.Text;
            _manager.Paste(text, Hide);
        }

        private class Paster
        {
            public string Text { get; set; }

            public void DoPaste()
            {
                Clipboard.SetText(Text);
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var dialog = new SettingsDialog(this, _manager.Settings);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _manager.SaveSettings();
            }
            UpdateTheme(_manager.Settings.Theme, _manager.Settings.Opacity);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _manager.ClipboardItems.Clear();
            ClipboardItemList.Items.Clear();
            _manager.SaveClipboard();
        }

        private void TitleButton_Hover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            var ctrl = sender as Control;
            if (ctrl != null)
                tt.SetToolTip(ctrl, ctrl.Tag?.ToString());
        }
    }
}
