using System.Runtime.Serialization;

namespace SimpleClipboardManager.Model
{
    public enum Theme
    {
        Light,
        Dark,
        Green,
        Blue
    }

    public enum HotKey
    {
        ControlInsert,
        Insert
    }

    [DataContract]
    public class SettingsModel
    {
        [DataMember]
        public int MinDisplayItems { get; set; } = 5;

        [DataMember]
        public int MaxDisplayItems { get; set; } = 20;

        [DataMember]
        public HotKey HotKey { get; set; } = HotKey.ControlInsert;

        [DataMember]
        public bool StorageEnabled { get; set; }

        [DataMember]
        public bool StartOnBoot { get; set; }

        [DataMember]
        public Theme Theme { get; set; } = Theme.Green;

        [DataMember]
        public double Opacity { get; set; } = 1;
    }
}
