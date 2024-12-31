namespace CarRental.DTO_s.Rental
{
    public class CreateRentalDTO
    {
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
    }
}
