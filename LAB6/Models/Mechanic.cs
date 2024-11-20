using System.ComponentModel.DataAnnotations;

namespace LAB6.Models
{
    public class Mechanic
    {
        public int MechanicId { get; set; }
        public string MechanicName { get; set; }
        public string OtherMechanicDetails { get; set; }

        public ICollection<MechanicOnService> MechanicOnServices { get; set; }
    }

}
