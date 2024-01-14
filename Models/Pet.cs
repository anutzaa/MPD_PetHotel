using System.ComponentModel.DataAnnotations;

namespace PetHotel.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Display(Name = "Pet Name")]
        public string Name { get; set; }
        public string Species { get; set; }
        public string Race { get; set; }

        [Display(Name = "Age in months")]
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Comments { get; set; }

        //navigation property for Owner
        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
