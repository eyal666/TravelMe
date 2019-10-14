using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelMe_webapp.Models;

namespace TravelMe.ViewModel
{
    public class PostViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Post Post{ get; set; }
    }
}