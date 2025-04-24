using System.ComponentModel.DataAnnotations;

namespace CustomerEntryApp.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(maximumLength:50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0, 110)]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$", ErrorMessage = "Postcode Must contain characters and numbers.")]
        public string Postcode { get; set; } = string.Empty;
        [Required]
        [Range(0,2.50, ErrorMessage = "Height must be between 0 and 2.50")]
        public double Height { get; set; }
    }
}
