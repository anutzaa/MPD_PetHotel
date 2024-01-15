using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHotel.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; }

        public string? Image {  get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        [Required(ErrorMessage ="Please upload an image.")]
        public IFormFile? ImageFile { get; set; }

        public bool isOccupied { get; set; }
        public string Description { get; set; }


        //foreign key
        [Display(Name = "Room Type")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
