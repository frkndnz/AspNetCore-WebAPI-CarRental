using CarRental.DTO_s.Rental;

namespace CarRental.Services.Abstract
{
    public interface IPdfService
    {
        public  Task<byte[]> GenerateRentalPdfAsync(RentalDTO model);
    }
}
