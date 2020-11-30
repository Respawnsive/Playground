using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ReactiveUI;
using Shiny.Settings;

namespace Playground.Forms.Settings.User
{
    public abstract class UserSettingsBase : ReactiveObject
    {
        private readonly ISettings _settings;

        protected UserSettingsBase(ISettings settings)
        {
            _settings = settings;
            SetDefaultValues();
            _settings.Bind(this);
        }

        /// <summary>
        /// Clear saved settings back to default
        /// </summary>
        /// <param name="forceAll" >Clear all, including unclearable properties if true (default: false)</param>
        public virtual void Clear(bool forceAll = false)
        {
            var props = TypeDescriptor.GetProperties(this)
                .Cast<PropertyDescriptor>()
                .Where(prop => !prop.IsReadOnly)
                .ToList();

            // Iterate through each clearable property
            foreach (var prop in props.Where(prop => forceAll || !(prop.Attributes[typeof(UnclearableAttribute)] is UnclearableAttribute)))
                // Clear property if clearable
                _settings.Remove($"{GetType().FullName}.{prop.Name}");

            // Disable settings sync while returning to default
            _settings.UnBind(this);

            // Return to default values
            SetDefaultValues();

            // Enable settings sync back
            _settings.Bind(this);
        }

        private void SetDefaultValues(IEnumerable<PropertyDescriptor> props = null)
        {
            if (props == null)
                props = TypeDescriptor.GetProperties(this)
                    .Cast<PropertyDescriptor>()
                    .Where(prop => !prop.IsReadOnly)
                    .ToList();

            // Iterate through each property
            foreach (var prop in props)
                // Set default attribute value if decorated with DefaultValueAttribute
                if (prop.Attributes[typeof(DefaultValueAttribute)] is DefaultValueAttribute attr)
                    prop.SetValue(this, attr.Value);
                // Set default type value if not decorated with DefaultValueAttribute and UnclearableAttribute
                else if (!(prop.Attributes[typeof(UnclearableAttribute)] is UnclearableAttribute))
                    prop.SetValue(this, default);
        }

        [AttributeUsage(AttributeTargets.Property)]
        protected class UnclearableAttribute : Attribute { }
    }
}