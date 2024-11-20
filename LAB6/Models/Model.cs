using System.ComponentModel.DataAnnotations;

namespace LAB6.Models
{
    public class Model
    {
        [Key]
        public int ModelCode { get; set; }
        public int ManufacturerCode { get; set; }
        public string ModelName { get; set; }
        public string OtherModelDetails { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}
