using System.ComponentModel.DataAnnotations;

namespace PetHotel.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        //navigation properties:
        public ICollection<Pet>? Pets { get; set; } //= new List<Pet>();
    }
}
