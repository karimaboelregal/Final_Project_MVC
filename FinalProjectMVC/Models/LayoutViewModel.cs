﻿using Models.Models;

namespace FinalProjectMVC.Models
{
    public class LayoutViewModel
    {
        public List<Category> categories { get; set; }
        public Cart? Cart { get; set; } 
    }
}
