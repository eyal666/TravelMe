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
                List<ThumbnailModel> helper = new List<ThumbnailModel>();
                if (r1) AddToHelper(1, helper, thumbnails);
                if (r2) AddToHelper(2, helper, thumbnails);
                if (r3) AddToHelper(3, helper, thumbnails);
                if (r4) AddToHelper(4, helper, thumbnails);
                if (r5) AddToHelper(5, helper, thumbnails);

                if (!String.IsNullOrEmpty(search) && searchOpt != null)
                {
                    if (helper.Count() == 0)
                    {
                        helper = thumbnails;
                    }
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
                if (r1 || r2 || r3 || r4 || r5)
                {
                    thumbnails = helper;
                    return thumbnails.OrderByDescending(t => t.Post.Rating).ThenByDescending(t => t.Post.DateAdded);
                }

            }
            catch (Exception) { }
            return thumbnails.OrderByDescending(t => t.Post.DateAdded);

        }

        public static void AddToHelper(int r, List<ThumbnailModel> helper, List<ThumbnailModel> thumbnails)
        {
            var filteredThumbs = thumbnails.FindAll(t => t.Post.Rating == r);
            foreach (var t in filteredThumbs)
            {
                helper.Add(t);
            }
        }
    }
}