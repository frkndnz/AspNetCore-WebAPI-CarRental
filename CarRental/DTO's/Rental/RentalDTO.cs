namespace CarRental.DTO_s.Rental
{
    public class RentalDTO
    {
        public string? UserFullName {  get; set; }
        public string? UserEmail {  get; set; }
        public string? UserPhone {  get; set; }
        public string? CarBrand {  get; set; }  
        public string? CarModel {  get; set; }  

        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal Price { get; set; }
    }
}
