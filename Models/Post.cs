﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Body { get; set; }
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public int PlaceID { get; set; }
        [Required]
        [Range(0, 5)]
        public float Rating { get; set; }
        [DisplayName("View Count")]
        public int NumOfViews { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        [DisplayName("Date Added")]
        public DateTime DateAdded { get; set; }
        [Required]
        public Place Place { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public Category Category { get; set; }

    }
}
