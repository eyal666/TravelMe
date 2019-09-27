using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelMe_webapp.Models
{
    public class User
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Email { get; set; } //username
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }
        public int NumOfPosts { get; set; }
    }
}
