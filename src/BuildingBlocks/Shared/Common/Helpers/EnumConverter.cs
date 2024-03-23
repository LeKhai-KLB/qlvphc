namespace Shared.Common.Helpers;

public class EnumConverter
{
    public static List<int> StringToList<TEnum>(string value) where TEnum : struct, Enum
    {
        var list = new List<int>();
        if (string.IsNullOrEmpty(value))
            return list;

        var enumValues = value.Split(',');
        foreach (var enumValue in enumValues)
        {
            if (Enum.TryParse(enumValue, out TEnum result))
            {
                list.Add((int)(object)result);
            }
        }
        return list;
    }
}