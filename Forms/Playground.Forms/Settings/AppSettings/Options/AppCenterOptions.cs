using System.ComponentModel.DataAnnotations;

namespace Playground.Forms.Settings.AppSettings.Options
{
    public class AppCenterOptions
    {
        public string Secret { get; set; }
        public bool TrackCrashes { get; set; }
        public bool TrackEvents { get; set; }
    }
}
