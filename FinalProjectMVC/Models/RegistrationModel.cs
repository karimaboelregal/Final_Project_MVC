using System.ComponentModel.DataAnnotations;

namespace FinalProjectMVC.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        //[Required]
        //[MaxLength(12)]
        //public string Phone { get; set; }
        //[Required]
        //public string Address { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
