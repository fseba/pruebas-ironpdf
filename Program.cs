using PruebaIronPDF;
string basePath = "";
#if DEBUG
basePath = @"C:\Users\sflor\Desarrollo\IronPDF\PruebaIronPDF";
#else
basePath = @$"{Directory.GetCurrentDirectory()}";
#endif

string inputPath = $@"{basePath}\Input";
string outputPath = $@"{basePath}\Output";

if (!Directory.Exists(outputPath))
    Directory.CreateDirectory(outputPath);

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Paso 1: String HTML a PDF");
Console.WriteLine(" - Espere un momento...");

PDFConverter converter = new PDFConverter(outputPath);
var htmlStr = "<h1>Ironsoftware</h1>";
converter.StringHTMLToPDF(htmlStr, "1-String_HTML");

Console.WriteLine("Paso 2: Archivo HTML a PDF");
Console.WriteLine(" - Espere un momento...");
var htmlFilePath = $@"{inputPath}\InvoiceTemplate.html";
converter.HTMLFileToPDF(htmlFilePath, "2-HTML_File");

Console.WriteLine("Paso 3: Archivo HTML con JavaScript a PDF");
Console.WriteLine(" - Espere un momento...");
var htmlFilePath2 = $@"{inputPath}\D3jsSample.html";
converter.HTMLFileToPDF(htmlFilePath2, "3-HTML_JS_File");

Console.WriteLine(" ");
Console.WriteLine("Trabajo terminado, presione una tecla para finalizar...");
Console.ReadLine();
