using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogTrials.Models;

namespace DogTrials.Pages.Trials
{
    public class DeleteModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public DeleteModel(DogTrials.Models.DogTrialsContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trial = await _context.Trials.FindAsync(id);

            if (Trial != null)
            {
                _context.Trials.Remove(Trial);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
