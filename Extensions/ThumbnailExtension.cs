using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelMe.Models;
using TravelMe.Utils;
using TravelMe_webapp.Models;

namespace TravelMe.Extensions
{
    public static class ThumbnailExtension
    {
        public static IEnumerable<ThumbnailModel> GetPostThumbnail(
            this List<ThumbnailModel> thumbnails,
            ApplicationDbContext db = null,
            string search = null,
            bool r1 = false,
            bool r2 = false,
            bool r3 = false,
            bool r4 = false,
            bool r5 = false,
            string searchOpt = null
            )
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
                                  Body = p.Body,
                                  ImageUrl = p.ImageUrl,
                                  Link = "/PostDetails/Index/" + p.ID,
                                  Post = p,
                                  Place = p.Place
                              }
                              ).ToList();
                List<ThumbnailModel> helper = thumbnails;
                if (r1)
                {
                    helper.RemoveAll(t => t.Post.Rating != 1);
                }
                if (r2)
                {
                    helper.RemoveAll(t => t.Post.Rating != 2);
                }
                if (r3)
                {
                    helper.RemoveAll(t => t.Post.Rating != 3);
                }
                if (r4)
                {
                    helper.RemoveAll(t => t.Post.Rating != 4);
                }
                if (r5)
                {
                    helper.RemoveAll(t => t.Post.Rating != 5);
                }
                if (!String.IsNullOrEmpty(search) && searchOpt != null)
                {
                    if (searchOpt.Equals(SD.byPlaceName))
                    {
                        return helper.Where(t => t.Place.Address.ToLower().Contains(search.ToLower()));
                    }
                    else if (searchOpt.Equals(SD.byTitle))
                    {
                        return helper.Where(t => t.Title.ToLower().Contains(search.ToLower()));
                    }
                    else if (searchOpt.Equals(SD.byBody))
                    {
                        return helper.Where(t => t.Body.ToLower().Contains(search.ToLower()));
                    }
                }

            }
            catch (Exception) { }

            return thumbnails.OrderByDescending(t => t.Post.DateAdded);

        }
    }
}