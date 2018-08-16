using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogTrials.Models;

namespace DogTrials.Pages.Clubs
{
    public class EditModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public EditModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Club Club { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Club = await _context.Clubs.SingleOrDefaultAsync(m => m.ID == id);

            if (Club == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Club).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(Club.ID))
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

        private bool ClubExists(int id)
        {
            return _context.Clubs.Any(e => e.ID == id);
        }
    }
}
