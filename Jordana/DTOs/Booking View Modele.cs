namespace Jordana.DTOs
{
    public class Booking_View_Modele
    {
        public string SiteName{ get; set; }
        public string StartDate{ get; set; }
        public string Location { get; set; }
        public string InvitedMembers { get; set; }
        public string TotalPrice { get; set; }
        public bool? IsAccpted { get; set; }
        public int BookingId { get; set; }
    }
}
