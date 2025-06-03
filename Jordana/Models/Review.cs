using System;
using System.Collections.Generic;

namespace Jordana.Models
{
    public partial class Review
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public string Rating { get; set; } = null!;
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public virtual TouristsSite Site { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public bool? IsAccepted { get; set; }
    }
}
