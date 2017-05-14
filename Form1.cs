using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace _7zipCompression
{
    public partial class Form1 : Form
    {
        private List<CompressedDataInformation> data;
        private List<CompressedDataInformation> dataZip;
        private List<CompressedDataInformation> data7Z;
        private string absolute7zipRoute;
        private string urlToFolder = @"D:\aikd\Pliki_testowe\";
        private enum ZipCompresstionTypesEnum { Deflate, Deflate64, BZip2, LZMA, PPMd };
        private enum SevenZipCompresstionTypesEnum { LZMA, LZMA2, PPMd, BZip2 };
        private enum CompressionSpeedEnum { Low = 1, Fast = 3, Normal = 5, Maximum = 7, Ultra = 9 };
        public Form1()
        {
            InitializeComponent();
            absolute7zipRoute = "";
            data = new List<CompressedDataInformation>();
            dataZip = new List<CompressedDataInformation>();
            data7Z = new List<CompressedDataInformation>();
        }

        public long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        public void AddToFile(string outputFilePath,string Text)
        {
            using (StreamWriter sw = File.AppendText(outputFilePath))
            {
                sw.WriteLine(Text);
            }
        }
        public string ReadFromFile(string outputFilePath, string extension)
        {
            int counter = 0;
            string line;

            System.IO.StreamReader file =
               new System.IO.StreamReader(outputFilePath);
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(':');
                if(words[0] == extension)
                {
                    string[] methods = words[2].Split('=');
                    file.Close();
                    return words[1] +":"+ methods[1];
                }
                counter++;
            }
            return null;
        }

        public CompressedDataInformation compressFile(string type,string absoluteFileRoute, string absolute7zipRoute, string archiveFormat, string compressSpeed, string outputFileName, string compressMethod, RichTextBox textField)
        {

            long beforeCompress = DirSize(new DirectoryInfo(absoluteFileRoute));
            Stopwatch timer = new Stopwatch();
            Process p = new Process();
            p.StartInfo.Arguments = "a -t" + archiveFormat + "  -mx=" + compressSpeed + "  " + outputFileName + " \"" + absoluteFileRoute + "\" " + compressMethod;
            p.StartInfo.FileName = absolute7zipRoute;
            p.Start();
            timer.Start();
            p.WaitForExit();
            timer.Stop();
            try
            {
                long afterCompress = new System.IO.FileInfo(outputFileName + "." + archiveFormat).Length;
                System.IO.File.Delete(outputFileName + "." + archiveFormat);

                float compressionRatio = 100 * (1 - ((float)afterCompress / (float)beforeCompress));
                double compressionTime = timer.Elapsed.TotalSeconds;
                if (textField != null)
                {
                    if (textField.Text == "") textField.Text = String.Format("{0,-10}{1,-30}{2,-30}{3,-30}", "Typ", "Metoda", "Compression Ratio", "Time") + Environment.NewLine;
                    textField.Text += String.Format("{0,-10}{1,-30}{2,-30}{3,-30}", archiveFormat, compressMethod, compressionRatio.ToString("0.00") + "%", compressionTime.ToString("0.00") + "sec") + Environment.NewLine;
                }
                timer.Reset();
                return new CompressedDataInformation(type,compressionRatio, compressionTime, compressMethod, archiveFormat, compressSpeed);
            }
            catch (IOException ee)
            {
                Console.WriteLine(ee.Message);
            }
            return null;
        }

        private void SevenZipPathButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                absolute7zipRoute = openFileDialog1.FileName.ToString();
                SevenZipPathText.Text = absolute7zipRoute;
            }
        }

        private void TestOneButton_Click(object sender, EventArgs e)
        {
            TestyWyniki.Text = "";
            if (!absolute7zipRoute.Equals(""))
            {
                string format = "zip";
                int speed = (int)CompressionSpeedEnum.Ultra;
                string method = "";
                string filePath = urlToFolder;
                RichTextBox output = TestyWyniki;
                for (int i = 0; i < Enum.GetNames(typeof(ZipCompresstionTypesEnum)).Length; i++)
                {
                    method = Enum.GetName(typeof(ZipCompresstionTypesEnum), i);
                    dataZip.Add(compressFile("*",filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", format.Equals("7z") ? "-m0=" + method : "-mm=" + method, output));
                }

                format = "7z";
                for (int i = 0; i < Enum.GetNames(typeof(SevenZipCompresstionTypesEnum)).Length; i++)
                {
                    method = Enum.GetName(typeof(SevenZipCompresstionTypesEnum), i);
                    data7Z.Add(compressFile("*",filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", format.Equals("7z") ? "-m0=" + method : "-mm=" + method, output));
                }
                dataZip.Sort();
                data7Z.Sort();
                data.Add(dataZip[0]);
                data.Add(data7Z[0]);
                data.Sort();

                AddToFile(@"CompressionInformation.data", data[0].FileType + ":" + data[0].FileArchiveFormat + ":" + data[0].FileCompressionMethod);
                AddToFile(@"CompressionInformation.data", data[1].FileType + ":" + data[1].FileArchiveFormat + ":" + data[1].FileCompressionMethod);

                output.Text += System.Environment.NewLine + System.Environment.NewLine + "Najlepszy algorytm to " + data[0].FileCompressionMethod.ToString() + " Skompresonwano : " + data[0].FileCompressionRatio.ToString("00.00") + "%" + System.Environment.NewLine;
                output.Text += "Najgorszy algorytm to " + data[data.Count - 1].FileCompressionMethod.ToString() + " Skompresonwano : " + data[data.Count - 1].FileCompressionRatio.ToString("00.00") + "%" + System.Environment.NewLine + System.Environment.NewLine;

                method = data[0].FileCompressionMethod.ToString();
                format = data[0].FileArchiveFormat;
                data7Z.Clear();
                dataZip.Clear();

                speed = (int)CompressionSpeedEnum.Low;
                data.Add(compressFile("*", filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", method, output));
                speed = (int)CompressionSpeedEnum.Normal;
                data.Add(compressFile("*", filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", method, output));
                speed = (int)CompressionSpeedEnum.Ultra;
                data.Add(compressFile("*", filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", method, output));

            }
        }

        private void TextTwoButton_Click(object sender, EventArgs e)
        {
            TestyWyniki.Text = "";

            if (!absolute7zipRoute.Equals(""))
            {
                for (int i = 0; i < 2; i++)
                {
                    string format = "zip";
                    int speed = (int)CompressionSpeedEnum.Ultra;
                    string method = "";
                    string type = "";
                    if (i == 0) type = "txt";
                    else if (i == 1) type = "bin";
                    string filePath = urlToFolder + type;
                    RichTextBox output = TestyWyniki;

                    for (int j = 0; j < Enum.GetNames(typeof(ZipCompresstionTypesEnum)).Length; j++)
                    {
                        method = Enum.GetName(typeof(ZipCompresstionTypesEnum), j);
                        dataZip.Add(compressFile(type,filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", format.Equals("7z") ? "-m0=" + method : "-mm=" + method, output));
                    }

                    format = "7z";
                    for (int j = 0; j < Enum.GetNames(typeof(SevenZipCompresstionTypesEnum)).Length; j++)
                    {
                        method = Enum.GetName(typeof(SevenZipCompresstionTypesEnum), j);
                        data7Z.Add(compressFile(type,filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", format.Equals("7z") ? "-m0=" + method : "-mm=" + method, output));
                    }
                    dataZip.Sort();
                    data7Z.Sort();
                    data.Add(dataZip[0]);
                    data.Add(data7Z[0]);
                    data.Sort();
                    AddToFile(@"CompressionInformation.data", data[0].FileType + ":" + data[0].FileArchiveFormat + ":" + data[0].FileCompressionMethod);
                    AddToFile(@"CompressionInformation.data", data[1].FileType + ":" + data[1].FileArchiveFormat + ":" + data[1].FileCompressionMethod);
                    output.Text += System.Environment.NewLine + System.Environment.NewLine + "Najlepszy algorytm dla " + type + " to: " + data[0].FileCompressionMethod.ToString() + " Skompresonwano : " + data[0].FileCompressionRatio.ToString("00.00") + "%" + System.Environment.NewLine;
                    data.Clear();
                    data7Z.Clear();
                    dataZip.Clear();
                }
            }
        }

        private void TestThreeButton_Click(object sender, EventArgs e)
        {
            TestyWyniki.Text = "";

            if (!absolute7zipRoute.Equals(""))
            {
                string format = "zip";
                int speed = (int)CompressionSpeedEnum.Ultra;
                string method = "";
                string type = "bmpsmall";
                string filePath = urlToFolder + type;
                RichTextBox output = TestyWyniki;

                for (int j = 0; j < Enum.GetNames(typeof(ZipCompresstionTypesEnum)).Length; j++)
                {
                    method = Enum.GetName(typeof(ZipCompresstionTypesEnum), j);
                    dataZip.Add(compressFile(type,filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", format.Equals("7z") ? "-m0=" + method : "-mm=" + method, output));
                }

                format = "7z";
                for (int j = 0; j < Enum.GetNames(typeof(SevenZipCompresstionTypesEnum)).Length; j++)
                {
                    method = Enum.GetName(typeof(SevenZipCompresstionTypesEnum), j);
                    data7Z.Add(compressFile(type,filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", format.Equals("7z") ? "-m0=" + method : "-mm=" + method, output));
                }
                dataZip.Sort();
                data7Z.Sort();
                data.Add(dataZip[0]);
                data.Add(data7Z[0]);
                data.Sort();

                AddToFile(@"CompressionInformation.data", data[0].FileType + ":" + data[0].FileArchiveFormat + ":" + data[0].FileCompressionMethod);
                AddToFile(@"CompressionInformation.data", data[1].FileType + ":" + data[1].FileArchiveFormat + ":" + data[1].FileCompressionMethod);

                output.Text += System.Environment.NewLine + System.Environment.NewLine + "Najlepszy algorytm dla " + type + " to: " + data[0].FileCompressionMethod.ToString() + " Skompresonwano : " + data[0].FileCompressionRatio.ToString("00.00") + "%" + System.Environment.NewLine + System.Environment.NewLine;

                method = data[0].FileCompressionMethod.ToString();
                format = data[0].FileArchiveFormat;
                type = "";
                CompressedDataInformation info;
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0) type = "bmpbig";
                    if (i == 1) type = "jpgbig";
                    if (i == 2) type = "jpgsmall";
                    filePath = urlToFolder + type;

                    info = compressFile(type,filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", method, null);
                    output.Text +="Wynik algorytmu dla "+ format+" " + type + " to: " + info.FileCompressionMethod.ToString() + " Skompresonwano : " + info.FileCompressionRatio.ToString("00.00") + "%" + System.Environment.NewLine;
                }

                method = data[1].FileCompressionMethod.ToString();
                format = data[1].FileArchiveFormat;
                type = "";
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0) type = "bmpbig";
                    if (i == 1) type = "jpgbig";
                    if (i == 2) type = "jpgsmall";
                    filePath = urlToFolder + type;

                    info = compressFile(type,filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", method, null);
                    output.Text += "Wynik algorytmu dla " + format + " " + type + " to: " + info.FileCompressionMethod.ToString() + " Skompresonwano : " + info.FileCompressionRatio.ToString("00.00") + "%" + System.Environment.NewLine;
                }
                data7Z.Clear();
                dataZip.Clear();
                data.Clear();

                for (int i = 0; i < 3; i++)
                {
                    if (i == 0) type = "bmpbig";
                    if (i == 1) type = "jpgbig";
                    if (i == 2) type = "jpgsmall";
                    filePath = urlToFolder + type;
                    format = "zip";
                    for (int j = 0; j < Enum.GetNames(typeof(ZipCompresstionTypesEnum)).Length; j++)
                    {
                        method = Enum.GetName(typeof(ZipCompresstionTypesEnum), j);
                        dataZip.Add(compressFile(type, filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", format.Equals("7z") ? "-m0=" + method : "-mm=" + method, output));
                    }

                    format = "7z";
                    for (int j = 0; j < Enum.GetNames(typeof(SevenZipCompresstionTypesEnum)).Length; j++)
                    {
                        method = Enum.GetName(typeof(SevenZipCompresstionTypesEnum), j);
                        data7Z.Add(compressFile(type, filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", format.Equals("7z") ? "-m0=" + method : "-mm=" + method, output));
                    }
                    dataZip.Sort();
                    data7Z.Sort();
                    data.Add(dataZip[0]);
                    data.Add(data7Z[0]);
                    data.Sort();

                    AddToFile(@"CompressionInformation.data", data[0].FileType + ":" + data[0].FileArchiveFormat + ":" + data[0].FileCompressionMethod);
                    AddToFile(@"CompressionInformation.data", data[1].FileType + ":" + data[1].FileArchiveFormat + ":" + data[1].FileCompressionMethod);

                    data7Z.Clear();
                    dataZip.Clear();
                    data.Clear();
                }
            }
        }

        private void TestFourButton_Click(object sender, EventArgs e)
        {
            TestyWyniki.Text = "";

            if (!absolute7zipRoute.Equals(""))
            {
                for(int i = 0; i < 5; i++)
                {
                    string format = "zip";
                    int speed = (int)CompressionSpeedEnum.Ultra;
                    string method = "";
                    string type = "";
                    string extension = "";
                    if (i == 0)
                    {
                        type = "audiowav";
                        extension = "wav";
                    }
                    if (i == 1) {
                        type = "audiomp3";
                        extension = "mp3";
                    }
                    if (i == 2) {
                        type = "videomov";
                        extension = "mov";
                    }
                    if (i == 3) {
                        type = "videomp4";
                        extension = "mp4";
                    }
                    if (i == 4) {
                        type = "videompg";
                        extension = "mpg";
                    }
                    string filePath = urlToFolder + type;
                    RichTextBox output = TestyWyniki;

                    for (int j = 0; j < Enum.GetNames(typeof(ZipCompresstionTypesEnum)).Length; j++)
                    {
                        method = Enum.GetName(typeof(ZipCompresstionTypesEnum), j);
                        dataZip.Add(compressFile(extension, filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", format.Equals("7z") ? "-m0=" + method : "-mm=" + method, output));
                    }

                    format = "7z";
                    for (int j = 0; j < Enum.GetNames(typeof(SevenZipCompresstionTypesEnum)).Length; j++)
                    {
                        method = Enum.GetName(typeof(SevenZipCompresstionTypesEnum), j);
                        data7Z.Add(compressFile(extension, filePath, absolute7zipRoute, format, speed.ToString(), "archiwum", format.Equals("7z") ? "-m0=" + method : "-mm=" + method, output));
                    }
                    dataZip.Sort();
                    data7Z.Sort();
                    data.Add(dataZip[0]);
                    data.Add(data7Z[0]);
                    data.Sort();

                    AddToFile(@"CompressionInformation.data", data[0].FileType + ":" + data[0].FileArchiveFormat + ":" + data[0].FileCompressionMethod);
                    AddToFile(@"CompressionInformation.data", data[1].FileType + ":" + data[1].FileArchiveFormat + ":" + data[1].FileCompressionMethod);

                    output.Text += System.Environment.NewLine + System.Environment.NewLine + "Najlepszy algorytm dla " + type + " to: " + data[0].FileCompressionMethod.ToString() + " Skompresonwano : " + data[0].FileCompressionRatio.ToString("00.00") + "%" + System.Environment.NewLine + System.Environment.NewLine;
                    data.Clear();
                    data7Z.Clear();
                    dataZip.Clear();
                }
            }
        }

        private void formatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillComboBoxes();
        }

        public void fillComboBoxes()
        {
            if (formatBox.GetItemText(formatBox.SelectedItem) == "zip")
            {
                methodBox.Items.Clear();
                methodBox.Text = "";
                for (int j = 0; j < Enum.GetNames(typeof(ZipCompresstionTypesEnum)).Length; j++)
                {
                    string method = Enum.GetName(typeof(ZipCompresstionTypesEnum), j);

                    methodBox.Items.Add(method);
                }
            }
            if (formatBox.GetItemText(formatBox.SelectedItem) == "7z")
            {
                methodBox.Items.Clear();
                methodBox.Text = "";
                for (int j = 0; j < Enum.GetNames(typeof(SevenZipCompresstionTypesEnum)).Length; j++)
                {
                    string method = Enum.GetName(typeof(SevenZipCompresstionTypesEnum), j);

                    methodBox.Items.Add(method);
                }
            }
        }

        private void SelectBestCompressionButton_Click(object sender, EventArgs e)
        {
            if ((FilePath.Text != "Plik do kompresji" || FolderPath.Text != "Folder do kompresji"))
            {
                string[] files = SelectedFilesText.Lines;
                List<string> extensions = new List<string>();
                string[] directories;
                List<string> dirExc = new List<string>();
                for (int i = 0; i < files.Length - 1; i++)
                {
                    extensions.Add(Path.GetExtension(files[i]));
                    if (Path.GetExtension(files[i]) == "")
                    {
                        directories = Directory.GetFiles(files[i]);
                        
                        for (int j = 0; j < directories.Length; j++)
                        {
                            dirExc.Add(Path.GetExtension(directories[j]));
                        }
                        if (dirExc.Select(s => s.ToLower()).Distinct().Count() == 1)
                        {
                            extensions[i] = dirExc[0];
                        }
                    }
                }
                string extension = "*";
                bool areEqual = extensions.Select(s => s.ToLower()).Distinct().Count() == 1;
                if (areEqual) extension = extensions[0];
                string format;
                
                switch (extension)
                {
                    case ".mp3":
                        formatBox.SelectedIndex = formatBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "mp3").Split(':')[0]);
                        methodBox.SelectedIndex = methodBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "mp3").Split(':')[1]);
                        break;
                    case ".wav":
                        formatBox.SelectedIndex = formatBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "wav").Split(':')[0]);
                        methodBox.SelectedIndex = methodBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "wav").Split(':')[1]);
                        break;
                    case ".bmp":
                        format = string.Empty;

                        if (FolderPath.Text.ToLower().Contains("small"))
                            format = "bmpsmall";
                        if (FolderPath.Text.ToLower().Contains("big"))
                            format = "bmpbig";

                        if (FilePath.Text.ToLower().Contains("small"))
                            format = "bmpsmall";
                        if (FilePath.Text.ToLower().Contains("big"))
                            format = "bmpbig";
                        Console.WriteLine(format);
                        formatBox.SelectedIndex = formatBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", format).Split(':')[0]);
                        methodBox.SelectedIndex = methodBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", format).Split(':')[1]);
                        break;
                    case ".jpg":
                        format = string.Empty;
                       
                        if (FolderPath.Text.ToLower().Contains("small"))
                            format = "jpgsmall";
                        if (FolderPath.Text.ToLower().Contains("big"))
                            format = "jpgbig";

                        if (FilePath.Text.ToLower().Contains("small"))
                            format = "jpgsmall";
                        if (FilePath.Text.ToLower().Contains("big"))
                            format = "jpgbig";
                        Console.WriteLine(format);
                        formatBox.SelectedIndex = formatBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", format).Split(':')[0]);
                        methodBox.SelectedIndex = methodBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", format).Split(':')[1]);
                        break;
                    case ".txt":
                        formatBox.SelectedIndex = formatBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "txt").Split(':')[0]);
                        methodBox.SelectedIndex = methodBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "txt").Split(':')[1]);
                        break;
                    case ".mov":
                        formatBox.SelectedIndex = formatBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "mov").Split(':')[0]);
                        methodBox.SelectedIndex = methodBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "mov").Split(':')[1]);
                        break;
                    case ".mp4":
                        formatBox.SelectedIndex = formatBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "mp4").Split(':')[0]);
                        methodBox.SelectedIndex = methodBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "mp4").Split(':')[1]);
                        break;
                    case ".mpg":
                        formatBox.SelectedIndex = formatBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "mpg").Split(':')[0]);
                        methodBox.SelectedIndex = methodBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "mpg").Split(':')[1]);
                        break;
                    default:
                        formatBox.SelectedIndex = formatBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "*").Split(':')[0]);
                        methodBox.SelectedIndex = methodBox.FindStringExact(ReadFromFile(@"CompressionInformation.data", "*").Split(':')[1]);
                        break;
                }
                extensions.Clear();
                dirExc.Clear();
            }
            if(FilePath.Text == "Plik do kompresji" && FolderPath.Text == "Folder do kompresji")
            {
                MessageBox.Show("Proszę wybrać ścierzkę do pliku/folderu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SelectedFilesText.Text += fbd.SelectedPath + System.Environment.NewLine;
                    FolderPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            x.Multiselect = true;
            x.ShowDialog();
            string[] result = x.FileNames;

            foreach (string y in result)
            {
                SelectedFilesText.Text += y + System.Environment.NewLine;
                FilePath.Text = y;
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectedFilesText.Clear();
            formatBox.SelectedIndex = -1;
            methodBox.SelectedIndex = -1;
            methodBox.Items.Clear();
            FilePath.Text = "Plik do kompresji";
            FolderPath.Text = "Folder do kompresji";
        }
    }
}
