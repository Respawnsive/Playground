using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Forms.Settings.AppSettings
{
    public class TheMovieDbSettings : AppSettingsBase
    {
        public string Url { get; private set; }
        public string ReadAccessToken { get; private set; }
    }
}
