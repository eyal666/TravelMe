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

                //if (!String.IsNullOrEmpty(search))
                //{
                //    return thumbnails.Where(t => t.Title.ToLower().Contains(search.ToLower())).OrderBy(t => t.Title);
                //}
                if (!String.IsNullOrEmpty(search) && searchOpt != null)
                {
                    if (searchOpt.Equals(SD.byPlaceName))
                    {
                        return thumbnails.Where(t => t.Place.Address.ToLower().Contains(search.ToLower()));
                    }
                    else if (searchOpt.Equals(SD.byTitle))
                    {
                        return thumbnails.Where(t => t.Title.ToLower().Contains(search.ToLower()));
                    }
                    else if (searchOpt.Equals(SD.byBody))
                    {
                        return thumbnails.Where(t => t.Body.ToLower().Contains(search.ToLower()));
                    }
                }

                if (r1)
                {
                    var filteredThumbs = thumbnails.FindAll(t => t.Post.Rating == 1);
                    foreach (var t in filteredThumbs)
                    {
                        helper.Add(t);
                    }
                }
                if (r2)
                {
                    var filteredThumbs = thumbnails.FindAll(t => t.Post.Rating == 2);
                    foreach (var t in filteredThumbs)
                    {
                        helper.Add(t);
                    }
                }
                if (r3)
                {
                    var filteredThumbs = thumbnails.FindAll(t => t.Post.Rating == 3);
                    foreach (var t in filteredThumbs)
                    {
                        helper.Add(t);
                    }
                }
                if (r4)
                {
                    var filteredThumbs = thumbnails.FindAll(t => t.Post.Rating == 4);
                    foreach (var t in filteredThumbs)
                    {
                        helper.Add(t);
                    }
                }
                if (r5)
                {
                    var filteredThumbs = thumbnails.FindAll(t => t.Post.Rating == 5);
                    foreach (var t in filteredThumbs)
                    {
                        helper.Add(t);
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
    }
}