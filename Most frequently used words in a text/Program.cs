using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

public class TopWords
{
    public static void Main()
    {
        // Test
        var t = Top3("e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e");
        // ...should return { e, ddd, aa };
    }

    public static List<string> Top3(string s)
    {
        Dictionary<string, int> dict = new();
        var words = Regex.Matches(s.ToLowerInvariant(), @"('*[a-z]'*)+").Select(match => match.Value);
        List<string> result = new();

        foreach (var word in words)
        {
            if (dict.ContainsKey(word))
                dict[word]++;

            else dict.Add(word, 1);
        }

        for (int i = 0; dict.Count > 0 && i < 3; i++)
        {
            result.Add(dict.First(x => x.Value == dict.Max(x => x.Value)).Key);
            dict.Remove(result[i]);
        }

        return result;
    }
}