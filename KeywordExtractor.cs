using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyWinFormApp
{
    public class KeywordExtractor
    {
        private HashSet<string> stopWords;

        public KeywordExtractor()
        {
            stopWords = new HashSet<string>
            {
                "и", "в", "во", "не", "что", "он", "на", "я", "с", "со", "как", "а", "то",
                "все", "она", "так", "его", "но", "да", "ты", "к", "у", "же", "вы", "за",
                "бы", "по", "только", "ее", "мне", "было", "вот", "от", "меня", "еще",
                "нет", "о", "из", "ему", "теперь", "когда", "даже", "ну", "вдруг",
                "ли", "если", "уже", "или", "ни", "быть", "был", "него", "до", "вас",
                "нибудь", "опять", "уж", "вам", "ведь", "там", "потом", "себя", "ничего",
                "ей", "может", "они", "тут", "где", "есть", "надо", "ней", "для", "мы",
                "тебя", "их", "чем", "была", "сам", "чтоб", "без", "будто", "чего",
                "раз", "тоже", "себе", "под", "будет", "ж", "тогда", "кто", "этот"
            };
        }

        public Dictionary<string, int> ExtractKeywords(string text, int topN = 20)
        {
            var words = Regex.Split(text.ToLower(), @"\W+")
                             .Where(word => word.Length > 2 && !stopWords.Contains(word))
                             .ToList();

            var frequency = words.GroupBy(w => w)
                                 .ToDictionary(g => g.Key, g => g.Count());

            return frequency.OrderByDescending(kvp => kvp.Value)
                            .Take(topN)
                            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
