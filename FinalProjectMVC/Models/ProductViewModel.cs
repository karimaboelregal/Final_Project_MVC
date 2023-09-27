﻿using Models.Models;

namespace FinalProjectMVC.Models
{
    public class ProductViewModel : LayoutViewModel
    {
        public List<Product> products { get; set; }
        public List<Order> orders { get; set; }
        public LoginModel login { get; set; }
        public  RegistrationModel registration { get; set; }    
    }
}
