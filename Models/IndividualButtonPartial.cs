using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TravelMe.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }
        public int? CategoriesId { get; set; }
        public int? PlaceId { get; set; }
        public int? PostId { get; set; }
        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");
                if (PostId != null && PostId > 0)
                {
                    param.Append(String.Format("{0}", PostId));
                }
                if (CategoriesId != null && CategoriesId > 0)
                {
                    param.Append(String.Format("{0}", CategoriesId));
                }
                if (PlaceId != null && PlaceId > 0)
                {
                    param.Append(String.Format("{0}", PlaceId));
                }

                return param.ToString();
            }
        }

    }
}