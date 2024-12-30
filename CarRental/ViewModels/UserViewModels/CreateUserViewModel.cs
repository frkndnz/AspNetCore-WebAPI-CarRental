using System.ComponentModel.DataAnnotations;

namespace CarRental.ViewModels.UserViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50,ErrorMessage ="Name can't exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't exceed 50 characters")]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid email format")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage ="Phone is required")]
        public string Phone { get; set; }
    }
}
