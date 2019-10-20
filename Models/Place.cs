using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelMe_webapp.Models
{
  public class Place
  {

    [Required]
    public int ID { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public double Longtitude { get; set; }
    [Required]
    public double Latitude { get; set; }
    [DisplayName("Avarage Rating")]
    public float? AvgRating { get; set; }
    [Required]
    [DisplayName("Posts Count")]
    public int NumOfPosts { get; set; }
    public string PostsIdList { get; set; }
    public void AddPostID(int id)
    {
      string str = id.ToString();
      StringBuilder sb = new StringBuilder(PostsIdList);
      PostsIdList = sb.Length == 0 ? sb.Append(str).ToString() : sb.Append(',' + str).ToString();
    }
    public void RemovePostID(int id)
    {
      string str = id.ToString();
      StringBuilder sb = new StringBuilder(PostsIdList);

      if (PostsIdList.StartsWith(str) && PostsIdList.Contains(','))
      {
        sb.Replace(str + ',', "");
      }
      else if (PostsIdList.StartsWith(str))
      {
        sb.Replace(str, "");
      }
      else
      {
        sb.Replace("," + str, "");
      }
      PostsIdList = sb.ToString();
    }
  }
}
