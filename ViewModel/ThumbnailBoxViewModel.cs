using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelMe.Models;

namespace TravelMe.ViewModel
{
    public class ThumbnailBoxViewModel
    {
        public IEnumerable<ThumbnailModel> Thumbnails { get; set; }
    }
}