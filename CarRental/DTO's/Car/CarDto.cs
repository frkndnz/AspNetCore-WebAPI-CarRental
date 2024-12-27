namespace CarRental.DTO_s.Car
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string CategoryName { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
    }
}
