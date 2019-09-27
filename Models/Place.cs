using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelMe_webapp.Models
{
    public class Place
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; } //Coordinates //convert to double long, double lat
        public float? AvgRating { get; set; }
        [Required]
        public int NumOfPosts { get; set; }
    }
}
