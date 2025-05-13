using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace DynaReport.Utilities;
public static class EnumUtility
{
    private static readonly ConcurrentDictionary<Enum, string> DescriptionCache = new();

    public static List<string?> EnumToList<TEnum>()
    {
        return Enum.GetValues(typeof(TEnum))
                                      .Cast<TEnum>()
                                      .Select(x => x?.ToString())
                                      .ToList();
    }

    public static string EnumToString<TEnum>() where TEnum : Enum
    {
        var extList = EnumToList<TEnum>();
        return string.Join(",", extList);
    }

    public static bool IsValidEnumValue<TEnum>(this int value) where TEnum : Enum
    {
        return Enum.IsDefined(typeof(TEnum), value);
    }

    public static string GetEnumName<TEnum>(this TEnum tEnum) where TEnum : Enum
    {
        var enumType = typeof(TEnum);
        var enumName = Enum.GetName(enumType, tEnum);
        if (string.IsNullOrEmpty(enumName))
        {
            return string.Empty;
        }

        enumName = enumName.Replace('_', ' ');
        enumName = enumName.Replace("Id", "");
        enumName = Regex.Replace(enumName, "(?<!^)([A-Z])", " $1");
        return enumName;
    }

    public static string GetEnumNameWithoutReplace<TEnum>(this TEnum tEnum) where TEnum : Enum
    {
        var enumType = typeof(TEnum);
        return Enum.GetName(enumType, tEnum) ?? string.Empty;
    }

    public static int GetEnumIntValue<TEnum>(this TEnum tEnum) where TEnum : Enum
    {
        return Convert.ToInt32(tEnum);
    }

    public static IEnumerable<int> GetAllEnumIntValues<TEnum>() where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum))
                   .Cast<TEnum>()
                   .Select(enumValue => Convert.ToInt32(enumValue));
    }

    public static short GetEnumShortValue<TEnum>(this TEnum tEnum) where TEnum : Enum
    {
        return Convert.ToInt16(tEnum);
    }

    public static IEnumerable<short> GetAllEnumShortValues<TEnum>() where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum))
                   .Cast<TEnum>()
                   .Select(enumValue => Convert.ToInt16(enumValue));
    }

    public static TEnum GetPreviousEnumValue<TEnum>(this TEnum currentEnum) where TEnum : Enum
    {
        TEnum[] values = (TEnum[])Enum.GetValues(typeof(TEnum));
        int currentIndex = Array.IndexOf(values, currentEnum);

        return currentIndex == 0 ? values[^1] : values[currentIndex - 1];
    }

    public static TEnum GetNextEnumValue<TEnum>(this TEnum currentEnum) where TEnum : Enum
    {
        TEnum[] values = (TEnum[])Enum.GetValues(typeof(TEnum));
        int currentIndex = Array.IndexOf(values, currentEnum);

        return currentIndex == values.Length - 1 ? values[0] : values[currentIndex + 1];
    }

    public static TEnum? GetEnumValueByName<TEnum>(this string enumName, bool ignoreCase = true) where TEnum : struct, Enum
    {
        if (Enum.TryParse(typeof(TEnum), enumName, ignoreCase, out object? result))
        {
            return (TEnum)result!;
        }

        return null;
    }

    public static IEnumerable<TEnum> GetAllEnumValues<TEnum>() where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
    }

    public static IEnumerable<TEnum> GetAllEnumValues<TEnum>(List<string?> enumNames, bool ignoreCase = true) where TEnum : Enum
    {
        List<TEnum> enumValues = new();
        foreach (var name in enumNames)
        {
            if (Enum.TryParse(typeof(TEnum), name, ignoreCase, out object? enumValue) && enumValue != null)
                enumValues.Add((TEnum)enumValue);
            else
                Console.WriteLine($"Failed to parse enum value for '{name}'");
        }
        return enumValues;
    }

    public static IEnumerable<int> GetAllEnumIntValues<TEnum>(List<string?> enumNames, bool ignoreCase = true) where TEnum : Enum
    {
        List<int> enumIntValues = new();
        foreach (var name in enumNames)
        {
            if (Enum.TryParse(typeof(TEnum), name, ignoreCase, out object? enumValue) && enumValue != null)
                enumIntValues.Add(Convert.ToInt32(enumValue));
            else
                Console.WriteLine($"Failed to parse enum value for '{name}'");
        }
        return enumIntValues;
    }

    public static IEnumerable<short> GetAllEnumShortValues<TEnum>(List<string?> enumNames, bool ignoreCase = true) where TEnum : Enum
    {
        List<short> enumIntValues = new();
        foreach (var name in enumNames)
        {
            if (Enum.TryParse(typeof(TEnum), name, ignoreCase, out object? enumValue) && enumValue != null)
                enumIntValues.Add(Convert.ToInt16(enumValue));
            else
                Console.WriteLine($"Failed to parse enum value for '{name}'");
        }
        return enumIntValues;
    }

    public static bool HasFlags<TEnum>(this TEnum value) where TEnum : Enum
    {
        var underlyingType = Enum.GetUnderlyingType(typeof(TEnum));

        if (underlyingType == typeof(int) || underlyingType == typeof(uint) || underlyingType == typeof(long) || underlyingType == typeof(ulong))
        {
            long longValue = Convert.ToInt64(value);
            return (longValue & longValue - 1) != 0;
        }
        return false;
    }

    public static IList<KeyValuePair<string, int>> ToKeyValueList<TEnum>() where TEnum : Enum
    {
        var enumType = typeof(TEnum);
        var values = Enum.GetValues(enumType);
        var keyValueList = new List<KeyValuePair<string, int>>();

        foreach (var value in values)
        {
            var key = Enum.GetName(enumType, value);
            var intValue = (int)value;
            var pair = new KeyValuePair<string, int>(key ?? string.Empty, intValue);
            keyValueList.Add(pair);
        }
        return keyValueList;
    }

    public static bool TryGetEnumFromValue<TEnum>(this int value, out TEnum result) where TEnum : struct, Enum
    {
        result = default;

        if (Enum.IsDefined(typeof(TEnum), value))
        {
            result = (TEnum)Enum.ToObject(typeof(TEnum), value);
            return true;
        }

        return false;
    }

    public static bool TryGetEnumFromName<TEnum>(this string name, bool ignoreCase, out TEnum result) where TEnum : struct, Enum
    {
        result = default;

        if (Enum.TryParse(name, ignoreCase, out TEnum parsedValue))
        {
            result = parsedValue;
            return true;
        }

        return false;
    }
}
