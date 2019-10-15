using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelMe.Models;

namespace TravelMe4.Extensions
{
    public static class ThumbnailExtension
    {
        public static IEnumerable<ThumbnailModel> GetBookThumbnail(this List<ThumbnailModel> thumbnails, ApplicationDbContext db = null, string search = null)
        {
            try
            {
                if (db == null)
                {
                    db = ApplicationDbContext.Create();
                }

                thumbnails = (from p in db.Posts
                              select new ThumbnailModel
                              {
                                  PostId = p.ID,
                                  Title = p.Title,
                                  Body= p.Body,
                                  ImageUrl = p.ImageUrl,
                                  Link = "/PostDetails/Index/" + p.ID
                              }
                              ).ToList();

                if (search != null)
                {
                    return thumbnails.Where(t => t.Title.ToLower().Contains(search.ToLower())).OrderBy(t => t.Title);
                }
            }
            catch (Exception e) { }

            return thumbnails.OrderBy(b => b.Title);

        }
    }
}