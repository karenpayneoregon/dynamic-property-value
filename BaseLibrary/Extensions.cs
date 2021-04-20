using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary
{
    public static class Extensions
    {
        /// <summary>
        /// Dynamically set property value
        /// </summary>
        /// <param name="sender">Generic type</param>
        /// <param name="propertyName">Property name to set value for</param>
        /// <param name="value">Value to set for property</param>
        /// <remarks>
        /// Currently setup for general types and enum. For other types
        /// check out "Is" Properties and handles the type as done with enum below
        /// </remarks>
        public static void SetValue<T>(this T sender, string propertyName, object value)
        {
            var propertyInfo = sender.GetType().GetProperty(propertyName);

            if (propertyInfo is null) return;

            var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;


            if (propertyInfo.PropertyType.IsEnum)
            {
                propertyInfo.SetValue(sender, Enum.Parse(propertyInfo.PropertyType, value.ToString()!));
            }
            else
            {
                var safeValue = (value == null) ? null : Convert.ChangeType(value, type);
                propertyInfo.SetValue(sender, safeValue, null);
            }
        }
    }
}
