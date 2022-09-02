using IronPdf;

namespace PruebaIronPDF
{
    internal class PDFConverter
    {
        private string outputPath;

        public PDFConverter(string outputPath)
        {
            this.outputPath = outputPath;
        }

        public void StringHTMLToPDF(string htmlStr, string pdfFileName)
        {
            // Create a PDF from an existing HTML using C#
            var Renderer = new HtmlToPdf();
            var PDF = Renderer.RenderHtmlAsPdf(htmlStr);

            Console.WriteLine($@" - Output: {outputPath}\{pdfFileName}.pdf");            
            PDF.SaveAs($@"{outputPath}\{pdfFileName}.pdf");
            Console.WriteLine(" - Finalizó correctamente");
        }

        public void HTMLFileToPDF(string htmlFilePath, string pdfFileName)
        {
            // Install IronPdf with Nuget:  PM> Install-Package IronPdf
            HtmlToPdf Renderer = new HtmlToPdf();
            
            //Choose screen or print CSS media
            Renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Screen;
            
            //Set the width of the responsive virtual browser window in pixels
            Renderer.PrintOptions.ViewPortWidth = 1280;
            
            // Render an HTML document or snippet as a string
            var PDF = Renderer.RenderHTMLFileAsPdf(htmlFilePath);

            Console.WriteLine($@" - Output: {outputPath}\{pdfFileName}.pdf");            
            PDF.SaveAs($@"{outputPath}\{pdfFileName}.pdf");
            Console.WriteLine(" - Finalizó correctamente");
        }

        public void HTMLWithJavaScriptToPDF(string htmlFilePath, string pdfFileName)
        {
            var Renderer = new HtmlToPdf();
            Renderer.PrintOptions.EnableJavaScript = true;
            Renderer.PrintOptions.RenderDelay = 500;
            Renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Print;

            var PDF = Renderer.RenderHTMLFileAsPdf(htmlFilePath);
            
            Console.WriteLine($@" - Output: {outputPath}\{pdfFileName}.pdf");            
            PDF.SaveAs($@"{outputPath}\{pdfFileName}.pdf");
            Console.WriteLine(" - Finalizó correctamente");
        }
    }
}