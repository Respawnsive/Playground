using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Playground.Forms.Settings.AppSettings
{
    public class TheMovieDbSettings : AppSettingsBase
    {
        public string BaseUrl { get; private set; }
        public string MoviePath { get; private set; }
        public string ReadAccessToken { get; private set; }

        public string MovieBaseUrl => Path.Combine(BaseUrl, MoviePath);
    }
}
