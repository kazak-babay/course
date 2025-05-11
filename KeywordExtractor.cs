using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyWinFormApp
{
    public class KeywordExtractor
    {
        private readonly HashSet<string> stopWords;

        // Конструктор, который загружает стоп-слова из файла
        public KeywordExtractor(string stopWordsFilePath)
        {
            stopWords = new HashSet<string>(File.ReadAllLines(stopWordsFilePath).Select(line => line.ToLower()));
        }

        private List<string> Tokenize(string text)
        {
            return Regex.Split(text.ToLower(), @"\W+")
                .Where(word => word.Length > 2 && !stopWords.Contains(word))
                .ToList();
        }

        public Dictionary<string, Dictionary<string, double>> ExtractKeywordsFromDocuments(Dictionary<string, string> documents, int topN = 10)
        {
            var tokenizedDocs = new Dictionary<string, List<string>>();
            var df = new Dictionary<string, int>(); // Document Frequency

            // 1. Токенизация и подсчёт DF
            foreach (var (docName, text) in documents)
            {
                var tokens = Tokenize(text);
                tokenizedDocs[docName] = tokens;

                foreach (var token in tokens.Distinct())
                {
                    if (!df.ContainsKey(token))
                        df[token] = 0;
                    df[token]++;
                }
            }

            int totalDocs = documents.Count;

            // 2. Подсчёт TF-IDF
            var result = new Dictionary<string, Dictionary<string, double>>();
            foreach (var (docName, tokens) in tokenizedDocs)
            {
                var tf = tokens.GroupBy(w => w).ToDictionary(g => g.Key, g => (double)g.Count() / tokens.Count);
                var tfidf = new Dictionary<string, double>();

                foreach (var (term, tfVal) in tf)
                {
                    double idf = Math.Log((1.0 + totalDocs) / (1.0 + df[term])) + 1.0;
                    tfidf[term] = tfVal * idf;
                }

                result[docName] = tfidf
                    .OrderByDescending(kvp => kvp.Value)
                    .Take(topN)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }

            return result;
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