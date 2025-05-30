using System;
using System.Collections.Generic;

namespace Jordana.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
            UserFavorites = new HashSet<UserFavorite>();
        }

        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserType { get; set; } = null!;
        public string ProfileImage { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
    }
}
