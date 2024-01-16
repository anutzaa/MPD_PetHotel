using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetHotel.Data;
using PetHotel.Models;

namespace PetHotel.Pages.Owners
{
    public class DetailsModel : PageModel
    {
        private readonly PetHotel.Data.PetHotelContext _context;

        public DetailsModel(PetHotel.Data.PetHotelContext context)
        {
            _context = context;
        }

        public Owner Owner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owner
             .Include(o => o.Pets)
                 .ThenInclude(p => p.Bookings)
             .FirstOrDefaultAsync(m => m.Id == id);

            if (owner == null)
            {
                return NotFound();
            }
            else
            {
                Owner = owner;
            }
            return Page();
        }
    }
}
