using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace FileAnalyzer_Console.FileReaders
{
    public class DocxFileReader
    {
        public string ReadText(string filePath) // docx dormatındaki dosyalardaki metni okuma işlemi de neredeyse pdf deki metni okuma işlemi ile aynı.
        {
            StringBuilder sb = new StringBuilder(); // stringbuilder aynı string gibi bir sınıf, int decimal ise birer veri tipi. stringbuilder ın string den farkı değiştirilebilir olması.

            WordprocessingDocument docx = WordprocessingDocument.Open(filePath, false); // WordprocessingDocument sınıfı ile tüm metin, tablo, resim vb. içeriği tutuyoruz.

            Body body = docx.MainDocumentPart.Document.Body; // Body sıınıfı ile docx dosyasının ana kısımlarını alıyoruz. metin, resim, tablo vb. geriye kalan araçlar, yorumlar, ek veriler filtreleniyor.

            foreach (var paragraf in body.Elements<Paragraph>()) // body deki her bir resimli tablolu metinli paragrafı paragraf isimli değişkene atıyoruz. buradaki her bir paragraf enter tuşu ile ayrılıyor.
            {
                sb.AppendLine(paragraf.InnerText); // paragraftaki yalnızca text leri stringbuilder a ekliyoruz.
            }

            docx.Dispose(); // dispose ile docx i kapatıyoruz. kapatma işlemi için dispose kullanmak eğer dispose desteklenmiyorsa close kullanmak daha mantıklı.

            return sb.ToString();
        }
    }
}
