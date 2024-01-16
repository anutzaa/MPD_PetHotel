using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetHotel.Data;
using PetHotel.Models;

namespace PetHotel.Pages.Pets
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly PetHotel.Data.PetHotelContext _context;

        public CreateModel(PetHotel.Data.PetHotelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["OwnerId"] = new SelectList(_context.Set<Owner>(), "Id", "OwnerName");
            return Page();
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pet.Add(Pet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
