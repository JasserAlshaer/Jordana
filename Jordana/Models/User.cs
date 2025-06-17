using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [StringLength(100)]
        public string? CreatedBy { get; set; }

        [StringLength(100)]
        public string? UpdatedBy { get; set; }
        
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
   
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#\$%\^&\*]).{8,}$",
        ErrorMessage = "Password must include uppercase, lowercase, digit, and special character.")]
        public string Password { get; set; } = null!;


        [Required]
        [StringLength(50)]
        public string UserType { get; set; } = null!;

        [StringLength(255)]
        public string ProfileImage { get; set; } = null!;
        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Only digits allowed")]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(255)]
        public string? EmailConfirmationToken { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;


        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
    
    }
}
