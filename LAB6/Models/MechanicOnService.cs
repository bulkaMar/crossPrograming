using System.ComponentModel.DataAnnotations;

namespace LAB6.Models
{
    public class MechanicOnService
    {
        [Key]
        public int MechanicId { get; set; }
        [Key]
        public int SvcBookingId { get; set; }

        public Mechanic Mechanic { get; set; }
        public ServiceBooking ServiceBooking { get; set; }
        // Зворотний зв'язок з MechanicOnService
    }

}
