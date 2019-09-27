using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelMe_webapp.Models
{
    public class PlaceCatagory
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int PlaceID { get; set; }
        [Required]
        public int CatagoryID { get; set; }
        [Required]
        public Place Place { get; set; }
        [Required]
        public Category Category { get; set; }
    }
}
