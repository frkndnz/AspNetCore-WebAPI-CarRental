using System.Diagnostics;
using System.Linq.Expressions;
using CarRental.DTO_s.Rental;
using CarRental.Services.Abstract;
using SelectPdf;

namespace CarRental.Services.Concrete
{
    public class PdfService : IPdfService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PdfService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<byte[]> GenerateRentalPdfAsync(RentalDTO model)
        {
            string _templatePath = Path.Combine(_webHostEnvironment.WebRootPath, "Templates", "rental-template.html");
            string htmlTemplate = await File.ReadAllTextAsync(_templatePath);

            string html = htmlTemplate
            .Replace("{UserFullName}", model.UserFullName)
            .Replace("{UserEmail}", model.UserEmail)
            .Replace("{UserPhone}", model.UserPhone)
            .Replace("{CarBrand}", model.CarBrand)
            .Replace("{CarModel}", model.CarModel)
            .Replace("{RentalStartDate}", model.RentalStartDate.ToShortDateString())
            .Replace("{RentalEndDate}", model.RentalEndDate.ToShortDateString())
            .Replace("{Price}", model.Price.ToString())
            .Replace("{CompanyLogo}", "/images/company-logo.png")
            .Replace("{GenerationDate}", DateTime.Now.ToString("dd.MM.yyyy HH:mm"))
            .Replace("{DocumentNumber}", GenerateDocumentNumber());

            HtmlToPdf converter=new HtmlToPdf();

            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.MarginLeft = 10;
            converter.Options.MarginRight = 10;
            converter.Options.MarginTop = 10;
            converter.Options.MarginBottom = 10;

            PdfDocument doc=converter.ConvertHtmlString(html);
            byte[] pdf = doc.Save();
            doc.Close();
            return pdf;

        }

        private string GenerateDocumentNumber() 
        {
            return $"DOC-{Guid.NewGuid().ToString("N").Substring(0,8)}";
        }
    }
}
