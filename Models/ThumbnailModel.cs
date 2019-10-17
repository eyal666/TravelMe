using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TravelMe_webapp.Models;

namespace TravelMe.Models
{
    public class ThumbnailModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
        public Post Post { get; set; }
        public Place Place { get; set; }

    }
}