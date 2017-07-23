using SimpleClipboardManager.Model;
using SimpleClipboardManager.Properties;
using System.Drawing;

namespace SimpleClipboardManager
{
    class ThemeResources
    {

        public static Color GetTitleBackColor(Theme theme)
        {
            switch (theme)
            {
                case Theme.Light:
                    return Color.LightGray;
                case Theme.Dark:
                    return Color.FromArgb(50, 50, 50);
                case Theme.Green:
                    return Color.MediumSeaGreen;
            }
            return Color.MediumBlue;
        }

        public static Color GetTitleForeColor(Theme theme)
        {
            switch (theme)
            {
                case Theme.Light:
                    return Color.Black;
            }
            return Color.WhiteSmoke;
        }

        public static Color GetContentBackColor(Theme theme)
        {
            switch (theme)
            {
                case Theme.Light:
                    return Color.FromArgb(180, 180, 180);
                case Theme.Dark:
                    return Color.FromArgb(30, 30, 30);
                case Theme.Green:
                    return Color.FromArgb(57, 121, 104);
            }
            return Color.Navy;
        }

        public static Color GetContentForeColor(Theme theme)
        {
            switch (theme)
            {
                case Theme.Light:
                    return Color.Black;
            }
            return Color.WhiteSmoke;
        }

        public static Bitmap GetCloseButtonIcon(Theme theme)
        {
            return Resources.LightTheme_Close;
        }

        public static Bitmap GetSettingsButtonIcon(Theme theme)
        {
            return Resources.LightTheme_Settings;
        }

        public static Bitmap GetClearButtonIcon(Theme theme)
        {
            return Resources.LightTheme_Clear;
        }

    }
}
