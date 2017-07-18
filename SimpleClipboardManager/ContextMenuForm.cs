using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleClipboardManager
{
    public partial class ContextMenuForm : Form
    {
        public ContextMenuForm(IEnumerable<string> items)
        {
            InitializeComponent();
            if (items != null)
                foreach (var item in items)
                    listBox1.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listBox1.SelectedItem as string);
            Hide();
            SendKeys.Send("^v");
            Close();
        }
    }
}
