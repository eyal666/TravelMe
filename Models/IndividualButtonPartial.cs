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
        public int? GenreId { get; set; }
        public int? PostId { get; set; }
        public int? CustomerId { get; set; }
        public int? MembershipTypeId { get; set; }
        public string userId { get; set; }
        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");
                if (PostId != null && PostId > 0)
                {
                    param.Append(String.Format("{0}", PostId));
                }
                if (GenreId != null && GenreId > 0)
                {
                    param.Append(String.Format("{0}", GenreId));
                }
                if (CustomerId != null && CustomerId > 0)
                {
                    param.Append(String.Format("{0}", CustomerId));
                }
                if (MembershipTypeId != null && MembershipTypeId > 0)
                {
                    param.Append(String.Format("{0}", MembershipTypeId));
                }
                if (userId != null && userId.Trim().Length > 0)
                {
                    param.Append(String.Format("{0}", userId));
                }

                return param.ToString();
            }
        }

    }
}