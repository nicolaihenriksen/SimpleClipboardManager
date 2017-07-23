using SimpleClipboardManager.Model;
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
                    return Color.Gray;
                case Theme.Dark:
                    return Color.Black;
                case Theme.Green:
                    return Color.MediumSeaGreen;
            }
            return Color.Navy;
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
                    return Color.LightGray;
                case Theme.Dark:
                    return Color.FromArgb(50, 50, 50);
                case Theme.Green:
                    return Color.FromArgb(57, 121, 104);
            }
            return Color.MediumBlue;
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

    }
}
