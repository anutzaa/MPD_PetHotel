﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetHotel.Data;
using PetHotel.Models;

namespace PetHotel.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly PetHotel.Data.PetHotelContext _context;

        public IndexModel(PetHotel.Data.PetHotelContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Room = await _context.Room
                .Include(r => r.Category).ToListAsync();
        }
    }
}
