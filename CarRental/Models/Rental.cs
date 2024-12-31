namespace CarRental.Models
{
    public class Rental:BaseEntity
    {
        public int CarId { get; set; }
        public Car? Car { get; set; } // navigation prop
        public int UserId {  get; set; }
        public User? User{ get; set; } // nav prop
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal Price {  get; set; }
    }
}
