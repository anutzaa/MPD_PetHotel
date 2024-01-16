using System.ComponentModel.DataAnnotations;

namespace PetHotel.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [Display(Name ="Check-in date")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check-out date")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        //foreign keys
        public int? PetId { get; set; }
        public Pet? Pet { get; set; }

        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        
    }
}
