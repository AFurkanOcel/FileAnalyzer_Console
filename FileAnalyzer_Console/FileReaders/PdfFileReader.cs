using System.Text;
using UglyToad.PdfPig;

namespace FileAnalyzer_Console.FileReaders
{
    public class PdfFileReader
    {
        public string ReadText(string filePath)
        {
            #region StringBuilder() kullanarak
            var sb = new StringBuilder();

            var pdf = PdfDocument.Open(filePath);

            foreach (var page in pdf.GetPages())
            {
                sb.AppendLine(page.Text);
            }

            pdf.Dispose();

            return sb.ToString();
            #endregion
        }
    }
}
