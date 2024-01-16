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

namespace PetHotel.Pages.Pets
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

        public IList<Pet> Pet { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null)
                {
                    if (await _userManager.IsInRoleAsync(currentUser, "Admin"))
                    {
                        // If the user is an admin, show all pets
                        Pet = await _context.Pet
                            .Include(p => p.Owner)
                            .ToListAsync();
                    }
                    else
                    {
                        // If the user is not an admin, filter pets by owner
                        Pet = await _context.Pet
                            .Include(p => p.Owner)
                            .Where(p => p.Owner.Email == currentUser.Email)
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
