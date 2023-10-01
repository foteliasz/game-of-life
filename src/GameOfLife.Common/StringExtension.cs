using System.Text.RegularExpressions;

namespace GameOfLife.Common;

public static class StringExtension
{
    public static string SanitizeNewLines(this string phrase)
    {
        return Regex.Replace(phrase, @"\r\n?|\n", "");
    }
}