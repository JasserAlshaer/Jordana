using System;
using System.Collections.Generic;

namespace Jordana.Models
{
    public partial class UserFavorite
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public int FavId { get; set; }
        public int? UserId { get; set; }
        public int? SiteId { get; set; }

        public virtual TouristsSite? Site { get; set; }
        public virtual User? User { get; set; }
    }
}
