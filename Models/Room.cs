using System.ComponentModel.DataAnnotations;

namespace PetHotel.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; }

        public int Availability { get; set; }

        [Display(Name = "Room Type")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
