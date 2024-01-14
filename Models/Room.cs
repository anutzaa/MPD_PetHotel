using System.ComponentModel.DataAnnotations;

namespace PetHotel.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; }

        [Display(Name = "Availability")]
        public bool isOccupied { get; set; }

        [Display(Name = "Room Type")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
