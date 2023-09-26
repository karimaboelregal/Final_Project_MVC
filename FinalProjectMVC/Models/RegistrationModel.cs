using System.ComponentModel.DataAnnotations;

namespace FinalProjectMVC.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string FullName { get; set; }
    }

}
