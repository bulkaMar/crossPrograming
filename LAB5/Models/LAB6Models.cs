using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LAB5.Models
{
    public class LAB6Models
    {
        public class Car
        {
            [Key]
            [JsonProperty("licenceNumber")]
            public string LicenceNumber { get; set; }

            [JsonProperty("modelCode")]
            public int ModelCode { get; set; }

            [JsonProperty("customerId")]
            public int CustomerId { get; set; }

            [JsonProperty("currentMileage")]
            public int CurrentMileage { get; set; }

            [JsonProperty("engineSize")]
            public double EngineSize { get; set; }

            [JsonProperty("otherCarDetails")]
            public string OtherCarDetails { get; set; }

            [JsonProperty("model")]
            public Model Model { get; set; }

            [JsonProperty("customer")]
            public Customer Customer { get; set; }
        }

        public class Model
        {
            [Key]
            [JsonProperty("modelCode")]
            public int ModelCode { get; set; }

            [JsonProperty("manufacturerCode")]
            public int ManufacturerCode { get; set; }

            [JsonProperty("modelName")]
            public string ModelName { get; set; }

            [JsonProperty("otherModelDetails")]
            public string OtherModelDetails { get; set; }

            [JsonProperty("manufacturer")]
            public Manufacturer Manufacturer { get; set; }

            [JsonProperty("cars")]
            public ICollection<Car> Cars { get; set; }
        }

        public class Manufacturer
        {
            [Key]
            [JsonProperty("manufacturerCode")]
            public int ManufacturerCode { get; set; }

            [JsonProperty("manufacturerName")]
            public string ManufacturerName { get; set; }

            [JsonProperty("otherManufacturerDetails")]
            public string OtherManufacturerDetails { get; set; }

            [JsonProperty("models")]
            public ICollection<Model> Models { get; set; }
        }

        public class Customer
        {
            [JsonProperty("customerId")]
            public int CustomerId { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("gender")]
            public string Gender { get; set; }

            [JsonProperty("emailAddress")]
            [EmailAddress]
            public string EmailAddress { get; set; }

            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }

            [JsonProperty("addressLine1")]
            public string AddressLine1 { get; set; }

            [JsonProperty("addressLine2")]
            public string AddressLine2 { get; set; }

            [JsonProperty("addressLine3")]
            public string AddressLine3 { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("otherCustomerDetails")]
            public string OtherCustomerDetails { get; set; }

            [JsonProperty("cars")]
            public ICollection<Car> Cars { get; set; }
        }

        public class ServiceBooking
        {
            [Key]
            [JsonProperty("svcBookingId")]
            public int SvcBookingId { get; set; }

            [JsonProperty("customerId")]
            public int CustomerId { get; set; }

            [JsonProperty("licenceNumber")]
            public string LicenceNumber { get; set; }

            [JsonProperty("paymentReceivedYN")]
            public bool PaymentReceivedYN { get; set; }

            [JsonProperty("dateTimeOfService")]
            public DateTime DateTimeOfService { get; set; }

            [JsonProperty("otherSvcBookingDetails")]
            public string OtherSvcBookingDetails { get; set; }

            [JsonProperty("customer")]
            public Customer Customer { get; set; }

            [JsonProperty("car")]
            public Car Car { get; set; }

            [JsonProperty("mechanicsOnServices")]
            public ICollection<MechanicOnService> MechanicsOnServices { get; set; }
        }

        public class MechanicOnService
        {
            [Key]
            [JsonProperty("mechanicOnServiceId")]
            public int MechanicOnServiceId { get; set; }

            [JsonProperty("mechanicId")]
            public int MechanicId { get; set; }

            [JsonProperty("svcBookingId")]
            public int SvcBookingId { get; set; }

            [JsonProperty("otherMechanicOnServiceDetails")]
            public string OtherMechanicOnServiceDetails { get; set; }

            [JsonProperty("serviceBooking")]
            public ServiceBooking ServiceBooking { get; set; }
        }
    }
}
