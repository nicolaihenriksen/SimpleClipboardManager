using System;

namespace SimpleClipboardManager
{
    [Serializable]
    public class ClipboardItem
    {
        public string Text { get; set; }

        public string DisplayText { get; set; }

        public bool IsPassword { get; set; }

        public void MarkAsPassword(string displayText = null)
        {
            IsPassword = true;
            if (!string.IsNullOrEmpty(displayText))
            {
                DisplayText = displayText;
            }
        }

        public void UnmarkAsPassword()
        {
            IsPassword = false;
            DisplayText = null;
        }

        public override string ToString()
        {
            return DisplayText ?? Text;
        }
    }
}
