namespace Playground.Forms.Settings.SessionSettings
{
    public abstract class SessionSettingsBase : EditableSettingsBase
    {
        protected SessionSettingsBase()
        {
            // Init settings
            Init();
        }

        /// <summary>
        /// Set default values
        /// </summary>
        protected sealed override void Init()
        {
            // Return to default values
            SetDefaultValues();
        }

        /// <summary>
        /// Clear saved settings and set it back to default values
        /// </summary>
        /// <param name="includeUnclearables" >Clear all, including unclearable properties if true (default: false)</param>
        public override void Clear(bool includeUnclearables = false)
        {
            // Get all editable properties if force all mode or clearable one
            var props = GetEditableProperties(includeUnclearables);

            // Return to default values
            SetDefaultValues(props);
        }
    }
}
