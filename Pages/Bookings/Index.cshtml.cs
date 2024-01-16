using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetHotel.Data;
using PetHotel.Models;

namespace PetHotel.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly PetHotel.Data.PetHotelContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(PetHotel.Data.PetHotelContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null)
                {
                    if (await _userManager.IsInRoleAsync(currentUser, "Admin"))
                    {
                        // If the user is an admin, show all bookings
                        Booking = await _context.Booking
                            .Include(b => b.Pet)
                            .Include(b => b.Room)
                            .ThenInclude(r => r.Category)
                            .ToListAsync();
                    }
                    else
                    {
                        // If the user is not an admin, filter bookings by owner
                        Booking = await _context.Booking
                            .Include(b => b.Pet)
                            .Include(b => b.Room)
                            .ThenInclude(r => r.Category)
                            .Where(b => b.Pet.Owner.Email == currentUser.Email)
                            .ToListAsync();
                    }

                    return Page();
                }
            }

            // If the user is not authenticated, redirect them to the login page
            return RedirectToPage("/Account/Login");
        }


    }
}
