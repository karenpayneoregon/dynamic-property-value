using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

        public static object GetPropValue(this object sender, string name)
        {
            foreach (var part in name.Split('.'))
            {
                if (sender is null) { return null; }

                Type type = sender.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info is null) { return null; }

                sender = info.GetValue(sender, null);
            }

            return sender;
        }

        /// <summary>
        /// Get value of a object by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetPropValue<T>(this object sender, string name)
        {
            var result = GetPropValue(sender, name);

            if (result == null) { return default; }

            // throws InvalidCastException if types are incompatible
            return (T)result;
        }

        /// <summary>
        /// Determine if a property is in a class case sensitive
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool IsValidProperty<T>(this T sender, string propertyName) => 
            typeof(Person).GetProperties().FirstOrDefault(item => item.Name == propertyName) is not  null;

        /// <summary>
        /// Determine if a property is in a class case sensitive insensitive
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool IsValidPropertyIgnoreCase<T>(this T sender, string propertyName) =>
            typeof(Person).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase) is not null;

        public static string GetPropertyName<T, TReturn>(this Expression<Func<T, TReturn>> expression)
        {
            var body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }
    }
}
