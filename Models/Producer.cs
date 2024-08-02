using System.ComponentModel.DataAnnotations;

namespace TelephoneApp.Models
{
    public class Producer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Broj karaktera izmedju 1 i 20")]
        public string Name { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Broj karaktera izmedju 2 i 60")]
        public string CountryOrigin { get; set; }
    }
}
