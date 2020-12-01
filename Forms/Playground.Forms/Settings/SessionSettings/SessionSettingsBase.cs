using System.Collections.Generic;
using System.ComponentModel;

namespace Playground.Forms.Settings.SessionSettings
{
    public abstract class SessionSettingsBase : SettingsBase
    {
        protected SessionSettingsBase()
        {
            // Init settings
            Init();
        }

        /// <summary>
        /// Set default values
        /// </summary>
        /// <param name="props">Properties to set (default: null = all)</param>
        /// <param name="includeUnclearables" >Init all, including unclearable properties if true (default: true)</param>
        protected sealed override void Init(IList<PropertyDescriptor> props = null, bool includeUnclearables = true)
        {
            // Return to default values
            base.Init(props, includeUnclearables);
        }
    }
}
