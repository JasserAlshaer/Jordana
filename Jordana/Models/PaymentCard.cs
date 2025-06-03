namespace Jordana.Models
{
    public class PaymentCard
    {
        public int PaymentId { get; set; }
        public string Visa { get; set; }
        public string Cvv2 { get; set; }
        public DateTime? ExpireDate { get; set; }
        public double? Balance { get; set; }
    }
}
