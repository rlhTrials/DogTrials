using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogTrials.Models;

namespace DogTrials.Pages.Stakes
{
    public class DeleteModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public DeleteModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stake Stake { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stake = await _context.Stakes.SingleOrDefaultAsync(m => m.ID == id);

            if (Stake == null)
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

            Stake = await _context.Stakes.FindAsync(id);

            if (Stake != null)
            {
                _context.Stakes.Remove(Stake);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
