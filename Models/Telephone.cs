using System.ComponentModel.DataAnnotations;

namespace TelephoneApp.Models
{
    public class Telephone
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Broj karaktera izmedju 3 i 120")]
        public string Model { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Broj karaktera izmedju 2 i 30")]
        public string OperatingSystem { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "Dostupna kolicina moze biti u rasponu od 0 do 1000")]
        public int AvailableAmount { get; set; }
        [Required]
        [Range(1.0, 250000.0)]
        public decimal Price { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
