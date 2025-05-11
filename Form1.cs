using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyWinFormApp
{
    public partial class Form1 : Form
    {
        private KeywordExtractor extractor;

        public Form1()
        {
            InitializeComponent();
            extractor = new KeywordExtractor("stopwords.txt");
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string text = File.ReadAllText(openFileDialog.FileName);
                richTextBoxInput.Text = text;
            }
        }

        private void buttonLoadMultipleFiles_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var documents = new Dictionary<string, string>();
                foreach (string filename in openFileDialog.FileNames)
                {
                    string content = File.ReadAllText(filename);
                    documents.Add(Path.GetFileName(filename), content);
                }

                int topN = (int)numericUpDownTopN.Value;
                var results = extractor.ExtractKeywordsFromDocuments(documents, topN);

                listBoxResults.Items.Clear();
                foreach (var doc in results)
                {
                    listBoxResults.Items.Add($"Документ: {doc.Key}");
                    foreach (var kvp in doc.Value)
                    {
                        listBoxResults.Items.Add($"  {kvp.Key} — {kvp.Value:F4}");
                    }
                    listBoxResults.Items.Add("");
                }
            }
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            string inputText = richTextBoxInput.Text;
            int topN = (int)numericUpDownTopN.Value;
            var keywords = extractor.ExtractKeywords(inputText, topN);

            listBoxResults.Items.Clear();
            foreach (var pair in keywords)
            {
                listBoxResults.Items.Add($"{pair.Key} — {pair.Value}");
            }
        }
    }
}
