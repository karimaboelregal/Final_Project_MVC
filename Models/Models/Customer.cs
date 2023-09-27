using Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{

    public class Customer : User
    {
        [MaxLength(12)]
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
