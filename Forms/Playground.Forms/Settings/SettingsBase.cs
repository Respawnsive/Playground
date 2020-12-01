using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ReactiveUI;

namespace Playground.Forms.Settings
{
    public abstract class SettingsBase : ReactiveObject
    {
        protected SettingsBase()
        {
            Init();
        }

        /// <summary>
        /// Set default values
        /// </summary>
        /// <param name="props">Properties to set (default: null = all)</param>
        /// <param name="includeUnclearables" >Init all, including unclearable properties if true (default: true)</param>
        protected virtual void Init(IList<PropertyDescriptor> props = null, bool includeUnclearables = true)
        {
            // Return to default values
            SetDefaultValues(props, includeUnclearables);
        }

        /// <summary>
        /// Return to default values
        /// </summary>
        /// <param name="props">Properties to set (default: null = all)</param>
        /// <param name="includeUnclearables" >Reset all, including unclearable properties if true (default: true)</param>
        protected virtual void Reset(IList<PropertyDescriptor> props = null, bool includeUnclearables = true)
        {
            // Return to default values
            Init(props, includeUnclearables);
        }

        /// <summary>
        /// Set properties to default values based on System.ComponentModel.DefaultValueAttribute decoration
        /// </summary>
        /// <param name="props">Properties to set (default: null = all)</param>
        /// <param name="includeUnclearables" >Set all, including unclearable properties if true (default: true)</param>
        protected void SetDefaultValues(IList<PropertyDescriptor> props = null, bool includeUnclearables = true)
        {
            // Get all editable properties if null
            if (props == null)
                props = GetEditableProperties(includeUnclearables);

            // Iterate through each property
            foreach (var prop in props)
                // Set default attribute value if decorated with DefaultValueAttribute
                if (prop.Attributes[typeof(DefaultValueAttribute)] is DefaultValueAttribute attr)
                    prop.SetValue(this, attr.Value);
                // Otherwise set default type value
                else prop.SetValue(this, default);
        }

        /// <summary>
        /// Clear saved settings and set it back to default values
        /// </summary>
        /// <param name="includeUnclearables" >Clear all, including unclearable properties if true (default: false)</param>
        public virtual void Clear(bool includeUnclearables = false)
        {
            // Get all editable properties if force all mode or clearable one
            var props = GetEditableProperties(includeUnclearables);

            // Return to default values
            Reset(props, includeUnclearables);
        }

        /// <summary>
        /// Get all editable properties
        /// </summary>
        /// <param name="includeUnclearables" >Get all, including unclearable properties if true (default: false)</param>
        /// <returns></returns>
        protected IList<PropertyDescriptor> GetEditableProperties(bool includeUnclearables = false)
        {
            return TypeDescriptor.GetProperties(this)
                .Cast<PropertyDescriptor>()
                .Where(prop => !prop.IsReadOnly && (includeUnclearables || !(prop.Attributes[typeof(UnclearableAttribute)] is UnclearableAttribute)))
                .ToList();
        }

        /// <summary>
        /// Attribute to prevent decorated property from being cleared
        /// </summary>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        protected class UnclearableAttribute : Attribute { }
    }
}
