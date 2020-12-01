namespace Playground.Forms.Settings.AppSettings
{
    public class AppCenterSettings : AppSettingsBase
    {
        public string Secret { get; private set; }
        public bool TrackCrashes { get; private set; }
        public bool TrackEvents { get; private set; }
    }
}
