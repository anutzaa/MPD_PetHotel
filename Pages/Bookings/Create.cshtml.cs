using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetHotel.Data;
using PetHotel.Models;

namespace PetHotel.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly PetHotel.Data.PetHotelContext _context;

        public CreateModel(PetHotel.Data.PetHotelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PetId"] = new SelectList(_context.Set<Pet>(), "Id", "PetName");
            ViewData["RoomId"] = new SelectList(_context.Room.Include(r => r.Category).Where(r => r.isOccupied == true), "Id", "DisplayText");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            if (Booking.RoomId.HasValue)
            {
                var bookedRoom = await _context.Room.FindAsync(Booking.RoomId);
                if (bookedRoom != null)
                {
                    bookedRoom.isOccupied = false;
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./Index");
        }


    }
}
