using System.ComponentModel.DataAnnotations;

namespace PetHotel.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Display(Name ="Check-in date")]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check-out date")]
        public DateTime CheckOut { get; set; }

        //nav properties & foreign keys
        public int? PetId { get; set; }
        public Pet? Pet { get; set; }

        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        
    }
}
