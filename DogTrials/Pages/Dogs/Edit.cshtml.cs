using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogTrials.Models;
using DogTrials.Pages.People;

namespace DogTrials.Pages.Dogs
{
    public class EditModel : PersonNamePageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public EditModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dogs
                .Include(c => c.Owner)
                .SingleOrDefaultAsync(m => m.ID == id);

            if (Dog == null)
            {
                return NotFound();
            }

            PopulatePersonNamesDropDownList(_context, Dog.OwnerID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(Dog.ID))
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

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.ID == id);
        }
    }
}
