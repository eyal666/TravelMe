using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelMe_webapp.Models
{
    public class Post
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int PlaceID { get; set; }
        [Required]
        [Range(0, 5)]
        public float Rating { get; set; }
        public int NumOfViews { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0: dd mm yyyy}")]
        public DateTime DateAdded { get; set; }
        [Required]
        public Place Place { get; set; }
    }
}
