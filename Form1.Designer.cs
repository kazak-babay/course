namespace MyWinFormApp;

partial class Form1
{
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	private System.Windows.Forms.RichTextBox richTextBoxInput;
	private System.Windows.Forms.Button buttonLoadFile;
	private System.Windows.Forms.Button buttonAnalyze;
	private System.Windows.Forms.ListBox listBoxResults;
	private System.Windows.Forms.Label labelInput;
	private System.Windows.Forms.Label labelResults;
	private System.Windows.Forms.Button buttonLoadMultipleFiles;


	private void InitializeComponent()
	{
		this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
		this.buttonLoadFile = new System.Windows.Forms.Button();
		this.buttonLoadMultipleFiles = new System.Windows.Forms.Button();
		this.buttonAnalyze = new System.Windows.Forms.Button();
		this.listBoxResults = new System.Windows.Forms.ListBox();
		this.labelInput = new System.Windows.Forms.Label();
		this.labelResults = new System.Windows.Forms.Label();
		this.SuspendLayout();
		// 
		// labelInput
		// 
		this.labelInput.Text = "Ввод текста или содержимое файла:";
		this.labelInput.Location = new System.Drawing.Point(20, 15);
		this.labelInput.AutoSize = true;
		// 
		// richTextBoxInput
		// 
		this.richTextBoxInput.Location = new System.Drawing.Point(20, 40);
		this.richTextBoxInput.Size = new System.Drawing.Size(900, 250);
		this.richTextBoxInput.Name = "richTextBoxInput";
		this.richTextBoxInput.Font = new System.Drawing.Font("Segoe UI", 10);
		// 
		// buttonLoadFile
		// 
		this.buttonLoadFile.Location = new System.Drawing.Point(940, 40);
		this.buttonLoadFile.Size = new System.Drawing.Size(300, 40);
		this.buttonLoadFile.Text = "📂 Загрузить файл";
		this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
		this.buttonLoadFile.Name = "buttonLoadFile";
		this.buttonLoadFile.Font = new System.Drawing.Font("Segoe UI", 10);
		// 
		// buttonLoadMultipleFiles
		//
		this.buttonLoadMultipleFiles.Location = new System.Drawing.Point(940, 140);
		this.buttonLoadMultipleFiles.Size = new System.Drawing.Size(300, 40);
		this.buttonLoadMultipleFiles.Text = "📂 Загрузить несколько файлов";
		this.buttonLoadMultipleFiles.Click += new System.EventHandler(this.buttonLoadMultipleFiles_Click);
		this.buttonLoadMultipleFiles.Name = "buttonLoadMultipleFiles";
		this.buttonLoadMultipleFiles.Font = new System.Drawing.Font("Segoe UI", 10);
		this.Controls.Add(this.buttonLoadMultipleFiles);
		//
		// buttonAnalyze
		// 
		this.buttonAnalyze.Location = new System.Drawing.Point(940, 90);
		this.buttonAnalyze.Size = new System.Drawing.Size(300, 40);
		this.buttonAnalyze.Text = "🔍 Анализировать";
		this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
		this.buttonAnalyze.Name = "buttonAnalyze";
		this.buttonAnalyze.Font = new System.Drawing.Font("Segoe UI", 10);
		// 
		// labelResults
		// 
		this.labelResults.Text = "Результаты (ключевые слова):";
		this.labelResults.Location = new System.Drawing.Point(20, 310);
		this.labelResults.AutoSize = true;
		// 
		// listBoxResults
		// 
		this.listBoxResults.Location = new System.Drawing.Point(20, 335);
		this.listBoxResults.Size = new System.Drawing.Size(1220, 300);
		this.listBoxResults.Name = "listBoxResults";
		this.listBoxResults.Font = new System.Drawing.Font("Segoe UI", 10);
		// 
		// Form1
		// 
		this.ClientSize = new System.Drawing.Size(1280, 720);
		this.Controls.Add(this.labelInput);
		this.Controls.Add(this.richTextBoxInput);
		this.Controls.Add(this.buttonLoadFile);
		this.Controls.Add(this.buttonAnalyze);
		this.Controls.Add(this.labelResults);
		this.Controls.Add(this.listBoxResults);

		this.Name = "Form1";
		this.Text = "Анализ ключевых слов в тексте";
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	#endregion


}

