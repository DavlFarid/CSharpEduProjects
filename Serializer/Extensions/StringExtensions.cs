namespace Serializer.Extensions;

public static class StringExtensions
{
    public static string Capitalize(this string value)
    {
        return $"{char.ToUpper(value[0])}{value[1..]}";
    }
}
