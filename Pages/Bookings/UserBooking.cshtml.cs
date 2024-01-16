using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetHotel.Data;
using PetHotel.Models;

namespace PetHotel.Pages.Bookings
{
    public class UserBookingModel : PageModel
    {
        private readonly PetHotel.Data.PetHotelContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserBookingModel(PetHotel.Data.PetHotelContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["RoomId"] = new SelectList(_context.Room.Include(r => r.Category).Where(r => r.isOccupied == true), "Id", "DisplayText");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = new Booking();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            // Find the Owner based on the user's email
            var owner = _context.Owner.FirstOrDefault(o => o.Email == currentUser.Email);

            if (owner == null)
            {
                return NotFound();
            }

            // Set the OwnerId based on the found Owner's Id
            Booking.Pet.OwnerId = owner.Id;

            // Add the pet to the context and set the PetId for the booking
            _context.Pet.Add(Booking.Pet);
            Booking.PetId = Booking.Pet.Id;

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
