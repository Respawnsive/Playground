using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ReactiveUI;

namespace Playground.Forms.Settings
{
    public abstract class EditableSettingsBase : ReactiveObject
    {
        /// <summary>
        /// Set default values
        /// </summary>
        protected abstract void Init();

        /// <summary>
        /// Clear saved settings and set it back to default values
        /// </summary>
        /// <param name="includeUnclearables" >Clear all, including unclearable properties if true (default: false)</param>
        public abstract void Clear(bool includeUnclearables = false);

        /// <summary>
        /// Set properties to default values based on System.ComponentModel.DefaultValueAttribute decoration
        /// </summary>
        /// <param name="props">Properties to set (default: null = all)</param>
        /// <param name="includeUnclearables" >Set all, including unclearable properties if true (default: true)</param>
        protected void SetDefaultValues(IList<PropertyDescriptor> props = null)
        {
            // Get all editable properties if null
            props ??= GetEditableProperties();

            // Iterate through each property
            foreach (var prop in props)
                // Set default attribute value if decorated with DefaultValueAttribute
                if (prop.Attributes[typeof(DefaultValueAttribute)] is DefaultValueAttribute attr)
                    prop.SetValue(this, attr.Value);
                // Otherwise set default type value
                else prop.SetValue(this, default);
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
