using System;
using System.Collections.Generic;
using System.IO; // dosya, klasör işlemlerinde bize (Path, File, FileStream, StreamReader) gibi sınıfları sağlayan .NET kütüphanesi.
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAnalyzer_Console.FileReaders;
using System.Windows.Forms;

namespace FileAnalyzer_Console
{
    public class Program
    {
        [STAThread] // file dialog kullandığımız için kullanammız gerekiyor, sta yani single-threaded apartment ile file dialog un yalnızca bizim thread ile kullanılmasını diğer thread ler erişmeye çalışırsa, diğer thread lerin engellenmesi sağlanıyor.
        static void Main(string[] args)
        {
            string filePath = "";

            OpenFileDialog openFileDialog = new OpenFileDialog(); // OpenFileDialog file dialog u açmaya yarayan bir araç.
            openFileDialog.Filter = "All files (*.*)|*.*|  Text Files (*.txt)|*.txt|  Word Documents (*.docx)|*.docx|  PDF Files (*.pdf)|*.pdf"; // burada filter ile file dialog üzerinde yalnızca istediğimiz dosya formatlarının görünmesini sağlıyoruz.

            openFileDialog.Title = "FileAnalyzer";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName; // erişilen dosyanın adını filePath a atıyoruz. Bu dosya adını FileReader lara gönderip, dosyayı okuycaz ve sonrasında ise Textanalyzer gönderip, dosyayı analiz edicez.
            }
            else
            {
                Console.WriteLine("No file selected."); // file dialog herhangi bir dosya seçilmeden kapatılırsa konsola "dosya seçilmedi" uyarısını döndürücez.
                return;
            }


            if (File.Exists(filePath) == false) // dosya var mı kontrolü yapıyoruz.
            {
                Console.WriteLine("File not found!");
                return;
            }

            string extension = Path.GetExtension(filePath).ToLower(); // dosyanın uzantısını aldık ve .txt ve .TXT gibi uzantıları farklı algılamaması adına tüm uzantıları TOLower() ile küçük harfe çevirdik.
            string content = ""; // FileReader da okunan ve stringe dönüştürülen içeriği, başlangıçta boş olarak tanımladığımız content değişkenine atıcaz.

            try // try catch ile hata ayıklama yapıcaz.
            {
                if (extension == ".txt") // extension a atanan uzantı .txt ise TxtFileReader çağrılıyor.
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
                analyzer.Analyze(content);  // son olarak analiz işlemi için TextAnalyzer() sınıfının içerisindeki Analyze metodunu çağırıyoruz, content i yani string halindeki içeriği gönderiyoruz. 
            }
            catch (Exception ex) // bu işlemler yürütülürken oluşan hataları yakalıyoruz. Exception ex ile her türden hata yakalanıyor.
            {
                Directory.CreateDirectory("Logs"); // Logs isimli bir klasör oluşturuyoruz alınan hata mesajlarını buraya kaydedicez.
                string logPath = Path.Combine("Logs", "log.txt");

                // hata mesajının hangi kullanıcı tarafından, hangi tarihte alındığı vb. bilgileri logluyoruz.
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