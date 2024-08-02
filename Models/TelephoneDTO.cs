using System;

namespace TelephoneApp.Models
{
    public class TelephoneDTO
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string OperatingSystem { get; set; }

        public int AvailableAmount { get; set; }

        public decimal Price { get; set; }

        public string ProducerName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TelephoneDTO dTO &&
                   Id == dTO.Id &&
                   Model == dTO.Model &&
                   OperatingSystem == dTO.OperatingSystem &&
                   AvailableAmount == dTO.AvailableAmount &&
                   Price == dTO.Price &&
                   ProducerName == dTO.ProducerName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Model, OperatingSystem, AvailableAmount, Price, ProducerName);
        }
    }
}
