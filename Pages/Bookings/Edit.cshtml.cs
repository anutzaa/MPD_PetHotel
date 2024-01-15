using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetHotel.Data;
using PetHotel.Models;

namespace PetHotel.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly PetHotel.Data.PetHotelContext _context;

        public EditModel(PetHotel.Data.PetHotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Pet)
                .Include(b => b.Room)
                    .ThenInclude(r => r.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            Booking = booking;

            ViewData["PetId"] = new SelectList(_context.Set<Pet>(), "Id", "PetName");
            ViewData["RoomId"] = new SelectList(_context.Room.Include(r => r.Category).Where(r => r.isOccupied == true), "Id", "DisplayText");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["PetId"] = new SelectList(_context.Set<Pet>(), "Id", "PetName");
                ViewData["RoomId"] = new SelectList(_context.Room.Include(r => r.Category).Where(r => r.isOccupied == true), "Id", "DisplayText");
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}
