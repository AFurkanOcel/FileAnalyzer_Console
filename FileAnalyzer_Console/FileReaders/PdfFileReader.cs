using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using UglyToad.PdfPig;

namespace FileAnalyzer_Console.FileReaders
{
    public class PdfFileReader
    {
        public string ReadText(string filePath)
        {
            #region StringBuilder() kullanarak
            var sb = new StringBuilder(); // StringBuilder sayfa sayfa okunan tüm metinleri birleştirip tek bir string halinde tutuyoruz. sayfa 1 den sayfa 2 den ... gelen stringler tutuluyor. string kullanmadık çünkü stringler değiştirilemez, bu nedenle her ekleme vb. işlemde yeni bir string oluşturacaktı bu da hafıza da gereksiz yer tutar. liste kullanılmış halinde ise her eleman ayrı birer eleman olarak kaydedilir; "ali", "veli" gibi en son join diyerek "ali veli" şeklinde tek bir elemana çeviririz, string builder da buna gerek kalmaz.

            var pdf = PdfDocument.Open(filePath); // PDF dosyasını açtıkve pdf sadece metin içermediği için ilk olarak var olarak kaydettik.

            foreach (var page in pdf.GetPages()) // GetPages() metodu pdf in sayfalarını ayırıyor. Bu döngüde her sayfayı ayrı ayrı alıp stringbuilder a ekliyoruz.
            {
                sb.AppendLine(page.Text); // her sayfanın içeriğindeki metni, page.Text ile string olarak stringbuilder a tek tek ekliyoruz, "sayfa1icerik sayfa2icerik ..." seklinde. 
            }

            pdf.Dispose(); // PdfDocument sınıfında Close() metodu yok onun yerine benzer amaçlı kullanılan Dispose() metodunu kullandık.

            return sb.ToString(); // var olarak kaydettiğimiz sb yi stringe cevirip return ettik.
            #endregion

            #region liste kullanarak
            //List<string> lines = new List<string>();

            //var pdf = PdfDocument.Open(filePath);

            //foreach (var page in pdf.GetPages())
            //{
            //    lines.Add(page.Text); // Her sayfanın metnini listeye ayrı birer eleman olarak ekliyoruz.
            //}

            //pdf.Dispose(); // açtığımız pdf i kapatıyoruz.

            //return string.Join(Environment.NewLine, lines); //  Enviorenment.NewLine kullanarak her sayfadan sonra bir satır aşağı inerek sayfaları ayırıyoruz, ayrı eleman olarak tanımlanan her bir sayfayı join ile tek bir eleman haline getiriyoruz. sonuç olarak tek bir string halinde düzenli metin oluyor; "sayfa1 \r\n sayfa2 \r\n ..." seklinde.
            #endregion
        }
    }
}
