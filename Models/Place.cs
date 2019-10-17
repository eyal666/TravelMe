using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Address { get; set; }
        [Required]
        public double Longtitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [DisplayName("Avarage Rating")]
        public float? AvgRating { get; set; }
        [Required]
        [DisplayName("Posts Count")]
        public int NumOfPosts { get; set; }

    }
}
