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
        public int MaxStoredItems { get; set; } = 20;

        [DataMember]
        public bool StartOnBoot { get; set; }

        [DataMember]
        public Theme Theme { get; set; } = Theme.Blue;

        [DataMember]
        public double Opacity { get; set; } = 1;

        [DataMember]
        public bool ShowItemPreview { get; set; } = true;

        [DataMember]
        public int MaxPreviewLines { get; set; } = 3;

        [OnDeserializing]
        void OnDeserializing(StreamingContext context)
        {
            MinDisplayItems = 5;
            MaxDisplayItems = 20;
            HotKey = HotKey.ControlInsert;
            MaxStoredItems = 20;
            Theme = Theme.Blue;
            ShowItemPreview = true;
            MaxPreviewLines = 3;
        }
    }
}
