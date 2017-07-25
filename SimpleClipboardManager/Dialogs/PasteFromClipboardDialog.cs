using SimpleClipboardManager.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SimpleClipboardManager.Dialogs
{
    public partial class PasteFromClipboardDialog : Form
    {
        private ClipboardManager _manager;
        private readonly ContextMenuStrip _itemContextMenu;
        private List<ClipboardItem> _clipboardItems;
        private SettingsModel _settings;
        private ClipboardItem _selectedItem;
        private ToolStripMenuItem _menuItemMarkAsPassword;
        private ToolStripMenuItem _menuItemClearMarkAsPassword;
        private bool _previouslyActivated;

        public PasteFromClipboardDialog(ClipboardManager manager, List<ClipboardItem> items, SettingsModel settings, string activeAppTitle)
        {
            _manager = manager;
            _clipboardItems = items;
            _settings = settings;
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
            int displayedItemCount = Math.Min(_manager.Settings.MaxDisplayItems, items.Count);
            displayedItemCount = Math.Max(_manager.Settings.MinDisplayItems, displayedItemCount) + 2;
            Height = (int)tableLayoutPanel1.RowStyles[0].Height                 // Title header
                + (int)tableLayoutPanel3.RowStyles[1].Height                    // Hint pane
                + (displayedItemCount * clipboardItemList.ItemHeight) - 14;     // Item list
            Region = Region.FromHrgn(SafeNativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 31, 31));
            LblPasteAppName.Text = "Pasting into: " + activeAppTitle;

            _itemContextMenu = new ContextMenuStrip();
            _itemContextMenu.Items.Add(_menuItemMarkAsPassword = new ToolStripMenuItem { Text = "Mark as password..." });
            _itemContextMenu.Items.Add(_menuItemClearMarkAsPassword = new ToolStripMenuItem { Text = "Unmark as password" });

            _menuItemMarkAsPassword.Click += (s, e) =>
            {
                var dialog = new MarkAsPasswordDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var displayText = string.IsNullOrWhiteSpace(dialog.DisplayText) ? "********" : dialog.DisplayText;
                    _selectedItem?.MarkAsPassword(displayText);
                    _manager.SaveClipboard();
                    clipboardItemList.Items[clipboardItemList.SelectedIndex] = _selectedItem;
                }
            };
            _menuItemClearMarkAsPassword.Click += (s, e) =>
            {
                _selectedItem?.UnmarkAsPassword();
                _manager.SaveClipboard();
                clipboardItemList.Items[clipboardItemList.SelectedIndex] = _selectedItem;
            };

            clipboardItemList.MouseDown += ClipboardItemList_MouseDown;
            clipboardItemList.MouseDoubleClick += ClipboardItemList_MouseDoubleClick;
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
                + "CTRL+Enter = Show context menu for selected element";
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
            var index = clipboardItemList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches && index == clipboardItemList.SelectedIndex)
            {
                Paste();
            }
        }

        private void PopulateList()
        {
            clipboardItemList.Items.Clear();
            if (_clipboardItems != null)
                foreach (var item in _clipboardItems)
                    clipboardItemList.Items.Add(item);
        }

        private void ContextMenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode & Keys.Escape) == Keys.Escape)
            {
                Close();
            }

            if (clipboardItemList.SelectedIndex == ListBox.NoMatches)
                return;

            if ((e.KeyCode & Keys.Enter) == Keys.Enter)
            {
                if (ModifierKeys == Keys.Control)
                    ShowContextMenu(false);
                else
                    Paste();
            }
            else if ((e.KeyCode & Keys.Up) == Keys.Up && ModifierKeys == Keys.Control)
            {
                MoveSelectedItem(-1);
            }
            else if ((e.KeyCode & Keys.Down) == Keys.Down && ModifierKeys == Keys.Control)
            {
                MoveSelectedItem(1);
            }
            else if ((e.KeyCode & Keys.Delete) == Keys.Delete)
            {
                var selectedItem = clipboardItemList.SelectedItem as ClipboardItem;
                if (selectedItem != null)
                {
                    var selectedIndex = clipboardItemList.SelectedIndex;
                    clipboardItemList.Items.Remove(selectedItem);
                    _clipboardItems.Remove(selectedItem);
                    if (selectedIndex > clipboardItemList.Items.Count - 1)
                        clipboardItemList.SelectedIndex = clipboardItemList.Items.Count - 1;
                    else if (clipboardItemList.Items.Count > 0)
                        clipboardItemList.SelectedIndex = selectedIndex;
                    _manager.SaveClipboard();
                }
            }
        }

        private void MoveSelectedItem(int places)
        {
            if (places == 0)
                return;

            _selectedItem = clipboardItemList.SelectedItem as ClipboardItem;
            if (_selectedItem != null)
            {
                var currentIndex = _clipboardItems.IndexOf(_selectedItem);
                if ((places > 0 && currentIndex + places > _clipboardItems.Count - 1) || (places < 0 && currentIndex + places < 0))
                    return;

                _clipboardItems.Remove(_selectedItem);
                var newIndex = currentIndex + places;
                _clipboardItems.Insert(newIndex, _selectedItem);
                _manager.SaveClipboard();
                PopulateList();
                clipboardItemList.SelectedIndex = newIndex - places;
            }
        }

        private void ClipboardItemList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = clipboardItemList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches && index == clipboardItemList.SelectedIndex)
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
            _selectedItem = clipboardItemList.SelectedItem as ClipboardItem;
            if (_selectedItem != null)
            {
                _menuItemMarkAsPassword.Visible = !_selectedItem.IsPassword;
                _menuItemClearMarkAsPassword.Visible = _selectedItem.IsPassword;

                var point = Cursor.Position;
                if (!showAtMousePointer)
                {
                    var rect = clipboardItemList.GetItemRectangle(clipboardItemList.SelectedIndex);
                    point = new Point(rect.Left + 20, rect.Top + clipboardItemList.ItemHeight / 2);
                    point = clipboardItemList.PointToScreen(point);
                }
                _itemContextMenu.Show(point);
                _itemContextMenu.Visible = true;
            }
        }

        private void HighlightFistClipboardItem()
        {
            clipboardItemList.Focus();
            if (clipboardItemList.Items.Count > 0)
                clipboardItemList.SelectedIndex = 0;
        }

        public void BringInFocus()
        {
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
            ClipboardNotification.SuppressNextEvent();
            var text = (clipboardItemList.SelectedItem as ClipboardItem)?.Text;
            if (!string.IsNullOrEmpty(text))
            {
                var paster = new Paster { Text = text };
                Thread thread = new Thread(paster.DoPaste);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                Hide();
                SendKeys.Send("^v");
            }
            Close();
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
            _clipboardItems.Clear();
            clipboardItemList.Items.Clear();
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
