using System;
using System.Collections.Generic;

namespace Jordana.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingMembers = new HashSet<BookingMember>();
        }

        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingStatus { get; set; } = null!;
        public DateTime BookingEndDate { get; set; }
        public double Price { get; set; }
        public string Transportation { get; set; } = null!;
        public bool? IsAccpted { get; set; }
        public virtual TouristsSite Site { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<BookingMember> BookingMembers { get; set; }
    
    }
}
