using System;
using System.Collections.Generic;

namespace Jordana.Models
{
    public partial class SiteMedium
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public int? SiteId { get; set; }
        public int MediaId { get; set; }
        public string Type { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual TouristsSite? Site { get; set; }
    }
}
