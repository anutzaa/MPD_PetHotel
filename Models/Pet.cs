using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PetHotel.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Display(Name = "Pet Name")]
        [RegularExpression(@"(?:[A-Z][a-z]*\s*)+", ErrorMessage = "Name must start with a capital letter!")]
        public string PetName { get; set; }
        public string Species { get; set; }
  

        [Display(Name = "Age in months")]
        public int Age { get; set; }


        [Display(Name = "Special needs")]
        public bool hasSpecialNeeds { get; set; }

        //navigation property for Owner
        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }

        // Navigation property
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

