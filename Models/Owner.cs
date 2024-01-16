using System.ComponentModel.DataAnnotations;

namespace PetHotel.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Display(Name = "Owner Name")]
        [RegularExpression(@"(?:[A-Z][a-z]*\s*)+", ErrorMessage = "Name must start with a capital letter!")]

        [StringLength(30, MinimumLength = 3)]
        public string? OwnerName { get; set; }

        public string? Phone { get; set; }

        [RegularExpression(@"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        //navigation properties:
        public ICollection<Pet>? Pets { get; set; } = new List<Pet>();
    }
}
