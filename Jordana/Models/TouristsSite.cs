using System;
using System.Collections.Generic;

namespace Jordana.Models
{
    public partial class TouristsSite
    {
        public TouristsSite()
        {
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
            SiteMedia = new HashSet<SiteMedium>();
            UserFavorites = new HashSet<UserFavorite>();
        }

        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; } = null!;
        public string SiteDescription { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string SiteLocation { get; set; } = null!;
        public double Lat { get; set; }
        public double Long { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; } = null!;
        public string? EntryFee { get; set; }
        public string? OpeningHours { get; set; }
        public string MainImage { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<SiteMedium> SiteMedia { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
    }
}
