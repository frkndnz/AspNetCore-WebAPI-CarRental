namespace CarRental.Models
{
    public class User:BaseEntity
    {
        public string Name {  get; set; }=string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; }
    }
}
