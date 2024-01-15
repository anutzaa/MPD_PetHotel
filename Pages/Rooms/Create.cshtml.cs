using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.Extensions.Hosting;
using PetHotel.Data;
using PetHotel.Models;

namespace PetHotel.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly PetHotel.Data.PetHotelContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CreateModel(PetHotel.Data.PetHotelContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Room Room { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Process and save the uploaded image
            if (Room.ImageFile != null && Room.ImageFile.Length > 0)
            {
                var fileExtension = Path.GetExtension(Room.ImageFile.FileName).ToLower();
                var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".pdf" }; // add the desired image extensions here

                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("Room.ImageFile", "Invalid file type. Please select a valid image file.");
                    return Page();
                }
                var fileName = Path.GetFileName(Room.ImageFile.FileName);
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    Room.ImageFile.CopyTo(stream);
                }

                Room.Image = Path.Combine("images", fileName);
            }
            else
            {
                ModelState.AddModelError("Room.ImageFile", "Please select an image.");
                return Page();
            }

            _context.Room.Add(Room);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
