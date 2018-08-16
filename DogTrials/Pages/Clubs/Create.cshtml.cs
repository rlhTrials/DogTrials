using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogTrials.Models;

namespace DogTrials.Pages.Clubs
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
            return Page();
        }

        [BindProperty]
        public Club Club { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clubs.Add(Club);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}