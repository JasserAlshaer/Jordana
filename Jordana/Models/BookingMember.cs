using System;
using System.Collections.Generic;

namespace Jordana.Models
{
    public partial class BookingMember
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public int BookingId { get; set; }
        public int MemId { get; set; }
        public int Age { get; set; }
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string? NationalId { get; set; }
        public string? PassportNumber { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string ReferencePhoneNumber { get; set; } = null!;
        public string ReferenceName { get; set; } = null!;
        public string Relationship { get; set; } = null!;

        public virtual Booking Booking { get; set; } = null!;
    }
}
