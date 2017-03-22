namespace _7zipCompression
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TestFourButton = new System.Windows.Forms.Button();
            this.TestThreeButton = new System.Windows.Forms.Button();
            this.TextTwoButton = new System.Windows.Forms.Button();
            this.SevenZipPathButton = new System.Windows.Forms.Button();
            this.SevenZipPathText = new System.Windows.Forms.TextBox();
            this.TestOneButton = new System.Windows.Forms.Button();
            this.TestyWyniki = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SelectedFilesText = new System.Windows.Forms.RichTextBox();
            this.methodBox = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.formatBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.FolderPath = new System.Windows.Forms.TextBox();
            this.SelectBestCompressionButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1187, 490);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TestFourButton);
            this.tabPage1.Controls.Add(this.TestThreeButton);
            this.tabPage1.Controls.Add(this.TextTwoButton);
            this.tabPage1.Controls.Add(this.SevenZipPathButton);
            this.tabPage1.Controls.Add(this.SevenZipPathText);
            this.tabPage1.Controls.Add(this.TestOneButton);
            this.tabPage1.Controls.Add(this.TestyWyniki);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1179, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Testy";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TestFourButton
            // 
            this.TestFourButton.Location = new System.Drawing.Point(31, 222);
            this.TestFourButton.Name = "TestFourButton";
            this.TestFourButton.Size = new System.Drawing.Size(283, 23);
            this.TestFourButton.TabIndex = 8;
            this.TestFourButton.Text = "Test 4";
            this.TestFourButton.UseVisualStyleBackColor = true;
            this.TestFourButton.Click += new System.EventHandler(this.TestFourButton_Click);
            // 
            // TestThreeButton
            // 
            this.TestThreeButton.Location = new System.Drawing.Point(31, 193);
            this.TestThreeButton.Name = "TestThreeButton";
            this.TestThreeButton.Size = new System.Drawing.Size(283, 23);
            this.TestThreeButton.TabIndex = 7;
            this.TestThreeButton.Text = "Test 3";
            this.TestThreeButton.UseVisualStyleBackColor = true;
            this.TestThreeButton.Click += new System.EventHandler(this.TestThreeButton_Click);
            // 
            // TextTwoButton
            // 
            this.TextTwoButton.Location = new System.Drawing.Point(31, 164);
            this.TextTwoButton.Name = "TextTwoButton";
            this.TextTwoButton.Size = new System.Drawing.Size(283, 23);
            this.TextTwoButton.TabIndex = 6;
            this.TextTwoButton.Text = "Test 2";
            this.TextTwoButton.UseVisualStyleBackColor = true;
            this.TextTwoButton.Click += new System.EventHandler(this.TextTwoButton_Click);
            // 
            // SevenZipPathButton
            // 
            this.SevenZipPathButton.Location = new System.Drawing.Point(239, 71);
            this.SevenZipPathButton.Name = "SevenZipPathButton";
            this.SevenZipPathButton.Size = new System.Drawing.Size(75, 23);
            this.SevenZipPathButton.TabIndex = 5;
            this.SevenZipPathButton.Text = "Wybierz";
            this.SevenZipPathButton.UseVisualStyleBackColor = true;
            this.SevenZipPathButton.Click += new System.EventHandler(this.SevenZipPathButton_Click);
            // 
            // SevenZipPathText
            // 
            this.SevenZipPathText.Enabled = false;
            this.SevenZipPathText.Location = new System.Drawing.Point(31, 71);
            this.SevenZipPathText.Name = "SevenZipPathText";
            this.SevenZipPathText.Size = new System.Drawing.Size(201, 20);
            this.SevenZipPathText.TabIndex = 3;
            this.SevenZipPathText.Text = "Ścierzka do programu 7zip.exe";
            // 
            // TestOneButton
            // 
            this.TestOneButton.Location = new System.Drawing.Point(31, 135);
            this.TestOneButton.Name = "TestOneButton";
            this.TestOneButton.Size = new System.Drawing.Size(283, 23);
            this.TestOneButton.TabIndex = 1;
            this.TestOneButton.Text = "Test 1";
            this.TestOneButton.UseVisualStyleBackColor = true;
            this.TestOneButton.Click += new System.EventHandler(this.TestOneButton_Click);
            // 
            // TestyWyniki
            // 
            this.TestyWyniki.Location = new System.Drawing.Point(353, 6);
            this.TestyWyniki.Name = "TestyWyniki";
            this.TestyWyniki.Size = new System.Drawing.Size(820, 455);
            this.TestyWyniki.TabIndex = 0;
            this.TestyWyniki.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.FilePath);
            this.tabPage2.Controls.Add(this.SelectBestCompressionButton);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.FolderPath);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.formatBox);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.methodBox);
            this.tabPage2.Controls.Add(this.SelectedFilesText);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1179, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kompresja";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SelectedFilesText
            // 
            this.SelectedFilesText.Enabled = false;
            this.SelectedFilesText.Location = new System.Drawing.Point(356, 0);
            this.SelectedFilesText.Name = "SelectedFilesText";
            this.SelectedFilesText.Size = new System.Drawing.Size(820, 455);
            this.SelectedFilesText.TabIndex = 1;
            this.SelectedFilesText.Text = "";
            // 
            // methodBox
            // 
            this.methodBox.FormattingEnabled = true;
            this.methodBox.Location = new System.Drawing.Point(195, 177);
            this.methodBox.Name = "methodBox";
            this.methodBox.Size = new System.Drawing.Size(121, 21);
            this.methodBox.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(33, 177);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Metoda kompresji";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(33, 151);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(148, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "Rodzaj kompresji";
            // 
            // formatBox
            // 
            this.formatBox.FormattingEnabled = true;
            this.formatBox.Items.AddRange(new object[] {
            "zip",
            "7z"});
            this.formatBox.Location = new System.Drawing.Point(195, 151);
            this.formatBox.Name = "formatBox";
            this.formatBox.Size = new System.Drawing.Size(121, 21);
            this.formatBox.TabIndex = 10;
            this.formatBox.SelectedIndexChanged += new System.EventHandler(this.formatBox_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(241, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Wybierz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FolderPath
            // 
            this.FolderPath.Enabled = false;
            this.FolderPath.Location = new System.Drawing.Point(33, 87);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(201, 20);
            this.FolderPath.TabIndex = 12;
            this.FolderPath.Text = "Folder do kompresji";
            // 
            // SelectBestCompressionButton
            // 
            this.SelectBestCompressionButton.Location = new System.Drawing.Point(33, 243);
            this.SelectBestCompressionButton.Name = "SelectBestCompressionButton";
            this.SelectBestCompressionButton.Size = new System.Drawing.Size(283, 45);
            this.SelectBestCompressionButton.TabIndex = 14;
            this.SelectBestCompressionButton.Text = "Dobierz kompresję";
            this.SelectBestCompressionButton.UseVisualStyleBackColor = true;
            this.SelectBestCompressionButton.Click += new System.EventHandler(this.SelectBestCompressionButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(241, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Wybierz";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FilePath
            // 
            this.FilePath.Enabled = false;
            this.FilePath.Location = new System.Drawing.Point(33, 113);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(201, 20);
            this.FilePath.TabIndex = 15;
            this.FilePath.Text = "Plik do kompresji";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(33, 308);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(283, 45);
            this.button4.TabIndex = 17;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 514);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button SevenZipPathButton;
        private System.Windows.Forms.TextBox SevenZipPathText;
        private System.Windows.Forms.Button TestOneButton;
        private System.Windows.Forms.RichTextBox TestyWyniki;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button TestFourButton;
        private System.Windows.Forms.Button TestThreeButton;
        private System.Windows.Forms.Button TextTwoButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox formatBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox methodBox;
        private System.Windows.Forms.RichTextBox SelectedFilesText;
        private System.Windows.Forms.Button SelectBestCompressionButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox FolderPath;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Button button4;
    }
}

