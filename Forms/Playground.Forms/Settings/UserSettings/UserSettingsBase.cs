using System;
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
    public abstract class UserSettingsBase : EditableSettingsBase
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
                .Subscribe(_ => OnGlobalClearing());
        }

        /// <summary>
        /// Set default values and enable settings sync
        /// </summary>
        protected sealed override void Init()
        {
            // Set to default values
            SetDefaultValues();

            // Enable settings sync
            _settings.Bind(this);
        }

        /// <summary>
        /// Clear saved settings and set it back to default values
        /// </summary>
        /// <param name="includeUnclearables" >Clear all, including unclearable properties if true (default: false)</param>
        public override void Clear(bool includeUnclearables = false)
        {
            // Get all editable properties
            var props = GetEditableProperties(includeUnclearables);

            // Iterate through each clearable property
            foreach (var prop in props)
                // Clear property if clearable
                _settings.Remove($"{GetType().FullName}.{prop.Name}");

            // Disable settings sync while returning to default
            _settings.UnBind(this);

            // Return to default values
            SetDefaultValues(props);

            // Enable settings sync back
            _settings.Bind(this);
        }

        /// <summary>
        /// Return to default values
        /// </summary>
        private void OnGlobalClearing()
        {
            // Disable settings sync while returning to default
            _settings.UnBind(this);

            // Return to default values
            SetDefaultValues();

            // Enable settings sync back
            _settings.Bind(this);
        }
    }
}