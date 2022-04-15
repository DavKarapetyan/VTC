using System.ComponentModel.DataAnnotations;

namespace VTC.Common.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password don't match")]
        public string ConfirmPassword { get; set; }
    }
}
