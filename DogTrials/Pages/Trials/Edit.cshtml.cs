using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogTrials.Models;

namespace DogTrials.Pages.Trials
{
    public class EditModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public EditModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trial Trial { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trial = await _context.Trials
                .Include(t => t.Club).SingleOrDefaultAsync(m => m.ID == id);

            if (Trial == null)
            {
                return NotFound();
            }
           ViewData["ClubID"] = new SelectList(_context.Clubs, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Trial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrialExists(Trial.ID))
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

        private bool TrialExists(int id)
        {
            return _context.Trials.Any(e => e.ID == id);
        }
    }
}
