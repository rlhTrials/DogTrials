using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogTrials.Models;

namespace DogTrials.Pages.Trials
{
    public class CreateModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public CreateModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClubID"] = new SelectList(_context.Clubs, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Trial Trial { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trials.Add(Trial);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}