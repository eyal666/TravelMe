using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelMe.ViewModel
{
    public class PostVM
    {
        [Required]
        public string CategoryName { get; set; }
    }
}