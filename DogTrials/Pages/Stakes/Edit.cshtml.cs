using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogTrials.Models;

namespace DogTrials.Pages.Stakes
{
    public class EditModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public EditModel(DogTrials.Models.DogTrialsContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Stake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StakeExists(Stake.ID))
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

        private bool StakeExists(int id)
        {
            return _context.Stakes.Any(e => e.ID == id);
        }
    }
}
