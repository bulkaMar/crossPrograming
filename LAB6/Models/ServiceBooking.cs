using System.ComponentModel.DataAnnotations;

namespace LAB6.Models
{
    public class ServiceBooking
    {
        [Key]
        public int SvcBookingId { get; set; }
        public int CustomerId { get; set; }
        public string LicenceNumber { get; set; }
        public bool PaymentReceivedYN { get; set; }
        public DateTime DateTimeOfService { get; set; }
        public string OtherSvcBookingDetails { get; set; }

        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public ICollection<MechanicOnService> MechanicsOnServices { get; set; }
    }

}
