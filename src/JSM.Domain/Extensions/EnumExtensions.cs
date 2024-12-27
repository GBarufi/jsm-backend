using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace JSM.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static T? GetEnumValueFromDisplayName<T>(this string displayName) where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().FirstOrDefault(x => x.GetDisplayName().ToLower() == displayName.ToLower());
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue
                .GetType()
                .GetMember(enumValue.ToString())[0]?
                .GetCustomAttribute<DisplayAttribute>()?
                .Name ?? string.Empty;
        }
    }
}
