using System.ComponentModel.DataAnnotations;

namespace LAB6.Models
{
    public class Car
    {
        [Key]
        public string LicenceNumber { get; set; }
        public int ModelCode { get; set; }
        public int CustomerId { get; set; }
        public int CurrentMileage { get; set; }
        public double EngineSize { get; set; }
        public string OtherCarDetails { get; set; }

        public Model Model { get; set; }
        public Customer Customer { get; set; }
    }

}
