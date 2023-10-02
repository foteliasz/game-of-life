using System.Text.RegularExpressions;

namespace GameOfLife.Common;

public static class StringExtension
{
    public static string SanitizeNewLines(this string phrase)
    {
        return Regex.Replace(phrase, @"\r\n?|\n", "");
    }
    
    public static IEnumerable<string> SplitToPieces(this string phrase, int length) {
        for (var i = 0; i < phrase.Length; i += length)
            yield return phrase.Substring(i, Math.Min(length, phrase.Length - i));
    }

    
}