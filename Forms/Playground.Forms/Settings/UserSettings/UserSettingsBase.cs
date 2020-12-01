using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive.Linq;
using Shiny;
using Shiny.Settings;

namespace Playground.Forms.Settings.UserSettings
{
    /// <summary>
    /// Will sync user settings properties with device preferences key value entries
    /// Will notify property changed
    /// On Clear() calls, will return to default attribute value when decorated with DefaultValueAttribute or to default type value if not,
    /// excepted for those decorated with UnclearableAttribute
    /// Will save in a secure encrypted way if decorated with Secure attribute
    /// </summary>
    public abstract class UserSettingsBase : SettingsBase
    {
        private readonly ISettings _settings;

        protected UserSettingsBase()
        {
            // This one can't be injected as constructor must be parameter-less
            _settings = ShinyHost.Resolve<ISettings>();

            // Init settings
            Init();

            // Observe global clearing to set local properties back to default values
            _settings.Changed
                .Where(x => x.Action == SettingChangeAction.Clear)
                .Subscribe(_ => Reset());
        }

        /// <summary>
        /// Set default values and enable settings sync
        /// </summary>
        /// <param name="props">Properties to set (default: null = all)</param>
        /// <param name="includeUnclearables" >Init all, including unclearable properties if true (default: true)</param>
        protected sealed override void Init(IList<PropertyDescriptor> props = null, bool includeUnclearables = true)
        {
            // Return to default values
            base.Init(props, includeUnclearables);

            // Enable settings sync back
            _settings.Bind(this);
        }

        /// <summary>
        /// Return to default values
        /// </summary>
        /// <param name="props">Properties to set (default: null = all)</param>
        /// <param name="includeUnclearables" >Init all, including unclearable properties if true (default: true)</param>
        protected override void Reset(IList<PropertyDescriptor> props = null, bool includeUnclearables = true)
        {
            // Get all editable properties if null
            if (props == null)
                props = GetEditableProperties(includeUnclearables);

            // Iterate through each clearable property
            foreach (var prop in props)
                // Clear property if clearable
                _settings.Remove($"{GetType().FullName}.{prop.Name}");

            // Disable settings sync while returning to default
            _settings.UnBind(this);

            // Return to default values and enable settings sync back
            base.Reset(props, includeUnclearables);
        }
    }
}