using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
//using System.Drawing;

namespace SpirePdfConvertPdfToJpgPOCNet6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				string spirePdfLicence = "YmsaJ5kZGigBAAdC/qCHgkL0tzWkP1F7s+PKGF+xxe8JptFH/L6ozwiYBR9GXAz+KPX6B1hcRzfQ9jGMoBk1OpWi3pgMknzA2+RSaBmpd9WQ9l7S2XR7Aru0iF6vmtkfgNR3un6W45gy1rlFauXJxpOnp0Hw4EDzisSlI8Ekx8iKN5Ar6hfYARVggkxXUeAwgtpn68ue8NMagQ9V27Zon00aZ1UWW9hv0tGSV6JZkKZeOTFGld+NgdcwgDurqIxfv+B5oeYPJggLB3UNjT72eQgSFhmwz6Fj/OB8KJF9O8GhZJXuMep+NGTPfbA+Zn+6pxUy0JQe9Syj8docl/fdxP5f/mthTM4XbnM167REBgiBxBvkgvhOkTvAwFm98Z9Z2j3DksHoJ5jrVyPZd/7LrlCgel07q7rUOJh9PW1NpuIrm25oEnekPSuNK5cK/GUITUM3MSJGe0yzrGB4x+T5Wlx6Nt9BYigda0Der2CLrjlTx75KlFma5TJRNzSO5aN8EMOUlrV4Sq1Jw+Qj40xnw2zBlYTwxwOcLIfOptzWmg4MB1m+7KZJ+MdXxJQzb64W7zPiOftgsNyV/Fo0o5camA/YWoIOThZqNyLptKs6FXu4KUPU/MScVui9eyDYZsrFiJmvwNvfM8AB9Rd6xjcAc4n2NVcXw6mLA9DqzJl6vM3YICTxHiD8rfvJ0bOcBYr0GAXRkuN+hx9vz23Icq4ahTtEmffJcL9KnY68NUhfNYfgjKrZNQ0aWfur4AkRGdevGl2ynhV/yMcLkZ9w6SRLws55eAAGDbtR8qsOiD4AUSZT+7ijBJmmaUCCKRQ7/7t7ly7hRLW75JkufUHiaOl1NG2azacmUSrwvgEmDuhhWH8Q4ESq2Uv1QBA2CxYh4oxHcSuKEa1N12Xh2qYgtT5AOPPN+OdNVboyyOFuAbhXzAfDkC26S52M2fVyTZbBNnD284C/K6+XtJaJt9VeMf528gLBDzeSnfQEyfDESMbH5SNVBuRWt4TxkVXNsSkzGEKK1Q4Ba7pC73Nl2QuN7EvZH2GY9d2phtHrblnc4jhGRkDqxIedlNZsKQ5GemoYtKxnTj6oNsKrR41kau6HrNcx53nMMn21m/T6yDxBTYuPl4FXXT+ubP42PTCDaAzrDjUpgQWebL8TtSSwA4TtLuVyj92C3WbPiYlnGBHPIRkuUkN4Jv+IDQFtmccdrMQmh++8MbvG6bUGoN569pT/cpEbaxNjpoZG8YoQS8lErrnfhpMMwZqd5u0mAx2pegUNiJbQSB/3m6oRPatBSmH0M3nns59fIUW/p36C3EVDP7Th6bPPiounVN9qmqJdZ/2t1BqmM6EwL2IsaAHdbvmnWSGHnf+BKDA6ZgccCrmLIkPuT6jGM4yL2iKIri17Y7oQw5lVUOq2FMp0rqk8SumxfuLr3BmBaItnNGhrvz4YTWNyaDKh3+l/g0BQbGYYUe420Qi+JJ2wQBrHE6WgTRHDf/d5EGsge4/qDcJPff0Q7U8p8LkIgnBv6gpkTh0snol1VGOAUk1uvChI5s+Iwdfiu7AI7Zy0u9yBtpNyFyojlXqZjJmLD5y/We4xFQ==";
				Spire.License.LicenseProvider.SetLicenseKey(spirePdfLicence);

				// Load document from local
				//string filePath = "./PdfToConvert/sampletwo.pdf";
				//string filePath = "./PdfToConvert/good.pdf";
				//string filePath = "./PdfToConvert/Watt&Wolt_Nov.pdf";
				string filePath = "./PdfToConvert/UserManual.pdf";

				//string fileName = "sampletwo";
				//string fileName = "good";
				//string fileName = "Watt&Wolt_Nov";
				string fileName = "UserManual";

				//var path = "C:\\00_Development\\GitHub\\SpirePdfConvertPdfToJpgPOC\\NET3.1\\ImagesGenerated\\";
				//var path = "C:\\development\\POC\\SpirePdfConvertPdfToJpgPOC\\SpirePdfConvertPdfToJpgPOC\\ImagesGenerated\\";

				byte[] fileData = File.ReadAllBytes(filePath);
				//Console.WriteLine(String.Join(',', fileData));

				PdfDocument document = new PdfDocument();

				document.LoadFromBytes(fileData);
				//Console.WriteLine(document.ToString());

				var pages = document.Pages.Count;

				var path = Directory.GetCurrentDirectory();
				Console.WriteLine(path);

				for (int page = 0; page < pages; page++)
				{
					string internalFileName = $"{fileName}_page_{page + 1}.jpg";

					using (Stream bmp = document.SaveAsImage(page))
					{
						byte[] bt = new byte[bmp.Length];
						bmp.Read(bt, 0, bt.Length);
						bmp.Flush();
						bmp.Close();
						File.WriteAllBytes(internalFileName, bt);
					}

				}

				Console.WriteLine("Loop Exited");

				document.Close();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error converting to image files in PdfToImagesConversion: " + ex);
			}
		}


		//public static byte[] ImageToByteArray(Image img)
		//{
		//	MemoryStream ms = new MemoryStream();
		//	img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
		//	return ms.ToArray();
		//}
	}
}