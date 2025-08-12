using System;
using System.IO; 
using FileAnalyzer_Console.FileReaders;
using System.Windows.Forms;

namespace FileAnalyzer_Console
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string filePath = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*|  Text Files (*.txt)|*.txt|  Word Documents (*.docx)|*.docx|  PDF Files (*.pdf)|*.pdf";

            openFileDialog.Title = "FileAnalyzer";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
            else
            {
                Console.WriteLine("No file selected.");
                return;
            }


            if (File.Exists(filePath) == false)
            {
                Console.WriteLine("File not found!");
                return;
            }

            string extension = Path.GetExtension(filePath).ToLower();
            string content = "";

            try
            {
                if (extension == ".txt")
                {
                    var txtReader = new TxtFileReader();
                    content = txtReader.ReadText(filePath);
                }
                else if (extension == ".docx")
                {
                    var docxReader = new DocxFileReader();
                    content = docxReader.ReadText(filePath);
                }
                else if (extension == ".pdf")
                {
                    var pdfReader = new PdfFileReader();
                    content = pdfReader.ReadText(filePath);
                }
                else
                {
                    throw new Exception("Unsupported file type");
                }

                var analyzer = new TextAnalyzer();
                analyzer.AnalyzeFile(content);
            }
            catch (Exception ex)
            {
                Directory.CreateDirectory("Logs");
                string logPath = Path.Combine("Logs", "log.txt");

                File.AppendAllText(logPath, Environment.UserName);
                File.AppendAllText(logPath, Environment.NewLine);
                File.AppendAllText(logPath, DateTime.Now.ToString("dd.MM.yyyy HH.mm"));
                File.AppendAllText(logPath, Environment.NewLine);
                File.AppendAllText(logPath, ex.Message);
                File.AppendAllText(logPath, Environment.NewLine);
                File.AppendAllText(logPath, ex.StackTrace);
                File.AppendAllText(logPath, Environment.NewLine);
            }
        }
    }
}