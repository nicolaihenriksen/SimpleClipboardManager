using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    public partial class ContextMenuForm : Form
    {
        private ClipboardManager _manager;

        private readonly ContextMenuStrip _itemContextMenu;

        private List<ClipboardItem> _items;

        private ClipboardItem _selectedItem;

        private ToolStripMenuItem _menuItemMarkAsPassword;

        private ToolStripMenuItem _menuItemClearMarkAsPassword;

        private bool _previouslyActivated;

        public ContextMenuForm(ClipboardManager manager, List<ClipboardItem> items)
        {
            _manager = manager;
            _items = items;
            InitializeComponent();
            if (items != null)
                foreach (var item in items)
                    clipboardItemList.Items.Add(item);
            Activated += (s, a) =>
            {
                BringInFocus();
                if (!_previouslyActivated)
                    HighlightFistClipboardItem();
                _previouslyActivated = true;
            };
            TransparencyKey = System.Drawing.Color.Lime;
            //Opacity = 0.85;
            BackColor = System.Drawing.Color.Lime;
            int displayedItemCount = Math.Min(7, items.Count) + 1;
            Height = (int)tableLayoutPanel1.RowStyles[0].Height + (displayedItemCount * clipboardItemList.ItemHeight);
            Region = System.Drawing.Region.FromHrgn(SafeNativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 11, 11));

            _itemContextMenu = new ContextMenuStrip();
            _itemContextMenu.Items.Add(_menuItemMarkAsPassword = new ToolStripMenuItem { Text = "Mark as password..." });
            _itemContextMenu.Items.Add(_menuItemClearMarkAsPassword = new ToolStripMenuItem { Text = "Unmark as password" });

            _menuItemMarkAsPassword.Click += (s, e) =>
            {
                _selectedItem?.MarkAsPassword("My password");
                _manager.SaveClipboard();
                clipboardItemList.Items[clipboardItemList.SelectedIndex] = _selectedItem;
            };
            _menuItemClearMarkAsPassword.Click += (s, e) =>
            {
                _selectedItem?.UnmarkAsPassword();
                _manager.SaveClipboard();
                clipboardItemList.Items[clipboardItemList.SelectedIndex] = _selectedItem;
            };

            clipboardItemList.MouseDown += ClipboardItemList_MouseDown;
            KeyPreview = true;
            KeyDown += ContextMenuForm_KeyDown;
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
                Paste();
            }
            else if ((e.KeyCode & Keys.Delete) == Keys.Delete)
            {
                var selectedItem = clipboardItemList.SelectedItem as ClipboardItem;
                if (selectedItem != null)
                {
                    var selectedIndex = clipboardItemList.SelectedIndex;
                    clipboardItemList.Items.Remove(selectedItem);
                    _items.Remove(selectedItem);
                    if (selectedIndex > clipboardItemList.Items.Count - 1)
                        clipboardItemList.SelectedIndex = clipboardItemList.Items.Count - 1;
                    else if (clipboardItemList.Items.Count > 0)
                        clipboardItemList.SelectedIndex = selectedIndex;
                    _manager.SaveClipboard();
                }
            }
        }

        private void ClipboardItemList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = clipboardItemList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches && index == clipboardItemList.SelectedIndex)
            {
                _selectedItem = clipboardItemList.Items[index] as ClipboardItem;

                _menuItemMarkAsPassword.Visible = !_selectedItem.IsPassword;
                _menuItemClearMarkAsPassword.Visible = _selectedItem.IsPassword;

                _itemContextMenu.Show(Cursor.Position);
                _itemContextMenu.Visible = true;
            }
            else
            {
                _itemContextMenu.Visible = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void Paste()
        {
            ClipboardNotification.SuppressNextEvent();
            var text = (clipboardItemList.SelectedItem as ClipboardItem)?.Text;
            if (!string.IsNullOrEmpty(text))
            {
                var paster = new Paster { Text = text };
                Thread thread = new Thread(paster.DoPaste);
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
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

        private void button3_Click(object sender, EventArgs e)
        {
            _manager.SaveClipboard();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _manager.LoadClipboard();
        }
    }
}
