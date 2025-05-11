using System;
using System.IO;
using System.Windows.Forms;

namespace MyWinFormApp
{
    public partial class Form1 : Form
    {
        private KeywordExtractor extractor;

        public Form1()
        {
            InitializeComponent();
            extractor = new KeywordExtractor();
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

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            string inputText = richTextBoxInput.Text;
            var keywords = extractor.ExtractKeywords(inputText);

            listBoxResults.Items.Clear();
            foreach (var pair in keywords)
            {
                listBoxResults.Items.Add($"{pair.Key} — {pair.Value}");
            }
        }
    }
}
