using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IndexModel(PetHotel.Data.PetHotelContext context)
        {
            _context = context;
        }

        public IList<Pet> Pet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pet = await _context.Pet
                .Include(b=>b.Owner)
                .ToListAsync();
        }
    }
}
