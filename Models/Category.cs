using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelMe_webapp.Models
{
    public class Category
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
