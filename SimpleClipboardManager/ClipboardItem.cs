using System;

namespace SimpleClipboardManager
{
    [Serializable]
    public class ClipboardItem
    {
        public string Text { get; set; }

        public string DisplayText { get; set; }

        public bool IsPassword { get; set; }

        public int? Favorite { get; set; }

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

        public void UnmarkAsFavorite()
        {
            Favorite = null;
        }

        public override string ToString()
        {
            var text = DisplayText ?? Text;
            if (Favorite.HasValue)
            {
                text = $"[F{Favorite.Value + 1}] " + text;
            }
            return text;
        }
    }
}
