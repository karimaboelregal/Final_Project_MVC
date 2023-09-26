using FinalProjectMVC.Areas.Identity.Pages.Account;
using Models.Models;

namespace FinalProjectMVC.Models
{
    public class ProductViewModel : LayoutViewModel
    {
        public List<Product> products { get; set; }
        public LoginModel loginmodel { get; set; }
        public RegistrationModel registrationmodel { get; set; }
    }
}
