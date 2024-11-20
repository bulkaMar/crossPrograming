using System.ComponentModel.DataAnnotations;

namespace LAB6.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string OtherManufacturerDetails { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}
